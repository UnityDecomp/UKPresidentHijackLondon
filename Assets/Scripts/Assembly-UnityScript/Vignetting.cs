using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Camera/Vignette and Chromatic Aberration")]
[ExecuteInEditMode]
[Serializable]
public class Vignetting : PostEffectsBase
{
	// Token: 0x06000316 RID: 790 RVA: 0x000267DC File Offset: 0x000249DC
	public Vignetting()
	{
		this.mode = Vignetting.AberrationMode.Simple;
		this.intensity = 0.375f;
		this.chromaticAberration = 0.2f;
		this.axialAberration = 0.5f;
		this.blurSpread = 0.75f;
		this.luminanceDependency = 0.25f;
		this.blurDistance = 2.5f;
	}

	// Token: 0x06000317 RID: 791 RVA: 0x00026838 File Offset: 0x00024A38
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.vignetteMaterial = this.CheckShaderAndCreateMaterial(this.vignetteShader, this.vignetteMaterial);
		this.separableBlurMaterial = this.CheckShaderAndCreateMaterial(this.separableBlurShader, this.separableBlurMaterial);
		this.chromAberrationMaterial = this.CheckShaderAndCreateMaterial(this.chromAberrationShader, this.chromAberrationMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000318 RID: 792 RVA: 0x000268AC File Offset: 0x00024AAC
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			int width = source.width;
			int height = source.height;
			bool _num = Mathf.Abs(blur) > 0f;
			if (!_num)
			{
				_num = (Mathf.Abs(intensity) > 0f);
			}
			bool flag = _num;
			float num = 1f * (float)width / (1f * (float)height);
			float num2 = 0.001953125f;
			RenderTexture renderTexture = null;
			RenderTexture renderTexture2 = null;
			if (flag)
			{
				renderTexture = RenderTexture.GetTemporary(width, height, 0, source.format);
				if (Mathf.Abs(this.blur) > (float)0)
				{
					renderTexture2 = RenderTexture.GetTemporary(width / 2, height / 2, 0, source.format);
					Graphics.Blit(source, renderTexture2, this.chromAberrationMaterial, 0);
					for (int i = 0; i < 2; i++)
					{
						this.separableBlurMaterial.SetVector("offsets", new Vector4((float)0, this.blurSpread * num2, (float)0, (float)0));
						RenderTexture temporary = RenderTexture.GetTemporary(width / 2, height / 2, 0, source.format);
						Graphics.Blit(renderTexture2, temporary, this.separableBlurMaterial);
						RenderTexture.ReleaseTemporary(renderTexture2);
						this.separableBlurMaterial.SetVector("offsets", new Vector4(this.blurSpread * num2 / num, (float)0, (float)0, (float)0));
						renderTexture2 = RenderTexture.GetTemporary(width / 2, height / 2, 0, source.format);
						Graphics.Blit(temporary, renderTexture2, this.separableBlurMaterial);
						RenderTexture.ReleaseTemporary(temporary);
					}
				}
				this.vignetteMaterial.SetFloat("_Intensity", this.intensity);
				this.vignetteMaterial.SetFloat("_Blur", this.blur);
				this.vignetteMaterial.SetTexture("_VignetteTex", renderTexture2);
				Graphics.Blit(source, renderTexture, this.vignetteMaterial, 0);
			}
			this.chromAberrationMaterial.SetFloat("_ChromaticAberration", this.chromaticAberration);
			this.chromAberrationMaterial.SetFloat("_AxialAberration", this.axialAberration);
			this.chromAberrationMaterial.SetVector("_BlurDistance", new Vector2(-this.blurDistance, this.blurDistance));
			this.chromAberrationMaterial.SetFloat("_Luminance", 1f / Mathf.Max(Mathf.Epsilon, this.luminanceDependency));
			if (flag)
			{
				renderTexture.wrapMode = TextureWrapMode.Clamp;
			}
			else
			{
				source.wrapMode = TextureWrapMode.Clamp;
			}
			Graphics.Blit((!flag) ? source : renderTexture, destination, this.chromAberrationMaterial, (this.mode != Vignetting.AberrationMode.Advanced) ? 1 : 2);
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture.ReleaseTemporary(renderTexture2);
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x00026B40 File Offset: 0x00024D40
	public override void Main()
	{
	}

	// Token: 0x040005BE RID: 1470
	public Vignetting.AberrationMode mode;

	// Token: 0x040005BF RID: 1471
	public float intensity;

	// Token: 0x040005C0 RID: 1472
	public float chromaticAberration;

	// Token: 0x040005C1 RID: 1473
	public float axialAberration;

	// Token: 0x040005C2 RID: 1474
	public float blur;

	// Token: 0x040005C3 RID: 1475
	public float blurSpread;

	// Token: 0x040005C4 RID: 1476
	public float luminanceDependency;

	// Token: 0x040005C5 RID: 1477
	public float blurDistance;

	// Token: 0x040005C6 RID: 1478
	public Shader vignetteShader;

	// Token: 0x040005C7 RID: 1479
	private Material vignetteMaterial;

	// Token: 0x040005C8 RID: 1480
	public Shader separableBlurShader;

	// Token: 0x040005C9 RID: 1481
	private Material separableBlurMaterial;

	// Token: 0x040005CA RID: 1482
	public Shader chromAberrationShader;

	// Token: 0x040005CB RID: 1483
	private Material chromAberrationMaterial;

	// Token: 0x020000E7 RID: 231
	[Serializable]
	public enum AberrationMode
	{
		// Token: 0x040005CD RID: 1485
		Simple,
		// Token: 0x040005CE RID: 1486
		Advanced
	}
}
