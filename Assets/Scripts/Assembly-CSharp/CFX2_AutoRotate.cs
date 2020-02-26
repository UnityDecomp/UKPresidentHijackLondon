using System;
using UnityEngine;

// Token: 0x02000119 RID: 281
public class CFX2_AutoRotate : MonoBehaviour
{
	// Token: 0x06000780 RID: 1920 RVA: 0x0003252A File Offset: 0x0003092A
	private void Update()
	{
		base.transform.Rotate(this.speed * Time.deltaTime);
	}

	// Token: 0x04000695 RID: 1685
	public Vector3 speed = new Vector3(0f, 40f, 0f);
}
