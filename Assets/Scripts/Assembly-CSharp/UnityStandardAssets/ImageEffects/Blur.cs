using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200017B RID: 379
	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/Blur/Blur")]
	public class Blur : MonoBehaviour
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000B06 RID: 2822 RVA: 0x000421F0 File Offset: 0x000405F0
		protected Material material
		{
			get
			{
				if (Blur.m_Material == null)
				{
					Blur.m_Material = new Material(this.blurShader);
					Blur.m_Material.hideFlags = HideFlags.DontSave;
				}
				return Blur.m_Material;
			}
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00042223 File Offset: 0x00040623
		protected void OnDisable()
		{
			if (Blur.m_Material)
			{
				UnityEngine.Object.DestroyImmediate(Blur.m_Material);
			}
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00042240 File Offset: 0x00040640
		protected void Start()
		{
			if (!SystemInfo.supportsImageEffects)
			{
				base.enabled = false;
				return;
			}
			if (!this.blurShader || !this.material.shader.isSupported)
			{
				base.enabled = false;
				return;
			}
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0004228C File Offset: 0x0004068C
		public void FourTapCone(RenderTexture source, RenderTexture dest, int iteration)
		{
			float num = 0.5f + (float)iteration * this.blurSpread;
			Graphics.BlitMultiTap(source, dest, this.material, new Vector2[]
			{
				new Vector2(-num, -num),
				new Vector2(-num, num),
				new Vector2(num, num),
				new Vector2(num, -num)
			});
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0004230C File Offset: 0x0004070C
		private void DownSample4x(RenderTexture source, RenderTexture dest)
		{
			float num = 1f;
			Graphics.BlitMultiTap(source, dest, this.material, new Vector2[]
			{
				new Vector2(-num, -num),
				new Vector2(-num, num),
				new Vector2(num, num),
				new Vector2(num, -num)
			});
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00042384 File Offset: 0x00040784
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			int width = source.width / 4;
			int height = source.height / 4;
			RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 0);
			this.DownSample4x(source, renderTexture);
			for (int i = 0; i < this.iterations; i++)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
				this.FourTapCone(renderTexture, temporary, i);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
			}
			Graphics.Blit(renderTexture, destination);
			RenderTexture.ReleaseTemporary(renderTexture);
		}

		// Token: 0x04000A5D RID: 2653
		[Range(0f, 10f)]
		public int iterations = 3;

		// Token: 0x04000A5E RID: 2654
		[Range(0f, 1f)]
		public float blurSpread = 0.6f;

		// Token: 0x04000A5F RID: 2655
		public Shader blurShader;

		// Token: 0x04000A60 RID: 2656
		private static Material m_Material;
	}
}
