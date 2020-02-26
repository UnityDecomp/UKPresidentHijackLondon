using System;
using UnityEngine;

// Token: 0x020000DF RID: 223
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Camera/Tilt Shift (Lens Blur)")]
[ExecuteInEditMode]
[Serializable]
public class TiltShiftHdr : PostEffectsBase
{
	// Token: 0x06000304 RID: 772 RVA: 0x00025C64 File Offset: 0x00023E64
	public TiltShiftHdr()
	{
		this.mode = TiltShiftHdr.TiltShiftMode.TiltShiftMode;
		this.quality = TiltShiftHdr.TiltShiftQuality.Normal;
		this.blurArea = 1f;
		this.maxBlurSize = 5f;
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00025C9C File Offset: 0x00023E9C
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.tiltShiftMaterial = this.CheckShaderAndCreateMaterial(this.tiltShiftShader, this.tiltShiftMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000306 RID: 774 RVA: 0x00025CD8 File Offset: 0x00023ED8
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			this.tiltShiftMaterial.SetFloat("_BlurSize", (this.maxBlurSize >= (float)0) ? this.maxBlurSize : ((float)0));
			this.tiltShiftMaterial.SetFloat("_BlurArea", this.blurArea);
			source.filterMode = FilterMode.Bilinear;
			RenderTexture renderTexture = destination;
			if (this.downsample != 0)
			{
				renderTexture = RenderTexture.GetTemporary(source.width >> this.downsample, source.height >> this.downsample, 0, source.format);
				renderTexture.filterMode = FilterMode.Bilinear;
			}
			int num = (int)this.quality;
			num *= 2;
			Graphics.Blit(source, renderTexture, this.tiltShiftMaterial, (this.mode != TiltShiftHdr.TiltShiftMode.TiltShiftMode) ? (num + 1) : num);
			if (this.downsample != 0)
			{
				this.tiltShiftMaterial.SetTexture("_Blurred", renderTexture);
				Graphics.Blit(source, destination, this.tiltShiftMaterial, 6);
			}
			if (renderTexture != destination)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
			}
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x00025DE8 File Offset: 0x00023FE8
	public override void Main()
	{
	}

	// Token: 0x04000591 RID: 1425
	public TiltShiftHdr.TiltShiftMode mode;

	// Token: 0x04000592 RID: 1426
	public TiltShiftHdr.TiltShiftQuality quality;

	// Token: 0x04000593 RID: 1427
	[Range(0f, 15f)]
	public float blurArea;

	// Token: 0x04000594 RID: 1428
	[Range(0f, 25f)]
	public float maxBlurSize;

	// Token: 0x04000595 RID: 1429
	[Range(0f, 1f)]
	public int downsample;

	// Token: 0x04000596 RID: 1430
	public Shader tiltShiftShader;

	// Token: 0x04000597 RID: 1431
	private Material tiltShiftMaterial;

	// Token: 0x020000E0 RID: 224
	[Serializable]
	public enum TiltShiftMode
	{
		// Token: 0x04000599 RID: 1433
		TiltShiftMode,
		// Token: 0x0400059A RID: 1434
		IrisMode
	}

	// Token: 0x020000E1 RID: 225
	[Serializable]
	public enum TiltShiftQuality
	{
		// Token: 0x0400059C RID: 1436
		Preview,
		// Token: 0x0400059D RID: 1437
		Normal,
		// Token: 0x0400059E RID: 1438
		High
	}
}
