Shader "ARPG/character/flow" {
	Properties {
		_Tint ("Color Tint", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_AdditiveTex ("Distort Texture (RG)", 2D) = "white" {}
		_ScrollXSpeed ("X Scroll Speed",Range(0,10)) = 2
		_ScrollYSpeed ("Y Scroll Speed",Range(0,10)) = 2
	    _Cutoff ("alpha test", Range(0,1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Lighting off
		
		CGPROGRAM
		#pragma surface surf NoLight alphatest:_Cutoff

		
		sampler2D _MainTex;
		sampler2D _AdditiveTex;
		fixed _ScrollXSpeed;
		fixed _ScrollYSpeed;
		float4 _Tint;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed2 scrolledUV = IN.uv_MainTex;
			
			fixed xScrollValue = _ScrollXSpeed * _Time;
			fixed yScrollValue = _ScrollYSpeed * _Time;
			
			scrolledUV += fixed2(xScrollValue, yScrollValue);
			
			half4 m = tex2D (_MainTex, IN.uv_MainTex);
			half4 add = tex2D (_AdditiveTex, scrolledUV);
			o.Emission = (m.rgb + add.rgb * add.a) * _Tint.rgb;
			o.Alpha = m.a;
		}
		
		half4 LightingNoLight (SurfaceOutput s, fixed3 lightDir, fixed atten){
      		float4 c;
			c.rgb = float3(0,0,0);
			c.a = s.Alpha;
			return c;
      	}
		ENDCG
	} 
	FallBack "Diffuse"
}
