using System;
using UnityEngine;

// Token: 0x02000110 RID: 272
public class CFX_Demo_RotateCamera : MonoBehaviour
{
	// Token: 0x06000759 RID: 1881 RVA: 0x00030FCD File Offset: 0x0002F3CD
	private void Update()
	{
		if (CFX_Demo_RotateCamera.rotating)
		{
			base.transform.RotateAround(this.rotationCenter.position, Vector3.up, this.speed * Time.deltaTime);
		}
	}

	// Token: 0x0400066B RID: 1643
	public static bool rotating = true;

	// Token: 0x0400066C RID: 1644
	public float speed = 30f;

	// Token: 0x0400066D RID: 1645
	public Transform rotationCenter;
}
