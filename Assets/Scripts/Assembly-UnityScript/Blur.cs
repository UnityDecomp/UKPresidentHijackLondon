using System;
using UnityEngine;

// Token: 0x020000BD RID: 189
[AddComponentMenu("Image Effects/Blur/Blur (Optimized)")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[Serializable]
public class Blur : PostEffectsBase
{
	// Token: 0x0600027D RID: 637 RVA: 0x0001FBD8 File Offset: 0x0001DDD8
	public Blur()
	{
		this.downsample = 1;
		this.blurSize = 3f;
		this.blurIterations = 2;
		this.blurType = Blur.BlurType.StandardGauss;
	}

	// Token: 0x0600027E RID: 638 RVA: 0x0001FC0C File Offset: 0x0001DE0C
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.blurMaterial = this.CheckShaderAndCreateMaterial(this.blurShader, this.blurMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x0600027F RID: 639 RVA: 0x0001FC48 File Offset: 0x0001DE48
	public virtual void OnDisable()
	{
		if (this.blurMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.blurMaterial);
		}
	}

	// Token: 0x06000280 RID: 640 RVA: 0x0001FC68 File Offset: 0x0001DE68
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			float num = 1f / (1f * (float)(1 << this.downsample));
			this.blurMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num, -this.blurSize * num, (float)0, (float)0));
			source.filterMode = FilterMode.Bilinear;
			int width = source.width >> this.downsample;
			int height = source.height >> this.downsample;
			RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 0, source.format);
			renderTexture.filterMode = FilterMode.Bilinear;
			Graphics.Blit(source, renderTexture, this.blurMaterial, 0);
			int num2 = (this.blurType != Blur.BlurType.StandardGauss) ? 2 : 0;
			for (int i = 0; i < this.blurIterations; i++)
			{
				float num3 = (float)i * 1f;
				this.blurMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num + num3, -this.blurSize * num - num3, (float)0, (float)0));
				RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, source.format);
				temporary.filterMode = FilterMode.Bilinear;
				Graphics.Blit(renderTexture, temporary, this.blurMaterial, 1 + num2);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
				temporary = RenderTexture.GetTemporary(width, height, 0, source.format);
				temporary.filterMode = FilterMode.Bilinear;
				Graphics.Blit(renderTexture, temporary, this.blurMaterial, 2 + num2);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
			}
			Graphics.Blit(renderTexture, destination);
			RenderTexture.ReleaseTemporary(renderTexture);
		}
	}

	// Token: 0x06000281 RID: 641 RVA: 0x0001FDF4 File Offset: 0x0001DFF4
	public override void Main()
	{
	}

	// Token: 0x04000472 RID: 1138
	[Range(0f, 2f)]
	public int downsample;

	// Token: 0x04000473 RID: 1139
	[Range(0f, 10f)]
	public float blurSize;

	// Token: 0x04000474 RID: 1140
	[Range(1f, 4f)]
	public int blurIterations;

	// Token: 0x04000475 RID: 1141
	public Blur.BlurType blurType;

	// Token: 0x04000476 RID: 1142
	public Shader blurShader;

	// Token: 0x04000477 RID: 1143
	private Material blurMaterial;

	// Token: 0x020000BE RID: 190
	[Serializable]
	public enum BlurType
	{
		// Token: 0x04000479 RID: 1145
		StandardGauss,
		// Token: 0x0400047A RID: 1146
		SgxGauss
	}
}
