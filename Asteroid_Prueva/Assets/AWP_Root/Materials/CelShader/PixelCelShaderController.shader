Shader "Custom/PixelCelShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _LightDir ("Light Direction", Vector) = (0,1,0,0)
        _Levels ("Levels", Float) = 3
        _BumpStrength ("Normal Strength", Float) = 1
        _PixelStep ("Pixel Step", Float) = 1
        _Color ("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;
            };

            sampler2D _MainTex;
            sampler2D _BumpMap;
            float4 _Color;
            float3 _LightDir;
            float _Levels;
            float _BumpStrength;
            float _PixelStep;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 normalTex = UnpackNormal(tex2D(_BumpMap, i.uv));
                normalTex *= _BumpStrength;

                float3 normal = normalize(i.normal + normalTex);
                float3 lightDir = normalize(_LightDir);

                float intensity = dot(normal, lightDir);

                float cel = floor(intensity * _Levels) / _Levels;
                cel = saturate(cel);

                float2 uv = floor(i.uv * _PixelStep) / _PixelStep;

                fixed4 tex = tex2D(_MainTex, uv);

                float3 col = tex.rgb * _Color.rgb * cel;

                return fixed4(col, tex.a);
            }

            ENDCG
        }
    }
}