using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
[AddComponentMenu("Image Effects/Noise/Noise And Grain (Filmic)")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[Serializable]
public class NoiseAndGrain : PostEffectsBase
{
	// Token: 0x060002D9 RID: 729 RVA: 0x000241B0 File Offset: 0x000223B0
	public NoiseAndGrain()
	{
		this.intensityMultiplier = 0.25f;
		this.generalIntensity = 0.5f;
		this.blackIntensity = 1f;
		this.whiteIntensity = 1f;
		this.midGrey = 0.2f;
		this.intensities = new Vector3(1f, 1f, 1f);
		this.tiling = new Vector3(64f, 64f, 64f);
		this.monochromeTiling = 64f;
		this.filterMode = FilterMode.Bilinear;
	}

	// Token: 0x060002DB RID: 731 RVA: 0x0002424C File Offset: 0x0002244C
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.noiseMaterial = this.CheckShaderAndCreateMaterial(this.noiseShader, this.noiseMaterial);
		if (this.dx11Grain && this.supportDX11)
		{
			this.dx11NoiseMaterial = this.CheckShaderAndCreateMaterial(this.dx11NoiseShader, this.dx11NoiseMaterial);
		}
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002DC RID: 732 RVA: 0x000242C0 File Offset: 0x000224C0
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources() || null == this.noiseTexture)
		{
			Graphics.Blit(source, destination);
			if (null == this.noiseTexture)
			{
				Debug.LogWarning("Noise & Grain effect failing as noise texture is not assigned. please assign.", this.transform);
			}
		}
		else
		{
			this.softness = Mathf.Clamp(this.softness, (float)0, 0.99f);
			if (this.dx11Grain && this.supportDX11)
			{
				this.dx11NoiseMaterial.SetFloat("_DX11NoiseTime", (float)Time.frameCount);
				this.dx11NoiseMaterial.SetTexture("_NoiseTex", this.noiseTexture);
				this.dx11NoiseMaterial.SetVector("_NoisePerChannel", (!this.monochrome) ? this.intensities : Vector3.one);
				this.dx11NoiseMaterial.SetVector("_MidGrey", new Vector3(this.midGrey, 1f / (1f - this.midGrey), -1f / this.midGrey));
				this.dx11NoiseMaterial.SetVector("_NoiseAmount", new Vector3(this.generalIntensity, this.blackIntensity, this.whiteIntensity) * this.intensityMultiplier);
				if (this.softness > Mathf.Epsilon)
				{
					RenderTexture temporary = RenderTexture.GetTemporary((int)((float)source.width * (1f - this.softness)), (int)((float)source.height * (1f - this.softness)));
					NoiseAndGrain.DrawNoiseQuadGrid(source, temporary, this.dx11NoiseMaterial, this.noiseTexture, (!this.monochrome) ? 2 : 3);
					this.dx11NoiseMaterial.SetTexture("_NoiseTex", temporary);
					Graphics.Blit(source, destination, this.dx11NoiseMaterial, 4);
					RenderTexture.ReleaseTemporary(temporary);
				}
				else
				{
					NoiseAndGrain.DrawNoiseQuadGrid(source, destination, this.dx11NoiseMaterial, this.noiseTexture, (!this.monochrome) ? 0 : 1);
				}
			}
			else
			{
				if (this.noiseTexture)
				{
					this.noiseTexture.wrapMode = TextureWrapMode.Repeat;
					this.noiseTexture.filterMode = this.filterMode;
				}
				this.noiseMaterial.SetTexture("_NoiseTex", this.noiseTexture);
				this.noiseMaterial.SetVector("_NoisePerChannel", (!this.monochrome) ? this.intensities : Vector3.one);
				this.noiseMaterial.SetVector("_NoiseTilingPerChannel", (!this.monochrome) ? this.tiling : (Vector3.one * this.monochromeTiling));
				this.noiseMaterial.SetVector("_MidGrey", new Vector3(this.midGrey, 1f / (1f - this.midGrey), -1f / this.midGrey));
				this.noiseMaterial.SetVector("_NoiseAmount", new Vector3(this.generalIntensity, this.blackIntensity, this.whiteIntensity) * this.intensityMultiplier);
				if (this.softness > Mathf.Epsilon)
				{
					RenderTexture temporary2 = RenderTexture.GetTemporary((int)((float)source.width * (1f - this.softness)), (int)((float)source.height * (1f - this.softness)));
					NoiseAndGrain.DrawNoiseQuadGrid(source, temporary2, this.noiseMaterial, this.noiseTexture, 2);
					this.noiseMaterial.SetTexture("_NoiseTex", temporary2);
					Graphics.Blit(source, destination, this.noiseMaterial, 1);
					RenderTexture.ReleaseTemporary(temporary2);
				}
				else
				{
					NoiseAndGrain.DrawNoiseQuadGrid(source, destination, this.noiseMaterial, this.noiseTexture, 0);
				}
			}
		}
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00024684 File Offset: 0x00022884
	public static void DrawNoiseQuadGrid(RenderTexture source, RenderTexture dest, Material fxMaterial, Texture2D noise, int passNr)
	{
		RenderTexture.active = dest;
		float num = (float)noise.width * 1f;
		float num2 = 1f * (float)source.width / NoiseAndGrain.TILE_AMOUNT;
		fxMaterial.SetTexture("_MainTex", source);
		GL.PushMatrix();
		GL.LoadOrtho();
		float num3 = 1f * (float)source.width / (1f * (float)source.height);
		float num4 = 1f / num2;
		float num5 = num4 * num3;
		float num6 = num / ((float)noise.width * 1f);
		fxMaterial.SetPass(passNr);
		GL.Begin(7);
		for (float num7 = (float)0; num7 < 1f; num7 += num4)
		{
			for (float num8 = (float)0; num8 < 1f; num8 += num5)
			{
				float num9 = UnityEngine.Random.Range((float)0, 1f);
				float num10 = UnityEngine.Random.Range((float)0, 1f);
				num9 = Mathf.Floor(num9 * num) / num;
				num10 = Mathf.Floor(num10 * num) / num;
				float num11 = 1f / num;
				GL.MultiTexCoord2(0, num9, num10);
				GL.MultiTexCoord2(1, (float)0, (float)0);
				GL.Vertex3(num7, num8, 0.1f);
				GL.MultiTexCoord2(0, num9 + num6 * num11, num10);
				GL.MultiTexCoord2(1, 1f, (float)0);
				GL.Vertex3(num7 + num4, num8, 0.1f);
				GL.MultiTexCoord2(0, num9 + num6 * num11, num10 + num6 * num11);
				GL.MultiTexCoord2(1, 1f, 1f);
				GL.Vertex3(num7 + num4, num8 + num5, 0.1f);
				GL.MultiTexCoord2(0, num9, num10 + num6 * num11);
				GL.MultiTexCoord2(1, (float)0, 1f);
				GL.Vertex3(num7, num8 + num5, 0.1f);
			}
		}
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00024854 File Offset: 0x00022A54
	public override void Main()
	{
	}

	// Token: 0x0400055A RID: 1370
	public float intensityMultiplier;

	// Token: 0x0400055B RID: 1371
	public float generalIntensity;

	// Token: 0x0400055C RID: 1372
	public float blackIntensity;

	// Token: 0x0400055D RID: 1373
	public float whiteIntensity;

	// Token: 0x0400055E RID: 1374
	public float midGrey;

	// Token: 0x0400055F RID: 1375
	public bool dx11Grain;

	// Token: 0x04000560 RID: 1376
	public float softness;

	// Token: 0x04000561 RID: 1377
	public bool monochrome;

	// Token: 0x04000562 RID: 1378
	public Vector3 intensities;

	// Token: 0x04000563 RID: 1379
	public Vector3 tiling;

	// Token: 0x04000564 RID: 1380
	public float monochromeTiling;

	// Token: 0x04000565 RID: 1381
	public FilterMode filterMode;

	// Token: 0x04000566 RID: 1382
	public Texture2D noiseTexture;

	// Token: 0x04000567 RID: 1383
	public Shader noiseShader;

	// Token: 0x04000568 RID: 1384
	private Material noiseMaterial;

	// Token: 0x04000569 RID: 1385
	public Shader dx11NoiseShader;

	// Token: 0x0400056A RID: 1386
	private Material dx11NoiseMaterial;

	// Token: 0x0400056B RID: 1387
	[NonSerialized]
	private static float TILE_AMOUNT = 64f;
}
