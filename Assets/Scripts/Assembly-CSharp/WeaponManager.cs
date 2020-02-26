using System;
using UnityEngine;

// Token: 0x0200021F RID: 543
public class WeaponManager : MonoBehaviour
{
	// Token: 0x04000EC3 RID: 3779
	public Transform attackPoint;

	// Token: 0x04000EC4 RID: 3780
	public WeaponManager.FireType fireType;

	// Token: 0x04000EC5 RID: 3781
	public int damage = 5;

	// Token: 0x04000EC6 RID: 3782
	public Transform muzzleFlash;

	// Token: 0x04000EC7 RID: 3783
	public GameObject attackPrefab;

	// Token: 0x04000EC8 RID: 3784
	public AudioClip shotSound;

	// Token: 0x04000EC9 RID: 3785
	public AnimationClip shotAnimation;

	// Token: 0x02000220 RID: 544
	public enum FireType
	{
		// Token: 0x04000ECB RID: 3787
		SingleShot,
		// Token: 0x04000ECC RID: 3788
		Burst
	}
}
