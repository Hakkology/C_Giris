Shader "Hidden/PostEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // bir vertex shader�m�z var bir de fragment shader�m�z var, ikisi i�inde farkl� fonksiyonlar var.

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                // data al�p vertexleri de�i�tirebilirsiniz.
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                // her pixel i�in �al���r. 1920x1080 => 2 milyon piksel.
                // nas�l ya ?
                fixed4 col = tex2D(_MainTex, i.uv);
                // fixed4 col = tex2D(_MainTex, i.uv + float2(0, 0.1f));
                // fixed col = tex2D(_MainTex, IN.uv + float2(0, sin(IN.vertex.x/50) /10 + _Time[1]));
                // Main tex direk ekran�m�z.
                // just invert the colors
                col.rgb = 1 - col.rgb;
                // denemeler yapal�m:
                // col.r = 1;
                return col;
            }
            ENDCG
        }
    }
}