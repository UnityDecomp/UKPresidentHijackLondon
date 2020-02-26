using System;
using UnityEngine;

// Token: 0x020001D9 RID: 473
public class CharacterIK : MonoBehaviour
{
	// Token: 0x06000C4E RID: 3150 RVA: 0x0004E206 File Offset: 0x0004C606
	private void Start()
	{
		this.anim = base.GetComponent<Animator>();
		this.chest = this.anim.GetBoneTransform(HumanBodyBones.Spine);
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x0004E228 File Offset: 0x0004C628
	private void LateUpdate()
	{
		if (this.chest)
		{
			this.chest.LookAt(this.Target.position);
			this.chest.rotation = this.chest.rotation * Quaternion.Euler(this.Offset);
		}
	}

	// Token: 0x04000CC0 RID: 3264
	public Transform Target;

	// Token: 0x04000CC1 RID: 3265
	public Vector3 Offset;

	// Token: 0x04000CC2 RID: 3266
	private Animator anim;

	// Token: 0x04000CC3 RID: 3267
	private Transform chest;
}
