using System;
using DG.Tweening;
using SWS;
using UnityEngine;

// Token: 0x020000F8 RID: 248
public class PathInputDemo : MonoBehaviour
{
	// Token: 0x060006F4 RID: 1780 RVA: 0x0002D967 File Offset: 0x0002BD67
	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
		this.move = base.GetComponent<splineMove>();
		this.move.StartMove();
		this.move.Pause(0f);
		this.progress = 0f;
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x0002D9A8 File Offset: 0x0002BDA8
	private void Update()
	{
		float num = this.speedMultiplier / 100f;
		float num2 = this.move.tween.Duration(true);
		if (Input.GetKey("right"))
		{
			this.progress += Time.deltaTime * 10f * num;
			this.progress = Mathf.Clamp(this.progress, 0f, num2);
			this.move.tween.fullPosition = this.progress;
		}
		if (Input.GetKey("left"))
		{
			this.progress -= Time.deltaTime * 10f * num;
			this.progress = Mathf.Clamp(this.progress, 0f, num2);
			this.move.tween.fullPosition = this.progress;
		}
		if ((Input.GetKey("right") || Input.GetKey("left")) && this.progress != 0f && this.progress != num2)
		{
			this.animator.SetFloat("Speed", this.move.speed);
		}
		else
		{
			this.animator.SetFloat("Speed", 0f);
		}
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x0002DAF0 File Offset: 0x0002BEF0
	private void LateUpdate()
	{
		if (Input.GetKey("left"))
		{
			Vector3 localEulerAngles = base.transform.localEulerAngles;
			localEulerAngles.y += 180f;
			base.transform.localEulerAngles = localEulerAngles;
		}
	}

	// Token: 0x040005EE RID: 1518
	public float speedMultiplier = 10f;

	// Token: 0x040005EF RID: 1519
	public float progress;

	// Token: 0x040005F0 RID: 1520
	private splineMove move;

	// Token: 0x040005F1 RID: 1521
	private Animator animator;
}
