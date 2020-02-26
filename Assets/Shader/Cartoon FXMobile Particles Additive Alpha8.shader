Shader "Cartoon FX/Mobile Particles Additive Alpha8" {
	Properties {
		_MainTex ("Particle Texture (Alpha8)", 2D) = "white" {}
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha One, SrcAlpha One
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 38786
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  mediump vec4 tmpvar_2;
					  tmpvar_2 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_1 = tmpvar_2;
					  highp vec4 tmpvar_3;
					  tmpvar_3.w = 1.0;
					  tmpvar_3.xyz = _glesVertex.xyz;
					  xlv_COLOR0 = tmpvar_1;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 col_1;
					  col_1.xyz = xlv_COLOR0.xyz;
					  col_1.w = (texture2D (_MainTex, xlv_TEXCOORD0).w * xlv_COLOR0.w);
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  mediump vec4 tmpvar_2;
					  tmpvar_2 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_1 = tmpvar_2;
					  highp vec4 tmpvar_3;
					  tmpvar_3.w = 1.0;
					  tmpvar_3.xyz = _glesVertex.xyz;
					  xlv_COLOR0 = tmpvar_1;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 col_1;
					  col_1.xyz = xlv_COLOR0.xyz;
					  col_1.w = (texture2D (_MainTex, xlv_TEXCOORD0).w * xlv_COLOR0.w);
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  mediump vec4 tmpvar_2;
					  tmpvar_2 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_1 = tmpvar_2;
					  highp vec4 tmpvar_3;
					  tmpvar_3.w = 1.0;
					  tmpvar_3.xyz = _glesVertex.xyz;
					  xlv_COLOR0 = tmpvar_1;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 col_1;
					  col_1.xyz = xlv_COLOR0.xyz;
					  col_1.w = (texture2D (_MainTex, xlv_TEXCOORD0).w * xlv_COLOR0.w);
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp float u_xlat10_0;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy).w;
					    SV_Target0.w = u_xlat10_0 * vs_COLOR0.w;
					    SV_Target0.xyz = vs_COLOR0.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp float u_xlat10_0;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy).w;
					    SV_Target0.w = u_xlat10_0 * vs_COLOR0.w;
					    SV_Target0.xyz = vs_COLOR0.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp float u_xlat10_0;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy).w;
					    SV_Target0.w = u_xlat10_0 * vs_COLOR0.w;
					    SV_Target0.xyz = vs_COLOR0.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "vulkan hw_tier00 " {
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 113
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Vertex %4 "main" %9 %11 %21 %24 %47 %98 
					                                                     OpDecorate %9 RelaxedPrecision 
					                                                     OpDecorate %9 Location 9 
					                                                     OpDecorate %11 RelaxedPrecision 
					                                                     OpDecorate %11 Location 11 
					                                                     OpDecorate %12 RelaxedPrecision 
					                                                     OpDecorate %13 RelaxedPrecision 
					                                                     OpDecorate %16 RelaxedPrecision 
					                                                     OpDecorate %17 RelaxedPrecision 
					                                                     OpDecorate %18 RelaxedPrecision 
					                                                     OpDecorate %21 Location 21 
					                                                     OpDecorate %24 Location 24 
					                                                     OpDecorate %29 ArrayStride 29 
					                                                     OpDecorate %30 ArrayStride 30 
					                                                     OpMemberDecorate %31 0 Offset 31 
					                                                     OpMemberDecorate %31 1 Offset 31 
					                                                     OpMemberDecorate %31 2 Offset 31 
					                                                     OpDecorate %31 Block 
					                                                     OpDecorate %33 DescriptorSet 33 
					                                                     OpDecorate %33 Binding 33 
					                                                     OpDecorate %47 Location 47 
					                                                     OpMemberDecorate %96 0 BuiltIn 96 
					                                                     OpMemberDecorate %96 1 BuiltIn 96 
					                                                     OpMemberDecorate %96 2 BuiltIn 96 
					                                                     OpDecorate %96 Block 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 4 
					                                              %8 = OpTypePointer Output %7 
					                                Output f32_4* %9 = OpVariable Output 
					                                             %10 = OpTypePointer Input %7 
					                                Input f32_4* %11 = OpVariable Input 
					                                         f32 %14 = OpConstant 3.674022E-40 
					                                         f32 %15 = OpConstant 3.674022E-40 
					                                             %19 = OpTypeVector %6 2 
					                                             %20 = OpTypePointer Output %19 
					                               Output f32_2* %21 = OpVariable Output 
					                                             %22 = OpTypeVector %6 3 
					                                             %23 = OpTypePointer Input %22 
					                                Input f32_3* %24 = OpVariable Input 
					                                             %27 = OpTypeInt 32 0 
					                                         u32 %28 = OpConstant 4 
					                                             %29 = OpTypeArray %7 %28 
					                                             %30 = OpTypeArray %7 %28 
					                                             %31 = OpTypeStruct %29 %30 %7 
					                                             %32 = OpTypePointer Uniform %31 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4;}* %33 = OpVariable Uniform 
					                                             %34 = OpTypeInt 32 1 
					                                         i32 %35 = OpConstant 2 
					                                             %36 = OpTypePointer Uniform %7 
					                                             %45 = OpTypePointer Private %7 
					                              Private f32_4* %46 = OpVariable Private 
					                                Input f32_3* %47 = OpVariable Input 
					                                         i32 %50 = OpConstant 0 
					                                         i32 %51 = OpConstant 1 
					                                         i32 %70 = OpConstant 3 
					                              Private f32_4* %74 = OpVariable Private 
					                                         u32 %94 = OpConstant 1 
					                                             %95 = OpTypeArray %6 %94 
					                                             %96 = OpTypeStruct %7 %6 %95 
					                                             %97 = OpTypePointer Output %96 
					        Output struct {f32_4; f32; f32[1];}* %98 = OpVariable Output 
					                                            %107 = OpTypePointer Output %6 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %12 = OpLoad %11 
					                                                     OpStore %9 %12 
					                                       f32_4 %13 = OpLoad %9 
					                                       f32_4 %16 = OpCompositeConstruct %14 %14 %14 %14 
					                                       f32_4 %17 = OpCompositeConstruct %15 %15 %15 %15 
					                                       f32_4 %18 = OpExtInst %1 43 %13 %16 %17 
					                                                     OpStore %9 %18 
					                                       f32_3 %25 = OpLoad %24 
					                                       f32_2 %26 = OpVectorShuffle %25 %25 0 1 
					                              Uniform f32_4* %37 = OpAccessChain %33 %35 
					                                       f32_4 %38 = OpLoad %37 
					                                       f32_2 %39 = OpVectorShuffle %38 %38 0 1 
					                                       f32_2 %40 = OpFMul %26 %39 
					                              Uniform f32_4* %41 = OpAccessChain %33 %35 
					                                       f32_4 %42 = OpLoad %41 
					                                       f32_2 %43 = OpVectorShuffle %42 %42 2 3 
					                                       f32_2 %44 = OpFAdd %40 %43 
					                                                     OpStore %21 %44 
					                                       f32_3 %48 = OpLoad %47 
					                                       f32_4 %49 = OpVectorShuffle %48 %48 1 1 1 1 
					                              Uniform f32_4* %52 = OpAccessChain %33 %50 %51 
					                                       f32_4 %53 = OpLoad %52 
					                                       f32_4 %54 = OpFMul %49 %53 
					                                                     OpStore %46 %54 
					                              Uniform f32_4* %55 = OpAccessChain %33 %50 %50 
					                                       f32_4 %56 = OpLoad %55 
					                                       f32_3 %57 = OpLoad %47 
					                                       f32_4 %58 = OpVectorShuffle %57 %57 0 0 0 0 
					                                       f32_4 %59 = OpFMul %56 %58 
					                                       f32_4 %60 = OpLoad %46 
					                                       f32_4 %61 = OpFAdd %59 %60 
					                                                     OpStore %46 %61 
					                              Uniform f32_4* %62 = OpAccessChain %33 %50 %35 
					                                       f32_4 %63 = OpLoad %62 
					                                       f32_3 %64 = OpLoad %47 
					                                       f32_4 %65 = OpVectorShuffle %64 %64 2 2 2 2 
					                                       f32_4 %66 = OpFMul %63 %65 
					                                       f32_4 %67 = OpLoad %46 
					                                       f32_4 %68 = OpFAdd %66 %67 
					                                                     OpStore %46 %68 
					                                       f32_4 %69 = OpLoad %46 
					                              Uniform f32_4* %71 = OpAccessChain %33 %50 %70 
					                                       f32_4 %72 = OpLoad %71 
					                                       f32_4 %73 = OpFAdd %69 %72 
					                                                     OpStore %46 %73 
					                                       f32_4 %75 = OpLoad %46 
					                                       f32_4 %76 = OpVectorShuffle %75 %75 1 1 1 1 
					                              Uniform f32_4* %77 = OpAccessChain %33 %51 %51 
					                                       f32_4 %78 = OpLoad %77 
					                                       f32_4 %79 = OpFMul %76 %78 
					                                                     OpStore %74 %79 
					                              Uniform f32_4* %80 = OpAccessChain %33 %51 %50 
					                                       f32_4 %81 = OpLoad %80 
					                                       f32_4 %82 = OpLoad %46 
					                                       f32_4 %83 = OpVectorShuffle %82 %82 0 0 0 0 
					                                       f32_4 %84 = OpFMul %81 %83 
					                                       f32_4 %85 = OpLoad %74 
					                                       f32_4 %86 = OpFAdd %84 %85 
					                                                     OpStore %74 %86 
					                              Uniform f32_4* %87 = OpAccessChain %33 %51 %35 
					                                       f32_4 %88 = OpLoad %87 
					                                       f32_4 %89 = OpLoad %46 
					                                       f32_4 %90 = OpVectorShuffle %89 %89 2 2 2 2 
					                                       f32_4 %91 = OpFMul %88 %90 
					                                       f32_4 %92 = OpLoad %74 
					                                       f32_4 %93 = OpFAdd %91 %92 
					                                                     OpStore %74 %93 
					                              Uniform f32_4* %99 = OpAccessChain %33 %51 %70 
					                                      f32_4 %100 = OpLoad %99 
					                                      f32_4 %101 = OpLoad %46 
					                                      f32_4 %102 = OpVectorShuffle %101 %101 3 3 3 3 
					                                      f32_4 %103 = OpFMul %100 %102 
					                                      f32_4 %104 = OpLoad %74 
					                                      f32_4 %105 = OpFAdd %103 %104 
					                              Output f32_4* %106 = OpAccessChain %98 %50 
					                                                     OpStore %106 %105 
					                                Output f32* %108 = OpAccessChain %98 %50 %94 
					                                        f32 %109 = OpLoad %108 
					                                        f32 %110 = OpFNegate %109 
					                                Output f32* %111 = OpAccessChain %98 %50 %94 
					                                                     OpStore %111 %110 
					                                                     OpReturn
					                                                     OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 40
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %16 %24 %27 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %8 RelaxedPrecision 
					                                                    OpDecorate %12 RelaxedPrecision 
					                                                    OpDecorate %12 DescriptorSet 12 
					                                                    OpDecorate %12 Binding 12 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %16 Location 16 
					                                                    OpDecorate %22 RelaxedPrecision 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %24 Location 24 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpDecorate %27 Location 27 
					                                                    OpDecorate %30 RelaxedPrecision 
					                                                    OpDecorate %31 RelaxedPrecision 
					                                                    OpDecorate %35 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypePointer Private %6 
					                                Private f32* %8 = OpVariable Private 
					                                             %9 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %10 = OpTypeSampledImage %9 
					                                            %11 = OpTypePointer UniformConstant %10 
					UniformConstant read_only Texture2DSampled* %12 = OpVariable UniformConstant 
					                                            %14 = OpTypeVector %6 2 
					                                            %15 = OpTypePointer Input %14 
					                               Input f32_2* %16 = OpVariable Input 
					                                            %18 = OpTypeVector %6 4 
					                                            %20 = OpTypeInt 32 0 
					                                        u32 %21 = OpConstant 3 
					                                            %23 = OpTypePointer Output %18 
					                              Output f32_4* %24 = OpVariable Output 
					                                            %26 = OpTypePointer Input %18 
					                               Input f32_4* %27 = OpVariable Input 
					                                            %28 = OpTypePointer Input %6 
					                                            %32 = OpTypePointer Output %6 
					                                            %34 = OpTypeVector %6 3 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %13 = OpLoad %12 
					                                      f32_2 %17 = OpLoad %16 
					                                      f32_4 %19 = OpImageSampleImplicitLod %13 %17 
					                                        f32 %22 = OpCompositeExtract %19 3 
					                                                    OpStore %8 %22 
					                                        f32 %25 = OpLoad %8 
					                                 Input f32* %29 = OpAccessChain %27 %21 
					                                        f32 %30 = OpLoad %29 
					                                        f32 %31 = OpFMul %25 %30 
					                                Output f32* %33 = OpAccessChain %24 %21 
					                                                    OpStore %33 %31 
					                                      f32_4 %35 = OpLoad %27 
					                                      f32_3 %36 = OpVectorShuffle %35 %35 0 1 2 
					                                      f32_4 %37 = OpLoad %24 
					                                      f32_4 %38 = OpVectorShuffle %37 %36 4 5 6 3 
					                                                    OpStore %24 %38 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier01 " {
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 113
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Vertex %4 "main" %9 %11 %21 %24 %47 %98 
					                                                     OpDecorate %9 RelaxedPrecision 
					                                                     OpDecorate %9 Location 9 
					                                                     OpDecorate %11 RelaxedPrecision 
					                                                     OpDecorate %11 Location 11 
					                                                     OpDecorate %12 RelaxedPrecision 
					                                                     OpDecorate %13 RelaxedPrecision 
					                                                     OpDecorate %16 RelaxedPrecision 
					                                                     OpDecorate %17 RelaxedPrecision 
					                                                     OpDecorate %18 RelaxedPrecision 
					                                                     OpDecorate %21 Location 21 
					                                                     OpDecorate %24 Location 24 
					                                                     OpDecorate %29 ArrayStride 29 
					                                                     OpDecorate %30 ArrayStride 30 
					                                                     OpMemberDecorate %31 0 Offset 31 
					                                                     OpMemberDecorate %31 1 Offset 31 
					                                                     OpMemberDecorate %31 2 Offset 31 
					                                                     OpDecorate %31 Block 
					                                                     OpDecorate %33 DescriptorSet 33 
					                                                     OpDecorate %33 Binding 33 
					                                                     OpDecorate %47 Location 47 
					                                                     OpMemberDecorate %96 0 BuiltIn 96 
					                                                     OpMemberDecorate %96 1 BuiltIn 96 
					                                                     OpMemberDecorate %96 2 BuiltIn 96 
					                                                     OpDecorate %96 Block 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 4 
					                                              %8 = OpTypePointer Output %7 
					                                Output f32_4* %9 = OpVariable Output 
					                                             %10 = OpTypePointer Input %7 
					                                Input f32_4* %11 = OpVariable Input 
					                                         f32 %14 = OpConstant 3.674022E-40 
					                                         f32 %15 = OpConstant 3.674022E-40 
					                                             %19 = OpTypeVector %6 2 
					                                             %20 = OpTypePointer Output %19 
					                               Output f32_2* %21 = OpVariable Output 
					                                             %22 = OpTypeVector %6 3 
					                                             %23 = OpTypePointer Input %22 
					                                Input f32_3* %24 = OpVariable Input 
					                                             %27 = OpTypeInt 32 0 
					                                         u32 %28 = OpConstant 4 
					                                             %29 = OpTypeArray %7 %28 
					                                             %30 = OpTypeArray %7 %28 
					                                             %31 = OpTypeStruct %29 %30 %7 
					                                             %32 = OpTypePointer Uniform %31 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4;}* %33 = OpVariable Uniform 
					                                             %34 = OpTypeInt 32 1 
					                                         i32 %35 = OpConstant 2 
					                                             %36 = OpTypePointer Uniform %7 
					                                             %45 = OpTypePointer Private %7 
					                              Private f32_4* %46 = OpVariable Private 
					                                Input f32_3* %47 = OpVariable Input 
					                                         i32 %50 = OpConstant 0 
					                                         i32 %51 = OpConstant 1 
					                                         i32 %70 = OpConstant 3 
					                              Private f32_4* %74 = OpVariable Private 
					                                         u32 %94 = OpConstant 1 
					                                             %95 = OpTypeArray %6 %94 
					                                             %96 = OpTypeStruct %7 %6 %95 
					                                             %97 = OpTypePointer Output %96 
					        Output struct {f32_4; f32; f32[1];}* %98 = OpVariable Output 
					                                            %107 = OpTypePointer Output %6 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %12 = OpLoad %11 
					                                                     OpStore %9 %12 
					                                       f32_4 %13 = OpLoad %9 
					                                       f32_4 %16 = OpCompositeConstruct %14 %14 %14 %14 
					                                       f32_4 %17 = OpCompositeConstruct %15 %15 %15 %15 
					                                       f32_4 %18 = OpExtInst %1 43 %13 %16 %17 
					                                                     OpStore %9 %18 
					                                       f32_3 %25 = OpLoad %24 
					                                       f32_2 %26 = OpVectorShuffle %25 %25 0 1 
					                              Uniform f32_4* %37 = OpAccessChain %33 %35 
					                                       f32_4 %38 = OpLoad %37 
					                                       f32_2 %39 = OpVectorShuffle %38 %38 0 1 
					                                       f32_2 %40 = OpFMul %26 %39 
					                              Uniform f32_4* %41 = OpAccessChain %33 %35 
					                                       f32_4 %42 = OpLoad %41 
					                                       f32_2 %43 = OpVectorShuffle %42 %42 2 3 
					                                       f32_2 %44 = OpFAdd %40 %43 
					                                                     OpStore %21 %44 
					                                       f32_3 %48 = OpLoad %47 
					                                       f32_4 %49 = OpVectorShuffle %48 %48 1 1 1 1 
					                              Uniform f32_4* %52 = OpAccessChain %33 %50 %51 
					                                       f32_4 %53 = OpLoad %52 
					                                       f32_4 %54 = OpFMul %49 %53 
					                                                     OpStore %46 %54 
					                              Uniform f32_4* %55 = OpAccessChain %33 %50 %50 
					                                       f32_4 %56 = OpLoad %55 
					                                       f32_3 %57 = OpLoad %47 
					                                       f32_4 %58 = OpVectorShuffle %57 %57 0 0 0 0 
					                                       f32_4 %59 = OpFMul %56 %58 
					                                       f32_4 %60 = OpLoad %46 
					                                       f32_4 %61 = OpFAdd %59 %60 
					                                                     OpStore %46 %61 
					                              Uniform f32_4* %62 = OpAccessChain %33 %50 %35 
					                                       f32_4 %63 = OpLoad %62 
					                                       f32_3 %64 = OpLoad %47 
					                                       f32_4 %65 = OpVectorShuffle %64 %64 2 2 2 2 
					                                       f32_4 %66 = OpFMul %63 %65 
					                                       f32_4 %67 = OpLoad %46 
					                                       f32_4 %68 = OpFAdd %66 %67 
					                                                     OpStore %46 %68 
					                                       f32_4 %69 = OpLoad %46 
					                              Uniform f32_4* %71 = OpAccessChain %33 %50 %70 
					                                       f32_4 %72 = OpLoad %71 
					                                       f32_4 %73 = OpFAdd %69 %72 
					                                                     OpStore %46 %73 
					                                       f32_4 %75 = OpLoad %46 
					                                       f32_4 %76 = OpVectorShuffle %75 %75 1 1 1 1 
					                              Uniform f32_4* %77 = OpAccessChain %33 %51 %51 
					                                       f32_4 %78 = OpLoad %77 
					                                       f32_4 %79 = OpFMul %76 %78 
					                                                     OpStore %74 %79 
					                              Uniform f32_4* %80 = OpAccessChain %33 %51 %50 
					                                       f32_4 %81 = OpLoad %80 
					                                       f32_4 %82 = OpLoad %46 
					                                       f32_4 %83 = OpVectorShuffle %82 %82 0 0 0 0 
					                                       f32_4 %84 = OpFMul %81 %83 
					                                       f32_4 %85 = OpLoad %74 
					                                       f32_4 %86 = OpFAdd %84 %85 
					                                                     OpStore %74 %86 
					                              Uniform f32_4* %87 = OpAccessChain %33 %51 %35 
					                                       f32_4 %88 = OpLoad %87 
					                                       f32_4 %89 = OpLoad %46 
					                                       f32_4 %90 = OpVectorShuffle %89 %89 2 2 2 2 
					                                       f32_4 %91 = OpFMul %88 %90 
					                                       f32_4 %92 = OpLoad %74 
					                                       f32_4 %93 = OpFAdd %91 %92 
					                                                     OpStore %74 %93 
					                              Uniform f32_4* %99 = OpAccessChain %33 %51 %70 
					                                      f32_4 %100 = OpLoad %99 
					                                      f32_4 %101 = OpLoad %46 
					                                      f32_4 %102 = OpVectorShuffle %101 %101 3 3 3 3 
					                                      f32_4 %103 = OpFMul %100 %102 
					                                      f32_4 %104 = OpLoad %74 
					                                      f32_4 %105 = OpFAdd %103 %104 
					                              Output f32_4* %106 = OpAccessChain %98 %50 
					                                                     OpStore %106 %105 
					                                Output f32* %108 = OpAccessChain %98 %50 %94 
					                                        f32 %109 = OpLoad %108 
					                                        f32 %110 = OpFNegate %109 
					                                Output f32* %111 = OpAccessChain %98 %50 %94 
					                                                     OpStore %111 %110 
					                                                     OpReturn
					                                                     OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 40
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %16 %24 %27 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %8 RelaxedPrecision 
					                                                    OpDecorate %12 RelaxedPrecision 
					                                                    OpDecorate %12 DescriptorSet 12 
					                                                    OpDecorate %12 Binding 12 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %16 Location 16 
					                                                    OpDecorate %22 RelaxedPrecision 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %24 Location 24 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpDecorate %27 Location 27 
					                                                    OpDecorate %30 RelaxedPrecision 
					                                                    OpDecorate %31 RelaxedPrecision 
					                                                    OpDecorate %35 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypePointer Private %6 
					                                Private f32* %8 = OpVariable Private 
					                                             %9 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %10 = OpTypeSampledImage %9 
					                                            %11 = OpTypePointer UniformConstant %10 
					UniformConstant read_only Texture2DSampled* %12 = OpVariable UniformConstant 
					                                            %14 = OpTypeVector %6 2 
					                                            %15 = OpTypePointer Input %14 
					                               Input f32_2* %16 = OpVariable Input 
					                                            %18 = OpTypeVector %6 4 
					                                            %20 = OpTypeInt 32 0 
					                                        u32 %21 = OpConstant 3 
					                                            %23 = OpTypePointer Output %18 
					                              Output f32_4* %24 = OpVariable Output 
					                                            %26 = OpTypePointer Input %18 
					                               Input f32_4* %27 = OpVariable Input 
					                                            %28 = OpTypePointer Input %6 
					                                            %32 = OpTypePointer Output %6 
					                                            %34 = OpTypeVector %6 3 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %13 = OpLoad %12 
					                                      f32_2 %17 = OpLoad %16 
					                                      f32_4 %19 = OpImageSampleImplicitLod %13 %17 
					                                        f32 %22 = OpCompositeExtract %19 3 
					                                                    OpStore %8 %22 
					                                        f32 %25 = OpLoad %8 
					                                 Input f32* %29 = OpAccessChain %27 %21 
					                                        f32 %30 = OpLoad %29 
					                                        f32 %31 = OpFMul %25 %30 
					                                Output f32* %33 = OpAccessChain %24 %21 
					                                                    OpStore %33 %31 
					                                      f32_4 %35 = OpLoad %27 
					                                      f32_3 %36 = OpVectorShuffle %35 %35 0 1 2 
					                                      f32_4 %37 = OpLoad %24 
					                                      f32_4 %38 = OpVectorShuffle %37 %36 4 5 6 3 
					                                                    OpStore %24 %38 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier02 " {
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 113
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Vertex %4 "main" %9 %11 %21 %24 %47 %98 
					                                                     OpDecorate %9 RelaxedPrecision 
					                                                     OpDecorate %9 Location 9 
					                                                     OpDecorate %11 RelaxedPrecision 
					                                                     OpDecorate %11 Location 11 
					                                                     OpDecorate %12 RelaxedPrecision 
					                                                     OpDecorate %13 RelaxedPrecision 
					                                                     OpDecorate %16 RelaxedPrecision 
					                                                     OpDecorate %17 RelaxedPrecision 
					                                                     OpDecorate %18 RelaxedPrecision 
					                                                     OpDecorate %21 Location 21 
					                                                     OpDecorate %24 Location 24 
					                                                     OpDecorate %29 ArrayStride 29 
					                                                     OpDecorate %30 ArrayStride 30 
					                                                     OpMemberDecorate %31 0 Offset 31 
					                                                     OpMemberDecorate %31 1 Offset 31 
					                                                     OpMemberDecorate %31 2 Offset 31 
					                                                     OpDecorate %31 Block 
					                                                     OpDecorate %33 DescriptorSet 33 
					                                                     OpDecorate %33 Binding 33 
					                                                     OpDecorate %47 Location 47 
					                                                     OpMemberDecorate %96 0 BuiltIn 96 
					                                                     OpMemberDecorate %96 1 BuiltIn 96 
					                                                     OpMemberDecorate %96 2 BuiltIn 96 
					                                                     OpDecorate %96 Block 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 4 
					                                              %8 = OpTypePointer Output %7 
					                                Output f32_4* %9 = OpVariable Output 
					                                             %10 = OpTypePointer Input %7 
					                                Input f32_4* %11 = OpVariable Input 
					                                         f32 %14 = OpConstant 3.674022E-40 
					                                         f32 %15 = OpConstant 3.674022E-40 
					                                             %19 = OpTypeVector %6 2 
					                                             %20 = OpTypePointer Output %19 
					                               Output f32_2* %21 = OpVariable Output 
					                                             %22 = OpTypeVector %6 3 
					                                             %23 = OpTypePointer Input %22 
					                                Input f32_3* %24 = OpVariable Input 
					                                             %27 = OpTypeInt 32 0 
					                                         u32 %28 = OpConstant 4 
					                                             %29 = OpTypeArray %7 %28 
					                                             %30 = OpTypeArray %7 %28 
					                                             %31 = OpTypeStruct %29 %30 %7 
					                                             %32 = OpTypePointer Uniform %31 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4;}* %33 = OpVariable Uniform 
					                                             %34 = OpTypeInt 32 1 
					                                         i32 %35 = OpConstant 2 
					                                             %36 = OpTypePointer Uniform %7 
					                                             %45 = OpTypePointer Private %7 
					                              Private f32_4* %46 = OpVariable Private 
					                                Input f32_3* %47 = OpVariable Input 
					                                         i32 %50 = OpConstant 0 
					                                         i32 %51 = OpConstant 1 
					                                         i32 %70 = OpConstant 3 
					                              Private f32_4* %74 = OpVariable Private 
					                                         u32 %94 = OpConstant 1 
					                                             %95 = OpTypeArray %6 %94 
					                                             %96 = OpTypeStruct %7 %6 %95 
					                                             %97 = OpTypePointer Output %96 
					        Output struct {f32_4; f32; f32[1];}* %98 = OpVariable Output 
					                                            %107 = OpTypePointer Output %6 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %12 = OpLoad %11 
					                                                     OpStore %9 %12 
					                                       f32_4 %13 = OpLoad %9 
					                                       f32_4 %16 = OpCompositeConstruct %14 %14 %14 %14 
					                                       f32_4 %17 = OpCompositeConstruct %15 %15 %15 %15 
					                                       f32_4 %18 = OpExtInst %1 43 %13 %16 %17 
					                                                     OpStore %9 %18 
					                                       f32_3 %25 = OpLoad %24 
					                                       f32_2 %26 = OpVectorShuffle %25 %25 0 1 
					                              Uniform f32_4* %37 = OpAccessChain %33 %35 
					                                       f32_4 %38 = OpLoad %37 
					                                       f32_2 %39 = OpVectorShuffle %38 %38 0 1 
					                                       f32_2 %40 = OpFMul %26 %39 
					                              Uniform f32_4* %41 = OpAccessChain %33 %35 
					                                       f32_4 %42 = OpLoad %41 
					                                       f32_2 %43 = OpVectorShuffle %42 %42 2 3 
					                                       f32_2 %44 = OpFAdd %40 %43 
					                                                     OpStore %21 %44 
					                                       f32_3 %48 = OpLoad %47 
					                                       f32_4 %49 = OpVectorShuffle %48 %48 1 1 1 1 
					                              Uniform f32_4* %52 = OpAccessChain %33 %50 %51 
					                                       f32_4 %53 = OpLoad %52 
					                                       f32_4 %54 = OpFMul %49 %53 
					                                                     OpStore %46 %54 
					                              Uniform f32_4* %55 = OpAccessChain %33 %50 %50 
					                                       f32_4 %56 = OpLoad %55 
					                                       f32_3 %57 = OpLoad %47 
					                                       f32_4 %58 = OpVectorShuffle %57 %57 0 0 0 0 
					                                       f32_4 %59 = OpFMul %56 %58 
					                                       f32_4 %60 = OpLoad %46 
					                                       f32_4 %61 = OpFAdd %59 %60 
					                                                     OpStore %46 %61 
					                              Uniform f32_4* %62 = OpAccessChain %33 %50 %35 
					                                       f32_4 %63 = OpLoad %62 
					                                       f32_3 %64 = OpLoad %47 
					                                       f32_4 %65 = OpVectorShuffle %64 %64 2 2 2 2 
					                                       f32_4 %66 = OpFMul %63 %65 
					                                       f32_4 %67 = OpLoad %46 
					                                       f32_4 %68 = OpFAdd %66 %67 
					                                                     OpStore %46 %68 
					                                       f32_4 %69 = OpLoad %46 
					                              Uniform f32_4* %71 = OpAccessChain %33 %50 %70 
					                                       f32_4 %72 = OpLoad %71 
					                                       f32_4 %73 = OpFAdd %69 %72 
					                                                     OpStore %46 %73 
					                                       f32_4 %75 = OpLoad %46 
					                                       f32_4 %76 = OpVectorShuffle %75 %75 1 1 1 1 
					                              Uniform f32_4* %77 = OpAccessChain %33 %51 %51 
					                                       f32_4 %78 = OpLoad %77 
					                                       f32_4 %79 = OpFMul %76 %78 
					                                                     OpStore %74 %79 
					                              Uniform f32_4* %80 = OpAccessChain %33 %51 %50 
					                                       f32_4 %81 = OpLoad %80 
					                                       f32_4 %82 = OpLoad %46 
					                                       f32_4 %83 = OpVectorShuffle %82 %82 0 0 0 0 
					                                       f32_4 %84 = OpFMul %81 %83 
					                                       f32_4 %85 = OpLoad %74 
					                                       f32_4 %86 = OpFAdd %84 %85 
					                                                     OpStore %74 %86 
					                              Uniform f32_4* %87 = OpAccessChain %33 %51 %35 
					                                       f32_4 %88 = OpLoad %87 
					                                       f32_4 %89 = OpLoad %46 
					                                       f32_4 %90 = OpVectorShuffle %89 %89 2 2 2 2 
					                                       f32_4 %91 = OpFMul %88 %90 
					                                       f32_4 %92 = OpLoad %74 
					                                       f32_4 %93 = OpFAdd %91 %92 
					                                                     OpStore %74 %93 
					                              Uniform f32_4* %99 = OpAccessChain %33 %51 %70 
					                                      f32_4 %100 = OpLoad %99 
					                                      f32_4 %101 = OpLoad %46 
					                                      f32_4 %102 = OpVectorShuffle %101 %101 3 3 3 3 
					                                      f32_4 %103 = OpFMul %100 %102 
					                                      f32_4 %104 = OpLoad %74 
					                                      f32_4 %105 = OpFAdd %103 %104 
					                              Output f32_4* %106 = OpAccessChain %98 %50 
					                                                     OpStore %106 %105 
					                                Output f32* %108 = OpAccessChain %98 %50 %94 
					                                        f32 %109 = OpLoad %108 
					                                        f32 %110 = OpFNegate %109 
					                                Output f32* %111 = OpAccessChain %98 %50 %94 
					                                                     OpStore %111 %110 
					                                                     OpReturn
					                                                     OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 40
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %16 %24 %27 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %8 RelaxedPrecision 
					                                                    OpDecorate %12 RelaxedPrecision 
					                                                    OpDecorate %12 DescriptorSet 12 
					                                                    OpDecorate %12 Binding 12 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %16 Location 16 
					                                                    OpDecorate %22 RelaxedPrecision 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %24 Location 24 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpDecorate %27 Location 27 
					                                                    OpDecorate %30 RelaxedPrecision 
					                                                    OpDecorate %31 RelaxedPrecision 
					                                                    OpDecorate %35 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypePointer Private %6 
					                                Private f32* %8 = OpVariable Private 
					                                             %9 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %10 = OpTypeSampledImage %9 
					                                            %11 = OpTypePointer UniformConstant %10 
					UniformConstant read_only Texture2DSampled* %12 = OpVariable UniformConstant 
					                                            %14 = OpTypeVector %6 2 
					                                            %15 = OpTypePointer Input %14 
					                               Input f32_2* %16 = OpVariable Input 
					                                            %18 = OpTypeVector %6 4 
					                                            %20 = OpTypeInt 32 0 
					                                        u32 %21 = OpConstant 3 
					                                            %23 = OpTypePointer Output %18 
					                              Output f32_4* %24 = OpVariable Output 
					                                            %26 = OpTypePointer Input %18 
					                               Input f32_4* %27 = OpVariable Input 
					                                            %28 = OpTypePointer Input %6 
					                                            %32 = OpTypePointer Output %6 
					                                            %34 = OpTypeVector %6 3 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %13 = OpLoad %12 
					                                      f32_2 %17 = OpLoad %16 
					                                      f32_4 %19 = OpImageSampleImplicitLod %13 %17 
					                                        f32 %22 = OpCompositeExtract %19 3 
					                                                    OpStore %8 %22 
					                                        f32 %25 = OpLoad %8 
					                                 Input f32* %29 = OpAccessChain %27 %21 
					                                        f32 %30 = OpLoad %29 
					                                        f32 %31 = OpFMul %25 %30 
					                                Output f32* %33 = OpAccessChain %24 %21 
					                                                    OpStore %33 %31 
					                                      f32_4 %35 = OpLoad %27 
					                                      f32_3 %36 = OpVectorShuffle %35 %35 0 1 2 
					                                      f32_4 %37 = OpLoad %24 
					                                      f32_4 %38 = OpVectorShuffle %37 %36 4 5 6 3 
					                                                    OpStore %24 %38 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 unity_FogParams;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD1;
					void main ()
					{
					  highp vec3 tmpvar_1;
					  tmpvar_1 = _glesVertex.xyz;
					  highp vec4 tmpvar_2;
					  tmpvar_2.w = 1.0;
					  tmpvar_2.xyz = tmpvar_1;
					  highp vec3 tmpvar_3;
					  tmpvar_3 = ((unity_MatrixV * unity_ObjectToWorld) * tmpvar_2).xyz;
					  lowp vec4 tmpvar_4;
					  mediump vec4 tmpvar_5;
					  tmpvar_5 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_4 = tmpvar_5;
					  highp float tmpvar_6;
					  tmpvar_6 = (unity_FogParams.x * sqrt(dot (tmpvar_3, tmpvar_3)));
					  lowp float tmpvar_7;
					  highp float tmpvar_8;
					  tmpvar_8 = clamp (exp2((
					    -(tmpvar_6)
					   * tmpvar_6)), 0.0, 1.0);
					  tmpvar_7 = tmpvar_8;
					  highp vec4 tmpvar_9;
					  tmpvar_9.w = 1.0;
					  tmpvar_9.xyz = tmpvar_1;
					  xlv_COLOR0 = tmpvar_4;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = tmpvar_7;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_9));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform lowp vec4 unity_FogColor;
					uniform sampler2D _MainTex;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 col_1;
					  col_1.w = (texture2D (_MainTex, xlv_TEXCOORD0).w * xlv_COLOR0.w);
					  col_1.xyz = mix (unity_FogColor.xyz, xlv_COLOR0.xyz, vec3(xlv_TEXCOORD1));
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 unity_FogParams;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD1;
					void main ()
					{
					  highp vec3 tmpvar_1;
					  tmpvar_1 = _glesVertex.xyz;
					  highp vec4 tmpvar_2;
					  tmpvar_2.w = 1.0;
					  tmpvar_2.xyz = tmpvar_1;
					  highp vec3 tmpvar_3;
					  tmpvar_3 = ((unity_MatrixV * unity_ObjectToWorld) * tmpvar_2).xyz;
					  lowp vec4 tmpvar_4;
					  mediump vec4 tmpvar_5;
					  tmpvar_5 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_4 = tmpvar_5;
					  highp float tmpvar_6;
					  tmpvar_6 = (unity_FogParams.x * sqrt(dot (tmpvar_3, tmpvar_3)));
					  lowp float tmpvar_7;
					  highp float tmpvar_8;
					  tmpvar_8 = clamp (exp2((
					    -(tmpvar_6)
					   * tmpvar_6)), 0.0, 1.0);
					  tmpvar_7 = tmpvar_8;
					  highp vec4 tmpvar_9;
					  tmpvar_9.w = 1.0;
					  tmpvar_9.xyz = tmpvar_1;
					  xlv_COLOR0 = tmpvar_4;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = tmpvar_7;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_9));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform lowp vec4 unity_FogColor;
					uniform sampler2D _MainTex;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 col_1;
					  col_1.w = (texture2D (_MainTex, xlv_TEXCOORD0).w * xlv_COLOR0.w);
					  col_1.xyz = mix (unity_FogColor.xyz, xlv_COLOR0.xyz, vec3(xlv_TEXCOORD1));
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 unity_FogParams;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD1;
					void main ()
					{
					  highp vec3 tmpvar_1;
					  tmpvar_1 = _glesVertex.xyz;
					  highp vec4 tmpvar_2;
					  tmpvar_2.w = 1.0;
					  tmpvar_2.xyz = tmpvar_1;
					  highp vec3 tmpvar_3;
					  tmpvar_3 = ((unity_MatrixV * unity_ObjectToWorld) * tmpvar_2).xyz;
					  lowp vec4 tmpvar_4;
					  mediump vec4 tmpvar_5;
					  tmpvar_5 = clamp (_glesColor, 0.0, 1.0);
					  tmpvar_4 = tmpvar_5;
					  highp float tmpvar_6;
					  tmpvar_6 = (unity_FogParams.x * sqrt(dot (tmpvar_3, tmpvar_3)));
					  lowp float tmpvar_7;
					  highp float tmpvar_8;
					  tmpvar_8 = clamp (exp2((
					    -(tmpvar_6)
					   * tmpvar_6)), 0.0, 1.0);
					  tmpvar_7 = tmpvar_8;
					  highp vec4 tmpvar_9;
					  tmpvar_9.w = 1.0;
					  tmpvar_9.xyz = tmpvar_1;
					  xlv_COLOR0 = tmpvar_4;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = tmpvar_7;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_9));
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform lowp vec4 unity_FogColor;
					uniform sampler2D _MainTex;
					varying lowp vec4 xlv_COLOR0;
					varying highp vec2 xlv_TEXCOORD0;
					varying lowp float xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 col_1;
					  col_1.w = (texture2D (_MainTex, xlv_TEXCOORD0).w * xlv_COLOR0.w);
					  col_1.xyz = mix (unity_FogColor.xyz, xlv_COLOR0.xyz, vec3(xlv_TEXCOORD1));
					  gl_FragData[0] = col_1;
					}
					
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 unity_FogParams;
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					out mediump float vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[1].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].xxx + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].zzz + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].www + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * in_POSITION0.yyy;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.xxx + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.zzz + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat0.xyz + u_xlat1.xyz;
					    u_xlat0.x = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat0.x = sqrt(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * unity_FogParams.x;
					    u_xlat0.x = u_xlat0.x * (-u_xlat0.x);
					    vs_TEXCOORD1 = exp2(u_xlat0.x);
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 unity_FogColor;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in mediump float vs_TEXCOORD1;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy).w;
					    SV_Target0.w = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.xyz = vs_COLOR0.xyz + (-unity_FogColor.xyz);
					    SV_Target0.xyz = vec3(vs_TEXCOORD1) * u_xlat16_1.xyz + unity_FogColor.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 unity_FogParams;
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					out mediump float vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[1].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].xxx + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].zzz + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].www + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * in_POSITION0.yyy;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.xxx + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.zzz + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat0.xyz + u_xlat1.xyz;
					    u_xlat0.x = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat0.x = sqrt(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * unity_FogParams.x;
					    u_xlat0.x = u_xlat0.x * (-u_xlat0.x);
					    vs_TEXCOORD1 = exp2(u_xlat0.x);
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 unity_FogColor;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in mediump float vs_TEXCOORD1;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy).w;
					    SV_Target0.w = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.xyz = vs_COLOR0.xyz + (-unity_FogColor.xyz);
					    SV_Target0.xyz = vec3(vs_TEXCOORD1) * u_xlat16_1.xyz + unity_FogColor.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 unity_FogParams;
					uniform 	vec4 _MainTex_ST;
					in highp vec3 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec3 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					out mediump float vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					#ifdef UNITY_ADRENO_ES3
					    vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
					#else
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					#endif
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[1].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].xxx + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].zzz + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[1].www + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * in_POSITION0.yyy;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[0].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.xxx + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[2].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat1.xyz * in_POSITION0.zzz + u_xlat0.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].yyy * hlslcc_mtx4x4unity_MatrixV[1].xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[0].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].xxx + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[2].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].zzz + u_xlat1.xyz;
					    u_xlat1.xyz = hlslcc_mtx4x4unity_MatrixV[3].xyz * hlslcc_mtx4x4unity_ObjectToWorld[3].www + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat0.xyz + u_xlat1.xyz;
					    u_xlat0.x = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat0.x = sqrt(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * unity_FogParams.x;
					    u_xlat0.x = u_xlat0.x * (-u_xlat0.x);
					    vs_TEXCOORD1 = exp2(u_xlat0.x);
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 unity_FogColor;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in mediump float vs_TEXCOORD1;
					layout(location = 0) out mediump vec4 SV_Target0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy).w;
					    SV_Target0.w = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.xyz = vs_COLOR0.xyz + (-unity_FogColor.xyz);
					    SV_Target0.xyz = vec3(vs_TEXCOORD1) * u_xlat16_1.xyz + unity_FogColor.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "vulkan hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 359
					; Schema: 0
					                                                      OpCapability Shader 
					                                               %1 = OpExtInstImport "GLSL.std.450" 
					                                                      OpMemoryModel Logical GLSL450 
					                                                      OpEntryPoint Vertex %4 "main" %9 %11 %21 %24 %99 %295 %345 
					                                                      OpDecorate %9 RelaxedPrecision 
					                                                      OpDecorate %9 Location 9 
					                                                      OpDecorate %11 RelaxedPrecision 
					                                                      OpDecorate %11 Location 11 
					                                                      OpDecorate %12 RelaxedPrecision 
					                                                      OpDecorate %13 RelaxedPrecision 
					                                                      OpDecorate %16 RelaxedPrecision 
					                                                      OpDecorate %17 RelaxedPrecision 
					                                                      OpDecorate %18 RelaxedPrecision 
					                                                      OpDecorate %21 Location 21 
					                                                      OpDecorate %24 Location 24 
					                                                      OpDecorate %29 ArrayStride 29 
					                                                      OpDecorate %30 ArrayStride 30 
					                                                      OpDecorate %31 ArrayStride 31 
					                                                      OpMemberDecorate %32 0 Offset 32 
					                                                      OpMemberDecorate %32 1 Offset 32 
					                                                      OpMemberDecorate %32 2 Offset 32 
					                                                      OpMemberDecorate %32 3 Offset 32 
					                                                      OpMemberDecorate %32 4 Offset 32 
					                                                      OpDecorate %32 Block 
					                                                      OpDecorate %34 DescriptorSet 34 
					                                                      OpDecorate %34 Binding 34 
					                                                      OpDecorate %99 Location 99 
					                                                      OpDecorate %295 RelaxedPrecision 
					                                                      OpDecorate %295 Location 295 
					                                                      OpMemberDecorate %343 0 BuiltIn 343 
					                                                      OpMemberDecorate %343 1 BuiltIn 343 
					                                                      OpMemberDecorate %343 2 BuiltIn 343 
					                                                      OpDecorate %343 Block 
					                                               %2 = OpTypeVoid 
					                                               %3 = OpTypeFunction %2 
					                                               %6 = OpTypeFloat 32 
					                                               %7 = OpTypeVector %6 4 
					                                               %8 = OpTypePointer Output %7 
					                                 Output f32_4* %9 = OpVariable Output 
					                                              %10 = OpTypePointer Input %7 
					                                 Input f32_4* %11 = OpVariable Input 
					                                          f32 %14 = OpConstant 3.674022E-40 
					                                          f32 %15 = OpConstant 3.674022E-40 
					                                              %19 = OpTypeVector %6 2 
					                                              %20 = OpTypePointer Output %19 
					                                Output f32_2* %21 = OpVariable Output 
					                                              %22 = OpTypeVector %6 3 
					                                              %23 = OpTypePointer Input %22 
					                                 Input f32_3* %24 = OpVariable Input 
					                                              %27 = OpTypeInt 32 0 
					                                          u32 %28 = OpConstant 4 
					                                              %29 = OpTypeArray %7 %28 
					                                              %30 = OpTypeArray %7 %28 
					                                              %31 = OpTypeArray %7 %28 
					                                              %32 = OpTypeStruct %29 %30 %31 %7 %7 
					                                              %33 = OpTypePointer Uniform %32 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4[4]; f32_4; f32_4;}* %34 = OpVariable Uniform 
					                                              %35 = OpTypeInt 32 1 
					                                          i32 %36 = OpConstant 4 
					                                              %37 = OpTypePointer Uniform %7 
					                                              %46 = OpTypePointer Private %7 
					                               Private f32_4* %47 = OpVariable Private 
					                                          i32 %48 = OpConstant 0 
					                                          i32 %49 = OpConstant 1 
					                                          i32 %71 = OpConstant 2 
					                                          i32 %84 = OpConstant 3 
					                                 Input f32_3* %99 = OpVariable Input 
					                              Private f32_4* %105 = OpVariable Private 
					                                         u32 %273 = OpConstant 0 
					                                             %274 = OpTypePointer Private %6 
					                                             %282 = OpTypePointer Uniform %6 
					                                             %294 = OpTypePointer Output %6 
					                                 Output f32* %295 = OpVariable Output 
					                                         u32 %341 = OpConstant 1 
					                                             %342 = OpTypeArray %6 %341 
					                                             %343 = OpTypeStruct %7 %6 %342 
					                                             %344 = OpTypePointer Output %343 
					        Output struct {f32_4; f32; f32[1];}* %345 = OpVariable Output 
					                                          void %4 = OpFunction None %3 
					                                               %5 = OpLabel 
					                                        f32_4 %12 = OpLoad %11 
					                                                      OpStore %9 %12 
					                                        f32_4 %13 = OpLoad %9 
					                                        f32_4 %16 = OpCompositeConstruct %14 %14 %14 %14 
					                                        f32_4 %17 = OpCompositeConstruct %15 %15 %15 %15 
					                                        f32_4 %18 = OpExtInst %1 43 %13 %16 %17 
					                                                      OpStore %9 %18 
					                                        f32_3 %25 = OpLoad %24 
					                                        f32_2 %26 = OpVectorShuffle %25 %25 0 1 
					                               Uniform f32_4* %38 = OpAccessChain %34 %36 
					                                        f32_4 %39 = OpLoad %38 
					                                        f32_2 %40 = OpVectorShuffle %39 %39 0 1 
					                                        f32_2 %41 = OpFMul %26 %40 
					                               Uniform f32_4* %42 = OpAccessChain %34 %36 
					                                        f32_4 %43 = OpLoad %42 
					                                        f32_2 %44 = OpVectorShuffle %43 %43 2 3 
					                                        f32_2 %45 = OpFAdd %41 %44 
					                                                      OpStore %21 %45 
					                               Uniform f32_4* %50 = OpAccessChain %34 %48 %49 
					                                        f32_4 %51 = OpLoad %50 
					                                        f32_3 %52 = OpVectorShuffle %51 %51 1 1 1 
					                               Uniform f32_4* %53 = OpAccessChain %34 %49 %49 
					                                        f32_4 %54 = OpLoad %53 
					                                        f32_3 %55 = OpVectorShuffle %54 %54 0 1 2 
					                                        f32_3 %56 = OpFMul %52 %55 
					                                        f32_4 %57 = OpLoad %47 
					                                        f32_4 %58 = OpVectorShuffle %57 %56 4 5 6 3 
					                                                      OpStore %47 %58 
					                               Uniform f32_4* %59 = OpAccessChain %34 %49 %48 
					                                        f32_4 %60 = OpLoad %59 
					                                        f32_3 %61 = OpVectorShuffle %60 %60 0 1 2 
					                               Uniform f32_4* %62 = OpAccessChain %34 %48 %49 
					                                        f32_4 %63 = OpLoad %62 
					                                        f32_3 %64 = OpVectorShuffle %63 %63 0 0 0 
					                                        f32_3 %65 = OpFMul %61 %64 
					                                        f32_4 %66 = OpLoad %47 
					                                        f32_3 %67 = OpVectorShuffle %66 %66 0 1 2 
					                                        f32_3 %68 = OpFAdd %65 %67 
					                                        f32_4 %69 = OpLoad %47 
					                                        f32_4 %70 = OpVectorShuffle %69 %68 4 5 6 3 
					                                                      OpStore %47 %70 
					                               Uniform f32_4* %72 = OpAccessChain %34 %49 %71 
					                                        f32_4 %73 = OpLoad %72 
					                                        f32_3 %74 = OpVectorShuffle %73 %73 0 1 2 
					                               Uniform f32_4* %75 = OpAccessChain %34 %48 %49 
					                                        f32_4 %76 = OpLoad %75 
					                                        f32_3 %77 = OpVectorShuffle %76 %76 2 2 2 
					                                        f32_3 %78 = OpFMul %74 %77 
					                                        f32_4 %79 = OpLoad %47 
					                                        f32_3 %80 = OpVectorShuffle %79 %79 0 1 2 
					                                        f32_3 %81 = OpFAdd %78 %80 
					                                        f32_4 %82 = OpLoad %47 
					                                        f32_4 %83 = OpVectorShuffle %82 %81 4 5 6 3 
					                                                      OpStore %47 %83 
					                               Uniform f32_4* %85 = OpAccessChain %34 %49 %84 
					                                        f32_4 %86 = OpLoad %85 
					                                        f32_3 %87 = OpVectorShuffle %86 %86 0 1 2 
					                               Uniform f32_4* %88 = OpAccessChain %34 %48 %49 
					                                        f32_4 %89 = OpLoad %88 
					                                        f32_3 %90 = OpVectorShuffle %89 %89 3 3 3 
					                                        f32_3 %91 = OpFMul %87 %90 
					                                        f32_4 %92 = OpLoad %47 
					                                        f32_3 %93 = OpVectorShuffle %92 %92 0 1 2 
					                                        f32_3 %94 = OpFAdd %91 %93 
					                                        f32_4 %95 = OpLoad %47 
					                                        f32_4 %96 = OpVectorShuffle %95 %94 4 5 6 3 
					                                                      OpStore %47 %96 
					                                        f32_4 %97 = OpLoad %47 
					                                        f32_3 %98 = OpVectorShuffle %97 %97 0 1 2 
					                                       f32_3 %100 = OpLoad %99 
					                                       f32_3 %101 = OpVectorShuffle %100 %100 1 1 1 
					                                       f32_3 %102 = OpFMul %98 %101 
					                                       f32_4 %103 = OpLoad %47 
					                                       f32_4 %104 = OpVectorShuffle %103 %102 4 5 6 3 
					                                                      OpStore %47 %104 
					                              Uniform f32_4* %106 = OpAccessChain %34 %48 %48 
					                                       f32_4 %107 = OpLoad %106 
					                                       f32_3 %108 = OpVectorShuffle %107 %107 1 1 1 
					                              Uniform f32_4* %109 = OpAccessChain %34 %49 %49 
					                                       f32_4 %110 = OpLoad %109 
					                                       f32_3 %111 = OpVectorShuffle %110 %110 0 1 2 
					                                       f32_3 %112 = OpFMul %108 %111 
					                                       f32_4 %113 = OpLoad %105 
					                                       f32_4 %114 = OpVectorShuffle %113 %112 4 5 6 3 
					                                                      OpStore %105 %114 
					                              Uniform f32_4* %115 = OpAccessChain %34 %49 %48 
					                                       f32_4 %116 = OpLoad %115 
					                                       f32_3 %117 = OpVectorShuffle %116 %116 0 1 2 
					                              Uniform f32_4* %118 = OpAccessChain %34 %48 %48 
					                                       f32_4 %119 = OpLoad %118 
					                                       f32_3 %120 = OpVectorShuffle %119 %119 0 0 0 
					                                       f32_3 %121 = OpFMul %117 %120 
					                                       f32_4 %122 = OpLoad %105 
					                                       f32_3 %123 = OpVectorShuffle %122 %122 0 1 2 
					                                       f32_3 %124 = OpFAdd %121 %123 
					                                       f32_4 %125 = OpLoad %105 
					                                       f32_4 %126 = OpVectorShuffle %125 %124 4 5 6 3 
					                                                      OpStore %105 %126 
					                              Uniform f32_4* %127 = OpAccessChain %34 %49 %71 
					                                       f32_4 %128 = OpLoad %127 
					                                       f32_3 %129 = OpVectorShuffle %128 %128 0 1 2 
					                              Uniform f32_4* %130 = OpAccessChain %34 %48 %48 
					                                       f32_4 %131 = OpLoad %130 
					                                       f32_3 %132 = OpVectorShuffle %131 %131 2 2 2 
					                                       f32_3 %133 = OpFMul %129 %132 
					                                       f32_4 %134 = OpLoad %105 
					                                       f32_3 %135 = OpVectorShuffle %134 %134 0 1 2 
					                                       f32_3 %136 = OpFAdd %133 %135 
					                                       f32_4 %137 = OpLoad %105 
					                                       f32_4 %138 = OpVectorShuffle %137 %136 4 5 6 3 
					                                                      OpStore %105 %138 
					                              Uniform f32_4* %139 = OpAccessChain %34 %49 %84 
					                                       f32_4 %140 = OpLoad %139 
					                                       f32_3 %141 = OpVectorShuffle %140 %140 0 1 2 
					                              Uniform f32_4* %142 = OpAccessChain %34 %48 %48 
					                                       f32_4 %143 = OpLoad %142 
					                                       f32_3 %144 = OpVectorShuffle %143 %143 3 3 3 
					                                       f32_3 %145 = OpFMul %141 %144 
					                                       f32_4 %146 = OpLoad %105 
					                                       f32_3 %147 = OpVectorShuffle %146 %146 0 1 2 
					                                       f32_3 %148 = OpFAdd %145 %147 
					                                       f32_4 %149 = OpLoad %105 
					                                       f32_4 %150 = OpVectorShuffle %149 %148 4 5 6 3 
					                                                      OpStore %105 %150 
					                                       f32_4 %151 = OpLoad %105 
					                                       f32_3 %152 = OpVectorShuffle %151 %151 0 1 2 
					                                       f32_3 %153 = OpLoad %99 
					                                       f32_3 %154 = OpVectorShuffle %153 %153 0 0 0 
					                                       f32_3 %155 = OpFMul %152 %154 
					                                       f32_4 %156 = OpLoad %47 
					                                       f32_3 %157 = OpVectorShuffle %156 %156 0 1 2 
					                                       f32_3 %158 = OpFAdd %155 %157 
					                                       f32_4 %159 = OpLoad %47 
					                                       f32_4 %160 = OpVectorShuffle %159 %158 4 5 6 3 
					                                                      OpStore %47 %160 
					                              Uniform f32_4* %161 = OpAccessChain %34 %48 %71 
					                                       f32_4 %162 = OpLoad %161 
					                                       f32_3 %163 = OpVectorShuffle %162 %162 1 1 1 
					                              Uniform f32_4* %164 = OpAccessChain %34 %49 %49 
					                                       f32_4 %165 = OpLoad %164 
					                                       f32_3 %166 = OpVectorShuffle %165 %165 0 1 2 
					                                       f32_3 %167 = OpFMul %163 %166 
					                                       f32_4 %168 = OpLoad %105 
					                                       f32_4 %169 = OpVectorShuffle %168 %167 4 5 6 3 
					                                                      OpStore %105 %169 
					                              Uniform f32_4* %170 = OpAccessChain %34 %49 %48 
					                                       f32_4 %171 = OpLoad %170 
					                                       f32_3 %172 = OpVectorShuffle %171 %171 0 1 2 
					                              Uniform f32_4* %173 = OpAccessChain %34 %48 %71 
					                                       f32_4 %174 = OpLoad %173 
					                                       f32_3 %175 = OpVectorShuffle %174 %174 0 0 0 
					                                       f32_3 %176 = OpFMul %172 %175 
					                                       f32_4 %177 = OpLoad %105 
					                                       f32_3 %178 = OpVectorShuffle %177 %177 0 1 2 
					                                       f32_3 %179 = OpFAdd %176 %178 
					                                       f32_4 %180 = OpLoad %105 
					                                       f32_4 %181 = OpVectorShuffle %180 %179 4 5 6 3 
					                                                      OpStore %105 %181 
					                              Uniform f32_4* %182 = OpAccessChain %34 %49 %71 
					                                       f32_4 %183 = OpLoad %182 
					                                       f32_3 %184 = OpVectorShuffle %183 %183 0 1 2 
					                              Uniform f32_4* %185 = OpAccessChain %34 %48 %71 
					                                       f32_4 %186 = OpLoad %185 
					                                       f32_3 %187 = OpVectorShuffle %186 %186 2 2 2 
					                                       f32_3 %188 = OpFMul %184 %187 
					                                       f32_4 %189 = OpLoad %105 
					                                       f32_3 %190 = OpVectorShuffle %189 %189 0 1 2 
					                                       f32_3 %191 = OpFAdd %188 %190 
					                                       f32_4 %192 = OpLoad %105 
					                                       f32_4 %193 = OpVectorShuffle %192 %191 4 5 6 3 
					                                                      OpStore %105 %193 
					                              Uniform f32_4* %194 = OpAccessChain %34 %49 %84 
					                                       f32_4 %195 = OpLoad %194 
					                                       f32_3 %196 = OpVectorShuffle %195 %195 0 1 2 
					                              Uniform f32_4* %197 = OpAccessChain %34 %48 %71 
					                                       f32_4 %198 = OpLoad %197 
					                                       f32_3 %199 = OpVectorShuffle %198 %198 3 3 3 
					                                       f32_3 %200 = OpFMul %196 %199 
					                                       f32_4 %201 = OpLoad %105 
					                                       f32_3 %202 = OpVectorShuffle %201 %201 0 1 2 
					                                       f32_3 %203 = OpFAdd %200 %202 
					                                       f32_4 %204 = OpLoad %105 
					                                       f32_4 %205 = OpVectorShuffle %204 %203 4 5 6 3 
					                                                      OpStore %105 %205 
					                                       f32_4 %206 = OpLoad %105 
					                                       f32_3 %207 = OpVectorShuffle %206 %206 0 1 2 
					                                       f32_3 %208 = OpLoad %99 
					                                       f32_3 %209 = OpVectorShuffle %208 %208 2 2 2 
					                                       f32_3 %210 = OpFMul %207 %209 
					                                       f32_4 %211 = OpLoad %47 
					                                       f32_3 %212 = OpVectorShuffle %211 %211 0 1 2 
					                                       f32_3 %213 = OpFAdd %210 %212 
					                                       f32_4 %214 = OpLoad %47 
					                                       f32_4 %215 = OpVectorShuffle %214 %213 4 5 6 3 
					                                                      OpStore %47 %215 
					                              Uniform f32_4* %216 = OpAccessChain %34 %48 %84 
					                                       f32_4 %217 = OpLoad %216 
					                                       f32_3 %218 = OpVectorShuffle %217 %217 1 1 1 
					                              Uniform f32_4* %219 = OpAccessChain %34 %49 %49 
					                                       f32_4 %220 = OpLoad %219 
					                                       f32_3 %221 = OpVectorShuffle %220 %220 0 1 2 
					                                       f32_3 %222 = OpFMul %218 %221 
					                                       f32_4 %223 = OpLoad %105 
					                                       f32_4 %224 = OpVectorShuffle %223 %222 4 5 6 3 
					                                                      OpStore %105 %224 
					                              Uniform f32_4* %225 = OpAccessChain %34 %49 %48 
					                                       f32_4 %226 = OpLoad %225 
					                                       f32_3 %227 = OpVectorShuffle %226 %226 0 1 2 
					                              Uniform f32_4* %228 = OpAccessChain %34 %48 %84 
					                                       f32_4 %229 = OpLoad %228 
					                                       f32_3 %230 = OpVectorShuffle %229 %229 0 0 0 
					                                       f32_3 %231 = OpFMul %227 %230 
					                                       f32_4 %232 = OpLoad %105 
					                                       f32_3 %233 = OpVectorShuffle %232 %232 0 1 2 
					                                       f32_3 %234 = OpFAdd %231 %233 
					                                       f32_4 %235 = OpLoad %105 
					                                       f32_4 %236 = OpVectorShuffle %235 %234 4 5 6 3 
					                                                      OpStore %105 %236 
					                              Uniform f32_4* %237 = OpAccessChain %34 %49 %71 
					                                       f32_4 %238 = OpLoad %237 
					                                       f32_3 %239 = OpVectorShuffle %238 %238 0 1 2 
					                              Uniform f32_4* %240 = OpAccessChain %34 %48 %84 
					                                       f32_4 %241 = OpLoad %240 
					                                       f32_3 %242 = OpVectorShuffle %241 %241 2 2 2 
					                                       f32_3 %243 = OpFMul %239 %242 
					                                       f32_4 %244 = OpLoad %105 
					                                       f32_3 %245 = OpVectorShuffle %244 %244 0 1 2 
					                                       f32_3 %246 = OpFAdd %243 %245 
					                                       f32_4 %247 = OpLoad %105 
					                                       f32_4 %248 = OpVectorShuffle %247 %246 4 5 6 3 
					                                                      OpStore %105 %248 
					                              Uniform f32_4* %249 = OpAccessChain %34 %49 %84 
					                                       f32_4 %250 = OpLoad %249 
					                                       f32_3 %251 = OpVectorShuffle %250 %250 0 1 2 
					                              Uniform f32_4* %252 = OpAccessChain %34 %48 %84 
					                                       f32_4 %253 = OpLoad %252 
					                                       f32_3 %254 = OpVectorShuffle %253 %253 3 3 3 
					                                       f32_3 %255 = OpFMul %251 %254 
					                                       f32_4 %256 = OpLoad %105 
					                                       f32_3 %257 = OpVectorShuffle %256 %256 0 1 2 
					                                       f32_3 %258 = OpFAdd %255 %257 
					                                       f32_4 %259 = OpLoad %105 
					                                       f32_4 %260 = OpVectorShuffle %259 %258 4 5 6 3 
					                                                      OpStore %105 %260 
					                                       f32_4 %261 = OpLoad %47 
					                                       f32_3 %262 = OpVectorShuffle %261 %261 0 1 2 
					                                       f32_4 %263 = OpLoad %105 
					                                       f32_3 %264 = OpVectorShuffle %263 %263 0 1 2 
					                                       f32_3 %265 = OpFAdd %262 %264 
					                                       f32_4 %266 = OpLoad %47 
					                                       f32_4 %267 = OpVectorShuffle %266 %265 4 5 6 3 
					                                                      OpStore %47 %267 
					                                       f32_4 %268 = OpLoad %47 
					                                       f32_3 %269 = OpVectorShuffle %268 %268 0 1 2 
					                                       f32_4 %270 = OpLoad %47 
					                                       f32_3 %271 = OpVectorShuffle %270 %270 0 1 2 
					                                         f32 %272 = OpDot %269 %271 
					                                Private f32* %275 = OpAccessChain %47 %273 
					                                                      OpStore %275 %272 
					                                Private f32* %276 = OpAccessChain %47 %273 
					                                         f32 %277 = OpLoad %276 
					                                         f32 %278 = OpExtInst %1 31 %277 
					                                Private f32* %279 = OpAccessChain %47 %273 
					                                                      OpStore %279 %278 
					                                Private f32* %280 = OpAccessChain %47 %273 
					                                         f32 %281 = OpLoad %280 
					                                Uniform f32* %283 = OpAccessChain %34 %84 %273 
					                                         f32 %284 = OpLoad %283 
					                                         f32 %285 = OpFMul %281 %284 
					                                Private f32* %286 = OpAccessChain %47 %273 
					                                                      OpStore %286 %285 
					                                Private f32* %287 = OpAccessChain %47 %273 
					                                         f32 %288 = OpLoad %287 
					                                Private f32* %289 = OpAccessChain %47 %273 
					                                         f32 %290 = OpLoad %289 
					                                         f32 %291 = OpFNegate %290 
					                                         f32 %292 = OpFMul %288 %291 
					                                Private f32* %293 = OpAccessChain %47 %273 
					                                                      OpStore %293 %292 
					                                Private f32* %296 = OpAccessChain %47 %273 
					                                         f32 %297 = OpLoad %296 
					                                         f32 %298 = OpExtInst %1 29 %297 
					                                                      OpStore %295 %298 
					                                       f32_3 %299 = OpLoad %99 
					                                       f32_4 %300 = OpVectorShuffle %299 %299 1 1 1 1 
					                              Uniform f32_4* %301 = OpAccessChain %34 %48 %49 
					                                       f32_4 %302 = OpLoad %301 
					                                       f32_4 %303 = OpFMul %300 %302 
					                                                      OpStore %47 %303 
					                              Uniform f32_4* %304 = OpAccessChain %34 %48 %48 
					                                       f32_4 %305 = OpLoad %304 
					                                       f32_3 %306 = OpLoad %99 
					                                       f32_4 %307 = OpVectorShuffle %306 %306 0 0 0 0 
					                                       f32_4 %308 = OpFMul %305 %307 
					                                       f32_4 %309 = OpLoad %47 
					                                       f32_4 %310 = OpFAdd %308 %309 
					                                                      OpStore %47 %310 
					                              Uniform f32_4* %311 = OpAccessChain %34 %48 %71 
					                                       f32_4 %312 = OpLoad %311 
					                                       f32_3 %313 = OpLoad %99 
					                                       f32_4 %314 = OpVectorShuffle %313 %313 2 2 2 2 
					                                       f32_4 %315 = OpFMul %312 %314 
					                                       f32_4 %316 = OpLoad %47 
					                                       f32_4 %317 = OpFAdd %315 %316 
					                                                      OpStore %47 %317 
					                                       f32_4 %318 = OpLoad %47 
					                              Uniform f32_4* %319 = OpAccessChain %34 %48 %84 
					                                       f32_4 %320 = OpLoad %319 
					                                       f32_4 %321 = OpFAdd %318 %320 
					                                                      OpStore %47 %321 
					                                       f32_4 %322 = OpLoad %47 
					                                       f32_4 %323 = OpVectorShuffle %322 %322 1 1 1 1 
					                              Uniform f32_4* %324 = OpAccessChain %34 %71 %49 
					                                       f32_4 %325 = OpLoad %324 
					                                       f32_4 %326 = OpFMul %323 %325 
					                                                      OpStore %105 %326 
					                              Uniform f32_4* %327 = OpAccessChain %34 %71 %48 
					                                       f32_4 %328 = OpLoad %327 
					                                       f32_4 %329 = OpLoad %47 
					                                       f32_4 %330 = OpVectorShuffle %329 %329 0 0 0 0 
					                                       f32_4 %331 = OpFMul %328 %330 
					                                       f32_4 %332 = OpLoad %105 
					                                       f32_4 %333 = OpFAdd %331 %332 
					                                                      OpStore %105 %333 
					                              Uniform f32_4* %334 = OpAccessChain %34 %71 %71 
					                                       f32_4 %335 = OpLoad %334 
					                                       f32_4 %336 = OpLoad %47 
					                                       f32_4 %337 = OpVectorShuffle %336 %336 2 2 2 2 
					                                       f32_4 %338 = OpFMul %335 %337 
					                                       f32_4 %339 = OpLoad %105 
					                                       f32_4 %340 = OpFAdd %338 %339 
					                                                      OpStore %105 %340 
					                              Uniform f32_4* %346 = OpAccessChain %34 %71 %84 
					                                       f32_4 %347 = OpLoad %346 
					                                       f32_4 %348 = OpLoad %47 
					                                       f32_4 %349 = OpVectorShuffle %348 %348 3 3 3 3 
					                                       f32_4 %350 = OpFMul %347 %349 
					                                       f32_4 %351 = OpLoad %105 
					                                       f32_4 %352 = OpFAdd %350 %351 
					                               Output f32_4* %353 = OpAccessChain %345 %48 
					                                                      OpStore %353 %352 
					                                 Output f32* %354 = OpAccessChain %345 %48 %341 
					                                         f32 %355 = OpLoad %354 
					                                         f32 %356 = OpFNegate %355 
					                                 Output f32* %357 = OpAccessChain %345 %48 %341 
					                                                      OpStore %357 %356 
					                                                      OpReturn
					                                                      OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 62
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %16 %24 %27 %50 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %8 RelaxedPrecision 
					                                                    OpDecorate %12 RelaxedPrecision 
					                                                    OpDecorate %12 DescriptorSet 12 
					                                                    OpDecorate %12 Binding 12 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %16 Location 16 
					                                                    OpDecorate %22 RelaxedPrecision 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %24 Location 24 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpDecorate %27 Location 27 
					                                                    OpDecorate %30 RelaxedPrecision 
					                                                    OpDecorate %31 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                                    OpDecorate %37 RelaxedPrecision 
					                                                    OpDecorate %38 RelaxedPrecision 
					                                                    OpMemberDecorate %39 0 RelaxedPrecision 
					                                                    OpMemberDecorate %39 0 Offset 39 
					                                                    OpDecorate %39 Block 
					                                                    OpDecorate %41 DescriptorSet 41 
					                                                    OpDecorate %41 Binding 41 
					                                                    OpDecorate %46 RelaxedPrecision 
					                                                    OpDecorate %47 RelaxedPrecision 
					                                                    OpDecorate %48 RelaxedPrecision 
					                                                    OpDecorate %49 RelaxedPrecision 
					                                                    OpDecorate %50 RelaxedPrecision 
					                                                    OpDecorate %50 Location 50 
					                                                    OpDecorate %51 RelaxedPrecision 
					                                                    OpDecorate %52 RelaxedPrecision 
					                                                    OpDecorate %53 RelaxedPrecision 
					                                                    OpDecorate %54 RelaxedPrecision 
					                                                    OpDecorate %56 RelaxedPrecision 
					                                                    OpDecorate %57 RelaxedPrecision 
					                                                    OpDecorate %58 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypePointer Private %6 
					                                Private f32* %8 = OpVariable Private 
					                                             %9 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %10 = OpTypeSampledImage %9 
					                                            %11 = OpTypePointer UniformConstant %10 
					UniformConstant read_only Texture2DSampled* %12 = OpVariable UniformConstant 
					                                            %14 = OpTypeVector %6 2 
					                                            %15 = OpTypePointer Input %14 
					                               Input f32_2* %16 = OpVariable Input 
					                                            %18 = OpTypeVector %6 4 
					                                            %20 = OpTypeInt 32 0 
					                                        u32 %21 = OpConstant 3 
					                                            %23 = OpTypePointer Output %18 
					                              Output f32_4* %24 = OpVariable Output 
					                                            %26 = OpTypePointer Input %18 
					                               Input f32_4* %27 = OpVariable Input 
					                                            %28 = OpTypePointer Input %6 
					                                            %32 = OpTypePointer Output %6 
					                                            %34 = OpTypeVector %6 3 
					                                            %35 = OpTypePointer Private %34 
					                             Private f32_3* %36 = OpVariable Private 
					                                            %39 = OpTypeStruct %18 
					                                            %40 = OpTypePointer Uniform %39 
					                   Uniform struct {f32_4;}* %41 = OpVariable Uniform 
					                                            %42 = OpTypeInt 32 1 
					                                        i32 %43 = OpConstant 0 
					                                            %44 = OpTypePointer Uniform %18 
					                                 Input f32* %50 = OpVariable Input 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %13 = OpLoad %12 
					                                      f32_2 %17 = OpLoad %16 
					                                      f32_4 %19 = OpImageSampleImplicitLod %13 %17 
					                                        f32 %22 = OpCompositeExtract %19 3 
					                                                    OpStore %8 %22 
					                                        f32 %25 = OpLoad %8 
					                                 Input f32* %29 = OpAccessChain %27 %21 
					                                        f32 %30 = OpLoad %29 
					                                        f32 %31 = OpFMul %25 %30 
					                                Output f32* %33 = OpAccessChain %24 %21 
					                                                    OpStore %33 %31 
					                                      f32_4 %37 = OpLoad %27 
					                                      f32_3 %38 = OpVectorShuffle %37 %37 0 1 2 
					                             Uniform f32_4* %45 = OpAccessChain %41 %43 
					                                      f32_4 %46 = OpLoad %45 
					                                      f32_3 %47 = OpVectorShuffle %46 %46 0 1 2 
					                                      f32_3 %48 = OpFNegate %47 
					                                      f32_3 %49 = OpFAdd %38 %48 
					                                                    OpStore %36 %49 
					                                        f32 %51 = OpLoad %50 
					                                      f32_3 %52 = OpCompositeConstruct %51 %51 %51 
					                                      f32_3 %53 = OpLoad %36 
					                                      f32_3 %54 = OpFMul %52 %53 
					                             Uniform f32_4* %55 = OpAccessChain %41 %43 
					                                      f32_4 %56 = OpLoad %55 
					                                      f32_3 %57 = OpVectorShuffle %56 %56 0 1 2 
					                                      f32_3 %58 = OpFAdd %54 %57 
					                                      f32_4 %59 = OpLoad %24 
					                                      f32_4 %60 = OpVectorShuffle %59 %58 4 5 6 3 
					                                                    OpStore %24 %60 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 359
					; Schema: 0
					                                                      OpCapability Shader 
					                                               %1 = OpExtInstImport "GLSL.std.450" 
					                                                      OpMemoryModel Logical GLSL450 
					                                                      OpEntryPoint Vertex %4 "main" %9 %11 %21 %24 %99 %295 %345 
					                                                      OpDecorate %9 RelaxedPrecision 
					                                                      OpDecorate %9 Location 9 
					                                                      OpDecorate %11 RelaxedPrecision 
					                                                      OpDecorate %11 Location 11 
					                                                      OpDecorate %12 RelaxedPrecision 
					                                                      OpDecorate %13 RelaxedPrecision 
					                                                      OpDecorate %16 RelaxedPrecision 
					                                                      OpDecorate %17 RelaxedPrecision 
					                                                      OpDecorate %18 RelaxedPrecision 
					                                                      OpDecorate %21 Location 21 
					                                                      OpDecorate %24 Location 24 
					                                                      OpDecorate %29 ArrayStride 29 
					                                                      OpDecorate %30 ArrayStride 30 
					                                                      OpDecorate %31 ArrayStride 31 
					                                                      OpMemberDecorate %32 0 Offset 32 
					                                                      OpMemberDecorate %32 1 Offset 32 
					                                                      OpMemberDecorate %32 2 Offset 32 
					                                                      OpMemberDecorate %32 3 Offset 32 
					                                                      OpMemberDecorate %32 4 Offset 32 
					                                                      OpDecorate %32 Block 
					                                                      OpDecorate %34 DescriptorSet 34 
					                                                      OpDecorate %34 Binding 34 
					                                                      OpDecorate %99 Location 99 
					                                                      OpDecorate %295 RelaxedPrecision 
					                                                      OpDecorate %295 Location 295 
					                                                      OpMemberDecorate %343 0 BuiltIn 343 
					                                                      OpMemberDecorate %343 1 BuiltIn 343 
					                                                      OpMemberDecorate %343 2 BuiltIn 343 
					                                                      OpDecorate %343 Block 
					                                               %2 = OpTypeVoid 
					                                               %3 = OpTypeFunction %2 
					                                               %6 = OpTypeFloat 32 
					                                               %7 = OpTypeVector %6 4 
					                                               %8 = OpTypePointer Output %7 
					                                 Output f32_4* %9 = OpVariable Output 
					                                              %10 = OpTypePointer Input %7 
					                                 Input f32_4* %11 = OpVariable Input 
					                                          f32 %14 = OpConstant 3.674022E-40 
					                                          f32 %15 = OpConstant 3.674022E-40 
					                                              %19 = OpTypeVector %6 2 
					                                              %20 = OpTypePointer Output %19 
					                                Output f32_2* %21 = OpVariable Output 
					                                              %22 = OpTypeVector %6 3 
					                                              %23 = OpTypePointer Input %22 
					                                 Input f32_3* %24 = OpVariable Input 
					                                              %27 = OpTypeInt 32 0 
					                                          u32 %28 = OpConstant 4 
					                                              %29 = OpTypeArray %7 %28 
					                                              %30 = OpTypeArray %7 %28 
					                                              %31 = OpTypeArray %7 %28 
					                                              %32 = OpTypeStruct %29 %30 %31 %7 %7 
					                                              %33 = OpTypePointer Uniform %32 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4[4]; f32_4; f32_4;}* %34 = OpVariable Uniform 
					                                              %35 = OpTypeInt 32 1 
					                                          i32 %36 = OpConstant 4 
					                                              %37 = OpTypePointer Uniform %7 
					                                              %46 = OpTypePointer Private %7 
					                               Private f32_4* %47 = OpVariable Private 
					                                          i32 %48 = OpConstant 0 
					                                          i32 %49 = OpConstant 1 
					                                          i32 %71 = OpConstant 2 
					                                          i32 %84 = OpConstant 3 
					                                 Input f32_3* %99 = OpVariable Input 
					                              Private f32_4* %105 = OpVariable Private 
					                                         u32 %273 = OpConstant 0 
					                                             %274 = OpTypePointer Private %6 
					                                             %282 = OpTypePointer Uniform %6 
					                                             %294 = OpTypePointer Output %6 
					                                 Output f32* %295 = OpVariable Output 
					                                         u32 %341 = OpConstant 1 
					                                             %342 = OpTypeArray %6 %341 
					                                             %343 = OpTypeStruct %7 %6 %342 
					                                             %344 = OpTypePointer Output %343 
					        Output struct {f32_4; f32; f32[1];}* %345 = OpVariable Output 
					                                          void %4 = OpFunction None %3 
					                                               %5 = OpLabel 
					                                        f32_4 %12 = OpLoad %11 
					                                                      OpStore %9 %12 
					                                        f32_4 %13 = OpLoad %9 
					                                        f32_4 %16 = OpCompositeConstruct %14 %14 %14 %14 
					                                        f32_4 %17 = OpCompositeConstruct %15 %15 %15 %15 
					                                        f32_4 %18 = OpExtInst %1 43 %13 %16 %17 
					                                                      OpStore %9 %18 
					                                        f32_3 %25 = OpLoad %24 
					                                        f32_2 %26 = OpVectorShuffle %25 %25 0 1 
					                               Uniform f32_4* %38 = OpAccessChain %34 %36 
					                                        f32_4 %39 = OpLoad %38 
					                                        f32_2 %40 = OpVectorShuffle %39 %39 0 1 
					                                        f32_2 %41 = OpFMul %26 %40 
					                               Uniform f32_4* %42 = OpAccessChain %34 %36 
					                                        f32_4 %43 = OpLoad %42 
					                                        f32_2 %44 = OpVectorShuffle %43 %43 2 3 
					                                        f32_2 %45 = OpFAdd %41 %44 
					                                                      OpStore %21 %45 
					                               Uniform f32_4* %50 = OpAccessChain %34 %48 %49 
					                                        f32_4 %51 = OpLoad %50 
					                                        f32_3 %52 = OpVectorShuffle %51 %51 1 1 1 
					                               Uniform f32_4* %53 = OpAccessChain %34 %49 %49 
					                                        f32_4 %54 = OpLoad %53 
					                                        f32_3 %55 = OpVectorShuffle %54 %54 0 1 2 
					                                        f32_3 %56 = OpFMul %52 %55 
					                                        f32_4 %57 = OpLoad %47 
					                                        f32_4 %58 = OpVectorShuffle %57 %56 4 5 6 3 
					                                                      OpStore %47 %58 
					                               Uniform f32_4* %59 = OpAccessChain %34 %49 %48 
					                                        f32_4 %60 = OpLoad %59 
					                                        f32_3 %61 = OpVectorShuffle %60 %60 0 1 2 
					                               Uniform f32_4* %62 = OpAccessChain %34 %48 %49 
					                                        f32_4 %63 = OpLoad %62 
					                                        f32_3 %64 = OpVectorShuffle %63 %63 0 0 0 
					                                        f32_3 %65 = OpFMul %61 %64 
					                                        f32_4 %66 = OpLoad %47 
					                                        f32_3 %67 = OpVectorShuffle %66 %66 0 1 2 
					                                        f32_3 %68 = OpFAdd %65 %67 
					                                        f32_4 %69 = OpLoad %47 
					                                        f32_4 %70 = OpVectorShuffle %69 %68 4 5 6 3 
					                                                      OpStore %47 %70 
					                               Uniform f32_4* %72 = OpAccessChain %34 %49 %71 
					                                        f32_4 %73 = OpLoad %72 
					                                        f32_3 %74 = OpVectorShuffle %73 %73 0 1 2 
					                               Uniform f32_4* %75 = OpAccessChain %34 %48 %49 
					                                        f32_4 %76 = OpLoad %75 
					                                        f32_3 %77 = OpVectorShuffle %76 %76 2 2 2 
					                                        f32_3 %78 = OpFMul %74 %77 
					                                        f32_4 %79 = OpLoad %47 
					                                        f32_3 %80 = OpVectorShuffle %79 %79 0 1 2 
					                                        f32_3 %81 = OpFAdd %78 %80 
					                                        f32_4 %82 = OpLoad %47 
					                                        f32_4 %83 = OpVectorShuffle %82 %81 4 5 6 3 
					                                                      OpStore %47 %83 
					                               Uniform f32_4* %85 = OpAccessChain %34 %49 %84 
					                                        f32_4 %86 = OpLoad %85 
					                                        f32_3 %87 = OpVectorShuffle %86 %86 0 1 2 
					                               Uniform f32_4* %88 = OpAccessChain %34 %48 %49 
					                                        f32_4 %89 = OpLoad %88 
					                                        f32_3 %90 = OpVectorShuffle %89 %89 3 3 3 
					                                        f32_3 %91 = OpFMul %87 %90 
					                                        f32_4 %92 = OpLoad %47 
					                                        f32_3 %93 = OpVectorShuffle %92 %92 0 1 2 
					                                        f32_3 %94 = OpFAdd %91 %93 
					                                        f32_4 %95 = OpLoad %47 
					                                        f32_4 %96 = OpVectorShuffle %95 %94 4 5 6 3 
					                                                      OpStore %47 %96 
					                                        f32_4 %97 = OpLoad %47 
					                                        f32_3 %98 = OpVectorShuffle %97 %97 0 1 2 
					                                       f32_3 %100 = OpLoad %99 
					                                       f32_3 %101 = OpVectorShuffle %100 %100 1 1 1 
					                                       f32_3 %102 = OpFMul %98 %101 
					                                       f32_4 %103 = OpLoad %47 
					                                       f32_4 %104 = OpVectorShuffle %103 %102 4 5 6 3 
					                                                      OpStore %47 %104 
					                              Uniform f32_4* %106 = OpAccessChain %34 %48 %48 
					                                       f32_4 %107 = OpLoad %106 
					                                       f32_3 %108 = OpVectorShuffle %107 %107 1 1 1 
					                              Uniform f32_4* %109 = OpAccessChain %34 %49 %49 
					                                       f32_4 %110 = OpLoad %109 
					                                       f32_3 %111 = OpVectorShuffle %110 %110 0 1 2 
					                                       f32_3 %112 = OpFMul %108 %111 
					                                       f32_4 %113 = OpLoad %105 
					                                       f32_4 %114 = OpVectorShuffle %113 %112 4 5 6 3 
					                                                      OpStore %105 %114 
					                              Uniform f32_4* %115 = OpAccessChain %34 %49 %48 
					                                       f32_4 %116 = OpLoad %115 
					                                       f32_3 %117 = OpVectorShuffle %116 %116 0 1 2 
					                              Uniform f32_4* %118 = OpAccessChain %34 %48 %48 
					                                       f32_4 %119 = OpLoad %118 
					                                       f32_3 %120 = OpVectorShuffle %119 %119 0 0 0 
					                                       f32_3 %121 = OpFMul %117 %120 
					                                       f32_4 %122 = OpLoad %105 
					                                       f32_3 %123 = OpVectorShuffle %122 %122 0 1 2 
					                                       f32_3 %124 = OpFAdd %121 %123 
					                                       f32_4 %125 = OpLoad %105 
					                                       f32_4 %126 = OpVectorShuffle %125 %124 4 5 6 3 
					                                                      OpStore %105 %126 
					                              Uniform f32_4* %127 = OpAccessChain %34 %49 %71 
					                                       f32_4 %128 = OpLoad %127 
					                                       f32_3 %129 = OpVectorShuffle %128 %128 0 1 2 
					                              Uniform f32_4* %130 = OpAccessChain %34 %48 %48 
					                                       f32_4 %131 = OpLoad %130 
					                                       f32_3 %132 = OpVectorShuffle %131 %131 2 2 2 
					                                       f32_3 %133 = OpFMul %129 %132 
					                                       f32_4 %134 = OpLoad %105 
					                                       f32_3 %135 = OpVectorShuffle %134 %134 0 1 2 
					                                       f32_3 %136 = OpFAdd %133 %135 
					                                       f32_4 %137 = OpLoad %105 
					                                       f32_4 %138 = OpVectorShuffle %137 %136 4 5 6 3 
					                                                      OpStore %105 %138 
					                              Uniform f32_4* %139 = OpAccessChain %34 %49 %84 
					                                       f32_4 %140 = OpLoad %139 
					                                       f32_3 %141 = OpVectorShuffle %140 %140 0 1 2 
					                              Uniform f32_4* %142 = OpAccessChain %34 %48 %48 
					                                       f32_4 %143 = OpLoad %142 
					                                       f32_3 %144 = OpVectorShuffle %143 %143 3 3 3 
					                                       f32_3 %145 = OpFMul %141 %144 
					                                       f32_4 %146 = OpLoad %105 
					                                       f32_3 %147 = OpVectorShuffle %146 %146 0 1 2 
					                                       f32_3 %148 = OpFAdd %145 %147 
					                                       f32_4 %149 = OpLoad %105 
					                                       f32_4 %150 = OpVectorShuffle %149 %148 4 5 6 3 
					                                                      OpStore %105 %150 
					                                       f32_4 %151 = OpLoad %105 
					                                       f32_3 %152 = OpVectorShuffle %151 %151 0 1 2 
					                                       f32_3 %153 = OpLoad %99 
					                                       f32_3 %154 = OpVectorShuffle %153 %153 0 0 0 
					                                       f32_3 %155 = OpFMul %152 %154 
					                                       f32_4 %156 = OpLoad %47 
					                                       f32_3 %157 = OpVectorShuffle %156 %156 0 1 2 
					                                       f32_3 %158 = OpFAdd %155 %157 
					                                       f32_4 %159 = OpLoad %47 
					                                       f32_4 %160 = OpVectorShuffle %159 %158 4 5 6 3 
					                                                      OpStore %47 %160 
					                              Uniform f32_4* %161 = OpAccessChain %34 %48 %71 
					                                       f32_4 %162 = OpLoad %161 
					                                       f32_3 %163 = OpVectorShuffle %162 %162 1 1 1 
					                              Uniform f32_4* %164 = OpAccessChain %34 %49 %49 
					                                       f32_4 %165 = OpLoad %164 
					                                       f32_3 %166 = OpVectorShuffle %165 %165 0 1 2 
					                                       f32_3 %167 = OpFMul %163 %166 
					                                       f32_4 %168 = OpLoad %105 
					                                       f32_4 %169 = OpVectorShuffle %168 %167 4 5 6 3 
					                                                      OpStore %105 %169 
					                              Uniform f32_4* %170 = OpAccessChain %34 %49 %48 
					                                       f32_4 %171 = OpLoad %170 
					                                       f32_3 %172 = OpVectorShuffle %171 %171 0 1 2 
					                              Uniform f32_4* %173 = OpAccessChain %34 %48 %71 
					                                       f32_4 %174 = OpLoad %173 
					                                       f32_3 %175 = OpVectorShuffle %174 %174 0 0 0 
					                                       f32_3 %176 = OpFMul %172 %175 
					                                       f32_4 %177 = OpLoad %105 
					                                       f32_3 %178 = OpVectorShuffle %177 %177 0 1 2 
					                                       f32_3 %179 = OpFAdd %176 %178 
					                                       f32_4 %180 = OpLoad %105 
					                                       f32_4 %181 = OpVectorShuffle %180 %179 4 5 6 3 
					                                                      OpStore %105 %181 
					                              Uniform f32_4* %182 = OpAccessChain %34 %49 %71 
					                                       f32_4 %183 = OpLoad %182 
					                                       f32_3 %184 = OpVectorShuffle %183 %183 0 1 2 
					                              Uniform f32_4* %185 = OpAccessChain %34 %48 %71 
					                                       f32_4 %186 = OpLoad %185 
					                                       f32_3 %187 = OpVectorShuffle %186 %186 2 2 2 
					                                       f32_3 %188 = OpFMul %184 %187 
					                                       f32_4 %189 = OpLoad %105 
					                                       f32_3 %190 = OpVectorShuffle %189 %189 0 1 2 
					                                       f32_3 %191 = OpFAdd %188 %190 
					                                       f32_4 %192 = OpLoad %105 
					                                       f32_4 %193 = OpVectorShuffle %192 %191 4 5 6 3 
					                                                      OpStore %105 %193 
					                              Uniform f32_4* %194 = OpAccessChain %34 %49 %84 
					                                       f32_4 %195 = OpLoad %194 
					                                       f32_3 %196 = OpVectorShuffle %195 %195 0 1 2 
					                              Uniform f32_4* %197 = OpAccessChain %34 %48 %71 
					                                       f32_4 %198 = OpLoad %197 
					                                       f32_3 %199 = OpVectorShuffle %198 %198 3 3 3 
					                                       f32_3 %200 = OpFMul %196 %199 
					                                       f32_4 %201 = OpLoad %105 
					                                       f32_3 %202 = OpVectorShuffle %201 %201 0 1 2 
					                                       f32_3 %203 = OpFAdd %200 %202 
					                                       f32_4 %204 = OpLoad %105 
					                                       f32_4 %205 = OpVectorShuffle %204 %203 4 5 6 3 
					                                                      OpStore %105 %205 
					                                       f32_4 %206 = OpLoad %105 
					                                       f32_3 %207 = OpVectorShuffle %206 %206 0 1 2 
					                                       f32_3 %208 = OpLoad %99 
					                                       f32_3 %209 = OpVectorShuffle %208 %208 2 2 2 
					                                       f32_3 %210 = OpFMul %207 %209 
					                                       f32_4 %211 = OpLoad %47 
					                                       f32_3 %212 = OpVectorShuffle %211 %211 0 1 2 
					                                       f32_3 %213 = OpFAdd %210 %212 
					                                       f32_4 %214 = OpLoad %47 
					                                       f32_4 %215 = OpVectorShuffle %214 %213 4 5 6 3 
					                                                      OpStore %47 %215 
					                              Uniform f32_4* %216 = OpAccessChain %34 %48 %84 
					                                       f32_4 %217 = OpLoad %216 
					                                       f32_3 %218 = OpVectorShuffle %217 %217 1 1 1 
					                              Uniform f32_4* %219 = OpAccessChain %34 %49 %49 
					                                       f32_4 %220 = OpLoad %219 
					                                       f32_3 %221 = OpVectorShuffle %220 %220 0 1 2 
					                                       f32_3 %222 = OpFMul %218 %221 
					                                       f32_4 %223 = OpLoad %105 
					                                       f32_4 %224 = OpVectorShuffle %223 %222 4 5 6 3 
					                                                      OpStore %105 %224 
					                              Uniform f32_4* %225 = OpAccessChain %34 %49 %48 
					                                       f32_4 %226 = OpLoad %225 
					                                       f32_3 %227 = OpVectorShuffle %226 %226 0 1 2 
					                              Uniform f32_4* %228 = OpAccessChain %34 %48 %84 
					                                       f32_4 %229 = OpLoad %228 
					                                       f32_3 %230 = OpVectorShuffle %229 %229 0 0 0 
					                                       f32_3 %231 = OpFMul %227 %230 
					                                       f32_4 %232 = OpLoad %105 
					                                       f32_3 %233 = OpVectorShuffle %232 %232 0 1 2 
					                                       f32_3 %234 = OpFAdd %231 %233 
					                                       f32_4 %235 = OpLoad %105 
					                                       f32_4 %236 = OpVectorShuffle %235 %234 4 5 6 3 
					                                                      OpStore %105 %236 
					                              Uniform f32_4* %237 = OpAccessChain %34 %49 %71 
					                                       f32_4 %238 = OpLoad %237 
					                                       f32_3 %239 = OpVectorShuffle %238 %238 0 1 2 
					                              Uniform f32_4* %240 = OpAccessChain %34 %48 %84 
					                                       f32_4 %241 = OpLoad %240 
					                                       f32_3 %242 = OpVectorShuffle %241 %241 2 2 2 
					                                       f32_3 %243 = OpFMul %239 %242 
					                                       f32_4 %244 = OpLoad %105 
					                                       f32_3 %245 = OpVectorShuffle %244 %244 0 1 2 
					                                       f32_3 %246 = OpFAdd %243 %245 
					                                       f32_4 %247 = OpLoad %105 
					                                       f32_4 %248 = OpVectorShuffle %247 %246 4 5 6 3 
					                                                      OpStore %105 %248 
					                              Uniform f32_4* %249 = OpAccessChain %34 %49 %84 
					                                       f32_4 %250 = OpLoad %249 
					                                       f32_3 %251 = OpVectorShuffle %250 %250 0 1 2 
					                              Uniform f32_4* %252 = OpAccessChain %34 %48 %84 
					                                       f32_4 %253 = OpLoad %252 
					                                       f32_3 %254 = OpVectorShuffle %253 %253 3 3 3 
					                                       f32_3 %255 = OpFMul %251 %254 
					                                       f32_4 %256 = OpLoad %105 
					                                       f32_3 %257 = OpVectorShuffle %256 %256 0 1 2 
					                                       f32_3 %258 = OpFAdd %255 %257 
					                                       f32_4 %259 = OpLoad %105 
					                                       f32_4 %260 = OpVectorShuffle %259 %258 4 5 6 3 
					                                                      OpStore %105 %260 
					                                       f32_4 %261 = OpLoad %47 
					                                       f32_3 %262 = OpVectorShuffle %261 %261 0 1 2 
					                                       f32_4 %263 = OpLoad %105 
					                                       f32_3 %264 = OpVectorShuffle %263 %263 0 1 2 
					                                       f32_3 %265 = OpFAdd %262 %264 
					                                       f32_4 %266 = OpLoad %47 
					                                       f32_4 %267 = OpVectorShuffle %266 %265 4 5 6 3 
					                                                      OpStore %47 %267 
					                                       f32_4 %268 = OpLoad %47 
					                                       f32_3 %269 = OpVectorShuffle %268 %268 0 1 2 
					                                       f32_4 %270 = OpLoad %47 
					                                       f32_3 %271 = OpVectorShuffle %270 %270 0 1 2 
					                                         f32 %272 = OpDot %269 %271 
					                                Private f32* %275 = OpAccessChain %47 %273 
					                                                      OpStore %275 %272 
					                                Private f32* %276 = OpAccessChain %47 %273 
					                                         f32 %277 = OpLoad %276 
					                                         f32 %278 = OpExtInst %1 31 %277 
					                                Private f32* %279 = OpAccessChain %47 %273 
					                                                      OpStore %279 %278 
					                                Private f32* %280 = OpAccessChain %47 %273 
					                                         f32 %281 = OpLoad %280 
					                                Uniform f32* %283 = OpAccessChain %34 %84 %273 
					                                         f32 %284 = OpLoad %283 
					                                         f32 %285 = OpFMul %281 %284 
					                                Private f32* %286 = OpAccessChain %47 %273 
					                                                      OpStore %286 %285 
					                                Private f32* %287 = OpAccessChain %47 %273 
					                                         f32 %288 = OpLoad %287 
					                                Private f32* %289 = OpAccessChain %47 %273 
					                                         f32 %290 = OpLoad %289 
					                                         f32 %291 = OpFNegate %290 
					                                         f32 %292 = OpFMul %288 %291 
					                                Private f32* %293 = OpAccessChain %47 %273 
					                                                      OpStore %293 %292 
					                                Private f32* %296 = OpAccessChain %47 %273 
					                                         f32 %297 = OpLoad %296 
					                                         f32 %298 = OpExtInst %1 29 %297 
					                                                      OpStore %295 %298 
					                                       f32_3 %299 = OpLoad %99 
					                                       f32_4 %300 = OpVectorShuffle %299 %299 1 1 1 1 
					                              Uniform f32_4* %301 = OpAccessChain %34 %48 %49 
					                                       f32_4 %302 = OpLoad %301 
					                                       f32_4 %303 = OpFMul %300 %302 
					                                                      OpStore %47 %303 
					                              Uniform f32_4* %304 = OpAccessChain %34 %48 %48 
					                                       f32_4 %305 = OpLoad %304 
					                                       f32_3 %306 = OpLoad %99 
					                                       f32_4 %307 = OpVectorShuffle %306 %306 0 0 0 0 
					                                       f32_4 %308 = OpFMul %305 %307 
					                                       f32_4 %309 = OpLoad %47 
					                                       f32_4 %310 = OpFAdd %308 %309 
					                                                      OpStore %47 %310 
					                              Uniform f32_4* %311 = OpAccessChain %34 %48 %71 
					                                       f32_4 %312 = OpLoad %311 
					                                       f32_3 %313 = OpLoad %99 
					                                       f32_4 %314 = OpVectorShuffle %313 %313 2 2 2 2 
					                                       f32_4 %315 = OpFMul %312 %314 
					                                       f32_4 %316 = OpLoad %47 
					                                       f32_4 %317 = OpFAdd %315 %316 
					                                                      OpStore %47 %317 
					                                       f32_4 %318 = OpLoad %47 
					                              Uniform f32_4* %319 = OpAccessChain %34 %48 %84 
					                                       f32_4 %320 = OpLoad %319 
					                                       f32_4 %321 = OpFAdd %318 %320 
					                                                      OpStore %47 %321 
					                                       f32_4 %322 = OpLoad %47 
					                                       f32_4 %323 = OpVectorShuffle %322 %322 1 1 1 1 
					                              Uniform f32_4* %324 = OpAccessChain %34 %71 %49 
					                                       f32_4 %325 = OpLoad %324 
					                                       f32_4 %326 = OpFMul %323 %325 
					                                                      OpStore %105 %326 
					                              Uniform f32_4* %327 = OpAccessChain %34 %71 %48 
					                                       f32_4 %328 = OpLoad %327 
					                                       f32_4 %329 = OpLoad %47 
					                                       f32_4 %330 = OpVectorShuffle %329 %329 0 0 0 0 
					                                       f32_4 %331 = OpFMul %328 %330 
					                                       f32_4 %332 = OpLoad %105 
					                                       f32_4 %333 = OpFAdd %331 %332 
					                                                      OpStore %105 %333 
					                              Uniform f32_4* %334 = OpAccessChain %34 %71 %71 
					                                       f32_4 %335 = OpLoad %334 
					                                       f32_4 %336 = OpLoad %47 
					                                       f32_4 %337 = OpVectorShuffle %336 %336 2 2 2 2 
					                                       f32_4 %338 = OpFMul %335 %337 
					                                       f32_4 %339 = OpLoad %105 
					                                       f32_4 %340 = OpFAdd %338 %339 
					                                                      OpStore %105 %340 
					                              Uniform f32_4* %346 = OpAccessChain %34 %71 %84 
					                                       f32_4 %347 = OpLoad %346 
					                                       f32_4 %348 = OpLoad %47 
					                                       f32_4 %349 = OpVectorShuffle %348 %348 3 3 3 3 
					                                       f32_4 %350 = OpFMul %347 %349 
					                                       f32_4 %351 = OpLoad %105 
					                                       f32_4 %352 = OpFAdd %350 %351 
					                               Output f32_4* %353 = OpAccessChain %345 %48 
					                                                      OpStore %353 %352 
					                                 Output f32* %354 = OpAccessChain %345 %48 %341 
					                                         f32 %355 = OpLoad %354 
					                                         f32 %356 = OpFNegate %355 
					                                 Output f32* %357 = OpAccessChain %345 %48 %341 
					                                                      OpStore %357 %356 
					                                                      OpReturn
					                                                      OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 62
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %16 %24 %27 %50 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %8 RelaxedPrecision 
					                                                    OpDecorate %12 RelaxedPrecision 
					                                                    OpDecorate %12 DescriptorSet 12 
					                                                    OpDecorate %12 Binding 12 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %16 Location 16 
					                                                    OpDecorate %22 RelaxedPrecision 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %24 Location 24 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpDecorate %27 Location 27 
					                                                    OpDecorate %30 RelaxedPrecision 
					                                                    OpDecorate %31 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                                    OpDecorate %37 RelaxedPrecision 
					                                                    OpDecorate %38 RelaxedPrecision 
					                                                    OpMemberDecorate %39 0 RelaxedPrecision 
					                                                    OpMemberDecorate %39 0 Offset 39 
					                                                    OpDecorate %39 Block 
					                                                    OpDecorate %41 DescriptorSet 41 
					                                                    OpDecorate %41 Binding 41 
					                                                    OpDecorate %46 RelaxedPrecision 
					                                                    OpDecorate %47 RelaxedPrecision 
					                                                    OpDecorate %48 RelaxedPrecision 
					                                                    OpDecorate %49 RelaxedPrecision 
					                                                    OpDecorate %50 RelaxedPrecision 
					                                                    OpDecorate %50 Location 50 
					                                                    OpDecorate %51 RelaxedPrecision 
					                                                    OpDecorate %52 RelaxedPrecision 
					                                                    OpDecorate %53 RelaxedPrecision 
					                                                    OpDecorate %54 RelaxedPrecision 
					                                                    OpDecorate %56 RelaxedPrecision 
					                                                    OpDecorate %57 RelaxedPrecision 
					                                                    OpDecorate %58 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypePointer Private %6 
					                                Private f32* %8 = OpVariable Private 
					                                             %9 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %10 = OpTypeSampledImage %9 
					                                            %11 = OpTypePointer UniformConstant %10 
					UniformConstant read_only Texture2DSampled* %12 = OpVariable UniformConstant 
					                                            %14 = OpTypeVector %6 2 
					                                            %15 = OpTypePointer Input %14 
					                               Input f32_2* %16 = OpVariable Input 
					                                            %18 = OpTypeVector %6 4 
					                                            %20 = OpTypeInt 32 0 
					                                        u32 %21 = OpConstant 3 
					                                            %23 = OpTypePointer Output %18 
					                              Output f32_4* %24 = OpVariable Output 
					                                            %26 = OpTypePointer Input %18 
					                               Input f32_4* %27 = OpVariable Input 
					                                            %28 = OpTypePointer Input %6 
					                                            %32 = OpTypePointer Output %6 
					                                            %34 = OpTypeVector %6 3 
					                                            %35 = OpTypePointer Private %34 
					                             Private f32_3* %36 = OpVariable Private 
					                                            %39 = OpTypeStruct %18 
					                                            %40 = OpTypePointer Uniform %39 
					                   Uniform struct {f32_4;}* %41 = OpVariable Uniform 
					                                            %42 = OpTypeInt 32 1 
					                                        i32 %43 = OpConstant 0 
					                                            %44 = OpTypePointer Uniform %18 
					                                 Input f32* %50 = OpVariable Input 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %13 = OpLoad %12 
					                                      f32_2 %17 = OpLoad %16 
					                                      f32_4 %19 = OpImageSampleImplicitLod %13 %17 
					                                        f32 %22 = OpCompositeExtract %19 3 
					                                                    OpStore %8 %22 
					                                        f32 %25 = OpLoad %8 
					                                 Input f32* %29 = OpAccessChain %27 %21 
					                                        f32 %30 = OpLoad %29 
					                                        f32 %31 = OpFMul %25 %30 
					                                Output f32* %33 = OpAccessChain %24 %21 
					                                                    OpStore %33 %31 
					                                      f32_4 %37 = OpLoad %27 
					                                      f32_3 %38 = OpVectorShuffle %37 %37 0 1 2 
					                             Uniform f32_4* %45 = OpAccessChain %41 %43 
					                                      f32_4 %46 = OpLoad %45 
					                                      f32_3 %47 = OpVectorShuffle %46 %46 0 1 2 
					                                      f32_3 %48 = OpFNegate %47 
					                                      f32_3 %49 = OpFAdd %38 %48 
					                                                    OpStore %36 %49 
					                                        f32 %51 = OpLoad %50 
					                                      f32_3 %52 = OpCompositeConstruct %51 %51 %51 
					                                      f32_3 %53 = OpLoad %36 
					                                      f32_3 %54 = OpFMul %52 %53 
					                             Uniform f32_4* %55 = OpAccessChain %41 %43 
					                                      f32_4 %56 = OpLoad %55 
					                                      f32_3 %57 = OpVectorShuffle %56 %56 0 1 2 
					                                      f32_3 %58 = OpFAdd %54 %57 
					                                      f32_4 %59 = OpLoad %24 
					                                      f32_4 %60 = OpVectorShuffle %59 %58 4 5 6 3 
					                                                    OpStore %24 %60 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 359
					; Schema: 0
					                                                      OpCapability Shader 
					                                               %1 = OpExtInstImport "GLSL.std.450" 
					                                                      OpMemoryModel Logical GLSL450 
					                                                      OpEntryPoint Vertex %4 "main" %9 %11 %21 %24 %99 %295 %345 
					                                                      OpDecorate %9 RelaxedPrecision 
					                                                      OpDecorate %9 Location 9 
					                                                      OpDecorate %11 RelaxedPrecision 
					                                                      OpDecorate %11 Location 11 
					                                                      OpDecorate %12 RelaxedPrecision 
					                                                      OpDecorate %13 RelaxedPrecision 
					                                                      OpDecorate %16 RelaxedPrecision 
					                                                      OpDecorate %17 RelaxedPrecision 
					                                                      OpDecorate %18 RelaxedPrecision 
					                                                      OpDecorate %21 Location 21 
					                                                      OpDecorate %24 Location 24 
					                                                      OpDecorate %29 ArrayStride 29 
					                                                      OpDecorate %30 ArrayStride 30 
					                                                      OpDecorate %31 ArrayStride 31 
					                                                      OpMemberDecorate %32 0 Offset 32 
					                                                      OpMemberDecorate %32 1 Offset 32 
					                                                      OpMemberDecorate %32 2 Offset 32 
					                                                      OpMemberDecorate %32 3 Offset 32 
					                                                      OpMemberDecorate %32 4 Offset 32 
					                                                      OpDecorate %32 Block 
					                                                      OpDecorate %34 DescriptorSet 34 
					                                                      OpDecorate %34 Binding 34 
					                                                      OpDecorate %99 Location 99 
					                                                      OpDecorate %295 RelaxedPrecision 
					                                                      OpDecorate %295 Location 295 
					                                                      OpMemberDecorate %343 0 BuiltIn 343 
					                                                      OpMemberDecorate %343 1 BuiltIn 343 
					                                                      OpMemberDecorate %343 2 BuiltIn 343 
					                                                      OpDecorate %343 Block 
					                                               %2 = OpTypeVoid 
					                                               %3 = OpTypeFunction %2 
					                                               %6 = OpTypeFloat 32 
					                                               %7 = OpTypeVector %6 4 
					                                               %8 = OpTypePointer Output %7 
					                                 Output f32_4* %9 = OpVariable Output 
					                                              %10 = OpTypePointer Input %7 
					                                 Input f32_4* %11 = OpVariable Input 
					                                          f32 %14 = OpConstant 3.674022E-40 
					                                          f32 %15 = OpConstant 3.674022E-40 
					                                              %19 = OpTypeVector %6 2 
					                                              %20 = OpTypePointer Output %19 
					                                Output f32_2* %21 = OpVariable Output 
					                                              %22 = OpTypeVector %6 3 
					                                              %23 = OpTypePointer Input %22 
					                                 Input f32_3* %24 = OpVariable Input 
					                                              %27 = OpTypeInt 32 0 
					                                          u32 %28 = OpConstant 4 
					                                              %29 = OpTypeArray %7 %28 
					                                              %30 = OpTypeArray %7 %28 
					                                              %31 = OpTypeArray %7 %28 
					                                              %32 = OpTypeStruct %29 %30 %31 %7 %7 
					                                              %33 = OpTypePointer Uniform %32 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4[4]; f32_4; f32_4;}* %34 = OpVariable Uniform 
					                                              %35 = OpTypeInt 32 1 
					                                          i32 %36 = OpConstant 4 
					                                              %37 = OpTypePointer Uniform %7 
					                                              %46 = OpTypePointer Private %7 
					                               Private f32_4* %47 = OpVariable Private 
					                                          i32 %48 = OpConstant 0 
					                                          i32 %49 = OpConstant 1 
					                                          i32 %71 = OpConstant 2 
					                                          i32 %84 = OpConstant 3 
					                                 Input f32_3* %99 = OpVariable Input 
					                              Private f32_4* %105 = OpVariable Private 
					                                         u32 %273 = OpConstant 0 
					                                             %274 = OpTypePointer Private %6 
					                                             %282 = OpTypePointer Uniform %6 
					                                             %294 = OpTypePointer Output %6 
					                                 Output f32* %295 = OpVariable Output 
					                                         u32 %341 = OpConstant 1 
					                                             %342 = OpTypeArray %6 %341 
					                                             %343 = OpTypeStruct %7 %6 %342 
					                                             %344 = OpTypePointer Output %343 
					        Output struct {f32_4; f32; f32[1];}* %345 = OpVariable Output 
					                                          void %4 = OpFunction None %3 
					                                               %5 = OpLabel 
					                                        f32_4 %12 = OpLoad %11 
					                                                      OpStore %9 %12 
					                                        f32_4 %13 = OpLoad %9 
					                                        f32_4 %16 = OpCompositeConstruct %14 %14 %14 %14 
					                                        f32_4 %17 = OpCompositeConstruct %15 %15 %15 %15 
					                                        f32_4 %18 = OpExtInst %1 43 %13 %16 %17 
					                                                      OpStore %9 %18 
					                                        f32_3 %25 = OpLoad %24 
					                                        f32_2 %26 = OpVectorShuffle %25 %25 0 1 
					                               Uniform f32_4* %38 = OpAccessChain %34 %36 
					                                        f32_4 %39 = OpLoad %38 
					                                        f32_2 %40 = OpVectorShuffle %39 %39 0 1 
					                                        f32_2 %41 = OpFMul %26 %40 
					                               Uniform f32_4* %42 = OpAccessChain %34 %36 
					                                        f32_4 %43 = OpLoad %42 
					                                        f32_2 %44 = OpVectorShuffle %43 %43 2 3 
					                                        f32_2 %45 = OpFAdd %41 %44 
					                                                      OpStore %21 %45 
					                               Uniform f32_4* %50 = OpAccessChain %34 %48 %49 
					                                        f32_4 %51 = OpLoad %50 
					                                        f32_3 %52 = OpVectorShuffle %51 %51 1 1 1 
					                               Uniform f32_4* %53 = OpAccessChain %34 %49 %49 
					                                        f32_4 %54 = OpLoad %53 
					                                        f32_3 %55 = OpVectorShuffle %54 %54 0 1 2 
					                                        f32_3 %56 = OpFMul %52 %55 
					                                        f32_4 %57 = OpLoad %47 
					                                        f32_4 %58 = OpVectorShuffle %57 %56 4 5 6 3 
					                                                      OpStore %47 %58 
					                               Uniform f32_4* %59 = OpAccessChain %34 %49 %48 
					                                        f32_4 %60 = OpLoad %59 
					                                        f32_3 %61 = OpVectorShuffle %60 %60 0 1 2 
					                               Uniform f32_4* %62 = OpAccessChain %34 %48 %49 
					                                        f32_4 %63 = OpLoad %62 
					                                        f32_3 %64 = OpVectorShuffle %63 %63 0 0 0 
					                                        f32_3 %65 = OpFMul %61 %64 
					                                        f32_4 %66 = OpLoad %47 
					                                        f32_3 %67 = OpVectorShuffle %66 %66 0 1 2 
					                                        f32_3 %68 = OpFAdd %65 %67 
					                                        f32_4 %69 = OpLoad %47 
					                                        f32_4 %70 = OpVectorShuffle %69 %68 4 5 6 3 
					                                                      OpStore %47 %70 
					                               Uniform f32_4* %72 = OpAccessChain %34 %49 %71 
					                                        f32_4 %73 = OpLoad %72 
					                                        f32_3 %74 = OpVectorShuffle %73 %73 0 1 2 
					                               Uniform f32_4* %75 = OpAccessChain %34 %48 %49 
					                                        f32_4 %76 = OpLoad %75 
					                                        f32_3 %77 = OpVectorShuffle %76 %76 2 2 2 
					                                        f32_3 %78 = OpFMul %74 %77 
					                                        f32_4 %79 = OpLoad %47 
					                                        f32_3 %80 = OpVectorShuffle %79 %79 0 1 2 
					                                        f32_3 %81 = OpFAdd %78 %80 
					                                        f32_4 %82 = OpLoad %47 
					                                        f32_4 %83 = OpVectorShuffle %82 %81 4 5 6 3 
					                                                      OpStore %47 %83 
					                               Uniform f32_4* %85 = OpAccessChain %34 %49 %84 
					                                        f32_4 %86 = OpLoad %85 
					                                        f32_3 %87 = OpVectorShuffle %86 %86 0 1 2 
					                               Uniform f32_4* %88 = OpAccessChain %34 %48 %49 
					                                        f32_4 %89 = OpLoad %88 
					                                        f32_3 %90 = OpVectorShuffle %89 %89 3 3 3 
					                                        f32_3 %91 = OpFMul %87 %90 
					                                        f32_4 %92 = OpLoad %47 
					                                        f32_3 %93 = OpVectorShuffle %92 %92 0 1 2 
					                                        f32_3 %94 = OpFAdd %91 %93 
					                                        f32_4 %95 = OpLoad %47 
					                                        f32_4 %96 = OpVectorShuffle %95 %94 4 5 6 3 
					                                                      OpStore %47 %96 
					                                        f32_4 %97 = OpLoad %47 
					                                        f32_3 %98 = OpVectorShuffle %97 %97 0 1 2 
					                                       f32_3 %100 = OpLoad %99 
					                                       f32_3 %101 = OpVectorShuffle %100 %100 1 1 1 
					                                       f32_3 %102 = OpFMul %98 %101 
					                                       f32_4 %103 = OpLoad %47 
					                                       f32_4 %104 = OpVectorShuffle %103 %102 4 5 6 3 
					                                                      OpStore %47 %104 
					                              Uniform f32_4* %106 = OpAccessChain %34 %48 %48 
					                                       f32_4 %107 = OpLoad %106 
					                                       f32_3 %108 = OpVectorShuffle %107 %107 1 1 1 
					                              Uniform f32_4* %109 = OpAccessChain %34 %49 %49 
					                                       f32_4 %110 = OpLoad %109 
					                                       f32_3 %111 = OpVectorShuffle %110 %110 0 1 2 
					                                       f32_3 %112 = OpFMul %108 %111 
					                                       f32_4 %113 = OpLoad %105 
					                                       f32_4 %114 = OpVectorShuffle %113 %112 4 5 6 3 
					                                                      OpStore %105 %114 
					                              Uniform f32_4* %115 = OpAccessChain %34 %49 %48 
					                                       f32_4 %116 = OpLoad %115 
					                                       f32_3 %117 = OpVectorShuffle %116 %116 0 1 2 
					                              Uniform f32_4* %118 = OpAccessChain %34 %48 %48 
					                                       f32_4 %119 = OpLoad %118 
					                                       f32_3 %120 = OpVectorShuffle %119 %119 0 0 0 
					                                       f32_3 %121 = OpFMul %117 %120 
					                                       f32_4 %122 = OpLoad %105 
					                                       f32_3 %123 = OpVectorShuffle %122 %122 0 1 2 
					                                       f32_3 %124 = OpFAdd %121 %123 
					                                       f32_4 %125 = OpLoad %105 
					                                       f32_4 %126 = OpVectorShuffle %125 %124 4 5 6 3 
					                                                      OpStore %105 %126 
					                              Uniform f32_4* %127 = OpAccessChain %34 %49 %71 
					                                       f32_4 %128 = OpLoad %127 
					                                       f32_3 %129 = OpVectorShuffle %128 %128 0 1 2 
					                              Uniform f32_4* %130 = OpAccessChain %34 %48 %48 
					                                       f32_4 %131 = OpLoad %130 
					                                       f32_3 %132 = OpVectorShuffle %131 %131 2 2 2 
					                                       f32_3 %133 = OpFMul %129 %132 
					                                       f32_4 %134 = OpLoad %105 
					                                       f32_3 %135 = OpVectorShuffle %134 %134 0 1 2 
					                                       f32_3 %136 = OpFAdd %133 %135 
					                                       f32_4 %137 = OpLoad %105 
					                                       f32_4 %138 = OpVectorShuffle %137 %136 4 5 6 3 
					                                                      OpStore %105 %138 
					                              Uniform f32_4* %139 = OpAccessChain %34 %49 %84 
					                                       f32_4 %140 = OpLoad %139 
					                                       f32_3 %141 = OpVectorShuffle %140 %140 0 1 2 
					                              Uniform f32_4* %142 = OpAccessChain %34 %48 %48 
					                                       f32_4 %143 = OpLoad %142 
					                                       f32_3 %144 = OpVectorShuffle %143 %143 3 3 3 
					                                       f32_3 %145 = OpFMul %141 %144 
					                                       f32_4 %146 = OpLoad %105 
					                                       f32_3 %147 = OpVectorShuffle %146 %146 0 1 2 
					                                       f32_3 %148 = OpFAdd %145 %147 
					                                       f32_4 %149 = OpLoad %105 
					                                       f32_4 %150 = OpVectorShuffle %149 %148 4 5 6 3 
					                                                      OpStore %105 %150 
					                                       f32_4 %151 = OpLoad %105 
					                                       f32_3 %152 = OpVectorShuffle %151 %151 0 1 2 
					                                       f32_3 %153 = OpLoad %99 
					                                       f32_3 %154 = OpVectorShuffle %153 %153 0 0 0 
					                                       f32_3 %155 = OpFMul %152 %154 
					                                       f32_4 %156 = OpLoad %47 
					                                       f32_3 %157 = OpVectorShuffle %156 %156 0 1 2 
					                                       f32_3 %158 = OpFAdd %155 %157 
					                                       f32_4 %159 = OpLoad %47 
					                                       f32_4 %160 = OpVectorShuffle %159 %158 4 5 6 3 
					                                                      OpStore %47 %160 
					                              Uniform f32_4* %161 = OpAccessChain %34 %48 %71 
					                                       f32_4 %162 = OpLoad %161 
					                                       f32_3 %163 = OpVectorShuffle %162 %162 1 1 1 
					                              Uniform f32_4* %164 = OpAccessChain %34 %49 %49 
					                                       f32_4 %165 = OpLoad %164 
					                                       f32_3 %166 = OpVectorShuffle %165 %165 0 1 2 
					                                       f32_3 %167 = OpFMul %163 %166 
					                                       f32_4 %168 = OpLoad %105 
					                                       f32_4 %169 = OpVectorShuffle %168 %167 4 5 6 3 
					                                                      OpStore %105 %169 
					                              Uniform f32_4* %170 = OpAccessChain %34 %49 %48 
					                                       f32_4 %171 = OpLoad %170 
					                                       f32_3 %172 = OpVectorShuffle %171 %171 0 1 2 
					                              Uniform f32_4* %173 = OpAccessChain %34 %48 %71 
					                                       f32_4 %174 = OpLoad %173 
					                                       f32_3 %175 = OpVectorShuffle %174 %174 0 0 0 
					                                       f32_3 %176 = OpFMul %172 %175 
					                                       f32_4 %177 = OpLoad %105 
					                                       f32_3 %178 = OpVectorShuffle %177 %177 0 1 2 
					                                       f32_3 %179 = OpFAdd %176 %178 
					                                       f32_4 %180 = OpLoad %105 
					                                       f32_4 %181 = OpVectorShuffle %180 %179 4 5 6 3 
					                                                      OpStore %105 %181 
					                              Uniform f32_4* %182 = OpAccessChain %34 %49 %71 
					                                       f32_4 %183 = OpLoad %182 
					                                       f32_3 %184 = OpVectorShuffle %183 %183 0 1 2 
					                              Uniform f32_4* %185 = OpAccessChain %34 %48 %71 
					                                       f32_4 %186 = OpLoad %185 
					                                       f32_3 %187 = OpVectorShuffle %186 %186 2 2 2 
					                                       f32_3 %188 = OpFMul %184 %187 
					                                       f32_4 %189 = OpLoad %105 
					                                       f32_3 %190 = OpVectorShuffle %189 %189 0 1 2 
					                                       f32_3 %191 = OpFAdd %188 %190 
					                                       f32_4 %192 = OpLoad %105 
					                                       f32_4 %193 = OpVectorShuffle %192 %191 4 5 6 3 
					                                                      OpStore %105 %193 
					                              Uniform f32_4* %194 = OpAccessChain %34 %49 %84 
					                                       f32_4 %195 = OpLoad %194 
					                                       f32_3 %196 = OpVectorShuffle %195 %195 0 1 2 
					                              Uniform f32_4* %197 = OpAccessChain %34 %48 %71 
					                                       f32_4 %198 = OpLoad %197 
					                                       f32_3 %199 = OpVectorShuffle %198 %198 3 3 3 
					                                       f32_3 %200 = OpFMul %196 %199 
					                                       f32_4 %201 = OpLoad %105 
					                                       f32_3 %202 = OpVectorShuffle %201 %201 0 1 2 
					                                       f32_3 %203 = OpFAdd %200 %202 
					                                       f32_4 %204 = OpLoad %105 
					                                       f32_4 %205 = OpVectorShuffle %204 %203 4 5 6 3 
					                                                      OpStore %105 %205 
					                                       f32_4 %206 = OpLoad %105 
					                                       f32_3 %207 = OpVectorShuffle %206 %206 0 1 2 
					                                       f32_3 %208 = OpLoad %99 
					                                       f32_3 %209 = OpVectorShuffle %208 %208 2 2 2 
					                                       f32_3 %210 = OpFMul %207 %209 
					                                       f32_4 %211 = OpLoad %47 
					                                       f32_3 %212 = OpVectorShuffle %211 %211 0 1 2 
					                                       f32_3 %213 = OpFAdd %210 %212 
					                                       f32_4 %214 = OpLoad %47 
					                                       f32_4 %215 = OpVectorShuffle %214 %213 4 5 6 3 
					                                                      OpStore %47 %215 
					                              Uniform f32_4* %216 = OpAccessChain %34 %48 %84 
					                                       f32_4 %217 = OpLoad %216 
					                                       f32_3 %218 = OpVectorShuffle %217 %217 1 1 1 
					                              Uniform f32_4* %219 = OpAccessChain %34 %49 %49 
					                                       f32_4 %220 = OpLoad %219 
					                                       f32_3 %221 = OpVectorShuffle %220 %220 0 1 2 
					                                       f32_3 %222 = OpFMul %218 %221 
					                                       f32_4 %223 = OpLoad %105 
					                                       f32_4 %224 = OpVectorShuffle %223 %222 4 5 6 3 
					                                                      OpStore %105 %224 
					                              Uniform f32_4* %225 = OpAccessChain %34 %49 %48 
					                                       f32_4 %226 = OpLoad %225 
					                                       f32_3 %227 = OpVectorShuffle %226 %226 0 1 2 
					                              Uniform f32_4* %228 = OpAccessChain %34 %48 %84 
					                                       f32_4 %229 = OpLoad %228 
					                                       f32_3 %230 = OpVectorShuffle %229 %229 0 0 0 
					                                       f32_3 %231 = OpFMul %227 %230 
					                                       f32_4 %232 = OpLoad %105 
					                                       f32_3 %233 = OpVectorShuffle %232 %232 0 1 2 
					                                       f32_3 %234 = OpFAdd %231 %233 
					                                       f32_4 %235 = OpLoad %105 
					                                       f32_4 %236 = OpVectorShuffle %235 %234 4 5 6 3 
					                                                      OpStore %105 %236 
					                              Uniform f32_4* %237 = OpAccessChain %34 %49 %71 
					                                       f32_4 %238 = OpLoad %237 
					                                       f32_3 %239 = OpVectorShuffle %238 %238 0 1 2 
					                              Uniform f32_4* %240 = OpAccessChain %34 %48 %84 
					                                       f32_4 %241 = OpLoad %240 
					                                       f32_3 %242 = OpVectorShuffle %241 %241 2 2 2 
					                                       f32_3 %243 = OpFMul %239 %242 
					                                       f32_4 %244 = OpLoad %105 
					                                       f32_3 %245 = OpVectorShuffle %244 %244 0 1 2 
					                                       f32_3 %246 = OpFAdd %243 %245 
					                                       f32_4 %247 = OpLoad %105 
					                                       f32_4 %248 = OpVectorShuffle %247 %246 4 5 6 3 
					                                                      OpStore %105 %248 
					                              Uniform f32_4* %249 = OpAccessChain %34 %49 %84 
					                                       f32_4 %250 = OpLoad %249 
					                                       f32_3 %251 = OpVectorShuffle %250 %250 0 1 2 
					                              Uniform f32_4* %252 = OpAccessChain %34 %48 %84 
					                                       f32_4 %253 = OpLoad %252 
					                                       f32_3 %254 = OpVectorShuffle %253 %253 3 3 3 
					                                       f32_3 %255 = OpFMul %251 %254 
					                                       f32_4 %256 = OpLoad %105 
					                                       f32_3 %257 = OpVectorShuffle %256 %256 0 1 2 
					                                       f32_3 %258 = OpFAdd %255 %257 
					                                       f32_4 %259 = OpLoad %105 
					                                       f32_4 %260 = OpVectorShuffle %259 %258 4 5 6 3 
					                                                      OpStore %105 %260 
					                                       f32_4 %261 = OpLoad %47 
					                                       f32_3 %262 = OpVectorShuffle %261 %261 0 1 2 
					                                       f32_4 %263 = OpLoad %105 
					                                       f32_3 %264 = OpVectorShuffle %263 %263 0 1 2 
					                                       f32_3 %265 = OpFAdd %262 %264 
					                                       f32_4 %266 = OpLoad %47 
					                                       f32_4 %267 = OpVectorShuffle %266 %265 4 5 6 3 
					                                                      OpStore %47 %267 
					                                       f32_4 %268 = OpLoad %47 
					                                       f32_3 %269 = OpVectorShuffle %268 %268 0 1 2 
					                                       f32_4 %270 = OpLoad %47 
					                                       f32_3 %271 = OpVectorShuffle %270 %270 0 1 2 
					                                         f32 %272 = OpDot %269 %271 
					                                Private f32* %275 = OpAccessChain %47 %273 
					                                                      OpStore %275 %272 
					                                Private f32* %276 = OpAccessChain %47 %273 
					                                         f32 %277 = OpLoad %276 
					                                         f32 %278 = OpExtInst %1 31 %277 
					                                Private f32* %279 = OpAccessChain %47 %273 
					                                                      OpStore %279 %278 
					                                Private f32* %280 = OpAccessChain %47 %273 
					                                         f32 %281 = OpLoad %280 
					                                Uniform f32* %283 = OpAccessChain %34 %84 %273 
					                                         f32 %284 = OpLoad %283 
					                                         f32 %285 = OpFMul %281 %284 
					                                Private f32* %286 = OpAccessChain %47 %273 
					                                                      OpStore %286 %285 
					                                Private f32* %287 = OpAccessChain %47 %273 
					                                         f32 %288 = OpLoad %287 
					                                Private f32* %289 = OpAccessChain %47 %273 
					                                         f32 %290 = OpLoad %289 
					                                         f32 %291 = OpFNegate %290 
					                                         f32 %292 = OpFMul %288 %291 
					                                Private f32* %293 = OpAccessChain %47 %273 
					                                                      OpStore %293 %292 
					                                Private f32* %296 = OpAccessChain %47 %273 
					                                         f32 %297 = OpLoad %296 
					                                         f32 %298 = OpExtInst %1 29 %297 
					                                                      OpStore %295 %298 
					                                       f32_3 %299 = OpLoad %99 
					                                       f32_4 %300 = OpVectorShuffle %299 %299 1 1 1 1 
					                              Uniform f32_4* %301 = OpAccessChain %34 %48 %49 
					                                       f32_4 %302 = OpLoad %301 
					                                       f32_4 %303 = OpFMul %300 %302 
					                                                      OpStore %47 %303 
					                              Uniform f32_4* %304 = OpAccessChain %34 %48 %48 
					                                       f32_4 %305 = OpLoad %304 
					                                       f32_3 %306 = OpLoad %99 
					                                       f32_4 %307 = OpVectorShuffle %306 %306 0 0 0 0 
					                                       f32_4 %308 = OpFMul %305 %307 
					                                       f32_4 %309 = OpLoad %47 
					                                       f32_4 %310 = OpFAdd %308 %309 
					                                                      OpStore %47 %310 
					                              Uniform f32_4* %311 = OpAccessChain %34 %48 %71 
					                                       f32_4 %312 = OpLoad %311 
					                                       f32_3 %313 = OpLoad %99 
					                                       f32_4 %314 = OpVectorShuffle %313 %313 2 2 2 2 
					                                       f32_4 %315 = OpFMul %312 %314 
					                                       f32_4 %316 = OpLoad %47 
					                                       f32_4 %317 = OpFAdd %315 %316 
					                                                      OpStore %47 %317 
					                                       f32_4 %318 = OpLoad %47 
					                              Uniform f32_4* %319 = OpAccessChain %34 %48 %84 
					                                       f32_4 %320 = OpLoad %319 
					                                       f32_4 %321 = OpFAdd %318 %320 
					                                                      OpStore %47 %321 
					                                       f32_4 %322 = OpLoad %47 
					                                       f32_4 %323 = OpVectorShuffle %322 %322 1 1 1 1 
					                              Uniform f32_4* %324 = OpAccessChain %34 %71 %49 
					                                       f32_4 %325 = OpLoad %324 
					                                       f32_4 %326 = OpFMul %323 %325 
					                                                      OpStore %105 %326 
					                              Uniform f32_4* %327 = OpAccessChain %34 %71 %48 
					                                       f32_4 %328 = OpLoad %327 
					                                       f32_4 %329 = OpLoad %47 
					                                       f32_4 %330 = OpVectorShuffle %329 %329 0 0 0 0 
					                                       f32_4 %331 = OpFMul %328 %330 
					                                       f32_4 %332 = OpLoad %105 
					                                       f32_4 %333 = OpFAdd %331 %332 
					                                                      OpStore %105 %333 
					                              Uniform f32_4* %334 = OpAccessChain %34 %71 %71 
					                                       f32_4 %335 = OpLoad %334 
					                                       f32_4 %336 = OpLoad %47 
					                                       f32_4 %337 = OpVectorShuffle %336 %336 2 2 2 2 
					                                       f32_4 %338 = OpFMul %335 %337 
					                                       f32_4 %339 = OpLoad %105 
					                                       f32_4 %340 = OpFAdd %338 %339 
					                                                      OpStore %105 %340 
					                              Uniform f32_4* %346 = OpAccessChain %34 %71 %84 
					                                       f32_4 %347 = OpLoad %346 
					                                       f32_4 %348 = OpLoad %47 
					                                       f32_4 %349 = OpVectorShuffle %348 %348 3 3 3 3 
					                                       f32_4 %350 = OpFMul %347 %349 
					                                       f32_4 %351 = OpLoad %105 
					                                       f32_4 %352 = OpFAdd %350 %351 
					                               Output f32_4* %353 = OpAccessChain %345 %48 
					                                                      OpStore %353 %352 
					                                 Output f32* %354 = OpAccessChain %345 %48 %341 
					                                         f32 %355 = OpLoad %354 
					                                         f32 %356 = OpFNegate %355 
					                                 Output f32* %357 = OpAccessChain %345 %48 %341 
					                                                      OpStore %357 %356 
					                                                      OpReturn
					                                                      OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 62
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %16 %24 %27 %50 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %8 RelaxedPrecision 
					                                                    OpDecorate %12 RelaxedPrecision 
					                                                    OpDecorate %12 DescriptorSet 12 
					                                                    OpDecorate %12 Binding 12 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %16 Location 16 
					                                                    OpDecorate %22 RelaxedPrecision 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %24 Location 24 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpDecorate %27 Location 27 
					                                                    OpDecorate %30 RelaxedPrecision 
					                                                    OpDecorate %31 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                                    OpDecorate %37 RelaxedPrecision 
					                                                    OpDecorate %38 RelaxedPrecision 
					                                                    OpMemberDecorate %39 0 RelaxedPrecision 
					                                                    OpMemberDecorate %39 0 Offset 39 
					                                                    OpDecorate %39 Block 
					                                                    OpDecorate %41 DescriptorSet 41 
					                                                    OpDecorate %41 Binding 41 
					                                                    OpDecorate %46 RelaxedPrecision 
					                                                    OpDecorate %47 RelaxedPrecision 
					                                                    OpDecorate %48 RelaxedPrecision 
					                                                    OpDecorate %49 RelaxedPrecision 
					                                                    OpDecorate %50 RelaxedPrecision 
					                                                    OpDecorate %50 Location 50 
					                                                    OpDecorate %51 RelaxedPrecision 
					                                                    OpDecorate %52 RelaxedPrecision 
					                                                    OpDecorate %53 RelaxedPrecision 
					                                                    OpDecorate %54 RelaxedPrecision 
					                                                    OpDecorate %56 RelaxedPrecision 
					                                                    OpDecorate %57 RelaxedPrecision 
					                                                    OpDecorate %58 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypePointer Private %6 
					                                Private f32* %8 = OpVariable Private 
					                                             %9 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %10 = OpTypeSampledImage %9 
					                                            %11 = OpTypePointer UniformConstant %10 
					UniformConstant read_only Texture2DSampled* %12 = OpVariable UniformConstant 
					                                            %14 = OpTypeVector %6 2 
					                                            %15 = OpTypePointer Input %14 
					                               Input f32_2* %16 = OpVariable Input 
					                                            %18 = OpTypeVector %6 4 
					                                            %20 = OpTypeInt 32 0 
					                                        u32 %21 = OpConstant 3 
					                                            %23 = OpTypePointer Output %18 
					                              Output f32_4* %24 = OpVariable Output 
					                                            %26 = OpTypePointer Input %18 
					                               Input f32_4* %27 = OpVariable Input 
					                                            %28 = OpTypePointer Input %6 
					                                            %32 = OpTypePointer Output %6 
					                                            %34 = OpTypeVector %6 3 
					                                            %35 = OpTypePointer Private %34 
					                             Private f32_3* %36 = OpVariable Private 
					                                            %39 = OpTypeStruct %18 
					                                            %40 = OpTypePointer Uniform %39 
					                   Uniform struct {f32_4;}* %41 = OpVariable Uniform 
					                                            %42 = OpTypeInt 32 1 
					                                        i32 %43 = OpConstant 0 
					                                            %44 = OpTypePointer Uniform %18 
					                                 Input f32* %50 = OpVariable Input 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %13 = OpLoad %12 
					                                      f32_2 %17 = OpLoad %16 
					                                      f32_4 %19 = OpImageSampleImplicitLod %13 %17 
					                                        f32 %22 = OpCompositeExtract %19 3 
					                                                    OpStore %8 %22 
					                                        f32 %25 = OpLoad %8 
					                                 Input f32* %29 = OpAccessChain %27 %21 
					                                        f32 %30 = OpLoad %29 
					                                        f32 %31 = OpFMul %25 %30 
					                                Output f32* %33 = OpAccessChain %24 %21 
					                                                    OpStore %33 %31 
					                                      f32_4 %37 = OpLoad %27 
					                                      f32_3 %38 = OpVectorShuffle %37 %37 0 1 2 
					                             Uniform f32_4* %45 = OpAccessChain %41 %43 
					                                      f32_4 %46 = OpLoad %45 
					                                      f32_3 %47 = OpVectorShuffle %46 %46 0 1 2 
					                                      f32_3 %48 = OpFNegate %47 
					                                      f32_3 %49 = OpFAdd %38 %48 
					                                                    OpStore %36 %49 
					                                        f32 %51 = OpLoad %50 
					                                      f32_3 %52 = OpCompositeConstruct %51 %51 %51 
					                                      f32_3 %53 = OpLoad %36 
					                                      f32_3 %54 = OpFMul %52 %53 
					                             Uniform f32_4* %55 = OpAccessChain %41 %43 
					                                      f32_4 %56 = OpLoad %55 
					                                      f32_3 %57 = OpVectorShuffle %56 %56 0 1 2 
					                                      f32_3 %58 = OpFAdd %54 %57 
					                                      f32_4 %59 = OpLoad %24 
					                                      f32_4 %60 = OpVectorShuffle %59 %58 4 5 6 3 
					                                                    OpStore %24 %60 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					"!!!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					"!!!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					"!!!!GLES3"
				}
				SubProgram "vulkan hw_tier00 " {
					"!!vulkan"
				}
				SubProgram "vulkan hw_tier01 " {
					"!!vulkan"
				}
				SubProgram "vulkan hw_tier02 " {
					"!!vulkan"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!!!GLES3"
				}
				SubProgram "vulkan hw_tier00 " {
					Keywords { "FOG_EXP2" }
					"!!vulkan"
				}
				SubProgram "vulkan hw_tier01 " {
					Keywords { "FOG_EXP2" }
					"!!vulkan"
				}
				SubProgram "vulkan hw_tier02 " {
					Keywords { "FOG_EXP2" }
					"!!vulkan"
				}
			}
		}
	}
}