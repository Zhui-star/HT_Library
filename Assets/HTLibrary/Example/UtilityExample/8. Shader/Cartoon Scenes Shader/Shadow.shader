﻿
	Shader "Custom/Chapter9_Shadow" {
	Properties{
	_Color("Color",Color)=(1,1,1,1)
	_SpecularColor("Specular",Color)=(1,1,1,1)
	_Gloss("Gloss",Range(8.0,256))=20
	}
 
	SubShader{
	Pass{
		Tags{"LightMode"="ForwardBase"}
 
		CGPROGRAM
		#pragma multi_compile_fwdbase
		#pragma vertex vert
		#pragma fragment frag
 
		#include "Lighting.cginc"
		#include "AutoLight.cginc" 
		//计算阴影所用的宏包含在AutoLight.cginc文件中
 
		fixed4 _Color;
		fixed4 _SpecularColor;
		float   _Gloss;
 
		struct a2v{
			float4  vertex:POSITION;
			float3  normal:NORMAL; 
		};
 
		struct v2f{
			float4 pos:SV_POSITION;
			float3 worldPos:TEXCOORD0;
			float3 worldNormal:TEXCOORD1;
			SHADOW_COORDS(2) 
			//该宏的作用是声明一个用于对阴影纹理采样的坐标
			//这个宏的参数是下一个可用的插值寄存器的索引值，上述中为2
		};
 
		v2f vert(a2v v){
			v2f o;
			o.pos=UnityObjectToClipPos(v.vertex);
			o.worldPos=mul(unity_ObjectToWorld,v.vertex).xyz;
			o.worldNormal=UnityObjectToWorldNormal(v.normal);
 
			TRANSFER_SHADOW(o);
			//该宏用于计算上一步声明的阴影纹理采样坐标
 
			return o;
		}
 
		fixed4 frag(v2f i):SV_Target{
			float3 worldLightDir=normalize(UnityWorldSpaceLightDir(i.worldPos));
			float3 worldNormal=normalize(i.worldNormal);
			float3 worldViewDir=normalize(UnityWorldSpaceViewDir(i.worldPos));
 
			fixed3 ambient=UNITY_LIGHTMODEL_AMBIENT.xyz;
			fixed3 diffuse=_LightColor0.rgb*_Color.rgb*max(0,dot(worldLightDir,worldNormal));
			fixed3 halfDir=normalize(worldLightDir+worldViewDir);
			fixed3 specularColor=_LightColor0.rgb*_SpecularColor.rgb*pow(saturate(dot(halfDir,worldNormal)),_Gloss);
 
			fixed shadow=SHADOW_ATTENUATION(i);
			//片元着色器中计算阴影值
 
			fixed atten=1.0;
			return fixed4(ambient+(diffuse+specularColor)*shadow,1.0);
		}
		ENDCG
	}
 
	}
	FallBack "Specular"

	} 