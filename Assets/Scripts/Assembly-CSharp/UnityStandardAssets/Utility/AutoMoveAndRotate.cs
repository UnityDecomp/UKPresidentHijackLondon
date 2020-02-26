using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001B5 RID: 437
	public class AutoMoveAndRotate : MonoBehaviour
	{
		// Token: 0x06000BC9 RID: 3017 RVA: 0x0004A57C File Offset: 0x0004897C
		private void Start()
		{
			this.m_LastRealTime = Time.realtimeSinceStartup;
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0004A58C File Offset: 0x0004898C
		private void Update()
		{
			float d = Time.deltaTime;
			if (this.ignoreTimescale)
			{
				d = Time.realtimeSinceStartup - this.m_LastRealTime;
				this.m_LastRealTime = Time.realtimeSinceStartup;
			}
			base.transform.Translate(this.moveUnitsPerSecond.value * d, this.moveUnitsPerSecond.space);
			base.transform.Rotate(this.rotateDegreesPerSecond.value * d, this.moveUnitsPerSecond.space);
		}

		// Token: 0x04000BFE RID: 3070
		public AutoMoveAndRotate.Vector3andSpace moveUnitsPerSecond;

		// Token: 0x04000BFF RID: 3071
		public AutoMoveAndRotate.Vector3andSpace rotateDegreesPerSecond;

		// Token: 0x04000C00 RID: 3072
		public bool ignoreTimescale;

		// Token: 0x04000C01 RID: 3073
		private float m_LastRealTime;

		// Token: 0x020001B6 RID: 438
		[Serializable]
		public class Vector3andSpace
		{
			// Token: 0x04000C02 RID: 3074
			public Vector3 value;

			// Token: 0x04000C03 RID: 3075
			public Space space = Space.Self;
		}
	}
}
