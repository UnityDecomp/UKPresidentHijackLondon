using System;
using UnityEngine;

// Token: 0x0200001C RID: 28
[Serializable]
public class AtkSound
{
	// Token: 0x0600004A RID: 74 RVA: 0x00004F60 File Offset: 0x00003160
	public AtkSound()
	{
		this.attackComboVoice = new AudioClip[3];
	}

	// Token: 0x0400009C RID: 156
	public AudioClip[] attackComboVoice;

	// Token: 0x0400009D RID: 157
	public AudioClip magicCastVoice;

	// Token: 0x0400009E RID: 158
	public AudioClip hurtVoice;
}
