using System;
using UnityEngine;

// Token: 0x020001F3 RID: 499
public class MinimapMark : MonoBehaviour
{
	// Token: 0x06000CD2 RID: 3282 RVA: 0x00050D60 File Offset: 0x0004F160
	private void Start()
	{
		if (!this.target)
		{
			this.target = null;
			MonoBehaviour.print("Please give a target to minimap mark script");
		}
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x00050D84 File Offset: 0x0004F184
	private void Update()
	{
		if (this.target)
		{
			base.transform.position = new Vector3(this.target.transform.position.x, base.transform.position.y, this.target.transform.position.z);
		}
	}

	// Token: 0x04000D50 RID: 3408
	public GameObject target;
}
