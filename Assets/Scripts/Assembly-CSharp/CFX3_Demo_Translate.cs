using System;
using UnityEngine;

// Token: 0x02000114 RID: 276
public class CFX3_Demo_Translate : MonoBehaviour
{
	// Token: 0x06000771 RID: 1905 RVA: 0x000320D8 File Offset: 0x000304D8
	private void Start()
	{
		this.dir = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f));
		this.dir.Scale(this.rotation);
		base.transform.localEulerAngles = this.dir;
	}

	// Token: 0x06000772 RID: 1906 RVA: 0x0003213F File Offset: 0x0003053F
	private void Update()
	{
		base.transform.Translate(this.axis * this.speed * Time.deltaTime, Space.Self);
	}

	// Token: 0x04000687 RID: 1671
	public float speed = 30f;

	// Token: 0x04000688 RID: 1672
	public Vector3 rotation = Vector3.forward;

	// Token: 0x04000689 RID: 1673
	public Vector3 axis = Vector3.forward;

	// Token: 0x0400068A RID: 1674
	public bool gravity;

	// Token: 0x0400068B RID: 1675
	private Vector3 dir;
}
