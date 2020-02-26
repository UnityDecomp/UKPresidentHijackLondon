using System;
using UnityEngine;

// Token: 0x02000209 RID: 521
public class RunAtPoint : MonoBehaviour
{
	// Token: 0x06000D84 RID: 3460 RVA: 0x0005675C File Offset: 0x00054B5C
	private void Start()
	{
		this.controller = base.GetComponent<CharacterController>();
		this.anim = base.GetComponent<Animator>();
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x00056778 File Offset: 0x00054B78
	private void Update()
	{
		if (RunAtPoint.startRun && this.target)
		{
			Vector3 a = base.transform.TransformDirection(Vector3.forward);
			base.transform.LookAt(new Vector3(this.target.position.x, base.transform.position.y, this.target.position.z));
			this.anim.SetBool("run", true);
			this.controller.Move(a * this.speed * Time.deltaTime);
		}
	}

	// Token: 0x04000E37 RID: 3639
	public static bool startRun;

	// Token: 0x04000E38 RID: 3640
	public float speed = 4f;

	// Token: 0x04000E39 RID: 3641
	public Transform target;

	// Token: 0x04000E3A RID: 3642
	private CharacterController controller;

	// Token: 0x04000E3B RID: 3643
	private Animator anim;
}
