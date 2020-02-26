using System;
using UnityEngine;

// Token: 0x02000150 RID: 336
public class NGUISoundPlay : MonoBehaviour
{
	// Token: 0x06000A56 RID: 2646 RVA: 0x0003ED98 File Offset: 0x0003D198
	private void OnHover(bool isOver)
	{
		if (!base.enabled || (isOver && this.trigger == NGUISoundPlay.Trigger.OnMouseOver) || isOver || this.trigger == NGUISoundPlay.Trigger.OnMouseOut)
		{
		}
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x0003EDC9 File Offset: 0x0003D1C9
	private void OnPress(bool isPressed)
	{
		if (!base.enabled || (isPressed && this.trigger == NGUISoundPlay.Trigger.OnPress) || isPressed || this.trigger == NGUISoundPlay.Trigger.OnRelease)
		{
		}
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x0003EDFA File Offset: 0x0003D1FA
	private void OnClick()
	{
		if (!base.enabled || this.trigger == NGUISoundPlay.Trigger.OnClick)
		{
		}
	}

	// Token: 0x0400096E RID: 2414
	public AudioClip audioClip;

	// Token: 0x0400096F RID: 2415
	public NGUISoundPlay.Trigger trigger;

	// Token: 0x04000970 RID: 2416
	[Range(0f, 1f)]
	public float volume = 1f;

	// Token: 0x04000971 RID: 2417
	[Range(0f, 2f)]
	public float pitch = 1f;

	// Token: 0x02000151 RID: 337
	public enum Trigger
	{
		// Token: 0x04000973 RID: 2419
		OnClick,
		// Token: 0x04000974 RID: 2420
		OnMouseOver,
		// Token: 0x04000975 RID: 2421
		OnMouseOut,
		// Token: 0x04000976 RID: 2422
		OnPress,
		// Token: 0x04000977 RID: 2423
		OnRelease
	}
}
