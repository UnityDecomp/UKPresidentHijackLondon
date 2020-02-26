using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Rendering/Sun Shafts")]
[Serializable]
public class SunShafts : PostEffectsBase
{
	// Token: 0x06000300 RID: 768 RVA: 0x000257CC File Offset: 0x000239CC
	public SunShafts()
	{
		this.resolution = SunShaftsResolution.Normal;
		this.screenBlendMode = ShaftsScreenBlendMode.Screen;
		this.radialBlurIterations = 2;
		this.sunColor = Color.white;
		this.sunShaftBlurRadius = 2.5f;
		this.sunShaftIntensity = 1.15f;
		this.useSkyBoxAlpha = 0.75f;
		this.maxRadius = 0.75f;
		this.useDepthTexture = true;
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00025834 File Offset: 0x00023A34
	public override bool CheckResources()
	{
		this.CheckSupport(this.useDepthTexture);
		this.sunShaftsMaterial = this.CheckShaderAndCreateMaterial(this.sunShaftsShader, this.sunShaftsMaterial);
		this.simpleClearMaterial = this.CheckShaderAndCreateMaterial(this.simpleClearShader, this.simpleClearMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00025898 File Offset: 0x00023A98
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			if (this.useDepthTexture)
			{
				this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.Depth);
			}
			int num = 4;
			if (this.resolution == SunShaftsResolution.Normal)
			{
				num = 2;
			}
			else if (this.resolution == SunShaftsResolution.High)
			{
				num = 1;
			}
			Vector3 vector = Vector3.one * 0.5f;
			if (this.sunTransform)
			{
				vector = this.GetComponent<Camera>().WorldToViewportPoint(this.sunTransform.position);
			}
			else
			{
				vector = new Vector3(0.5f, 0.5f, (float)0);
			}
			int width = source.width / num;
			int height = source.height / num;
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			this.sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4(1f, 1f, (float)0, (float)0) * this.sunShaftBlurRadius);
			this.sunShaftsMaterial.SetVector("_SunPosition", new Vector4(vector.x, vector.y, vector.z, this.maxRadius));
			this.sunShaftsMaterial.SetFloat("_NoSkyBoxMask", 1f - this.useSkyBoxAlpha);
			if (!this.useDepthTexture)
			{
				RenderTexture temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0);
				RenderTexture.active = temporary2;
				GL.ClearWithSkybox(false, this.GetComponent<Camera>());
				this.sunShaftsMaterial.SetTexture("_Skybox", temporary2);
				Graphics.Blit(source, temporary, this.sunShaftsMaterial, 3);
				RenderTexture.ReleaseTemporary(temporary2);
			}
			else
			{
				Graphics.Blit(source, temporary, this.sunShaftsMaterial, 2);
			}
			this.DrawBorder(temporary, this.simpleClearMaterial);
			this.radialBlurIterations = Mathf.Clamp(this.radialBlurIterations, 1, 4);
			float num2 = this.sunShaftBlurRadius * 0.00130208337f;
			this.sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4(num2, num2, (float)0, (float)0));
			this.sunShaftsMaterial.SetVector("_SunPosition", new Vector4(vector.x, vector.y, vector.z, this.maxRadius));
			for (int i = 0; i < this.radialBlurIterations; i++)
			{
				RenderTexture temporary3 = RenderTexture.GetTemporary(width, height, 0);
				Graphics.Blit(temporary, temporary3, this.sunShaftsMaterial, 1);
				RenderTexture.ReleaseTemporary(temporary);
				num2 = this.sunShaftBlurRadius * (((float)i * 2f + 1f) * 6f) / 768f;
				this.sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4(num2, num2, (float)0, (float)0));
				temporary = RenderTexture.GetTemporary(width, height, 0);
				Graphics.Blit(temporary3, temporary, this.sunShaftsMaterial, 1);
				RenderTexture.ReleaseTemporary(temporary3);
				num2 = this.sunShaftBlurRadius * (((float)i * 2f + 2f) * 6f) / 768f;
				this.sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4(num2, num2, (float)0, (float)0));
			}
			if (vector.z >= (float)0)
			{
				this.sunShaftsMaterial.SetVector("_SunColor", new Vector4(this.sunColor.r, this.sunColor.g, this.sunColor.b, this.sunColor.a) * this.sunShaftIntensity);
			}
			else
			{
				this.sunShaftsMaterial.SetVector("_SunColor", Vector4.zero);
			}
			this.sunShaftsMaterial.SetTexture("_ColorBuffer", temporary);
			Graphics.Blit(source, destination, this.sunShaftsMaterial, (this.screenBlendMode != ShaftsScreenBlendMode.Screen) ? 4 : 0);
			RenderTexture.ReleaseTemporary(temporary);
		}
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00025C60 File Offset: 0x00023E60
	public override void Main()
	{
	}

	// Token: 0x04000583 RID: 1411
	public SunShaftsResolution resolution;

	// Token: 0x04000584 RID: 1412
	public ShaftsScreenBlendMode screenBlendMode;

	// Token: 0x04000585 RID: 1413
	public Transform sunTransform;

	// Token: 0x04000586 RID: 1414
	public int radialBlurIterations;

	// Token: 0x04000587 RID: 1415
	public Color sunColor;

	// Token: 0x04000588 RID: 1416
	public float sunShaftBlurRadius;

	// Token: 0x04000589 RID: 1417
	public float sunShaftIntensity;

	// Token: 0x0400058A RID: 1418
	public float useSkyBoxAlpha;

	// Token: 0x0400058B RID: 1419
	public float maxRadius;

	// Token: 0x0400058C RID: 1420
	public bool useDepthTexture;

	// Token: 0x0400058D RID: 1421
	public Shader sunShaftsShader;

	// Token: 0x0400058E RID: 1422
	private Material sunShaftsMaterial;

	// Token: 0x0400058F RID: 1423
	public Shader simpleClearShader;

	// Token: 0x04000590 RID: 1424
	private Material simpleClearMaterial;
}
