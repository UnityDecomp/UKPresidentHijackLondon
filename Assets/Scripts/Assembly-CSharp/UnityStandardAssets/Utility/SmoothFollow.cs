using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C7 RID: 455
	public class SmoothFollow : MonoBehaviour
	{
		// Token: 0x06000BFF RID: 3071 RVA: 0x0004BE2A File Offset: 0x0004A22A
		private void Start()
		{
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0004BE2C File Offset: 0x0004A22C
		private void LateUpdate()
		{
			if (!this.target)
			{
				return;
			}
			float y = this.target.eulerAngles.y;
			float b = this.target.position.y + this.height;
			float num = base.transform.eulerAngles.y;
			float num2 = base.transform.position.y;
			num = Mathf.LerpAngle(num, y, this.rotationDamping * Time.deltaTime);
			num2 = Mathf.Lerp(num2, b, this.heightDamping * Time.deltaTime);
			Quaternion rotation = Quaternion.Euler(0f, num, 0f);
			base.transform.position = this.target.position;
			base.transform.position -= rotation * Vector3.forward * this.distance;
			base.transform.position = new Vector3(base.transform.position.x, num2, base.transform.position.z);
			base.transform.LookAt(this.target);
		}

		// Token: 0x04000C51 RID: 3153
		[SerializeField]
		private Transform target;

		// Token: 0x04000C52 RID: 3154
		[SerializeField]
		private float distance = 10f;

		// Token: 0x04000C53 RID: 3155
		[SerializeField]
		private float height = 5f;

		// Token: 0x04000C54 RID: 3156
		[SerializeField]
		private float rotationDamping;

		// Token: 0x04000C55 RID: 3157
		[SerializeField]
		private float heightDamping;
	}
}
