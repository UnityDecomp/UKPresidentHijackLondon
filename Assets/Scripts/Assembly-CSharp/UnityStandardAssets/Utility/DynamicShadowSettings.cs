using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001BA RID: 442
	public class DynamicShadowSettings : MonoBehaviour
	{
		// Token: 0x06000BD9 RID: 3033 RVA: 0x0004AC77 File Offset: 0x00049077
		private void Start()
		{
			this.m_OriginalStrength = this.sunLight.shadowStrength;
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0004AC8C File Offset: 0x0004908C
		private void Update()
		{
			Ray ray = new Ray(Camera.main.transform.position, -Vector3.up);
			float num = base.transform.position.y;
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				num = raycastHit.distance;
			}
			if (Mathf.Abs(num - this.m_SmoothHeight) > 1f)
			{
				this.m_SmoothHeight = Mathf.SmoothDamp(this.m_SmoothHeight, num, ref this.m_ChangeSpeed, this.adaptTime);
			}
			float num2 = Mathf.InverseLerp(this.minHeight, this.maxHeight, this.m_SmoothHeight);
			QualitySettings.shadowDistance = Mathf.Lerp(this.minShadowDistance, this.maxShadowDistance, num2);
			this.sunLight.shadowBias = Mathf.Lerp(this.minShadowBias, this.maxShadowBias, 1f - (1f - num2) * (1f - num2));
			this.sunLight.shadowStrength = Mathf.Lerp(this.m_OriginalStrength, 0f, num2);
		}

		// Token: 0x04000C19 RID: 3097
		public Light sunLight;

		// Token: 0x04000C1A RID: 3098
		public float minHeight = 10f;

		// Token: 0x04000C1B RID: 3099
		public float minShadowDistance = 80f;

		// Token: 0x04000C1C RID: 3100
		public float minShadowBias = 1f;

		// Token: 0x04000C1D RID: 3101
		public float maxHeight = 1000f;

		// Token: 0x04000C1E RID: 3102
		public float maxShadowDistance = 10000f;

		// Token: 0x04000C1F RID: 3103
		public float maxShadowBias = 0.1f;

		// Token: 0x04000C20 RID: 3104
		public float adaptTime = 1f;

		// Token: 0x04000C21 RID: 3105
		private float m_SmoothHeight;

		// Token: 0x04000C22 RID: 3106
		private float m_ChangeSpeed;

		// Token: 0x04000C23 RID: 3107
		private float m_OriginalStrength = 1f;
	}
}
