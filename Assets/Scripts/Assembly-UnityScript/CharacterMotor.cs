using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x02000032 RID: 50
[AddComponentMenu("Character/Character Motor")]
[RequireComponent(typeof(CharacterController))]
[Serializable]
public class CharacterMotor : MonoBehaviour
{
	// Token: 0x0600007B RID: 123 RVA: 0x00006D48 File Offset: 0x00004F48
	public CharacterMotor()
	{
		this.canControl = true;
		this.useFixedUpdate = true;
		this.inputMoveDirection = Vector3.zero;
		this.movement = new CharacterMotorMovement();
		this.jumping = new CharacterMotorJumping();
		this.movingPlatform = new CharacterMotorMovingPlatform();
		this.sliding = new CharacterMotorSliding();
		this.grounded = true;
		this.groundNormal = Vector3.zero;
		this.lastGroundNormal = Vector3.zero;
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00006DC0 File Offset: 0x00004FC0
	public virtual void Awake()
	{
		this.controller = (CharacterController)this.GetComponent(typeof(CharacterController));
		this.tr = this.transform;
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00006DEC File Offset: 0x00004FEC
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
			if (y != (float)0)
			{
				this.tr.Rotate((float)0, y, (float)0);
			}
		}
		Vector3 position = this.tr.position;
		Vector3 vector3 = vector * Time.deltaTime;
		float d = Mathf.Max(this.controller.stepOffset, new Vector3(vector3.x, (float)0, vector3.z).magnitude);
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
		Vector3 vector4 = new Vector3(vector.x, (float)0, vector.z);
		this.movement.velocity = (this.tr.position - position) / Time.deltaTime;
		Vector3 lhs2 = new Vector3(this.movement.velocity.x, (float)0, this.movement.velocity.z);
		if (vector4 == Vector3.zero)
		{
			this.movement.velocity = new Vector3((float)0, this.movement.velocity.y, (float)0);
		}
		else
		{
			float value = Vector3.Dot(lhs2, vector4) / vector4.sqrMagnitude;
			this.movement.velocity = vector4 * Mathf.Clamp01(value) + this.movement.velocity.y * Vector3.up;
		}
		if (this.movement.velocity.y < vector.y - 0.001f)
		{
			if (this.movement.velocity.y < (float)0)
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
			if (this.movingPlatform.enabled && (this.movingPlatform.movementTransfer == MovementTransferOnJump.InitTransfer || this.movingPlatform.movementTransfer == MovementTransferOnJump.PermaTransfer))
			{
				this.movement.frameVelocity = this.movingPlatform.platformVelocity;
				this.movement.velocity = this.movement.velocity + this.movingPlatform.platformVelocity;
			}
			this.SendMessage("OnFall", SendMessageOptions.DontRequireReceiver);
			this.tr.position = this.tr.position + d * Vector3.up;
		}
		else if (!this.grounded && this.IsGroundedTest())
		{
			this.grounded = true;
			this.jumping.jumping = false;
			this.StartCoroutine(this.SubtractNewPlatformVelocity());
			this.SendMessage("OnLand", SendMessageOptions.DontRequireReceiver);
		}
		if (this.MoveWithPlatform())
		{
			this.movingPlatform.activeGlobalPoint = this.tr.position + Vector3.up * (this.controller.center.y - this.controller.height * 0.5f + this.controller.radius);
			this.movingPlatform.activeLocalPoint = this.movingPlatform.activePlatform.InverseTransformPoint(this.movingPlatform.activeGlobalPoint);
			this.movingPlatform.activeGlobalRotation = this.tr.rotation;
			this.movingPlatform.activeLocalRotation = Quaternion.Inverse(this.movingPlatform.activePlatform.rotation) * this.movingPlatform.activeGlobalRotation;
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00007334 File Offset: 0x00005534
	public virtual void FixedUpdate()
	{
		if (this.movingPlatform.enabled)
		{
			if (this.movingPlatform.activePlatform != null)
			{
				if (!this.movingPlatform.newPlatform)
				{
					Vector3 platformVelocity = this.movingPlatform.platformVelocity;
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

	// Token: 0x0600007F RID: 127 RVA: 0x00007428 File Offset: 0x00005628
	public virtual void Update()
	{
		if (!this.useFixedUpdate)
		{
			this.UpdateFunction();
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x0000743C File Offset: 0x0000563C
	private Vector3 ApplyInputVelocityChange(Vector3 velocity)
	{
		if (!this.canControl)
		{
			this.inputMoveDirection = Vector3.zero;
		}
		Vector3 vector = default(Vector3);
		if (this.grounded && this.TooSteep())
		{
			vector = new Vector3(this.groundNormal.x, (float)0, this.groundNormal.z).normalized;
			Vector3 vector2 = Vector3.Project(this.inputMoveDirection, vector);
			vector = vector + vector2 * this.sliding.speedControl + (this.inputMoveDirection - vector2) * this.sliding.sidewaysControl;
			vector *= this.sliding.slidingSpeed;
		}
		else
		{
			vector = this.GetDesiredHorizontalVelocity();
		}
		if (this.movingPlatform.enabled && this.movingPlatform.movementTransfer == MovementTransferOnJump.PermaTransfer)
		{
			vector += this.movement.frameVelocity;
			vector.y = (float)0;
		}
		if (this.grounded)
		{
			vector = this.AdjustGroundVelocityToNormal(vector, this.groundNormal);
		}
		else
		{
			velocity.y = (float)0;
		}
		float num = this.GetMaxAcceleration(this.grounded) * Time.deltaTime;
		Vector3 b = vector - velocity;
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
			velocity.y = Mathf.Min(velocity.y, (float)0);
		}
		return velocity;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x000075F4 File Offset: 0x000057F4
	private Vector3 ApplyGravityAndJumping(Vector3 velocity)
	{
		if (!this.inputJump || !this.canControl)
		{
			this.jumping.holdingJumpButton = false;
			this.jumping.lastButtonDownTime = (float)-100;
		}
		if (this.inputJump && this.jumping.lastButtonDownTime < (float)0 && this.canControl)
		{
			this.jumping.lastButtonDownTime = Time.time;
		}
		if (this.grounded)
		{
			velocity.y = Mathf.Min((float)0, velocity.y) - this.movement.gravity * Time.deltaTime;
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
			if (this.jumping.enabled && this.canControl && Time.time - this.jumping.lastButtonDownTime < 0.2f)
			{
				this.grounded = false;
				this.jumping.jumping = true;
				this.jumping.lastStartTime = Time.time;
				this.jumping.lastButtonDownTime = (float)-100;
				this.jumping.holdingJumpButton = true;
				if (this.TooSteep())
				{
					this.jumping.jumpDir = Vector3.Slerp(Vector3.up, this.groundNormal, this.jumping.steepPerpAmount);
				}
				else
				{
					this.jumping.jumpDir = Vector3.Slerp(Vector3.up, this.groundNormal, this.jumping.perpAmount);
				}
				velocity.y = (float)0;
				velocity += this.jumping.jumpDir * this.CalculateJumpVerticalSpeed(this.jumping.baseHeight);
				if (this.movingPlatform.enabled && (this.movingPlatform.movementTransfer == MovementTransferOnJump.InitTransfer || this.movingPlatform.movementTransfer == MovementTransferOnJump.PermaTransfer))
				{
					this.movement.frameVelocity = this.movingPlatform.platformVelocity;
					velocity += this.movingPlatform.platformVelocity;
				}
				this.SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				this.jumping.holdingJumpButton = false;
			}
		}
		return velocity;
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00007914 File Offset: 0x00005B14
	public virtual void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.normal.y > (float)0 && hit.normal.y > this.groundNormal.y && hit.moveDirection.y < (float)0)
		{
			if ((hit.point - this.movement.lastHitPoint).sqrMagnitude > 0.001f || this.lastGroundNormal == Vector3.zero)
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

	// Token: 0x06000083 RID: 131 RVA: 0x000079FC File Offset: 0x00005BFC
	private IEnumerator SubtractNewPlatformVelocity()
	{
		return new CharacterMotor.$SubtractNewPlatformVelocity$168(this).GetEnumerator();
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00007A0C File Offset: 0x00005C0C
	private bool MoveWithPlatform()
	{
		bool flag;
		if (flag = this.movingPlatform.enabled)
		{
			flag = (this.grounded ?? (this.movingPlatform.movementTransfer == MovementTransferOnJump.PermaLocked));
		}
		bool result;
		if (result = flag)
		{
			result = (this.movingPlatform.activePlatform != null);
		}
		return result;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00007A60 File Offset: 0x00005C60
	private Vector3 GetDesiredHorizontalVelocity()
	{
		Vector3 vector = this.tr.InverseTransformDirection(this.inputMoveDirection);
		float num = this.MaxSpeedInDirection(vector);
		if (this.grounded)
		{
			float time = Mathf.Asin(this.movement.velocity.normalized.y) * 57.29578f;
			num *= this.movement.slopeSpeedMultiplier.Evaluate(time);
		}
		return this.tr.TransformDirection(vector * num);
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00007ADC File Offset: 0x00005CDC
	private Vector3 AdjustGroundVelocityToNormal(Vector3 hVelocity, Vector3 groundNormal)
	{
		Vector3 lhs = Vector3.Cross(Vector3.up, hVelocity);
		return Vector3.Cross(lhs, groundNormal).normalized * hVelocity.magnitude;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00007B14 File Offset: 0x00005D14
	private bool IsGroundedTest()
	{
		return this.groundNormal.y > 0.01f;
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00007B28 File Offset: 0x00005D28
	public virtual float GetMaxAcceleration(bool grounded)
	{
		return (!grounded) ? this.movement.maxAirAcceleration : this.movement.maxGroundAcceleration;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00007B5C File Offset: 0x00005D5C
	public virtual float CalculateJumpVerticalSpeed(float targetJumpHeight)
	{
		return Mathf.Sqrt((float)2 * targetJumpHeight * this.movement.gravity);
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00007B74 File Offset: 0x00005D74
	public virtual bool IsJumping()
	{
		return this.jumping.jumping;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00007B84 File Offset: 0x00005D84
	public virtual bool IsSliding()
	{
		bool enabled;
		if (enabled = this.grounded)
		{
			enabled = this.sliding.enabled;
		}
		bool result;
		if (result = enabled)
		{
			result = this.TooSteep();
		}
		return result;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00007BAC File Offset: 0x00005DAC
	public virtual bool IsTouchingCeiling()
	{
		return (this.movement.collisionFlags & CollisionFlags.Above) != CollisionFlags.None;
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00007BC4 File Offset: 0x00005DC4
	public virtual bool IsGrounded()
	{
		return this.grounded;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00007BCC File Offset: 0x00005DCC
	public virtual bool TooSteep()
	{
		return this.groundNormal.y <= Mathf.Cos(this.controller.slopeLimit * 0.0174532924f);
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00007C00 File Offset: 0x00005E00
	public virtual Vector3 GetDirection()
	{
		return this.inputMoveDirection;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00007C08 File Offset: 0x00005E08
	public virtual void SetControllable(bool controllable)
	{
		this.canControl = controllable;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00007C14 File Offset: 0x00005E14
	public virtual float MaxSpeedInDirection(Vector3 desiredMovementDirection)
	{
		float result;
		if (desiredMovementDirection == Vector3.zero)
		{
			result = (float)0;
		}
		else
		{
			float num = ((desiredMovementDirection.z <= (float)0) ? this.movement.maxBackwardsSpeed : this.movement.maxForwardSpeed) / this.movement.maxSidewaysSpeed;
			Vector3 normalized = new Vector3(desiredMovementDirection.x, (float)0, desiredMovementDirection.z / num).normalized;
			float num2 = new Vector3(normalized.x, (float)0, normalized.z * num).magnitude * this.movement.maxSidewaysSpeed;
			result = num2;
		}
		return result;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00007CD0 File Offset: 0x00005ED0
	public virtual void SetVelocity(Vector3 velocity)
	{
		this.grounded = false;
		this.movement.velocity = velocity;
		this.movement.frameVelocity = Vector3.zero;
		this.SendMessage("OnExternalVelocity");
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00007D0C File Offset: 0x00005F0C
	public virtual void Main()
	{
	}

	// Token: 0x04000123 RID: 291
	public bool canControl;

	// Token: 0x04000124 RID: 292
	public bool useFixedUpdate;

	// Token: 0x04000125 RID: 293
	[NonSerialized]
	public Vector3 inputMoveDirection;

	// Token: 0x04000126 RID: 294
	[NonSerialized]
	public bool inputJump;

	// Token: 0x04000127 RID: 295
	public CharacterMotorMovement movement;

	// Token: 0x04000128 RID: 296
	public CharacterMotorJumping jumping;

	// Token: 0x04000129 RID: 297
	public CharacterMotorMovingPlatform movingPlatform;

	// Token: 0x0400012A RID: 298
	public CharacterMotorSliding sliding;

	// Token: 0x0400012B RID: 299
	[NonSerialized]
	public bool grounded;

	// Token: 0x0400012C RID: 300
	[NonSerialized]
	public Vector3 groundNormal;

	// Token: 0x0400012D RID: 301
	private Vector3 lastGroundNormal;

	// Token: 0x0400012E RID: 302
	private Transform tr;

	// Token: 0x0400012F RID: 303
	private CharacterController controller;

	// Token: 0x02000033 RID: 51
	[CompilerGenerated]
	[Serializable]
	internal sealed class $SubtractNewPlatformVelocity$168 : GenericGenerator<object>
	{
		// Token: 0x06000094 RID: 148 RVA: 0x00007D10 File Offset: 0x00005F10
		public $SubtractNewPlatformVelocity$168(CharacterMotor self_)
		{
			this.$self_$171 = self_;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007D20 File Offset: 0x00005F20
		public override IEnumerator<object> GetEnumerator()
		{
			return new CharacterMotor.$SubtractNewPlatformVelocity$168.$(this.$self_$171);
		}

		// Token: 0x04000130 RID: 304
		internal CharacterMotor $self_$171;
	}
}
