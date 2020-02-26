Shader "Cartoon FX/Particle Multiply Colored" {
	Properties {
		_TintColor ("Tint Color", Vector) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture (alpha)", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01, 3)) = 1
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend DstColor Zero, DstColor Zero
			ColorMask RGB -1
			ZWrite Off
			Cull Off
			GpuProgramID 46631
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
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  highp vec4 tmpvar_1;
					  tmpvar_1.w = 1.0;
					  tmpvar_1.xyz = _glesVertex.xyz;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_1));
					  xlv_COLOR = _glesColor;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					uniform lowp vec4 _TintColor;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  tmpvar_1 = mix (vec4(1.0, 1.0, 1.0, 1.0), (_TintColor * xlv_COLOR), (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR.w));
					  gl_FragData[0] = tmpvar_1;
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
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  highp vec4 tmpvar_1;
					  tmpvar_1.w = 1.0;
					  tmpvar_1.xyz = _glesVertex.xyz;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_1));
					  xlv_COLOR = _glesColor;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					uniform lowp vec4 _TintColor;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  tmpvar_1 = mix (vec4(1.0, 1.0, 1.0, 1.0), (_TintColor * xlv_COLOR), (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR.w));
					  gl_FragData[0] = tmpvar_1;
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
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  highp vec4 tmpvar_1;
					  tmpvar_1.w = 1.0;
					  tmpvar_1.xyz = _glesVertex.xyz;
					  gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_1));
					  xlv_COLOR = _glesColor;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform sampler2D _MainTex;
					uniform lowp vec4 _TintColor;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  tmpvar_1 = mix (vec4(1.0, 1.0, 1.0, 1.0), (_TintColor * xlv_COLOR), (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR.w));
					  gl_FragData[0] = tmpvar_1;
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
					in highp vec4 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec2 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 _TintColor;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0 * vs_COLOR0.wwww;
					    u_xlat16_1 = _TintColor * vs_COLOR0 + vec4(-1.0, -1.0, -1.0, -1.0);
					    SV_Target0 = u_xlat16_0 * u_xlat16_1 + vec4(1.0, 1.0, 1.0, 1.0);
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
					in highp vec4 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec2 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 _TintColor;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0 * vs_COLOR0.wwww;
					    u_xlat16_1 = _TintColor * vs_COLOR0 + vec4(-1.0, -1.0, -1.0, -1.0);
					    SV_Target0 = u_xlat16_0 * u_xlat16_1 + vec4(1.0, 1.0, 1.0, 1.0);
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
					in highp vec4 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec2 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	mediump vec4 _TintColor;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					layout(location = 0) out mediump vec4 SV_Target0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0 * vs_COLOR0.wwww;
					    u_xlat16_1 = _TintColor * vs_COLOR0 + vec4(-1.0, -1.0, -1.0, -1.0);
					    SV_Target0 = u_xlat16_0 * u_xlat16_1 + vec4(1.0, 1.0, 1.0, 1.0);
					    return;
					}
					
					#endif"
				}
				SubProgram "vulkan hw_tier00 " {
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 105
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Vertex %4 "main" %11 %72 %82 %83 %87 %89 
					                                                     OpDecorate %11 Location 11 
					                                                     OpDecorate %16 ArrayStride 16 
					                                                     OpDecorate %17 ArrayStride 17 
					                                                     OpMemberDecorate %18 0 Offset 18 
					                                                     OpMemberDecorate %18 1 Offset 18 
					                                                     OpMemberDecorate %18 2 Offset 18 
					                                                     OpDecorate %18 Block 
					                                                     OpDecorate %20 DescriptorSet 20 
					                                                     OpDecorate %20 Binding 20 
					                                                     OpMemberDecorate %70 0 BuiltIn 70 
					                                                     OpMemberDecorate %70 1 BuiltIn 70 
					                                                     OpMemberDecorate %70 2 BuiltIn 70 
					                                                     OpDecorate %70 Block 
					                                                     OpDecorate %82 RelaxedPrecision 
					                                                     OpDecorate %82 Location 82 
					                                                     OpDecorate %83 RelaxedPrecision 
					                                                     OpDecorate %83 Location 83 
					                                                     OpDecorate %84 RelaxedPrecision 
					                                                     OpDecorate %87 Location 87 
					                                                     OpDecorate %89 Location 89 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 4 
					                                              %8 = OpTypePointer Private %7 
					                               Private f32_4* %9 = OpVariable Private 
					                                             %10 = OpTypePointer Input %7 
					                                Input f32_4* %11 = OpVariable Input 
					                                             %14 = OpTypeInt 32 0 
					                                         u32 %15 = OpConstant 4 
					                                             %16 = OpTypeArray %7 %15 
					                                             %17 = OpTypeArray %7 %15 
					                                             %18 = OpTypeStruct %16 %17 %7 
					                                             %19 = OpTypePointer Uniform %18 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4;}* %20 = OpVariable Uniform 
					                                             %21 = OpTypeInt 32 1 
					                                         i32 %22 = OpConstant 0 
					                                         i32 %23 = OpConstant 1 
					                                             %24 = OpTypePointer Uniform %7 
					                                         i32 %35 = OpConstant 2 
					                                         i32 %44 = OpConstant 3 
					                              Private f32_4* %48 = OpVariable Private 
					                                         u32 %68 = OpConstant 1 
					                                             %69 = OpTypeArray %6 %68 
					                                             %70 = OpTypeStruct %7 %6 %69 
					                                             %71 = OpTypePointer Output %70 
					        Output struct {f32_4; f32; f32[1];}* %72 = OpVariable Output 
					                                             %80 = OpTypePointer Output %7 
					                               Output f32_4* %82 = OpVariable Output 
					                                Input f32_4* %83 = OpVariable Input 
					                                             %85 = OpTypeVector %6 2 
					                                             %86 = OpTypePointer Output %85 
					                               Output f32_2* %87 = OpVariable Output 
					                                             %88 = OpTypePointer Input %85 
					                                Input f32_2* %89 = OpVariable Input 
					                                             %99 = OpTypePointer Output %6 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %12 = OpLoad %11 
					                                       f32_4 %13 = OpVectorShuffle %12 %12 1 1 1 1 
					                              Uniform f32_4* %25 = OpAccessChain %20 %22 %23 
					                                       f32_4 %26 = OpLoad %25 
					                                       f32_4 %27 = OpFMul %13 %26 
					                                                     OpStore %9 %27 
					                              Uniform f32_4* %28 = OpAccessChain %20 %22 %22 
					                                       f32_4 %29 = OpLoad %28 
					                                       f32_4 %30 = OpLoad %11 
					                                       f32_4 %31 = OpVectorShuffle %30 %30 0 0 0 0 
					                                       f32_4 %32 = OpFMul %29 %31 
					                                       f32_4 %33 = OpLoad %9 
					                                       f32_4 %34 = OpFAdd %32 %33 
					                                                     OpStore %9 %34 
					                              Uniform f32_4* %36 = OpAccessChain %20 %22 %35 
					                                       f32_4 %37 = OpLoad %36 
					                                       f32_4 %38 = OpLoad %11 
					                                       f32_4 %39 = OpVectorShuffle %38 %38 2 2 2 2 
					                                       f32_4 %40 = OpFMul %37 %39 
					                                       f32_4 %41 = OpLoad %9 
					                                       f32_4 %42 = OpFAdd %40 %41 
					                                                     OpStore %9 %42 
					                                       f32_4 %43 = OpLoad %9 
					                              Uniform f32_4* %45 = OpAccessChain %20 %22 %44 
					                                       f32_4 %46 = OpLoad %45 
					                                       f32_4 %47 = OpFAdd %43 %46 
					                                                     OpStore %9 %47 
					                                       f32_4 %49 = OpLoad %9 
					                                       f32_4 %50 = OpVectorShuffle %49 %49 1 1 1 1 
					                              Uniform f32_4* %51 = OpAccessChain %20 %23 %23 
					                                       f32_4 %52 = OpLoad %51 
					                                       f32_4 %53 = OpFMul %50 %52 
					                                                     OpStore %48 %53 
					                              Uniform f32_4* %54 = OpAccessChain %20 %23 %22 
					                                       f32_4 %55 = OpLoad %54 
					                                       f32_4 %56 = OpLoad %9 
					                                       f32_4 %57 = OpVectorShuffle %56 %56 0 0 0 0 
					                                       f32_4 %58 = OpFMul %55 %57 
					                                       f32_4 %59 = OpLoad %48 
					                                       f32_4 %60 = OpFAdd %58 %59 
					                                                     OpStore %48 %60 
					                              Uniform f32_4* %61 = OpAccessChain %20 %23 %35 
					                                       f32_4 %62 = OpLoad %61 
					                                       f32_4 %63 = OpLoad %9 
					                                       f32_4 %64 = OpVectorShuffle %63 %63 2 2 2 2 
					                                       f32_4 %65 = OpFMul %62 %64 
					                                       f32_4 %66 = OpLoad %48 
					                                       f32_4 %67 = OpFAdd %65 %66 
					                                                     OpStore %48 %67 
					                              Uniform f32_4* %73 = OpAccessChain %20 %23 %44 
					                                       f32_4 %74 = OpLoad %73 
					                                       f32_4 %75 = OpLoad %9 
					                                       f32_4 %76 = OpVectorShuffle %75 %75 3 3 3 3 
					                                       f32_4 %77 = OpFMul %74 %76 
					                                       f32_4 %78 = OpLoad %48 
					                                       f32_4 %79 = OpFAdd %77 %78 
					                               Output f32_4* %81 = OpAccessChain %72 %22 
					                                                     OpStore %81 %79 
					                                       f32_4 %84 = OpLoad %83 
					                                                     OpStore %82 %84 
					                                       f32_2 %90 = OpLoad %89 
					                              Uniform f32_4* %91 = OpAccessChain %20 %35 
					                                       f32_4 %92 = OpLoad %91 
					                                       f32_2 %93 = OpVectorShuffle %92 %92 0 1 
					                                       f32_2 %94 = OpFMul %90 %93 
					                              Uniform f32_4* %95 = OpAccessChain %20 %35 
					                                       f32_4 %96 = OpLoad %95 
					                                       f32_2 %97 = OpVectorShuffle %96 %96 2 3 
					                                       f32_2 %98 = OpFAdd %94 %97 
					                                                     OpStore %87 %98 
					                                Output f32* %100 = OpAccessChain %72 %22 %68 
					                                        f32 %101 = OpLoad %100 
					                                        f32 %102 = OpFNegate %101 
					                                Output f32* %103 = OpAccessChain %72 %22 %68 
					                                                     OpStore %103 %102 
					                                                     OpReturn
					                                                     OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 50
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %17 %23 %42 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %9 RelaxedPrecision 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %13 DescriptorSet 13 
					                                                    OpDecorate %13 Binding 13 
					                                                    OpDecorate %14 RelaxedPrecision 
					                                                    OpDecorate %17 Location 17 
					                                                    OpDecorate %20 RelaxedPrecision 
					                                                    OpDecorate %21 RelaxedPrecision 
					                                                    OpDecorate %23 RelaxedPrecision 
					                                                    OpDecorate %23 Location 23 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %26 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpMemberDecorate %28 0 RelaxedPrecision 
					                                                    OpMemberDecorate %28 0 Offset 28 
					                                                    OpDecorate %28 Block 
					                                                    OpDecorate %30 DescriptorSet 30 
					                                                    OpDecorate %30 Binding 30 
					                                                    OpDecorate %35 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                                    OpDecorate %37 RelaxedPrecision 
					                                                    OpDecorate %40 RelaxedPrecision 
					                                                    OpDecorate %42 RelaxedPrecision 
					                                                    OpDecorate %42 Location 42 
					                                                    OpDecorate %43 RelaxedPrecision 
					                                                    OpDecorate %44 RelaxedPrecision 
					                                                    OpDecorate %45 RelaxedPrecision 
					                                                    OpDecorate %48 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypeVector %6 4 
					                                             %8 = OpTypePointer Private %7 
					                              Private f32_4* %9 = OpVariable Private 
					                                            %10 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %11 = OpTypeSampledImage %10 
					                                            %12 = OpTypePointer UniformConstant %11 
					UniformConstant read_only Texture2DSampled* %13 = OpVariable UniformConstant 
					                                            %15 = OpTypeVector %6 2 
					                                            %16 = OpTypePointer Input %15 
					                               Input f32_2* %17 = OpVariable Input 
					                             Private f32_4* %20 = OpVariable Private 
					                                            %22 = OpTypePointer Input %7 
					                               Input f32_4* %23 = OpVariable Input 
					                             Private f32_4* %27 = OpVariable Private 
					                                            %28 = OpTypeStruct %7 
					                                            %29 = OpTypePointer Uniform %28 
					                   Uniform struct {f32_4;}* %30 = OpVariable Uniform 
					                                            %31 = OpTypeInt 32 1 
					                                        i32 %32 = OpConstant 0 
					                                            %33 = OpTypePointer Uniform %7 
					                                        f32 %38 = OpConstant 3.674022E-40 
					                                      f32_4 %39 = OpConstantComposite %38 %38 %38 %38 
					                                            %41 = OpTypePointer Output %7 
					                              Output f32_4* %42 = OpVariable Output 
					                                        f32 %46 = OpConstant 3.674022E-40 
					                                      f32_4 %47 = OpConstantComposite %46 %46 %46 %46 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %14 = OpLoad %13 
					                                      f32_2 %18 = OpLoad %17 
					                                      f32_4 %19 = OpImageSampleImplicitLod %14 %18 
					                                                    OpStore %9 %19 
					                                      f32_4 %21 = OpLoad %9 
					                                      f32_4 %24 = OpLoad %23 
					                                      f32_4 %25 = OpVectorShuffle %24 %24 3 3 3 3 
					                                      f32_4 %26 = OpFMul %21 %25 
					                                                    OpStore %20 %26 
					                             Uniform f32_4* %34 = OpAccessChain %30 %32 
					                                      f32_4 %35 = OpLoad %34 
					                                      f32_4 %36 = OpLoad %23 
					                                      f32_4 %37 = OpFMul %35 %36 
					                                      f32_4 %40 = OpFAdd %37 %39 
					                                                    OpStore %27 %40 
					                                      f32_4 %43 = OpLoad %20 
					                                      f32_4 %44 = OpLoad %27 
					                                      f32_4 %45 = OpFMul %43 %44 
					                                      f32_4 %48 = OpFAdd %45 %47 
					                                                    OpStore %42 %48 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier01 " {
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 105
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Vertex %4 "main" %11 %72 %82 %83 %87 %89 
					                                                     OpDecorate %11 Location 11 
					                                                     OpDecorate %16 ArrayStride 16 
					                                                     OpDecorate %17 ArrayStride 17 
					                                                     OpMemberDecorate %18 0 Offset 18 
					                                                     OpMemberDecorate %18 1 Offset 18 
					                                                     OpMemberDecorate %18 2 Offset 18 
					                                                     OpDecorate %18 Block 
					                                                     OpDecorate %20 DescriptorSet 20 
					                                                     OpDecorate %20 Binding 20 
					                                                     OpMemberDecorate %70 0 BuiltIn 70 
					                                                     OpMemberDecorate %70 1 BuiltIn 70 
					                                                     OpMemberDecorate %70 2 BuiltIn 70 
					                                                     OpDecorate %70 Block 
					                                                     OpDecorate %82 RelaxedPrecision 
					                                                     OpDecorate %82 Location 82 
					                                                     OpDecorate %83 RelaxedPrecision 
					                                                     OpDecorate %83 Location 83 
					                                                     OpDecorate %84 RelaxedPrecision 
					                                                     OpDecorate %87 Location 87 
					                                                     OpDecorate %89 Location 89 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 4 
					                                              %8 = OpTypePointer Private %7 
					                               Private f32_4* %9 = OpVariable Private 
					                                             %10 = OpTypePointer Input %7 
					                                Input f32_4* %11 = OpVariable Input 
					                                             %14 = OpTypeInt 32 0 
					                                         u32 %15 = OpConstant 4 
					                                             %16 = OpTypeArray %7 %15 
					                                             %17 = OpTypeArray %7 %15 
					                                             %18 = OpTypeStruct %16 %17 %7 
					                                             %19 = OpTypePointer Uniform %18 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4;}* %20 = OpVariable Uniform 
					                                             %21 = OpTypeInt 32 1 
					                                         i32 %22 = OpConstant 0 
					                                         i32 %23 = OpConstant 1 
					                                             %24 = OpTypePointer Uniform %7 
					                                         i32 %35 = OpConstant 2 
					                                         i32 %44 = OpConstant 3 
					                              Private f32_4* %48 = OpVariable Private 
					                                         u32 %68 = OpConstant 1 
					                                             %69 = OpTypeArray %6 %68 
					                                             %70 = OpTypeStruct %7 %6 %69 
					                                             %71 = OpTypePointer Output %70 
					        Output struct {f32_4; f32; f32[1];}* %72 = OpVariable Output 
					                                             %80 = OpTypePointer Output %7 
					                               Output f32_4* %82 = OpVariable Output 
					                                Input f32_4* %83 = OpVariable Input 
					                                             %85 = OpTypeVector %6 2 
					                                             %86 = OpTypePointer Output %85 
					                               Output f32_2* %87 = OpVariable Output 
					                                             %88 = OpTypePointer Input %85 
					                                Input f32_2* %89 = OpVariable Input 
					                                             %99 = OpTypePointer Output %6 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %12 = OpLoad %11 
					                                       f32_4 %13 = OpVectorShuffle %12 %12 1 1 1 1 
					                              Uniform f32_4* %25 = OpAccessChain %20 %22 %23 
					                                       f32_4 %26 = OpLoad %25 
					                                       f32_4 %27 = OpFMul %13 %26 
					                                                     OpStore %9 %27 
					                              Uniform f32_4* %28 = OpAccessChain %20 %22 %22 
					                                       f32_4 %29 = OpLoad %28 
					                                       f32_4 %30 = OpLoad %11 
					                                       f32_4 %31 = OpVectorShuffle %30 %30 0 0 0 0 
					                                       f32_4 %32 = OpFMul %29 %31 
					                                       f32_4 %33 = OpLoad %9 
					                                       f32_4 %34 = OpFAdd %32 %33 
					                                                     OpStore %9 %34 
					                              Uniform f32_4* %36 = OpAccessChain %20 %22 %35 
					                                       f32_4 %37 = OpLoad %36 
					                                       f32_4 %38 = OpLoad %11 
					                                       f32_4 %39 = OpVectorShuffle %38 %38 2 2 2 2 
					                                       f32_4 %40 = OpFMul %37 %39 
					                                       f32_4 %41 = OpLoad %9 
					                                       f32_4 %42 = OpFAdd %40 %41 
					                                                     OpStore %9 %42 
					                                       f32_4 %43 = OpLoad %9 
					                              Uniform f32_4* %45 = OpAccessChain %20 %22 %44 
					                                       f32_4 %46 = OpLoad %45 
					                                       f32_4 %47 = OpFAdd %43 %46 
					                                                     OpStore %9 %47 
					                                       f32_4 %49 = OpLoad %9 
					                                       f32_4 %50 = OpVectorShuffle %49 %49 1 1 1 1 
					                              Uniform f32_4* %51 = OpAccessChain %20 %23 %23 
					                                       f32_4 %52 = OpLoad %51 
					                                       f32_4 %53 = OpFMul %50 %52 
					                                                     OpStore %48 %53 
					                              Uniform f32_4* %54 = OpAccessChain %20 %23 %22 
					                                       f32_4 %55 = OpLoad %54 
					                                       f32_4 %56 = OpLoad %9 
					                                       f32_4 %57 = OpVectorShuffle %56 %56 0 0 0 0 
					                                       f32_4 %58 = OpFMul %55 %57 
					                                       f32_4 %59 = OpLoad %48 
					                                       f32_4 %60 = OpFAdd %58 %59 
					                                                     OpStore %48 %60 
					                              Uniform f32_4* %61 = OpAccessChain %20 %23 %35 
					                                       f32_4 %62 = OpLoad %61 
					                                       f32_4 %63 = OpLoad %9 
					                                       f32_4 %64 = OpVectorShuffle %63 %63 2 2 2 2 
					                                       f32_4 %65 = OpFMul %62 %64 
					                                       f32_4 %66 = OpLoad %48 
					                                       f32_4 %67 = OpFAdd %65 %66 
					                                                     OpStore %48 %67 
					                              Uniform f32_4* %73 = OpAccessChain %20 %23 %44 
					                                       f32_4 %74 = OpLoad %73 
					                                       f32_4 %75 = OpLoad %9 
					                                       f32_4 %76 = OpVectorShuffle %75 %75 3 3 3 3 
					                                       f32_4 %77 = OpFMul %74 %76 
					                                       f32_4 %78 = OpLoad %48 
					                                       f32_4 %79 = OpFAdd %77 %78 
					                               Output f32_4* %81 = OpAccessChain %72 %22 
					                                                     OpStore %81 %79 
					                                       f32_4 %84 = OpLoad %83 
					                                                     OpStore %82 %84 
					                                       f32_2 %90 = OpLoad %89 
					                              Uniform f32_4* %91 = OpAccessChain %20 %35 
					                                       f32_4 %92 = OpLoad %91 
					                                       f32_2 %93 = OpVectorShuffle %92 %92 0 1 
					                                       f32_2 %94 = OpFMul %90 %93 
					                              Uniform f32_4* %95 = OpAccessChain %20 %35 
					                                       f32_4 %96 = OpLoad %95 
					                                       f32_2 %97 = OpVectorShuffle %96 %96 2 3 
					                                       f32_2 %98 = OpFAdd %94 %97 
					                                                     OpStore %87 %98 
					                                Output f32* %100 = OpAccessChain %72 %22 %68 
					                                        f32 %101 = OpLoad %100 
					                                        f32 %102 = OpFNegate %101 
					                                Output f32* %103 = OpAccessChain %72 %22 %68 
					                                                     OpStore %103 %102 
					                                                     OpReturn
					                                                     OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 50
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %17 %23 %42 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %9 RelaxedPrecision 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %13 DescriptorSet 13 
					                                                    OpDecorate %13 Binding 13 
					                                                    OpDecorate %14 RelaxedPrecision 
					                                                    OpDecorate %17 Location 17 
					                                                    OpDecorate %20 RelaxedPrecision 
					                                                    OpDecorate %21 RelaxedPrecision 
					                                                    OpDecorate %23 RelaxedPrecision 
					                                                    OpDecorate %23 Location 23 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %26 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpMemberDecorate %28 0 RelaxedPrecision 
					                                                    OpMemberDecorate %28 0 Offset 28 
					                                                    OpDecorate %28 Block 
					                                                    OpDecorate %30 DescriptorSet 30 
					                                                    OpDecorate %30 Binding 30 
					                                                    OpDecorate %35 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                                    OpDecorate %37 RelaxedPrecision 
					                                                    OpDecorate %40 RelaxedPrecision 
					                                                    OpDecorate %42 RelaxedPrecision 
					                                                    OpDecorate %42 Location 42 
					                                                    OpDecorate %43 RelaxedPrecision 
					                                                    OpDecorate %44 RelaxedPrecision 
					                                                    OpDecorate %45 RelaxedPrecision 
					                                                    OpDecorate %48 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypeVector %6 4 
					                                             %8 = OpTypePointer Private %7 
					                              Private f32_4* %9 = OpVariable Private 
					                                            %10 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %11 = OpTypeSampledImage %10 
					                                            %12 = OpTypePointer UniformConstant %11 
					UniformConstant read_only Texture2DSampled* %13 = OpVariable UniformConstant 
					                                            %15 = OpTypeVector %6 2 
					                                            %16 = OpTypePointer Input %15 
					                               Input f32_2* %17 = OpVariable Input 
					                             Private f32_4* %20 = OpVariable Private 
					                                            %22 = OpTypePointer Input %7 
					                               Input f32_4* %23 = OpVariable Input 
					                             Private f32_4* %27 = OpVariable Private 
					                                            %28 = OpTypeStruct %7 
					                                            %29 = OpTypePointer Uniform %28 
					                   Uniform struct {f32_4;}* %30 = OpVariable Uniform 
					                                            %31 = OpTypeInt 32 1 
					                                        i32 %32 = OpConstant 0 
					                                            %33 = OpTypePointer Uniform %7 
					                                        f32 %38 = OpConstant 3.674022E-40 
					                                      f32_4 %39 = OpConstantComposite %38 %38 %38 %38 
					                                            %41 = OpTypePointer Output %7 
					                              Output f32_4* %42 = OpVariable Output 
					                                        f32 %46 = OpConstant 3.674022E-40 
					                                      f32_4 %47 = OpConstantComposite %46 %46 %46 %46 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %14 = OpLoad %13 
					                                      f32_2 %18 = OpLoad %17 
					                                      f32_4 %19 = OpImageSampleImplicitLod %14 %18 
					                                                    OpStore %9 %19 
					                                      f32_4 %21 = OpLoad %9 
					                                      f32_4 %24 = OpLoad %23 
					                                      f32_4 %25 = OpVectorShuffle %24 %24 3 3 3 3 
					                                      f32_4 %26 = OpFMul %21 %25 
					                                                    OpStore %20 %26 
					                             Uniform f32_4* %34 = OpAccessChain %30 %32 
					                                      f32_4 %35 = OpLoad %34 
					                                      f32_4 %36 = OpLoad %23 
					                                      f32_4 %37 = OpFMul %35 %36 
					                                      f32_4 %40 = OpFAdd %37 %39 
					                                                    OpStore %27 %40 
					                                      f32_4 %43 = OpLoad %20 
					                                      f32_4 %44 = OpLoad %27 
					                                      f32_4 %45 = OpFMul %43 %44 
					                                      f32_4 %48 = OpFAdd %45 %47 
					                                                    OpStore %42 %48 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier02 " {
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 105
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Vertex %4 "main" %11 %72 %82 %83 %87 %89 
					                                                     OpDecorate %11 Location 11 
					                                                     OpDecorate %16 ArrayStride 16 
					                                                     OpDecorate %17 ArrayStride 17 
					                                                     OpMemberDecorate %18 0 Offset 18 
					                                                     OpMemberDecorate %18 1 Offset 18 
					                                                     OpMemberDecorate %18 2 Offset 18 
					                                                     OpDecorate %18 Block 
					                                                     OpDecorate %20 DescriptorSet 20 
					                                                     OpDecorate %20 Binding 20 
					                                                     OpMemberDecorate %70 0 BuiltIn 70 
					                                                     OpMemberDecorate %70 1 BuiltIn 70 
					                                                     OpMemberDecorate %70 2 BuiltIn 70 
					                                                     OpDecorate %70 Block 
					                                                     OpDecorate %82 RelaxedPrecision 
					                                                     OpDecorate %82 Location 82 
					                                                     OpDecorate %83 RelaxedPrecision 
					                                                     OpDecorate %83 Location 83 
					                                                     OpDecorate %84 RelaxedPrecision 
					                                                     OpDecorate %87 Location 87 
					                                                     OpDecorate %89 Location 89 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 4 
					                                              %8 = OpTypePointer Private %7 
					                               Private f32_4* %9 = OpVariable Private 
					                                             %10 = OpTypePointer Input %7 
					                                Input f32_4* %11 = OpVariable Input 
					                                             %14 = OpTypeInt 32 0 
					                                         u32 %15 = OpConstant 4 
					                                             %16 = OpTypeArray %7 %15 
					                                             %17 = OpTypeArray %7 %15 
					                                             %18 = OpTypeStruct %16 %17 %7 
					                                             %19 = OpTypePointer Uniform %18 
					Uniform struct {f32_4[4]; f32_4[4]; f32_4;}* %20 = OpVariable Uniform 
					                                             %21 = OpTypeInt 32 1 
					                                         i32 %22 = OpConstant 0 
					                                         i32 %23 = OpConstant 1 
					                                             %24 = OpTypePointer Uniform %7 
					                                         i32 %35 = OpConstant 2 
					                                         i32 %44 = OpConstant 3 
					                              Private f32_4* %48 = OpVariable Private 
					                                         u32 %68 = OpConstant 1 
					                                             %69 = OpTypeArray %6 %68 
					                                             %70 = OpTypeStruct %7 %6 %69 
					                                             %71 = OpTypePointer Output %70 
					        Output struct {f32_4; f32; f32[1];}* %72 = OpVariable Output 
					                                             %80 = OpTypePointer Output %7 
					                               Output f32_4* %82 = OpVariable Output 
					                                Input f32_4* %83 = OpVariable Input 
					                                             %85 = OpTypeVector %6 2 
					                                             %86 = OpTypePointer Output %85 
					                               Output f32_2* %87 = OpVariable Output 
					                                             %88 = OpTypePointer Input %85 
					                                Input f32_2* %89 = OpVariable Input 
					                                             %99 = OpTypePointer Output %6 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %12 = OpLoad %11 
					                                       f32_4 %13 = OpVectorShuffle %12 %12 1 1 1 1 
					                              Uniform f32_4* %25 = OpAccessChain %20 %22 %23 
					                                       f32_4 %26 = OpLoad %25 
					                                       f32_4 %27 = OpFMul %13 %26 
					                                                     OpStore %9 %27 
					                              Uniform f32_4* %28 = OpAccessChain %20 %22 %22 
					                                       f32_4 %29 = OpLoad %28 
					                                       f32_4 %30 = OpLoad %11 
					                                       f32_4 %31 = OpVectorShuffle %30 %30 0 0 0 0 
					                                       f32_4 %32 = OpFMul %29 %31 
					                                       f32_4 %33 = OpLoad %9 
					                                       f32_4 %34 = OpFAdd %32 %33 
					                                                     OpStore %9 %34 
					                              Uniform f32_4* %36 = OpAccessChain %20 %22 %35 
					                                       f32_4 %37 = OpLoad %36 
					                                       f32_4 %38 = OpLoad %11 
					                                       f32_4 %39 = OpVectorShuffle %38 %38 2 2 2 2 
					                                       f32_4 %40 = OpFMul %37 %39 
					                                       f32_4 %41 = OpLoad %9 
					                                       f32_4 %42 = OpFAdd %40 %41 
					                                                     OpStore %9 %42 
					                                       f32_4 %43 = OpLoad %9 
					                              Uniform f32_4* %45 = OpAccessChain %20 %22 %44 
					                                       f32_4 %46 = OpLoad %45 
					                                       f32_4 %47 = OpFAdd %43 %46 
					                                                     OpStore %9 %47 
					                                       f32_4 %49 = OpLoad %9 
					                                       f32_4 %50 = OpVectorShuffle %49 %49 1 1 1 1 
					                              Uniform f32_4* %51 = OpAccessChain %20 %23 %23 
					                                       f32_4 %52 = OpLoad %51 
					                                       f32_4 %53 = OpFMul %50 %52 
					                                                     OpStore %48 %53 
					                              Uniform f32_4* %54 = OpAccessChain %20 %23 %22 
					                                       f32_4 %55 = OpLoad %54 
					                                       f32_4 %56 = OpLoad %9 
					                                       f32_4 %57 = OpVectorShuffle %56 %56 0 0 0 0 
					                                       f32_4 %58 = OpFMul %55 %57 
					                                       f32_4 %59 = OpLoad %48 
					                                       f32_4 %60 = OpFAdd %58 %59 
					                                                     OpStore %48 %60 
					                              Uniform f32_4* %61 = OpAccessChain %20 %23 %35 
					                                       f32_4 %62 = OpLoad %61 
					                                       f32_4 %63 = OpLoad %9 
					                                       f32_4 %64 = OpVectorShuffle %63 %63 2 2 2 2 
					                                       f32_4 %65 = OpFMul %62 %64 
					                                       f32_4 %66 = OpLoad %48 
					                                       f32_4 %67 = OpFAdd %65 %66 
					                                                     OpStore %48 %67 
					                              Uniform f32_4* %73 = OpAccessChain %20 %23 %44 
					                                       f32_4 %74 = OpLoad %73 
					                                       f32_4 %75 = OpLoad %9 
					                                       f32_4 %76 = OpVectorShuffle %75 %75 3 3 3 3 
					                                       f32_4 %77 = OpFMul %74 %76 
					                                       f32_4 %78 = OpLoad %48 
					                                       f32_4 %79 = OpFAdd %77 %78 
					                               Output f32_4* %81 = OpAccessChain %72 %22 
					                                                     OpStore %81 %79 
					                                       f32_4 %84 = OpLoad %83 
					                                                     OpStore %82 %84 
					                                       f32_2 %90 = OpLoad %89 
					                              Uniform f32_4* %91 = OpAccessChain %20 %35 
					                                       f32_4 %92 = OpLoad %91 
					                                       f32_2 %93 = OpVectorShuffle %92 %92 0 1 
					                                       f32_2 %94 = OpFMul %90 %93 
					                              Uniform f32_4* %95 = OpAccessChain %20 %35 
					                                       f32_4 %96 = OpLoad %95 
					                                       f32_2 %97 = OpVectorShuffle %96 %96 2 3 
					                                       f32_2 %98 = OpFAdd %94 %97 
					                                                     OpStore %87 %98 
					                                Output f32* %100 = OpAccessChain %72 %22 %68 
					                                        f32 %101 = OpLoad %100 
					                                        f32 %102 = OpFNegate %101 
					                                Output f32* %103 = OpAccessChain %72 %22 %68 
					                                                     OpStore %103 %102 
					                                                     OpReturn
					                                                     OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 50
					; Schema: 0
					                                                    OpCapability Shader 
					                                             %1 = OpExtInstImport "GLSL.std.450" 
					                                                    OpMemoryModel Logical GLSL450 
					                                                    OpEntryPoint Fragment %4 "main" %17 %23 %42 
					                                                    OpExecutionMode %4 OriginUpperLeft 
					                                                    OpDecorate %9 RelaxedPrecision 
					                                                    OpDecorate %13 RelaxedPrecision 
					                                                    OpDecorate %13 DescriptorSet 13 
					                                                    OpDecorate %13 Binding 13 
					                                                    OpDecorate %14 RelaxedPrecision 
					                                                    OpDecorate %17 Location 17 
					                                                    OpDecorate %20 RelaxedPrecision 
					                                                    OpDecorate %21 RelaxedPrecision 
					                                                    OpDecorate %23 RelaxedPrecision 
					                                                    OpDecorate %23 Location 23 
					                                                    OpDecorate %24 RelaxedPrecision 
					                                                    OpDecorate %25 RelaxedPrecision 
					                                                    OpDecorate %26 RelaxedPrecision 
					                                                    OpDecorate %27 RelaxedPrecision 
					                                                    OpMemberDecorate %28 0 RelaxedPrecision 
					                                                    OpMemberDecorate %28 0 Offset 28 
					                                                    OpDecorate %28 Block 
					                                                    OpDecorate %30 DescriptorSet 30 
					                                                    OpDecorate %30 Binding 30 
					                                                    OpDecorate %35 RelaxedPrecision 
					                                                    OpDecorate %36 RelaxedPrecision 
					                                                    OpDecorate %37 RelaxedPrecision 
					                                                    OpDecorate %40 RelaxedPrecision 
					                                                    OpDecorate %42 RelaxedPrecision 
					                                                    OpDecorate %42 Location 42 
					                                                    OpDecorate %43 RelaxedPrecision 
					                                                    OpDecorate %44 RelaxedPrecision 
					                                                    OpDecorate %45 RelaxedPrecision 
					                                                    OpDecorate %48 RelaxedPrecision 
					                                             %2 = OpTypeVoid 
					                                             %3 = OpTypeFunction %2 
					                                             %6 = OpTypeFloat 32 
					                                             %7 = OpTypeVector %6 4 
					                                             %8 = OpTypePointer Private %7 
					                              Private f32_4* %9 = OpVariable Private 
					                                            %10 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                            %11 = OpTypeSampledImage %10 
					                                            %12 = OpTypePointer UniformConstant %11 
					UniformConstant read_only Texture2DSampled* %13 = OpVariable UniformConstant 
					                                            %15 = OpTypeVector %6 2 
					                                            %16 = OpTypePointer Input %15 
					                               Input f32_2* %17 = OpVariable Input 
					                             Private f32_4* %20 = OpVariable Private 
					                                            %22 = OpTypePointer Input %7 
					                               Input f32_4* %23 = OpVariable Input 
					                             Private f32_4* %27 = OpVariable Private 
					                                            %28 = OpTypeStruct %7 
					                                            %29 = OpTypePointer Uniform %28 
					                   Uniform struct {f32_4;}* %30 = OpVariable Uniform 
					                                            %31 = OpTypeInt 32 1 
					                                        i32 %32 = OpConstant 0 
					                                            %33 = OpTypePointer Uniform %7 
					                                        f32 %38 = OpConstant 3.674022E-40 
					                                      f32_4 %39 = OpConstantComposite %38 %38 %38 %38 
					                                            %41 = OpTypePointer Output %7 
					                              Output f32_4* %42 = OpVariable Output 
					                                        f32 %46 = OpConstant 3.674022E-40 
					                                      f32_4 %47 = OpConstantComposite %46 %46 %46 %46 
					                                        void %4 = OpFunction None %3 
					                                             %5 = OpLabel 
					                 read_only Texture2DSampled %14 = OpLoad %13 
					                                      f32_2 %18 = OpLoad %17 
					                                      f32_4 %19 = OpImageSampleImplicitLod %14 %18 
					                                                    OpStore %9 %19 
					                                      f32_4 %21 = OpLoad %9 
					                                      f32_4 %24 = OpLoad %23 
					                                      f32_4 %25 = OpVectorShuffle %24 %24 3 3 3 3 
					                                      f32_4 %26 = OpFMul %21 %25 
					                                                    OpStore %20 %26 
					                             Uniform f32_4* %34 = OpAccessChain %30 %32 
					                                      f32_4 %35 = OpLoad %34 
					                                      f32_4 %36 = OpLoad %23 
					                                      f32_4 %37 = OpFMul %35 %36 
					                                      f32_4 %40 = OpFAdd %37 %39 
					                                                    OpStore %27 %40 
					                                      f32_4 %43 = OpLoad %20 
					                                      f32_4 %44 = OpLoad %27 
					                                      f32_4 %45 = OpFMul %43 %44 
					                                      f32_4 %48 = OpFAdd %45 %47 
					                                                    OpStore %42 %48 
					                                                    OpReturn
					                                                    OpFunctionEnd"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp vec4 _ProjectionParams;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec4 xlv_TEXCOORD1;
					void main ()
					{
					  highp vec4 tmpvar_1;
					  tmpvar_1 = _glesVertex;
					  highp vec4 tmpvar_2;
					  highp vec4 tmpvar_3;
					  highp vec4 tmpvar_4;
					  tmpvar_4.w = 1.0;
					  tmpvar_4.xyz = tmpvar_1.xyz;
					  tmpvar_3 = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_4));
					  highp vec4 o_5;
					  highp vec4 tmpvar_6;
					  tmpvar_6 = (tmpvar_3 * 0.5);
					  highp vec2 tmpvar_7;
					  tmpvar_7.x = tmpvar_6.x;
					  tmpvar_7.y = (tmpvar_6.y * _ProjectionParams.x);
					  o_5.xy = (tmpvar_7 + tmpvar_6.w);
					  o_5.zw = tmpvar_3.zw;
					  tmpvar_2.xyw = o_5.xyw;
					  highp vec4 tmpvar_8;
					  tmpvar_8.w = 1.0;
					  tmpvar_8.xyz = tmpvar_1.xyz;
					  tmpvar_2.z = -((unity_MatrixV * (unity_ObjectToWorld * tmpvar_8)).z);
					  gl_Position = tmpvar_3;
					  xlv_COLOR = _glesColor;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = tmpvar_2;
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform highp vec4 _ZBufferParams;
					uniform sampler2D _MainTex;
					uniform lowp vec4 _TintColor;
					uniform sampler2D _CameraDepthTexture;
					uniform highp float _InvFade;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec4 xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  tmpvar_1.xyz = xlv_COLOR.xyz;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2DProj (_CameraDepthTexture, xlv_TEXCOORD1);
					  highp float z_3;
					  z_3 = tmpvar_2.x;
					  highp float tmpvar_4;
					  tmpvar_4 = clamp ((_InvFade * (
					    (1.0/(((_ZBufferParams.z * z_3) + _ZBufferParams.w)))
					   - xlv_TEXCOORD1.z)), 0.0, 1.0);
					  tmpvar_1.w = (xlv_COLOR.w * tmpvar_4);
					  lowp vec4 tmpvar_5;
					  tmpvar_5 = mix (vec4(1.0, 1.0, 1.0, 1.0), (_TintColor * tmpvar_1), (texture2D (_MainTex, xlv_TEXCOORD0) * tmpvar_1.w));
					  gl_FragData[0] = tmpvar_5;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp vec4 _ProjectionParams;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec4 xlv_TEXCOORD1;
					void main ()
					{
					  highp vec4 tmpvar_1;
					  tmpvar_1 = _glesVertex;
					  highp vec4 tmpvar_2;
					  highp vec4 tmpvar_3;
					  highp vec4 tmpvar_4;
					  tmpvar_4.w = 1.0;
					  tmpvar_4.xyz = tmpvar_1.xyz;
					  tmpvar_3 = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_4));
					  highp vec4 o_5;
					  highp vec4 tmpvar_6;
					  tmpvar_6 = (tmpvar_3 * 0.5);
					  highp vec2 tmpvar_7;
					  tmpvar_7.x = tmpvar_6.x;
					  tmpvar_7.y = (tmpvar_6.y * _ProjectionParams.x);
					  o_5.xy = (tmpvar_7 + tmpvar_6.w);
					  o_5.zw = tmpvar_3.zw;
					  tmpvar_2.xyw = o_5.xyw;
					  highp vec4 tmpvar_8;
					  tmpvar_8.w = 1.0;
					  tmpvar_8.xyz = tmpvar_1.xyz;
					  tmpvar_2.z = -((unity_MatrixV * (unity_ObjectToWorld * tmpvar_8)).z);
					  gl_Position = tmpvar_3;
					  xlv_COLOR = _glesColor;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = tmpvar_2;
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform highp vec4 _ZBufferParams;
					uniform sampler2D _MainTex;
					uniform lowp vec4 _TintColor;
					uniform sampler2D _CameraDepthTexture;
					uniform highp float _InvFade;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec4 xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  tmpvar_1.xyz = xlv_COLOR.xyz;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2DProj (_CameraDepthTexture, xlv_TEXCOORD1);
					  highp float z_3;
					  z_3 = tmpvar_2.x;
					  highp float tmpvar_4;
					  tmpvar_4 = clamp ((_InvFade * (
					    (1.0/(((_ZBufferParams.z * z_3) + _ZBufferParams.w)))
					   - xlv_TEXCOORD1.z)), 0.0, 1.0);
					  tmpvar_1.w = (xlv_COLOR.w * tmpvar_4);
					  lowp vec4 tmpvar_5;
					  tmpvar_5 = mix (vec4(1.0, 1.0, 1.0, 1.0), (_TintColor * tmpvar_1), (texture2D (_MainTex, xlv_TEXCOORD0) * tmpvar_1.w));
					  gl_FragData[0] = tmpvar_5;
					}
					
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES
					#version 100
					
					#ifdef VERTEX
					attribute vec4 _glesVertex;
					attribute vec4 _glesColor;
					attribute vec4 _glesMultiTexCoord0;
					uniform highp vec4 _ProjectionParams;
					uniform highp mat4 unity_ObjectToWorld;
					uniform highp mat4 unity_MatrixV;
					uniform highp mat4 unity_MatrixVP;
					uniform highp vec4 _MainTex_ST;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec4 xlv_TEXCOORD1;
					void main ()
					{
					  highp vec4 tmpvar_1;
					  tmpvar_1 = _glesVertex;
					  highp vec4 tmpvar_2;
					  highp vec4 tmpvar_3;
					  highp vec4 tmpvar_4;
					  tmpvar_4.w = 1.0;
					  tmpvar_4.xyz = tmpvar_1.xyz;
					  tmpvar_3 = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_4));
					  highp vec4 o_5;
					  highp vec4 tmpvar_6;
					  tmpvar_6 = (tmpvar_3 * 0.5);
					  highp vec2 tmpvar_7;
					  tmpvar_7.x = tmpvar_6.x;
					  tmpvar_7.y = (tmpvar_6.y * _ProjectionParams.x);
					  o_5.xy = (tmpvar_7 + tmpvar_6.w);
					  o_5.zw = tmpvar_3.zw;
					  tmpvar_2.xyw = o_5.xyw;
					  highp vec4 tmpvar_8;
					  tmpvar_8.w = 1.0;
					  tmpvar_8.xyz = tmpvar_1.xyz;
					  tmpvar_2.z = -((unity_MatrixV * (unity_ObjectToWorld * tmpvar_8)).z);
					  gl_Position = tmpvar_3;
					  xlv_COLOR = _glesColor;
					  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
					  xlv_TEXCOORD1 = tmpvar_2;
					}
					
					
					#endif
					#ifdef FRAGMENT
					uniform highp vec4 _ZBufferParams;
					uniform sampler2D _MainTex;
					uniform lowp vec4 _TintColor;
					uniform sampler2D _CameraDepthTexture;
					uniform highp float _InvFade;
					varying lowp vec4 xlv_COLOR;
					varying highp vec2 xlv_TEXCOORD0;
					varying highp vec4 xlv_TEXCOORD1;
					void main ()
					{
					  lowp vec4 tmpvar_1;
					  tmpvar_1.xyz = xlv_COLOR.xyz;
					  lowp vec4 tmpvar_2;
					  tmpvar_2 = texture2DProj (_CameraDepthTexture, xlv_TEXCOORD1);
					  highp float z_3;
					  z_3 = tmpvar_2.x;
					  highp float tmpvar_4;
					  tmpvar_4 = clamp ((_InvFade * (
					    (1.0/(((_ZBufferParams.z * z_3) + _ZBufferParams.w)))
					   - xlv_TEXCOORD1.z)), 0.0, 1.0);
					  tmpvar_1.w = (xlv_COLOR.w * tmpvar_4);
					  lowp vec4 tmpvar_5;
					  tmpvar_5 = mix (vec4(1.0, 1.0, 1.0, 1.0), (_TintColor * tmpvar_1), (texture2D (_MainTex, xlv_TEXCOORD0) * tmpvar_1.w));
					  gl_FragData[0] = tmpvar_5;
					}
					
					
					#endif"
				}
				SubProgram "gles3 hw_tier00 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 _ProjectionParams;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					in highp vec4 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec2 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					out highp vec4 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    gl_Position = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat2 = u_xlat0.y * hlslcc_mtx4x4unity_MatrixV[1].z;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[0].z * u_xlat0.x + u_xlat2;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[2].z * u_xlat0.z + u_xlat0.x;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[3].z * u_xlat0.w + u_xlat0.x;
					    vs_TEXCOORD1.z = (-u_xlat0.x);
					    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
					    u_xlat0.w = u_xlat0.x * 0.5;
					    u_xlat0.xz = u_xlat1.xw * vec2(0.5, 0.5);
					    vs_TEXCOORD1.w = u_xlat1.w;
					    vs_TEXCOORD1.xy = u_xlat0.zz + u_xlat0.xw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _ZBufferParams;
					uniform 	mediump vec4 _TintColor;
					uniform 	float _InvFade;
					uniform highp sampler2D _CameraDepthTexture;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in highp vec4 vs_TEXCOORD1;
					layout(location = 0) out mediump vec4 SV_Target0;
					vec2 u_xlat0;
					mediump vec4 u_xlat16_0;
					mediump vec4 u_xlat16_1;
					lowp vec4 u_xlat10_2;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD1.xy / vs_TEXCOORD1.ww;
					    u_xlat0.x = texture(_CameraDepthTexture, u_xlat0.xy).x;
					    u_xlat0.x = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
					    u_xlat0.x = float(1.0) / u_xlat0.x;
					    u_xlat0.x = u_xlat0.x + (-vs_TEXCOORD1.z);
					    u_xlat0.x = u_xlat0.x * _InvFade;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0.x = min(max(u_xlat0.x, 0.0), 1.0);
					#else
					    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
					#endif
					    u_xlat0.x = u_xlat0.x * vs_COLOR0.w;
					    u_xlat16_1.w = u_xlat0.x * _TintColor.w;
					    u_xlat16_1.xyz = vs_COLOR0.xyz * _TintColor.xyz;
					    u_xlat16_1 = u_xlat16_1 + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat10_2 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat0.xxxx * u_xlat10_2;
					    SV_Target0 = u_xlat16_0 * u_xlat16_1 + vec4(1.0, 1.0, 1.0, 1.0);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier01 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 _ProjectionParams;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					in highp vec4 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec2 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					out highp vec4 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    gl_Position = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat2 = u_xlat0.y * hlslcc_mtx4x4unity_MatrixV[1].z;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[0].z * u_xlat0.x + u_xlat2;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[2].z * u_xlat0.z + u_xlat0.x;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[3].z * u_xlat0.w + u_xlat0.x;
					    vs_TEXCOORD1.z = (-u_xlat0.x);
					    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
					    u_xlat0.w = u_xlat0.x * 0.5;
					    u_xlat0.xz = u_xlat1.xw * vec2(0.5, 0.5);
					    vs_TEXCOORD1.w = u_xlat1.w;
					    vs_TEXCOORD1.xy = u_xlat0.zz + u_xlat0.xw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _ZBufferParams;
					uniform 	mediump vec4 _TintColor;
					uniform 	float _InvFade;
					uniform highp sampler2D _CameraDepthTexture;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in highp vec4 vs_TEXCOORD1;
					layout(location = 0) out mediump vec4 SV_Target0;
					vec2 u_xlat0;
					mediump vec4 u_xlat16_0;
					mediump vec4 u_xlat16_1;
					lowp vec4 u_xlat10_2;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD1.xy / vs_TEXCOORD1.ww;
					    u_xlat0.x = texture(_CameraDepthTexture, u_xlat0.xy).x;
					    u_xlat0.x = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
					    u_xlat0.x = float(1.0) / u_xlat0.x;
					    u_xlat0.x = u_xlat0.x + (-vs_TEXCOORD1.z);
					    u_xlat0.x = u_xlat0.x * _InvFade;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0.x = min(max(u_xlat0.x, 0.0), 1.0);
					#else
					    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
					#endif
					    u_xlat0.x = u_xlat0.x * vs_COLOR0.w;
					    u_xlat16_1.w = u_xlat0.x * _TintColor.w;
					    u_xlat16_1.xyz = vs_COLOR0.xyz * _TintColor.xyz;
					    u_xlat16_1 = u_xlat16_1 + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat10_2 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat0.xxxx * u_xlat10_2;
					    SV_Target0 = u_xlat16_0 * u_xlat16_1 + vec4(1.0, 1.0, 1.0, 1.0);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles3 hw_tier02 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES3
					#ifdef VERTEX
					#version 300 es
					
					uniform 	vec4 _ProjectionParams;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixV[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					in highp vec4 in_POSITION0;
					in mediump vec4 in_COLOR0;
					in highp vec2 in_TEXCOORD0;
					out mediump vec4 vs_COLOR0;
					out highp vec2 vs_TEXCOORD0;
					out highp vec4 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    gl_Position = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat2 = u_xlat0.y * hlslcc_mtx4x4unity_MatrixV[1].z;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[0].z * u_xlat0.x + u_xlat2;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[2].z * u_xlat0.z + u_xlat0.x;
					    u_xlat0.x = hlslcc_mtx4x4unity_MatrixV[3].z * u_xlat0.w + u_xlat0.x;
					    vs_TEXCOORD1.z = (-u_xlat0.x);
					    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
					    u_xlat0.w = u_xlat0.x * 0.5;
					    u_xlat0.xz = u_xlat1.xw * vec2(0.5, 0.5);
					    vs_TEXCOORD1.w = u_xlat1.w;
					    vs_TEXCOORD1.xy = u_xlat0.zz + u_xlat0.xw;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 300 es
					
					precision highp int;
					uniform 	vec4 _ZBufferParams;
					uniform 	mediump vec4 _TintColor;
					uniform 	float _InvFade;
					uniform highp sampler2D _CameraDepthTexture;
					uniform lowp sampler2D _MainTex;
					in mediump vec4 vs_COLOR0;
					in highp vec2 vs_TEXCOORD0;
					in highp vec4 vs_TEXCOORD1;
					layout(location = 0) out mediump vec4 SV_Target0;
					vec2 u_xlat0;
					mediump vec4 u_xlat16_0;
					mediump vec4 u_xlat16_1;
					lowp vec4 u_xlat10_2;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD1.xy / vs_TEXCOORD1.ww;
					    u_xlat0.x = texture(_CameraDepthTexture, u_xlat0.xy).x;
					    u_xlat0.x = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
					    u_xlat0.x = float(1.0) / u_xlat0.x;
					    u_xlat0.x = u_xlat0.x + (-vs_TEXCOORD1.z);
					    u_xlat0.x = u_xlat0.x * _InvFade;
					#ifdef UNITY_ADRENO_ES3
					    u_xlat0.x = min(max(u_xlat0.x, 0.0), 1.0);
					#else
					    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
					#endif
					    u_xlat0.x = u_xlat0.x * vs_COLOR0.w;
					    u_xlat16_1.w = u_xlat0.x * _TintColor.w;
					    u_xlat16_1.xyz = vs_COLOR0.xyz * _TintColor.xyz;
					    u_xlat16_1 = u_xlat16_1 + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat10_2 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat0.xxxx * u_xlat10_2;
					    SV_Target0 = u_xlat16_0 * u_xlat16_1 + vec4(1.0, 1.0, 1.0, 1.0);
					    return;
					}
					
					#endif"
				}
				SubProgram "vulkan hw_tier00 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 177
					; Schema: 0
					                                                      OpCapability Shader 
					                                               %1 = OpExtInstImport "GLSL.std.450" 
					                                                      OpMemoryModel Logical GLSL450 
					                                                      OpEntryPoint Vertex %4 "main" %11 %80 %84 %85 %89 %91 %139 
					                                                      OpDecorate %11 Location 11 
					                                                      OpDecorate %16 ArrayStride 16 
					                                                      OpDecorate %17 ArrayStride 17 
					                                                      OpDecorate %18 ArrayStride 18 
					                                                      OpMemberDecorate %19 0 Offset 19 
					                                                      OpMemberDecorate %19 1 Offset 19 
					                                                      OpMemberDecorate %19 2 Offset 19 
					                                                      OpMemberDecorate %19 3 Offset 19 
					                                                      OpMemberDecorate %19 4 Offset 19 
					                                                      OpDecorate %19 Block 
					                                                      OpDecorate %21 DescriptorSet 21 
					                                                      OpDecorate %21 Binding 21 
					                                                      OpMemberDecorate %78 0 BuiltIn 78 
					                                                      OpMemberDecorate %78 1 BuiltIn 78 
					                                                      OpMemberDecorate %78 2 BuiltIn 78 
					                                                      OpDecorate %78 Block 
					                                                      OpDecorate %84 RelaxedPrecision 
					                                                      OpDecorate %84 Location 84 
					                                                      OpDecorate %85 RelaxedPrecision 
					                                                      OpDecorate %85 Location 85 
					                                                      OpDecorate %86 RelaxedPrecision 
					                                                      OpDecorate %89 Location 89 
					                                                      OpDecorate %91 Location 91 
					                                                      OpDecorate %139 Location 139 
					                                               %2 = OpTypeVoid 
					                                               %3 = OpTypeFunction %2 
					                                               %6 = OpTypeFloat 32 
					                                               %7 = OpTypeVector %6 4 
					                                               %8 = OpTypePointer Private %7 
					                                Private f32_4* %9 = OpVariable Private 
					                                              %10 = OpTypePointer Input %7 
					                                 Input f32_4* %11 = OpVariable Input 
					                                              %14 = OpTypeInt 32 0 
					                                          u32 %15 = OpConstant 4 
					                                              %16 = OpTypeArray %7 %15 
					                                              %17 = OpTypeArray %7 %15 
					                                              %18 = OpTypeArray %7 %15 
					                                              %19 = OpTypeStruct %7 %16 %17 %18 %7 
					                                              %20 = OpTypePointer Uniform %19 
					Uniform struct {f32_4; f32_4[4]; f32_4[4]; f32_4[4]; f32_4;}* %21 = OpVariable Uniform 
					                                              %22 = OpTypeInt 32 1 
					                                          i32 %23 = OpConstant 1 
					                                              %24 = OpTypePointer Uniform %7 
					                                          i32 %28 = OpConstant 0 
					                                          i32 %36 = OpConstant 2 
					                                          i32 %45 = OpConstant 3 
					                               Private f32_4* %49 = OpVariable Private 
					                                          u32 %76 = OpConstant 1 
					                                              %77 = OpTypeArray %6 %76 
					                                              %78 = OpTypeStruct %7 %6 %77 
					                                              %79 = OpTypePointer Output %78 
					         Output struct {f32_4; f32; f32[1];}* %80 = OpVariable Output 
					                                              %82 = OpTypePointer Output %7 
					                                Output f32_4* %84 = OpVariable Output 
					                                 Input f32_4* %85 = OpVariable Input 
					                                              %87 = OpTypeVector %6 2 
					                                              %88 = OpTypePointer Output %87 
					                                Output f32_2* %89 = OpVariable Output 
					                                              %90 = OpTypePointer Input %87 
					                                 Input f32_2* %91 = OpVariable Input 
					                                          i32 %93 = OpConstant 4 
					                                             %102 = OpTypePointer Private %6 
					                                Private f32* %103 = OpVariable Private 
					                                         u32 %106 = OpConstant 2 
					                                             %107 = OpTypePointer Uniform %6 
					                                         u32 %113 = OpConstant 0 
					                                         u32 %131 = OpConstant 3 
					                               Output f32_4* %139 = OpVariable Output 
					                                             %143 = OpTypePointer Output %6 
					                                         f32 %153 = OpConstant 3.674022E-40 
					                                       f32_2 %158 = OpConstantComposite %153 %153 
					                                          void %4 = OpFunction None %3 
					                                               %5 = OpLabel 
					                                        f32_4 %12 = OpLoad %11 
					                                        f32_4 %13 = OpVectorShuffle %12 %12 1 1 1 1 
					                               Uniform f32_4* %25 = OpAccessChain %21 %23 %23 
					                                        f32_4 %26 = OpLoad %25 
					                                        f32_4 %27 = OpFMul %13 %26 
					                                                      OpStore %9 %27 
					                               Uniform f32_4* %29 = OpAccessChain %21 %23 %28 
					                                        f32_4 %30 = OpLoad %29 
					                                        f32_4 %31 = OpLoad %11 
					                                        f32_4 %32 = OpVectorShuffle %31 %31 0 0 0 0 
					                                        f32_4 %33 = OpFMul %30 %32 
					                                        f32_4 %34 = OpLoad %9 
					                                        f32_4 %35 = OpFAdd %33 %34 
					                                                      OpStore %9 %35 
					                               Uniform f32_4* %37 = OpAccessChain %21 %23 %36 
					                                        f32_4 %38 = OpLoad %37 
					                                        f32_4 %39 = OpLoad %11 
					                                        f32_4 %40 = OpVectorShuffle %39 %39 2 2 2 2 
					                                        f32_4 %41 = OpFMul %38 %40 
					                                        f32_4 %42 = OpLoad %9 
					                                        f32_4 %43 = OpFAdd %41 %42 
					                                                      OpStore %9 %43 
					                                        f32_4 %44 = OpLoad %9 
					                               Uniform f32_4* %46 = OpAccessChain %21 %23 %45 
					                                        f32_4 %47 = OpLoad %46 
					                                        f32_4 %48 = OpFAdd %44 %47 
					                                                      OpStore %9 %48 
					                                        f32_4 %50 = OpLoad %9 
					                                        f32_4 %51 = OpVectorShuffle %50 %50 1 1 1 1 
					                               Uniform f32_4* %52 = OpAccessChain %21 %45 %23 
					                                        f32_4 %53 = OpLoad %52 
					                                        f32_4 %54 = OpFMul %51 %53 
					                                                      OpStore %49 %54 
					                               Uniform f32_4* %55 = OpAccessChain %21 %45 %28 
					                                        f32_4 %56 = OpLoad %55 
					                                        f32_4 %57 = OpLoad %9 
					                                        f32_4 %58 = OpVectorShuffle %57 %57 0 0 0 0 
					                                        f32_4 %59 = OpFMul %56 %58 
					                                        f32_4 %60 = OpLoad %49 
					                                        f32_4 %61 = OpFAdd %59 %60 
					                                                      OpStore %49 %61 
					                               Uniform f32_4* %62 = OpAccessChain %21 %45 %36 
					                                        f32_4 %63 = OpLoad %62 
					                                        f32_4 %64 = OpLoad %9 
					                                        f32_4 %65 = OpVectorShuffle %64 %64 2 2 2 2 
					                                        f32_4 %66 = OpFMul %63 %65 
					                                        f32_4 %67 = OpLoad %49 
					                                        f32_4 %68 = OpFAdd %66 %67 
					                                                      OpStore %49 %68 
					                               Uniform f32_4* %69 = OpAccessChain %21 %45 %45 
					                                        f32_4 %70 = OpLoad %69 
					                                        f32_4 %71 = OpLoad %9 
					                                        f32_4 %72 = OpVectorShuffle %71 %71 3 3 3 3 
					                                        f32_4 %73 = OpFMul %70 %72 
					                                        f32_4 %74 = OpLoad %49 
					                                        f32_4 %75 = OpFAdd %73 %74 
					                                                      OpStore %49 %75 
					                                        f32_4 %81 = OpLoad %49 
					                                Output f32_4* %83 = OpAccessChain %80 %28 
					                                                      OpStore %83 %81 
					                                        f32_4 %86 = OpLoad %85 
					                                                      OpStore %84 %86 
					                                        f32_2 %92 = OpLoad %91 
					                               Uniform f32_4* %94 = OpAccessChain %21 %93 
					                                        f32_4 %95 = OpLoad %94 
					                                        f32_2 %96 = OpVectorShuffle %95 %95 0 1 
					                                        f32_2 %97 = OpFMul %92 %96 
					                               Uniform f32_4* %98 = OpAccessChain %21 %93 
					                                        f32_4 %99 = OpLoad %98 
					                                       f32_2 %100 = OpVectorShuffle %99 %99 2 3 
					                                       f32_2 %101 = OpFAdd %97 %100 
					                                                      OpStore %89 %101 
					                                Private f32* %104 = OpAccessChain %9 %76 
					                                         f32 %105 = OpLoad %104 
					                                Uniform f32* %108 = OpAccessChain %21 %36 %23 %106 
					                                         f32 %109 = OpLoad %108 
					                                         f32 %110 = OpFMul %105 %109 
					                                                      OpStore %103 %110 
					                                Uniform f32* %111 = OpAccessChain %21 %36 %28 %106 
					                                         f32 %112 = OpLoad %111 
					                                Private f32* %114 = OpAccessChain %9 %113 
					                                         f32 %115 = OpLoad %114 
					                                         f32 %116 = OpFMul %112 %115 
					                                         f32 %117 = OpLoad %103 
					                                         f32 %118 = OpFAdd %116 %117 
					                                Private f32* %119 = OpAccessChain %9 %113 
					                                                      OpStore %119 %118 
					                                Uniform f32* %120 = OpAccessChain %21 %36 %36 %106 
					                                         f32 %121 = OpLoad %120 
					                                Private f32* %122 = OpAccessChain %9 %106 
					                                         f32 %123 = OpLoad %122 
					                                         f32 %124 = OpFMul %121 %123 
					                                Private f32* %125 = OpAccessChain %9 %113 
					                                         f32 %126 = OpLoad %125 
					                                         f32 %127 = OpFAdd %124 %126 
					                                Private f32* %128 = OpAccessChain %9 %113 
					                                                      OpStore %128 %127 
					                                Uniform f32* %129 = OpAccessChain %21 %36 %45 %106 
					                                         f32 %130 = OpLoad %129 
					                                Private f32* %132 = OpAccessChain %9 %131 
					                                         f32 %133 = OpLoad %132 
					                                         f32 %134 = OpFMul %130 %133 
					                                Private f32* %135 = OpAccessChain %9 %113 
					                                         f32 %136 = OpLoad %135 
					                                         f32 %137 = OpFAdd %134 %136 
					                                Private f32* %138 = OpAccessChain %9 %113 
					                                                      OpStore %138 %137 
					                                Private f32* %140 = OpAccessChain %9 %113 
					                                         f32 %141 = OpLoad %140 
					                                         f32 %142 = OpFNegate %141 
					                                 Output f32* %144 = OpAccessChain %139 %106 
					                                                      OpStore %144 %142 
					                                Private f32* %145 = OpAccessChain %49 %76 
					                                         f32 %146 = OpLoad %145 
					                                Uniform f32* %147 = OpAccessChain %21 %28 %113 
					                                         f32 %148 = OpLoad %147 
					                                         f32 %149 = OpFMul %146 %148 
					                                Private f32* %150 = OpAccessChain %9 %113 
					                                                      OpStore %150 %149 
					                                Private f32* %151 = OpAccessChain %9 %113 
					                                         f32 %152 = OpLoad %151 
					                                         f32 %154 = OpFMul %152 %153 
					                                Private f32* %155 = OpAccessChain %9 %131 
					                                                      OpStore %155 %154 
					                                       f32_4 %156 = OpLoad %49 
					                                       f32_2 %157 = OpVectorShuffle %156 %156 0 3 
					                                       f32_2 %159 = OpFMul %157 %158 
					                                       f32_4 %160 = OpLoad %9 
					                                       f32_4 %161 = OpVectorShuffle %160 %159 4 1 5 3 
					                                                      OpStore %9 %161 
					                                Private f32* %162 = OpAccessChain %49 %131 
					                                         f32 %163 = OpLoad %162 
					                                 Output f32* %164 = OpAccessChain %139 %131 
					                                                      OpStore %164 %163 
					                                       f32_4 %165 = OpLoad %9 
					                                       f32_2 %166 = OpVectorShuffle %165 %165 2 2 
					                                       f32_4 %167 = OpLoad %9 
					                                       f32_2 %168 = OpVectorShuffle %167 %167 0 3 
					                                       f32_2 %169 = OpFAdd %166 %168 
					                                       f32_4 %170 = OpLoad %139 
					                                       f32_4 %171 = OpVectorShuffle %170 %169 4 5 2 3 
					                                                      OpStore %139 %171 
					                                 Output f32* %172 = OpAccessChain %80 %28 %76 
					                                         f32 %173 = OpLoad %172 
					                                         f32 %174 = OpFNegate %173 
					                                 Output f32* %175 = OpAccessChain %80 %28 %76 
					                                                      OpStore %175 %174 
					                                                      OpReturn
					                                                      OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 122
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Fragment %4 "main" %12 %74 %106 %115 
					                                                     OpExecutionMode %4 OriginUpperLeft 
					                                                     OpDecorate %12 Location 12 
					                                                     OpDecorate %21 DescriptorSet 21 
					                                                     OpDecorate %21 Binding 21 
					                                                     OpMemberDecorate %30 0 Offset 30 
					                                                     OpMemberDecorate %30 1 RelaxedPrecision 
					                                                     OpMemberDecorate %30 1 Offset 30 
					                                                     OpMemberDecorate %30 2 Offset 30 
					                                                     OpDecorate %30 Block 
					                                                     OpDecorate %32 DescriptorSet 32 
					                                                     OpDecorate %32 Binding 32 
					                                                     OpDecorate %74 RelaxedPrecision 
					                                                     OpDecorate %74 Location 74 
					                                                     OpDecorate %76 RelaxedPrecision 
					                                                     OpDecorate %80 RelaxedPrecision 
					                                                     OpDecorate %85 RelaxedPrecision 
					                                                     OpDecorate %89 RelaxedPrecision 
					                                                     OpDecorate %90 RelaxedPrecision 
					                                                     OpDecorate %93 RelaxedPrecision 
					                                                     OpDecorate %94 RelaxedPrecision 
					                                                     OpDecorate %95 RelaxedPrecision 
					                                                     OpDecorate %98 RelaxedPrecision 
					                                                     OpDecorate %101 RelaxedPrecision 
					                                                     OpDecorate %102 RelaxedPrecision 
					                                                     OpDecorate %103 RelaxedPrecision 
					                                                     OpDecorate %103 DescriptorSet 103 
					                                                     OpDecorate %103 Binding 103 
					                                                     OpDecorate %104 RelaxedPrecision 
					                                                     OpDecorate %106 Location 106 
					                                                     OpDecorate %109 RelaxedPrecision 
					                                                     OpDecorate %112 RelaxedPrecision 
					                                                     OpDecorate %115 RelaxedPrecision 
					                                                     OpDecorate %115 Location 115 
					                                                     OpDecorate %116 RelaxedPrecision 
					                                                     OpDecorate %117 RelaxedPrecision 
					                                                     OpDecorate %118 RelaxedPrecision 
					                                                     OpDecorate %120 RelaxedPrecision 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 2 
					                                              %8 = OpTypePointer Private %7 
					                               Private f32_2* %9 = OpVariable Private 
					                                             %10 = OpTypeVector %6 4 
					                                             %11 = OpTypePointer Input %10 
					                                Input f32_4* %12 = OpVariable Input 
					                                             %18 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                             %19 = OpTypeSampledImage %18 
					                                             %20 = OpTypePointer UniformConstant %19 
					 UniformConstant read_only Texture2DSampled* %21 = OpVariable UniformConstant 
					                                             %25 = OpTypeInt 32 0 
					                                         u32 %26 = OpConstant 0 
					                                             %28 = OpTypePointer Private %6 
					                                             %30 = OpTypeStruct %10 %10 %6 
					                                             %31 = OpTypePointer Uniform %30 
					        Uniform struct {f32_4; f32_4; f32;}* %32 = OpVariable Uniform 
					                                             %33 = OpTypeInt 32 1 
					                                         i32 %34 = OpConstant 0 
					                                         u32 %35 = OpConstant 2 
					                                             %36 = OpTypePointer Uniform %6 
					                                         u32 %42 = OpConstant 3 
					                                         f32 %47 = OpConstant 3.674022E-40 
					                                             %54 = OpTypePointer Input %6 
					                                         i32 %62 = OpConstant 2 
					                                         f32 %69 = OpConstant 3.674022E-40 
					                                Input f32_4* %74 = OpVariable Input 
					                                             %79 = OpTypePointer Private %10 
					                              Private f32_4* %80 = OpVariable Private 
					                                         i32 %83 = OpConstant 1 
					                                             %88 = OpTypeVector %6 3 
					                                             %91 = OpTypePointer Uniform %10 
					                                         f32 %99 = OpConstant 3.674022E-40 
					                                      f32_4 %100 = OpConstantComposite %99 %99 %99 %99 
					                             Private f32_4* %102 = OpVariable Private 
					UniformConstant read_only Texture2DSampled* %103 = OpVariable UniformConstant 
					                                            %105 = OpTypePointer Input %7 
					                               Input f32_2* %106 = OpVariable Input 
					                             Private f32_4* %109 = OpVariable Private 
					                                            %114 = OpTypePointer Output %10 
					                              Output f32_4* %115 = OpVariable Output 
					                                      f32_4 %119 = OpConstantComposite %47 %47 %47 %47 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %13 = OpLoad %12 
					                                       f32_2 %14 = OpVectorShuffle %13 %13 0 1 
					                                       f32_4 %15 = OpLoad %12 
					                                       f32_2 %16 = OpVectorShuffle %15 %15 3 3 
					                                       f32_2 %17 = OpFDiv %14 %16 
					                                                     OpStore %9 %17 
					                  read_only Texture2DSampled %22 = OpLoad %21 
					                                       f32_2 %23 = OpLoad %9 
					                                       f32_4 %24 = OpImageSampleImplicitLod %22 %23 
					                                         f32 %27 = OpCompositeExtract %24 0 
					                                Private f32* %29 = OpAccessChain %9 %26 
					                                                     OpStore %29 %27 
					                                Uniform f32* %37 = OpAccessChain %32 %34 %35 
					                                         f32 %38 = OpLoad %37 
					                                Private f32* %39 = OpAccessChain %9 %26 
					                                         f32 %40 = OpLoad %39 
					                                         f32 %41 = OpFMul %38 %40 
					                                Uniform f32* %43 = OpAccessChain %32 %34 %42 
					                                         f32 %44 = OpLoad %43 
					                                         f32 %45 = OpFAdd %41 %44 
					                                Private f32* %46 = OpAccessChain %9 %26 
					                                                     OpStore %46 %45 
					                                Private f32* %48 = OpAccessChain %9 %26 
					                                         f32 %49 = OpLoad %48 
					                                         f32 %50 = OpFDiv %47 %49 
					                                Private f32* %51 = OpAccessChain %9 %26 
					                                                     OpStore %51 %50 
					                                Private f32* %52 = OpAccessChain %9 %26 
					                                         f32 %53 = OpLoad %52 
					                                  Input f32* %55 = OpAccessChain %12 %35 
					                                         f32 %56 = OpLoad %55 
					                                         f32 %57 = OpFNegate %56 
					                                         f32 %58 = OpFAdd %53 %57 
					                                Private f32* %59 = OpAccessChain %9 %26 
					                                                     OpStore %59 %58 
					                                Private f32* %60 = OpAccessChain %9 %26 
					                                         f32 %61 = OpLoad %60 
					                                Uniform f32* %63 = OpAccessChain %32 %62 
					                                         f32 %64 = OpLoad %63 
					                                         f32 %65 = OpFMul %61 %64 
					                                Private f32* %66 = OpAccessChain %9 %26 
					                                                     OpStore %66 %65 
					                                Private f32* %67 = OpAccessChain %9 %26 
					                                         f32 %68 = OpLoad %67 
					                                         f32 %70 = OpExtInst %1 43 %68 %69 %47 
					                                Private f32* %71 = OpAccessChain %9 %26 
					                                                     OpStore %71 %70 
					                                Private f32* %72 = OpAccessChain %9 %26 
					                                         f32 %73 = OpLoad %72 
					                                  Input f32* %75 = OpAccessChain %74 %42 
					                                         f32 %76 = OpLoad %75 
					                                         f32 %77 = OpFMul %73 %76 
					                                Private f32* %78 = OpAccessChain %9 %26 
					                                                     OpStore %78 %77 
					                                Private f32* %81 = OpAccessChain %9 %26 
					                                         f32 %82 = OpLoad %81 
					                                Uniform f32* %84 = OpAccessChain %32 %83 %42 
					                                         f32 %85 = OpLoad %84 
					                                         f32 %86 = OpFMul %82 %85 
					                                Private f32* %87 = OpAccessChain %80 %42 
					                                                     OpStore %87 %86 
					                                       f32_4 %89 = OpLoad %74 
					                                       f32_3 %90 = OpVectorShuffle %89 %89 0 1 2 
					                              Uniform f32_4* %92 = OpAccessChain %32 %83 
					                                       f32_4 %93 = OpLoad %92 
					                                       f32_3 %94 = OpVectorShuffle %93 %93 0 1 2 
					                                       f32_3 %95 = OpFMul %90 %94 
					                                       f32_4 %96 = OpLoad %80 
					                                       f32_4 %97 = OpVectorShuffle %96 %95 4 5 6 3 
					                                                     OpStore %80 %97 
					                                       f32_4 %98 = OpLoad %80 
					                                      f32_4 %101 = OpFAdd %98 %100 
					                                                     OpStore %80 %101 
					                 read_only Texture2DSampled %104 = OpLoad %103 
					                                      f32_2 %107 = OpLoad %106 
					                                      f32_4 %108 = OpImageSampleImplicitLod %104 %107 
					                                                     OpStore %102 %108 
					                                      f32_2 %110 = OpLoad %9 
					                                      f32_4 %111 = OpVectorShuffle %110 %110 0 0 0 0 
					                                      f32_4 %112 = OpLoad %102 
					                                      f32_4 %113 = OpFMul %111 %112 
					                                                     OpStore %109 %113 
					                                      f32_4 %116 = OpLoad %109 
					                                      f32_4 %117 = OpLoad %80 
					                                      f32_4 %118 = OpFMul %116 %117 
					                                      f32_4 %120 = OpFAdd %118 %119 
					                                                     OpStore %115 %120 
					                                                     OpReturn
					                                                     OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier01 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 177
					; Schema: 0
					                                                      OpCapability Shader 
					                                               %1 = OpExtInstImport "GLSL.std.450" 
					                                                      OpMemoryModel Logical GLSL450 
					                                                      OpEntryPoint Vertex %4 "main" %11 %80 %84 %85 %89 %91 %139 
					                                                      OpDecorate %11 Location 11 
					                                                      OpDecorate %16 ArrayStride 16 
					                                                      OpDecorate %17 ArrayStride 17 
					                                                      OpDecorate %18 ArrayStride 18 
					                                                      OpMemberDecorate %19 0 Offset 19 
					                                                      OpMemberDecorate %19 1 Offset 19 
					                                                      OpMemberDecorate %19 2 Offset 19 
					                                                      OpMemberDecorate %19 3 Offset 19 
					                                                      OpMemberDecorate %19 4 Offset 19 
					                                                      OpDecorate %19 Block 
					                                                      OpDecorate %21 DescriptorSet 21 
					                                                      OpDecorate %21 Binding 21 
					                                                      OpMemberDecorate %78 0 BuiltIn 78 
					                                                      OpMemberDecorate %78 1 BuiltIn 78 
					                                                      OpMemberDecorate %78 2 BuiltIn 78 
					                                                      OpDecorate %78 Block 
					                                                      OpDecorate %84 RelaxedPrecision 
					                                                      OpDecorate %84 Location 84 
					                                                      OpDecorate %85 RelaxedPrecision 
					                                                      OpDecorate %85 Location 85 
					                                                      OpDecorate %86 RelaxedPrecision 
					                                                      OpDecorate %89 Location 89 
					                                                      OpDecorate %91 Location 91 
					                                                      OpDecorate %139 Location 139 
					                                               %2 = OpTypeVoid 
					                                               %3 = OpTypeFunction %2 
					                                               %6 = OpTypeFloat 32 
					                                               %7 = OpTypeVector %6 4 
					                                               %8 = OpTypePointer Private %7 
					                                Private f32_4* %9 = OpVariable Private 
					                                              %10 = OpTypePointer Input %7 
					                                 Input f32_4* %11 = OpVariable Input 
					                                              %14 = OpTypeInt 32 0 
					                                          u32 %15 = OpConstant 4 
					                                              %16 = OpTypeArray %7 %15 
					                                              %17 = OpTypeArray %7 %15 
					                                              %18 = OpTypeArray %7 %15 
					                                              %19 = OpTypeStruct %7 %16 %17 %18 %7 
					                                              %20 = OpTypePointer Uniform %19 
					Uniform struct {f32_4; f32_4[4]; f32_4[4]; f32_4[4]; f32_4;}* %21 = OpVariable Uniform 
					                                              %22 = OpTypeInt 32 1 
					                                          i32 %23 = OpConstant 1 
					                                              %24 = OpTypePointer Uniform %7 
					                                          i32 %28 = OpConstant 0 
					                                          i32 %36 = OpConstant 2 
					                                          i32 %45 = OpConstant 3 
					                               Private f32_4* %49 = OpVariable Private 
					                                          u32 %76 = OpConstant 1 
					                                              %77 = OpTypeArray %6 %76 
					                                              %78 = OpTypeStruct %7 %6 %77 
					                                              %79 = OpTypePointer Output %78 
					         Output struct {f32_4; f32; f32[1];}* %80 = OpVariable Output 
					                                              %82 = OpTypePointer Output %7 
					                                Output f32_4* %84 = OpVariable Output 
					                                 Input f32_4* %85 = OpVariable Input 
					                                              %87 = OpTypeVector %6 2 
					                                              %88 = OpTypePointer Output %87 
					                                Output f32_2* %89 = OpVariable Output 
					                                              %90 = OpTypePointer Input %87 
					                                 Input f32_2* %91 = OpVariable Input 
					                                          i32 %93 = OpConstant 4 
					                                             %102 = OpTypePointer Private %6 
					                                Private f32* %103 = OpVariable Private 
					                                         u32 %106 = OpConstant 2 
					                                             %107 = OpTypePointer Uniform %6 
					                                         u32 %113 = OpConstant 0 
					                                         u32 %131 = OpConstant 3 
					                               Output f32_4* %139 = OpVariable Output 
					                                             %143 = OpTypePointer Output %6 
					                                         f32 %153 = OpConstant 3.674022E-40 
					                                       f32_2 %158 = OpConstantComposite %153 %153 
					                                          void %4 = OpFunction None %3 
					                                               %5 = OpLabel 
					                                        f32_4 %12 = OpLoad %11 
					                                        f32_4 %13 = OpVectorShuffle %12 %12 1 1 1 1 
					                               Uniform f32_4* %25 = OpAccessChain %21 %23 %23 
					                                        f32_4 %26 = OpLoad %25 
					                                        f32_4 %27 = OpFMul %13 %26 
					                                                      OpStore %9 %27 
					                               Uniform f32_4* %29 = OpAccessChain %21 %23 %28 
					                                        f32_4 %30 = OpLoad %29 
					                                        f32_4 %31 = OpLoad %11 
					                                        f32_4 %32 = OpVectorShuffle %31 %31 0 0 0 0 
					                                        f32_4 %33 = OpFMul %30 %32 
					                                        f32_4 %34 = OpLoad %9 
					                                        f32_4 %35 = OpFAdd %33 %34 
					                                                      OpStore %9 %35 
					                               Uniform f32_4* %37 = OpAccessChain %21 %23 %36 
					                                        f32_4 %38 = OpLoad %37 
					                                        f32_4 %39 = OpLoad %11 
					                                        f32_4 %40 = OpVectorShuffle %39 %39 2 2 2 2 
					                                        f32_4 %41 = OpFMul %38 %40 
					                                        f32_4 %42 = OpLoad %9 
					                                        f32_4 %43 = OpFAdd %41 %42 
					                                                      OpStore %9 %43 
					                                        f32_4 %44 = OpLoad %9 
					                               Uniform f32_4* %46 = OpAccessChain %21 %23 %45 
					                                        f32_4 %47 = OpLoad %46 
					                                        f32_4 %48 = OpFAdd %44 %47 
					                                                      OpStore %9 %48 
					                                        f32_4 %50 = OpLoad %9 
					                                        f32_4 %51 = OpVectorShuffle %50 %50 1 1 1 1 
					                               Uniform f32_4* %52 = OpAccessChain %21 %45 %23 
					                                        f32_4 %53 = OpLoad %52 
					                                        f32_4 %54 = OpFMul %51 %53 
					                                                      OpStore %49 %54 
					                               Uniform f32_4* %55 = OpAccessChain %21 %45 %28 
					                                        f32_4 %56 = OpLoad %55 
					                                        f32_4 %57 = OpLoad %9 
					                                        f32_4 %58 = OpVectorShuffle %57 %57 0 0 0 0 
					                                        f32_4 %59 = OpFMul %56 %58 
					                                        f32_4 %60 = OpLoad %49 
					                                        f32_4 %61 = OpFAdd %59 %60 
					                                                      OpStore %49 %61 
					                               Uniform f32_4* %62 = OpAccessChain %21 %45 %36 
					                                        f32_4 %63 = OpLoad %62 
					                                        f32_4 %64 = OpLoad %9 
					                                        f32_4 %65 = OpVectorShuffle %64 %64 2 2 2 2 
					                                        f32_4 %66 = OpFMul %63 %65 
					                                        f32_4 %67 = OpLoad %49 
					                                        f32_4 %68 = OpFAdd %66 %67 
					                                                      OpStore %49 %68 
					                               Uniform f32_4* %69 = OpAccessChain %21 %45 %45 
					                                        f32_4 %70 = OpLoad %69 
					                                        f32_4 %71 = OpLoad %9 
					                                        f32_4 %72 = OpVectorShuffle %71 %71 3 3 3 3 
					                                        f32_4 %73 = OpFMul %70 %72 
					                                        f32_4 %74 = OpLoad %49 
					                                        f32_4 %75 = OpFAdd %73 %74 
					                                                      OpStore %49 %75 
					                                        f32_4 %81 = OpLoad %49 
					                                Output f32_4* %83 = OpAccessChain %80 %28 
					                                                      OpStore %83 %81 
					                                        f32_4 %86 = OpLoad %85 
					                                                      OpStore %84 %86 
					                                        f32_2 %92 = OpLoad %91 
					                               Uniform f32_4* %94 = OpAccessChain %21 %93 
					                                        f32_4 %95 = OpLoad %94 
					                                        f32_2 %96 = OpVectorShuffle %95 %95 0 1 
					                                        f32_2 %97 = OpFMul %92 %96 
					                               Uniform f32_4* %98 = OpAccessChain %21 %93 
					                                        f32_4 %99 = OpLoad %98 
					                                       f32_2 %100 = OpVectorShuffle %99 %99 2 3 
					                                       f32_2 %101 = OpFAdd %97 %100 
					                                                      OpStore %89 %101 
					                                Private f32* %104 = OpAccessChain %9 %76 
					                                         f32 %105 = OpLoad %104 
					                                Uniform f32* %108 = OpAccessChain %21 %36 %23 %106 
					                                         f32 %109 = OpLoad %108 
					                                         f32 %110 = OpFMul %105 %109 
					                                                      OpStore %103 %110 
					                                Uniform f32* %111 = OpAccessChain %21 %36 %28 %106 
					                                         f32 %112 = OpLoad %111 
					                                Private f32* %114 = OpAccessChain %9 %113 
					                                         f32 %115 = OpLoad %114 
					                                         f32 %116 = OpFMul %112 %115 
					                                         f32 %117 = OpLoad %103 
					                                         f32 %118 = OpFAdd %116 %117 
					                                Private f32* %119 = OpAccessChain %9 %113 
					                                                      OpStore %119 %118 
					                                Uniform f32* %120 = OpAccessChain %21 %36 %36 %106 
					                                         f32 %121 = OpLoad %120 
					                                Private f32* %122 = OpAccessChain %9 %106 
					                                         f32 %123 = OpLoad %122 
					                                         f32 %124 = OpFMul %121 %123 
					                                Private f32* %125 = OpAccessChain %9 %113 
					                                         f32 %126 = OpLoad %125 
					                                         f32 %127 = OpFAdd %124 %126 
					                                Private f32* %128 = OpAccessChain %9 %113 
					                                                      OpStore %128 %127 
					                                Uniform f32* %129 = OpAccessChain %21 %36 %45 %106 
					                                         f32 %130 = OpLoad %129 
					                                Private f32* %132 = OpAccessChain %9 %131 
					                                         f32 %133 = OpLoad %132 
					                                         f32 %134 = OpFMul %130 %133 
					                                Private f32* %135 = OpAccessChain %9 %113 
					                                         f32 %136 = OpLoad %135 
					                                         f32 %137 = OpFAdd %134 %136 
					                                Private f32* %138 = OpAccessChain %9 %113 
					                                                      OpStore %138 %137 
					                                Private f32* %140 = OpAccessChain %9 %113 
					                                         f32 %141 = OpLoad %140 
					                                         f32 %142 = OpFNegate %141 
					                                 Output f32* %144 = OpAccessChain %139 %106 
					                                                      OpStore %144 %142 
					                                Private f32* %145 = OpAccessChain %49 %76 
					                                         f32 %146 = OpLoad %145 
					                                Uniform f32* %147 = OpAccessChain %21 %28 %113 
					                                         f32 %148 = OpLoad %147 
					                                         f32 %149 = OpFMul %146 %148 
					                                Private f32* %150 = OpAccessChain %9 %113 
					                                                      OpStore %150 %149 
					                                Private f32* %151 = OpAccessChain %9 %113 
					                                         f32 %152 = OpLoad %151 
					                                         f32 %154 = OpFMul %152 %153 
					                                Private f32* %155 = OpAccessChain %9 %131 
					                                                      OpStore %155 %154 
					                                       f32_4 %156 = OpLoad %49 
					                                       f32_2 %157 = OpVectorShuffle %156 %156 0 3 
					                                       f32_2 %159 = OpFMul %157 %158 
					                                       f32_4 %160 = OpLoad %9 
					                                       f32_4 %161 = OpVectorShuffle %160 %159 4 1 5 3 
					                                                      OpStore %9 %161 
					                                Private f32* %162 = OpAccessChain %49 %131 
					                                         f32 %163 = OpLoad %162 
					                                 Output f32* %164 = OpAccessChain %139 %131 
					                                                      OpStore %164 %163 
					                                       f32_4 %165 = OpLoad %9 
					                                       f32_2 %166 = OpVectorShuffle %165 %165 2 2 
					                                       f32_4 %167 = OpLoad %9 
					                                       f32_2 %168 = OpVectorShuffle %167 %167 0 3 
					                                       f32_2 %169 = OpFAdd %166 %168 
					                                       f32_4 %170 = OpLoad %139 
					                                       f32_4 %171 = OpVectorShuffle %170 %169 4 5 2 3 
					                                                      OpStore %139 %171 
					                                 Output f32* %172 = OpAccessChain %80 %28 %76 
					                                         f32 %173 = OpLoad %172 
					                                         f32 %174 = OpFNegate %173 
					                                 Output f32* %175 = OpAccessChain %80 %28 %76 
					                                                      OpStore %175 %174 
					                                                      OpReturn
					                                                      OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 122
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Fragment %4 "main" %12 %74 %106 %115 
					                                                     OpExecutionMode %4 OriginUpperLeft 
					                                                     OpDecorate %12 Location 12 
					                                                     OpDecorate %21 DescriptorSet 21 
					                                                     OpDecorate %21 Binding 21 
					                                                     OpMemberDecorate %30 0 Offset 30 
					                                                     OpMemberDecorate %30 1 RelaxedPrecision 
					                                                     OpMemberDecorate %30 1 Offset 30 
					                                                     OpMemberDecorate %30 2 Offset 30 
					                                                     OpDecorate %30 Block 
					                                                     OpDecorate %32 DescriptorSet 32 
					                                                     OpDecorate %32 Binding 32 
					                                                     OpDecorate %74 RelaxedPrecision 
					                                                     OpDecorate %74 Location 74 
					                                                     OpDecorate %76 RelaxedPrecision 
					                                                     OpDecorate %80 RelaxedPrecision 
					                                                     OpDecorate %85 RelaxedPrecision 
					                                                     OpDecorate %89 RelaxedPrecision 
					                                                     OpDecorate %90 RelaxedPrecision 
					                                                     OpDecorate %93 RelaxedPrecision 
					                                                     OpDecorate %94 RelaxedPrecision 
					                                                     OpDecorate %95 RelaxedPrecision 
					                                                     OpDecorate %98 RelaxedPrecision 
					                                                     OpDecorate %101 RelaxedPrecision 
					                                                     OpDecorate %102 RelaxedPrecision 
					                                                     OpDecorate %103 RelaxedPrecision 
					                                                     OpDecorate %103 DescriptorSet 103 
					                                                     OpDecorate %103 Binding 103 
					                                                     OpDecorate %104 RelaxedPrecision 
					                                                     OpDecorate %106 Location 106 
					                                                     OpDecorate %109 RelaxedPrecision 
					                                                     OpDecorate %112 RelaxedPrecision 
					                                                     OpDecorate %115 RelaxedPrecision 
					                                                     OpDecorate %115 Location 115 
					                                                     OpDecorate %116 RelaxedPrecision 
					                                                     OpDecorate %117 RelaxedPrecision 
					                                                     OpDecorate %118 RelaxedPrecision 
					                                                     OpDecorate %120 RelaxedPrecision 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 2 
					                                              %8 = OpTypePointer Private %7 
					                               Private f32_2* %9 = OpVariable Private 
					                                             %10 = OpTypeVector %6 4 
					                                             %11 = OpTypePointer Input %10 
					                                Input f32_4* %12 = OpVariable Input 
					                                             %18 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                             %19 = OpTypeSampledImage %18 
					                                             %20 = OpTypePointer UniformConstant %19 
					 UniformConstant read_only Texture2DSampled* %21 = OpVariable UniformConstant 
					                                             %25 = OpTypeInt 32 0 
					                                         u32 %26 = OpConstant 0 
					                                             %28 = OpTypePointer Private %6 
					                                             %30 = OpTypeStruct %10 %10 %6 
					                                             %31 = OpTypePointer Uniform %30 
					        Uniform struct {f32_4; f32_4; f32;}* %32 = OpVariable Uniform 
					                                             %33 = OpTypeInt 32 1 
					                                         i32 %34 = OpConstant 0 
					                                         u32 %35 = OpConstant 2 
					                                             %36 = OpTypePointer Uniform %6 
					                                         u32 %42 = OpConstant 3 
					                                         f32 %47 = OpConstant 3.674022E-40 
					                                             %54 = OpTypePointer Input %6 
					                                         i32 %62 = OpConstant 2 
					                                         f32 %69 = OpConstant 3.674022E-40 
					                                Input f32_4* %74 = OpVariable Input 
					                                             %79 = OpTypePointer Private %10 
					                              Private f32_4* %80 = OpVariable Private 
					                                         i32 %83 = OpConstant 1 
					                                             %88 = OpTypeVector %6 3 
					                                             %91 = OpTypePointer Uniform %10 
					                                         f32 %99 = OpConstant 3.674022E-40 
					                                      f32_4 %100 = OpConstantComposite %99 %99 %99 %99 
					                             Private f32_4* %102 = OpVariable Private 
					UniformConstant read_only Texture2DSampled* %103 = OpVariable UniformConstant 
					                                            %105 = OpTypePointer Input %7 
					                               Input f32_2* %106 = OpVariable Input 
					                             Private f32_4* %109 = OpVariable Private 
					                                            %114 = OpTypePointer Output %10 
					                              Output f32_4* %115 = OpVariable Output 
					                                      f32_4 %119 = OpConstantComposite %47 %47 %47 %47 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %13 = OpLoad %12 
					                                       f32_2 %14 = OpVectorShuffle %13 %13 0 1 
					                                       f32_4 %15 = OpLoad %12 
					                                       f32_2 %16 = OpVectorShuffle %15 %15 3 3 
					                                       f32_2 %17 = OpFDiv %14 %16 
					                                                     OpStore %9 %17 
					                  read_only Texture2DSampled %22 = OpLoad %21 
					                                       f32_2 %23 = OpLoad %9 
					                                       f32_4 %24 = OpImageSampleImplicitLod %22 %23 
					                                         f32 %27 = OpCompositeExtract %24 0 
					                                Private f32* %29 = OpAccessChain %9 %26 
					                                                     OpStore %29 %27 
					                                Uniform f32* %37 = OpAccessChain %32 %34 %35 
					                                         f32 %38 = OpLoad %37 
					                                Private f32* %39 = OpAccessChain %9 %26 
					                                         f32 %40 = OpLoad %39 
					                                         f32 %41 = OpFMul %38 %40 
					                                Uniform f32* %43 = OpAccessChain %32 %34 %42 
					                                         f32 %44 = OpLoad %43 
					                                         f32 %45 = OpFAdd %41 %44 
					                                Private f32* %46 = OpAccessChain %9 %26 
					                                                     OpStore %46 %45 
					                                Private f32* %48 = OpAccessChain %9 %26 
					                                         f32 %49 = OpLoad %48 
					                                         f32 %50 = OpFDiv %47 %49 
					                                Private f32* %51 = OpAccessChain %9 %26 
					                                                     OpStore %51 %50 
					                                Private f32* %52 = OpAccessChain %9 %26 
					                                         f32 %53 = OpLoad %52 
					                                  Input f32* %55 = OpAccessChain %12 %35 
					                                         f32 %56 = OpLoad %55 
					                                         f32 %57 = OpFNegate %56 
					                                         f32 %58 = OpFAdd %53 %57 
					                                Private f32* %59 = OpAccessChain %9 %26 
					                                                     OpStore %59 %58 
					                                Private f32* %60 = OpAccessChain %9 %26 
					                                         f32 %61 = OpLoad %60 
					                                Uniform f32* %63 = OpAccessChain %32 %62 
					                                         f32 %64 = OpLoad %63 
					                                         f32 %65 = OpFMul %61 %64 
					                                Private f32* %66 = OpAccessChain %9 %26 
					                                                     OpStore %66 %65 
					                                Private f32* %67 = OpAccessChain %9 %26 
					                                         f32 %68 = OpLoad %67 
					                                         f32 %70 = OpExtInst %1 43 %68 %69 %47 
					                                Private f32* %71 = OpAccessChain %9 %26 
					                                                     OpStore %71 %70 
					                                Private f32* %72 = OpAccessChain %9 %26 
					                                         f32 %73 = OpLoad %72 
					                                  Input f32* %75 = OpAccessChain %74 %42 
					                                         f32 %76 = OpLoad %75 
					                                         f32 %77 = OpFMul %73 %76 
					                                Private f32* %78 = OpAccessChain %9 %26 
					                                                     OpStore %78 %77 
					                                Private f32* %81 = OpAccessChain %9 %26 
					                                         f32 %82 = OpLoad %81 
					                                Uniform f32* %84 = OpAccessChain %32 %83 %42 
					                                         f32 %85 = OpLoad %84 
					                                         f32 %86 = OpFMul %82 %85 
					                                Private f32* %87 = OpAccessChain %80 %42 
					                                                     OpStore %87 %86 
					                                       f32_4 %89 = OpLoad %74 
					                                       f32_3 %90 = OpVectorShuffle %89 %89 0 1 2 
					                              Uniform f32_4* %92 = OpAccessChain %32 %83 
					                                       f32_4 %93 = OpLoad %92 
					                                       f32_3 %94 = OpVectorShuffle %93 %93 0 1 2 
					                                       f32_3 %95 = OpFMul %90 %94 
					                                       f32_4 %96 = OpLoad %80 
					                                       f32_4 %97 = OpVectorShuffle %96 %95 4 5 6 3 
					                                                     OpStore %80 %97 
					                                       f32_4 %98 = OpLoad %80 
					                                      f32_4 %101 = OpFAdd %98 %100 
					                                                     OpStore %80 %101 
					                 read_only Texture2DSampled %104 = OpLoad %103 
					                                      f32_2 %107 = OpLoad %106 
					                                      f32_4 %108 = OpImageSampleImplicitLod %104 %107 
					                                                     OpStore %102 %108 
					                                      f32_2 %110 = OpLoad %9 
					                                      f32_4 %111 = OpVectorShuffle %110 %110 0 0 0 0 
					                                      f32_4 %112 = OpLoad %102 
					                                      f32_4 %113 = OpFMul %111 %112 
					                                                     OpStore %109 %113 
					                                      f32_4 %116 = OpLoad %109 
					                                      f32_4 %117 = OpLoad %80 
					                                      f32_4 %118 = OpFMul %116 %117 
					                                      f32_4 %120 = OpFAdd %118 %119 
					                                                     OpStore %115 %120 
					                                                     OpReturn
					                                                     OpFunctionEnd"
				}
				SubProgram "vulkan hw_tier02 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!vulkan
					
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 177
					; Schema: 0
					                                                      OpCapability Shader 
					                                               %1 = OpExtInstImport "GLSL.std.450" 
					                                                      OpMemoryModel Logical GLSL450 
					                                                      OpEntryPoint Vertex %4 "main" %11 %80 %84 %85 %89 %91 %139 
					                                                      OpDecorate %11 Location 11 
					                                                      OpDecorate %16 ArrayStride 16 
					                                                      OpDecorate %17 ArrayStride 17 
					                                                      OpDecorate %18 ArrayStride 18 
					                                                      OpMemberDecorate %19 0 Offset 19 
					                                                      OpMemberDecorate %19 1 Offset 19 
					                                                      OpMemberDecorate %19 2 Offset 19 
					                                                      OpMemberDecorate %19 3 Offset 19 
					                                                      OpMemberDecorate %19 4 Offset 19 
					                                                      OpDecorate %19 Block 
					                                                      OpDecorate %21 DescriptorSet 21 
					                                                      OpDecorate %21 Binding 21 
					                                                      OpMemberDecorate %78 0 BuiltIn 78 
					                                                      OpMemberDecorate %78 1 BuiltIn 78 
					                                                      OpMemberDecorate %78 2 BuiltIn 78 
					                                                      OpDecorate %78 Block 
					                                                      OpDecorate %84 RelaxedPrecision 
					                                                      OpDecorate %84 Location 84 
					                                                      OpDecorate %85 RelaxedPrecision 
					                                                      OpDecorate %85 Location 85 
					                                                      OpDecorate %86 RelaxedPrecision 
					                                                      OpDecorate %89 Location 89 
					                                                      OpDecorate %91 Location 91 
					                                                      OpDecorate %139 Location 139 
					                                               %2 = OpTypeVoid 
					                                               %3 = OpTypeFunction %2 
					                                               %6 = OpTypeFloat 32 
					                                               %7 = OpTypeVector %6 4 
					                                               %8 = OpTypePointer Private %7 
					                                Private f32_4* %9 = OpVariable Private 
					                                              %10 = OpTypePointer Input %7 
					                                 Input f32_4* %11 = OpVariable Input 
					                                              %14 = OpTypeInt 32 0 
					                                          u32 %15 = OpConstant 4 
					                                              %16 = OpTypeArray %7 %15 
					                                              %17 = OpTypeArray %7 %15 
					                                              %18 = OpTypeArray %7 %15 
					                                              %19 = OpTypeStruct %7 %16 %17 %18 %7 
					                                              %20 = OpTypePointer Uniform %19 
					Uniform struct {f32_4; f32_4[4]; f32_4[4]; f32_4[4]; f32_4;}* %21 = OpVariable Uniform 
					                                              %22 = OpTypeInt 32 1 
					                                          i32 %23 = OpConstant 1 
					                                              %24 = OpTypePointer Uniform %7 
					                                          i32 %28 = OpConstant 0 
					                                          i32 %36 = OpConstant 2 
					                                          i32 %45 = OpConstant 3 
					                               Private f32_4* %49 = OpVariable Private 
					                                          u32 %76 = OpConstant 1 
					                                              %77 = OpTypeArray %6 %76 
					                                              %78 = OpTypeStruct %7 %6 %77 
					                                              %79 = OpTypePointer Output %78 
					         Output struct {f32_4; f32; f32[1];}* %80 = OpVariable Output 
					                                              %82 = OpTypePointer Output %7 
					                                Output f32_4* %84 = OpVariable Output 
					                                 Input f32_4* %85 = OpVariable Input 
					                                              %87 = OpTypeVector %6 2 
					                                              %88 = OpTypePointer Output %87 
					                                Output f32_2* %89 = OpVariable Output 
					                                              %90 = OpTypePointer Input %87 
					                                 Input f32_2* %91 = OpVariable Input 
					                                          i32 %93 = OpConstant 4 
					                                             %102 = OpTypePointer Private %6 
					                                Private f32* %103 = OpVariable Private 
					                                         u32 %106 = OpConstant 2 
					                                             %107 = OpTypePointer Uniform %6 
					                                         u32 %113 = OpConstant 0 
					                                         u32 %131 = OpConstant 3 
					                               Output f32_4* %139 = OpVariable Output 
					                                             %143 = OpTypePointer Output %6 
					                                         f32 %153 = OpConstant 3.674022E-40 
					                                       f32_2 %158 = OpConstantComposite %153 %153 
					                                          void %4 = OpFunction None %3 
					                                               %5 = OpLabel 
					                                        f32_4 %12 = OpLoad %11 
					                                        f32_4 %13 = OpVectorShuffle %12 %12 1 1 1 1 
					                               Uniform f32_4* %25 = OpAccessChain %21 %23 %23 
					                                        f32_4 %26 = OpLoad %25 
					                                        f32_4 %27 = OpFMul %13 %26 
					                                                      OpStore %9 %27 
					                               Uniform f32_4* %29 = OpAccessChain %21 %23 %28 
					                                        f32_4 %30 = OpLoad %29 
					                                        f32_4 %31 = OpLoad %11 
					                                        f32_4 %32 = OpVectorShuffle %31 %31 0 0 0 0 
					                                        f32_4 %33 = OpFMul %30 %32 
					                                        f32_4 %34 = OpLoad %9 
					                                        f32_4 %35 = OpFAdd %33 %34 
					                                                      OpStore %9 %35 
					                               Uniform f32_4* %37 = OpAccessChain %21 %23 %36 
					                                        f32_4 %38 = OpLoad %37 
					                                        f32_4 %39 = OpLoad %11 
					                                        f32_4 %40 = OpVectorShuffle %39 %39 2 2 2 2 
					                                        f32_4 %41 = OpFMul %38 %40 
					                                        f32_4 %42 = OpLoad %9 
					                                        f32_4 %43 = OpFAdd %41 %42 
					                                                      OpStore %9 %43 
					                                        f32_4 %44 = OpLoad %9 
					                               Uniform f32_4* %46 = OpAccessChain %21 %23 %45 
					                                        f32_4 %47 = OpLoad %46 
					                                        f32_4 %48 = OpFAdd %44 %47 
					                                                      OpStore %9 %48 
					                                        f32_4 %50 = OpLoad %9 
					                                        f32_4 %51 = OpVectorShuffle %50 %50 1 1 1 1 
					                               Uniform f32_4* %52 = OpAccessChain %21 %45 %23 
					                                        f32_4 %53 = OpLoad %52 
					                                        f32_4 %54 = OpFMul %51 %53 
					                                                      OpStore %49 %54 
					                               Uniform f32_4* %55 = OpAccessChain %21 %45 %28 
					                                        f32_4 %56 = OpLoad %55 
					                                        f32_4 %57 = OpLoad %9 
					                                        f32_4 %58 = OpVectorShuffle %57 %57 0 0 0 0 
					                                        f32_4 %59 = OpFMul %56 %58 
					                                        f32_4 %60 = OpLoad %49 
					                                        f32_4 %61 = OpFAdd %59 %60 
					                                                      OpStore %49 %61 
					                               Uniform f32_4* %62 = OpAccessChain %21 %45 %36 
					                                        f32_4 %63 = OpLoad %62 
					                                        f32_4 %64 = OpLoad %9 
					                                        f32_4 %65 = OpVectorShuffle %64 %64 2 2 2 2 
					                                        f32_4 %66 = OpFMul %63 %65 
					                                        f32_4 %67 = OpLoad %49 
					                                        f32_4 %68 = OpFAdd %66 %67 
					                                                      OpStore %49 %68 
					                               Uniform f32_4* %69 = OpAccessChain %21 %45 %45 
					                                        f32_4 %70 = OpLoad %69 
					                                        f32_4 %71 = OpLoad %9 
					                                        f32_4 %72 = OpVectorShuffle %71 %71 3 3 3 3 
					                                        f32_4 %73 = OpFMul %70 %72 
					                                        f32_4 %74 = OpLoad %49 
					                                        f32_4 %75 = OpFAdd %73 %74 
					                                                      OpStore %49 %75 
					                                        f32_4 %81 = OpLoad %49 
					                                Output f32_4* %83 = OpAccessChain %80 %28 
					                                                      OpStore %83 %81 
					                                        f32_4 %86 = OpLoad %85 
					                                                      OpStore %84 %86 
					                                        f32_2 %92 = OpLoad %91 
					                               Uniform f32_4* %94 = OpAccessChain %21 %93 
					                                        f32_4 %95 = OpLoad %94 
					                                        f32_2 %96 = OpVectorShuffle %95 %95 0 1 
					                                        f32_2 %97 = OpFMul %92 %96 
					                               Uniform f32_4* %98 = OpAccessChain %21 %93 
					                                        f32_4 %99 = OpLoad %98 
					                                       f32_2 %100 = OpVectorShuffle %99 %99 2 3 
					                                       f32_2 %101 = OpFAdd %97 %100 
					                                                      OpStore %89 %101 
					                                Private f32* %104 = OpAccessChain %9 %76 
					                                         f32 %105 = OpLoad %104 
					                                Uniform f32* %108 = OpAccessChain %21 %36 %23 %106 
					                                         f32 %109 = OpLoad %108 
					                                         f32 %110 = OpFMul %105 %109 
					                                                      OpStore %103 %110 
					                                Uniform f32* %111 = OpAccessChain %21 %36 %28 %106 
					                                         f32 %112 = OpLoad %111 
					                                Private f32* %114 = OpAccessChain %9 %113 
					                                         f32 %115 = OpLoad %114 
					                                         f32 %116 = OpFMul %112 %115 
					                                         f32 %117 = OpLoad %103 
					                                         f32 %118 = OpFAdd %116 %117 
					                                Private f32* %119 = OpAccessChain %9 %113 
					                                                      OpStore %119 %118 
					                                Uniform f32* %120 = OpAccessChain %21 %36 %36 %106 
					                                         f32 %121 = OpLoad %120 
					                                Private f32* %122 = OpAccessChain %9 %106 
					                                         f32 %123 = OpLoad %122 
					                                         f32 %124 = OpFMul %121 %123 
					                                Private f32* %125 = OpAccessChain %9 %113 
					                                         f32 %126 = OpLoad %125 
					                                         f32 %127 = OpFAdd %124 %126 
					                                Private f32* %128 = OpAccessChain %9 %113 
					                                                      OpStore %128 %127 
					                                Uniform f32* %129 = OpAccessChain %21 %36 %45 %106 
					                                         f32 %130 = OpLoad %129 
					                                Private f32* %132 = OpAccessChain %9 %131 
					                                         f32 %133 = OpLoad %132 
					                                         f32 %134 = OpFMul %130 %133 
					                                Private f32* %135 = OpAccessChain %9 %113 
					                                         f32 %136 = OpLoad %135 
					                                         f32 %137 = OpFAdd %134 %136 
					                                Private f32* %138 = OpAccessChain %9 %113 
					                                                      OpStore %138 %137 
					                                Private f32* %140 = OpAccessChain %9 %113 
					                                         f32 %141 = OpLoad %140 
					                                         f32 %142 = OpFNegate %141 
					                                 Output f32* %144 = OpAccessChain %139 %106 
					                                                      OpStore %144 %142 
					                                Private f32* %145 = OpAccessChain %49 %76 
					                                         f32 %146 = OpLoad %145 
					                                Uniform f32* %147 = OpAccessChain %21 %28 %113 
					                                         f32 %148 = OpLoad %147 
					                                         f32 %149 = OpFMul %146 %148 
					                                Private f32* %150 = OpAccessChain %9 %113 
					                                                      OpStore %150 %149 
					                                Private f32* %151 = OpAccessChain %9 %113 
					                                         f32 %152 = OpLoad %151 
					                                         f32 %154 = OpFMul %152 %153 
					                                Private f32* %155 = OpAccessChain %9 %131 
					                                                      OpStore %155 %154 
					                                       f32_4 %156 = OpLoad %49 
					                                       f32_2 %157 = OpVectorShuffle %156 %156 0 3 
					                                       f32_2 %159 = OpFMul %157 %158 
					                                       f32_4 %160 = OpLoad %9 
					                                       f32_4 %161 = OpVectorShuffle %160 %159 4 1 5 3 
					                                                      OpStore %9 %161 
					                                Private f32* %162 = OpAccessChain %49 %131 
					                                         f32 %163 = OpLoad %162 
					                                 Output f32* %164 = OpAccessChain %139 %131 
					                                                      OpStore %164 %163 
					                                       f32_4 %165 = OpLoad %9 
					                                       f32_2 %166 = OpVectorShuffle %165 %165 2 2 
					                                       f32_4 %167 = OpLoad %9 
					                                       f32_2 %168 = OpVectorShuffle %167 %167 0 3 
					                                       f32_2 %169 = OpFAdd %166 %168 
					                                       f32_4 %170 = OpLoad %139 
					                                       f32_4 %171 = OpVectorShuffle %170 %169 4 5 2 3 
					                                                      OpStore %139 %171 
					                                 Output f32* %172 = OpAccessChain %80 %28 %76 
					                                         f32 %173 = OpLoad %172 
					                                         f32 %174 = OpFNegate %173 
					                                 Output f32* %175 = OpAccessChain %80 %28 %76 
					                                                      OpStore %175 %174 
					                                                      OpReturn
					                                                      OpFunctionEnd
					; SPIR-V
					; Version: 1.0
					; Generator: Khronos Glslang Reference Front End; 1
					; Bound: 122
					; Schema: 0
					                                                     OpCapability Shader 
					                                              %1 = OpExtInstImport "GLSL.std.450" 
					                                                     OpMemoryModel Logical GLSL450 
					                                                     OpEntryPoint Fragment %4 "main" %12 %74 %106 %115 
					                                                     OpExecutionMode %4 OriginUpperLeft 
					                                                     OpDecorate %12 Location 12 
					                                                     OpDecorate %21 DescriptorSet 21 
					                                                     OpDecorate %21 Binding 21 
					                                                     OpMemberDecorate %30 0 Offset 30 
					                                                     OpMemberDecorate %30 1 RelaxedPrecision 
					                                                     OpMemberDecorate %30 1 Offset 30 
					                                                     OpMemberDecorate %30 2 Offset 30 
					                                                     OpDecorate %30 Block 
					                                                     OpDecorate %32 DescriptorSet 32 
					                                                     OpDecorate %32 Binding 32 
					                                                     OpDecorate %74 RelaxedPrecision 
					                                                     OpDecorate %74 Location 74 
					                                                     OpDecorate %76 RelaxedPrecision 
					                                                     OpDecorate %80 RelaxedPrecision 
					                                                     OpDecorate %85 RelaxedPrecision 
					                                                     OpDecorate %89 RelaxedPrecision 
					                                                     OpDecorate %90 RelaxedPrecision 
					                                                     OpDecorate %93 RelaxedPrecision 
					                                                     OpDecorate %94 RelaxedPrecision 
					                                                     OpDecorate %95 RelaxedPrecision 
					                                                     OpDecorate %98 RelaxedPrecision 
					                                                     OpDecorate %101 RelaxedPrecision 
					                                                     OpDecorate %102 RelaxedPrecision 
					                                                     OpDecorate %103 RelaxedPrecision 
					                                                     OpDecorate %103 DescriptorSet 103 
					                                                     OpDecorate %103 Binding 103 
					                                                     OpDecorate %104 RelaxedPrecision 
					                                                     OpDecorate %106 Location 106 
					                                                     OpDecorate %109 RelaxedPrecision 
					                                                     OpDecorate %112 RelaxedPrecision 
					                                                     OpDecorate %115 RelaxedPrecision 
					                                                     OpDecorate %115 Location 115 
					                                                     OpDecorate %116 RelaxedPrecision 
					                                                     OpDecorate %117 RelaxedPrecision 
					                                                     OpDecorate %118 RelaxedPrecision 
					                                                     OpDecorate %120 RelaxedPrecision 
					                                              %2 = OpTypeVoid 
					                                              %3 = OpTypeFunction %2 
					                                              %6 = OpTypeFloat 32 
					                                              %7 = OpTypeVector %6 2 
					                                              %8 = OpTypePointer Private %7 
					                               Private f32_2* %9 = OpVariable Private 
					                                             %10 = OpTypeVector %6 4 
					                                             %11 = OpTypePointer Input %10 
					                                Input f32_4* %12 = OpVariable Input 
					                                             %18 = OpTypeImage %6 Dim2D 0 0 0 1 Unknown 
					                                             %19 = OpTypeSampledImage %18 
					                                             %20 = OpTypePointer UniformConstant %19 
					 UniformConstant read_only Texture2DSampled* %21 = OpVariable UniformConstant 
					                                             %25 = OpTypeInt 32 0 
					                                         u32 %26 = OpConstant 0 
					                                             %28 = OpTypePointer Private %6 
					                                             %30 = OpTypeStruct %10 %10 %6 
					                                             %31 = OpTypePointer Uniform %30 
					        Uniform struct {f32_4; f32_4; f32;}* %32 = OpVariable Uniform 
					                                             %33 = OpTypeInt 32 1 
					                                         i32 %34 = OpConstant 0 
					                                         u32 %35 = OpConstant 2 
					                                             %36 = OpTypePointer Uniform %6 
					                                         u32 %42 = OpConstant 3 
					                                         f32 %47 = OpConstant 3.674022E-40 
					                                             %54 = OpTypePointer Input %6 
					                                         i32 %62 = OpConstant 2 
					                                         f32 %69 = OpConstant 3.674022E-40 
					                                Input f32_4* %74 = OpVariable Input 
					                                             %79 = OpTypePointer Private %10 
					                              Private f32_4* %80 = OpVariable Private 
					                                         i32 %83 = OpConstant 1 
					                                             %88 = OpTypeVector %6 3 
					                                             %91 = OpTypePointer Uniform %10 
					                                         f32 %99 = OpConstant 3.674022E-40 
					                                      f32_4 %100 = OpConstantComposite %99 %99 %99 %99 
					                             Private f32_4* %102 = OpVariable Private 
					UniformConstant read_only Texture2DSampled* %103 = OpVariable UniformConstant 
					                                            %105 = OpTypePointer Input %7 
					                               Input f32_2* %106 = OpVariable Input 
					                             Private f32_4* %109 = OpVariable Private 
					                                            %114 = OpTypePointer Output %10 
					                              Output f32_4* %115 = OpVariable Output 
					                                      f32_4 %119 = OpConstantComposite %47 %47 %47 %47 
					                                         void %4 = OpFunction None %3 
					                                              %5 = OpLabel 
					                                       f32_4 %13 = OpLoad %12 
					                                       f32_2 %14 = OpVectorShuffle %13 %13 0 1 
					                                       f32_4 %15 = OpLoad %12 
					                                       f32_2 %16 = OpVectorShuffle %15 %15 3 3 
					                                       f32_2 %17 = OpFDiv %14 %16 
					                                                     OpStore %9 %17 
					                  read_only Texture2DSampled %22 = OpLoad %21 
					                                       f32_2 %23 = OpLoad %9 
					                                       f32_4 %24 = OpImageSampleImplicitLod %22 %23 
					                                         f32 %27 = OpCompositeExtract %24 0 
					                                Private f32* %29 = OpAccessChain %9 %26 
					                                                     OpStore %29 %27 
					                                Uniform f32* %37 = OpAccessChain %32 %34 %35 
					                                         f32 %38 = OpLoad %37 
					                                Private f32* %39 = OpAccessChain %9 %26 
					                                         f32 %40 = OpLoad %39 
					                                         f32 %41 = OpFMul %38 %40 
					                                Uniform f32* %43 = OpAccessChain %32 %34 %42 
					                                         f32 %44 = OpLoad %43 
					                                         f32 %45 = OpFAdd %41 %44 
					                                Private f32* %46 = OpAccessChain %9 %26 
					                                                     OpStore %46 %45 
					                                Private f32* %48 = OpAccessChain %9 %26 
					                                         f32 %49 = OpLoad %48 
					                                         f32 %50 = OpFDiv %47 %49 
					                                Private f32* %51 = OpAccessChain %9 %26 
					                                                     OpStore %51 %50 
					                                Private f32* %52 = OpAccessChain %9 %26 
					                                         f32 %53 = OpLoad %52 
					                                  Input f32* %55 = OpAccessChain %12 %35 
					                                         f32 %56 = OpLoad %55 
					                                         f32 %57 = OpFNegate %56 
					                                         f32 %58 = OpFAdd %53 %57 
					                                Private f32* %59 = OpAccessChain %9 %26 
					                                                     OpStore %59 %58 
					                                Private f32* %60 = OpAccessChain %9 %26 
					                                         f32 %61 = OpLoad %60 
					                                Uniform f32* %63 = OpAccessChain %32 %62 
					                                         f32 %64 = OpLoad %63 
					                                         f32 %65 = OpFMul %61 %64 
					                                Private f32* %66 = OpAccessChain %9 %26 
					                                                     OpStore %66 %65 
					                                Private f32* %67 = OpAccessChain %9 %26 
					                                         f32 %68 = OpLoad %67 
					                                         f32 %70 = OpExtInst %1 43 %68 %69 %47 
					                                Private f32* %71 = OpAccessChain %9 %26 
					                                                     OpStore %71 %70 
					                                Private f32* %72 = OpAccessChain %9 %26 
					                                         f32 %73 = OpLoad %72 
					                                  Input f32* %75 = OpAccessChain %74 %42 
					                                         f32 %76 = OpLoad %75 
					                                         f32 %77 = OpFMul %73 %76 
					                                Private f32* %78 = OpAccessChain %9 %26 
					                                                     OpStore %78 %77 
					                                Private f32* %81 = OpAccessChain %9 %26 
					                                         f32 %82 = OpLoad %81 
					                                Uniform f32* %84 = OpAccessChain %32 %83 %42 
					                                         f32 %85 = OpLoad %84 
					                                         f32 %86 = OpFMul %82 %85 
					                                Private f32* %87 = OpAccessChain %80 %42 
					                                                     OpStore %87 %86 
					                                       f32_4 %89 = OpLoad %74 
					                                       f32_3 %90 = OpVectorShuffle %89 %89 0 1 2 
					                              Uniform f32_4* %92 = OpAccessChain %32 %83 
					                                       f32_4 %93 = OpLoad %92 
					                                       f32_3 %94 = OpVectorShuffle %93 %93 0 1 2 
					                                       f32_3 %95 = OpFMul %90 %94 
					                                       f32_4 %96 = OpLoad %80 
					                                       f32_4 %97 = OpVectorShuffle %96 %95 4 5 6 3 
					                                                     OpStore %80 %97 
					                                       f32_4 %98 = OpLoad %80 
					                                      f32_4 %101 = OpFAdd %98 %100 
					                                                     OpStore %80 %101 
					                 read_only Texture2DSampled %104 = OpLoad %103 
					                                      f32_2 %107 = OpLoad %106 
					                                      f32_4 %108 = OpImageSampleImplicitLod %104 %107 
					                                                     OpStore %102 %108 
					                                      f32_2 %110 = OpLoad %9 
					                                      f32_4 %111 = OpVectorShuffle %110 %110 0 0 0 0 
					                                      f32_4 %112 = OpLoad %102 
					                                      f32_4 %113 = OpFMul %111 %112 
					                                                     OpStore %109 %113 
					                                      f32_4 %116 = OpLoad %109 
					                                      f32_4 %117 = OpLoad %80 
					                                      f32_4 %118 = OpFMul %116 %117 
					                                      f32_4 %120 = OpFAdd %118 %119 
					                                                     OpStore %115 %120 
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
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES"
				}
				SubProgram "gles3 hw_tier00 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES3"
				}
				SubProgram "gles3 hw_tier01 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES3"
				}
				SubProgram "gles3 hw_tier02 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!!!GLES3"
				}
				SubProgram "vulkan hw_tier00 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!vulkan"
				}
				SubProgram "vulkan hw_tier01 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!vulkan"
				}
				SubProgram "vulkan hw_tier02 " {
					Keywords { "SOFTPARTICLES_ON" }
					"!!vulkan"
				}
			}
		}
	}
}