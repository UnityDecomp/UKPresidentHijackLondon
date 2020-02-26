using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000054 RID: 84
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Character/Character Motor")]
public class CharacterMotorC : MonoBehaviour
{
	// Token: 0x06000349 RID: 841 RVA: 0x0000FD35 File Offset: 0x0000E135
	private void Awake()
	{
		this.controller = base.GetComponent<CharacterController>();
		this.tr = base.transform;
	}

	// Token: 0x0600034A RID: 842 RVA: 0x0000FD50 File Offset: 0x0000E150
	private void UpdateFunction()
	{
		Vector3 vector = this.movement.velocity;
		vector = this.ApplyInputVelocityChange(vector);
		vector = this.ApplyGravityAndJumping(vector);
		Vector3 vector2 = Vector3.zero;
		if (this.MoveWithPlatform())
		{
			Vector3 a = this.movingPlatform.activePlatform.TransformPoint(this.movingPlatform.activeLocalPoint);
			vector2 = a - this.movingPlatform.activeGlobalPoint;
			if (vector2 != Vector3.zero)
			{
				this.controller.Move(vector2);
			}
			Quaternion lhs = this.movingPlatform.activePlatform.rotation * this.movingPlatform.activeLocalRotation;
			float y = (lhs * Quaternion.Inverse(this.movingPlatform.activeGlobalRotation)).eulerAngles.y;
			if (y != 0f)
			{
				this.tr.Rotate(0f, y, 0f);
			}
		}
		Vector3 position = this.tr.position;
		Vector3 vector3 = vector * Time.deltaTime;
		float stepOffset = this.controller.stepOffset;
		Vector3 vector4 = new Vector3(vector3.x, 0f, vector3.z);
		float d = Mathf.Max(stepOffset, vector4.magnitude);
		if (this.grounded)
		{
			vector3 -= d * Vector3.up;
		}
		this.movingPlatform.hitPlatform = null;
		this.groundNormal = Vector3.zero;
		this.movement.collisionFlags = this.controller.Move(vector3);
		this.movement.lastHitPoint = this.movement.hitPoint;
		this.lastGroundNormal = this.groundNormal;
		if (this.movingPlatform.enabled && this.movingPlatform.activePlatform != this.movingPlatform.hitPlatform && this.movingPlatform.hitPlatform != null)
		{
			this.movingPlatform.activePlatform = this.movingPlatform.hitPlatform;
			this.movingPlatform.lastMatrix = this.movingPlatform.hitPlatform.localToWorldMatrix;
			this.movingPlatform.newPlatform = true;
		}
		Vector3 vector5 = new Vector3(vector.x, 0f, vector.z);
		this.movement.velocity = (this.tr.position - position) / Time.deltaTime;
		Vector3 lhs2 = new Vector3(this.movement.velocity.x, 0f, this.movement.velocity.z);
		if (vector5 == Vector3.zero)
		{
			this.movement.velocity = new Vector3(0f, this.movement.velocity.y, 0f);
		}
		else
		{
			float value = Vector3.Dot(lhs2, vector5) / vector5.sqrMagnitude;
			this.movement.velocity = vector5 * Mathf.Clamp01(value) + this.movement.velocity.y * Vector3.up;
		}
		if ((double)this.movement.velocity.y < (double)vector.y - 0.001)
		{
			if (this.movement.velocity.y < 0f)
			{
				this.movement.velocity.y = vector.y;
			}
			else
			{
				this.jumping.holdingJumpButton = false;
			}
		}
		if (this.grounded && !this.IsGroundedTest())
		{
			this.grounded = false;
			if (this.movingPlatform.enabled && (this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.InitTransfer || this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.PermaTransfer))
			{
				this.movement.frameVelocity = this.movingPlatform.platformVelocity;
				this.movement.velocity += this.movingPlatform.platformVelocity;
			}
			base.SendMessage("OnFall", SendMessageOptions.DontRequireReceiver);
		}
		else if (!this.grounded && this.IsGroundedTest())
		{
			this.grounded = true;
			this.jumping.jumping = false;
			this.SubtractNewPlatformVelocity();
			base.SendMessage("OnLand", SendMessageOptions.DontRequireReceiver);
		}
		if (this.MoveWithPlatform())
		{
			this.movingPlatform.activeGlobalPoint = this.tr.position + Vector3.up * (this.controller.center.y - this.controller.height * 0.5f + this.controller.radius);
			this.movingPlatform.activeLocalPoint = this.movingPlatform.activePlatform.InverseTransformPoint(this.movingPlatform.activeGlobalPoint);
			this.movingPlatform.activeGlobalRotation = this.tr.rotation;
			this.movingPlatform.activeLocalRotation = Quaternion.Inverse(this.movingPlatform.activePlatform.rotation) * this.movingPlatform.activeGlobalRotation;
		}
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00010288 File Offset: 0x0000E688
	private void FixedUpdate()
	{
		if (this.movingPlatform.enabled)
		{
			if (this.movingPlatform.activePlatform != null)
			{
				if (!this.movingPlatform.newPlatform)
				{
					this.movingPlatform.platformVelocity = (this.movingPlatform.activePlatform.localToWorldMatrix.MultiplyPoint3x4(this.movingPlatform.activeLocalPoint) - this.movingPlatform.lastMatrix.MultiplyPoint3x4(this.movingPlatform.activeLocalPoint)) / Time.deltaTime;
				}
				this.movingPlatform.lastMatrix = this.movingPlatform.activePlatform.localToWorldMatrix;
				this.movingPlatform.newPlatform = false;
			}
			else
			{
				this.movingPlatform.platformVelocity = Vector3.zero;
			}
		}
		if (this.useFixedUpdate)
		{
			this.UpdateFunction();
		}
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00010370 File Offset: 0x0000E770
	private void Update()
	{
		if (!this.useFixedUpdate)
		{
			this.UpdateFunction();
		}
	}

	// Token: 0x0600034D RID: 845 RVA: 0x00010384 File Offset: 0x0000E784
	private Vector3 ApplyInputVelocityChange(Vector3 velocity)
	{
		if (!this.canControl)
		{
			this.inputMoveDirection = Vector3.zero;
		}
		Vector3 vector2;
		if (this.grounded && this.TooSteep())
		{
			Vector3 vector = new Vector3(this.groundNormal.x, 0f, this.groundNormal.z);
			vector2 = vector.normalized;
			Vector3 vector3 = Vector3.Project(this.inputMoveDirection, vector2);
			vector2 = vector2 + vector3 * this.sliding.speedControl + (this.inputMoveDirection - vector3) * this.sliding.sidewaysControl;
			vector2 *= this.sliding.slidingSpeed;
		}
		else
		{
			vector2 = this.GetDesiredHorizontalVelocity();
		}
		if (this.movingPlatform.enabled && this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.PermaTransfer)
		{
			vector2 += this.movement.frameVelocity;
			vector2.y = 0f;
		}
		if (this.grounded)
		{
			vector2 = this.AdjustGroundVelocityToNormal(vector2, this.groundNormal);
		}
		else
		{
			velocity.y = 0f;
		}
		float num = this.GetMaxAcceleration(this.grounded) * Time.deltaTime;
		Vector3 b = vector2 - velocity;
		if (b.sqrMagnitude > num * num)
		{
			b = b.normalized * num;
		}
		if (this.grounded || this.canControl)
		{
			velocity += b;
		}
		if (this.grounded)
		{
			velocity.y = Mathf.Min(velocity.y, 0f);
		}
		return velocity;
	}

	// Token: 0x0600034E RID: 846 RVA: 0x00010534 File Offset: 0x0000E934
	private Vector3 ApplyGravityAndJumping(Vector3 velocity)
	{
		if (!this.inputJump || !this.canControl)
		{
			this.jumping.holdingJumpButton = false;
			this.jumping.lastButtonDownTime = -100f;
		}
		if (this.inputJump && this.jumping.lastButtonDownTime < 0f && this.canControl)
		{
			this.jumping.lastButtonDownTime = Time.time;
		}
		if (this.grounded)
		{
			velocity.y = Mathf.Min(0f, velocity.y) - this.movement.gravity * Time.deltaTime;
		}
		else
		{
			velocity.y = this.movement.velocity.y - this.movement.gravity * Time.deltaTime;
			if (this.jumping.jumping && this.jumping.holdingJumpButton && Time.time < this.jumping.lastStartTime + this.jumping.extraHeight / this.CalculateJumpVerticalSpeed(this.jumping.baseHeight))
			{
				velocity += this.jumping.jumpDir * this.movement.gravity * Time.deltaTime;
			}
			velocity.y = Mathf.Max(velocity.y, -this.movement.maxFallSpeed);
		}
		if (this.grounded)
		{
			if (this.jumping.enabled && this.canControl && (double)(Time.time - this.jumping.lastButtonDownTime) < 0.2)
			{
				this.grounded = false;
				this.jumping.jumping = true;
				this.jumping.lastStartTime = Time.time;
				this.jumping.lastButtonDownTime = -100f;
				this.jumping.holdingJumpButton = true;
				if (this.TooSteep())
				{
					this.jumping.jumpDir = Vector3.Slerp(Vector3.up, this.groundNormal, this.jumping.steepPerpAmount);
				}
				else
				{
					this.jumping.jumpDir = Vector3.Slerp(Vector3.up, this.groundNormal, this.jumping.perpAmount);
				}
				velocity.y = 0f;
				velocity += this.jumping.jumpDir * this.CalculateJumpVerticalSpeed(this.jumping.baseHeight);
				if (this.movingPlatform.enabled && (this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.InitTransfer || this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.PermaTransfer))
				{
					this.movement.frameVelocity = this.movingPlatform.platformVelocity;
					velocity += this.movingPlatform.platformVelocity;
				}
				base.SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				this.jumping.holdingJumpButton = false;
			}
		}
		return velocity;
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00010840 File Offset: 0x0000EC40
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.normal.y > 0f && hit.normal.y > this.groundNormal.y && hit.moveDirection.y < 0f)
		{
			if ((double)(hit.point - this.movement.lastHitPoint).sqrMagnitude > 0.001 || this.lastGroundNormal == Vector3.zero)
			{
				this.groundNormal = hit.normal;
			}
			else
			{
				this.groundNormal = this.lastGroundNormal;
			}
			this.movingPlatform.hitPlatform = hit.collider.transform;
			this.movement.hitPoint = hit.point;
			this.movement.frameVelocity = Vector3.zero;
		}
	}

	// Token: 0x06000350 RID: 848 RVA: 0x00010934 File Offset: 0x0000ED34
	private IEnumerator SubtractNewPlatformVelocity()
	{
		if (this.movingPlatform.enabled && (this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.InitTransfer || this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.PermaTransfer))
		{
			if (this.movingPlatform.newPlatform)
			{
				Transform platform = this.movingPlatform.activePlatform;
				yield return new WaitForFixedUpdate();
				yield return new WaitForFixedUpdate();
				if (this.grounded && platform == this.movingPlatform.activePlatform)
				{
					yield break;
				}
			}
			this.movement.velocity -= this.movingPlatform.platformVelocity;
		}
		yield break;
	}

	// Token: 0x06000351 RID: 849 RVA: 0x00010950 File Offset: 0x0000ED50
	private bool MoveWithPlatform()
	{
		return this.movingPlatform.enabled && (this.grounded || this.movingPlatform.movementTransfer == CharacterMotorC.MovementTransferOnJump.PermaLocked) && this.movingPlatform.activePlatform != null;
	}

	// Token: 0x06000352 RID: 850 RVA: 0x000109A0 File Offset: 0x0000EDA0
	private Vector3 GetDesiredHorizontalVelocity()
	{
		Vector3 vector = this.tr.InverseTransformDirection(this.inputMoveDirection);
		float d = this.MaxSpeedInDirection(vector);
		if (this.grounded)
		{
			float num = Mathf.Asin(this.movement.velocity.normalized.y) * 57.29578f;
		}
		return this.tr.TransformDirection(vector * d);
	}

	// Token: 0x06000353 RID: 851 RVA: 0x00010A08 File Offset: 0x0000EE08
	private Vector3 AdjustGroundVelocityToNormal(Vector3 hVelocity, Vector3 groundNormal)
	{
		Vector3 lhs = Vector3.Cross(Vector3.up, hVelocity);
		return Vector3.Cross(lhs, groundNormal).normalized * hVelocity.magnitude;
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00010A3C File Offset: 0x0000EE3C
	private bool IsGroundedTest()
	{
		return (double)this.groundNormal.y > 0.01;
	}

	// Token: 0x06000355 RID: 853 RVA: 0x00010A55 File Offset: 0x0000EE55
	private float GetMaxAcceleration(bool grounded)
	{
		if (grounded)
		{
			return this.movement.maxGroundAcceleration;
		}
		return this.movement.maxAirAcceleration;
	}

	// Token: 0x06000356 RID: 854 RVA: 0x00010A74 File Offset: 0x0000EE74
	private float CalculateJumpVerticalSpeed(float targetJumpHeight)
	{
		return Mathf.Sqrt(2f * targetJumpHeight * this.movement.gravity);
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00010A8E File Offset: 0x0000EE8E
	private bool IsJumping()
	{
		return this.jumping.jumping;
	}

	// Token: 0x06000358 RID: 856 RVA: 0x00010A9B File Offset: 0x0000EE9B
	private bool IsSliding()
	{
		return this.grounded && this.sliding.enabled && this.TooSteep();
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00010AC1 File Offset: 0x0000EEC1
	private bool IsTouchingCeiling()
	{
		return (this.movement.collisionFlags & CollisionFlags.Above) != CollisionFlags.None;
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00010AD6 File Offset: 0x0000EED6
	private bool IsGrounded()
	{
		return this.grounded;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00010ADE File Offset: 0x0000EEDE
	private bool TooSteep()
	{
		return this.groundNormal.y <= Mathf.Cos(this.controller.slopeLimit * 0.0174532924f);
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00010B06 File Offset: 0x0000EF06
	private Vector3 GetDirection()
	{
		return this.inputMoveDirection;
	}

	// Token: 0x0600035D RID: 861 RVA: 0x00010B0E File Offset: 0x0000EF0E
	private void SetControllable(bool controllable)
	{
		this.canControl = controllable;
	}

	// Token: 0x0600035E RID: 862 RVA: 0x00010B18 File Offset: 0x0000EF18
	private float MaxSpeedInDirection(Vector3 desiredMovementDirection)
	{
		if (desiredMovementDirection == Vector3.zero)
		{
			return 0f;
		}
		float num = ((desiredMovementDirection.z <= 0f) ? this.movement.maxBackwardsSpeed : this.movement.maxForwardSpeed) / this.movement.maxSidewaysSpeed;
		Vector3 vector = new Vector3(desiredMovementDirection.x, 0f, desiredMovementDirection.z / num);
		Vector3 normalized = vector.normalized;
		Vector3 vector2 = new Vector3(normalized.x, 0f, normalized.z * num);
		return vector2.magnitude * this.movement.maxSidewaysSpeed;
	}

	// Token: 0x0600035F RID: 863 RVA: 0x00010BC9 File Offset: 0x0000EFC9
	private void SetVelocity(Vector3 velocity)
	{
		this.grounded = false;
		this.movement.velocity = velocity;
		this.movement.frameVelocity = Vector3.zero;
		base.SendMessage("OnExternalVelocity");
	}

	// Token: 0x04000231 RID: 561
	public bool canControl = true;

	// Token: 0x04000232 RID: 562
	public bool useFixedUpdate = true;

	// Token: 0x04000233 RID: 563
	[NonSerialized]
	public Vector3 inputMoveDirection = Vector3.zero;

	// Token: 0x04000234 RID: 564
	[NonSerialized]
	public bool inputJump;

	// Token: 0x04000235 RID: 565
	public CharacterMotorC.CharacterMotorMovement movement = new CharacterMotorC.CharacterMotorMovement();

	// Token: 0x04000236 RID: 566
	public CharacterMotorC.CharacterMotorJumping jumping = new CharacterMotorC.CharacterMotorJumping();

	// Token: 0x04000237 RID: 567
	public CharacterMotorC.CharacterMotorMovingPlatform movingPlatform = new CharacterMotorC.CharacterMotorMovingPlatform();

	// Token: 0x04000238 RID: 568
	public CharacterMotorC.CharacterMotorSliding sliding = new CharacterMotorC.CharacterMotorSliding();

	// Token: 0x04000239 RID: 569
	[NonSerialized]
	public bool grounded = true;

	// Token: 0x0400023A RID: 570
	[NonSerialized]
	public Vector3 groundNormal = Vector3.zero;

	// Token: 0x0400023B RID: 571
	private Vector3 lastGroundNormal = Vector3.zero;

	// Token: 0x0400023C RID: 572
	private Transform tr;

	// Token: 0x0400023D RID: 573
	private CharacterController controller;

	// Token: 0x02000055 RID: 85
	[Serializable]
	public class CharacterMotorMovement
	{
		// Token: 0x0400023E RID: 574
		public float maxForwardSpeed = 6f;

		// Token: 0x0400023F RID: 575
		public float maxSidewaysSpeed = 6f;

		// Token: 0x04000240 RID: 576
		public float maxBackwardsSpeed = 6f;

		// Token: 0x04000241 RID: 577
		public AnimationCurve slopeSpeedMultiplier = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(-90f, 1f),
			new Keyframe(0f, 1f),
			new Keyframe(90f, 0f)
		});

		// Token: 0x04000242 RID: 578
		public float maxGroundAcceleration = 30f;

		// Token: 0x04000243 RID: 579
		public float maxAirAcceleration = 20f;

		// Token: 0x04000244 RID: 580
		public float gravity = 10f;

		// Token: 0x04000245 RID: 581
		public float maxFallSpeed = 20f;

		// Token: 0x04000246 RID: 582
		[NonSerialized]
		public CollisionFlags collisionFlags;

		// Token: 0x04000247 RID: 583
		[NonSerialized]
		public Vector3 velocity;

		// Token: 0x04000248 RID: 584
		[NonSerialized]
		public Vector3 frameVelocity = Vector3.zero;

		// Token: 0x04000249 RID: 585
		[NonSerialized]
		public Vector3 hitPoint = Vector3.zero;

		// Token: 0x0400024A RID: 586
		[NonSerialized]
		public Vector3 lastHitPoint = new Vector3(float.PositiveInfinity, 0f, 0f);
	}

	// Token: 0x02000056 RID: 86
	public enum MovementTransferOnJump
	{
		// Token: 0x0400024C RID: 588
		None,
		// Token: 0x0400024D RID: 589
		InitTransfer,
		// Token: 0x0400024E RID: 590
		PermaTransfer,
		// Token: 0x0400024F RID: 591
		PermaLocked
	}

	// Token: 0x02000057 RID: 87
	[Serializable]
	public class CharacterMotorJumping
	{
		// Token: 0x04000250 RID: 592
		public bool enabled = true;

		// Token: 0x04000251 RID: 593
		public float baseHeight = 1f;

		// Token: 0x04000252 RID: 594
		public float extraHeight = 4.1f;

		// Token: 0x04000253 RID: 595
		public float perpAmount;

		// Token: 0x04000254 RID: 596
		public float steepPerpAmount = 0.5f;

		// Token: 0x04000255 RID: 597
		[NonSerialized]
		public bool jumping;

		// Token: 0x04000256 RID: 598
		[NonSerialized]
		public bool holdingJumpButton;

		// Token: 0x04000257 RID: 599
		[NonSerialized]
		public float lastStartTime;

		// Token: 0x04000258 RID: 600
		[NonSerialized]
		public float lastButtonDownTime = -100f;

		// Token: 0x04000259 RID: 601
		[NonSerialized]
		public Vector3 jumpDir = Vector3.up;
	}

	// Token: 0x02000058 RID: 88
	[Serializable]
	public class CharacterMotorMovingPlatform
	{
		// Token: 0x0400025A RID: 602
		public bool enabled = true;

		// Token: 0x0400025B RID: 603
		public CharacterMotorC.MovementTransferOnJump movementTransfer = CharacterMotorC.MovementTransferOnJump.PermaTransfer;

		// Token: 0x0400025C RID: 604
		[NonSerialized]
		public Transform hitPlatform;

		// Token: 0x0400025D RID: 605
		[NonSerialized]
		public Transform activePlatform;

		// Token: 0x0400025E RID: 606
		[NonSerialized]
		public Vector3 activeLocalPoint;

		// Token: 0x0400025F RID: 607
		[NonSerialized]
		public Vector3 activeGlobalPoint;

		// Token: 0x04000260 RID: 608
		[NonSerialized]
		public Quaternion activeLocalRotation;

		// Token: 0x04000261 RID: 609
		[NonSerialized]
		public Quaternion activeGlobalRotation;

		// Token: 0x04000262 RID: 610
		[NonSerialized]
		public Matrix4x4 lastMatrix;

		// Token: 0x04000263 RID: 611
		[NonSerialized]
		public Vector3 platformVelocity;

		// Token: 0x04000264 RID: 612
		[NonSerialized]
		public bool newPlatform;
	}

	// Token: 0x02000059 RID: 89
	[Serializable]
	public class CharacterMotorSliding
	{
		// Token: 0x04000265 RID: 613
		public bool enabled = true;

		// Token: 0x04000266 RID: 614
		public float slidingSpeed = 15f;

		// Token: 0x04000267 RID: 615
		public float sidewaysControl = 1f;

		// Token: 0x04000268 RID: 616
		public float speedControl = 0.4f;
	}
}
