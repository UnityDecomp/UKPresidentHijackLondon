using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x020001AC RID: 428
	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/Displacement/Twirl")]
	public class Twirl : ImageEffectBase
	{
		// Token: 0x06000BBB RID: 3003 RVA: 0x00049D65 File Offset: 0x00048165
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			ImageEffects.RenderDistortion(base.material, source, destination, this.angle, this.center, this.radius);
		}

		// Token: 0x04000BD7 RID: 3031
		public Vector2 radius = new Vector2(0.3f, 0.3f);

		// Token: 0x04000BD8 RID: 3032
		[Range(0f, 360f)]
		public float angle = 50f;

		// Token: 0x04000BD9 RID: 3033
		public Vector2 center = new Vector2(0.5f, 0.5f);
	}
}
