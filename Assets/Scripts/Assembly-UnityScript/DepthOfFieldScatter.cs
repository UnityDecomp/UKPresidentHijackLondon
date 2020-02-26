using System;

using UnityEngine;

// Token: 0x020000CB RID: 203
[AddComponentMenu("Image Effects/Camera/Depth of Field (Lens Blur, Scatter, DX11)")]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[Serializable]
public class DepthOfFieldScatter : PostEffectsBase
{
	// Token: 0x060002BA RID: 698 RVA: 0x00022934 File Offset: 0x00020B34
	public DepthOfFieldScatter()
	{
		this.focalLength = 10f;
		this.focalSize = 0.05f;
		this.aperture = 11.5f;
		this.maxBlurSize = 2f;
		this.blurType = DepthOfFieldScatter.BlurType.DiscBlur;
		this.blurSampleCount = DepthOfFieldScatter.BlurSampleCount.High;
		this.foregroundOverlap = 1f;
		this.dx11BokehThreshhold = 0.5f;
		this.dx11SpawnHeuristic = 0.0875f;
		this.dx11BokehScale = 1.2f;
		this.dx11BokehIntensity = 2.5f;
		this.focalDistance01 = 10f;
		this.internalBlurWidth = 1f;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x000229D0 File Offset: 0x00020BD0
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.dofHdrMaterial = this.CheckShaderAndCreateMaterial(this.dofHdrShader, this.dofHdrMaterial);
		if (this.supportDX11 && this.blurType == DepthOfFieldScatter.BlurType.DX11)
		{
			this.dx11bokehMaterial = this.CheckShaderAndCreateMaterial(this.dx11BokehShader, this.dx11bokehMaterial);
			this.CreateComputeResources();
		}
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002BC RID: 700 RVA: 0x00022A4C File Offset: 0x00020C4C
	public override void OnEnable()
	{
		this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.Depth);
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00022A74 File Offset: 0x00020C74
	public virtual void OnDisable()
	{
		this.ReleaseComputeResources();
		if (this.dofHdrMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.dofHdrMaterial);
		}
		this.dofHdrMaterial = null;
		if (this.dx11bokehMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.dx11bokehMaterial);
		}
		this.dx11bokehMaterial = null;
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00022ACC File Offset: 0x00020CCC
	public virtual void ReleaseComputeResources()
	{
		if (this.cbDrawArgs != null)
		{
			this.cbDrawArgs.Release();
		}
		this.cbDrawArgs = null;
		if (this.cbPoints != null)
		{
			this.cbPoints.Release();
		}
		this.cbPoints = null;
	}

