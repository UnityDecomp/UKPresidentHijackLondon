using System;
using UnityEngine;

// Token: 0x02000067 RID: 103
[RequireComponent(typeof(AIset))]
[Serializable]
public class PatrollingAi : MonoBehaviour
{
	// Token: 0x06000145 RID: 325 RVA: 0x0000FE48 File Offset: 0x0000E048
	public PatrollingAi()
	{
		this.speed = 4f;
		this.idleDuration = 2f;
		this.moveDuration = 3f;
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0000FE74 File Offset: 0x0000E074
	public virtual void Start()
	{
		this.ai = (AIset)this.GetComponent(typeof(AIset));
		this.mainModel = ((AIset)this.GetComponent(typeof(AIset))).mainModel;
		this.useMecanim = ((AIset)this.GetComponent(typeof(AIset))).useMecanim;
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		this.movingAnimation = this.ai.movingAnimation;
		this.idleAnimation = this.ai.idleAnimation;
		if (this.useMecanim)
		{
			this.animator = this.ai.animator;
			if (!this.animator)
			{
				this.animator = (Animator)this.mainModel.GetComponent(typeof(Animator));
			}
		}
	}

	// Token: 0x06000147 RID: 327 RVA: 0x0000FF68 File Offset: 0x0000E168
	public virtual void Update()
	{
		if (this.ai.followState == AIState.Idle)
		{
			if (this.state == 1)
			{
				CharacterController characterController = (CharacterController)this.GetComponent(typeof(CharacterController));
				Vector3 a = this.transform.TransformDirection(Vector3.forward);
				characterController.Move(a * this.speed * Time.deltaTime);
			}
			if (this.wait >= this.idleDuration && this.state == 0)
			{
				this.RandomTurning();
			}
			if (this.wait >= this.moveDuration && this.state == 1)
			{
				if (this.idleAnimation && !this.useMecanim)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
				}
				else if (this.useMecanim)
				{
					this.animator.SetBool("run", false);
				}
				this.wait = (float)0;
				this.state = 0;
			}
			this.wait += Time.deltaTime;
		}
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00010094 File Offset: 0x0000E294
	public virtual void RandomTurning()
	{
		float num = (float)UnityEngine.Random.Range(0, 360);
		float y = num;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.y = y;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
		if (this.movingAnimation && !this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		else if (this.useMecanim)
		{
			this.animator.SetBool("run", true);
		}
		this.wait = (float)0;
		this.state = 1;
	}

	// Token: 0x06000149 RID: 329 RVA: 0x0001014C File Offset: 0x0000E34C
	public virtual void Main()
	{
	}

	// Token: 0x04000235 RID: 565
	public float speed;

	// Token: 0x04000236 RID: 566
	private AIset ai;

	// Token: 0x04000237 RID: 567
	private int state;

	// Token: 0x04000238 RID: 568
	private AnimationClip movingAnimation;

	// Token: 0x04000239 RID: 569
	private AnimationClip idleAnimation;

	// Token: 0x0400023A RID: 570
	private GameObject mainModel;

	// Token: 0x0400023B RID: 571
	public float idleDuration;

	// Token: 0x0400023C RID: 572
	public float moveDuration;

	// Token: 0x0400023D RID: 573
	private float wait;

	// Token: 0x0400023E RID: 574
	private bool useMecanim;

	// Token: 0x0400023F RID: 575
	private Animator animator;
}
