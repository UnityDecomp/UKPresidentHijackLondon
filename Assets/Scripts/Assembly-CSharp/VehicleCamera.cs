using System;
using UnityEngine;

// Token: 0x02000218 RID: 536
public class VehicleCamera : MonoBehaviour
{
	// Token: 0x06000DCA RID: 3530 RVA: 0x00057FDC File Offset: 0x000563DC
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			this.Switch++;
			if (this.Switch > this.cameraSwitchView.Length)
			{
				this.Switch = 0;
			}
		}
		if (this.Switch == 0)
		{
			if (!this.target)
			{
				return;
			}
			float y = Mathf.SmoothDampAngle(base.transform.eulerAngles.y, this.target.eulerAngles.y, ref this.yVelocity, this.smooth);
			float num = Mathf.SmoothDampAngle(base.transform.eulerAngles.x, this.target.eulerAngles.x + this.Angle, ref this.xVelocity, this.smooth);
			Vector3 a = this.target.position;
			a += Quaternion.Euler(this.Angle, y, 0f) * new Vector3(0f, 0f, -this.distance);
			base.transform.eulerAngles = new Vector3(this.Angle, y, 0f);
			Vector3 vector = base.transform.rotation * -Vector3.forward;
			float d = this.AdjustLineOfSight(this.target.position + new Vector3(0f, this.height, 0f), vector);
			base.transform.position = this.target.position + new Vector3(0f, this.height, 0f) + vector * d;
		}
		else
		{
			base.transform.position = this.cameraSwitchView[this.Switch - 1].position;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.cameraSwitchView[this.Switch - 1].rotation, Time.deltaTime * 5f);
		}
	}

	// Token: 0x06000DCB RID: 3531 RVA: 0x000581F8 File Offset: 0x000565F8
	private float AdjustLineOfSight(Vector3 target, Vector3 direction)
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(target, direction, out raycastHit, this.distance, this.lineOfSightMask.value))
		{
			return raycastHit.distance;
		}
		return this.distance;
	}

	// Token: 0x06000DCC RID: 3532 RVA: 0x00058232 File Offset: 0x00056632
	public void CamSwitch()
	{
		this.Switch++;
		if (this.Switch > this.cameraSwitchView.Length)
		{
			this.Switch = 0;
		}
	}

	// Token: 0x06000DCD RID: 3533 RVA: 0x0005825C File Offset: 0x0005665C
	public void OnGUI()
	{
	}

	// Token: 0x04000E83 RID: 3715
	public Transform target;

	// Token: 0x04000E84 RID: 3716
	public float smooth = 0.3f;

	// Token: 0x04000E85 RID: 3717
	public float distance = 5f;

	// Token: 0x04000E86 RID: 3718
	public float height = 1f;

	// Token: 0x04000E87 RID: 3719
	public float Angle = 20f;

	// Token: 0x04000E88 RID: 3720
	public Transform[] cameraSwitchView;

	// Token: 0x04000E89 RID: 3721
	public LayerMask lineOfSightMask = 0;

	// Token: 0x04000E8A RID: 3722
	public GUISkin GUISkin;

	// Token: 0x04000E8B RID: 3723
	private float yVelocity;

	// Token: 0x04000E8C RID: 3724
	private float xVelocity;

	// Token: 0x04000E8D RID: 3725
	private int Switch;
}
