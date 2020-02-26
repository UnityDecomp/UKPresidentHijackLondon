using System;
using UnityEngine;

// Token: 0x0200002D RID: 45
[Serializable]
public class CharacterMotorMovement
{
	// Token: 0x06000077 RID: 119 RVA: 0x00006BC8 File Offset: 0x00004DC8
	public CharacterMotorMovement()
	{
		this.maxForwardSpeed = 10f;
		this.maxSidewaysSpeed = 10f;
		this.maxBackwardsSpeed = 10f;
		this.slopeSpeedMultiplier = new AnimationCurve(new Keyframe[]
		{
			new Keyframe((float)-90, (float)1),
			new Keyframe((float)0, (float)1),
			new Keyframe((float)90, (float)0)
		});
		this.maxGroundAcceleration = 30f;
		this.maxAirAcceleration = 20f;
		this.gravity = 10f;
		this.maxFallSpeed = 20f;
		this.frameVelocity = Vector3.zero;
		this.hitPoint = Vector3.zero;
		this.lastHitPoint = new Vector3(float.PositiveInfinity, (float)0, (float)0);
	}

	// Token: 0x040000F8 RID: 248
	public float maxForwardSpeed;

	// Token: 0x040000F9 RID: 249
	public float maxSidewaysSpeed;

	// Token: 0x040000FA RID: 250
	public float maxBackwardsSpeed;

	// Token: 0x040000FB RID: 251
	public AnimationCurve slopeSpeedMultiplier;

	// Token: 0x040000FC RID: 252
	public float maxGroundAcceleration;

	// Token: 0x040000FD RID: 253
	public float maxAirAcceleration;

	// Token: 0x040000FE RID: 254
	public float gravity;

	// Token: 0x040000FF RID: 255
	public float maxFallSpeed;

	// Token: 0x04000100 RID: 256
	[NonSerialized]
	public CollisionFlags collisionFlags;

	// Token: 0x04000101 RID: 257
	[NonSerialized]
	public Vector3 velocity;

	// Token: 0x04000102 RID: 258
	[NonSerialized]
	public Vector3 frameVelocity;

	// Token: 0x04000103 RID: 259
	[NonSerialized]
	public Vector3 hitPoint;

	// Token: 0x04000104 RID: 260
	[NonSerialized]
	public Vector3 lastHitPoint;
}
