using System;
using UnityEngine;

// Token: 0x020001D6 RID: 470
public class arrow : MonoBehaviour
{
	// Token: 0x06000C34 RID: 3124 RVA: 0x0004D5C4 File Offset: 0x0004B9C4
	private void Start()
	{
		this.target = this.destination.transform;
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x0004D5D7 File Offset: 0x0004B9D7
	private void Update()
	{
		base.transform.LookAt(this.target.position);
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x0004D5EF File Offset: 0x0004B9EF
	public void setTarget(Transform tgt)
	{
		this.target = tgt;
	}

	// Token: 0x04000CA9 RID: 3241
	public GameObject destination;

	// Token: 0x04000CAA RID: 3242
	public Transform target;
}
