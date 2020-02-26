using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000194 RID: 404
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("")]
	public class ImageEffectBase : MonoBehaviour
	{
		// Token: 0x06000B68 RID: 2920 RVA: 0x00043DF1 File Offset: 0x000421F1
		protected virtual void Start()
		{
			if (!SystemInfo.supportsImageEffects)
			{
				base.enabled = false;
				return;
			}
			if (!this.shader || !this.shader.isSupported)
			{
				base.enabled = false;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x00043E2C File Offset: 0x0004222C
		protected Material material
		{
			get
			{
				if (this.m_Material == null)
				{
					this.m_Material = new Material(this.shader);
					this.m_Material.hideFlags = HideFlags.HideAndDontSave;
				}
				return this.m_Material;
			}
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x00043E63 File Offset: 0x00042263
		protected virtual void OnDisable()
		{
			if (this.m_Material)
			{
				UnityEngine.Object.DestroyImmediate(this.m_Material);
			}
		}

		// Token: 0x04000B45 RID: 2885
		public Shader shader;

		// Token: 0x04000B46 RID: 2886
		private Material m_Material;
	}
}
