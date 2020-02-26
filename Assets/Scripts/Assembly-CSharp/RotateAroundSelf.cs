using System;
using UnityEngine;

// Token: 0x0200014C RID: 332
public class RotateAroundSelf : MonoBehaviour
{
	// Token: 0x06000A2D RID: 2605 RVA: 0x0003DFC0 File Offset: 0x0003C3C0
	private void Update()
	{
		base.transform.Rotate(this.dir * this.speed * Time.deltaTime);
	}

	// Token: 0x0400094C RID: 2380
	public Vector3 dir;

	// Token: 0x0400094D RID: 2381
	public float speed;
}
