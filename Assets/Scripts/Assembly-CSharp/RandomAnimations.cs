using System;
using UnityEngine;

// Token: 0x02000206 RID: 518
public class RandomAnimations : MonoBehaviour
{
	// Token: 0x06000D79 RID: 3449 RVA: 0x000563BC File Offset: 0x000547BC
	private void Start()
	{
		this.anim = base.GetComponent<Animator>();
		this.pointD = (UnityEngine.Object.FindObjectOfType(typeof(PointsAndDestinations)) as PointsAndDestinations);
		if (this.runDefaultOnStart)
		{
			this.anim.Play(this.defaultAnim.name);
		}
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x00056410 File Offset: 0x00054810
	private void Update()
	{
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x00056412 File Offset: 0x00054812
	public void playDyingAnim()
	{
		this.anim.Play(this.dyingAnim.name);
	}

	// Token: 0x06000D7C RID: 3452 RVA: 0x0005642C File Offset: 0x0005482C
	private void OnTriggerEnter(Collider other)
	{
		if ((base.gameObject.name == "Careless_guard" || base.gameObject.name == "Jailor") && (other.gameObject.name == "Melee(Clone)" || other.gameObject.name == "BulletC(Clone)"))
		{
			this.pointD.showNext(base.gameObject);
			this.playDyingAnim();
			base.gameObject.name = "unconsious_guard";
		}
	}

	// Token: 0x04000E28 RID: 3624
	public AnimationClip defaultAnim;

	// Token: 0x04000E29 RID: 3625
	public bool runDefaultOnStart;

	// Token: 0x04000E2A RID: 3626
	public AnimationClip dyingAnim;

	// Token: 0x04000E2B RID: 3627
	private Animator anim;

	// Token: 0x04000E2C RID: 3628
	private PointsAndDestinations pointD;
}
