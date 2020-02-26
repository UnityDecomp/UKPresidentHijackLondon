using System;
using UnityEngine;

// Token: 0x02000215 RID: 533
public class TPSCameraC : MonoBehaviour
{
	// Token: 0x06000DB5 RID: 3509 RVA: 0x00057BAC File Offset: 0x00055FAC
	private void Start()
	{
	}

	// Token: 0x06000DB6 RID: 3510 RVA: 0x00057BB0 File Offset: 0x00055FB0
	private void Update()
	{
		if (this.target)
		{
			this.target.transform.Rotate(new Vector3(0f, CFInput.GetAxis("Mouse X"), 0f) * (this.angularSpeed * 10f) * Time.deltaTime);
			if (this.lockOn)
			{
				base.transform.localEulerAngles = this.euler;
				this.RotUpDown = -CFInput.GetAxis("Mouse Y") * (this.angularSpeed * 10f) * Time.deltaTime;
				this.euler.y = this.euler.y + this.RotLeftRight;
				this.euler.x = this.euler.x + this.RotUpDown;
				if (this.euler.x >= this.maxY)
				{
					this.euler.x = this.maxY;
				}
				if (this.euler.x <= this.minY)
				{
					this.euler.x = this.minY;
				}
			}
		}
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x00057CCF File Offset: 0x000560CF
	public void shootMode()
	{
	}

	// Token: 0x06000DB8 RID: 3512 RVA: 0x00057CD1 File Offset: 0x000560D1
	public void melee()
	{
		this.euler = base.transform.localEulerAngles;
		this.lockOn = false;
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x00057CEB File Offset: 0x000560EB
	public void shoot()
	{
		this.euler = base.transform.localEulerAngles;
		this.lockOn = true;
	}

	// Token: 0x04000E71 RID: 3697
	public Transform target;

	// Token: 0x04000E72 RID: 3698
	public float angularSpeed = 50f;

	// Token: 0x04000E73 RID: 3699
	public float minY = -30f;

	// Token: 0x04000E74 RID: 3700
	public float maxY = 30f;

	// Token: 0x04000E75 RID: 3701
	private bool lockOn;

	// Token: 0x04000E76 RID: 3702
	private float RotLeftRight;

	// Token: 0x04000E77 RID: 3703
	private float RotUpDown;

	// Token: 0x04000E78 RID: 3704
	private Vector3 euler;
}
