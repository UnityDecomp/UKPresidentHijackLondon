using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000044 RID: 68
[RequireComponent(typeof(StatusC))]
[RequireComponent(typeof(CharacterMotorC))]
public class AIfriendC : MonoBehaviour
{
	// Token: 0x06000315 RID: 789 RVA: 0x0000BE38 File Offset: 0x0000A238
	private void Start()
	{
		base.gameObject.tag = "Ally";
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		base.GetComponent<StatusC>().mainModel = this.mainModel;
		if (!this.master)
		{
			MonoBehaviour.print("Please Assign It's Master first");
		}
		if (!this.attackPoint)
		{
			this.attackPoint = base.transform;
		}
		base.GetComponent<StatusC>().useMecanim = this.useMecanim;
		this.continueAttack = this.attackAnimation.Length;
		this.atk = base.GetComponent<StatusC>().atk;
		this.mag = base.GetComponent<StatusC>().matk;
		this.followState = AIfriendC.AIStatef.FollowMaster;
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
				this.animator = this.mainModel.GetComponent<Animator>();
			}
			this.animator.SetBool("run", true);
		}
		if (this.master)
		{
		}
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0000BFA0 File Offset: 0x0000A3A0
	private Vector3 GetDestination()
	{
		Vector3 position = this.followTarget.position;
		position.y = base.transform.position.y;
		return position;
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0000BFD4 File Offset: 0x0000A3D4
	private Vector3 GetMasterPosition()
	{
		if (!this.master)
		{
			return Vector3.zero;
		}
		Vector3 position = this.master.position;
		position.y = base.transform.position.y;
		return position;
	}

	// Token: 0x06000318 RID: 792 RVA: 0x0000C020 File Offset: 0x0000A420
	private void Update()
	{
		CharacterController component = base.GetComponent<CharacterController>();
		StatusC component2 = base.GetComponent<StatusC>();
		if (!this.master)
		{
			component2.Death();
			return;
		}
		if (this.meleefwd && !component2.freeze)
		{
			Vector3 a = base.transform.TransformDirection(Vector3.forward);
			component.Move(a * 5f * Time.deltaTime);
			return;
		}
		if (this.freeze || component2.freeze)
		{
			return;
		}
		if (this.useMecanim)
		{
			this.animator.SetBool("hurt", this.flinch);
		}
		if (this.flinch)
		{
			this.cancelAttack = true;
			Vector3 a2 = base.transform.TransformDirection(Vector3.back);
			component.SimpleMove(a2 * 5f);
			return;
		}
		if (this.allowFollowing && (this.master.position - base.transform.position).magnitude > 40f)
		{
			Vector3 position = this.master.position;
			position.y += 0.4f;
			position.x += UnityEngine.Random.Range(3f, 9f);
			position.z += UnityEngine.Random.Range(3f, 9f);
			base.transform.position = position;
		}
		if (this.searchEnemy)
		{
			this.FindClosest();
		}
		if (!this.followTarget)
		{
			this.FindClosest();
		}
		if (this.allowFollowing)
		{
			if (this.followState == AIfriendC.AIStatef.FollowMaster && this.allowFollowing)
			{
				if ((this.master.position - base.transform.position).magnitude <= this.minMasterDistance)
				{
					this.followState = AIfriendC.AIStatef.Idle;
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
					Vector3 a3 = base.transform.TransformDirection(Vector3.forward);
					component.Move(a3 * this.speed * Time.deltaTime);
					Vector3 position2 = this.master.position;
					position2.y = base.transform.position.y;
					base.transform.LookAt(position2);
				}
			}
			else if (this.followState == AIfriendC.AIStatef.Moving)
			{
				this.masterDistance = (base.transform.position - this.GetMasterPosition()).magnitude;
				if (this.masterDistance > this.detectRange + 5f)
				{
					this.followState = AIfriendC.AIStatef.FollowMaster;
					if (!this.useMecanim)
					{
						this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
					}
					else
					{
						this.animator.SetBool("run", true);
					}
				}
				else if ((this.followTarget.position - base.transform.position).magnitude <= this.approachDistance)
				{
					this.followState = AIfriendC.AIStatef.Pausing;
					if (!this.useMecanim)
					{
						this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
					}
					else
					{
						this.animator.SetBool("run", false);
					}
					if (this.followTarget.tag != "Player")
					{
						base.StartCoroutine(this.Attack());
						MonoBehaviour.print("Attacking");
					}
				}
				else if ((this.followTarget.position - base.transform.position).magnitude >= this.lostSight)
				{
					base.GetComponent<StatusC>().health = base.GetComponent<StatusC>().maxHealth;
					this.followState = AIfriendC.AIStatef.Idle;
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
					Vector3 a4 = base.transform.TransformDirection(Vector3.forward);
					component.Move(a4 * this.speed * Time.deltaTime);
					Vector3 position3 = this.followTarget.position;
					position3.y = base.transform.position.y;
					base.transform.LookAt(position3);
				}
			}
			else if (this.followState == AIfriendC.AIStatef.Pausing)
			{
				Vector3 position4 = this.followTarget.position;
				position4.y = base.transform.position.y;
				base.transform.LookAt(position4);
				this.distance = (base.transform.position - this.GetDestination()).magnitude;
				this.masterDistance = (base.transform.position - this.GetMasterPosition()).magnitude;
				if (this.masterDistance > 12f)
				{
					this.followState = AIfriendC.AIStatef.FollowMaster;
					if (!this.useMecanim)
					{
						this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
					}
					else
					{
						this.animator.SetBool("run", true);
					}
				}
				else if (this.distance > this.approachDistance + 10f)
				{
					this.followState = AIfriendC.AIStatef.Moving;
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
			else if (this.followState == AIfriendC.AIStatef.Idle)
			{
				Vector3 position5 = this.followTarget.position;
				position5.y = base.transform.position.y - position5.y;
				this.distance = (base.transform.position - this.GetDestination()).magnitude;
				this.masterDistance = (base.transform.position - this.GetMasterPosition()).magnitude;
				if (this.distance < this.detectRange && Mathf.Abs(position5.y) <= 4f && this.followTarget)
				{
					this.followState = AIfriendC.AIStatef.Moving;
					if (!this.useMecanim)
					{
						this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
					}
					else
					{
						this.animator.SetBool("run", true);
					}
				}
				else if (this.masterDistance > this.maxMasterDistance)
				{
					this.followState = AIfriendC.AIStatef.FollowMaster;
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
		else if (this.useMecanim)
		{
			this.animator.SetBool("run", false);
		}
		else
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0000C808 File Offset: 0x0000AC08
	private IEnumerator Attack()
	{
		StatusC stat = base.GetComponent<StatusC>();
		this.atk = base.GetComponent<StatusC>().atk;
		this.mag = base.GetComponent<StatusC>().matk;
		this.cancelAttack = false;
		int c = 0;
		if (this.flinch)
		{
			yield return false;
		}
		while (c < this.continueAttack && this.followTarget)
		{
			this.freeze = true;
			if (this.attackType == AIfriendC.AIatkType.MeleeDash)
			{
				base.StartCoroutine(this.MeleeDash());
			}
			if (this.followTarget)
			{
				Vector3 position = this.followTarget.position;
				position.y = base.transform.position.y;
				base.transform.LookAt(position);
			}
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().PlayQueued(this.attackAnimation[c].name, QueueMode.PlayNow);
			}
			else
			{
				this.animator.Play(this.attackAnimation[c].name);
			}
			yield return new WaitForSeconds(this.attackCast);
			if (this.flinch || stat.freeze)
			{
				this.freeze = false;
				c = this.continueAttack;
				yield return false;
			}
			if (!this.cancelAttack || base.GetComponent<StatusC>().freeze)
			{
				Transform bulletShootout = UnityEngine.Object.Instantiate<Transform>(this.attackPrefab, this.attackPoint.transform.position, this.attackPoint.transform.rotation);
				bulletShootout.GetComponent<BulletStatusC>().Setting(this.atk, this.mag, "Player", base.gameObject);
				c++;
				yield return new WaitForSeconds(this.continueAttackDelay);
			}
			else
			{
				this.freeze = false;
				c = this.continueAttack;
			}
		}
		yield return new WaitForSeconds(this.attackDelay);
		c = 0;
		this.freeze = false;
		this.CheckDistance();
		yield break;
	}

	// Token: 0x0600031A RID: 794 RVA: 0x0000C824 File Offset: 0x0000AC24
	private void CheckDistance()
	{
		this.masterDistance = (base.transform.position - this.GetMasterPosition()).magnitude;
		if (this.masterDistance > this.detectRange + 5f)
		{
			this.followState = AIfriendC.AIStatef.FollowMaster;
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
			}
			else
			{
				this.animator.SetBool("run", true);
			}
			return;
		}
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
			this.followState = AIfriendC.AIStatef.Idle;
			return;
		}
		float magnitude = (this.followTarget.position - base.transform.position).magnitude;
		if (magnitude <= this.approachDistance)
		{
			Vector3 position = this.followTarget.position;
			position.y = base.transform.position.y;
			base.transform.LookAt(position);
			this.Attack();
		}
		else
		{
			this.followState = AIfriendC.AIStatef.Moving;
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

	// Token: 0x0600031B RID: 795 RVA: 0x0000C9C8 File Offset: 0x0000ADC8
	private void FindClosest()
	{
		if (!this.allowAttack)
		{
			this.followTarget = this.master;
			return;
		}
		base.StartCoroutine(this.searchEnemyRoutine());
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		if (array.Length <= 0)
		{
			return;
		}
		GameObject gameObject = null;
		float num = float.PositiveInfinity;
		Vector3 position = base.transform.position;
		foreach (GameObject gameObject2 in array)
		{
			float sqrMagnitude = (gameObject2.transform.position - position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				gameObject = gameObject2;
				num = sqrMagnitude;
			}
		}
		if (!gameObject)
		{
			this.followTarget = null;
			this.followState = AIfriendC.AIStatef.FollowMaster;
			if (!this.useMecanim)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
			}
			else
			{
				this.animator.SetBool("run", true);
			}
			return;
		}
		this.followTarget = gameObject.transform;
	}

	// Token: 0x0600031C RID: 796 RVA: 0x0000CAD8 File Offset: 0x0000AED8
	private IEnumerator MeleeDash()
	{
		this.meleefwd = true;
		yield return new WaitForSeconds(0.2f);
		this.meleefwd = false;
		yield break;
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0000CAF4 File Offset: 0x0000AEF4
	private void Flinch(Vector3 dir)
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
		base.StartCoroutine(this.KnockBack());
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().PlayQueued(this.hurtAnimation.name, QueueMode.PlayNow);
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		this.followState = AIfriendC.AIStatef.Moving;
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0000CBF0 File Offset: 0x0000AFF0
	private IEnumerator KnockBack()
	{
		this.flinch = true;
		yield return new WaitForSeconds(0.2f);
		this.flinch = false;
		yield break;
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0000CC0C File Offset: 0x0000B00C
	private IEnumerator searchEnemyRoutine()
	{
		this.searchEnemy = false;
		yield return new WaitForSeconds(5f);
		this.searchEnemy = true;
		yield break;
	}

	// Token: 0x0400017D RID: 381
	public Transform[] masterList;

	// Token: 0x0400017E RID: 382
	public Transform master;

	// Token: 0x0400017F RID: 383
	[HideInInspector]
	public bool searchEnemy = true;

	// Token: 0x04000180 RID: 384
	public GameObject mainModel;

	// Token: 0x04000181 RID: 385
	public bool useMecanim;

	// Token: 0x04000182 RID: 386
	public Animator animator;

	// Token: 0x04000183 RID: 387
	public Transform followTarget;

	// Token: 0x04000184 RID: 388
	public float approachDistance = 3f;

	// Token: 0x04000185 RID: 389
	public float detectRange = 15f;

	// Token: 0x04000186 RID: 390
	public float lostSight = 100f;

	// Token: 0x04000187 RID: 391
	public float speed = 4f;

	// Token: 0x04000188 RID: 392
	public float minMasterDistance = 5f;

	// Token: 0x04000189 RID: 393
	public float maxMasterDistance = 18f;

	// Token: 0x0400018A RID: 394
	public AnimationClip movingAnimation;

	// Token: 0x0400018B RID: 395
	public AnimationClip idleAnimation;

	// Token: 0x0400018C RID: 396
	public AnimationClip[] attackAnimation = new AnimationClip[1];

	// Token: 0x0400018D RID: 397
	public AnimationClip hurtAnimation;

	// Token: 0x0400018E RID: 398
	private bool flinch;

	// Token: 0x0400018F RID: 399
	public bool stability;

	// Token: 0x04000190 RID: 400
	public bool freeze;

	// Token: 0x04000191 RID: 401
	public bool allowFollowing = true;

	// Token: 0x04000192 RID: 402
	public bool allowAttack = true;

	// Token: 0x04000193 RID: 403
	public Transform attackPrefab;

	// Token: 0x04000194 RID: 404
	public Transform attackPoint;

	// Token: 0x04000195 RID: 405
	private bool startFollow = true;

	// Token: 0x04000196 RID: 406
	public float attackCast = 0.5f;

	// Token: 0x04000197 RID: 407
	public float attackDelay = 1f;

	// Token: 0x04000198 RID: 408
	private int continueAttack = 1;

	// Token: 0x04000199 RID: 409
	public float continueAttackDelay = 0.8f;

	// Token: 0x0400019A RID: 410
	private AIfriendC.AIStatef followState;

	// Token: 0x0400019B RID: 411
	private float distance;

	// Token: 0x0400019C RID: 412
	private float masterDistance;

	// Token: 0x0400019D RID: 413
	private int atk;

	// Token: 0x0400019E RID: 414
	private int mag;

	// Token: 0x0400019F RID: 415
	private bool cancelAttack;

	// Token: 0x040001A0 RID: 416
	private bool meleefwd;

	// Token: 0x040001A1 RID: 417
	public AIfriendC.AIatkType attackType;

	// Token: 0x040001A2 RID: 418
	public AudioClip[] attackVoice = new AudioClip[3];

	// Token: 0x040001A3 RID: 419
	public AudioClip hurtVoice;

	// Token: 0x02000045 RID: 69
	private enum AIStatef
	{
		// Token: 0x040001A5 RID: 421
		Moving,
		// Token: 0x040001A6 RID: 422
		Pausing,
		// Token: 0x040001A7 RID: 423
		Escape,
		// Token: 0x040001A8 RID: 424
		Idle,
		// Token: 0x040001A9 RID: 425
		FollowMaster
	}

	// Token: 0x02000046 RID: 70
	public enum AIatkType
	{
		// Token: 0x040001AB RID: 427
		Immobile,
		// Token: 0x040001AC RID: 428
		MeleeDash
	}
}
