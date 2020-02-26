using System;
using UnityEngine;

// Token: 0x0200009E RID: 158
public class AnimationView : MonoBehaviour
{
	// Token: 0x060004A1 RID: 1185 RVA: 0x00024B64 File Offset: 0x00022F64
	private void Start()
	{
		this.clips = Resources.LoadAll<AnimationClip>("Animations/");
		Debug.Log("Clips loaded: " + this.clips.Length + base.gameObject.name);
		foreach (AnimationClip animationClip in this.clips)
		{
			base.GetComponent<Animation>().AddClip(animationClip, animationClip.name);
		}
		this.count = this.clips.Length;
		this.i = 0;
		base.GetComponent<Animation>().CrossFade(this.clips[this.i].name, this.fadeTime);
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x00024C14 File Offset: 0x00023014
	private void Update()
	{
		if (base.GetComponent<Animation>()[this.clips[this.i].name].time / base.GetComponent<Animation>()[this.clips[this.i].name].length > 0.9f)
		{
			this.i++;
			if (this.i >= this.count)
			{
				this.i = 0;
			}
			base.GetComponent<Animation>().CrossFade(this.clips[this.i].name, this.fadeTime);
		}
	}

	// Token: 0x040004C7 RID: 1223
	private AnimationClip[] clips;

	// Token: 0x040004C8 RID: 1224
	private int i;

	// Token: 0x040004C9 RID: 1225
	private int count;

	// Token: 0x040004CA RID: 1226
	public float fadeTime = 0.1f;
}
