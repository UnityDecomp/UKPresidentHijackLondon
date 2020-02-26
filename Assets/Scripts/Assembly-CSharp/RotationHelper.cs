using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000FA RID: 250
public class RotationHelper : MonoBehaviour
{
	// Token: 0x060006FC RID: 1788 RVA: 0x0002DF35 File Offset: 0x0002C335
	private void Start()
	{
		base.transform.DORotate(new Vector3((float)this.rotation, 0f, 0f), this.duration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
	}

	// Token: 0x040005FD RID: 1533
	public float duration;

	// Token: 0x040005FE RID: 1534
	public int rotation;
}
