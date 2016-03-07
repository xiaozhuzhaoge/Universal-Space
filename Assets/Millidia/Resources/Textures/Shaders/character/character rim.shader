Shader "ARPG/character/rim" {
	 Properties {
	  _Tint ("Color Tint", Color) = (1,1,1,1)
      _MainTex ("Texture", 2D) = "white" {}
      _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
      _Cutoff ("alpha test", Range(0,1)) = 0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      
      Lighting off
      
      CGPROGRAM
      #pragma surface surf NoLight alphatest:_Cutoff
      struct Input {
          float2 uv_MainTex;
          float3 viewDir;
      };
      sampler2D _MainTex;
      float4 _RimColor;
      float _RimPower;
      float4 _Tint;

      void surf (Input IN, inout SurfaceOutput o) {
      	  half4 m = tex2D (_MainTex, IN.uv_MainTex); 
          o.Albedo = m.rgb * _Tint.rgb;
          half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
          o.Emission = _RimColor.rgb * pow (rim, _RimPower) + o.Albedo;
          o.Alpha = m.a * _Tint.a;
      }
      
      half4 LightingNoLight (SurfaceOutput s, fixed3 lightDir, fixed atten){
      		float4 c;
			c.rgb = float3(0,0,0);
			c.a = s.Alpha;
			return c;
      }

      ENDCG
    } 
    Fallback "Diffuse"
}
