using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000195 RID: 405
	[AddComponentMenu("")]
	public class ImageEffects
	{
		// Token: 0x06000B6C RID: 2924 RVA: 0x00046F20 File Offset: 0x00045320
		public static void RenderDistortion(Material material, RenderTexture source, RenderTexture destination, float angle, Vector2 center, Vector2 radius)
		{
			bool flag = source.texelSize.y < 0f;
			if (flag)
			{
				center.y = 1f - center.y;
				angle = -angle;
			}
			Matrix4x4 value = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, angle), Vector3.one);
			material.SetMatrix("_RotationMatrix", value);
			material.SetVector("_CenterRadius", new Vector4(center.x, center.y, radius.x, radius.y));
			material.SetFloat("_Angle", angle * 0.0174532924f);
			Graphics.Blit(source, destination, material);
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00046FD3 File Offset: 0x000453D3
		[Obsolete("Use Graphics.Blit(source,dest) instead")]
		public static void Blit(RenderTexture source, RenderTexture dest)
		{
			Graphics.Blit(source, dest);
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00046FDC File Offset: 0x000453DC
		[Obsolete("Use Graphics.Blit(source, destination, material) instead")]
		public static void BlitWithMaterial(Material material, RenderTexture source, RenderTexture dest)
		{
			Graphics.Blit(source, dest, material);
		}
	}
}
