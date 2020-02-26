using System;
using UnityEngine;

// Token: 0x020000CA RID: 202
[AddComponentMenu("Image Effects/Camera/Depth of Field (3.4)")]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[Serializable]
public class DepthOfField34 : PostEffectsBase
{
	// Token: 0x060002A8 RID: 680 RVA: 0x00021828 File Offset: 0x0001FA28
	public DepthOfField34()
	{
		this.quality = Dof34QualitySetting.OnlyBackground;
		this.resolution = DofResolution.Low;
		this.simpleTweakMode = true;
		this.focalPoint = 1f;
		this.smoothness = 0.5f;
		this.focalZStartCurve = 1f;
		this.focalZEndCurve = 1f;
		this.focalStartCurve = 2f;
		this.focalEndCurve = 2f;
		this.focalDistance01 = 0.1f;
		this.bluriness = DofBlurriness.High;
		this.maxBlurSpread = 1.75f;
		this.foregroundBlurExtrude = 1.15f;
		this.bokehDestination = BokehDestination.Background;
		this.widthOverHeight = 1.25f;
		this.oneOverBaseSize = 0.001953125f;
		this.bokehSupport = true;
		this.bokehScale = 2.4f;
		this.bokehIntensity = 0.15f;
		this.bokehThreshholdContrast = 0.1f;
		this.bokehThreshholdLuminance = 0.55f;
		this.bokehDownsample = 1;
	}

	// Token: 0x060002AA RID: 682 RVA: 0x00021928 File Offset: 0x0001FB28
	public virtual void CreateMaterials()
	{
		this.dofBlurMaterial = this.CheckShaderAndCreateMaterial(this.dofBlurShader, this.dofBlurMaterial);
		this.dofMaterial = this.CheckShaderAndCreateMaterial(this.dofShader, this.dofMaterial);
		this.bokehSupport = this.bokehShader.isSupported;
		if (this.bokeh && this.bokehSupport && this.bokehShader)
		{
			this.bokehMaterial = this.CheckShaderAndCreateMaterial(this.bokehShader, this.bokehMaterial);
		}
	}

