using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x0200006B RID: 107
[RequireComponent(typeof(CharacterMotor))]
[Serializable]
public class PlayerInputController : MonoBehaviour
{
	// Token: 0x06000158 RID: 344 RVA: 0x00010A04 File Offset: 0x0000EC04
	public PlayerInputController()
	{
		this.walkSpeed = 6f;
		this.sprintSpeed = 12f;
		this.canSprint = true;
		this.staminaRecover = 1.4f;
		this.useStamina = 0.04f;
		this.maxStamina = 100f;
		this.stamina = 100f;
		this.dir = Vector3.forward;
		this.useMecanim = true;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00010A74 File Offset: 0x0000EC74
	public virtual void Start()
	{
		this.motor = (CharacterMotor)this.GetComponent(typeof(CharacterMotor));
		this.controller = (CharacterController)this.GetComponent(typeof(CharacterController));
		this.stamina = this.maxStamina;
		if (!this.mainModel)
		{
			this.mainModel = ((Status)this.GetComponent(typeof(Status))).mainModel;
		}
		this.useMecanim = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).useMecanim;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00010B14 File Offset: 0x0000ED14
	public virtual void Update()
	{
		Status status = (Status)this.GetComponent(typeof(Status));
		if (status.freeze)
		{
			this.motor.inputMoveDirection = new Vector3((float)0, (float)0, (float)0);
		}
		else if (Time.timeScale != (float)0)
		{
			if (this.dodging)
			{
				Vector3 a = this.transform.TransformDirection(this.dir);
				this.controller.Move(a * (float)8 * Time.deltaTime);
			}
			else
			{
				if (this.recover && !this.sprint && !this.dodging)
				{
					if (this.recoverStamina >= this.staminaRecover)
					{
						this.StaminaRecovery();
					}
					else
					{
						this.recoverStamina += Time.deltaTime;
					}
				}
				if (this.dodgeRollSetting.canDodgeRoll)
				{
					if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > (float)0 && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && Input.GetAxis("Horizontal") == (float)0)
					{
						if (Input.GetButtonDown("Vertical") && Time.time - this.lastTime < 0.4f && Input.GetButtonDown("Vertical") && Time.time - this.lastTime > 0.1f && Input.GetAxis("Vertical") > 0.03f)
						{
							this.lastTime = Time.time;
							this.dir = Vector3.forward;
							this.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeForward));
						}
						else
						{
							this.lastTime = Time.time;
						}
					}
					if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < (float)0 && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && Input.GetAxis("Horizontal") == (float)0)
					{
						if (Input.GetButtonDown("Vertical") && Time.time - this.lastTime < 0.4f && Input.GetButtonDown("Vertical") && Time.time - this.lastTime > 0.1f && Input.GetAxis("Vertical") < -0.03f)
						{
							this.lastTime = Time.time;
							this.dir = Vector3.back;
							this.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeBack));
						}
						else
						{
							this.lastTime = Time.time;
						}
					}
					if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < (float)0 && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && !Input.GetButton("Vertical"))
					{
						if (Input.GetButtonDown("Horizontal") && Time.time - this.lastTime < 0.3f && Input.GetButtonDown("Horizontal") && Time.time - this.lastTime > 0.15f && Input.GetAxis("Horizontal") < -0.03f)
						{
							this.lastTime = Time.time;
							this.dir = Vector3.left;
							this.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeLeft));
						}
						else
						{
							this.lastTime = Time.time;
						}
					}
					if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > (float)0 && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && !Input.GetButton("Vertical"))
					{
						if (Input.GetButtonDown("Horizontal") && Time.time - this.lastTime < 0.3f && Input.GetButtonDown("Horizontal") && Time.time - this.lastTime > 0.15f && Input.GetAxis("Horizontal") > 0.03f)
						{
							this.lastTime = Time.time;
							this.dir = Vector3.right;
							this.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeRight));
						}
						else
						{
							this.lastTime = Time.time;
						}
					}
				}
				if ((this.sprint && Input.GetAxis("Vertical") < 0.02f) || (this.sprint && this.stamina <= (float)0) || (this.sprint && Input.GetButtonDown("Fire1")) || (this.sprint && Input.GetKeyUp(KeyCode.LeftShift)))
				{
					this.sprint = false;
					this.recover = true;
					this.motor.movement.maxForwardSpeed = this.walkSpeed;
					this.motor.movement.maxSidewaysSpeed = this.walkSpeed;
					this.recoverStamina = (float)0;
				}
				Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), (float)0, Input.GetAxis("Vertical"));
				if (vector != Vector3.zero)
				{
					float num = vector.magnitude;
					vector /= num;
					num = Mathf.Min((float)1, num);
					num *= num;
					vector *= num;
				}
				this.motor.inputMoveDirection = this.transform.rotation * vector;
				this.motor.inputJump = Input.GetButton("Jump");
				if (this.sprint)
				{
					this.motor.movement.maxForwardSpeed = this.sprintSpeed;
					this.motor.movement.maxSidewaysSpeed = this.sprintSpeed;
				}
				else if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > (float)0 && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && this.canSprint && this.stamina > (float)0)
				{
					this.sprint = true;
					this.StartCoroutine(this.Dasher());
				}
			}
		}
	}

	// Token: 0x0600015B RID: 347 RVA: 0x00011150 File Offset: 0x0000F350
	public virtual void OnGUI()
	{
		if (this.sprint || this.recover || this.dodging)
		{
			float width = this.stamina * (float)100 / this.maxStamina * (float)3;
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height - 120), width, (float)10), this.staminaGauge);
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 153), (float)(Screen.height - 123), (float)306, (float)16), this.staminaBorder);
		}
	}

	// Token: 0x0600015C RID: 348 RVA: 0x000111F0 File Offset: 0x0000F3F0
	public virtual IEnumerator Dasher()
	{
		return new PlayerInputController.$Dasher$197(this).GetEnumerator();
	}

	// Token: 0x0600015D RID: 349 RVA: 0x00011200 File Offset: 0x0000F400
	public virtual void StaminaRecovery()
	{
		this.stamina += (float)1;
		if (this.stamina >= this.maxStamina)
		{
			this.stamina = this.maxStamina;
			this.recoverStamina = (float)0;
			this.recover = false;
		}
		else
		{
			this.recoverStamina = this.staminaRecover - 0.02f;
		}
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00011260 File Offset: 0x0000F460
	public virtual IEnumerator DodgeRoll(AnimationClip anim)
	{
		return new PlayerInputController.$DodgeRoll$200(anim, this).GetEnumerator();
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00011270 File Offset: 0x0000F470
	public virtual void Main()
	{
	}

	// Token: 0x04000262 RID: 610
	private GameObject mainModel;

	// Token: 0x04000263 RID: 611
	public float walkSpeed;

	// Token: 0x04000264 RID: 612
	public float sprintSpeed;

	// Token: 0x04000265 RID: 613
	public bool canSprint;

	// Token: 0x04000266 RID: 614
	private bool sprint;

	// Token: 0x04000267 RID: 615
	private bool recover;

	// Token: 0x04000268 RID: 616
	private float staminaRecover;

	// Token: 0x04000269 RID: 617
	private float useStamina;

	// Token: 0x0400026A RID: 618
	[HideInInspector]
	public bool dodging;

	// Token: 0x0400026B RID: 619
	public Texture2D staminaGauge;

	// Token: 0x0400026C RID: 620
	public Texture2D staminaBorder;

	// Token: 0x0400026D RID: 621
	public float maxStamina;

	// Token: 0x0400026E RID: 622
	public float stamina;

	// Token: 0x0400026F RID: 623
	private float lastTime;

	// Token: 0x04000270 RID: 624
	private float recoverStamina;

	// Token: 0x04000271 RID: 625
	private Vector3 dir;

	// Token: 0x04000272 RID: 626
	private bool useMecanim;

	// Token: 0x04000273 RID: 627
	public DodgeSetting dodgeRollSetting;

	// Token: 0x04000274 RID: 628
	private CharacterMotor motor;

	// Token: 0x04000275 RID: 629
	private CharacterController controller;

	// Token: 0x0200006C RID: 108
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Dasher$197 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000160 RID: 352 RVA: 0x00011274 File Offset: 0x0000F474
		public $Dasher$197(PlayerInputController self_)
		{
			this.$self_$199 = self_;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00011284 File Offset: 0x0000F484
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new PlayerInputController.$Dasher$197.$(this.$self_$199);
		}

		// Token: 0x04000276 RID: 630
		internal PlayerInputController $self_$199;
	}

	// Token: 0x0200006E RID: 110
	[CompilerGenerated]
	[Serializable]
	internal sealed class $DodgeRoll$200 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000164 RID: 356 RVA: 0x00011340 File Offset: 0x0000F540
		public $DodgeRoll$200(AnimationClip anim, PlayerInputController self_)
		{
			this.$anim$203 = anim;
			this.$self_$204 = self_;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00011358 File Offset: 0x0000F558
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new PlayerInputController.$DodgeRoll$200.$(this.$anim$203, this.$self_$204);
		}

		// Token: 0x04000278 RID: 632
		internal AnimationClip $anim$203;

		// Token: 0x04000279 RID: 633
		internal PlayerInputController $self_$204;
	}
}
