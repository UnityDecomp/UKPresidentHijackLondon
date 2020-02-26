using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000193 RID: 403
	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/Color Adjustments/Grayscale")]
	public class Grayscale : ImageEffectBase
	{
		// Token: 0x06000B66 RID: 2918 RVA: 0x00046EDD File Offset: 0x000452DD
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetTexture("_RampTex", this.textureRamp);
			base.material.SetFloat("_RampOffset", this.rampOffset);
			Graphics.Blit(source, destination, base.material);
		}

		// Token: 0x04000B43 RID: 2883
		public Texture textureRamp;

		// Token: 0x04000B44 RID: 2884
		[Range(-1f, 1f)]
		public float rampOffset;
	}
}
