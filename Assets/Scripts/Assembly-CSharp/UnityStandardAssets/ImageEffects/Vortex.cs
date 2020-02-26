using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x020001AF RID: 431
	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/Displacement/Vortex")]
	public class Vortex : ImageEffectBase
	{
		// Token: 0x06000BC0 RID: 3008 RVA: 0x0004A15B File Offset: 0x0004855B
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			ImageEffects.RenderDistortion(base.material, source, destination, this.angle, this.center, this.radius);
		}

		// Token: 0x04000BEB RID: 3051
		public Vector2 radius = new Vector2(0.4f, 0.4f);

		// Token: 0x04000BEC RID: 3052
		public float angle = 50f;

		// Token: 0x04000BED RID: 3053
		public Vector2 center = new Vector2(0.5f, 0.5f);
	}
}
