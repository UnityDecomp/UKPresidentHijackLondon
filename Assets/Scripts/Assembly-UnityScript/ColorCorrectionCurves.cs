using System;
using UnityEngine;

// Token: 0x020000C2 RID: 194
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Color Adjustments/Color Correction (Curves, Saturation)")]
[Serializable]
public class ColorCorrectionCurves : PostEffectsBase
{
	// Token: 0x0600028F RID: 655 RVA: 0x00020AF0 File Offset: 0x0001ECF0
	public ColorCorrectionCurves()
	{
		this.saturation = 1f;
		this.selectiveFromColor = Color.white;
		this.selectiveToColor = Color.white;
		this.updateTextures = true;
		this.updateTexturesOnStartup = true;
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00020B28 File Offset: 0x0001ED28
	public override void Start()
	{
		base.Start();
		this.updateTexturesOnStartup = true;
	}

	// Token: 0x06000291 RID: 657 RVA: 0x00020B38 File Offset: 0x0001ED38
	public virtual void Awake()
	{
	}

	// Token: 0x06000292 RID: 658 RVA: 0x00020B3C File Offset: 0x0001ED3C
	public override bool CheckResources()
	{
		this.CheckSupport(this.mode == ColorCorrectionMode.Advanced);
		this.ccMaterial = this.CheckShaderAndCreateMaterial(this.simpleColorCorrectionCurvesShader, this.ccMaterial);
		this.ccDepthMaterial = this.CheckShaderAndCreateMaterial(this.colorCorrectionCurvesShader, this.ccDepthMaterial);
		this.selectiveCcMaterial = this.CheckShaderAndCreateMaterial(this.colorCorrectionSelectiveShader, this.selectiveCcMaterial);
		if (!this.rgbChannelTex)
		{
			this.rgbChannelTex = new Texture2D(256, 4, TextureFormat.ARGB32, false, true);
		}
		if (!this.rgbDepthChannelTex)
		{
			this.rgbDepthChannelTex = new Texture2D(256, 4, TextureFormat.ARGB32, false, true);
		}
		if (!this.zCurveTex)
		{
			this.zCurveTex = new Texture2D(256, 1, TextureFormat.ARGB32, false, true);
		}
		this.rgbChannelTex.hideFlags = HideFlags.DontSave;
		this.rgbDepthChannelTex.hideFlags = HideFlags.DontSave;
		this.zCurveTex.hideFlags = HideFlags.DontSave;
		this.rgbChannelTex.wrapMode = TextureWrapMode.Clamp;
		this.rgbDepthChannelTex.wrapMode = TextureWrapMode.Clamp;
		this.zCurveTex.wrapMode = TextureWrapMode.Clamp;
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000293 RID: 659 RVA: 0x00020C70 File Offset: 0x0001EE70
	public virtual void UpdateParameters()
	{
		this.CheckResources();
		if (this.redChannel != null && this.greenChannel != null && this.blueChannel != null)
		{
			for (float num = (float)0; num <= 1f; num += 0.003921569f)
			{
				float num2 = Mathf.Clamp(this.redChannel.Evaluate(num), (float)0, 1f);
				float num3 = Mathf.Clamp(this.greenChannel.Evaluate(num), (float)0, 1f);
				float num4 = Mathf.Clamp(this.blueChannel.Evaluate(num), (float)0, 1f);
				this.rgbChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 0, new Color(num2, num2, num2));
				this.rgbChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 1, new Color(num3, num3, num3));
				this.rgbChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 2, new Color(num4, num4, num4));
				float num5 = Mathf.Clamp(this.zCurve.Evaluate(num), (float)0, 1f);
				this.zCurveTex.SetPixel((int)Mathf.Floor(num * 255f), 0, new Color(num5, num5, num5));
				num2 = Mathf.Clamp(this.depthRedChannel.Evaluate(num), (float)0, 1f);
				num3 = Mathf.Clamp(this.depthGreenChannel.Evaluate(num), (float)0, 1f);
				num4 = Mathf.Clamp(this.depthBlueChannel.Evaluate(num), (float)0, 1f);
				this.rgbDepthChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 0, new Color(num2, num2, num2));
				this.rgbDepthChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 1, new Color(num3, num3, num3));
				this.rgbDepthChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 2, new Color(num4, num4, num4));
			}
			this.rgbChannelTex.Apply();
			this.rgbDepthChannelTex.Apply();
			this.zCurveTex.Apply();
		}
	}

	// Token: 0x06000294 RID: 660 RVA: 0x00020E84 File Offset: 0x0001F084
	public virtual void UpdateTextures()
	{
		this.UpdateParameters();
	}

	// Token: 0x06000295 RID: 661 RVA: 0x00020E8C File Offset: 0x0001F08C
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			if (this.updateTexturesOnStartup)
			{
				this.UpdateParameters();
				this.updateTexturesOnStartup = false;
			}
			if (this.useDepthCorrection)
			{
				this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.Depth);
			}
			RenderTexture renderTexture = destination;
			if (this.selectiveCc)
			{
				renderTexture = RenderTexture.GetTemporary(source.width, source.height);
			}
			if (this.useDepthCorrection)
			{
				this.ccDepthMaterial.SetTexture("_RgbTex", this.rgbChannelTex);
				this.ccDepthMaterial.SetTexture("_ZCurve", this.zCurveTex);
				this.ccDepthMaterial.SetTexture("_RgbDepthTex", this.rgbDepthChannelTex);
				this.ccDepthMaterial.SetFloat("_Saturation", this.saturation);
				Graphics.Blit(source, renderTexture, this.ccDepthMaterial);
			}
			else
			{
				this.ccMaterial.SetTexture("_RgbTex", this.rgbChannelTex);
				this.ccMaterial.SetFloat("_Saturation", this.saturation);
				Graphics.Blit(source, renderTexture, this.ccMaterial);
			}
			if (this.selectiveCc)
			{
				this.selectiveCcMaterial.SetColor("selColor", this.selectiveFromColor);
				this.selectiveCcMaterial.SetColor("targetColor", this.selectiveToColor);
				Graphics.Blit(renderTexture, destination, this.selectiveCcMaterial);
				RenderTexture.ReleaseTemporary(renderTexture);
			}
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x00021004 File Offset: 0x0001F204
	public override void Main()
	{
	}

	// Token: 0x040004A2 RID: 1186
	public AnimationCurve redChannel;

	// Token: 0x040004A3 RID: 1187
	public AnimationCurve greenChannel;

	// Token: 0x040004A4 RID: 1188
	public AnimationCurve blueChannel;

	// Token: 0x040004A5 RID: 1189
	public bool useDepthCorrection;

	// Token: 0x040004A6 RID: 1190
	public AnimationCurve zCurve;

	// Token: 0x040004A7 RID: 1191
	public AnimationCurve depthRedChannel;

	// Token: 0x040004A8 RID: 1192
	public AnimationCurve depthGreenChannel;

	// Token: 0x040004A9 RID: 1193
	public AnimationCurve depthBlueChannel;

	// Token: 0x040004AA RID: 1194
	private Material ccMaterial;

	// Token: 0x040004AB RID: 1195
	private Material ccDepthMaterial;

	// Token: 0x040004AC RID: 1196
	private Material selectiveCcMaterial;

	// Token: 0x040004AD RID: 1197
	private Texture2D rgbChannelTex;

	// Token: 0x040004AE RID: 1198
	private Texture2D rgbDepthChannelTex;

	// Token: 0x040004AF RID: 1199
	private Texture2D zCurveTex;

	// Token: 0x040004B0 RID: 1200
	public float saturation;

	// Token: 0x040004B1 RID: 1201
	public bool selectiveCc;

	// Token: 0x040004B2 RID: 1202
	public Color selectiveFromColor;

	// Token: 0x040004B3 RID: 1203
	public Color selectiveToColor;

	// Token: 0x040004B4 RID: 1204
	public ColorCorrectionMode mode;

	// Token: 0x040004B5 RID: 1205
	public bool updateTextures;

	// Token: 0x040004B6 RID: 1206
	public Shader colorCorrectionCurvesShader;

	// Token: 0x040004B7 RID: 1207
	public Shader simpleColorCorrectionCurvesShader;

	// Token: 0x040004B8 RID: 1208
	public Shader colorCorrectionSelectiveShader;

	// Token: 0x040004B9 RID: 1209
	private bool updateTexturesOnStartup;
}
