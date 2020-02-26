using System;
using UnityEngine;

// Token: 0x0200007B RID: 123
[RequireComponent(typeof(AttackTriggerC))]
public class PlayerAnimationC : MonoBehaviour
{
	// Token: 0x060003DB RID: 987 RVA: 0x000181FC File Offset: 0x000165FC
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
		base.GetComponent<AttackTriggerC>().useMecanim = false;
		this.mainModel.GetComponent<Animation>()[this.run.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.right.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.left.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.back.name].speed = this.backMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.jump.name].wrapMode = WrapMode.ClampForever;
		if (this.hurt)
		{
			this.mainModel.GetComponent<Animation>()[this.hurt.name].layer = 5;
		}
	}

	// Token: 0x060003DC RID: 988 RVA: 0x00018348 File Offset: 0x00016748
	private void Update()
	{
	}

	// Token: 0x060003DD RID: 989 RVA: 0x0001834C File Offset: 0x0001674C
	public void StopAllAnims()
	{
		this.allowAnims = false;
		this.mainModel.GetComponent<Animation>().Stop(this.right.name);
		this.mainModel.GetComponent<Animation>().Stop(this.left.name);
		this.mainModel.GetComponent<Animation>().Stop(this.walk.name);
		this.mainModel.GetComponent<Animation>().Stop(this.idle.name);
	}

	// Token: 0x060003DE RID: 990 RVA: 0x000183CC File Offset: 0x000167CC
	public void AllowAllAnims()
	{
		this.allowAnims = true;
	}

	// Token: 0x060003DF RID: 991 RVA: 0x000183D8 File Offset: 0x000167D8
	public void AnimationSpeedSet()
	{
		this.mainModel = base.GetComponent<AttackTriggerC>().mainModel;
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		this.mainModel.GetComponent<Animation>()[this.run.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.right.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.left.name].speed = this.runMaxAnimationSpeed;
		this.mainModel.GetComponent<Animation>()[this.back.name].speed = this.backMaxAnimationSpeed;
	}

	// Token: 0x0400035C RID: 860
	public float runMaxAnimationSpeed = 1f;

	// Token: 0x0400035D RID: 861
	public float backMaxAnimationSpeed = 1f;

	// Token: 0x0400035E RID: 862
	public float sprintAnimationSpeed = 1.5f;

	// Token: 0x0400035F RID: 863
	private GameObject player;

	// Token: 0x04000360 RID: 864
	private GameObject mainModel;

	// Token: 0x04000361 RID: 865
	public AnimationClip idle;

	// Token: 0x04000362 RID: 866
	public AnimationClip walk;

	// Token: 0x04000363 RID: 867
	public AnimationClip run;

	// Token: 0x04000364 RID: 868
	public AnimationClip right;

	// Token: 0x04000365 RID: 869
	public AnimationClip left;

	// Token: 0x04000366 RID: 870
	public AnimationClip back;

	// Token: 0x04000367 RID: 871
	public AnimationClip jump;

	// Token: 0x04000368 RID: 872
	public AnimationClip hurt;

	// Token: 0x04000369 RID: 873
	private bool allowAnims = true;
}
