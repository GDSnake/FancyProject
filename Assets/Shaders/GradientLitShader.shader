/*
Simple Circular Gradient Shader Made by Gonçalo Delgado
*/

Shader "Custom/GradientLit" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_ColorForeground("ColorForeground", Color) = (0, 0, 0, 1)
		_ColorBackground("ColorBackground", Color) = (1, 0, 0, 1)
		_Mult("Mult",Float) = 1.0
		_Sum("Sum", Float) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		uniform float4 _ColorBackground;
		uniform float4 _ColorForeground;

		uniform float _Mult;
		uniform float _Sum;

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			float distfromcenter = distance(float2(0.5f, 0.5f), IN.uv_MainTex);
			float4 rColor = lerp(_ColorBackground, _ColorForeground, saturate(log(distfromcenter*_Mult + _Sum)));
			float4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			c.rgb = rColor;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
