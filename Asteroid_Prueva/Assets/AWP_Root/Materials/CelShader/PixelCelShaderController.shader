Shader "Custom/URP_PixelCelShader_V2"
{
    Properties
    {
        _MainTex ("Texture (Base Color)", 2D) = "white" {}
        [Normal] _BumpMap ("Normal Map", 2D) = "bump" {}
        _Levels ("Cel Levels", Float) = 3
        _BumpStrength ("Normal Strength", Range(0, 3)) = 1
        _PixelStep ("Pixel Density", Float) = 80
        _BaseColor ("Tint Color", Color) = (1,1,1,1)
        _Ambient ("Ambient Light", Range(0, 1)) = 0.2
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque" 
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry"
        }

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
                float3 normalOS     : NORMAL;
                float4 tangentOS    : TANGENT;
            };

            struct Varyings
            {
                float4 positionCS   : SV_POSITION;
                float2 uv           : TEXCOORD0;
                float3 normalWS     : TEXCOORD1;
                float4 tangentWS    : TEXCOORD2; 
            };

            // Definición correcta de texturas en URP
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D(_BumpMap);
            SAMPLER(sampler_BumpMap);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _BaseColor;
                float _Levels;
                float _BumpStrength;
                float _PixelStep;
                float _Ambient;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                // Transformaciones de posición
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                
                // Aplicar Tiling y Offset de la textura principal
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);

                // Normales y Tangentes
                VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);
                output.normalWS = normalInput.normalWS;
                output.tangentWS = float4(normalInput.tangentWS, input.tangentOS.w);

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // 1. Pixelado de UVs
                float2 uvPix = floor(input.uv * _PixelStep) / _PixelStep;

                // 2. Normal Mapping
                // Desempaquetamos la normal del mapa
                half4 bumpSample = SAMPLE_TEXTURE2D(_BumpMap, sampler_BumpMap, uvPix);
                half3 normalTS = UnpackNormalScale(bumpSample, _BumpStrength);
                
                // Construcción de la matriz TBN
                half3 bitangentWS = cross(input.normalWS, input.tangentWS.xyz) * input.tangentWS.w;
                half3x3 tangentToWorld = half3x3(input.tangentWS.xyz, bitangentWS, input.normalWS);
                
                // Normal final en espacio de mundo
                half3 normalWS = normalize(mul(normalTS, tangentToWorld));

                // 3. Iluminación
                Light mainLight = GetMainLight();
                half3 lightDir = normalize(mainLight.direction);
                
                // Dot product para luz difusa
                half ndotl = dot(normalWS, lightDir);
                
                // Cel Shading (Half-Lambertizado)
                half diff = saturate(ndotl * 0.5 + 0.5);
                half cel = floor(diff * _Levels) / _Levels;
                
                // Mezcla de luz ambiental y color de la luz principal
                half3 lightColor = mainLight.color * max(cel, _Ambient);

                // 4. Muestreo de textura de color
                half4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uvPix);
                
                // Combinación final
                half3 finalColor = texColor.rgb * _BaseColor.rgb * lightColor;

                return half4(finalColor, texColor.a);
            }
            ENDHLSL
        }
    }
    Fallback "Universal Render Pipeline/Lit"
}