	// Token: 0x060002BF RID: 703 RVA: 0x00022B14 File Offset: 0x00020D14
	public virtual void CreateComputeResources()
	{
		if (RuntimeServices.EqualityOperator(this.cbDrawArgs, null))
		{
			this.cbDrawArgs = new ComputeBuffer(1, 16, ComputeBufferType.IndirectArguments);
			int[] data = new int[]
			{
				0,
				1,
				0,
				0
			};
			this.cbDrawArgs.SetData(data);
		}
		if (RuntimeServices.EqualityOperator(this.cbPoints, null))
		{
			this.cbPoints = new ComputeBuffer(90000, 28, ComputeBufferType.Append);
		}
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00022B8C File Offset: 0x00020D8C
	public virtual float FocalDistance01(float worldDist)
	{
		return this.GetComponent<Camera>().WorldToViewportPoint((worldDist - this.GetComponent<Camera>().nearClipPlane) * this.GetComponent<Camera>().transform.forward + this.GetComponent<Camera>().transform.position).z / (this.GetComponent<Camera>().farClipPlane - this.GetComponent<Camera>().nearClipPlane);
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00022BFC File Offset: 0x00020DFC
	private void WriteCoc(RenderTexture fromTo, bool fgDilate)
	{
		this.dofHdrMaterial.SetTexture("_FgOverlap", null);
		if (this.nearBlur && fgDilate)
		{
			int width = fromTo.width / 2;
			int height = fromTo.height / 2;
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, fromTo.format);
			Graphics.Blit(fromTo, temporary, this.dofHdrMaterial, 4);
			float num = this.internalBlurWidth * this.foregroundOverlap;
			this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, num, (float)0, num));
			RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0, fromTo.format);
			Graphics.Blit(temporary, temporary2, this.dofHdrMaterial, 2);
			RenderTexture.ReleaseTemporary(temporary);
			this.dofHdrMaterial.SetVector("_Offsets", new Vector4(num, (float)0, (float)0, num));
			temporary = RenderTexture.GetTemporary(width, height, 0, fromTo.format);
			Graphics.Blit(temporary2, temporary, this.dofHdrMaterial, 2);
			RenderTexture.ReleaseTemporary(temporary2);
			this.dofHdrMaterial.SetTexture("_FgOverlap", temporary);
			fromTo.MarkRestoreExpected();
			Graphics.Blit(fromTo, fromTo, this.dofHdrMaterial, 13);
			RenderTexture.ReleaseTemporary(temporary);
		}
		else
		{
			Graphics.Blit(fromTo, fromTo, this.dofHdrMaterial, 0);
		}
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x00022D28 File Offset: 0x00020F28
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			if (this.aperture < (float)0)
			{
				this.aperture = (float)0;
			}
			if (this.maxBlurSize < 0.1f)
			{
				this.maxBlurSize = 0.1f;
			}
			this.focalSize = Mathf.Clamp(this.focalSize, (float)0, 2f);
			this.internalBlurWidth = Mathf.Max(this.maxBlurSize, (float)0);
			this.focalDistance01 = ((!this.focalTransform) ? this.FocalDistance01(this.focalLength) : (this.GetComponent<Camera>().WorldToViewportPoint(this.focalTransform.position).z / this.GetComponent<Camera>().farClipPlane));
			this.dofHdrMaterial.SetVector("_CurveParams", new Vector4(1f, this.focalSize, this.aperture / 10f, this.focalDistance01));
			RenderTexture renderTexture = null;
			RenderTexture renderTexture2 = null;
			float num = this.internalBlurWidth * this.foregroundOverlap;
			if (this.visualizeFocus)
			{
				this.WriteCoc(source, true);
				Graphics.Blit(source, destination, this.dofHdrMaterial, 16);
			}
			else if (this.blurType == DepthOfFieldScatter.BlurType.DX11 && this.dx11bokehMaterial)
			{
				if (this.highResolution)
				{
					this.internalBlurWidth = ((this.internalBlurWidth >= 0.1f) ? this.internalBlurWidth : 0.1f);
					num = this.internalBlurWidth * this.foregroundOverlap;
					renderTexture = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
					RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
					this.WriteCoc(source, false);
					RenderTexture temporary2 = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
					RenderTexture temporary3 = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
					Graphics.Blit(source, temporary2, this.dofHdrMaterial, 15);
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, 1.5f, (float)0, 1.5f));
					Graphics.Blit(temporary2, temporary3, this.dofHdrMaterial, 19);
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4(1.5f, (float)0, (float)0, 1.5f));
					Graphics.Blit(temporary3, temporary2, this.dofHdrMaterial, 19);
					if (this.nearBlur)
					{
						Graphics.Blit(source, temporary3, this.dofHdrMaterial, 4);
					}
					this.dx11bokehMaterial.SetTexture("_BlurredColor", temporary2);
					this.dx11bokehMaterial.SetFloat("_SpawnHeuristic", this.dx11SpawnHeuristic);
					this.dx11bokehMaterial.SetVector("_BokehParams", new Vector4(this.dx11BokehScale, this.dx11BokehIntensity, Mathf.Clamp(this.dx11BokehThreshhold, 0.005f, 4f), this.internalBlurWidth));
					this.dx11bokehMaterial.SetTexture("_FgCocMask", (!this.nearBlur) ? null : temporary3);
					Graphics.SetRandomWriteTarget(1, this.cbPoints);
					Graphics.Blit(source, renderTexture, this.dx11bokehMaterial, 0);
					Graphics.ClearRandomWriteTargets();
					if (this.nearBlur)
					{
						this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, num, (float)0, num));
						Graphics.Blit(temporary3, temporary2, this.dofHdrMaterial, 2);
						this.dofHdrMaterial.SetVector("_Offsets", new Vector4(num, (float)0, (float)0, num));
						Graphics.Blit(temporary2, temporary3, this.dofHdrMaterial, 2);
						Graphics.Blit(temporary3, renderTexture, this.dofHdrMaterial, 3);
					}
					Graphics.Blit(renderTexture, temporary, this.dofHdrMaterial, 20);
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4(this.internalBlurWidth, (float)0, (float)0, this.internalBlurWidth));
					Graphics.Blit(renderTexture, source, this.dofHdrMaterial, 5);
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, this.internalBlurWidth, (float)0, this.internalBlurWidth));
					Graphics.Blit(source, temporary, this.dofHdrMaterial, 21);
					Graphics.SetRenderTarget(temporary);
					ComputeBuffer.CopyCount(this.cbPoints, this.cbDrawArgs, 0);
					this.dx11bokehMaterial.SetBuffer("pointBuffer", this.cbPoints);
					this.dx11bokehMaterial.SetTexture("_MainTex", this.dx11BokehTexture);
					this.dx11bokehMaterial.SetVector("_Screen", new Vector3(1f / (1f * (float)source.width), 1f / (1f * (float)source.height), this.internalBlurWidth));
					this.dx11bokehMaterial.SetPass(2);
					Graphics.DrawProceduralIndirectNow(MeshTopology.Points, this.cbDrawArgs, 0);
					Graphics.Blit(temporary, destination);
					RenderTexture.ReleaseTemporary(temporary);
					RenderTexture.ReleaseTemporary(temporary2);
					RenderTexture.ReleaseTemporary(temporary3);
				}
				else
				{
					renderTexture = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
					renderTexture2 = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
					num = this.internalBlurWidth * this.foregroundOverlap;
					this.WriteCoc(source, false);
					source.filterMode = FilterMode.Bilinear;
					Graphics.Blit(source, renderTexture, this.dofHdrMaterial, 6);
					RenderTexture temporary2 = RenderTexture.GetTemporary(renderTexture.width >> 1, renderTexture.height >> 1, 0, renderTexture.format);
					RenderTexture temporary3 = RenderTexture.GetTemporary(renderTexture.width >> 1, renderTexture.height >> 1, 0, renderTexture.format);
					Graphics.Blit(renderTexture, temporary2, this.dofHdrMaterial, 15);
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, 1.5f, (float)0, 1.5f));
					Graphics.Blit(temporary2, temporary3, this.dofHdrMaterial, 19);
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4(1.5f, (float)0, (float)0, 1.5f));
					Graphics.Blit(temporary3, temporary2, this.dofHdrMaterial, 19);
					RenderTexture renderTexture3 = null;
					if (this.nearBlur)
					{
						renderTexture3 = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
						Graphics.Blit(source, renderTexture3, this.dofHdrMaterial, 4);
					}
					this.dx11bokehMaterial.SetTexture("_BlurredColor", temporary2);
					this.dx11bokehMaterial.SetFloat("_SpawnHeuristic", this.dx11SpawnHeuristic);
					this.dx11bokehMaterial.SetVector("_BokehParams", new Vector4(this.dx11BokehScale, this.dx11BokehIntensity, Mathf.Clamp(this.dx11BokehThreshhold, 0.005f, 4f), this.internalBlurWidth));
					this.dx11bokehMaterial.SetTexture("_FgCocMask", renderTexture3);
					Graphics.SetRandomWriteTarget(1, this.cbPoints);
					Graphics.Blit(renderTexture, renderTexture2, this.dx11bokehMaterial, 0);
					Graphics.ClearRandomWriteTargets();
					RenderTexture.ReleaseTemporary(temporary2);
					RenderTexture.ReleaseTemporary(temporary3);
					if (this.nearBlur)
					{
						this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, num, (float)0, num));
						Graphics.Blit(renderTexture3, renderTexture, this.dofHdrMaterial, 2);
						this.dofHdrMaterial.SetVector("_Offsets", new Vector4(num, (float)0, (float)0, num));
						Graphics.Blit(renderTexture, renderTexture3, this.dofHdrMaterial, 2);
						Graphics.Blit(renderTexture3, renderTexture2, this.dofHdrMaterial, 3);
					}
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4(this.internalBlurWidth, (float)0, (float)0, this.internalBlurWidth));
					Graphics.Blit(renderTexture2, renderTexture, this.dofHdrMaterial, 5);
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, this.internalBlurWidth, (float)0, this.internalBlurWidth));
					Graphics.Blit(renderTexture, renderTexture2, this.dofHdrMaterial, 5);
					Graphics.SetRenderTarget(renderTexture2);
					ComputeBuffer.CopyCount(this.cbPoints, this.cbDrawArgs, 0);
					this.dx11bokehMaterial.SetBuffer("pointBuffer", this.cbPoints);
					this.dx11bokehMaterial.SetTexture("_MainTex", this.dx11BokehTexture);
					this.dx11bokehMaterial.SetVector("_Screen", new Vector3(1f / (1f * (float)renderTexture2.width), 1f / (1f * (float)renderTexture2.height), this.internalBlurWidth));
					this.dx11bokehMaterial.SetPass(1);
					Graphics.DrawProceduralIndirectNow(MeshTopology.Points, this.cbDrawArgs, 0);
					this.dofHdrMaterial.SetTexture("_LowRez", renderTexture2);
					this.dofHdrMaterial.SetTexture("_FgOverlap", renderTexture3);
					this.dofHdrMaterial.SetVector("_Offsets", 1f * (float)source.width / (1f * (float)renderTexture2.width) * this.internalBlurWidth * Vector4.one);
					Graphics.Blit(source, destination, this.dofHdrMaterial, 9);
					if (renderTexture3)
					{
						RenderTexture.ReleaseTemporary(renderTexture3);
					}
				}
			}
			else
			{
				source.filterMode = FilterMode.Bilinear;
				if (this.highResolution)
				{
					this.internalBlurWidth *= 2f;
				}
				this.WriteCoc(source, true);
				renderTexture = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
				renderTexture2 = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
				int pass = (this.blurSampleCount != DepthOfFieldScatter.BlurSampleCount.High && this.blurSampleCount != DepthOfFieldScatter.BlurSampleCount.Medium) ? 11 : 17;
				if (this.highResolution)
				{
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, this.internalBlurWidth, 0.025f, this.internalBlurWidth));
					Graphics.Blit(source, destination, this.dofHdrMaterial, pass);
				}
				else
				{
					this.dofHdrMaterial.SetVector("_Offsets", new Vector4((float)0, this.internalBlurWidth, 0.1f, this.internalBlurWidth));
					Graphics.Blit(source, renderTexture, this.dofHdrMaterial, 6);
					Graphics.Blit(renderTexture, renderTexture2, this.dofHdrMaterial, pass);
					this.dofHdrMaterial.SetTexture("_LowRez", renderTexture2);
					this.dofHdrMaterial.SetTexture("_FgOverlap", null);
					this.dofHdrMaterial.SetVector("_Offsets", Vector4.one * (1f * (float)source.width / (1f * (float)renderTexture2.width)) * this.internalBlurWidth);
					Graphics.Blit(source, destination, this.dofHdrMaterial, (this.blurSampleCount != DepthOfFieldScatter.BlurSampleCount.High) ? 12 : 18);
				}
			}
			if (renderTexture)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
			}
			if (renderTexture2)
			{
				RenderTexture.ReleaseTemporary(renderTexture2);
			}
		}
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x000237C4 File Offset: 0x000219C4
	public override void Main()
	{
	}

	// Token: 0x04000507 RID: 1287
	public bool visualizeFocus;

	// Token: 0x04000508 RID: 1288
	public float focalLength;

	// Token: 0x04000509 RID: 1289
	public float focalSize;

	// Token: 0x0400050A RID: 1290
	public float aperture;

	// Token: 0x0400050B RID: 1291
	public Transform focalTransform;

	// Token: 0x0400050C RID: 1292
	public float maxBlurSize;

	// Token: 0x0400050D RID: 1293
	public bool highResolution;

	// Token: 0x0400050E RID: 1294
	public DepthOfFieldScatter.BlurType blurType;

	// Token: 0x0400050F RID: 1295
	public DepthOfFieldScatter.BlurSampleCount blurSampleCount;

	// Token: 0x04000510 RID: 1296
	public bool nearBlur;

	// Token: 0x04000511 RID: 1297
	public float foregroundOverlap;

	// Token: 0x04000512 RID: 1298
	public Shader dofHdrShader;

	// Token: 0x04000513 RID: 1299
	private Material dofHdrMaterial;

	// Token: 0x04000514 RID: 1300
	public Shader dx11BokehShader;

	// Token: 0x04000515 RID: 1301
	private Material dx11bokehMaterial;

	// Token: 0x04000516 RID: 1302
	public float dx11BokehThreshhold;

	// Token: 0x04000517 RID: 1303
	public float dx11SpawnHeuristic;

	// Token: 0x04000518 RID: 1304
	public Texture2D dx11BokehTexture;

	// Token: 0x04000519 RID: 1305
	public float dx11BokehScale;

	// Token: 0x0400051A RID: 1306
	public float dx11BokehIntensity;

	// Token: 0x0400051B RID: 1307
	private float focalDistance01;

	// Token: 0x0400051C RID: 1308
	private ComputeBuffer cbDrawArgs;

	// Token: 0x0400051D RID: 1309
	private ComputeBuffer cbPoints;

	// Token: 0x0400051E RID: 1310
	private float internalBlurWidth;

	// Token: 0x020000CC RID: 204
	[Serializable]
	public enum BlurType
	{
		// Token: 0x04000520 RID: 1312
		DiscBlur,
		// Token: 0x04000521 RID: 1313
		DX11
	}

	// Token: 0x020000CD RID: 205
	[Serializable]
	public enum BlurSampleCount
	{
		// Token: 0x04000523 RID: 1315
		Low,
		// Token: 0x04000524 RID: 1316
		Medium,
		// Token: 0x04000525 RID: 1317
		High
	}
}
