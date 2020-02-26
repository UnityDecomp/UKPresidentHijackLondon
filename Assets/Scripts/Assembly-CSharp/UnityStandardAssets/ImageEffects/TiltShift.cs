using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x020001A5 RID: 421
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Camera/Tilt Shift (Lens Blur)")]
	internal class TiltShift : PostEffectsBase
	{
		// Token: 0x06000BAC RID: 2988 RVA: 0x00049219 File Offset: 0x00047619
		public override bool CheckResources()
		{
			base.CheckSupport(true);
			this.tiltShiftMaterial = base.CheckShaderAndCreateMaterial(this.tiltShiftShader, this.tiltShiftMaterial);
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x00049254 File Offset: 0x00047654
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			this.tiltShiftMaterial.SetFloat("_BlurSize", (this.maxBlurSize >= 0f) ? this.maxBlurSize : 0f);
			this.tiltShiftMaterial.SetFloat("_BlurArea", this.blurArea);
			source.filterMode = FilterMode.Bilinear;
			RenderTexture renderTexture = destination;
			if ((float)this.downsample > 0f)
			{
				renderTexture = RenderTexture.GetTemporary(source.width >> this.downsample, source.height >> this.downsample, 0, source.format);
				renderTexture.filterMode = FilterMode.Bilinear;
			}
			int num = (int)this.quality;
			num *= 2;
			Graphics.Blit(source, renderTexture, this.tiltShiftMaterial, (this.mode != TiltShift.TiltShiftMode.TiltShiftMode) ? (num + 1) : num);
			if (this.downsample > 0)
			{
				this.tiltShiftMaterial.SetTexture("_Blurred", renderTexture);
				Graphics.Blit(source, destination, this.tiltShiftMaterial, 6);
			}
			if (renderTexture != destination)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
			}
		}

		// Token: 0x04000BAA RID: 2986
		public TiltShift.TiltShiftMode mode;

		// Token: 0x04000BAB RID: 2987
		public TiltShift.TiltShiftQuality quality = TiltShift.TiltShiftQuality.Normal;

		// Token: 0x04000BAC RID: 2988
		[Range(0f, 15f)]
		public float blurArea = 1f;

		// Token: 0x04000BAD RID: 2989
		[Range(0f, 25f)]
		public float maxBlurSize = 5f;

		// Token: 0x04000BAE RID: 2990
		[Range(0f, 1f)]
		public int downsample;

		// Token: 0x04000BAF RID: 2991
		public Shader tiltShiftShader;

		// Token: 0x04000BB0 RID: 2992
		private Material tiltShiftMaterial;

		// Token: 0x020001A6 RID: 422
		public enum TiltShiftMode
		{
			// Token: 0x04000BB2 RID: 2994
			TiltShiftMode,
			// Token: 0x04000BB3 RID: 2995
			IrisMode
		}

		// Token: 0x020001A7 RID: 423
		public enum TiltShiftQuality
		{
			// Token: 0x04000BB5 RID: 2997
			Preview,
			// Token: 0x04000BB6 RID: 2998
			Normal,
			// Token: 0x04000BB7 RID: 2999
			High
		}
	}
}
