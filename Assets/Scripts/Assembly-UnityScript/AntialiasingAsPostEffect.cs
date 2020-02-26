using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Other/Antialiasing")]
[ExecuteInEditMode]
[Serializable]
public class AntialiasingAsPostEffect : PostEffectsBase
{
	// Token: 0x06000267 RID: 615 RVA: 0x0001E1FC File Offset: 0x0001C3FC
	public AntialiasingAsPostEffect()
	{
		this.mode = AAMode.FXAA3Console;
		this.offsetScale = 0.2f;
		this.blurRadius = 18f;
		this.edgeThresholdMin = 0.05f;
		this.edgeThreshold = 0.2f;
		this.edgeSharpness = 4f;
	}

	// Token: 0x06000268 RID: 616 RVA: 0x0001E250 File Offset: 0x0001C450
	public virtual Material CurrentAAMaterial()
	{
		AAMode aamode = this.mode;
		Material result;
		if (aamode == AAMode.FXAA3Console)
		{
			result = this.materialFXAAIII;
		}
		else if (aamode == AAMode.FXAA2)
		{
			result = this.materialFXAAII;
		}
		else if (aamode == AAMode.FXAA1PresetA)
		{
			result = this.materialFXAAPreset2;
		}
		else if (aamode == AAMode.FXAA1PresetB)
		{
			result = this.materialFXAAPreset3;
		}
		else if (aamode == AAMode.NFAA)
		{
			result = this.nfaa;
		}
		else if (aamode == AAMode.SSAA)
		{
			result = this.ssaa;
		}
		else if (aamode == AAMode.DLAA)
		{
			result = this.dlaa;
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0001E2F4 File Offset: 0x0001C4F4
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.materialFXAAPreset2 = this.CreateMaterial(this.shaderFXAAPreset2, this.materialFXAAPreset2);
		this.materialFXAAPreset3 = this.CreateMaterial(this.shaderFXAAPreset3, this.materialFXAAPreset3);
		this.materialFXAAII = this.CreateMaterial(this.shaderFXAAII, this.materialFXAAII);
		this.materialFXAAIII = this.CreateMaterial(this.shaderFXAAIII, this.materialFXAAIII);
		this.nfaa = this.CreateMaterial(this.nfaaShader, this.nfaa);
		this.ssaa = this.CreateMaterial(this.ssaaShader, this.ssaa);
		this.dlaa = this.CreateMaterial(this.dlaaShader, this.dlaa);
		if (!this.ssaaShader.isSupported)
		{
			this.NotSupported();
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x0600026A RID: 618 RVA: 0x0001E3D4 File Offset: 0x0001C5D4
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else if (this.mode == AAMode.FXAA3Console && this.materialFXAAIII != null)
		{
			this.materialFXAAIII.SetFloat("_EdgeThresholdMin", this.edgeThresholdMin);
			this.materialFXAAIII.SetFloat("_EdgeThreshold", this.edgeThreshold);
			this.materialFXAAIII.SetFloat("_EdgeSharpness", this.edgeSharpness);
			Graphics.Blit(source, destination, this.materialFXAAIII);
		}
		else if (this.mode == AAMode.FXAA1PresetB && this.materialFXAAPreset3 != null)
		{
			Graphics.Blit(source, destination, this.materialFXAAPreset3);
		}
		else if (this.mode == AAMode.FXAA1PresetA && this.materialFXAAPreset2 != null)
		{
			source.anisoLevel = 4;
			Graphics.Blit(source, destination, this.materialFXAAPreset2);
			source.anisoLevel = 0;
		}
		else if (this.mode == AAMode.FXAA2 && this.materialFXAAII != null)
		{
			Graphics.Blit(source, destination, this.materialFXAAII);
		}
		else if (this.mode == AAMode.SSAA && this.ssaa != null)
		{
			Graphics.Blit(source, destination, this.ssaa);
		}
		else if (this.mode == AAMode.DLAA && this.dlaa != null)
		{
			source.anisoLevel = 0;
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height);
			Graphics.Blit(source, temporary, this.dlaa, 0);
			Graphics.Blit(temporary, destination, this.dlaa, (!this.dlaaSharp) ? 1 : 2);
			RenderTexture.ReleaseTemporary(temporary);
		}
		else if (this.mode == AAMode.NFAA && this.nfaa != null)
		{
			source.anisoLevel = 0;
			this.nfaa.SetFloat("_OffsetScale", this.offsetScale);
			this.nfaa.SetFloat("_BlurRadius", this.blurRadius);
			Graphics.Blit(source, destination, this.nfaa, (!this.showGeneratedNormals) ? 0 : 1);
		}
		else
		{
			Graphics.Blit(source, destination);
		}
	}

	// Token: 0x0600026B RID: 619 RVA: 0x0001E61C File Offset: 0x0001C81C
	public override void Main()
	{
	}

	// Token: 0x040003FB RID: 1019
	public AAMode mode;

	// Token: 0x040003FC RID: 1020
	public bool showGeneratedNormals;

	// Token: 0x040003FD RID: 1021
	public float offsetScale;

	// Token: 0x040003FE RID: 1022
	public float blurRadius;

	// Token: 0x040003FF RID: 1023
	public float edgeThresholdMin;

	// Token: 0x04000400 RID: 1024
	public float edgeThreshold;

	// Token: 0x04000401 RID: 1025
	public float edgeSharpness;

	// Token: 0x04000402 RID: 1026
	public bool dlaaSharp;

	// Token: 0x04000403 RID: 1027
	public Shader ssaaShader;

	// Token: 0x04000404 RID: 1028
	private Material ssaa;

	// Token: 0x04000405 RID: 1029
	public Shader dlaaShader;

	// Token: 0x04000406 RID: 1030
	private Material dlaa;

	// Token: 0x04000407 RID: 1031
	public Shader nfaaShader;

	// Token: 0x04000408 RID: 1032
	private Material nfaa;

	// Token: 0x04000409 RID: 1033
	public Shader shaderFXAAPreset2;

	// Token: 0x0400040A RID: 1034
	private Material materialFXAAPreset2;

	// Token: 0x0400040B RID: 1035
	public Shader shaderFXAAPreset3;

	// Token: 0x0400040C RID: 1036
	private Material materialFXAAPreset3;

	// Token: 0x0400040D RID: 1037
	public Shader shaderFXAAII;

	// Token: 0x0400040E RID: 1038
	private Material materialFXAAII;

	// Token: 0x0400040F RID: 1039
	public Shader shaderFXAAIII;

	// Token: 0x04000410 RID: 1040
	private Material materialFXAAIII;
}
