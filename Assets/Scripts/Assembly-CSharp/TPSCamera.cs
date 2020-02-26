using System;
using UnityEngine;

// Token: 0x02000214 RID: 532
public class TPSCamera : MonoBehaviour
{
	// Token: 0x06000DB1 RID: 3505 RVA: 0x00057AC6 File Offset: 0x00055EC6
	private void Start()
	{
	}

	// Token: 0x06000DB2 RID: 3506 RVA: 0x00057AC8 File Offset: 0x00055EC8
	private void Update()
	{
		this.target.transform.Rotate(new Vector3(0f, CFInput.GetAxis("Mouse X"), 0f) * (this.XSpeed * 100f) * Time.deltaTime);
		if (this.enableYAxis)
		{
			base.transform.Rotate(new Vector3(CFInput.GetAxis("Mouse Y"), 0f, 0f) * (this.YSpeed * 100f) * Time.deltaTime);
		}
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x00057B63 File Offset: 0x00055F63
	public void shootMode()
	{
		if (!this.enableYAxis)
		{
			this.enableYAxis = true;
		}
		else
		{
			this.enableYAxis = false;
		}
	}

	// Token: 0x04000E6D RID: 3693
	public Transform target;

	// Token: 0x04000E6E RID: 3694
	public float XSpeed = 1f;

	// Token: 0x04000E6F RID: 3695
	public float YSpeed = 1f;

	// Token: 0x04000E70 RID: 3696
	[HideInInspector]
	public bool enableYAxis;
}
