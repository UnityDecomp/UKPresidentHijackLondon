using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

// Token: 0x02000012 RID: 18
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Action-RPG Kit/Create Enemy")]
[RequireComponent(typeof(Status))]
[Serializable]
public class AIset : MonoBehaviour
{
	// Token: 0x0600002D RID: 45 RVA: 0x00003A08 File Offset: 0x00001C08
	public AIset()
	{
		this.approachDistance = 2f;
		this.detectRange = 15f;
		this.lostSight = 100f;
		this.speed = 4f;
		this.attackCast = 0.3f;
		this.attackDelay = 0.5f;
		this.knock = Vector3.zero;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003A68 File Offset: 0x00001C68
	public virtual void Start()
	{
		this.gameObject.tag = "Enemy";
		if (!this.attackPoint)
		{
			this.attackPoint = this.transform;
		}
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		((Status)this.GetComponent(typeof(Status))).useMecanim = this.useMecanim;
		((Status)this.GetComponent(typeof(Status))).mainModel = this.mainModel;
		this.atk = ((Status)this.GetComponent(typeof(Status))).atk;
		this.matk = ((Status)this.GetComponent(typeof(Status))).matk;
		this.followState = AIState.Idle;
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().Play(this.idleAnimation.name);
			this.mainModel.GetComponent<Animation>()[this.hurtAnimation.name].layer = 10;
		}
		else if (!this.animator)
		{
			this.animator = (Animator)this.mainModel.GetComponent(typeof(Animator));
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00003BC4 File Offset: 0x00001DC4
	public virtual Vector3 GetDestination()
	{
		Vector3 position = this.followTarget.position;
		position.y = this.transform.position.y;
		return position;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00003BF8 File Offset: 0x00001DF8
	public virtual void Update()
	{
		Status status = (Status)this.GetComponent(typeof(Status));
		CharacterController characterController = (CharacterController)this.GetComponent(typeof(CharacterController));
		this.FindClosest();
		if (this.useMecanim)
		{
			this.animator.SetBool("hurt", this.flinch);
		}
		if (this.flinch)
		{
			characterController.Move(this.knock * (float)6 * Time.deltaTime);
		}
		else if (!this.freeze && !status.freeze)
		{
			if (this.followTarget)
			{
				if (this.followState == AIState.Moving)
				{
					if ((this.followTarget.position - this.transform.position).magnitude <= this.approachDistance)
					{
						this.followState = AIState.Pausing;
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
						this.angry = false;
						((Status)this.GetComponent(typeof(Status))).health = ((Status)this.GetComponent(typeof(Status))).maxHealth;
						this.followState = AIState.Idle;
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
						Vector3 a = this.transform.TransformDirection(Vector3.forward);
						characterController.Move(a * this.speed * Time.deltaTime);
						Vector3 position = this.followTarget.position;
						position.y = this.transform.position.y;
						this.transform.LookAt(position);
					}
				}
				else if (this.followState == AIState.Pausing)
				{
					Vector3 position2 = this.followTarget.position;
					position2.y = this.transform.position.y;
					this.transform.LookAt(position2);
					this.distance = (this.transform.position - this.GetDestination()).magnitude;
					if (this.distance > this.approachDistance)
					{
						this.followState = AIState.Moving;
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
				else if (this.followState == AIState.Idle)
				{
					Vector3 position3 = this.followTarget.position;
					position3.y = this.transform.position.y - position3.y;
					int num = ((Status)this.GetComponent(typeof(Status))).maxHealth - ((Status)this.GetComponent(typeof(Status))).health;
					this.distance = (this.transform.position - this.GetDestination()).magnitude;
					if ((this.distance < this.detectRange && Mathf.Abs(position3.y) <= (float)4) || num > 0)
					{
						this.followState = AIState.Moving;
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

	// Token: 0x06000031 RID: 49 RVA: 0x00004038 File Offset: 0x00002238
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
			this.knock = this.transform.TransformDirection(Vector3.back);
			this.StartCoroutine(this.KnockBack());
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().PlayQueued(this.hurtAnimation.name, QueueMode.PlayNow);
				this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
			}
			this.followState = AIState.Moving;
		}
	}

	// Token: 0x06000032 RID: 50 RVA: 0x0000415C File Offset: 0x0000235C
	public virtual IEnumerator KnockBack()
	{
		return new AIset.$KnockBack$127(this).GetEnumerator();
	}

	// Token: 0x06000033 RID: 51 RVA: 0x0000416C File Offset: 0x0000236C
	public virtual IEnumerator Attack()
	{
		return new AIset.$Attack$130(this).GetEnumerator();
	}

	// Token: 0x06000034 RID: 52 RVA: 0x0000417C File Offset: 0x0000237C
	public virtual void CheckDistance()
	{
		if (!this.followTarget)
		{
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
			}
			else
			{
				this.animator.SetBool("run", false);
			}
			this.followState = AIState.Idle;
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
				this.followState = AIState.Moving;
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

	// Token: 0x06000035 RID: 53 RVA: 0x000042A4 File Offset: 0x000024A4
	public virtual void FindClosest()
	{
		this.gos = GameObject.FindGameObjectsWithTag("Player");
		this.gos = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), this.gos, GameObject.FindGameObjectsWithTag("Ally"));
		if (this.gos.Length > 0)
		{
			this.angry = true;
			float num = float.PositiveInfinity;
			Vector3 position = this.transform.position;
			int i = 0;
			GameObject[] array = this.gos;
			int length = array.Length;
			while (i < length)
			{
				float sqrMagnitude = (array[i].transform.position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					this.followTarget = array[i].transform;
					num = sqrMagnitude;
				}
				i++;
			}
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00004380 File Offset: 0x00002580
	public virtual void FindClosestEnemy()
	{
		float num = float.PositiveInfinity;
		float radius = this.detectRange;
		Collider[] array = Physics.OverlapSphere(this.transform.position, radius);
		int i = 0;
		Collider[] array2 = array;
		int length = array2.Length;
		while (i < length)
		{
			if (array2[i].CompareTag("Player") || array2[i].CompareTag("Ally"))
			{
				float sqrMagnitude = (array2[i].transform.position - this.transform.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					this.followTarget = array2[i].transform;
					num = sqrMagnitude;
				}
			}
			i++;
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x0000443C File Offset: 0x0000263C
	public virtual IEnumerator UseSkill(Transform skill, float castTime, float delay, string anim, float dist)
	{
		return new AIset.$UseSkill$134(skill, castTime, delay, anim, dist, this).GetEnumerator();
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00004458 File Offset: 0x00002658
	public virtual void Main()
	{
	}

	// Token: 0x04000053 RID: 83
	public GameObject mainModel;

	// Token: 0x04000054 RID: 84
	public Transform followTarget;

	// Token: 0x04000055 RID: 85
	public float approachDistance;

	// Token: 0x04000056 RID: 86
	public float detectRange;

	// Token: 0x04000057 RID: 87
	public float lostSight;

	// Token: 0x04000058 RID: 88
	public float speed;

	// Token: 0x04000059 RID: 89
	public bool useMecanim;

	// Token: 0x0400005A RID: 90
	public Animator animator;

	// Token: 0x0400005B RID: 91
	public AnimationClip movingAnimation;

	// Token: 0x0400005C RID: 92
	public AnimationClip idleAnimation;

	// Token: 0x0400005D RID: 93
	public AnimationClip attackAnimation;

	// Token: 0x0400005E RID: 94
	public AnimationClip hurtAnimation;

	// Token: 0x0400005F RID: 95
	[HideInInspector]
	public bool flinch;

	// Token: 0x04000060 RID: 96
	public bool stability;

	// Token: 0x04000061 RID: 97
	public bool freeze;

	// Token: 0x04000062 RID: 98
	public Transform bulletPrefab;

	// Token: 0x04000063 RID: 99
	public Transform attackPoint;

	// Token: 0x04000064 RID: 100
	public float attackCast;

	// Token: 0x04000065 RID: 101
	public float attackDelay;

	// Token: 0x04000066 RID: 102
	[HideInInspector]
	public AIState followState;

	// Token: 0x04000067 RID: 103
	private float distance;

	// Token: 0x04000068 RID: 104
	private int atk;

	// Token: 0x04000069 RID: 105
	private int matk;

	// Token: 0x0400006A RID: 106
	private Vector3 knock;

	// Token: 0x0400006B RID: 107
	[HideInInspector]
	public bool cancelAttack;

	// Token: 0x0400006C RID: 108
	private bool attacking;

	// Token: 0x0400006D RID: 109
	private bool castSkill;

	// Token: 0x0400006E RID: 110
	private bool angry;

	// Token: 0x0400006F RID: 111
	private GameObject[] gos;

	// Token: 0x04000070 RID: 112
	public AudioClip attackVoice;

	// Token: 0x04000071 RID: 113
	public AudioClip hurtVoice;

	// Token: 0x02000013 RID: 19
	[CompilerGenerated]
	[Serializable]
	internal sealed class $KnockBack$127 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000039 RID: 57 RVA: 0x0000445C File Offset: 0x0000265C
		public $KnockBack$127(AIset self_)
		{
			this.$self_$129 = self_;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000446C File Offset: 0x0000266C
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AIset.$KnockBack$127.$(this.$self_$129);
		}

		// Token: 0x04000072 RID: 114
		internal AIset $self_$129;
	}

	// Token: 0x02000015 RID: 21
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Attack$130 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000044E8 File Offset: 0x000026E8
		public $Attack$130(AIset self_)
		{
			this.$self_$133 = self_;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000044F8 File Offset: 0x000026F8
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AIset.$Attack$130.$(this.$self_$133);
		}

		// Token: 0x04000074 RID: 116
		internal AIset $self_$133;
	}

	// Token: 0x02000017 RID: 23
	[CompilerGenerated]
	[Serializable]
	internal sealed class $UseSkill$134 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000041 RID: 65 RVA: 0x000047E4 File Offset: 0x000029E4
		public $UseSkill$134(Transform skill, float castTime, float delay, string anim, float dist, AIset self_)
		{
			this.$skill$142 = skill;
			this.$castTime$143 = castTime;
			this.$delay$144 = delay;
			this.$anim$145 = anim;
			this.$dist$146 = dist;
			this.$self_$147 = self_;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00004830 File Offset: 0x00002A30
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AIset.$UseSkill$134.$(this.$skill$142, this.$castTime$143, this.$delay$144, this.$anim$145, this.$dist$146, this.$self_$147);
		}

		// Token: 0x04000077 RID: 119
		internal Transform $skill$142;

		// Token: 0x04000078 RID: 120
		internal float $castTime$143;

		// Token: 0x04000079 RID: 121
		internal float $delay$144;

		// Token: 0x0400007A RID: 122
		internal string $anim$145;

		// Token: 0x0400007B RID: 123
		internal float $dist$146;

		// Token: 0x0400007C RID: 124
		internal AIset $self_$147;
	}
}
