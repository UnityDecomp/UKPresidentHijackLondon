using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Bloom and Glow/Bloom")]
[ExecuteInEditMode]
[Serializable]
public class Bloom : PostEffectsBase
{
	// Token: 0x0600026C RID: 620 RVA: 0x0001E620 File Offset: 0x0001C820
	public Bloom()
	{
		this.screenBlendMode = Bloom.BloomScreenBlendMode.Add;
		this.hdr = Bloom.HDRBloomMode.Auto;
		this.sepBlurSpread = 2.5f;
		this.quality = Bloom.BloomQuality.High;
		this.bloomIntensity = 0.5f;
		this.bloomThreshhold = 0.5f;
		this.bloomThreshholdColor = Color.white;
		this.bloomBlurIterations = 2;
		this.hollywoodFlareBlurIterations = 2;
		this.lensflareMode = Bloom.LensFlareStyle.Anamorphic;
		this.hollyStretchWidth = 2.5f;
		this.lensflareThreshhold = 0.3f;
		this.lensFlareSaturation = 0.75f;
		this.flareColorA = new Color(0.4f, 0.4f, 0.8f, 0.75f);
		this.flareColorB = new Color(0.4f, 0.8f, 0.8f, 0.75f);
		this.flareColorC = new Color(0.8f, 0.4f, 0.8f, 0.75f);
		this.flareColorD = new Color(0.8f, 0.4f, (float)0, 0.75f);
		this.blurWidth = 1f;
	}

