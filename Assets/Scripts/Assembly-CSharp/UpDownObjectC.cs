using System;
using UnityEngine;

// Token: 0x0200009A RID: 154
public class UpDownObjectC : MonoBehaviour
{
	// Token: 0x06000492 RID: 1170 RVA: 0x00023DB0 File Offset: 0x000221B0
	private void Update()
	{
		base.transform.Translate(this.moveX * Time.deltaTime, this.moveY * Time.deltaTime, this.moveZ * Time.deltaTime);
		if (this.wait >= this.duration)
		{
			this.moveX *= -1f;
			this.moveY *= -1f;
			this.moveZ *= -1f;
			this.wait = 0f;
		}
		else
		{
			this.wait += Time.deltaTime;
		}
	}

	// Token: 0x0400049C RID: 1180
	public float moveX;

	// Token: 0x0400049D RID: 1181
	public float moveY = 5f;

	// Token: 0x0400049E RID: 1182
	public float moveZ;

	// Token: 0x0400049F RID: 1183
	private float wait;

	// Token: 0x040004A0 RID: 1184
	public float duration = 1f;
}
