using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000177 RID: 375
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Bloom and Glow/BloomAndFlares (3.5, Deprecated)")]
	public class BloomAndFlares : PostEffectsBase
	{
		// Token: 0x06000AFB RID: 2811 RVA: 0x0004162C File Offset: 0x0003FA2C
		public override bool CheckResources()
		{
			base.CheckSupport(false);
			this.screenBlend = base.CheckShaderAndCreateMaterial(this.screenBlendShader, this.screenBlend);
			this.lensFlareMaterial = base.CheckShaderAndCreateMaterial(this.lensFlareShader, this.lensFlareMaterial);
			this.vignetteMaterial = base.CheckShaderAndCreateMaterial(this.vignetteShader, this.vignetteMaterial);
			this.separableBlurMaterial = base.CheckShaderAndCreateMaterial(this.separableBlurShader, this.separableBlurMaterial);
			this.addBrightStuffBlendOneOneMaterial = base.CheckShaderAndCreateMaterial(this.addBrightStuffOneOneShader, this.addBrightStuffBlendOneOneMaterial);
			this.hollywoodFlaresMaterial = base.CheckShaderAndCreateMaterial(this.hollywoodFlaresShader, this.hollywoodFlaresMaterial);
			this.brightPassFilterMaterial = base.CheckShaderAndCreateMaterial(this.brightPassFilterShader, this.brightPassFilterMaterial);
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00041700 File Offset: 0x0003FB00
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			this.doHdr = false;
			if (this.hdr == HDRBloomMode.Auto)
			{
				this.doHdr = (source.format == RenderTextureFormat.ARGBHalf && base.GetComponent<Camera>().allowHDR);
			}
			else
			{
				this.doHdr = (this.hdr == HDRBloomMode.On);
			}
			this.doHdr = (this.doHdr && this.supportHDRTextures);
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
			this.BrightFilter(this.bloomThreshold, this.useSrcAlphaAsMask, temporary2, temporary3);
			temporary2.DiscardContents();
			if (this.bloomBlurIterations < 1)
			{
				this.bloomBlurIterations = 1;
			}
			for (int i = 0; i < this.bloomBlurIterations; i++)
			{
				float num3 = (1f + (float)i * 0.5f) * this.sepBlurSpread;
				this.separableBlurMaterial.SetVector("offsets", new Vector4(0f, num3 * num2, 0f, 0f));
				RenderTexture renderTexture = (i != 0) ? temporary2 : temporary3;
				Graphics.Blit(renderTexture, temporary4, this.separableBlurMaterial);
				renderTexture.DiscardContents();
				this.separableBlurMaterial.SetVector("offsets", new Vector4(num3 / num * num2, 0f, 0f, 0f));
				Graphics.Blit(temporary4, temporary2, this.separableBlurMaterial);
				temporary4.DiscardContents();
			}
			if (this.lensflares)
			{
				if (this.lensflareMode == LensflareStyle34.Ghosting)
				{
					this.BrightFilter(this.lensflareThreshold, 0f, temporary2, temporary4);
					temporary2.DiscardContents();
					this.Vignette(0.975f, temporary4, temporary3);
					temporary4.DiscardContents();
					this.BlendFlares(temporary3, temporary2);
					temporary3.DiscardContents();
				}
				else
				{
					this.hollywoodFlaresMaterial.SetVector("_threshold", new Vector4(this.lensflareThreshold, 1f / (1f - this.lensflareThreshold), 0f, 0f));
					this.hollywoodFlaresMaterial.SetVector("tintColor", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.flareColorA.a * this.lensflareIntensity);
					Graphics.Blit(temporary4, temporary3, this.hollywoodFlaresMaterial, 2);
					temporary4.DiscardContents();
					Graphics.Blit(temporary3, temporary4, this.hollywoodFlaresMaterial, 3);
					temporary3.DiscardContents();
					this.hollywoodFlaresMaterial.SetVector("offsets", new Vector4(this.sepBlurSpread * 1f / num * num2, 0f, 0f, 0f));
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
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, 0f, 0f, 0f));
							Graphics.Blit(temporary3, temporary4, this.separableBlurMaterial);
							temporary3.DiscardContents();
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, 0f, 0f, 0f));
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
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, 0f, 0f, 0f));
							Graphics.Blit(temporary3, temporary4, this.separableBlurMaterial);
							temporary3.DiscardContents();
							this.separableBlurMaterial.SetVector("offsets", new Vector4(this.hollyStretchWidth * 2f / num * num2, 0f, 0f, 0f));
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

		// Token: 0x06000AFD RID: 2813 RVA: 0x00041D37 File Offset: 0x00040137
		private void AddTo(float intensity_, RenderTexture from, RenderTexture to)
		{
			this.addBrightStuffBlendOneOneMaterial.SetFloat("_Intensity", intensity_);
			Graphics.Blit(from, to, this.addBrightStuffBlendOneOneMaterial);
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00041D58 File Offset: 0x00040158
		private void BlendFlares(RenderTexture from, RenderTexture to)
		{
			this.lensFlareMaterial.SetVector("colorA", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.lensflareIntensity);
			this.lensFlareMaterial.SetVector("colorB", new Vector4(this.flareColorB.r, this.flareColorB.g, this.flareColorB.b, this.flareColorB.a) * this.lensflareIntensity);
			this.lensFlareMaterial.SetVector("colorC", new Vector4(this.flareColorC.r, this.flareColorC.g, this.flareColorC.b, this.flareColorC.a) * this.lensflareIntensity);
			this.lensFlareMaterial.SetVector("colorD", new Vector4(this.flareColorD.r, this.flareColorD.g, this.flareColorD.b, this.flareColorD.a) * this.lensflareIntensity);
			Graphics.Blit(from, to, this.lensFlareMaterial);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00041EA4 File Offset: 0x000402A4
		private void BrightFilter(float thresh, float useAlphaAsMask, RenderTexture from, RenderTexture to)
		{
			if (this.doHdr)
			{
				this.brightPassFilterMaterial.SetVector("threshold", new Vector4(thresh, 1f, 0f, 0f));
			}
			else
			{
				this.brightPassFilterMaterial.SetVector("threshold", new Vector4(thresh, 1f / (1f - thresh), 0f, 0f));
			}
			this.brightPassFilterMaterial.SetFloat("useSrcAlphaAsMask", useAlphaAsMask);
			Graphics.Blit(from, to, this.brightPassFilterMaterial);
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00041F34 File Offset: 0x00040334
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

		// Token: 0x04000A2D RID: 2605
		public TweakMode34 tweakMode;

		// Token: 0x04000A2E RID: 2606
		public BloomScreenBlendMode screenBlendMode = BloomScreenBlendMode.Add;

		// Token: 0x04000A2F RID: 2607
		public HDRBloomMode hdr;

		// Token: 0x04000A30 RID: 2608
		private bool doHdr;

		// Token: 0x04000A31 RID: 2609
		public float sepBlurSpread = 1.5f;

		// Token: 0x04000A32 RID: 2610
		public float useSrcAlphaAsMask = 0.5f;

		// Token: 0x04000A33 RID: 2611
		public float bloomIntensity = 1f;

		// Token: 0x04000A34 RID: 2612
		public float bloomThreshold = 0.5f;

		// Token: 0x04000A35 RID: 2613
		public int bloomBlurIterations = 2;

		// Token: 0x04000A36 RID: 2614
		public bool lensflares;

		// Token: 0x04000A37 RID: 2615
		public int hollywoodFlareBlurIterations = 2;

		// Token: 0x04000A38 RID: 2616
		public LensflareStyle34 lensflareMode = LensflareStyle34.Anamorphic;

		// Token: 0x04000A39 RID: 2617
		public float hollyStretchWidth = 3.5f;

		// Token: 0x04000A3A RID: 2618
		public float lensflareIntensity = 1f;

		// Token: 0x04000A3B RID: 2619
		public float lensflareThreshold = 0.3f;

		// Token: 0x04000A3C RID: 2620
		public Color flareColorA = new Color(0.4f, 0.4f, 0.8f, 0.75f);

		// Token: 0x04000A3D RID: 2621
		public Color flareColorB = new Color(0.4f, 0.8f, 0.8f, 0.75f);

		// Token: 0x04000A3E RID: 2622
		public Color flareColorC = new Color(0.8f, 0.4f, 0.8f, 0.75f);

		// Token: 0x04000A3F RID: 2623
		public Color flareColorD = new Color(0.8f, 0.4f, 0f, 0.75f);

		// Token: 0x04000A40 RID: 2624
		public Texture2D lensFlareVignetteMask;

		// Token: 0x04000A41 RID: 2625
		public Shader lensFlareShader;

		// Token: 0x04000A42 RID: 2626
		private Material lensFlareMaterial;

		// Token: 0x04000A43 RID: 2627
		public Shader vignetteShader;

		// Token: 0x04000A44 RID: 2628
		private Material vignetteMaterial;

		// Token: 0x04000A45 RID: 2629
		public Shader separableBlurShader;

		// Token: 0x04000A46 RID: 2630
		private Material separableBlurMaterial;

		// Token: 0x04000A47 RID: 2631
		public Shader addBrightStuffOneOneShader;

		// Token: 0x04000A48 RID: 2632
		private Material addBrightStuffBlendOneOneMaterial;

		// Token: 0x04000A49 RID: 2633
		public Shader screenBlendShader;

		// Token: 0x04000A4A RID: 2634
		private Material screenBlend;

		// Token: 0x04000A4B RID: 2635
		public Shader hollywoodFlaresShader;

		// Token: 0x04000A4C RID: 2636
		private Material hollywoodFlaresMaterial;

		// Token: 0x04000A4D RID: 2637
		public Shader brightPassFilterShader;

		// Token: 0x04000A4E RID: 2638
		private Material brightPassFilterMaterial;
	}
}
