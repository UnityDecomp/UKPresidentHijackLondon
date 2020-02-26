using System;
using UnityEngine;

// Token: 0x0200004C RID: 76
[Serializable]
public class GainEXP : MonoBehaviour
{
	// Token: 0x060000EA RID: 234 RVA: 0x0000AC5C File Offset: 0x00008E5C
	public GainEXP()
	{
		this.expGain = 20;
	}

	// Token: 0x060000EB RID: 235 RVA: 0x0000AC6C File Offset: 0x00008E6C
	public virtual void Start()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		((Status)this.player.GetComponent(typeof(Status))).gainEXP(this.expGain);
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000ACC0 File Offset: 0x00008EC0
	public virtual void Main()
	{
	}

	// Token: 0x0400019F RID: 415
	public int expGain;

	// Token: 0x040001A0 RID: 416
	public GameObject player;
}
