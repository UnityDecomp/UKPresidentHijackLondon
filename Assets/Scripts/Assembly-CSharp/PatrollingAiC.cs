using System;
using UnityEngine;

// Token: 0x02000079 RID: 121
[RequireComponent(typeof(AIsetC))]
public class PatrollingAiC : MonoBehaviour
{
	// Token: 0x060003D0 RID: 976 RVA: 0x000179B8 File Offset: 0x00015DB8
	private void Start()
	{
		this.ai = base.GetComponent<AIsetC>();
		this.mainModel = base.GetComponent<AIsetC>().mainModel;
		this.useMecanim = base.GetComponent<AIsetC>().useMecanim;
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

	// Token: 0x060003D1 RID: 977 RVA: 0x00017A70 File Offset: 0x00015E70
	private void Update()
	{
		if (this.ai.followState == AIsetC.AIState.Idle)
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

	// Token: 0x060003D2 RID: 978 RVA: 0x00017B90 File Offset: 0x00015F90
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

	// Token: 0x04000341 RID: 833
	public float speed = 4f;

	// Token: 0x04000342 RID: 834
	private AIsetC ai;

	// Token: 0x04000343 RID: 835
	private int state;

	// Token: 0x04000344 RID: 836
	private AnimationClip movingAnimation;

	// Token: 0x04000345 RID: 837
	private AnimationClip idleAnimation;

	// Token: 0x04000346 RID: 838
	private GameObject mainModel;

	// Token: 0x04000347 RID: 839
	public float idleDuration = 2f;

	// Token: 0x04000348 RID: 840
	public float moveDuration = 3f;

	// Token: 0x04000349 RID: 841
	private bool useMecanim;

	// Token: 0x0400034A RID: 842
	private Animator animator;

	// Token: 0x0400034B RID: 843
	private float wait;
}
