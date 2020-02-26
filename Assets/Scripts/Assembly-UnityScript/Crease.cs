using System;
using UnityEngine;

// Token: 0x020000C5 RID: 197
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Edge Detection/Crease Shading")]
[RequireComponent(typeof(Camera))]
[Serializable]
public class Crease : PostEffectsBase
{
	// Token: 0x060002A4 RID: 676 RVA: 0x00021604 File Offset: 0x0001F804
	public Crease()
	{
		this.intensity = 0.5f;
		this.softness = 1;
		this.spread = 1f;
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x0002162C File Offset: 0x0001F82C
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.blurMaterial = this.CheckShaderAndCreateMaterial(this.blurShader, this.blurMaterial);
		this.depthFetchMaterial = this.CheckShaderAndCreateMaterial(this.depthFetchShader, this.depthFetchMaterial);
		this.creaseApplyMaterial = this.CheckShaderAndCreateMaterial(this.creaseApplyShader, this.creaseApplyMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x000216A0 File Offset: 0x0001F8A0
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
			float num = 1f * (float)width / (1f * (float)height);
			float num2 = 0.001953125f;
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			RenderTexture renderTexture = RenderTexture.GetTemporary(width / 2, height / 2, 0);
			Graphics.Blit(source, temporary, this.depthFetchMaterial);
			Graphics.Blit(temporary, renderTexture);
			for (int i = 0; i < this.softness; i++)
			{
				RenderTexture temporary2 = RenderTexture.GetTemporary(width / 2, height / 2, 0);
				this.blurMaterial.SetVector("offsets", new Vector4((float)0, this.spread * num2, (float)0, (float)0));
				Graphics.Blit(renderTexture, temporary2, this.blurMaterial);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary2;
				temporary2 = RenderTexture.GetTemporary(width / 2, height / 2, 0);
				this.blurMaterial.SetVector("offsets", new Vector4(this.spread * num2 / num, (float)0, (float)0, (float)0));
				Graphics.Blit(renderTexture, temporary2, this.blurMaterial);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary2;
			}
			this.creaseApplyMaterial.SetTexture("_HrDepthTex", temporary);
			this.creaseApplyMaterial.SetTexture("_LrDepthTex", renderTexture);
			this.creaseApplyMaterial.SetFloat("intensity", this.intensity);
			Graphics.Blit(source, destination, this.creaseApplyMaterial);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(renderTexture);
		}
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x00021824 File Offset: 0x0001FA24
	public override void Main()
	{
	}

	// Token: 0x040004C5 RID: 1221
	public float intensity;

	// Token: 0x040004C6 RID: 1222
	public int softness;

	// Token: 0x040004C7 RID: 1223
	public float spread;

	// Token: 0x040004C8 RID: 1224
	public Shader blurShader;

	// Token: 0x040004C9 RID: 1225
	private Material blurMaterial;

	// Token: 0x040004CA RID: 1226
	public Shader depthFetchShader;

	// Token: 0x040004CB RID: 1227
	private Material depthFetchMaterial;

	// Token: 0x040004CC RID: 1228
	public Shader creaseApplyShader;

	// Token: 0x040004CD RID: 1229
	private Material creaseApplyMaterial;
}
