using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x02000049 RID: 73
[RequireComponent(typeof(AIset))]
[Serializable]
public class FlyingEnemy : MonoBehaviour
{
	// Token: 0x060000DD RID: 221 RVA: 0x0000A6C8 File Offset: 0x000088C8
	public FlyingEnemy()
	{
		this.flyDownRange = 5.5f;
		this.flyUpRange = 8.5f;
		this.flyingSpeed = 8f;
		this.flyUpHeight = 7f;
		this.landingDelay = 0.4f;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x0000A708 File Offset: 0x00008908
	public virtual void Start()
	{
		this.ai = (AIset)this.GetComponent(typeof(AIset));
		this.mainModel = ((AIset)this.GetComponent(typeof(AIset))).mainModel;
		((CharacterMotor)this.GetComponent(typeof(CharacterMotor))).enabled = false;
		this.useMecanim = ((AIset)this.GetComponent(typeof(AIset))).useMecanim;
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		if (this.useMecanim)
		{
			this.animator = this.ai.animator;
			if (!this.animator)
			{
				this.animator = (Animator)this.mainModel.GetComponent(typeof(Animator));
			}
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x0000A7F4 File Offset: 0x000089F4
	public virtual Vector3 GetDestination()
	{
		Vector3 position = this.target.position;
		position.y = this.transform.position.y;
		return position;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x0000A828 File Offset: 0x00008A28
	public virtual void Update()
	{
		if (!this.target && ((AIset)this.GetComponent(typeof(AIset))).followTarget)
		{
			this.target = ((AIset)this.GetComponent(typeof(AIset))).followTarget;
		}
		if (this.target)
		{
			CharacterController characterController = (CharacterController)this.GetComponent(typeof(CharacterController));
			if (this.flying == 1)
			{
				if (!this.useMecanim && this.flyDownAnimation)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.flyDownAnimation.name, 0.2f);
				}
				else
				{
					this.animator.SetBool("flyDown", true);
				}
				Vector3 a = this.transform.TransformDirection(Vector3.down);
				characterController.Move(a * this.flyingSpeed * Time.deltaTime);
			}
			else if (this.flying == 2)
			{
				if (!this.useMecanim && this.flyUpAnimation)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.flyUpAnimation.name, 0.2f);
				}
				else
				{
					this.animator.SetBool("flyUp", true);
				}
				Vector3 a = this.transform.TransformDirection(Vector3.up);
				characterController.Move(a * this.flyingSpeed * Time.deltaTime);
				if (this.transform.position.y >= this.currentHeight + this.flyUpHeight)
				{
					this.ai.freeze = false;
					this.flying = 0;
				}
			}
			else
			{
				this.distance = (this.transform.position - this.GetDestination()).magnitude;
				if (this.distance <= this.flyDownRange && !this.onGround)
				{
					this.FlyDown();
				}
				if (this.distance >= this.flyUpRange && this.onGround)
				{
					this.FlyUp();
				}
			}
		}
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x0000AA74 File Offset: 0x00008C74
	public virtual void FlyDown()
	{
		this.ai.freeze = true;
		this.flying = 1;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x0000AA8C File Offset: 0x00008C8C
	public virtual void FlyUp()
	{
		this.onGround = false;
		((CharacterMotor)this.GetComponent(typeof(CharacterMotor))).enabled = false;
		this.currentHeight = this.transform.position.y;
		this.ai.freeze = true;
		this.flying = 2;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000AAE8 File Offset: 0x00008CE8
	public virtual void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (this.flying == 1)
		{
			this.StartCoroutine(this.Landing());
		}
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000AB04 File Offset: 0x00008D04
	public virtual IEnumerator Landing()
	{
		return new FlyingEnemy.$Landing$179(this).GetEnumerator();
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x0000AB14 File Offset: 0x00008D14
	public virtual void Main()
	{
	}

	// Token: 0x0400018C RID: 396
	private int flying;

	// Token: 0x0400018D RID: 397
	private bool onGround;

	// Token: 0x0400018E RID: 398
	private Transform target;

	// Token: 0x0400018F RID: 399
	private float distance;

	// Token: 0x04000190 RID: 400
	public float flyDownRange;

	// Token: 0x04000191 RID: 401
	public float flyUpRange;

	// Token: 0x04000192 RID: 402
	public float flyingSpeed;

	// Token: 0x04000193 RID: 403
	public float flyUpHeight;

	// Token: 0x04000194 RID: 404
	public float landingDelay;

	// Token: 0x04000195 RID: 405
	private float currentHeight;

	// Token: 0x04000196 RID: 406
	public AnimationClip flyDownAnimation;

	// Token: 0x04000197 RID: 407
	public AnimationClip flyUpAnimation;

	// Token: 0x04000198 RID: 408
	public AnimationClip landingAnimation;

	// Token: 0x04000199 RID: 409
	private GameObject mainModel;

	// Token: 0x0400019A RID: 410
	private bool useMecanim;

	// Token: 0x0400019B RID: 411
	private Animator animator;

	// Token: 0x0400019C RID: 412
	private AIset ai;

	// Token: 0x0200004A RID: 74
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Landing$179 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x0000AB18 File Offset: 0x00008D18
		public $Landing$179(FlyingEnemy self_)
		{
			this.$self_$181 = self_;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000AB28 File Offset: 0x00008D28
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new FlyingEnemy.$Landing$179.$(this.$self_$181);
		}

		// Token: 0x0400019D RID: 413
		internal FlyingEnemy $self_$181;
	}
}
