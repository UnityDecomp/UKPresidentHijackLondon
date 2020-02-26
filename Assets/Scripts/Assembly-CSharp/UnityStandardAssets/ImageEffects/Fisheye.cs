using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000191 RID: 401
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Displacement/Fisheye")]
	public class Fisheye : PostEffectsBase
	{
		// Token: 0x06000B5F RID: 2911 RVA: 0x000468FE File Offset: 0x00044CFE
		public override bool CheckResources()
		{
			base.CheckSupport(false);
			this.fisheyeMaterial = base.CheckShaderAndCreateMaterial(this.fishEyeShader, this.fisheyeMaterial);
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00046938 File Offset: 0x00044D38
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			float num = 0.15625f;
			float num2 = (float)source.width * 1f / ((float)source.height * 1f);
			this.fisheyeMaterial.SetVector("intensity", new Vector4(this.strengthX * num2 * num, this.strengthY * num, this.strengthX * num2 * num, this.strengthY * num));
			Graphics.Blit(source, destination, this.fisheyeMaterial);
		}

		// Token: 0x04000B36 RID: 2870
		[Range(0f, 1.5f)]
		public float strengthX = 0.05f;

		// Token: 0x04000B37 RID: 2871
		[Range(0f, 1.5f)]
		public float strengthY = 0.05f;

		// Token: 0x04000B38 RID: 2872
		public Shader fishEyeShader;

		// Token: 0x04000B39 RID: 2873
		private Material fisheyeMaterial;
	}
}
