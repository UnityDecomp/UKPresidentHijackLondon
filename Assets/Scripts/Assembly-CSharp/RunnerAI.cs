using System;
using UnityEngine;

// Token: 0x0200020A RID: 522
public class RunnerAI : MonoBehaviour
{
	// Token: 0x06000D88 RID: 3464 RVA: 0x0005684C File Offset: 0x00054C4C
	private void Start()
	{
		this.controller = base.GetComponent<CharacterController>();
		this.animator = this.mainModel.GetComponent<Animator>();
		this.move = false;
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x00056874 File Offset: 0x00054C74
	private void Update()
	{
		if (!this.move && !this.freeze)
		{
			this.checkForEnemy();
			return;
		}
		if (this.target)
		{
			Vector3 a = (this.target.transform.position - base.transform.position).normalized * 14f;
			base.transform.LookAt(this.target.position);
			this.controller.Move(a * this.runSpeed * Time.deltaTime);
			this.animator.SetBool("run", true);
			if (Vector3.Distance(base.transform.position, this.target.position) < 4f)
			{
				this.move = false;
				this.freeze = true;
				this.target = null;
				this.animator.SetBool("run", false);
			}
			return;
		}
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x0005697C File Offset: 0x00054D7C
	private void checkForEnemy()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, this.detectRange);
		foreach (Collider collider in array)
		{
			if (collider.CompareTag("Player"))
			{
				this.move = true;
			}
		}
	}

	// Token: 0x04000E3C RID: 3644
	public Transform target;

	// Token: 0x04000E3D RID: 3645
	public GameObject mainModel;

	// Token: 0x04000E3E RID: 3646
	public float runSpeed = 1f;

	// Token: 0x04000E3F RID: 3647
	public float detectRange = 4f;

	// Token: 0x04000E40 RID: 3648
	private CharacterController controller;

	// Token: 0x04000E41 RID: 3649
	private Animator animator;

	// Token: 0x04000E42 RID: 3650
	[HideInInspector]
	public bool move;

	// Token: 0x04000E43 RID: 3651
	private bool freeze;
}
