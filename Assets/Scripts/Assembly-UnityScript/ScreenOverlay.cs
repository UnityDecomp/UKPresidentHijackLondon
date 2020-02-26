using System;
using UnityEngine;

// Token: 0x020000DA RID: 218
[AddComponentMenu("Image Effects/Other/Screen Overlay")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[Serializable]
public class ScreenOverlay : PostEffectsBase
{
	// Token: 0x060002FC RID: 764 RVA: 0x0002570C File Offset: 0x0002390C
	public ScreenOverlay()
	{
		this.blendMode = ScreenOverlay.OverlayBlendMode.Overlay;
		this.intensity = 1f;
	}

	// Token: 0x060002FD RID: 765 RVA: 0x00025728 File Offset: 0x00023928
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.overlayMaterial = this.CheckShaderAndCreateMaterial(this.overlayShader, this.overlayMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002FE RID: 766 RVA: 0x00025764 File Offset: 0x00023964
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			this.overlayMaterial.SetFloat("_Intensity", this.intensity);
			this.overlayMaterial.SetTexture("_Overlay", this.texture);
			Graphics.Blit(source, destination, this.overlayMaterial, (int)this.blendMode);
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x000257C8 File Offset: 0x000239C8
	public override void Main()
	{
	}

	// Token: 0x04000571 RID: 1393
	public ScreenOverlay.OverlayBlendMode blendMode;

	// Token: 0x04000572 RID: 1394
	public float intensity;

	// Token: 0x04000573 RID: 1395
	public Texture2D texture;

	// Token: 0x04000574 RID: 1396
	public Shader overlayShader;

	// Token: 0x04000575 RID: 1397
	private Material overlayMaterial;

	// Token: 0x020000DB RID: 219
	[Serializable]
	public enum OverlayBlendMode
	{
		// Token: 0x04000577 RID: 1399
		Additive,
		// Token: 0x04000578 RID: 1400
		ScreenBlend,
		// Token: 0x04000579 RID: 1401
		Multiply,
		// Token: 0x0400057A RID: 1402
		Overlay,
		// Token: 0x0400057B RID: 1403
		AlphaBlend
	}
}