	// Token: 0x060002AB RID: 683 RVA: 0x000219B4 File Offset: 0x0001FBB4
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.dofBlurMaterial = this.CheckShaderAndCreateMaterial(this.dofBlurShader, this.dofBlurMaterial);
		this.dofMaterial = this.CheckShaderAndCreateMaterial(this.dofShader, this.dofMaterial);
		this.bokehSupport = this.bokehShader.isSupported;
		if (this.bokeh && this.bokehSupport && this.bokehShader)
		{
			this.bokehMaterial = this.CheckShaderAndCreateMaterial(this.bokehShader, this.bokehMaterial);
		}
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00021A60 File Offset: 0x0001FC60
	public virtual void OnDisable()
	{
		Quads.Cleanup();
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00021A68 File Offset: 0x0001FC68
	public override void OnEnable()
	{
		this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.Depth);
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00021A90 File Offset: 0x0001FC90
	public virtual float FocalDistance01(float worldDist)
	{
		return this.GetComponent<Camera>().WorldToViewportPoint((worldDist - this.GetComponent<Camera>().nearClipPlane) * this.GetComponent<Camera>().transform.forward + this.GetComponent<Camera>().transform.position).z / (this.GetComponent<Camera>().farClipPlane - this.GetComponent<Camera>().nearClipPlane);
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00021B00 File Offset: 0x0001FD00
	public virtual int GetDividerBasedOnQuality()
	{
		int result = 1;
		if (this.resolution == DofResolution.Medium)
		{
			result = 2;
		}
		else if (this.resolution == DofResolution.Low)
		{
			result = 2;
		}
		return result;
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00021B34 File Offset: 0x0001FD34
	public virtual int GetLowResolutionDividerBasedOnQuality(int baseDivider)
	{
		int num = baseDivider;
		if (this.resolution == DofResolution.High)
		{
			num *= 2;
		}
		if (this.resolution == DofResolution.Low)
		{
			num *= 2;
		}
		return num;
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00021B64 File Offset: 0x0001FD64
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			if (this.smoothness < 0.1f)
			{
				this.smoothness = 0.1f;
			}
			bool flag;
			if (flag = this.bokeh)
			{
				flag = this.bokehSupport;
			}
			this.bokeh = flag;
			float num = (!this.bokeh) ? 1f : DepthOfField34.BOKEH_EXTRA_BLUR;
			bool flag2 = this.quality > Dof34QualitySetting.OnlyBackground;
			float num2 = this.focalSize / (this.GetComponent<Camera>().farClipPlane - this.GetComponent<Camera>().nearClipPlane);
			if (this.simpleTweakMode)
			{
				this.focalDistance01 = ((!this.objectFocus) ? this.FocalDistance01(this.focalPoint) : (this.GetComponent<Camera>().WorldToViewportPoint(this.objectFocus.position).z / this.GetComponent<Camera>().farClipPlane));
				this.focalStartCurve = this.focalDistance01 * this.smoothness;
				this.focalEndCurve = this.focalStartCurve;
				bool flag3;
				if (flag3 = flag2)
				{
					flag3 = (this.focalPoint > this.GetComponent<Camera>().nearClipPlane + Mathf.Epsilon);
				}
				flag2 = flag3;
			}
			else
			{
				if (this.objectFocus)
				{
					Vector3 vector = this.GetComponent<Camera>().WorldToViewportPoint(this.objectFocus.position);
					vector.z /= this.GetComponent<Camera>().farClipPlane;
					this.focalDistance01 = vector.z;
				}
				else
				{
					this.focalDistance01 = this.FocalDistance01(this.focalZDistance);
				}
				this.focalStartCurve = this.focalZStartCurve;
				this.focalEndCurve = this.focalZEndCurve;
				bool flag4;
				if (flag4 = flag2)
				{
					flag4 = (this.focalPoint > this.GetComponent<Camera>().nearClipPlane + Mathf.Epsilon);
				}
				flag2 = flag4;
			}
			this.widthOverHeight = 1f * (float)source.width / (1f * (float)source.height);
			this.oneOverBaseSize = 0.001953125f;
			this.dofMaterial.SetFloat("_ForegroundBlurExtrude", this.foregroundBlurExtrude);
			this.dofMaterial.SetVector("_CurveParams", new Vector4((!this.simpleTweakMode) ? this.focalStartCurve : (1f / this.focalStartCurve), (!this.simpleTweakMode) ? this.focalEndCurve : (1f / this.focalEndCurve), num2 * 0.5f, this.focalDistance01));
			this.dofMaterial.SetVector("_InvRenderTargetSize", new Vector4(1f / (1f * (float)source.width), 1f / (1f * (float)source.height), (float)0, (float)0));
			int dividerBasedOnQuality = this.GetDividerBasedOnQuality();
			int lowResolutionDividerBasedOnQuality = this.GetLowResolutionDividerBasedOnQuality(dividerBasedOnQuality);
			this.AllocateTextures(flag2, source, dividerBasedOnQuality, lowResolutionDividerBasedOnQuality);
			Graphics.Blit(source, source, this.dofMaterial, 3);
			this.Downsample(source, this.mediumRezWorkTexture);
			this.Blur(this.mediumRezWorkTexture, this.mediumRezWorkTexture, DofBlurriness.Low, 4, this.maxBlurSpread);
			if (this.bokeh && (this.bokehDestination & BokehDestination.Background) != (BokehDestination)0)
			{
				this.dofMaterial.SetVector("_Threshhold", new Vector4(this.bokehThreshholdContrast, this.bokehThreshholdLuminance, 0.95f, (float)0));
				Graphics.Blit(this.mediumRezWorkTexture, this.bokehSource2, this.dofMaterial, 11);
				Graphics.Blit(this.mediumRezWorkTexture, this.lowRezWorkTexture);
				this.Blur(this.lowRezWorkTexture, this.lowRezWorkTexture, this.bluriness, 0, this.maxBlurSpread * num);
			}
			else
			{
				this.Downsample(this.mediumRezWorkTexture, this.lowRezWorkTexture);
				this.Blur(this.lowRezWorkTexture, this.lowRezWorkTexture, this.bluriness, 0, this.maxBlurSpread);
			}
			this.dofBlurMaterial.SetTexture("_TapLow", this.lowRezWorkTexture);
			this.dofBlurMaterial.SetTexture("_TapMedium", this.mediumRezWorkTexture);
			Graphics.Blit(null, this.finalDefocus, this.dofBlurMaterial, 3);
			if (this.bokeh && (this.bokehDestination & BokehDestination.Background) != (BokehDestination)0)
			{
				this.AddBokeh(this.bokehSource2, this.bokehSource, this.finalDefocus);
			}
			this.dofMaterial.SetTexture("_TapLowBackground", this.finalDefocus);
			this.dofMaterial.SetTexture("_TapMedium", this.mediumRezWorkTexture);
			Graphics.Blit(source, (!flag2) ? destination : this.foregroundTexture, this.dofMaterial, (!this.visualize) ? 0 : 2);
			if (flag2)
			{
				Graphics.Blit(this.foregroundTexture, source, this.dofMaterial, 5);
				this.Downsample(source, this.mediumRezWorkTexture);
				this.BlurFg(this.mediumRezWorkTexture, this.mediumRezWorkTexture, DofBlurriness.Low, 2, this.maxBlurSpread);
				if (this.bokeh && (this.bokehDestination & BokehDestination.Foreground) != (BokehDestination)0)
				{
					this.dofMaterial.SetVector("_Threshhold", new Vector4(this.bokehThreshholdContrast * 0.5f, this.bokehThreshholdLuminance, (float)0, (float)0));
					Graphics.Blit(this.mediumRezWorkTexture, this.bokehSource2, this.dofMaterial, 11);
					Graphics.Blit(this.mediumRezWorkTexture, this.lowRezWorkTexture);
					this.BlurFg(this.lowRezWorkTexture, this.lowRezWorkTexture, this.bluriness, 1, this.maxBlurSpread * num);
				}
				else
				{
					this.BlurFg(this.mediumRezWorkTexture, this.lowRezWorkTexture, this.bluriness, 1, this.maxBlurSpread);
				}
				Graphics.Blit(this.lowRezWorkTexture, this.finalDefocus);
				this.dofMaterial.SetTexture("_TapLowForeground", this.finalDefocus);
				Graphics.Blit(source, destination, this.dofMaterial, (!this.visualize) ? 4 : 1);
				if (this.bokeh && (this.bokehDestination & BokehDestination.Foreground) != (BokehDestination)0)
				{
					this.AddBokeh(this.bokehSource2, this.bokehSource, destination);
				}
			}
			this.ReleaseTextures();
		}
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00022174 File Offset: 0x00020374
	public virtual void Blur(RenderTexture from, RenderTexture to, DofBlurriness iterations, int blurPass, float spread)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(to.width, to.height);
		if (iterations > DofBlurriness.Low)
		{
			this.BlurHex(from, to, blurPass, spread, temporary);
			if (iterations > DofBlurriness.High)
			{
				this.dofBlurMaterial.SetVector("offsets", new Vector4((float)0, spread * this.oneOverBaseSize, (float)0, (float)0));
				Graphics.Blit(to, temporary, this.dofBlurMaterial, blurPass);
				this.dofBlurMaterial.SetVector("offsets", new Vector4(spread / this.widthOverHeight * this.oneOverBaseSize, (float)0, (float)0, (float)0));
				Graphics.Blit(temporary, to, this.dofBlurMaterial, blurPass);
			}
		}
		else
		{
			this.dofBlurMaterial.SetVector("offsets", new Vector4((float)0, spread * this.oneOverBaseSize, (float)0, (float)0));
			Graphics.Blit(from, temporary, this.dofBlurMaterial, blurPass);
			this.dofBlurMaterial.SetVector("offsets", new Vector4(spread / this.widthOverHeight * this.oneOverBaseSize, (float)0, (float)0, (float)0));
			Graphics.Blit(temporary, to, this.dofBlurMaterial, blurPass);
		}
		RenderTexture.ReleaseTemporary(temporary);
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x000222B4 File Offset: 0x000204B4
	public virtual void BlurFg(RenderTexture from, RenderTexture to, DofBlurriness iterations, int blurPass, float spread)
	{
		this.dofBlurMaterial.SetTexture("_TapHigh", from);
		RenderTexture temporary = RenderTexture.GetTemporary(to.width, to.height);
		if (iterations > DofBlurriness.Low)
		{
			this.BlurHex(from, to, blurPass, spread, temporary);
			if (iterations > DofBlurriness.High)
			{
				this.dofBlurMaterial.SetVector("offsets", new Vector4((float)0, spread * this.oneOverBaseSize, (float)0, (float)0));
				Graphics.Blit(to, temporary, this.dofBlurMaterial, blurPass);
				this.dofBlurMaterial.SetVector("offsets", new Vector4(spread / this.widthOverHeight * this.oneOverBaseSize, (float)0, (float)0, (float)0));
				Graphics.Blit(temporary, to, this.dofBlurMaterial, blurPass);
			}
		}
		else
		{
			this.dofBlurMaterial.SetVector("offsets", new Vector4((float)0, spread * this.oneOverBaseSize, (float)0, (float)0));
			Graphics.Blit(from, temporary, this.dofBlurMaterial, blurPass);
			this.dofBlurMaterial.SetVector("offsets", new Vector4(spread / this.widthOverHeight * this.oneOverBaseSize, (float)0, (float)0, (float)0));
			Graphics.Blit(temporary, to, this.dofBlurMaterial, blurPass);
		}
		RenderTexture.ReleaseTemporary(temporary);
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x00022404 File Offset: 0x00020604
	public virtual void BlurHex(RenderTexture from, RenderTexture to, int blurPass, float spread, RenderTexture tmp)
	{
		this.dofBlurMaterial.SetVector("offsets", new Vector4((float)0, spread * this.oneOverBaseSize, (float)0, (float)0));
		Graphics.Blit(from, tmp, this.dofBlurMaterial, blurPass);
		this.dofBlurMaterial.SetVector("offsets", new Vector4(spread / this.widthOverHeight * this.oneOverBaseSize, (float)0, (float)0, (float)0));
		Graphics.Blit(tmp, to, this.dofBlurMaterial, blurPass);
		this.dofBlurMaterial.SetVector("offsets", new Vector4(spread / this.widthOverHeight * this.oneOverBaseSize, spread * this.oneOverBaseSize, (float)0, (float)0));
		Graphics.Blit(to, tmp, this.dofBlurMaterial, blurPass);
		this.dofBlurMaterial.SetVector("offsets", new Vector4(spread / this.widthOverHeight * this.oneOverBaseSize, -spread * this.oneOverBaseSize, (float)0, (float)0));
		Graphics.Blit(tmp, to, this.dofBlurMaterial, blurPass);
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x00022520 File Offset: 0x00020720
	public virtual void Downsample(RenderTexture from, RenderTexture to)
	{
		this.dofMaterial.SetVector("_InvRenderTargetSize", new Vector4(1f / (1f * (float)to.width), 1f / (1f * (float)to.height), (float)0, (float)0));
		Graphics.Blit(from, to, this.dofMaterial, DepthOfField34.SMOOTH_DOWNSAMPLE_PASS);
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x00022580 File Offset: 0x00020780
	public virtual void AddBokeh(RenderTexture bokehInfo, RenderTexture tempTex, RenderTexture finalTarget)
	{
		if (this.bokehMaterial)
		{
			Mesh[] meshes = Quads.GetMeshes(tempTex.width, tempTex.height);
			RenderTexture.active = tempTex;
			GL.Clear(false, true, new Color((float)0, (float)0, (float)0, (float)0));
			GL.PushMatrix();
			GL.LoadIdentity();
			bokehInfo.filterMode = FilterMode.Point;
			float num = (float)bokehInfo.width * 1f / ((float)bokehInfo.height * 1f);
			float num2 = 2f / (1f * (float)bokehInfo.width);
			num2 += this.bokehScale * this.maxBlurSpread * DepthOfField34.BOKEH_EXTRA_BLUR * this.oneOverBaseSize;
			this.bokehMaterial.SetTexture("_Source", bokehInfo);
			this.bokehMaterial.SetTexture("_MainTex", this.bokehTexture);
			this.bokehMaterial.SetVector("_ArScale", new Vector4(num2, num2 * num, 0.5f, 0.5f * num));
			this.bokehMaterial.SetFloat("_Intensity", this.bokehIntensity);
			this.bokehMaterial.SetPass(0);
			int i = 0;
			Mesh[] array = meshes;
			int length = array.Length;
			while (i < length)
			{
				if (array[i])
				{
					Graphics.DrawMeshNow(array[i], Matrix4x4.identity);
				}
				i++;
			}
			GL.PopMatrix();
			Graphics.Blit(tempTex, finalTarget, this.dofMaterial, 8);
			bokehInfo.filterMode = FilterMode.Bilinear;
		}
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x000226F4 File Offset: 0x000208F4
	public virtual void ReleaseTextures()
	{
		if (this.foregroundTexture)
		{
			RenderTexture.ReleaseTemporary(this.foregroundTexture);
		}
		if (this.finalDefocus)
		{
			RenderTexture.ReleaseTemporary(this.finalDefocus);
		}
		if (this.mediumRezWorkTexture)
		{
			RenderTexture.ReleaseTemporary(this.mediumRezWorkTexture);
		}
		if (this.lowRezWorkTexture)
		{
			RenderTexture.ReleaseTemporary(this.lowRezWorkTexture);
		}
		if (this.bokehSource)
		{
			RenderTexture.ReleaseTemporary(this.bokehSource);
		}
		if (this.bokehSource2)
		{
			RenderTexture.ReleaseTemporary(this.bokehSource2);
		}
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x000227A4 File Offset: 0x000209A4
	public virtual void AllocateTextures(bool blurForeground, RenderTexture source, int divider, int lowTexDivider)
	{
		this.foregroundTexture = null;
		if (blurForeground)
		{
			this.foregroundTexture = RenderTexture.GetTemporary(source.width, source.height, 0);
		}
		this.mediumRezWorkTexture = RenderTexture.GetTemporary(source.width / divider, source.height / divider, 0);
		this.finalDefocus = RenderTexture.GetTemporary(source.width / divider, source.height / divider, 0);
		this.lowRezWorkTexture = RenderTexture.GetTemporary(source.width / lowTexDivider, source.height / lowTexDivider, 0);
		this.bokehSource = null;
		this.bokehSource2 = null;
		if (this.bokeh)
		{
			this.bokehSource = RenderTexture.GetTemporary(source.width / (lowTexDivider * this.bokehDownsample), source.height / (lowTexDivider * this.bokehDownsample), 0, RenderTextureFormat.ARGBHalf);
			this.bokehSource2 = RenderTexture.GetTemporary(source.width / (lowTexDivider * this.bokehDownsample), source.height / (lowTexDivider * this.bokehDownsample), 0, RenderTextureFormat.ARGBHalf);
			this.bokehSource.filterMode = FilterMode.Bilinear;
			this.bokehSource2.filterMode = FilterMode.Bilinear;
			RenderTexture.active = this.bokehSource2;
			GL.Clear(false, true, new Color((float)0, (float)0, (float)0, (float)0));
		}
		source.filterMode = FilterMode.Bilinear;
		this.finalDefocus.filterMode = FilterMode.Bilinear;
		this.mediumRezWorkTexture.filterMode = FilterMode.Bilinear;
		this.lowRezWorkTexture.filterMode = FilterMode.Bilinear;
		if (this.foregroundTexture)
		{
			this.foregroundTexture.filterMode = FilterMode.Bilinear;
		}
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x00022930 File Offset: 0x00020B30
	public override void Main()
	{
	}

	// Token: 0x040004DD RID: 1245
	[NonSerialized]
	private static int SMOOTH_DOWNSAMPLE_PASS = 6;

	// Token: 0x040004DE RID: 1246
	[NonSerialized]
	private static float BOKEH_EXTRA_BLUR = 2f;

	// Token: 0x040004DF RID: 1247
	public Dof34QualitySetting quality;

	// Token: 0x040004E0 RID: 1248
	public DofResolution resolution;

	// Token: 0x040004E1 RID: 1249
	public bool simpleTweakMode;

	// Token: 0x040004E2 RID: 1250
	public float focalPoint;

	// Token: 0x040004E3 RID: 1251
	public float smoothness;

	// Token: 0x040004E4 RID: 1252
	public float focalZDistance;

	// Token: 0x040004E5 RID: 1253
	public float focalZStartCurve;

	// Token: 0x040004E6 RID: 1254
	public float focalZEndCurve;

	// Token: 0x040004E7 RID: 1255
	private float focalStartCurve;

	// Token: 0x040004E8 RID: 1256
	private float focalEndCurve;

	// Token: 0x040004E9 RID: 1257
	private float focalDistance01;

	// Token: 0x040004EA RID: 1258
	public Transform objectFocus;

	// Token: 0x040004EB RID: 1259
	public float focalSize;

	// Token: 0x040004EC RID: 1260
	public DofBlurriness bluriness;

	// Token: 0x040004ED RID: 1261
	public float maxBlurSpread;

	// Token: 0x040004EE RID: 1262
	public float foregroundBlurExtrude;

	// Token: 0x040004EF RID: 1263
	public Shader dofBlurShader;

	// Token: 0x040004F0 RID: 1264
	private Material dofBlurMaterial;

	// Token: 0x040004F1 RID: 1265
	public Shader dofShader;

	// Token: 0x040004F2 RID: 1266
	private Material dofMaterial;

	// Token: 0x040004F3 RID: 1267
	public bool visualize;

	// Token: 0x040004F4 RID: 1268
	public BokehDestination bokehDestination;

	// Token: 0x040004F5 RID: 1269
	private float widthOverHeight;

	// Token: 0x040004F6 RID: 1270
	private float oneOverBaseSize;

	// Token: 0x040004F7 RID: 1271
	public bool bokeh;

	// Token: 0x040004F8 RID: 1272
	public bool bokehSupport;

	// Token: 0x040004F9 RID: 1273
	public Shader bokehShader;

	// Token: 0x040004FA RID: 1274
	public Texture2D bokehTexture;

	// Token: 0x040004FB RID: 1275
	public float bokehScale;

	// Token: 0x040004FC RID: 1276
	public float bokehIntensity;

	// Token: 0x040004FD RID: 1277
	public float bokehThreshholdContrast;

	// Token: 0x040004FE RID: 1278
	public float bokehThreshholdLuminance;

	// Token: 0x040004FF RID: 1279
	public int bokehDownsample;

	// Token: 0x04000500 RID: 1280
	private Material bokehMaterial;

	// Token: 0x04000501 RID: 1281
	private RenderTexture foregroundTexture;

	// Token: 0x04000502 RID: 1282
	private RenderTexture mediumRezWorkTexture;

	// Token: 0x04000503 RID: 1283
	private RenderTexture finalDefocus;

	// Token: 0x04000504 RID: 1284
	private RenderTexture lowRezWorkTexture;

	// Token: 0x04000505 RID: 1285
	private RenderTexture bokehSource;

	// Token: 0x04000506 RID: 1286
	private RenderTexture bokehSource2;
}
