using System;
using UnityEngine;

// Token: 0x020001EE RID: 494
public class CameraDirector : MonoBehaviour
{
	// Token: 0x06000CCC RID: 3276 RVA: 0x000507EC File Offset: 0x0004EBEC
	private void Update()
	{
		if (this.allowCam)
		{
			if (this.camType == CameraDirector.CamType.RotateItself)
			{
				base.transform.Rotate(Vector3.up * this.speed * Time.deltaTime);
			}
			if (this.camType == CameraDirector.CamType.RotateAround)
			{
				base.transform.LookAt(this.target.position);
				base.transform.RotateAround(this.target.position, Vector3.up, this.speed * Time.deltaTime);
			}
			if (this.camType == CameraDirector.CamType.MoveToward)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, this.target.position, this.speed * Time.deltaTime);
			}
		}
	}

	// Token: 0x04000D39 RID: 3385
	public CameraDirector.CamType camType;

	// Token: 0x04000D3A RID: 3386
	public Transform target;

	// Token: 0x04000D3B RID: 3387
	public float speed = 10f;

	// Token: 0x04000D3C RID: 3388
	[HideInInspector]
	public bool allowCam;

	// Token: 0x020001EF RID: 495
	public enum CamType
	{
		// Token: 0x04000D3E RID: 3390
		RotateItself,
		// Token: 0x04000D3F RID: 3391
		RotateAround,
		// Token: 0x04000D40 RID: 3392
		MoveToward
	}
}
