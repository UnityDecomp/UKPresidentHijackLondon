using System;
using UnityEngine;

// Token: 0x02000069 RID: 105
[RequireComponent(typeof(AttackTrigger))]
[AddComponentMenu("Action-RPG Kit/Create Player(Legacy)")]
[Serializable]
public class PlayerAnimation : MonoBehaviour
{
	// Token: 0x06000152 RID: 338 RVA: 0x00010624 File Offset: 0x0000E824
	public PlayerAnimation()
	{
		this.runMaxAnimationSpeed = 1f;
		this.backMaxAnimationSpeed = 1f;
		this.sprintAnimationSpeed = 1.5f;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x00010650 File Offset: 0x0000E850
	public virtual void Start()
	{
		if (!this.player)
		{
			this.player = this.gameObject;
		}
		this.mainModel = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).mainModel;
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).useMecanim = false;
		this.mainModel.GetComponent<Animation>()[this.run.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.right.name].speed = this.runMaxAnimationSpeed - 0.6f;
		this.mainModel.GetComponent<Animation>()[this.left.name].speed = this.runMaxAnimationSpeed - 0.6f;
		this.mainModel.GetComponent<Animation>()[this.back.name].speed = this.backMaxAnimationSpeed - 0.6f;
		this.mainModel.GetComponent<Animation>()[this.jump.name].wrapMode = WrapMode.ClampForever;
		if (this.hurt)
		{
			this.mainModel.GetComponent<Animation>()[this.hurt.name].layer = 5;
		}
	}

	// Token: 0x06000154 RID: 340 RVA: 0x000107CC File Offset: 0x0000E9CC
	public virtual void Update()
	{
		CharacterController characterController = (CharacterController)this.player.GetComponent(typeof(CharacterController));
		if ((characterController.collisionFlags & CollisionFlags.Below) != CollisionFlags.None)
		{
			if (Input.GetAxis("Horizontal") > 0.1f)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.right.name);
			}
			else if (Input.GetAxis("Horizontal") < -0.1f)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.left.name);
			}
			else if (Input.GetAxis("Vertical") > 0.1f)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.walk.name);
			}
			else if (Input.GetAxis("Vertical") < -0.1f)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.walk.name);
			}
			else
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.idle.name);
			}
		}
		else
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.jump.name);
		}
	}

	// Token: 0x06000155 RID: 341 RVA: 0x0001090C File Offset: 0x0000EB0C
	public virtual void AnimationSpeedSet()
	{
		this.mainModel = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).mainModel;
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		this.mainModel.GetComponent<Animation>()[this.run.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.right.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.left.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.back.name].speed = this.backMaxAnimationSpeed;
	}

	// Token: 0x06000156 RID: 342 RVA: 0x000109F0 File Offset: 0x0000EBF0
	public virtual void Main()
	{
	}

	// Token: 0x0400024F RID: 591
	public float runMaxAnimationSpeed;

	// Token: 0x04000250 RID: 592
	public float backMaxAnimationSpeed;

	// Token: 0x04000251 RID: 593
	public float sprintAnimationSpeed;

	// Token: 0x04000252 RID: 594
	private GameObject player;

	// Token: 0x04000253 RID: 595
	private GameObject mainModel;

	// Token: 0x04000254 RID: 596
	public AnimationClip idle;

	// Token: 0x04000255 RID: 597
	public AnimationClip walk;

	// Token: 0x04000256 RID: 598
	public AnimationClip run;

	// Token: 0x04000257 RID: 599
	public AnimationClip right;

	// Token: 0x04000258 RID: 600
	public AnimationClip left;

	// Token: 0x04000259 RID: 601
	public AnimationClip back;

	// Token: 0x0400025A RID: 602
	public AnimationClip jump;

	// Token: 0x0400025B RID: 603
	public AnimationClip hurt;
}
