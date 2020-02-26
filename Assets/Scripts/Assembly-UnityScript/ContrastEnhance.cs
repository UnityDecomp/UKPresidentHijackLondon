using System;
using UnityEngine;

// Token: 0x020000C4 RID: 196
[AddComponentMenu("Image Effects/Color Adjustments/Contrast Enhance (Unsharp Mask)")]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[Serializable]
public class ContrastEnhance : PostEffectsBase
{
	// Token: 0x060002A0 RID: 672 RVA: 0x00021430 File Offset: 0x0001F630
	public ContrastEnhance()
	{
		this.intensity = 0.5f;
		this.blurSpread = 1f;
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00021450 File Offset: 0x0001F650
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.contrastCompositeMaterial = this.CheckShaderAndCreateMaterial(this.contrastCompositeShader, this.contrastCompositeMaterial);
		this.separableBlurMaterial = this.CheckShaderAndCreateMaterial(this.separableBlurShader, this.separableBlurMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x000214AC File Offset: 0x0001F6AC
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
			RenderTexture temporary = RenderTexture.GetTemporary(width / 2, height / 2, 0);
			Graphics.Blit(source, temporary);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width / 4, height / 4, 0);
			Graphics.Blit(temporary, temporary2);
			RenderTexture.ReleaseTemporary(temporary);
			this.separableBlurMaterial.SetVector("offsets", new Vector4((float)0, this.blurSpread * 1f / (float)temporary2.height, (float)0, (float)0));
			RenderTexture temporary3 = RenderTexture.GetTemporary(width / 4, height / 4, 0);
			Graphics.Blit(temporary2, temporary3, this.separableBlurMaterial);
			RenderTexture.ReleaseTemporary(temporary2);
			this.separableBlurMaterial.SetVector("offsets", new Vector4(this.blurSpread * 1f / (float)temporary2.width, (float)0, (float)0, (float)0));
			temporary2 = RenderTexture.GetTemporary(width / 4, height / 4, 0);
			Graphics.Blit(temporary3, temporary2, this.separableBlurMaterial);
			RenderTexture.ReleaseTemporary(temporary3);
			this.contrastCompositeMaterial.SetTexture("_MainTexBlurred", temporary2);
			this.contrastCompositeMaterial.SetFloat("intensity", this.intensity);
			this.contrastCompositeMaterial.SetFloat("threshhold", this.threshhold);
			Graphics.Blit(source, destination, this.contrastCompositeMaterial);
			RenderTexture.ReleaseTemporary(temporary2);
		}
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x00021600 File Offset: 0x0001F800
	public override void Main()
	{
	}

	// Token: 0x040004BE RID: 1214
	public float intensity;

	// Token: 0x040004BF RID: 1215
	public float threshhold;

	// Token: 0x040004C0 RID: 1216
	private Material separableBlurMaterial;

	// Token: 0x040004C1 RID: 1217
	private Material contrastCompositeMaterial;

	// Token: 0x040004C2 RID: 1218
	public float blurSpread;

	// Token: 0x040004C3 RID: 1219
	public Shader separableBlurShader;

	// Token: 0x040004C4 RID: 1220
	public Shader contrastCompositeShader;
}
