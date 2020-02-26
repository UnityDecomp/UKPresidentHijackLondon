using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x0200000A RID: 10
[RequireComponent(typeof(Status))]
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Action-RPG Kit/Create Ally")]
[Serializable]
public class AIfriend : MonoBehaviour
{
	// Token: 0x06000015 RID: 21 RVA: 0x00002678 File Offset: 0x00000878
	public AIfriend()
	{
		this.approachDistance = 3f;
		this.detectRange = 15f;
		this.lostSight = 100f;
		this.speed = 4f;
		this.attackAnimation = new AnimationClip[1];
		this.attackCast = 0.5f;
		this.attackDelay = 1f;
		this.continueAttack = 1;
		this.continueAttackDelay = 0.8f;
		this.attackType = AIatkType.Immobile;
		this.attackVoice = new AudioClip[3];
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002700 File Offset: 0x00000900
	public virtual void Start()
	{
		this.gameObject.tag = "Ally";
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		((Status)this.GetComponent(typeof(Status))).mainModel = this.mainModel;
		if (!this.master)
		{
			MonoBehaviour.print("Please Assign It's Master first");
		}
		if (!this.attackPoint)
		{
			this.attackPoint = this.transform;
		}
		((Status)this.GetComponent(typeof(Status))).useMecanim = this.useMecanim;
		this.continueAttack = this.attackAnimation.Length;
		this.atk = ((Status)this.GetComponent(typeof(Status))).atk;
		this.mag = ((Status)this.GetComponent(typeof(Status))).matk;
		this.followState = AIStatef.FollowMaster;
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().Play(this.movingAnimation.name);
			if (this.hurtAnimation)
			{
				this.mainModel.GetComponent<Animation>()[this.hurtAnimation.name].layer = 10;
			}
		}
		else
		{
			if (!this.animator)
			{
				this.animator = (Animator)this.mainModel.GetComponent(typeof(Animator));
			}
			this.animator.SetBool("run", true);
		}
		if (this.master)
		{
			Physics.IgnoreCollision(this.GetComponent<Collider>(), this.master.GetComponent<Collider>());
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000028CC File Offset: 0x00000ACC
	public virtual Vector3 GetDestination()
	{
		Vector3 position = this.followTarget.position;
		position.y = this.transform.position.y;
		return position;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002900 File Offset: 0x00000B00
	public virtual Vector3 GetMasterPosition()
	{
		Vector3 result;
		if (!this.master)
		{
			Vector3 vector;
			result = vector;
		}
		else
		{
			Vector3 position = this.master.position;
			position.y = this.transform.position.y;
			result = position;
		}
		return result;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x0000294C File Offset: 0x00000B4C
	public virtual void Update()
	{
		CharacterController characterController = (CharacterController)this.GetComponent(typeof(CharacterController));
		Status status = (Status)this.GetComponent(typeof(Status));
		if (!this.master)
		{
			status.Death();
		}
		else if (this.meleefwd && !status.freeze)
		{
			Vector3 a = this.transform.TransformDirection(Vector3.forward);
			characterController.Move(a * (float)5 * Time.deltaTime);
		}
		else if (!this.freeze && !status.freeze)
		{
			if (this.useMecanim)
			{
				this.animator.SetBool("hurt", this.flinch);
			}
			if (this.flinch)
			{
				this.cancelAttack = true;
				Vector3 a = this.transform.TransformDirection(Vector3.back);
				characterController.SimpleMove(a * (float)5);
			}
			else
			{
				if ((this.master.position - this.transform.position).magnitude > 30f)
				{
					Vector3 position = this.master.position;
					position.y += 1.7f;
					this.transform.position = position;
				}
				this.FindClosest();
				if (this.followState == AIStatef.FollowMaster)
				{
					if ((this.master.position - this.transform.position).magnitude <= 3f)
					{
						this.followState = AIStatef.Idle;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", false);
						}
					}
					else
					{
						Vector3 a2 = this.transform.TransformDirection(Vector3.forward);
						characterController.Move(a2 * this.speed * Time.deltaTime);
						Vector3 position2 = this.master.position;
						position2.y = this.transform.position.y;
						this.transform.LookAt(position2);
					}
				}
				else if (this.followState == AIStatef.Moving)
				{
					this.masterDistance = (this.transform.position - this.GetMasterPosition()).magnitude;
					if (this.masterDistance > this.detectRange + 5f)
					{
						this.followState = AIStatef.FollowMaster;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", true);
						}
					}
					else if ((this.followTarget.position - this.transform.position).magnitude <= this.approachDistance)
					{
						this.followState = AIStatef.Pausing;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", false);
						}
						this.StartCoroutine(this.Attack());
					}
					else if ((this.followTarget.position - this.transform.position).magnitude >= this.lostSight)
					{
						((Status)this.GetComponent(typeof(Status))).health = ((Status)this.GetComponent(typeof(Status))).maxHealth;
						this.followState = AIStatef.Idle;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", false);
						}
					}
					else
					{
						Vector3 a2 = this.transform.TransformDirection(Vector3.forward);
						characterController.Move(a2 * this.speed * Time.deltaTime);
						Vector3 position3 = this.followTarget.position;
						position3.y = this.transform.position.y;
						this.transform.LookAt(position3);
					}
				}
				else if (this.followState == AIStatef.Pausing)
				{
					Vector3 position4 = this.followTarget.position;
					position4.y = this.transform.position.y;
					this.transform.LookAt(position4);
					this.distance = (this.transform.position - this.GetDestination()).magnitude;
					this.masterDistance = (this.transform.position - this.GetMasterPosition()).magnitude;
					if (this.masterDistance > 12f)
					{
						this.followState = AIStatef.FollowMaster;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", true);
						}
					}
					else if (this.distance > this.approachDistance)
					{
						this.followState = AIStatef.Moving;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", true);
						}
					}
				}
				else if (this.followState == AIStatef.Idle)
				{
					Vector3 position5 = this.followTarget.position;
					position5.y = this.transform.position.y - position5.y;
					int num = ((Status)this.GetComponent(typeof(Status))).maxHealth - ((Status)this.GetComponent(typeof(Status))).health;
					this.distance = (this.transform.position - this.GetDestination()).magnitude;
					this.masterDistance = (this.transform.position - this.GetMasterPosition()).magnitude;
					if (this.distance < this.detectRange && Mathf.Abs(position5.y) <= (float)4 && this.followTarget)
					{
						this.followState = AIStatef.Moving;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", true);
						}
					}
					else if (this.masterDistance > 3f)
					{
						this.followState = AIStatef.FollowMaster;
						if (!this.useMecanim)
						{
							this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
						}
						else
						{
							this.animator.SetBool("run", true);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000030C0 File Offset: 0x000012C0
	public virtual IEnumerator Attack()
	{
		return new AIfriend.$Attack$114(this).GetEnumerator();
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000030D0 File Offset: 0x000012D0
	public virtual void CheckDistance()
	{
		this.masterDistance = (this.transform.position - this.GetMasterPosition()).magnitude;
		if (this.masterDistance > this.detectRange + 5f)
		{
			this.followState = AIStatef.FollowMaster;
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
			}
			else
			{
				this.animator.SetBool("run", true);
			}
		}
		else if (!this.followTarget)
		{
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
			}
			else
			{
				this.animator.SetBool("run", false);
			}
			this.followState = AIStatef.Idle;
		}
		else
		{
			float magnitude = (this.followTarget.position - this.transform.position).magnitude;
			if (magnitude <= this.approachDistance)
			{
				Vector3 position = this.followTarget.position;
				position.y = this.transform.position.y;
				this.transform.LookAt(position);
				this.StartCoroutine(this.Attack());
			}
			else
			{
				this.followState = AIStatef.Moving;
				if (!this.useMecanim)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
				}
				else
				{
					this.animator.SetBool("run", true);
				}
			}
		}
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00003280 File Offset: 0x00001480
	public virtual GameObject FindClosest()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		if (array != null)
		{
			GameObject gameObject = null;
			float num = float.PositiveInfinity;
			Vector3 position = this.transform.position;
			int i = 0;
			GameObject[] array2 = array;
			int length = array2.Length;
			while (i < length)
			{
				float sqrMagnitude = (array2[i].transform.position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					gameObject = array2[i];
					num = sqrMagnitude;
				}
				i++;
			}
			if (gameObject)
			{
				this.followTarget = gameObject.transform;
				return gameObject;
			}
			this.followTarget = null;
			this.followState = AIStatef.FollowMaster;
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
			}
			else
			{
				this.animator.SetBool("run", true);
			}
		}
		return null;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000337C File Offset: 0x0000157C
	public virtual IEnumerator MeleeDash()
	{
		return new AIfriend.$MeleeDash$121(this).GetEnumerator();
	}

	// Token: 0x0600001E RID: 30 RVA: 0x0000338C File Offset: 0x0000158C
	public virtual void Flinch(Vector3 dir)
	{
		if (!this.stability)
		{
			if (this.hurtVoice && ((Status)this.GetComponent(typeof(Status))).health >= 1)
			{
				this.GetComponent<AudioSource>().clip = this.hurtVoice;
				this.GetComponent<AudioSource>().Play();
			}
			this.cancelAttack = true;
			if (this.followTarget)
			{
				Vector3 position = this.followTarget.position;
				position.y = this.transform.position.y;
				this.transform.LookAt(position);
			}
			this.StartCoroutine(this.KnockBack());
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().PlayQueued(this.hurtAnimation.name, QueueMode.PlayNow);
				this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
			}
			this.followState = AIStatef.Moving;
		}
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000349C File Offset: 0x0000169C
	public virtual IEnumerator KnockBack()
	{
		return new AIfriend.$KnockBack$124(this).GetEnumerator();
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000034AC File Offset: 0x000016AC
	public virtual void Main()
	{
	}

	// Token: 0x04000024 RID: 36
	public Transform master;

	// Token: 0x04000025 RID: 37
	public GameObject mainModel;

	// Token: 0x04000026 RID: 38
	public bool useMecanim;

	// Token: 0x04000027 RID: 39
	public Animator animator;

	// Token: 0x04000028 RID: 40
	public Transform followTarget;

	// Token: 0x04000029 RID: 41
	public float approachDistance;

	// Token: 0x0400002A RID: 42
	public float detectRange;

	// Token: 0x0400002B RID: 43
	public float lostSight;

	// Token: 0x0400002C RID: 44
	public float speed;

	// Token: 0x0400002D RID: 45
	public AnimationClip movingAnimation;

	// Token: 0x0400002E RID: 46
	public AnimationClip idleAnimation;

	// Token: 0x0400002F RID: 47
	public AnimationClip[] attackAnimation;

	// Token: 0x04000030 RID: 48
	public AnimationClip hurtAnimation;

	// Token: 0x04000031 RID: 49
	private bool flinch;

	// Token: 0x04000032 RID: 50
	public bool stability;

	// Token: 0x04000033 RID: 51
	public bool freeze;

	// Token: 0x04000034 RID: 52
	public Transform attackPrefab;

	// Token: 0x04000035 RID: 53
	public Transform attackPoint;

	// Token: 0x04000036 RID: 54
	public float attackCast;

	// Token: 0x04000037 RID: 55
	public float attackDelay;

	// Token: 0x04000038 RID: 56
	private int continueAttack;

	// Token: 0x04000039 RID: 57
	public float continueAttackDelay;

	// Token: 0x0400003A RID: 58
	private AIStatef followState;

	// Token: 0x0400003B RID: 59
	private float distance;

	// Token: 0x0400003C RID: 60
	private float masterDistance;

	// Token: 0x0400003D RID: 61
	private int atk;

	// Token: 0x0400003E RID: 62
	private int mag;

	// Token: 0x0400003F RID: 63
	private bool cancelAttack;

	// Token: 0x04000040 RID: 64
	private bool meleefwd;

	// Token: 0x04000041 RID: 65
	public AIatkType attackType;

	// Token: 0x04000042 RID: 66
	public AudioClip[] attackVoice;

	// Token: 0x04000043 RID: 67
	public AudioClip hurtVoice;

	// Token: 0x0200000B RID: 11
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Attack$114 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000034B0 File Offset: 0x000016B0
		public $Attack$114(AIfriend self_)
		{
			this.$self_$120 = self_;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000034C0 File Offset: 0x000016C0
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AIfriend.$Attack$114.$(this.$self_$120);
		}

		// Token: 0x04000044 RID: 68
		internal AIfriend $self_$120;
	}

	// Token: 0x0200000D RID: 13
	[CompilerGenerated]
	[Serializable]
	internal sealed class $MeleeDash$121 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000025 RID: 37 RVA: 0x000038F0 File Offset: 0x00001AF0
		public $MeleeDash$121(AIfriend self_)
		{
			this.$self_$123 = self_;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003900 File Offset: 0x00001B00
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AIfriend.$MeleeDash$121.$(this.$self_$123);
		}

		// Token: 0x0400004A RID: 74
		internal AIfriend $self_$123;
	}

	// Token: 0x0200000F RID: 15
	[CompilerGenerated]
	[Serializable]
	internal sealed class $KnockBack$124 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000029 RID: 41 RVA: 0x0000397C File Offset: 0x00001B7C
		public $KnockBack$124(AIfriend self_)
		{
			this.$self_$126 = self_;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000398C File Offset: 0x00001B8C
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AIfriend.$KnockBack$124.$(this.$self_$126);
		}

		// Token: 0x0400004C RID: 76
		internal AIfriend $self_$126;
	}
}
