Shader "Custom/SaturationThreshold"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Threshold ("Saturation Threshold", Range(0, 1)) = 0.2
        _ReplacementColor ("Replacement Color", Color) = (1, 0, 0, 1)
    }
    
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "Cull"="Off"}
        Cull Off
        LOD 100

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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Threshold;
            float4 _ReplacementColor;

            float3 RGBtoHSV(float3 rgb)
            {
                float maxC = max(rgb.r, max(rgb.g, rgb.b));
                float minC = min(rgb.r, min(rgb.g, rgb.b));
                float delta = maxC - minC;
                
                float h = 0;
                float s = 0;
                float v = maxC;
                
                if (delta > 0.0001)
                {
                    s = delta / maxC;
                    
                    if (rgb.r >= maxC)
                        h = (rgb.g - rgb.b) / delta;
                    else if (rgb.g >= maxC)
                        h = 2.0 + (rgb.b - rgb.r) / delta;
                    else
                        h = 4.0 + (rgb.r - rgb.g) / delta;
                    
                    h *= 60.0;
                    if (h < 0) h += 360.0;
                    h /= 360.0;
                }
                
                return float3(h, s, v);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float3 hsv = RGBtoHSV(col.rgb);
                
                if (hsv.y > _Threshold)
                {
                    return _ReplacementColor;
                }
                
                return col;
            }
            ENDCG
        }
    }
}
