using System;
using UnityEngine;

// Token: 0x0200010F RID: 271
public class CFX_Demo_RandomDir : MonoBehaviour
{
	// Token: 0x06000757 RID: 1879 RVA: 0x00030F4C File Offset: 0x0002F34C
	private void Awake()
	{
		base.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(this.min.x, this.max.x), UnityEngine.Random.Range(this.min.y, this.max.y), UnityEngine.Random.Range(this.min.z, this.max.z));
	}

	// Token: 0x04000669 RID: 1641
	public Vector3 min = new Vector3(0f, 0f, 0f);

	// Token: 0x0400066A RID: 1642
	public Vector3 max = new Vector3(0f, 360f, 0f);
}
