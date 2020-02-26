using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200021C RID: 540
public class WeakAI : MonoBehaviour
{
	// Token: 0x06000DDF RID: 3551 RVA: 0x00058754 File Offset: 0x00056B54
	private void Start()
	{
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
		this.followState = WeakAI.AIState.Idle;
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().Play(this.idleAnimation.name);
			this.mainModel.GetComponent<Animation>()[this.hurtAnimation.name].layer = 10;
		}
		else if (!this.animator)
		{
			this.animator = this.mainModel.GetComponent<Animator>();
		}
	}

	// Token: 0x06000DE0 RID: 3552 RVA: 0x00058854 File Offset: 0x00056C54
	private Vector3 GetDestination()
	{
		Vector3 position = this.followTarget.position;
		position.y = base.transform.position.y;
		return position;
	}

	// Token: 0x06000DE1 RID: 3553 RVA: 0x00058888 File Offset: 0x00056C88
	private void Update()
	{
		StatusC component = base.GetComponent<StatusC>();
		CharacterController component2 = base.GetComponent<CharacterController>();
		if (this.RunningInRange)
		{
			Vector3 a = base.transform.TransformDirection(this.runDirection);
			component2.Move(a * this.speed * Time.deltaTime);
			return;
		}
		this.followTarget = null;
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
		if (this.followState == WeakAI.AIState.Idle)
		{
			Vector3 position = this.followTarget.position;
			position.y = base.transform.position.y - position.y;
			int num = base.GetComponent<StatusC>().maxHealth - base.GetComponent<StatusC>().health;
			this.distance = (base.transform.position - this.GetDestination()).magnitude;
			if ((this.distance < this.detectRange && Mathf.Abs(position.y) <= 4f) || num > 0)
			{
				this.followState = WeakAI.AIState.Moving;
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

	// Token: 0x06000DE2 RID: 3554 RVA: 0x00058A54 File Offset: 0x00056E54
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
		this.knock = base.transform.TransformDirection(Vector3.back);
		base.StartCoroutine(this.KnockBack());
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().PlayQueued(this.hurtAnimation.name, QueueMode.PlayNow);
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		this.followState = WeakAI.AIState.Moving;
	}

	// Token: 0x06000DE3 RID: 3555 RVA: 0x00058B24 File Offset: 0x00056F24
	private IEnumerator KnockBack()
	{
		this.flinch = true;
		yield return new WaitForSeconds(0.2f);
		this.flinch = false;
		yield break;
	}

	// Token: 0x06000DE4 RID: 3556 RVA: 0x00058B40 File Offset: 0x00056F40
	private void FindClosestEnemy()
	{
		float num = this.detectRange;
		if (base.GetComponent<StatusC>().health < base.GetComponent<StatusC>().maxHealth)
		{
			num += this.lostSight + 3f;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, num);
		foreach (Collider collider in array)
		{
			if (collider.CompareTag("Player"))
			{
				this.followTarget = collider.transform;
				base.StartCoroutine(this.running());
			}
		}
	}

	// Token: 0x06000DE5 RID: 3557 RVA: 0x00058BE4 File Offset: 0x00056FE4
	private IEnumerator running()
	{
		if (this.allowTurn)
		{
			this.randomDirection();
		}
		else
		{
			this.runDirection = Vector3.back;
		}
		this.RunningInRange = true;
		this.followState = WeakAI.AIState.Moving;
		this.mainModel.transform.eulerAngles = new Vector3(this.mainModel.transform.eulerAngles.x, this.mainModel.transform.eulerAngles.y + (float)this.angle, this.mainModel.transform.eulerAngles.z);
		this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		yield return new WaitForSeconds((float)this.turnDelay);
		this.mainModel.transform.eulerAngles = new Vector3(this.mainModel.transform.eulerAngles.x, this.mainModel.transform.eulerAngles.y - (float)this.angle, this.mainModel.transform.eulerAngles.z);
		this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
		this.followState = WeakAI.AIState.Idle;
		this.RunningInRange = false;
		yield break;
	}

	// Token: 0x06000DE6 RID: 3558 RVA: 0x00058C00 File Offset: 0x00057000
	private void randomDirection()
	{
		int num = UnityEngine.Random.Range(0, 3);
		if (num == 0)
		{
			this.runDirection = Vector3.back;
			this.angle = 180;
		}
		else if (num == 1)
		{
			this.runDirection = Vector3.left;
			this.angle = -90;
		}
		else if (num == 2)
		{
			this.runDirection = Vector3.right;
			this.angle = 90;
		}
	}

	// Token: 0x04000E97 RID: 3735
	public GameObject mainModel;

	// Token: 0x04000E98 RID: 3736
	[HideInInspector]
	public Transform followTarget;

	// Token: 0x04000E99 RID: 3737
	private Vector3 runDirection;

	// Token: 0x04000E9A RID: 3738
	private int angle = 180;

	// Token: 0x04000E9B RID: 3739
	public float detectRange = 15f;

	// Token: 0x04000E9C RID: 3740
	public float lostSight = 100f;

	// Token: 0x04000E9D RID: 3741
	public float speed = 4f;

	// Token: 0x04000E9E RID: 3742
	public int turnDelay = 4;

	// Token: 0x04000E9F RID: 3743
	public bool allowTurn;

	// Token: 0x04000EA0 RID: 3744
	public bool useMecanim;

	// Token: 0x04000EA1 RID: 3745
	public Animator animator;

	// Token: 0x04000EA2 RID: 3746
	public AnimationClip movingAnimation;

	// Token: 0x04000EA3 RID: 3747
	public AnimationClip idleAnimation;

	// Token: 0x04000EA4 RID: 3748
	public AnimationClip attackAnimation;

	// Token: 0x04000EA5 RID: 3749
	public AnimationClip hurtAnimation;

	// Token: 0x04000EA6 RID: 3750
	[HideInInspector]
	public bool flinch;

	// Token: 0x04000EA7 RID: 3751
	public bool stability;

	// Token: 0x04000EA8 RID: 3752
	public bool freeze;

	// Token: 0x04000EA9 RID: 3753
	public Transform attackPoint;

	// Token: 0x04000EAA RID: 3754
	private bool RunningInRange;

	// Token: 0x04000EAB RID: 3755
	[HideInInspector]
	public WeakAI.AIState followState;

	// Token: 0x04000EAC RID: 3756
	private float distance;

	// Token: 0x04000EAD RID: 3757
	private int atk;

	// Token: 0x04000EAE RID: 3758
	private int matk;

	// Token: 0x04000EAF RID: 3759
	private Vector3 knock = Vector3.zero;

	// Token: 0x04000EB0 RID: 3760
	[HideInInspector]
	public bool cancelAttack;

	// Token: 0x04000EB1 RID: 3761
	private GameObject[] gos;

	// Token: 0x04000EB2 RID: 3762
	public AudioClip hurtVoice;

	// Token: 0x0200021D RID: 541
	public enum AIState
	{
		// Token: 0x04000EB4 RID: 3764
		Moving,
		// Token: 0x04000EB5 RID: 3765
		Pausing,
		// Token: 0x04000EB6 RID: 3766
		Idle,
		// Token: 0x04000EB7 RID: 3767
		Patrol
	}
}
