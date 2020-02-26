using System;
using UnityEngine;

// Token: 0x020000C3 RID: 195
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Color Adjustments/Color Correction (3D Lookup Texture)")]
[Serializable]
public class ColorCorrectionLut : PostEffectsBase
{
	// Token: 0x06000297 RID: 663 RVA: 0x00021008 File Offset: 0x0001F208
	public ColorCorrectionLut()
	{
		this.basedOnTempTex = string.Empty;
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0002101C File Offset: 0x0001F21C
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.material = this.CheckShaderAndCreateMaterial(this.shader, this.material);
		if (!this.isSupported || !SystemInfo.supports3DTextures)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0002106C File Offset: 0x0001F26C
	public virtual void OnDisable()
	{
		if (this.material)
		{
			UnityEngine.Object.DestroyImmediate(this.material);
			this.material = null;
		}
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0002109C File Offset: 0x0001F29C
	public virtual void OnDestroy()
	{
		if (this.converted3DLut)
		{
			UnityEngine.Object.DestroyImmediate(this.converted3DLut);
		}
		this.converted3DLut = null;
	}

	// Token: 0x0600029B RID: 667 RVA: 0x000210CC File Offset: 0x0001F2CC
	public virtual void SetIdentityLut()
	{
		int num = 16;
		Color[] array = new Color[num * num * num];
		float num2 = 1f / (1f * (float)num - 1f);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num; k++)
				{
					array[i + j * num + k * num * num] = new Color((float)i * 1f * num2, (float)j * 1f * num2, (float)k * 1f * num2, 1f);
				}
			}
		}
		if (this.converted3DLut)
		{
			UnityEngine.Object.DestroyImmediate(this.converted3DLut);
		}
		this.converted3DLut = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		this.converted3DLut.SetPixels(array);
		this.converted3DLut.Apply();
		this.basedOnTempTex = string.Empty;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x000211CC File Offset: 0x0001F3CC
	public virtual bool ValidDimensions(Texture2D tex2d)
	{
		bool result;
		if (!tex2d)
		{
			result = false;
		}
		else
		{
			int height = tex2d.height;
			result = (height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width)));
		}
		return result;
	}

	// Token: 0x0600029D RID: 669 RVA: 0x00021210 File Offset: 0x0001F410
	public virtual void Convert(Texture2D temp2DTex, string path)
	{
		if (temp2DTex)
		{
			int num = temp2DTex.width * temp2DTex.height;
			num = temp2DTex.height;
			if (!this.ValidDimensions(temp2DTex))
			{
				Debug.LogWarning("The given 2D texture " + temp2DTex.name + " cannot be used as a 3D LUT.");
				this.basedOnTempTex = string.Empty;
			}
			else
			{
				Color[] pixels = temp2DTex.GetPixels();
				Color[] array = new Color[pixels.Length];
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < num; j++)
					{
						for (int k = 0; k < num; k++)
						{
							int num2 = num - j - 1;
							array[i + j * num + k * num * num] = pixels[k * num + i + num2 * num * num];
						}
					}
				}
				if (this.converted3DLut)
				{
					UnityEngine.Object.DestroyImmediate(this.converted3DLut);
				}
				this.converted3DLut = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
				this.converted3DLut.SetPixels(array);
				this.converted3DLut.Apply();
				this.basedOnTempTex = path;
			}
		}
		else
		{
			Debug.LogError("Couldn't color correct with 3D LUT texture. Image Effect will be disabled.");
		}
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0002135C File Offset: 0x0001F55C
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources() || !SystemInfo.supports3DTextures)
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			if (this.converted3DLut == null)
			{
				this.SetIdentityLut();
			}
			int width = this.converted3DLut.width;
			this.converted3DLut.wrapMode = TextureWrapMode.Clamp;
			this.material.SetFloat("_Scale", (float)(width - 1) / (1f * (float)width));
			this.material.SetFloat("_Offset", 1f / (2f * (float)width));
			this.material.SetTexture("_ClutTex", this.converted3DLut);
			Graphics.Blit(source, destination, this.material, (QualitySettings.activeColorSpace != ColorSpace.Linear) ? 0 : 1);
		}
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0002142C File Offset: 0x0001F62C
	public override void Main()
	{
	}

	// Token: 0x040004BA RID: 1210
	public Shader shader;

	// Token: 0x040004BB RID: 1211
	private Material material;

	// Token: 0x040004BC RID: 1212
	public Texture3D converted3DLut;

	// Token: 0x040004BD RID: 1213
	public string basedOnTempTex;
}
