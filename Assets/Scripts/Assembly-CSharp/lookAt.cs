using System;
using UnityEngine;

// Token: 0x0200009B RID: 155
public class lookAt : MonoBehaviour
{
	// Token: 0x06000494 RID: 1172 RVA: 0x00023E5D File Offset: 0x0002225D
	private void Start()
	{
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x00023E5F File Offset: 0x0002225F
	private void Update()
	{
		base.transform.LookAt(this.enemy);
	}

	// Token: 0x040004A1 RID: 1185
	public Transform enemy;
}
