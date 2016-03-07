Shader "ARPG/character/fake scroll light" {
	Properties {
		_Tint ("Color Tint", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SpecularColor ("Specular Color", Color) = (1,1,1,1)
		_SpecPower ("Specular Power", Range(0.1, 60)) = 3
		_LightDir ("Fake Light Dir", Vector) = (0,0,1,1)
		_Cutoff ("alpha test", Range(0,1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Lighting off
		
		CGPROGRAM
		#pragma surface surf CustomBlinnPhong alphatest:_Cutoff

		sampler2D _MainTex;
		float4 _SpecularColor;
		float4 _LightDir;
		float _SpecPower;
		float4 _Tint;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {	
			
			float3 halfVector = normalize (_LightDir.rgb);			
			float diff = max (0, dot (o.Normal, _LightDir.rgb));
			float nh = max (0, dot (o.Normal, halfVector));
			float spec = pow (nh, _SpecPower) * _SpecularColor;
			
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Emission = c.rgb * _Tint.rgb + ( _SpecularColor.rgb * spec) ;
			o.Alpha = c.a;
		}	
		
		half4 LightingCustomBlinnPhong (SurfaceOutput s, fixed3 lightDir, fixed atten){				
			float4 c;
			c.rgb = s.Albedo ;
			c.a = s.Alpha;
			return c;
		}	
		
		ENDCG
	} 
	FallBack "Diffuse"
}
