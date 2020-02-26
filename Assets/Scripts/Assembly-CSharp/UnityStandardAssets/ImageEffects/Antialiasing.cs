using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200016C RID: 364
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Other/Antialiasing")]
	public class Antialiasing : PostEffectsBase
	{
		// Token: 0x06000AEF RID: 2799 RVA: 0x000405E4 File Offset: 0x0003E9E4
		public Material CurrentAAMaterial()
		{
			Material result;
			switch (this.mode)
			{
			case AAMode.FXAA2:
				result = this.materialFXAAII;
				break;
			case AAMode.FXAA3Console:
				result = this.materialFXAAIII;
				break;
			case AAMode.FXAA1PresetA:
				result = this.materialFXAAPreset2;
				break;
			case AAMode.FXAA1PresetB:
				result = this.materialFXAAPreset3;
				break;
			case AAMode.NFAA:
				result = this.nfaa;
				break;
			case AAMode.SSAA:
				result = this.ssaa;
				break;
			case AAMode.DLAA:
				result = this.dlaa;
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00040680 File Offset: 0x0003EA80
		public override bool CheckResources()
		{
			base.CheckSupport(false);
			this.materialFXAAPreset2 = base.CreateMaterial(this.shaderFXAAPreset2, this.materialFXAAPreset2);
			this.materialFXAAPreset3 = base.CreateMaterial(this.shaderFXAAPreset3, this.materialFXAAPreset3);
			this.materialFXAAII = base.CreateMaterial(this.shaderFXAAII, this.materialFXAAII);
			this.materialFXAAIII = base.CreateMaterial(this.shaderFXAAIII, this.materialFXAAIII);
			this.nfaa = base.CreateMaterial(this.nfaaShader, this.nfaa);
			this.ssaa = base.CreateMaterial(this.ssaaShader, this.ssaa);
			this.dlaa = base.CreateMaterial(this.dlaaShader, this.dlaa);
			if (!this.ssaaShader.isSupported)
			{
				base.NotSupported();
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00040760 File Offset: 0x0003EB60
		public void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			if (this.mode == AAMode.FXAA3Console && this.materialFXAAIII != null)
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

		// Token: 0x040009DA RID: 2522
		public AAMode mode = AAMode.FXAA3Console;

		// Token: 0x040009DB RID: 2523
		public bool showGeneratedNormals;

		// Token: 0x040009DC RID: 2524
		public float offsetScale = 0.2f;

		// Token: 0x040009DD RID: 2525
		public float blurRadius = 18f;

		// Token: 0x040009DE RID: 2526
		public float edgeThresholdMin = 0.05f;

		// Token: 0x040009DF RID: 2527
		public float edgeThreshold = 0.2f;

		// Token: 0x040009E0 RID: 2528
		public float edgeSharpness = 4f;

		// Token: 0x040009E1 RID: 2529
		public bool dlaaSharp;

		// Token: 0x040009E2 RID: 2530
		public Shader ssaaShader;

		// Token: 0x040009E3 RID: 2531
		private Material ssaa;

		// Token: 0x040009E4 RID: 2532
		public Shader dlaaShader;

		// Token: 0x040009E5 RID: 2533
		private Material dlaa;

		// Token: 0x040009E6 RID: 2534
		public Shader nfaaShader;

		// Token: 0x040009E7 RID: 2535
		private Material nfaa;

		// Token: 0x040009E8 RID: 2536
		public Shader shaderFXAAPreset2;

		// Token: 0x040009E9 RID: 2537
		private Material materialFXAAPreset2;

		// Token: 0x040009EA RID: 2538
		public Shader shaderFXAAPreset3;

		// Token: 0x040009EB RID: 2539
		private Material materialFXAAPreset3;

		// Token: 0x040009EC RID: 2540
		public Shader shaderFXAAII;

		// Token: 0x040009ED RID: 2541
		private Material materialFXAAII;

		// Token: 0x040009EE RID: 2542
		public Shader shaderFXAAIII;

		// Token: 0x040009EF RID: 2543
		private Material materialFXAAIII;
	}
}
