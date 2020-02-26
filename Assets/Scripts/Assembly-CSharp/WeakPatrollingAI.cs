using System;
using UnityEngine;

// Token: 0x0200021E RID: 542
[RequireComponent(typeof(WeakAI))]
public class WeakPatrollingAI : MonoBehaviour
{
	// Token: 0x06000DE8 RID: 3560 RVA: 0x00058F84 File Offset: 0x00057384
	private void Start()
	{
		this.ai = base.GetComponent<WeakAI>();
		this.mainModel = base.GetComponent<WeakAI>().mainModel;
		this.useMecanim = base.GetComponent<WeakAI>().useMecanim;
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		this.movingAnimation = this.ai.movingAnimation;
		this.idleAnimation = this.ai.idleAnimation;
		if (this.useMecanim)
		{
			this.animator = this.ai.animator;
			if (!this.animator)
			{
				this.animator = this.mainModel.GetComponent<Animator>();
			}
		}
	}

	// Token: 0x06000DE9 RID: 3561 RVA: 0x0005903C File Offset: 0x0005743C
	private void Update()
	{
		if (this.ai.followState == WeakAI.AIState.Idle)
		{
			if (this.state == 1)
			{
				CharacterController component = base.GetComponent<CharacterController>();
				Vector3 a = base.transform.TransformDirection(Vector3.forward);
				component.Move(a * this.speed * Time.deltaTime);
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
				this.wait = 0f;
				this.state = 0;
			}
			this.wait += Time.deltaTime;
		}
	}

	// Token: 0x06000DEA RID: 3562 RVA: 0x0005915C File Offset: 0x0005755C
	private void RandomTurning()
	{
		float y = (float)UnityEngine.Random.Range(0, 360);
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
		if (this.movingAnimation && !this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		else if (this.useMecanim)
		{
			this.animator.SetBool("run", true);
		}
		this.wait = 0f;
		this.state = 1;
	}

	// Token: 0x04000EB8 RID: 3768
	public float speed = 4f;

	// Token: 0x04000EB9 RID: 3769
	private WeakAI ai;

	// Token: 0x04000EBA RID: 3770
	private int state;

	// Token: 0x04000EBB RID: 3771
	private AnimationClip movingAnimation;

	// Token: 0x04000EBC RID: 3772
	private AnimationClip idleAnimation;

	// Token: 0x04000EBD RID: 3773
	private GameObject mainModel;

	// Token: 0x04000EBE RID: 3774
	public float idleDuration = 2f;

	// Token: 0x04000EBF RID: 3775
	public float moveDuration = 3f;

	// Token: 0x04000EC0 RID: 3776
	private bool useMecanim;

	// Token: 0x04000EC1 RID: 3777
	private Animator animator;

	// Token: 0x04000EC2 RID: 3778
	private float wait;
}
