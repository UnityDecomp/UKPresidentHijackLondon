using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x0200007C RID: 124
[Serializable]
public class RespawnMonster : MonoBehaviour
{
	// Token: 0x060001A6 RID: 422 RVA: 0x00013464 File Offset: 0x00011664
	public RespawnMonster()
	{
		this.pointName = "SpawnPoint";
		this.delay = 3f;
		this.randomPoint = 10f;
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00013490 File Offset: 0x00011690
	public virtual IEnumerator Start()
	{
		return new RespawnMonster.$Start$209(this).GetEnumerator();
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x000134A0 File Offset: 0x000116A0
	public virtual void Main()
	{
	}

	// Token: 0x040002C8 RID: 712
	public Transform enemy;

	// Token: 0x040002C9 RID: 713
	public string pointName;

	// Token: 0x040002CA RID: 714
	public float delay;

	// Token: 0x040002CB RID: 715
	public float randomPoint;

	// Token: 0x0200007D RID: 125
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Start$209 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x000134A4 File Offset: 0x000116A4
		public $Start$209(RespawnMonster self_)
		{
			this.$self_$215 = self_;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000134B4 File Offset: 0x000116B4
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new RespawnMonster.$Start$209.$(this.$self_$215);
		}

		// Token: 0x040002CC RID: 716
		internal RespawnMonster $self_$215;
	}
}
