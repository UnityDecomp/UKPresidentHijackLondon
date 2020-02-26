using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000047 RID: 71
[RequireComponent(typeof(StatusC))]
[RequireComponent(typeof(CharacterMotorC))]
public class AIsetC : MonoBehaviour
{
	// Token: 0x06000321 RID: 801 RVA: 0x0000D260 File Offset: 0x0000B660
	private void Start()
	{
		base.gameObject.tag = "Enemy";
		this.yPos = base.transform.position.y;
		if (!this.attackPoint)
		{
			this.attackPoint = base.transform;
		}
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		base.GetComponent<StatusC>().useMecanim = this.useMecanim;
		base.GetComponent<StatusC>().mainModel = this.mainModel;
		this.atk = base.GetComponent<StatusC>().atk;
		this.matk = base.GetComponent<StatusC>().matk;
		this.followState = AIsetC.AIState.Idle;
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().Play(this.idleAnimation.name);
		}
		else if (!this.animator)
		{
			this.animator = this.mainModel.GetComponent<Animator>();
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0000D368 File Offset: 0x0000B768
	private Vector3 GetDestination()
	{
		Vector3 position = this.followTarget.position;
		position.y = base.transform.position.y;
		return position;
	}

	// Token: 0x06000323 RID: 803 RVA: 0x0000D39C File Offset: 0x0000B79C
	private void Update()
	{
		StatusC component = base.GetComponent<StatusC>();
		CharacterController component2 = base.GetComponent<CharacterController>();
		if (this.constantAxis)
		{
			base.transform.position = new Vector3(base.transform.position.x, this.yPos, base.transform.position.z);
		}
		this.FindClosestEnemy();
		if (this.useMecanim)
		{
			this.animator.SetBool("hurt", this.flinch);
		}
		if (this.flinch)
		{
			component2.Move(this.knock * 6f * Time.deltaTime);
			return;
		}
		if (this.freeze || component.freeze)
		{
			return;
		}
		if (!this.followTarget)
		{
			return;
		}
		if (this.followState == AIsetC.AIState.Moving)
		{
			if ((this.followTarget.position - base.transform.position).magnitude <= this.approachDistance)
			{
				this.followState = AIsetC.AIState.Pausing;
				if (!this.useMecanim)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
				}
				else
				{
					this.animator.SetBool("run", false);
				}
				if (!this.fleeModeOn)
				{
					base.StartCoroutine(this.Attack());
				}
			}
			else if ((this.followTarget.position - base.transform.position).magnitude >= this.lostSight)
			{
				base.GetComponent<StatusC>().health = base.GetComponent<StatusC>().maxHealth;
				this.followState = AIsetC.AIState.Idle;
				this.mainModel.transform.LookAt(this.followTarget.position);
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
				Vector3 a;
				if (this.fleeModeOn)
				{
					a = base.transform.TransformDirection(Vector3.back);
					this.enemyRunAway();
				}
				else
				{
					a = base.transform.TransformDirection(Vector3.forward);
				}
				component2.Move(a * this.speed * Time.deltaTime);
				Vector3 position = this.followTarget.position;
				position.y = base.transform.position.y;
				base.transform.LookAt(position);
			}
		}
		else if (this.followState == AIsetC.AIState.Pausing)
		{
			Vector3 position2 = this.followTarget.position;
			position2.y = base.transform.position.y;
			base.transform.LookAt(position2);
			this.distance = (base.transform.position - this.GetDestination()).magnitude;
			if (this.distance > this.approachDistance)
			{
				this.followState = AIsetC.AIState.Moving;
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
		else if (this.followState == AIsetC.AIState.Idle)
		{
			Vector3 position3 = this.followTarget.position;
			position3.y = base.transform.position.y - position3.y;
			int num = base.GetComponent<StatusC>().maxHealth - base.GetComponent<StatusC>().health;
			this.distance = (base.transform.position - this.GetDestination()).magnitude;
			if ((this.distance < this.detectRange && Mathf.Abs(position3.y) <= 4f) || num > 0)
			{
				this.followState = AIsetC.AIState.Moving;
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

	// Token: 0x06000324 RID: 804 RVA: 0x0000D810 File Offset: 0x0000BC10
	public void enemyRunAway()
	{
		this.mainModel.transform.LookAt(this.mainModel.transform.position - (this.followTarget.position - this.mainModel.transform.position));
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0000D864 File Offset: 0x0000BC64
	public void Flinch(Vector3 dir)
	{
		if (this.stability)
		{
			return;
		}
		if (this.hurtVoice && base.GetComponent<StatusC>().health >= 1)
		{
			base.GetComponent<AudioSource>().clip = this.hurtVoice;
			base.GetComponent<AudioSource>().Play();
		}
		this.cancelAttack = true;
		if (this.followTarget)
		{
			Vector3 position = this.followTarget.position;
			position.y = base.transform.position.y;
			base.transform.LookAt(position);
		}
		this.knock = base.transform.TransformDirection(Vector3.back);
		base.StartCoroutine(this.KnockBack());
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().PlayQueued(this.hurtAnimation.name, QueueMode.PlayNow);
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		else
		{
			this.animator.SetBool("run", true);
		}
		this.followState = AIsetC.AIState.Moving;
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0000D98C File Offset: 0x0000BD8C
	private IEnumerator KnockBack()
	{
		this.flinch = true;
		this.animator.Play("hurt");
		yield return new WaitForSeconds(0.2f);
		this.flinch = false;
		yield return new WaitForSeconds(0.2f);
		if (!this.attacking)
		{
			this.animator.Play("idle");
		}
		yield break;
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0000D9A8 File Offset: 0x0000BDA8
	private IEnumerator Attack()
	{
		this.cancelAttack = false;
		if (!this.flinch || !base.GetComponent<StatusC>().freeze || !this.freeze || !this.attacking)
		{
			this.freeze = true;
			this.attacking = true;
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().Play(this.attackAnimation.name);
			}
			else
			{
				this.animator.Play(this.attackAnimation.name);
			}
			yield return new WaitForSeconds(this.attackCast);
			if (!this.cancelAttack)
			{
				if (this.attackVoice && !this.flinch)
				{
					base.GetComponent<AudioSource>().clip = this.attackVoice;
					base.GetComponent<AudioSource>().Play();
				}
				Transform bulletShootout = UnityEngine.Object.Instantiate<Transform>(this.bulletPrefab, this.attackPoint.transform.position, this.attackPoint.transform.rotation);
				bulletShootout.GetComponent<BulletStatusC>().Setting(this.atk, this.matk, "Enemy", base.gameObject);
				yield return new WaitForSeconds(this.attackDelay);
				this.freeze = false;
				this.attacking = false;
				if (!this.useMecanim)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
				}
				this.CheckDistance();
			}
			else
			{
				this.freeze = false;
				this.attacking = false;
			}
		}
		yield break;
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0000D9C4 File Offset: 0x0000BDC4
	private void CheckDistance()
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
			this.followState = AIsetC.AIState.Idle;
			return;
		}
		float magnitude = (this.followTarget.position - base.transform.position).magnitude;
		if (magnitude <= this.approachDistance)
		{
			Vector3 position = this.followTarget.position;
			position.y = base.transform.position.y;
			base.transform.LookAt(position);
			base.StartCoroutine(this.Attack());
		}
		else
		{
			this.followState = AIsetC.AIState.Moving;
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

	// Token: 0x06000329 RID: 809 RVA: 0x0000DAE8 File Offset: 0x0000BEE8
	private void FindClosest()
	{
		this.gos = GameObject.FindGameObjectsWithTag("Player");
		if (this.gos.Length > 0)
		{
			float num = float.PositiveInfinity;
			Vector3 position = base.transform.position;
			foreach (GameObject gameObject in this.gos)
			{
				float sqrMagnitude = (gameObject.transform.position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					this.followTarget = gameObject.transform;
					num = sqrMagnitude;
				}
			}
		}
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0000DB7C File Offset: 0x0000BF7C
	private void FindClosestEnemy()
	{
		float num = float.PositiveInfinity;
		float num2 = this.detectRange;
		if (base.GetComponent<StatusC>().health < base.GetComponent<StatusC>().maxHealth)
		{
			num2 += this.lostSight + 3f;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, num2);
		foreach (Collider collider in array)
		{
			if (collider.CompareTag("Player"))
			{
				float sqrMagnitude = (collider.transform.position - base.transform.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					this.followTarget = collider.transform;
					num = sqrMagnitude;
				}
			}
		}
	}

	// Token: 0x0600032B RID: 811 RVA: 0x0000DC41 File Offset: 0x0000C041
	public void ActivateSkill(Transform skill, float castTime, float delay, string anim, float dist)
	{
		base.StartCoroutine(this.UseSkill(skill, this.attackCast, this.attackDelay, anim, dist));
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0000DC64 File Offset: 0x0000C064
	public IEnumerator UseSkill(Transform skill, float castTime, float delay, string anim, float dist)
	{
		this.cancelAttack = false;
		if (!this.flinch && this.followTarget && (this.followTarget.position - base.transform.position).magnitude < dist && !base.GetComponent<StatusC>().silence && !base.GetComponent<StatusC>().freeze && !this.castSkill)
		{
			this.freeze = true;
			this.castSkill = true;
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().Play(anim);
			}
			else
			{
				this.animator.Play(anim);
			}
			yield return new WaitForSeconds(castTime);
			if (!this.cancelAttack)
			{
				Transform bulletShootout = UnityEngine.Object.Instantiate<Transform>(this.bulletPrefab, this.attackPoint.transform.position, this.attackPoint.transform.rotation);
				bulletShootout.GetComponent<BulletStatusC>().Setting(this.atk, this.matk, "Enemy", base.gameObject);
				yield return new WaitForSeconds(delay);
				this.freeze = false;
				this.castSkill = false;
				if (!this.useMecanim)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
				}
				else
				{
					this.animator.SetBool("run", true);
				}
			}
			else
			{
				this.freeze = false;
				this.castSkill = false;
			}
		}
		yield break;
	}

	// Token: 0x040001AD RID: 429
	public GameObject mainModel;

	// Token: 0x040001AE RID: 430
	public Transform followTarget;

	// Token: 0x040001AF RID: 431
	public float approachDistance = 2f;

	// Token: 0x040001B0 RID: 432
	public float detectRange = 15f;

	// Token: 0x040001B1 RID: 433
	public float lostSight = 100f;

	// Token: 0x040001B2 RID: 434
	public float speed = 4f;

	// Token: 0x040001B3 RID: 435
	public bool useMecanim;

	// Token: 0x040001B4 RID: 436
	public bool constantAxis;

	// Token: 0x040001B5 RID: 437
	public Animator animator;

	// Token: 0x040001B6 RID: 438
	public AnimationClip movingAnimation;

	// Token: 0x040001B7 RID: 439
	public AnimationClip idleAnimation;

	// Token: 0x040001B8 RID: 440
	public AnimationClip attackAnimation;

	// Token: 0x040001B9 RID: 441
	public AnimationClip hurtAnimation;

	// Token: 0x040001BA RID: 442
	[HideInInspector]
	public bool flinch;

	// Token: 0x040001BB RID: 443
	public bool fleeModeOn;

	// Token: 0x040001BC RID: 444
	public bool stability;

	// Token: 0x040001BD RID: 445
	public bool freeze;

	// Token: 0x040001BE RID: 446
	public Transform bulletPrefab;

	// Token: 0x040001BF RID: 447
	public Transform attackPoint;

	// Token: 0x040001C0 RID: 448
	public float attackCast = 0.3f;

	// Token: 0x040001C1 RID: 449
	public float attackDelay = 0.5f;

	// Token: 0x040001C2 RID: 450
	[HideInInspector]
	public AIsetC.AIState followState;

	// Token: 0x040001C3 RID: 451
	private float distance;

	// Token: 0x040001C4 RID: 452
	private int atk;

	// Token: 0x040001C5 RID: 453
	private int matk;

	// Token: 0x040001C6 RID: 454
	private Vector3 knock = Vector3.zero;

	// Token: 0x040001C7 RID: 455
	[HideInInspector]
	public bool cancelAttack;

	// Token: 0x040001C8 RID: 456
	private bool attacking;

	// Token: 0x040001C9 RID: 457
	private bool castSkill;

	// Token: 0x040001CA RID: 458
	private GameObject[] gos;

	// Token: 0x040001CB RID: 459
	private float yPos;

	// Token: 0x040001CC RID: 460
	public AudioClip attackVoice;

	// Token: 0x040001CD RID: 461
	public AudioClip hurtVoice;

	// Token: 0x02000048 RID: 72
	public enum AIState
	{
		// Token: 0x040001CF RID: 463
		Moving,
		// Token: 0x040001D0 RID: 464
		Pausing,
		// Token: 0x040001D1 RID: 465
		Idle,
		// Token: 0x040001D2 RID: 466
		Patrol
	}
}
