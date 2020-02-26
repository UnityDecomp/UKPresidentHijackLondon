using System;
using UnityEngine;

// Token: 0x020001F8 RID: 504
public class PlayAnimation : MonoBehaviour
{
	// Token: 0x06000CEA RID: 3306 RVA: 0x00051516 File Offset: 0x0004F916
	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x00051524 File Offset: 0x0004F924
	private void Update()
	{
		if (!this.allow)
		{
			return;
		}
		if (this.animateOnce)
		{
			this.allow = false;
		}
		this.animator.Play(this.startAnim);
	}

	// Token: 0x04000D76 RID: 3446
	public string startAnim = string.Empty;

	// Token: 0x04000D77 RID: 3447
	public bool animateOnce;

	// Token: 0x04000D78 RID: 3448
	private bool allow = true;

	// Token: 0x04000D79 RID: 3449
	private Animator animator;
}
