Shader "ARPG/character/no colored no alpha" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Cutoff ("Value Testing", Range(0,1)) = 0.5
	}
	SubShader {
		Pass{
			Tags { "RenderType"="Transparent" }
			
			Lighting off
			
			CGPROGRAM
			#pragma vertex vert_img
	        #pragma fragment frag
	        
	        #include "UnityCG.cginc"

			sampler2D _MainTex;
			float _Cutoff;
			
			float4 frag(v2f_img i) : COLOR {
	            float4 temp = tex2D(_MainTex, i.uv);
	            if (temp.r + temp.g + temp.b == 0 && temp.a < _Cutoff)
           		{
               		discard;
            	}
            	temp.a = 1;
	            return temp;
	        }	
	        
			ENDCG
		} 
	}
	FallBack "Diffuse"
}
