using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x020000E2 RID: 226
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Color Adjustments/Tonemapping")]
[Serializable]
public class Tonemapping : PostEffectsBase
{
	// Token: 0x06000308 RID: 776 RVA: 0x00025DEC File Offset: 0x00023FEC
	public Tonemapping()
	{
		this.type = Tonemapping.TonemapperType.Photographic;
		this.adaptiveTextureSize = Tonemapping.AdaptiveTexSize.Square256;
		this.exposureAdjustment = 1.5f;
		this.middleGrey = 0.4f;
		this.white = 2f;
		this.adaptionSpeed = 1.5f;
		this.validRenderTextureFormat = true;
		this.rtFormat = RenderTextureFormat.ARGBHalf;
	}

	// Token: 0x06000309 RID: 777 RVA: 0x00025E4C File Offset: 0x0002404C
	public override bool CheckResources()
	{
		this.CheckSupport(false, true);
		this.tonemapMaterial = this.CheckShaderAndCreateMaterial(this.tonemapper, this.tonemapMaterial);
		if (!this.curveTex && this.type == Tonemapping.TonemapperType.UserCurve)
		{
			this.curveTex = new Texture2D(256, 1, TextureFormat.ARGB32, false, true);
			this.curveTex.filterMode = FilterMode.Bilinear;
			this.curveTex.wrapMode = TextureWrapMode.Clamp;
			this.curveTex.hideFlags = HideFlags.DontSave;
		}
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x0600030A RID: 778 RVA: 0x00025EE8 File Offset: 0x000240E8
	public virtual float UpdateCurve()
	{
		float num = 1f;
		if (Extensions.get_length(this.remapCurve.keys) < 1)
		{
			this.remapCurve = new AnimationCurve(new Keyframe[]
			{
				new Keyframe((float)0, (float)0),
				new Keyframe((float)2, (float)1)
			});
		}
		if (this.remapCurve != null)
		{
			if (this.remapCurve.length != 0)
			{
				num = this.remapCurve[this.remapCurve.length - 1].time;
			}
			for (float num2 = (float)0; num2 <= 1f; num2 += 0.003921569f)
			{
				float num3 = this.remapCurve.Evaluate(num2 * 1f * num);
				this.curveTex.SetPixel((int)Mathf.Floor(num2 * 255f), 0, new Color(num3, num3, num3));
			}
			this.curveTex.Apply();
		}
		return 1f / num;
	}

	// Token: 0x0600030B RID: 779 RVA: 0x00025FEC File Offset: 0x000241EC
	public virtual void OnDisable()
	{
		if (this.rt)
		{
			UnityEngine.Object.DestroyImmediate(this.rt);
			this.rt = null;
		}
		if (this.tonemapMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.tonemapMaterial);
			this.tonemapMaterial = null;
		}
		if (this.curveTex)
		{
			UnityEngine.Object.DestroyImmediate(this.curveTex);
			this.curveTex = null;
		}
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00026060 File Offset: 0x00024260
	public virtual bool CreateInternalRenderTexture()
	{
		bool result;
		if (this.rt)
		{
			result = false;
		}
		else
		{
			this.rtFormat = ((!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGHalf)) ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.RGHalf);
			this.rt = new RenderTexture(1, 1, 0, this.rtFormat);
			this.rt.hideFlags = HideFlags.DontSave;
			result = true;
		}
		return result;
	}

