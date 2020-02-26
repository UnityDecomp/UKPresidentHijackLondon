using System;
using UnityEngine;

// Token: 0x02000030 RID: 48
[Serializable]
public class CharacterMotorMovingPlatform
{
	// Token: 0x06000079 RID: 121 RVA: 0x00006CF4 File Offset: 0x00004EF4
	public CharacterMotorMovingPlatform()
	{
		this.enabled = true;
		this.movementTransfer = MovementTransferOnJump.PermaTransfer;
	}

	// Token: 0x04000114 RID: 276
	public bool enabled;

	// Token: 0x04000115 RID: 277
	public MovementTransferOnJump movementTransfer;

	// Token: 0x04000116 RID: 278
	[NonSerialized]
	public Transform hitPlatform;

	// Token: 0x04000117 RID: 279
	[NonSerialized]
	public Transform activePlatform;

	// Token: 0x04000118 RID: 280
	[NonSerialized]
	public Vector3 activeLocalPoint;

	// Token: 0x04000119 RID: 281
	[NonSerialized]
	public Vector3 activeGlobalPoint;

	// Token: 0x0400011A RID: 282
	[NonSerialized]
	public Quaternion activeLocalRotation;

	// Token: 0x0400011B RID: 283
	[NonSerialized]
	public Quaternion activeGlobalRotation;

	// Token: 0x0400011C RID: 284
	[NonSerialized]
	public Matrix4x4 lastMatrix;

	// Token: 0x0400011D RID: 285
	[NonSerialized]
	public Vector3 platformVelocity;

	// Token: 0x0400011E RID: 286
	[NonSerialized]
	public bool newPlatform;
}
