using System;
using UnityEngine;

// Token: 0x020001FB RID: 507
public class Pointer : MonoBehaviour
{
	// Token: 0x06000CF5 RID: 3317 RVA: 0x000515F7 File Offset: 0x0004F9F7
	private void Start()
	{
		this.temp = this.finalPosition;
		base.Invoke("ResetPosition", 0.5f);
	}

	// Token: 0x06000CF6 RID: 3318 RVA: 0x00051615 File Offset: 0x0004FA15
	private void Update()
	{
		base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, this.temp, Time.deltaTime);
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x00051640 File Offset: 0x0004FA40
	private void ResetPosition()
	{
		this.isUp = !this.isUp;
		if (this.isUp)
		{
			this.temp = this.initPosition;
		}
		else
		{
			this.temp = this.finalPosition;
		}
		base.Invoke("ResetPosition", 0.5f);
	}

	// Token: 0x04000D7E RID: 3454
	public Vector3 initPosition;

	// Token: 0x04000D7F RID: 3455
	public Vector3 finalPosition;

	// Token: 0x04000D80 RID: 3456
	private Vector3 temp;

	// Token: 0x04000D81 RID: 3457
	private bool isUp;
}
