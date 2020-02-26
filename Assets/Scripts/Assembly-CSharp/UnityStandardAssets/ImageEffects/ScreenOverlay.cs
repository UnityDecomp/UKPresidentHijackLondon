using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200019C RID: 412
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Other/Screen Overlay")]
	public class ScreenOverlay : PostEffectsBase
	{
		// Token: 0x06000B98 RID: 2968 RVA: 0x000484C8 File Offset: 0x000468C8
		public override bool CheckResources()
		{
			base.CheckSupport(false);
			this.overlayMaterial = base.CheckShaderAndCreateMaterial(this.overlayShader, this.overlayMaterial);
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00048504 File Offset: 0x00046904
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			Vector4 value = new Vector4(1f, 0f, 0f, 1f);
			this.overlayMaterial.SetVector("_UV_Transform", value);
			this.overlayMaterial.SetFloat("_Intensity", this.intensity);
			this.overlayMaterial.SetTexture("_Overlay", this.texture);
			Graphics.Blit(source, destination, this.overlayMaterial, (int)this.blendMode);
		}

		// Token: 0x04000B73 RID: 2931
		public ScreenOverlay.OverlayBlendMode blendMode = ScreenOverlay.OverlayBlendMode.Overlay;

		// Token: 0x04000B74 RID: 2932
		public float intensity = 1f;

		// Token: 0x04000B75 RID: 2933
		public Texture2D texture;

		// Token: 0x04000B76 RID: 2934
		public Shader overlayShader;

		// Token: 0x04000B77 RID: 2935
		private Material overlayMaterial;

		// Token: 0x0200019D RID: 413
		public enum OverlayBlendMode
		{
			// Token: 0x04000B79 RID: 2937
			Additive,
			// Token: 0x04000B7A RID: 2938
			ScreenBlend,
			// Token: 0x04000B7B RID: 2939
			Multiply,
			// Token: 0x04000B7C RID: 2940
			Overlay,
			// Token: 0x04000B7D RID: 2941
			AlphaBlend
		}
	}
}
