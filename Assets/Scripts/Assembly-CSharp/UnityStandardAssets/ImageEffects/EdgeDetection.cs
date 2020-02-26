using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200018F RID: 399
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Edge Detection/Edge Detection")]
	public class EdgeDetection : PostEffectsBase
	{
		// Token: 0x06000B59 RID: 2905 RVA: 0x00046710 File Offset: 0x00044B10
		public override bool CheckResources()
		{
			base.CheckSupport(true);
			this.edgeDetectMaterial = base.CheckShaderAndCreateMaterial(this.edgeDetectShader, this.edgeDetectMaterial);
			if (this.mode != this.oldMode)
			{
				this.SetCameraFlag();
			}
			this.oldMode = this.mode;
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x00046777 File Offset: 0x00044B77
		private new void Start()
		{
			this.oldMode = this.mode;
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00046788 File Offset: 0x00044B88
		private void SetCameraFlag()
		{
			if (this.mode == EdgeDetection.EdgeDetectMode.SobelDepth || this.mode == EdgeDetection.EdgeDetectMode.SobelDepthThin)
			{
				base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
			}
			else if (this.mode == EdgeDetection.EdgeDetectMode.TriangleDepthNormals || this.mode == EdgeDetection.EdgeDetectMode.RobertsCrossDepthNormals)
			{
				base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
			}
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x000467EF File Offset: 0x00044BEF
		private void OnEnable()
		{
			this.SetCameraFlag();
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x000467F8 File Offset: 0x00044BF8
		[ImageEffectOpaque]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			Vector2 vector = new Vector2(this.sensitivityDepth, this.sensitivityNormals);
			this.edgeDetectMaterial.SetVector("_Sensitivity", new Vector4(vector.x, vector.y, 1f, vector.y));
			this.edgeDetectMaterial.SetFloat("_BgFade", this.edgesOnly);
			this.edgeDetectMaterial.SetFloat("_SampleDistance", this.sampleDist);
			this.edgeDetectMaterial.SetVector("_BgColor", this.edgesOnlyBgColor);
			this.edgeDetectMaterial.SetFloat("_Exponent", this.edgeExp);
			this.edgeDetectMaterial.SetFloat("_Threshold", this.lumThreshold);
			Graphics.Blit(source, destination, this.edgeDetectMaterial, (int)this.mode);
		}

		// Token: 0x04000B25 RID: 2853
		public EdgeDetection.EdgeDetectMode mode = EdgeDetection.EdgeDetectMode.SobelDepthThin;

		// Token: 0x04000B26 RID: 2854
		public float sensitivityDepth = 1f;

		// Token: 0x04000B27 RID: 2855
		public float sensitivityNormals = 1f;

		// Token: 0x04000B28 RID: 2856
		public float lumThreshold = 0.2f;

		// Token: 0x04000B29 RID: 2857
		public float edgeExp = 1f;

		// Token: 0x04000B2A RID: 2858
		public float sampleDist = 1f;

		// Token: 0x04000B2B RID: 2859
		public float edgesOnly;

		// Token: 0x04000B2C RID: 2860
		public Color edgesOnlyBgColor = Color.white;

		// Token: 0x04000B2D RID: 2861
		public Shader edgeDetectShader;

		// Token: 0x04000B2E RID: 2862
		private Material edgeDetectMaterial;

		// Token: 0x04000B2F RID: 2863
		private EdgeDetection.EdgeDetectMode oldMode = EdgeDetection.EdgeDetectMode.SobelDepthThin;

		// Token: 0x02000190 RID: 400
		public enum EdgeDetectMode
		{
			// Token: 0x04000B31 RID: 2865
			TriangleDepthNormals,
			// Token: 0x04000B32 RID: 2866
			RobertsCrossDepthNormals,
			// Token: 0x04000B33 RID: 2867
			SobelDepth,
			// Token: 0x04000B34 RID: 2868
			SobelDepthThin,
			// Token: 0x04000B35 RID: 2869
			TriangleLuminance
		}
	}
}
