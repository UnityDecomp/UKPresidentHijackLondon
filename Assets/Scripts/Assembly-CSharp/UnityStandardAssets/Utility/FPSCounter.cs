using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001BF RID: 447
	[RequireComponent(typeof(Text))]
	public class FPSCounter : MonoBehaviour
	{
		// Token: 0x06000BE8 RID: 3048 RVA: 0x0004B189 File Offset: 0x00049589
		private void Start()
		{
			this.m_FpsNextPeriod = Time.realtimeSinceStartup + 0.5f;
			this.m_Text = base.GetComponent<Text>();
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x0004B1A8 File Offset: 0x000495A8
		private void Update()
		{
			this.m_FpsAccumulator++;
			if (Time.realtimeSinceStartup > this.m_FpsNextPeriod)
			{
				this.m_CurrentFps = (int)((float)this.m_FpsAccumulator / 0.5f);
				this.m_FpsAccumulator = 0;
				this.m_FpsNextPeriod += 0.5f;
				this.m_Text.text = string.Format("{0} FPS", this.m_CurrentFps);
			}
		}

		// Token: 0x04000C2C RID: 3116
		private const float fpsMeasurePeriod = 0.5f;

		// Token: 0x04000C2D RID: 3117
		private int m_FpsAccumulator;

		// Token: 0x04000C2E RID: 3118
		private float m_FpsNextPeriod;

		// Token: 0x04000C2F RID: 3119
		private int m_CurrentFps;

		// Token: 0x04000C30 RID: 3120
		private const string display = "{0} FPS";

		// Token: 0x04000C31 RID: 3121
		private Text m_Text;
	}
}
