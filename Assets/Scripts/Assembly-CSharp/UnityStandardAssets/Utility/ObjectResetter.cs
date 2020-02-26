using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C1 RID: 449
	public class ObjectResetter : MonoBehaviour
	{
		// Token: 0x06000BEE RID: 3054 RVA: 0x0004B3E4 File Offset: 0x000497E4
		private void Start()
		{
			this.originalStructure = new List<Transform>(base.GetComponentsInChildren<Transform>());
			this.originalPosition = base.transform.position;
			this.originalRotation = base.transform.rotation;
			this.Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0004B430 File Offset: 0x00049830
		public void DelayedReset(float delay)
		{
			base.StartCoroutine(this.ResetCoroutine(delay));
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0004B440 File Offset: 0x00049840
		public IEnumerator ResetCoroutine(float delay)
		{
			yield return new WaitForSeconds(delay);
			foreach (Transform transform in base.GetComponentsInChildren<Transform>())
			{
				if (!this.originalStructure.Contains(transform))
				{
					transform.parent = null;
				}
			}
			base.transform.position = this.originalPosition;
			base.transform.rotation = this.originalRotation;
			if (this.Rigidbody)
			{
				this.Rigidbody.velocity = Vector3.zero;
				this.Rigidbody.angularVelocity = Vector3.zero;
			}
			base.SendMessage("Reset");
			yield break;
		}

		// Token: 0x04000C35 RID: 3125
		private Vector3 originalPosition;

		// Token: 0x04000C36 RID: 3126
		private Quaternion originalRotation;

		// Token: 0x04000C37 RID: 3127
		private List<Transform> originalStructure;

		// Token: 0x04000C38 RID: 3128
		private Rigidbody Rigidbody;
	}
}
