Shader "Custom/Wave"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        
        _Intensity ("Intensity", Range(0, 50)) = 0
        _ShaderWave ("ShaderWave", Range(0, 1)) = 0
        _Value ("Wave value", Range(0, 50)) = 0
        _SinScale ("SinScale", Range(0.01, 2)) = 0
        _HorizontalMove ("HorizontalMove", Range(-100, 100)) = 0
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            // use "vert" function as the vertex shader
            #pragma vertex vert
            // use "frag" function as the pixel (fragment) shader
            #pragma fragment frag


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
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
 
            sampler2D _MainTex;
            half _Intensity;
            half _HorizontalMove;
			half _Value;
			half _SinScale;
			half _ShaderWave;
         
            fixed4 frag (v2f i) : SV_Target
            {
                if(_ShaderWave == 1)
                {
                    i.uv.y += ((sin(((_Time.y*_SinScale + i.uv.x)) * _Intensity)/20 )* _Value);
                    i.uv.x += _Time *_HorizontalMove;
                }
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
