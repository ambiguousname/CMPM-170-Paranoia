Shader "Unlit/Eyes"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        ZWrite Off
        Blend SrcAlpha
        OneMinusSrcAlpha
        Cull back
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "Packages/jp.keijiro.noiseshader/Shader/ClassicNoise2D.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                float otherNoise = ClassicNoise((i.uv + float2(50.f, 50.f)) * 100.f * (sin(_Time.x/10.f) + 1.f));
                float noise = ClassicNoise((float2(_Time.x * otherNoise / 100.f, _Time.y/10.0f) + i.uv) * 10.0f);
                float red = 10.0f * noise * otherNoise;
                return half4(red * (cos(50.0f * _Time.x) + 0.5f), 0, 0, 1.0f);
}
            ENDCG
        }
    }
}
