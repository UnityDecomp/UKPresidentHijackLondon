using System;
using UnityEngine;

// Token: 0x0200004D RID: 77
public class BulletChildGetDamageC : MonoBehaviour
{
	// Token: 0x0600033D RID: 829 RVA: 0x0000F707 File Offset: 0x0000DB07
	private void Start()
	{
		base.GetComponent<BulletStatusC>().totalDamage = this.master.GetComponent<BulletStatusC>().totalDamage;
		base.GetComponent<BulletStatusC>().shooterTag = this.master.GetComponent<BulletStatusC>().shooterTag;
	}

	// Token: 0x0400020C RID: 524
	public GameObject master;
}
