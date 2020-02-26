using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C0 RID: 448
	[Serializable]
	public class LerpControlledBob
	{
		// Token: 0x06000BEB RID: 3051 RVA: 0x0004B228 File Offset: 0x00049628
		public float Offset()
		{
			return this.m_Offset;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0004B230 File Offset: 0x00049630
		public IEnumerator DoBobCycle()
		{
			float t = 0f;
			while (t < this.BobDuration)
			{
				this.m_Offset = Mathf.Lerp(0f, this.BobAmount, t / this.BobDuration);
				t += Time.deltaTime;
				yield return new WaitForFixedUpdate();
			}
			t = 0f;
			while (t < this.BobDuration)
			{
				this.m_Offset = Mathf.Lerp(this.BobAmount, 0f, t / this.BobDuration);
				t += Time.deltaTime;
				yield return new WaitForFixedUpdate();
			}
			this.m_Offset = 0f;
			yield break;
		}

		// Token: 0x04000C32 RID: 3122
		public float BobDuration;

		// Token: 0x04000C33 RID: 3123
		public float BobAmount;

		// Token: 0x04000C34 RID: 3124
		private float m_Offset;
	}
}
