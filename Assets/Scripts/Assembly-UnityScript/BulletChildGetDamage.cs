using System;
using UnityEngine;

// Token: 0x02000026 RID: 38
[Serializable]
public class BulletChildGetDamage : MonoBehaviour
{
	// Token: 0x06000067 RID: 103 RVA: 0x00006518 File Offset: 0x00004718
	public virtual void Start()
	{
		((BulletStatus)this.GetComponent(typeof(BulletStatus))).totalDamage = ((BulletStatus)this.master.GetComponent(typeof(BulletStatus))).totalDamage;
		((BulletStatus)this.GetComponent(typeof(BulletStatus))).shooterTag = ((BulletStatus)this.master.GetComponent(typeof(BulletStatus))).shooterTag;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00006598 File Offset: 0x00004798
	public virtual void Main()
	{
	}

	// Token: 0x040000D5 RID: 213
	public GameObject master;
}
