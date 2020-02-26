using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001BC RID: 444
	public class FollowTarget : MonoBehaviour
	{
		// Token: 0x06000BDE RID: 3038 RVA: 0x0004ADFC File Offset: 0x000491FC
		private void LateUpdate()
		{
			base.transform.position = this.target.position + this.offset;
		}

		// Token: 0x04000C24 RID: 3108
		public Transform target;

		// Token: 0x04000C25 RID: 3109
		public Vector3 offset = new Vector3(0f, 7.5f, 0f);
	}
}
