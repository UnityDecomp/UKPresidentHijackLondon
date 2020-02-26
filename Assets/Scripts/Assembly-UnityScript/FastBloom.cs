using System;
using UnityEngine;

// Token: 0x020000D0 RID: 208
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Bloom and Glow/Bloom (Optimized)")]
[ExecuteInEditMode]
[Serializable]
public class FastBloom : PostEffectsBase
{
	// Token: 0x060002CB RID: 715 RVA: 0x000239EC File Offset: 0x00021BEC
	public FastBloom()
	{
		this.threshhold = 0.25f;
		this.intensity = 0.75f;
		this.blurSize = 1f;
		this.resolution = FastBloom.Resolution.Low;
		this.blurIterations = 1;
		this.blurType = FastBloom.BlurType.Standard;
	}

	// Token: 0x060002CC RID: 716 RVA: 0x00023A38 File Offset: 0x00021C38
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.fastBloomMaterial = this.CheckShaderAndCreateMaterial(this.fastBloomShader, this.fastBloomMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00023A74 File Offset: 0x00021C74
	public virtual void OnDisable()
	{
		if (this.fastBloomMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.fastBloomMaterial);
		}
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00023A94 File Offset: 0x00021C94
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			int num = (this.resolution != FastBloom.Resolution.Low) ? 2 : 4;
			float num2 = (this.resolution != FastBloom.Resolution.Low) ? 1f : 0.5f;
			this.fastBloomMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num2, (float)0, this.threshhold, this.intensity));
			source.filterMode = FilterMode.Bilinear;
			int width = source.width / num;
			int height = source.height / num;
			RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 0, source.format);
			renderTexture.filterMode = FilterMode.Bilinear;
			Graphics.Blit(source, renderTexture, this.fastBloomMaterial, 1);
			int num3 = (this.blurType != FastBloom.BlurType.Standard) ? 2 : 0;
			for (int i = 0; i < this.blurIterations; i++)
			{
				this.fastBloomMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num2 + (float)i * 1f, (float)0, this.threshhold, this.intensity));
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
	}

	// Token: 0x060002CF RID: 719 RVA: 0x00023C4C File Offset: 0x00021E4C
	public override void Main()
	{
	}

	// Token: 0x04000537 RID: 1335
	[Range(0f, 1.5f)]
	public float threshhold;

	// Token: 0x04000538 RID: 1336
	[Range(0f, 2.5f)]
	public float intensity;

	// Token: 0x04000539 RID: 1337
	[Range(0.25f, 5.5f)]
	public float blurSize;

	// Token: 0x0400053A RID: 1338
	public FastBloom.Resolution resolution;

	// Token: 0x0400053B RID: 1339
	[Range(1f, 4f)]
	public int blurIterations;

	// Token: 0x0400053C RID: 1340
	public FastBloom.BlurType blurType;

	// Token: 0x0400053D RID: 1341
	public Shader fastBloomShader;

	// Token: 0x0400053E RID: 1342
	private Material fastBloomMaterial;

	// Token: 0x020000D1 RID: 209
	[Serializable]
	public enum Resolution
	{
		// Token: 0x04000540 RID: 1344
		Low,
		// Token: 0x04000541 RID: 1345
		High
	}

	// Token: 0x020000D2 RID: 210
	[Serializable]
	public enum BlurType
	{
		// Token: 0x04000543 RID: 1347
		Standard,
		// Token: 0x04000544 RID: 1348
		Sgx
	}
}
