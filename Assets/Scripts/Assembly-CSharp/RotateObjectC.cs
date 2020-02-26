using System;
using UnityEngine;

// Token: 0x02000089 RID: 137
public class RotateObjectC : MonoBehaviour
{
	// Token: 0x06000434 RID: 1076 RVA: 0x0001BE9A File Offset: 0x0001A29A
	private void Update()
	{
		base.transform.Rotate(this.rotateX * Time.deltaTime, this.rotateY * Time.deltaTime, this.rotateZ * Time.deltaTime);
	}

	// Token: 0x040003F4 RID: 1012
	public float rotateX;

	// Token: 0x040003F5 RID: 1013
	public float rotateY = 5f;

	// Token: 0x040003F6 RID: 1014
	public float rotateZ;
}
