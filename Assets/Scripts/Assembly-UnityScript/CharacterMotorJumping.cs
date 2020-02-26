using System;
using UnityEngine;

// Token: 0x0200002F RID: 47
[Serializable]
public class CharacterMotorJumping
{
	// Token: 0x06000078 RID: 120 RVA: 0x00006CA4 File Offset: 0x00004EA4
	public CharacterMotorJumping()
	{
		this.enabled = true;
		this.baseHeight = 1f;
		this.extraHeight = 4.1f;
		this.steepPerpAmount = 0.5f;
		this.lastButtonDownTime = (float)-100;
		this.jumpDir = Vector3.up;
	}

	// Token: 0x0400010A RID: 266
	public bool enabled;

	// Token: 0x0400010B RID: 267
	public float baseHeight;

	// Token: 0x0400010C RID: 268
	public float extraHeight;

	// Token: 0x0400010D RID: 269
	public float perpAmount;

	// Token: 0x0400010E RID: 270
	public float steepPerpAmount;

	// Token: 0x0400010F RID: 271
	[NonSerialized]
	public bool jumping;

	// Token: 0x04000110 RID: 272
	[NonSerialized]
	public bool holdingJumpButton;

	// Token: 0x04000111 RID: 273
	[NonSerialized]
	public float lastStartTime;

	// Token: 0x04000112 RID: 274
	[NonSerialized]
	public float lastButtonDownTime;

	// Token: 0x04000113 RID: 275
	[NonSerialized]
	public Vector3 jumpDir;
}
