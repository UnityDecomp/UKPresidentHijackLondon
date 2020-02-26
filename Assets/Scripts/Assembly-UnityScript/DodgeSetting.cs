using System;
using UnityEngine;

// Token: 0x0200006A RID: 106
[Serializable]
public class DodgeSetting
{
	// Token: 0x06000157 RID: 343 RVA: 0x000109F4 File Offset: 0x0000EBF4
	public DodgeSetting()
	{
		this.staminaUse = 25;
	}

	// Token: 0x0400025C RID: 604
	public bool canDodgeRoll;

	// Token: 0x0400025D RID: 605
	public int staminaUse;

	// Token: 0x0400025E RID: 606
	public AnimationClip dodgeForward;

	// Token: 0x0400025F RID: 607
	public AnimationClip dodgeLeft;

	// Token: 0x04000260 RID: 608
	public AnimationClip dodgeRight;

	// Token: 0x04000261 RID: 609
	public AnimationClip dodgeBack;
}
