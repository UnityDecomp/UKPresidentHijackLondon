using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000185 RID: 389
	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/Color Adjustments/Contrast Stretch")]
	public class ContrastStretch : MonoBehaviour
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x000440BD File Offset: 0x000424BD
		protected Material materialLum
		{
			get
			{
				if (this.m_materialLum == null)
				{
					this.m_materialLum = new Material(this.shaderLum);
					this.m_materialLum.hideFlags = HideFlags.HideAndDontSave;
				}
				return this.m_materialLum;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x000440F4 File Offset: 0x000424F4
		protected Material materialReduce
		{
			get
			{
				if (this.m_materialReduce == null)
				{
					this.m_materialReduce = new Material(this.shaderReduce);
					this.m_materialReduce.hideFlags = HideFlags.HideAndDontSave;
				}
				return this.m_materialReduce;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x0004412B File Offset: 0x0004252B
		protected Material materialAdapt
		{
			get
			{
				if (this.m_materialAdapt == null)
				{
					this.m_materialAdapt = new Material(this.shaderAdapt);
					this.m_materialAdapt.hideFlags = HideFlags.HideAndDontSave;
				}
				return this.m_materialAdapt;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x00044162 File Offset: 0x00042562
		protected Material materialApply
		{
			get
			{
				if (this.m_materialApply == null)
				{
					this.m_materialApply = new Material(this.shaderApply);
					this.m_materialApply.hideFlags = HideFlags.HideAndDontSave;
				}
				return this.m_materialApply;
			}
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0004419C File Offset: 0x0004259C
		private void Start()
		{
			if (!SystemInfo.supportsImageEffects)
			{
				base.enabled = false;
				return;
			}
			if (!this.shaderAdapt.isSupported || !this.shaderApply.isSupported || !this.shaderLum.isSupported || !this.shaderReduce.isSupported)
			{
				base.enabled = false;
				return;
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x00044204 File Offset: 0x00042604
		private void OnEnable()
		{
			for (int i = 0; i < 2; i++)
			{
				if (!this.adaptRenderTex[i])
				{
					this.adaptRenderTex[i] = new RenderTexture(1, 1, 0);
					this.adaptRenderTex[i].hideFlags = HideFlags.HideAndDontSave;
				}
			}
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00044254 File Offset: 0x00042654
		private void OnDisable()
		{
			for (int i = 0; i < 2; i++)
			{
				UnityEngine.Object.DestroyImmediate(this.adaptRenderTex[i]);
				this.adaptRenderTex[i] = null;
			}
			if (this.m_materialLum)
			{
				UnityEngine.Object.DestroyImmediate(this.m_materialLum);
			}
			if (this.m_materialReduce)
			{
				UnityEngine.Object.DestroyImmediate(this.m_materialReduce);
			}
			if (this.m_materialAdapt)
			{
				UnityEngine.Object.DestroyImmediate(this.m_materialAdapt);
			}
			if (this.m_materialApply)
			{
				UnityEngine.Object.DestroyImmediate(this.m_materialApply);
			}
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x000442F8 File Offset: 0x000426F8
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			RenderTexture renderTexture = RenderTexture.GetTemporary(source.width, source.height);
			Graphics.Blit(source, renderTexture, this.materialLum);
			while (renderTexture.width > 1 || renderTexture.height > 1)
			{
				int num = renderTexture.width / 2;
				if (num < 1)
				{
					num = 1;
				}
				int num2 = renderTexture.height / 2;
				if (num2 < 1)
				{
					num2 = 1;
				}
				RenderTexture temporary = RenderTexture.GetTemporary(num, num2);
				Graphics.Blit(renderTexture, temporary, this.materialReduce);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
			}
			this.CalculateAdaptation(renderTexture);
			this.materialApply.SetTexture("_AdaptTex", this.adaptRenderTex[this.curAdaptIndex]);
			Graphics.Blit(source, destination, this.materialApply);
			RenderTexture.ReleaseTemporary(renderTexture);
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x000443BC File Offset: 0x000427BC
		private void CalculateAdaptation(Texture curTexture)
		{
			int num = this.curAdaptIndex;
			this.curAdaptIndex = (this.curAdaptIndex + 1) % 2;
			float num2 = 1f - Mathf.Pow(1f - this.adaptationSpeed, 30f * Time.deltaTime);
			num2 = Mathf.Clamp(num2, 0.01f, 1f);
			this.materialAdapt.SetTexture("_CurTex", curTexture);
			this.materialAdapt.SetVector("_AdaptParams", new Vector4(num2, this.limitMinimum, this.limitMaximum, 0f));
			Graphics.SetRenderTarget(this.adaptRenderTex[this.curAdaptIndex]);
			GL.Clear(false, true, Color.black);
			Graphics.Blit(this.adaptRenderTex[num], this.adaptRenderTex[this.curAdaptIndex], this.materialAdapt);
		}

		// Token: 0x04000AB5 RID: 2741
		[Range(0.0001f, 1f)]
		public float adaptationSpeed = 0.02f;

		// Token: 0x04000AB6 RID: 2742
		[Range(0f, 1f)]
		public float limitMinimum = 0.2f;

		// Token: 0x04000AB7 RID: 2743
		[Range(0f, 1f)]
		public float limitMaximum = 0.6f;

		// Token: 0x04000AB8 RID: 2744
		private RenderTexture[] adaptRenderTex = new RenderTexture[2];

		// Token: 0x04000AB9 RID: 2745
		private int curAdaptIndex;

		// Token: 0x04000ABA RID: 2746
		public Shader shaderLum;

		// Token: 0x04000ABB RID: 2747
		private Material m_materialLum;

		// Token: 0x04000ABC RID: 2748
		public Shader shaderReduce;

		// Token: 0x04000ABD RID: 2749
		private Material m_materialReduce;

		// Token: 0x04000ABE RID: 2750
		public Shader shaderAdapt;

		// Token: 0x04000ABF RID: 2751
		private Material m_materialAdapt;

		// Token: 0x04000AC0 RID: 2752
		public Shader shaderApply;

		// Token: 0x04000AC1 RID: 2753
		private Material m_materialApply;
	}
}
