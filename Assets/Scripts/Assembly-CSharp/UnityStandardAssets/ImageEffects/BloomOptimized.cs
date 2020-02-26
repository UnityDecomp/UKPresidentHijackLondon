using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000178 RID: 376
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Bloom and Glow/Bloom (Optimized)")]
	public class BloomOptimized : PostEffectsBase
	{
		// Token: 0x06000B02 RID: 2818 RVA: 0x00041FC8 File Offset: 0x000403C8
		public override bool CheckResources()
		{
			base.CheckSupport(false);
			this.fastBloomMaterial = base.CheckShaderAndCreateMaterial(this.fastBloomShader, this.fastBloomMaterial);
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00042001 File Offset: 0x00040401
		private void OnDisable()
		{
			if (this.fastBloomMaterial)
			{
				UnityEngine.Object.DestroyImmediate(this.fastBloomMaterial);
			}
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00042020 File Offset: 0x00040420
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			int num = (this.resolution != BloomOptimized.Resolution.Low) ? 2 : 4;
			float num2 = (this.resolution != BloomOptimized.Resolution.Low) ? 1f : 0.5f;
			this.fastBloomMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num2, 0f, this.threshold, this.intensity));
			source.filterMode = FilterMode.Bilinear;
			int width = source.width / num;
			int height = source.height / num;
			RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 0, source.format);
			renderTexture.filterMode = FilterMode.Bilinear;
			Graphics.Blit(source, renderTexture, this.fastBloomMaterial, 1);
			int num3 = (this.blurType != BloomOptimized.BlurType.Standard) ? 2 : 0;
			for (int i = 0; i < this.blurIterations; i++)
			{
				this.fastBloomMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num2 + (float)i * 1f, 0f, this.threshold, this.intensity));
				RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, source.format);
				temporary.filterMode = FilterMode.Bilinear;
				Graphics.Blit(renderTexture, temporary, this.fastBloomMaterial, 2 + num3);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
				temporary = RenderTexture.GetTemporary(width, height, 0, source.format);
				temporary.filterMode = FilterMode.Bilinear;
				Graphics.Blit(renderTexture, temporary, this.fastBloomMaterial, 3 + num3);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
			}
			this.fastBloomMaterial.SetTexture("_Bloom", renderTexture);
			Graphics.Blit(source, destination, this.fastBloomMaterial, 0);
			RenderTexture.ReleaseTemporary(renderTexture);
		}

		// Token: 0x04000A4F RID: 2639
		[Range(0f, 1.5f)]
		public float threshold = 0.25f;

		// Token: 0x04000A50 RID: 2640
		[Range(0f, 2.5f)]
		public float intensity = 0.75f;

		// Token: 0x04000A51 RID: 2641
		[Range(0.25f, 5.5f)]
		public float blurSize = 1f;

		// Token: 0x04000A52 RID: 2642
		private BloomOptimized.Resolution resolution;

		// Token: 0x04000A53 RID: 2643
		[Range(1f, 4f)]
		public int blurIterations = 1;

		// Token: 0x04000A54 RID: 2644
		public BloomOptimized.BlurType blurType;

		// Token: 0x04000A55 RID: 2645
		public Shader fastBloomShader;

		// Token: 0x04000A56 RID: 2646
		private Material fastBloomMaterial;

		// Token: 0x02000179 RID: 377
		public enum Resolution
		{
			// Token: 0x04000A58 RID: 2648
			Low,
			// Token: 0x04000A59 RID: 2649
			High
		}

		// Token: 0x0200017A RID: 378
		public enum BlurType
		{
			// Token: 0x04000A5B RID: 2651
			Standard,
			// Token: 0x04000A5C RID: 2652
			Sgx
		}
	}
}
