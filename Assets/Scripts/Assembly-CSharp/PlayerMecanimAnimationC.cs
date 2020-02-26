using System;
using UnityEngine;

// Token: 0x0200007E RID: 126
[RequireComponent(typeof(AttackTriggerC))]
public class PlayerMecanimAnimationC : MonoBehaviour
{
	// Token: 0x060003F9 RID: 1017 RVA: 0x00019FC4 File Offset: 0x000183C4
	private void Start()
	{
		if (!this.player)
		{
			this.player = base.gameObject;
		}
		this.mainModel = base.GetComponent<AttackTriggerC>().mainModel;
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		if (!this.animator)
		{
			this.animator = this.mainModel.GetComponent<Animator>();
		}
		this.controller = this.player.GetComponent<CharacterController>();
		base.GetComponent<AttackTriggerC>().useMecanim = true;
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0001A058 File Offset: 0x00018458
	private void Update()
	{
		this.attacking = base.GetComponent<AttackTriggerC>().isCasting;
		this.flinch = base.GetComponent<AttackTriggerC>().flinch;
		this.animator.SetBool(this.hurtState, this.flinch);
		if (this.attacking || this.flinch)
		{
			return;
		}
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

	// Token: 0x060003FB RID: 1019 RVA: 0x0001A14D File Offset: 0x0001854D
	public void AttackAnimation(string anim)
	{
		this.animator.SetBool(this.jumpState, false);
		this.animator.Play(anim);
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0001A16D File Offset: 0x0001856D
	public void PlayAnim(string anim)
	{
		this.animator.Play(anim);
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0001A17B File Offset: 0x0001857B
	public void PlayPickUpAnim()
	{
		this.animator.Play(this.pickupAnim.name);
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0001A193 File Offset: 0x00018593
	public void PlayEatAnim()
	{
		this.animator.Play(this.eatingAnim.name);
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0001A1AB File Offset: 0x000185AB
	public void PlaySleepAnim()
	{
		this.animator.Play(this.sleepAnim.name);
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0001A1C3 File Offset: 0x000185C3
	public void PlayWakeAnim()
	{
		this.animator.Play(this.wakeAnim.name);
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0001A1DB File Offset: 0x000185DB
	public void PlayDrinkAnim()
	{
		this.animator.Play(this.drinkingAnim.name);
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0001A1F3 File Offset: 0x000185F3
	public void SetWeaponType(int val, string idle)
	{
		this.animator.SetInteger("weaponType", val);
		this.animator.Play(idle);
	}

	// Token: 0x040003A3 RID: 931
	private GameObject player;

	// Token: 0x040003A4 RID: 932
	private GameObject mainModel;

	// Token: 0x040003A5 RID: 933
	public Animator animator;

	// Token: 0x040003A6 RID: 934
	private CharacterController controller;

	// Token: 0x040003A7 RID: 935
	public string moveHorizontalState = "horizontal";

	// Token: 0x040003A8 RID: 936
	public string moveVerticalState = "vertical";

	// Token: 0x040003A9 RID: 937
	public string jumpState = "jump";

	// Token: 0x040003AA RID: 938
	public string hurtState = "hurt";

	// Token: 0x040003AB RID: 939
	public AnimationClip pickupAnim;

	// Token: 0x040003AC RID: 940
	public AnimationClip eatingAnim;

	// Token: 0x040003AD RID: 941
	public AnimationClip sleepAnim;

	// Token: 0x040003AE RID: 942
	public AnimationClip wakeAnim;

	// Token: 0x040003AF RID: 943
	public AnimationClip drinkingAnim;

	// Token: 0x040003B0 RID: 944
	private bool jumping;

	// Token: 0x040003B1 RID: 945
	private bool attacking;

	// Token: 0x040003B2 RID: 946
	private bool flinch;
}
