using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x020001AD RID: 429
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Camera/Vignette and Chromatic Aberration")]
	public class VignetteAndChromaticAberration : PostEffectsBase
	{
		// Token: 0x06000BBD RID: 3005 RVA: 0x00049DE0 File Offset: 0x000481E0
		public override bool CheckResources()
		{
			base.CheckSupport(false);
			this.m_VignetteMaterial = base.CheckShaderAndCreateMaterial(this.vignetteShader, this.m_VignetteMaterial);
			this.m_SeparableBlurMaterial = base.CheckShaderAndCreateMaterial(this.separableBlurShader, this.m_SeparableBlurMaterial);
			this.m_ChromAberrationMaterial = base.CheckShaderAndCreateMaterial(this.chromAberrationShader, this.m_ChromAberrationMaterial);
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00049E54 File Offset: 0x00048254
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			int width = source.width;
			int height = source.height;
			bool flag = Mathf.Abs(this.blur) > 0f || Mathf.Abs(this.intensity) > 0f;
			float num = 1f * (float)width / (1f * (float)height);
			RenderTexture renderTexture = null;
			RenderTexture renderTexture2 = null;
			if (flag)
			{
				renderTexture = RenderTexture.GetTemporary(width, height, 0, source.format);
				if (Mathf.Abs(this.blur) > 0f)
				{
					renderTexture2 = RenderTexture.GetTemporary(width / 2, height / 2, 0, source.format);
					Graphics.Blit(source, renderTexture2, this.m_ChromAberrationMaterial, 0);
					for (int i = 0; i < 2; i++)
					{
						this.m_SeparableBlurMaterial.SetVector("offsets", new Vector4(0f, this.blurSpread * 0.001953125f, 0f, 0f));
						RenderTexture temporary = RenderTexture.GetTemporary(width / 2, height / 2, 0, source.format);
						Graphics.Blit(renderTexture2, temporary, this.m_SeparableBlurMaterial);
						RenderTexture.ReleaseTemporary(renderTexture2);
						this.m_SeparableBlurMaterial.SetVector("offsets", new Vector4(this.blurSpread * 0.001953125f / num, 0f, 0f, 0f));
						renderTexture2 = RenderTexture.GetTemporary(width / 2, height / 2, 0, source.format);
						Graphics.Blit(temporary, renderTexture2, this.m_SeparableBlurMaterial);
						RenderTexture.ReleaseTemporary(temporary);
					}
				}
				this.m_VignetteMaterial.SetFloat("_Intensity", 1f / (1f - this.intensity) - 1f);
				this.m_VignetteMaterial.SetFloat("_Blur", 1f / (1f - this.blur) - 1f);
				this.m_VignetteMaterial.SetTexture("_VignetteTex", renderTexture2);
				Graphics.Blit(source, renderTexture, this.m_VignetteMaterial, 0);
			}
			this.m_ChromAberrationMaterial.SetFloat("_ChromaticAberration", this.chromaticAberration);
			this.m_ChromAberrationMaterial.SetFloat("_AxialAberration", this.axialAberration);
			this.m_ChromAberrationMaterial.SetVector("_BlurDistance", new Vector2(-this.blurDistance, this.blurDistance));
			this.m_ChromAberrationMaterial.SetFloat("_Luminance", 1f / Mathf.Max(Mathf.Epsilon, this.luminanceDependency));
			if (flag)
			{
				renderTexture.wrapMode = TextureWrapMode.Clamp;
			}
			else
			{
				source.wrapMode = TextureWrapMode.Clamp;
			}
			Graphics.Blit((!flag) ? source : renderTexture, destination, this.m_ChromAberrationMaterial, (this.mode != VignetteAndChromaticAberration.AberrationMode.Advanced) ? 1 : 2);
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture.ReleaseTemporary(renderTexture2);
		}

		// Token: 0x04000BDA RID: 3034
		public VignetteAndChromaticAberration.AberrationMode mode;

		// Token: 0x04000BDB RID: 3035
		public float intensity = 0.036f;

		// Token: 0x04000BDC RID: 3036
		public float chromaticAberration = 0.2f;

		// Token: 0x04000BDD RID: 3037
		public float axialAberration = 0.5f;

		// Token: 0x04000BDE RID: 3038
		public float blur;

		// Token: 0x04000BDF RID: 3039
		public float blurSpread = 0.75f;

		// Token: 0x04000BE0 RID: 3040
		public float luminanceDependency = 0.25f;

		// Token: 0x04000BE1 RID: 3041
		public float blurDistance = 2.5f;

		// Token: 0x04000BE2 RID: 3042
		public Shader vignetteShader;

		// Token: 0x04000BE3 RID: 3043
		public Shader separableBlurShader;

		// Token: 0x04000BE4 RID: 3044
		public Shader chromAberrationShader;

		// Token: 0x04000BE5 RID: 3045
		private Material m_VignetteMaterial;

		// Token: 0x04000BE6 RID: 3046
		private Material m_SeparableBlurMaterial;

		// Token: 0x04000BE7 RID: 3047
		private Material m_ChromAberrationMaterial;

		// Token: 0x020001AE RID: 430
		public enum AberrationMode
		{
			// Token: 0x04000BE9 RID: 3049
			Simple,
			// Token: 0x04000BEA RID: 3050
			Advanced
		}
	}
}
