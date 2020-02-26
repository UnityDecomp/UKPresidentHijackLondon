using System;
using UnityEngine;

// Token: 0x02000068 RID: 104
public class GainEXPC : MonoBehaviour
{
	// Token: 0x06000394 RID: 916 RVA: 0x00013457 File Offset: 0x00011857
	private void Start()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		this.player.GetComponent<StatusC>().gainEXP(this.expGain);
	}

	// Token: 0x040002B8 RID: 696
	public int expGain = 20;

	// Token: 0x040002B9 RID: 697
	private GameObject player;
}
