Shader "PostProcess/CelShading"
{
    Properties
    {
        _Levels ("Cel Levels", Float) = 4
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline"}
        LOD 100
        ZTest Always ZWrite Off Cull Off

        Pass
        {
            Name "CelPass"
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            // ESTA LINEA ES LA CLAVE EN UNITY 6
            #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

            struct Varyings {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float _Levels;

            // El vértice ahora es más simple usando Blit.hlsl
            Varyings vert (uint vertexID : SV_VertexID) {
                Varyings output;
                output.positionCS = GetFullScreenTriangleVertexPosition(vertexID);
                output.uv = GetFullScreenTriangleTexCoord(vertexID);
                return output;
            }

            half4 frag (Varyings input) : SV_Target {
                // Usamos _BlitTexture que es la que pasa el Full Screen Pass
                half4 col = SAMPLE_TEXTURE2D(_BlitTexture, sampler_LinearClamp, input.uv);
                
                // Convertimos a brillo
                float lum = dot(col.rgb, float3(0.2126, 0.7152, 0.0722));
                
                // Si el brillo es casi cero, no dividimos para evitar errores
                if(lum < 0.01) return col;

                // Aplicamos el Cel
                float cel = floor(lum * _Levels) / _Levels;
                col.rgb *= (cel / lum);

                return col;
            }
            ENDHLSL
        }
    }
}
