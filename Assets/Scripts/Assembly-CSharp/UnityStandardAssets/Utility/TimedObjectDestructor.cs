using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001CC RID: 460
	public class TimedObjectDestructor : MonoBehaviour
	{
		// Token: 0x06000C09 RID: 3081 RVA: 0x0004C28F File Offset: 0x0004A68F
		private void Awake()
		{
			base.Invoke("DestroyNow", this.m_TimeOut);
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0004C2A2 File Offset: 0x0004A6A2
		private void DestroyNow()
		{
			if (this.m_DetachChildren)
			{
				base.transform.DetachChildren();
			}
			UnityEngine.Object.DestroyObject(base.gameObject);
		}

		// Token: 0x04000C61 RID: 3169
		[SerializeField]
		private float m_TimeOut = 1f;

		// Token: 0x04000C62 RID: 3170
		[SerializeField]
		private bool m_DetachChildren;
	}
}
