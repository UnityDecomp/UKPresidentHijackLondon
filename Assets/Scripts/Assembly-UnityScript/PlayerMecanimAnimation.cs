using System;
using UnityEngine;

// Token: 0x02000070 RID: 112
[RequireComponent(typeof(AttackTrigger))]
[AddComponentMenu("Action-RPG Kit/Create Player(Mecanim)")]
[Serializable]
public class PlayerMecanimAnimation : MonoBehaviour
{
	// Token: 0x06000168 RID: 360 RVA: 0x00011534 File Offset: 0x0000F734
	public PlayerMecanimAnimation()
	{
		this.moveHorizontalState = "horizontal";
		this.moveVerticalState = "vertical";
		this.jumpState = "jump";
		this.hurtState = "hurt";
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00011574 File Offset: 0x0000F774
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
		if (!this.animator)
		{
			this.animator = (Animator)this.mainModel.GetComponent(typeof(Animator));
		}
		this.controller = (CharacterController)this.player.GetComponent(typeof(CharacterController));
		((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).useMecanim = true;
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00011644 File Offset: 0x0000F844
	public virtual void Update()
	{
		this.attacking = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).isCasting;
		this.flinch = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).flinch;
		this.animator.SetBool(this.hurtState, this.flinch);
		if (!this.attacking && !this.flinch)
		{
			if ((this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None)
			{
				float axis = Input.GetAxis("Horizontal");
				float axis2 = Input.GetAxis("Vertical");
				this.animator.SetFloat(this.moveHorizontalState, axis);
				this.animator.SetFloat(this.moveVerticalState, axis2);
				if (this.jumping)
				{
					this.jumping = false;
					this.animator.SetBool(this.jumpState, this.jumping);
				}
			}
			else
			{
				this.jumping = true;
				this.animator.SetBool(this.jumpState, this.jumping);
			}
		}
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0001175C File Offset: 0x0000F95C
	public virtual void AttackAnimation(string anim)
	{
		this.animator.SetBool(this.jumpState, false);
		this.animator.Play(anim);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x0001177C File Offset: 0x0000F97C
	public virtual void PlayAnim(string anim)
	{
		this.animator.Play(anim);
	}

	// Token: 0x0600016D RID: 365 RVA: 0x0001178C File Offset: 0x0000F98C
	public virtual void SetWeaponType(int val, string idle)
	{
		this.animator.SetInteger("weaponType", val);
		this.animator.Play(idle);
	}

	// Token: 0x0600016E RID: 366 RVA: 0x000117AC File Offset: 0x0000F9AC
	public virtual void Main()
	{
	}

	// Token: 0x0400027C RID: 636
	private GameObject player;

	// Token: 0x0400027D RID: 637
	private GameObject mainModel;

	// Token: 0x0400027E RID: 638
	public Animator animator;

	// Token: 0x0400027F RID: 639
	private CharacterController controller;

	// Token: 0x04000280 RID: 640
	public string moveHorizontalState;

	// Token: 0x04000281 RID: 641
	public string moveVerticalState;

	// Token: 0x04000282 RID: 642
	public string jumpState;

	// Token: 0x04000283 RID: 643
	public string hurtState;

	// Token: 0x04000284 RID: 644
	private bool jumping;

	// Token: 0x04000285 RID: 645
	private bool attacking;

	// Token: 0x04000286 RID: 646
	private bool flinch;
}
