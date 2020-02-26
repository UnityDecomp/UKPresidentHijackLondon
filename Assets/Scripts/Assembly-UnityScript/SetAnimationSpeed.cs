using System;
using UnityEngine;

// Token: 0x02000081 RID: 129
[Serializable]
public class SetAnimationSpeed : MonoBehaviour
{
	// Token: 0x060001B9 RID: 441 RVA: 0x000151E0 File Offset: 0x000133E0
	public SetAnimationSpeed()
	{
		this.animations = new AnimationClip[1];
		this.speed = 1.5f;
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00015200 File Offset: 0x00013400
	public virtual void Start()
	{
		if (!this.model)
		{
			MonoBehaviour.print("Please assign the model");
		}
		else
		{
			for (int i = 0; i < this.animations.Length; i++)
			{
				this.model.GetComponent<Animation>()[this.animations[i].name].speed = this.speed;
			}
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00015270 File Offset: 0x00013470
	public virtual void Main()
	{
	}

	// Token: 0x040002DC RID: 732
	public GameObject model;

	// Token: 0x040002DD RID: 733
	public AnimationClip[] animations;

	// Token: 0x040002DE RID: 734
	public float speed;
}
