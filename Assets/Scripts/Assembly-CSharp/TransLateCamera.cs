using System;
using UnityEngine;

// Token: 0x02000156 RID: 342
public class TransLateCamera : MonoBehaviour
{
	// Token: 0x06000A5E RID: 2654 RVA: 0x0003EE74 File Offset: 0x0003D274
	private void Start()
	{
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x0003EE76 File Offset: 0x0003D276
	private void Update()
	{
		base.transform.Translate(Vector3.up * 2f * Time.deltaTime);
	}
}