	// Token: 0x0600026D RID: 621 RVA: 0x0001E730 File Offset: 0x0001C930
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.screenBlend = this.CheckShaderAndCreateMaterial(this.screenBlendShader, this.screenBlend);
		this.lensFlareMaterial = this.CheckShaderAndCreateMaterial(this.lensFlareShader, this.lensFlareMaterial);
		this.blurAndFlaresMaterial = this.CheckShaderAndCreateMaterial(this.blurAndFlaresShader, this.blurAndFlaresMaterial);
		this.brightPassFilterMaterial = this.CheckShaderAndCreateMaterial(this.brightPassFilterShader, this.brightPassFilterMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x0600026E RID: 622 RVA: 0x0001E7BC File Offset: 0x0001C9BC
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			this.doHdr = false;
			if (this.hdr == Bloom.HDRBloomMode.Auto)
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
				this.doHdr = (this.hdr == Bloom.HDRBloomMode.On);
			}
			bool supportHDRTextures;
			if (supportHDRTextures = this.doHdr)
			{
				supportHDRTextures = this.supportHDRTextures;
			}
			this.doHdr = supportHDRTextures;
			Bloom.BloomScreenBlendMode bloomScreenBlendMode = this.screenBlendMode;
			if (this.doHdr)
			{
				bloomScreenBlendMode = Bloom.BloomScreenBlendMode.Add;
			}
			RenderTextureFormat format = (!this.doHdr) ? RenderTextureFormat.Default : RenderTextureFormat.ARGBHalf;
			int width = source.width / 2;
			int height = source.height / 2;
			int width2 = source.width / 4;
			int height2 = source.height / 4;
			float num = 1f * (float)source.width / (1f * (float)source.height);
			float num2 = 0.001953125f;
			RenderTexture temporary = RenderTexture.GetTemporary(width2, height2, 0, format);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0, format);
			if (this.quality > Bloom.BloomQuality.Cheap)
			{
				Graphics.Blit(source, temporary2, this.screenBlend, 2);
				RenderTexture temporary3 = RenderTexture.GetTemporary(width2, height2, 0, format);
				Graphics.Blit(temporary2, temporary3, this.screenBlend, 2);
				Graphics.Blit(temporary3, temporary, this.screenBlend, 6);
				RenderTexture.ReleaseTemporary(temporary3);
			}
			else
			{
				Graphics.Blit(source, temporary2);
				Graphics.Blit(temporary2, temporary, this.screenBlend, 6);
			}
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture renderTexture = RenderTexture.GetTemporary(width2, height2, 0, format);
			this.BrightFilter(this.bloomThreshhold * this.bloomThreshholdColor, temporary, renderTexture);
			if (this.bloomBlurIterations < 1)
			{
				this.bloomBlurIterations = 1;
			}
			else if (this.bloomBlurIterations > 10)
			{
				this.bloomBlurIterations = 10;
			}
			for (int i = 0; i < this.bloomBlurIterations; i++)
			{
				float num3 = (1f + (float)i * 0.25f) * this.sepBlurSpread;
				RenderTexture temporary4 = RenderTexture.GetTemporary(width2, height2, 0, format);
				this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4((float)0, num3 * num2, (float)0, (float)0));
				Graphics.Blit(renderTexture, temporary4, this.blurAndFlaresMaterial, 4);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary4;
				temporary4 = RenderTexture.GetTemporary(width2, height2, 0, format);
				this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num3 / num * num2, (float)0, (float)0, (float)0));
				Graphics.Blit(renderTexture, temporary4, this.blurAndFlaresMaterial, 4);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary4;
				if (this.quality > Bloom.BloomQuality.Cheap)
				{
					if (i == 0)
					{
						Graphics.SetRenderTarget(temporary);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(renderTexture, temporary);
					}
					else
					{
						temporary.MarkRestoreExpected();
						Graphics.Blit(renderTexture, temporary, this.screenBlend, 10);
					}
				}
			}
			if (this.quality > Bloom.BloomQuality.Cheap)
			{
				Graphics.SetRenderTarget(renderTexture);
				GL.Clear(false, true, Color.black);
				Graphics.Blit(temporary, renderTexture, this.screenBlend, 6);
			}
			if (this.lensflareIntensity > Mathf.Epsilon)
			{
				RenderTexture temporary5 = RenderTexture.GetTemporary(width2, height2, 0, format);
				if (this.lensflareMode == Bloom.LensFlareStyle.Ghosting)
				{
					this.BrightFilter(this.lensflareThreshhold, renderTexture, temporary5);
					if (this.quality > Bloom.BloomQuality.Cheap)
					{
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4((float)0, 1.5f / (1f * (float)temporary.height), (float)0, (float)0));
						Graphics.SetRenderTarget(temporary);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 4);
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(1.5f / (1f * (float)temporary.width), (float)0, (float)0, (float)0));
						Graphics.SetRenderTarget(temporary5);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 4);
					}
					this.Vignette(0.975f, temporary5, temporary5);
					this.BlendFlares(temporary5, renderTexture);
				}
				else
				{
					float num4 = 1f * Mathf.Cos(this.flareRotation);
					float num5 = 1f * Mathf.Sin(this.flareRotation);
					float num6 = this.hollyStretchWidth * 1f / num * num2;
					float num7 = this.hollyStretchWidth * num2;
					this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num4, num5, (float)0, (float)0));
					this.blurAndFlaresMaterial.SetVector("_Threshhold", new Vector4(this.lensflareThreshhold, 1f, (float)0, (float)0));
					this.blurAndFlaresMaterial.SetVector("_TintColor", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.flareColorA.a * this.lensflareIntensity);
					this.blurAndFlaresMaterial.SetFloat("_Saturation", this.lensFlareSaturation);
					temporary.DiscardContents();
					Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 2);
					temporary5.DiscardContents();
					Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 3);
					this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num4 * num6, num5 * num6, (float)0, (float)0));
					this.blurAndFlaresMaterial.SetFloat("_StretchWidth", this.hollyStretchWidth);
					temporary.DiscardContents();
					Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 1);
					this.blurAndFlaresMaterial.SetFloat("_StretchWidth", this.hollyStretchWidth * 2f);
					temporary5.DiscardContents();
					Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 1);
					this.blurAndFlaresMaterial.SetFloat("_StretchWidth", this.hollyStretchWidth * 4f);
					temporary.DiscardContents();
					Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 1);
					for (int i = 0; i < this.hollywoodFlareBlurIterations; i++)
					{
						num6 = this.hollyStretchWidth * 2f / num * num2;
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num6 * num4, num6 * num5, (float)0, (float)0));
						temporary5.DiscardContents();
						Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 4);
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num6 * num4, num6 * num5, (float)0, (float)0));
						temporary.DiscardContents();
						Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 4);
					}
					if (this.lensflareMode == Bloom.LensFlareStyle.Anamorphic)
					{
						this.AddTo(1f, temporary, renderTexture);
					}
					else
					{
						this.Vignette(1f, temporary, temporary5);
						this.BlendFlares(temporary5, temporary);
						this.AddTo(1f, temporary, renderTexture);
					}
				}
				RenderTexture.ReleaseTemporary(temporary5);
			}
			int pass = (int)bloomScreenBlendMode;
			this.screenBlend.SetFloat("_Intensity", this.bloomIntensity);
			this.screenBlend.SetTexture("_ColorBuffer", source);
			if (this.quality > Bloom.BloomQuality.Cheap)
			{
				RenderTexture temporary6 = RenderTexture.GetTemporary(width, height, 0, format);
				Graphics.Blit(renderTexture, temporary6);
				Graphics.Blit(temporary6, destination, this.screenBlend, pass);
				RenderTexture.ReleaseTemporary(temporary6);
			}
			else
			{
				Graphics.Blit(renderTexture, destination, this.screenBlend, pass);
			}
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(renderTexture);
		}
	}

	// Token: 0x0600026F RID: 623 RVA: 0x0001EF2C File Offset: 0x0001D12C
	private void AddTo(float intensity_, RenderTexture from, RenderTexture to)
	{
		this.screenBlend.SetFloat("_Intensity", intensity_);
		to.MarkRestoreExpected();
		Graphics.Blit(from, to, this.screenBlend, 9);
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0001EF60 File Offset: 0x0001D160
	private void BlendFlares(RenderTexture from, RenderTexture to)
	{
		this.lensFlareMaterial.SetVector("colorA", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.lensflareIntensity);
		this.lensFlareMaterial.SetVector("colorB", new Vector4(this.flareColorB.r, this.flareColorB.g, this.flareColorB.b, this.flareColorB.a) * this.lensflareIntensity);
		this.lensFlareMaterial.SetVector("colorC", new Vector4(this.flareColorC.r, this.flareColorC.g, this.flareColorC.b, this.flareColorC.a) * this.lensflareIntensity);
		this.lensFlareMaterial.SetVector("colorD", new Vector4(this.flareColorD.r, this.flareColorD.g, this.flareColorD.b, this.flareColorD.a) * this.lensflareIntensity);
		to.MarkRestoreExpected();
		Graphics.Blit(from, to, this.lensFlareMaterial);
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0001F0B0 File Offset: 0x0001D2B0
	private void BrightFilter(float thresh, RenderTexture from, RenderTexture to)
	{
		this.brightPassFilterMaterial.SetVector("_Threshhold", new Vector4(thresh, thresh, thresh, thresh));
		Graphics.Blit(from, to, this.brightPassFilterMaterial, 0);
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0001F0DC File Offset: 0x0001D2DC
	private void BrightFilter(Color threshColor, RenderTexture from, RenderTexture to)
	{
		this.brightPassFilterMaterial.SetVector("_Threshhold", threshColor);
		Graphics.Blit(from, to, this.brightPassFilterMaterial, 1);
	}

	// Token: 0x06000273 RID: 627 RVA: 0x0001F110 File Offset: 0x0001D310
	private void Vignette(float amount, RenderTexture from, RenderTexture to)
	{
		if (this.lensFlareVignetteMask)
		{
			this.screenBlend.SetTexture("_ColorBuffer", this.lensFlareVignetteMask);
			to.MarkRestoreExpected();
			Graphics.Blit((!(from == to)) ? from : null, to, this.screenBlend, (!(from == to)) ? 3 : 7);
		}
		else if (from != to)
		{
			Graphics.SetRenderTarget(to);
			GL.Clear(false, true, Color.black);
			Graphics.Blit(from, to);
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0001F1A8 File Offset: 0x0001D3A8
	public override void Main()
	{
	}

	// Token: 0x04000411 RID: 1041
	public Bloom.TweakMode tweakMode;

	// Token: 0x04000412 RID: 1042
	public Bloom.BloomScreenBlendMode screenBlendMode;

	// Token: 0x04000413 RID: 1043
	public Bloom.HDRBloomMode hdr;

	// Token: 0x04000414 RID: 1044
	private bool doHdr;

	// Token: 0x04000415 RID: 1045
	public float sepBlurSpread;

	// Token: 0x04000416 RID: 1046
	public Bloom.BloomQuality quality;

	// Token: 0x04000417 RID: 1047
	public float bloomIntensity;

	// Token: 0x04000418 RID: 1048
	public float bloomThreshhold;

	// Token: 0x04000419 RID: 1049
	public Color bloomThreshholdColor;

	// Token: 0x0400041A RID: 1050
	public int bloomBlurIterations;

	// Token: 0x0400041B RID: 1051
	public int hollywoodFlareBlurIterations;

	// Token: 0x0400041C RID: 1052
	public float flareRotation;

	// Token: 0x0400041D RID: 1053
	public Bloom.LensFlareStyle lensflareMode;

	// Token: 0x0400041E RID: 1054
	public float hollyStretchWidth;

	// Token: 0x0400041F RID: 1055
	public float lensflareIntensity;

	// Token: 0x04000420 RID: 1056
	public float lensflareThreshhold;

	// Token: 0x04000421 RID: 1057
	public float lensFlareSaturation;

	// Token: 0x04000422 RID: 1058
	public Color flareColorA;

	// Token: 0x04000423 RID: 1059
	public Color flareColorB;

	// Token: 0x04000424 RID: 1060
	public Color flareColorC;

	// Token: 0x04000425 RID: 1061
	public Color flareColorD;

	// Token: 0x04000426 RID: 1062
	public float blurWidth;

	// Token: 0x04000427 RID: 1063
	public Texture2D lensFlareVignetteMask;

	// Token: 0x04000428 RID: 1064
	public Shader lensFlareShader;

	// Token: 0x04000429 RID: 1065
	private Material lensFlareMaterial;

	// Token: 0x0400042A RID: 1066
	public Shader screenBlendShader;

	// Token: 0x0400042B RID: 1067
	private Material screenBlend;

	// Token: 0x0400042C RID: 1068
	public Shader blurAndFlaresShader;

	// Token: 0x0400042D RID: 1069
	private Material blurAndFlaresMaterial;

	// Token: 0x0400042E RID: 1070
	public Shader brightPassFilterShader;

	// Token: 0x0400042F RID: 1071
	private Material brightPassFilterMaterial;

	// Token: 0x020000B3 RID: 179
	[Serializable]
	public enum LensFlareStyle
	{
		// Token: 0x04000431 RID: 1073
		Ghosting,
		// Token: 0x04000432 RID: 1074
		Anamorphic,
		// Token: 0x04000433 RID: 1075
		Combined
	}

	// Token: 0x020000B4 RID: 180
	[Serializable]
	public enum TweakMode
	{
		// Token: 0x04000435 RID: 1077
		Basic,
		// Token: 0x04000436 RID: 1078
		Complex
	}

	// Token: 0x020000B5 RID: 181
	[Serializable]
	public enum HDRBloomMode
	{
		// Token: 0x04000438 RID: 1080
		Auto,
		// Token: 0x04000439 RID: 1081
		On,
		// Token: 0x0400043A RID: 1082
		Off
	}

	// Token: 0x020000B6 RID: 182
	[Serializable]
	public enum BloomScreenBlendMode
	{
		// Token: 0x0400043C RID: 1084
		Screen,
		// Token: 0x0400043D RID: 1085
		Add
	}

	// Token: 0x020000B7 RID: 183
	[Serializable]
	public enum BloomQuality
	{
		// Token: 0x0400043F RID: 1087
		Cheap,
		// Token: 0x04000440 RID: 1088
		High
	}
}
