Shader "ARPG/character/fake scroll light + flow" {
	Properties {
		_Tint ("Color Tint", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_AdditiveTex ("Distort Texture (RG)", 2D) = "white" {}
		_ScrollXSpeed ("X Scroll Speed",Range(0,10)) = 2
		_ScrollYSpeed ("Y Scroll Speed",Range(0,10)) = 2
		_SpecularColor ("Specular Color", Color) = (1,1,1,1)
		_SpecPower ("Specular Power", Range(0.1, 60)) = 3
		_LightDir ("Fake Light Dir", Vector) = (0,0,1,1)
		_Cutoff ("alpha test", Range(0,1)) = 0
		_NowTime ("now time", Float) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Lighting off
		
		CGPROGRAM
		#pragma surface surf CustomBlinnPhong alphatest:_Cutoff

		sampler2D _MainTex;
		sampler2D _AdditiveTex;
		fixed _ScrollXSpeed;
		fixed _ScrollYSpeed;
		float4 _SpecularColor;
		float4 _LightDir;
		float _SpecPower;
		float4 _Tint;
		float _NowTime;
		
		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed2 scrolledUV = IN.uv_MainTex;
			
			fixed xScrollValue = _ScrollXSpeed * _NowTime;
			fixed yScrollValue = _ScrollYSpeed * _NowTime;
			
			scrolledUV += fixed2(xScrollValue, yScrollValue);
			
			half4 m = tex2D (_MainTex, IN.uv_MainTex);
			half4 add = tex2D (_AdditiveTex, scrolledUV);
			o.Emission = (m.rgb + add.rgb * add.a)*_Tint.rgb;
//			o.Albedo = float3(0,0,0);
			o.Alpha = m.a;
			
			float3 halfVector = normalize (_LightDir.rgb);			
			float diff = max (0, dot (o.Normal, _LightDir.rgb));
			float nh = max (0, dot (o.Normal, halfVector));
			float spec = pow (nh, _SpecPower) * _SpecularColor;
			o.Emission += ( _SpecularColor.rgb * spec);
		}	
		
		half4 LightingCustomBlinnPhong (SurfaceOutput s, fixed3 lightDir, fixed atten){	
			
			float4 c;			
			c.rgb = float3(0,0,0);			
			c.a = s.Alpha;
			return c;
		}	
		
		ENDCG
	} 
	FallBack "Diffuse"
}
