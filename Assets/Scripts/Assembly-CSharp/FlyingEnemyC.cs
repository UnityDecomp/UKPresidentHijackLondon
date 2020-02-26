using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000067 RID: 103
public class FlyingEnemyC : MonoBehaviour
{
	// Token: 0x0600038C RID: 908 RVA: 0x00012F78 File Offset: 0x00011378
	private void Start()
	{
		this.ai = base.GetComponent<AIsetC>();
		this.mainModel = base.GetComponent<AIsetC>().mainModel;
		base.GetComponent<CharacterMotorC>().enabled = false;
		this.useMecanim = base.GetComponent<AIsetC>().useMecanim;
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		if (this.useMecanim)
		{
			this.animator = this.ai.animator;
			if (!this.animator)
			{
				this.animator = this.mainModel.GetComponent<Animator>();
			}
		}
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00013018 File Offset: 0x00011418
	private Vector3 GetDestination()
	{
		Vector3 position = this.target.position;
		position.y = base.transform.position.y;
		return position;
	}

	// Token: 0x0600038E RID: 910 RVA: 0x0001304C File Offset: 0x0001144C
	private void Update()
	{
		if (!this.target && base.GetComponent<AIsetC>().followTarget)
		{
			this.target = base.GetComponent<AIsetC>().followTarget;
		}
		if (!this.target)
		{
			return;
		}
		CharacterController component = base.GetComponent<CharacterController>();
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
			Vector3 a = base.transform.TransformDirection(Vector3.down);
			component.Move(a * this.flyingSpeed * Time.deltaTime);
			return;
		}
		if (this.flying == 2)
		{
			if (!this.useMecanim && this.flyUpAnimation)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.flyUpAnimation.name, 0.2f);
			}
			else
			{
				this.animator.SetBool("flyUp", true);
			}
			Vector3 a2 = base.transform.TransformDirection(Vector3.up);
			component.Move(a2 * this.flyingSpeed * Time.deltaTime);
			if (base.transform.position.y >= this.currentHeight + this.flyUpHeight)
			{
				this.ai.freeze = false;
				this.flying = 0;
			}
			return;
		}
		this.distance = (base.transform.position - this.GetDestination()).magnitude;
		if (this.distance <= this.flyDownRange && !this.onGround)
		{
			this.FlyDown();
		}
		if (this.distance >= this.flyUpRange && this.onGround)
		{
			this.FlyUp();
		}
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00013260 File Offset: 0x00011660
	private void FlyDown()
	{
		this.ai.freeze = true;
		this.flying = 1;
	}

	// Token: 0x06000390 RID: 912 RVA: 0x00013278 File Offset: 0x00011678
	private void FlyUp()
	{
		this.onGround = false;
		base.GetComponent<CharacterMotorC>().enabled = false;
		this.currentHeight = base.transform.position.y;
		this.ai.freeze = true;
		this.flying = 2;
	}

	// Token: 0x06000391 RID: 913 RVA: 0x000132C4 File Offset: 0x000116C4
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (this.flying == 1)
		{
			base.StartCoroutine(this.Landing());
		}
	}

	// Token: 0x06000392 RID: 914 RVA: 0x000132E0 File Offset: 0x000116E0
	private IEnumerator Landing()
	{
		base.GetComponent<CharacterMotorC>().enabled = true;
		if (this.landingAnimation && !this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().Play(this.landingAnimation.name);
		}
		else if (this.useMecanim)
		{
			this.animator.Play(this.landingAnimation.name);
		}
		yield return new WaitForSeconds(this.landingDelay);
		this.ai.freeze = false;
		this.flying = 0;
		this.onGround = true;
		yield break;
	}

	// Token: 0x040002A7 RID: 679
	private int flying;

	// Token: 0x040002A8 RID: 680
	private bool onGround;

	// Token: 0x040002A9 RID: 681
	private Transform target;

	// Token: 0x040002AA RID: 682
	private float distance;

	// Token: 0x040002AB RID: 683
	public float flyDownRange = 5.5f;

	// Token: 0x040002AC RID: 684
	public float flyUpRange = 8.5f;

	// Token: 0x040002AD RID: 685
	public float flyingSpeed = 8f;

	// Token: 0x040002AE RID: 686
	public float flyUpHeight = 7f;

	// Token: 0x040002AF RID: 687
	public float landingDelay = 0.4f;

	// Token: 0x040002B0 RID: 688
	private float currentHeight;

	// Token: 0x040002B1 RID: 689
	public AnimationClip flyDownAnimation;

	// Token: 0x040002B2 RID: 690
	public AnimationClip flyUpAnimation;

	// Token: 0x040002B3 RID: 691
	public AnimationClip landingAnimation;

	// Token: 0x040002B4 RID: 692
	private GameObject mainModel;

	// Token: 0x040002B5 RID: 693
	private bool useMecanim;

	// Token: 0x040002B6 RID: 694
	private Animator animator;

	// Token: 0x040002B7 RID: 695
	private AIsetC ai;
}
