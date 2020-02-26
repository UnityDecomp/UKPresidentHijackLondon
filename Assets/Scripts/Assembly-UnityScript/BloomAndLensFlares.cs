using System;
using UnityEngine;

// Token: 0x020000BC RID: 188
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Bloom and Glow/BloomAndFlares (3.5, Deprecated)")]
[ExecuteInEditMode]
[Serializable]
public class BloomAndLensFlares : PostEffectsBase
{
	// Token: 0x06000275 RID: 629 RVA: 0x0001F1AC File Offset: 0x0001D3AC
	public BloomAndLensFlares()
	{
		this.screenBlendMode = BloomScreenBlendMode.Add;
		this.hdr = HDRBloomMode.Auto;
		this.sepBlurSpread = 1.5f;
		this.useSrcAlphaAsMask = 0.5f;
		this.bloomIntensity = 1f;
		this.bloomThreshhold = 0.5f;
		this.bloomBlurIterations = 2;
		this.hollywoodFlareBlurIterations = 2;
		this.lensflareMode = LensflareStyle34.Anamorphic;
		this.hollyStretchWidth = 3.5f;
		this.lensflareIntensity = 1f;
		this.lensflareThreshhold = 0.3f;
		this.flareColorA = new Color(0.4f, 0.4f, 0.8f, 0.75f);
		this.flareColorB = new Color(0.4f, 0.8f, 0.8f, 0.75f);
		this.flareColorC = new Color(0.8f, 0.4f, 0.8f, 0.75f);
		this.flareColorD = new Color(0.8f, 0.4f, (float)0, 0.75f);
		this.blurWidth = 1f;
	}