	// Token: 0x0600030D RID: 781 RVA: 0x000260C0 File Offset: 0x000242C0
	[ImageEffectTransformsToLDR]
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			this.exposureAdjustment = ((this.exposureAdjustment >= 0.001f) ? this.exposureAdjustment : 0.001f);
			if (this.type == Tonemapping.TonemapperType.UserCurve)
			{
				float value = this.UpdateCurve();
				this.tonemapMaterial.SetFloat("_RangeScale", value);
				this.tonemapMaterial.SetTexture("_Curve", this.curveTex);
				Graphics.Blit(source, destination, this.tonemapMaterial, 4);
			}
			else if (this.type == Tonemapping.TonemapperType.SimpleReinhard)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 6);
			}
			else if (this.type == Tonemapping.TonemapperType.Hable)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 5);
			}
			else if (this.type == Tonemapping.TonemapperType.Photographic)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 8);
			}
			else if (this.type == Tonemapping.TonemapperType.OptimizedHejiDawson)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", 0.5f * this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 7);
			}
			else
			{
				bool flag = this.CreateInternalRenderTexture();
				RenderTexture temporary = RenderTexture.GetTemporary((int)this.adaptiveTextureSize, (int)this.adaptiveTextureSize, 0, this.rtFormat);
				Graphics.Blit(source, temporary);
				int num = (int)Mathf.Log((float)temporary.width * 1f, (float)2);
				int num2 = 2;
				RenderTexture[] array = new RenderTexture[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = RenderTexture.GetTemporary(temporary.width / num2, temporary.width / num2, 0, this.rtFormat);
					num2 *= 2;
				}
				float num3 = (float)source.width * 1f / ((float)source.height * 1f);
				RenderTexture source2 = array[num - 1];
				Graphics.Blit(temporary, array[0], this.tonemapMaterial, 1);
				if (this.type == Tonemapping.TonemapperType.AdaptiveReinhardAutoWhite)
				{
					for (int i = 0; i < num - 1; i++)
					{
						Graphics.Blit(array[i], array[i + 1], this.tonemapMaterial, 9);
						source2 = array[i + 1];
					}
				}
				else if (this.type == Tonemapping.TonemapperType.AdaptiveReinhard)
				{
					for (int i = 0; i < num - 1; i++)
					{
						Graphics.Blit(array[i], array[i + 1]);
						source2 = array[i + 1];
					}
				}
				this.adaptionSpeed = ((this.adaptionSpeed >= 0.001f) ? this.adaptionSpeed : 0.001f);
				this.tonemapMaterial.SetFloat("_AdaptionSpeed", this.adaptionSpeed);
				this.rt.MarkRestoreExpected();
				Graphics.Blit(source2, this.rt, this.tonemapMaterial, (!flag) ? 2 : 3);
				this.middleGrey = ((this.middleGrey >= 0.001f) ? this.middleGrey : 0.001f);
				this.tonemapMaterial.SetVector("_HdrParams", new Vector4(this.middleGrey, this.middleGrey, this.middleGrey, this.white * this.white));
				this.tonemapMaterial.SetTexture("_SmallTex", this.rt);
				if (this.type == Tonemapping.TonemapperType.AdaptiveReinhard)
				{
					Graphics.Blit(source, destination, this.tonemapMaterial, 0);
				}
				else if (this.type == Tonemapping.TonemapperType.AdaptiveReinhardAutoWhite)
				{
					Graphics.Blit(source, destination, this.tonemapMaterial, 10);
				}
				else
				{
					Debug.LogError("No valid adaptive tonemapper type found!");
					Graphics.Blit(source, destination);
				}
				for (int i = 0; i < num; i++)
				{
					RenderTexture.ReleaseTemporary(array[i]);
				}
				RenderTexture.ReleaseTemporary(temporary);
			}
		}
	}

	// Token: 0x0600030E RID: 782 RVA: 0x000264C4 File Offset: 0x000246C4
	public override void Main()
	{
	}

	// Token: 0x0400059F RID: 1439
	public Tonemapping.TonemapperType type;

	// Token: 0x040005A0 RID: 1440
	public Tonemapping.AdaptiveTexSize adaptiveTextureSize;

	// Token: 0x040005A1 RID: 1441
	public AnimationCurve remapCurve;

	// Token: 0x040005A2 RID: 1442
	private Texture2D curveTex;

	// Token: 0x040005A3 RID: 1443
	public float exposureAdjustment;

	// Token: 0x040005A4 RID: 1444
	public float middleGrey;

	// Token: 0x040005A5 RID: 1445
	public float white;

	// Token: 0x040005A6 RID: 1446
	public float adaptionSpeed;

	// Token: 0x040005A7 RID: 1447
	public Shader tonemapper;

	// Token: 0x040005A8 RID: 1448
	public bool validRenderTextureFormat;

	// Token: 0x040005A9 RID: 1449
	private Material tonemapMaterial;

	// Token: 0x040005AA RID: 1450
	private RenderTexture rt;

	// Token: 0x040005AB RID: 1451
	private RenderTextureFormat rtFormat;

	// Token: 0x020000E3 RID: 227
	[Serializable]
	public enum TonemapperType
	{
		// Token: 0x040005AD RID: 1453
		SimpleReinhard,
		// Token: 0x040005AE RID: 1454
		UserCurve,
		// Token: 0x040005AF RID: 1455
		Hable,
		// Token: 0x040005B0 RID: 1456
		Photographic,
		// Token: 0x040005B1 RID: 1457
		OptimizedHejiDawson,
		// Token: 0x040005B2 RID: 1458
		AdaptiveReinhard,
		// Token: 0x040005B3 RID: 1459
		AdaptiveReinhardAutoWhite
	}

	// Token: 0x020000E4 RID: 228
	[Serializable]
	public enum AdaptiveTexSize
	{
		// Token: 0x040005B5 RID: 1461
		Square16 = 16,
		// Token: 0x040005B6 RID: 1462
		Square32 = 32,
		// Token: 0x040005B7 RID: 1463
		Square64 = 64,
		// Token: 0x040005B8 RID: 1464
		Square128 = 128,
		// Token: 0x040005B9 RID: 1465
		Square256 = 256,
		// Token: 0x040005BA RID: 1466
		Square512 = 512,
		// Token: 0x040005BB RID: 1467
		Square1024 = 1024
	}
}