	// Token: 0x06000276 RID: 630 RVA: 0x0001F2B4 File Offset: 0x0001D4B4
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.screenBlend = this.CheckShaderAndCreateMaterial(this.screenBlendShader, this.screenBlend);
		this.lensFlareMaterial = this.CheckShaderAndCreateMaterial(this.lensFlareShader, this.lensFlareMaterial);
		this.vignetteMaterial = this.CheckShaderAndCreateMaterial(this.vignetteShader, this.vignetteMaterial);
		this.separableBlurMaterial = this.CheckShaderAndCreateMaterial(this.separableBlurShader, this.separableBlurMaterial);
		this.addBrightStuffBlendOneOneMaterial = this.CheckShaderAndCreateMaterial(this.addBrightStuffOneOneShader, this.addBrightStuffBlendOneOneMaterial);
		this.hollywoodFlaresMaterial = this.CheckShaderAndCreateMaterial(this.hollywoodFlaresShader, this.hollywoodFlaresMaterial);
		this.brightPassFilterMaterial = this.CheckShaderAndCreateMaterial(this.brightPassFilterShader, this.brightPassFilterMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000277 RID: 631 RVA: 0x0001F388 File Offset: 0x0001D588
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			this.doHdr = false;
			if (this.hdr == HDRBloomMode.Auto)
			{
				bool flag;
				if (flag = (source.format == RenderTextureFormat.ARGBHalf))
				{
					flag = this.GetComponent<Camera>().hdr;
				}
				this.doHdr = flag;
			}
			else
			{
				this.doHdr = (this.hdr == HDRBloomMode.On);
			}
			bool supportHDRTextures;
			if (supportHDRTextures = this.doHdr)
			{
				supportHDRTextures = this.supportHDRTextures;
			}
			this.doHdr = supportHDRTextures;
			BloomScreenBlendMode pass = this.screenBlendMode;
			if (this.doHdr)
			{
				pass = BloomScreenBlendMode.Add;
			}
			RenderTextureFormat format = (!this.doHdr) ? RenderTextureFormat.Default : RenderTextureFormat.ARGBHalf;
			RenderTexture temporary = RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0, format);
			RenderTexture temporary2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0, format);
			RenderTexture temporary3 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0, format);
			RenderTexture temporary4 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0, format);
			float num = 1f * (float)source.width / (1f * (float)source.height);
			float num2 = 0.001953125f;
			Graphics.Blit(source, temporary, this.screenBlend, 2);
			Graphics.Blit(temporary, temporary2, this.screenBlend, 2);
			RenderTexture.ReleaseTemporary(temporary);
			this.BrightFilter(this.bloomThreshhold, this.useSrcAlphaAsMask, temporary2, temporary3);
			temporary2.DiscardContents();
			if (this.bloomBlurIterations < 1)
			{
				this.bloomBlurIterations = 1;
			}
			for (int i = 0; i < this.bloomBlurIterations; i++)
			{
				float num3 = (1f + (float)i * 0.5f) * this.sepBlurSpread;
				this.separableBlurMaterial.SetVector("offsets", new Vector4((float)0, num3 * num2, (float)0, (float)0));
				RenderTexture renderTexture = (i != 0) ? temporary2 : temporary3;
				Graphics.Blit(renderTexture, temporary4, this.separableBlurMaterial);
				renderTexture.DiscardContents();
				this.separableBlurMaterial.SetVector("offsets", new Vector4(num3 / num * num2, (float)0, (float)0, (float)0));
				Graphics.Blit(temporary4, temporary2, this.separableBlurMaterial);
				temporary4.DiscardContents();
			}
			if (this.lensflares)
			{
				if (this.lensflareMode == LensflareStyle34.Ghosting)
				{
					this.BrightFilter(this.lensflareThreshhold, (float)0, temporary2, temporary4);
					temporary2.DiscardContents();
					this.Vignette(0.975f, temporary4, temporary3);
					temporary4.DiscardContents();
					this.BlendFlares(temporary3, temporary2);
					temporary3.DiscardContents();
				}
				else
				{
					this.hollywoodFlaresMaterial.SetVector("_Threshhold", new Vector4(this.lensflareThreshhold, 1f / (1f - this.lensflareThreshhold), (float)0, (float)0));
					this.hollywoodFlaresMaterial.SetVector("tintColor", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.flareColorA.a * this.lensflareIntensity);
					Graphics.Blit(temporary4, temporary3, this.hollywoodFlaresMaterial, 2);
					temporary4.DiscardContents();
					Graphics.Blit(temporary3, temporary4, this.hollywoodFlaresMaterial, 3);
					temporary3.DiscardContents();
					this.hollywoodFlaresMaterial.SetVector("offsets", new Vector4(this.sepBlurSpread * 1f / num * num2, (float)0, (float)0, (float)0));
					this.hollywoodFlaresMaterial.SetFloat("stretchWidth", this.hollyStretchWidth);
					Graphics.Blit(temporary4, temporary3, this.hollywoodFlaresMaterial, 1);
					temporary4.DiscardContents();
					this.hollywoodFlaresMaterial.SetFloat("stretchWidth", this.hollyStretchWidth * 2f);
					Graphics.Blit(temporary3, temporary4, this.hollywoodFlaresMaterial, 1);
					temporary3.DiscardContents();
					this.hollywoodFlaresMaterial.SetFloat("stretchWidth", this.hollyStretchWidth * 4f);
					Graphics.Blit(temporary4, temporary3, this.hollywoodFlaresMaterial, 1);
					temporary4.DiscardContents();
					if (this.lensflareMode == LensflareStyle34.Anamorphic)
					{
						for (int j = 0; j < this.hollywoodFlareBlurIterations; j++)
						{
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, (float)0, (float)0, (float)0));
							Graphics.Blit(temporary3, temporary4, this.separableBlurMaterial);
							temporary3.DiscardContents();
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, (float)0, (float)0, (float)0));
							Graphics.Blit(temporary4, temporary3, this.separableBlurMaterial);
							temporary4.DiscardContents();
						}
						this.AddTo(1f, temporary3, temporary2);
						temporary3.DiscardContents();
					}
					else
					{
						for (int k = 0; k < this.hollywoodFlareBlurIterations; k++)
						{
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, (float)0, (float)0, (float)0));
							Graphics.Blit(temporary3, temporary4, this.separableBlurMaterial);
							temporary3.DiscardContents();
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, (float)0, (float)0, (float)0));
							Graphics.Blit(temporary4, temporary3, this.separableBlurMaterial);
							temporary4.DiscardContents();
						}
						this.Vignette(1f, temporary3, temporary4);
						temporary3.DiscardContents();
						this.BlendFlares(temporary4, temporary3);
						temporary4.DiscardContents();
						this.AddTo(1f, temporary3, temporary2);
						temporary3.DiscardContents();
					}
				}
			}
			this.screenBlend.SetFloat("_Intensity", this.bloomIntensity);
			this.screenBlend.SetTexture("_ColorBuffer", source);
			Graphics.Blit(temporary2, destination, this.screenBlend, (int)pass);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary3);
			RenderTexture.ReleaseTemporary(temporary4);
		}
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0001F97C File Offset: 0x0001DB7C
	private void AddTo(float intensity_, RenderTexture from, RenderTexture to)
	{
		this.addBrightStuffBlendOneOneMaterial.SetFloat("_Intensity", intensity_);
		Graphics.Blit(from, to, this.addBrightStuffBlendOneOneMaterial);
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0001F99C File Offset: 0x0001DB9C
	private void BlendFlares(RenderTexture from, RenderTexture to)
	{
		this.lensFlareMaterial.SetVector("colorA", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.lensflareIntensity);
		this.lensFlareMaterial.SetVector("colorB", new Vector4(this.flareColorB.r, this.flareColorB.g, this.flareColorB.b, this.flareColorB.a) * this.lensflareIntensity);
		this.lensFlareMaterial.SetVector("colorC", new Vector4(this.flareColorC.r, this.flareColorC.g, this.flareColorC.b, this.flareColorC.a) * this.lensflareIntensity);
		this.lensFlareMaterial.SetVector("colorD", new Vector4(this.flareColorD.r, this.flareColorD.g, this.flareColorD.b, this.flareColorD.a) * this.lensflareIntensity);
		Graphics.Blit(from, to, this.lensFlareMaterial);
	}

	// Token: 0x0600027A RID: 634 RVA: 0x0001FAE8 File Offset: 0x0001DCE8
	private void BrightFilter(float thresh, float useAlphaAsMask, RenderTexture from, RenderTexture to)
	{
		if (this.doHdr)
		{
			this.brightPassFilterMaterial.SetVector("threshhold", new Vector4(thresh, 1f, (float)0, (float)0));
		}
		else
		{
			this.brightPassFilterMaterial.SetVector("threshhold", new Vector4(thresh, 1f / (1f - thresh), (float)0, (float)0));
		}
		this.brightPassFilterMaterial.SetFloat("useSrcAlphaAsMask", useAlphaAsMask);
		Graphics.Blit(from, to, this.brightPassFilterMaterial);
	}

	// Token: 0x0600027B RID: 635 RVA: 0x0001FB70 File Offset: 0x0001DD70
	private void Vignette(float amount, RenderTexture from, RenderTexture to)
	{
		if (this.lensFlareVignetteMask)
		{
			this.screenBlend.SetTexture("_ColorBuffer", this.lensFlareVignetteMask);
			Graphics.Blit(from, to, this.screenBlend, 3);
		}
		else
		{
			this.vignetteMaterial.SetFloat("vignetteIntensity", amount);
			Graphics.Blit(from, to, this.vignetteMaterial);
		}
	}

	// Token: 0x0600027C RID: 636 RVA: 0x0001FBD4 File Offset: 0x0001DDD4
	public override void Main()
	{
	}

	// Token: 0x0400044F RID: 1103
	public TweakMode34 tweakMode;

	// Token: 0x04000450 RID: 1104
	public BloomScreenBlendMode screenBlendMode;

	// Token: 0x04000451 RID: 1105
	public HDRBloomMode hdr;

	// Token: 0x04000452 RID: 1106
	private bool doHdr;

	// Token: 0x04000453 RID: 1107
	public float sepBlurSpread;

	// Token: 0x04000454 RID: 1108
	public float useSrcAlphaAsMask;

	// Token: 0x04000455 RID: 1109
	public float bloomIntensity;

	// Token: 0x04000456 RID: 1110
	public float bloomThreshhold;

	// Token: 0x04000457 RID: 1111
	public int bloomBlurIterations;

	// Token: 0x04000458 RID: 1112
	public bool lensflares;

	// Token: 0x04000459 RID: 1113
	public int hollywoodFlareBlurIterations;

	// Token: 0x0400045A RID: 1114
	public LensflareStyle34 lensflareMode;

	// Token: 0x0400045B RID: 1115
	public float hollyStretchWidth;

	// Token: 0x0400045C RID: 1116
	public float lensflareIntensity;

	// Token: 0x0400045D RID: 1117
	public float lensflareThreshhold;

	// Token: 0x0400045E RID: 1118
	public Color flareColorA;

	// Token: 0x0400045F RID: 1119
	public Color flareColorB;

	// Token: 0x04000460 RID: 1120
	public Color flareColorC;

	// Token: 0x04000461 RID: 1121
	public Color flareColorD;

	// Token: 0x04000462 RID: 1122
	public float blurWidth;

	// Token: 0x04000463 RID: 1123
	public Texture2D lensFlareVignetteMask;

	// Token: 0x04000464 RID: 1124
	public Shader lensFlareShader;

	// Token: 0x04000465 RID: 1125
	private Material lensFlareMaterial;

	// Token: 0x04000466 RID: 1126
	public Shader vignetteShader;

	// Token: 0x04000467 RID: 1127
	private Material vignetteMaterial;

	// Token: 0x04000468 RID: 1128
	public Shader separableBlurShader;

	// Token: 0x04000469 RID: 1129
	private Material separableBlurMaterial;

	// Token: 0x0400046A RID: 1130
	public Shader addBrightStuffOneOneShader;

	// Token: 0x0400046B RID: 1131
	private Material addBrightStuffBlendOneOneMaterial;

	// Token: 0x0400046C RID: 1132
	public Shader screenBlendShader;

	// Token: 0x0400046D RID: 1133
	private Material screenBlend;

	// Token: 0x0400046E RID: 1134
	public Shader hollywoodFlaresShader;

	// Token: 0x0400046F RID: 1135
	private Material hollywoodFlaresMaterial;

	// Token: 0x04000470 RID: 1136
	public Shader brightPassFilterShader;

	// Token: 0x04000471 RID: 1137
	private Material brightPassFilterMaterial;
}
