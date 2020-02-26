using System;
using UnityEngine;

// Token: 0x02000128 RID: 296
[Serializable]
public class TouchableControl
{
	// Token: 0x060007E8 RID: 2024 RVA: 0x000346E1 File Offset: 0x00032AE1
	public virtual void Init(TouchController joy)
	{
		this.joy = joy;
		this.visible = true;
		this.enabled = true;
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x000346F8 File Offset: 0x00032AF8
	public virtual TouchController.HitTestResult HitTest(Vector2 pos, int touchId)
	{
		return new TouchController.HitTestResult(false);
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x00034700 File Offset: 0x00032B00
	public virtual TouchController.EventResult OnTouchStart(int touchId, Vector2 pos)
	{
		return TouchController.EventResult.NOT_HANDLED;
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x00034703 File Offset: 0x00032B03
	public virtual TouchController.EventResult OnTouchEnd(int touchId, bool cancel = false)
	{
		return TouchController.EventResult.NOT_HANDLED;
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x00034706 File Offset: 0x00032B06
	public virtual TouchController.EventResult OnTouchMove(int touchId, Vector2 pos)
	{
		return TouchController.EventResult.NOT_HANDLED;
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x00034709 File Offset: 0x00032B09
	public virtual void OnReset()
	{
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x0003470B File Offset: 0x00032B0B
	public virtual void OnPrePoll()
	{
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x0003470D File Offset: 0x00032B0D
	public virtual void OnPostPoll()
	{
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x0003470F File Offset: 0x00032B0F
	public virtual void OnUpdate(bool firstPostPollUpdate)
	{
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00034711 File Offset: 0x00032B11
	public virtual void OnPostUpdate(bool firstPostPollUpdate)
	{
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00034713 File Offset: 0x00032B13
	public virtual void OnLayoutAddContent()
	{
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x00034715 File Offset: 0x00032B15
	public virtual void OnLayout()
	{
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x00034717 File Offset: 0x00032B17
	public virtual void DrawGUI()
	{
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x00034719 File Offset: 0x00032B19
	public virtual void ReleaseTouches()
	{
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x0003471B File Offset: 0x00032B1B
	public virtual void TakeoverTouches(TouchableControl controlToUntouch)
	{
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x0003471D File Offset: 0x00032B1D
	public virtual void ResetRect()
	{
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x0003471F File Offset: 0x00032B1F
	public void DisableGUI()
	{
		this.disableGui = true;
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x00034728 File Offset: 0x00032B28
	public void EnableGUI()
	{
		this.disableGui = false;
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x00034731 File Offset: 0x00032B31
	public bool DefaultGUIEnabled()
	{
		return !this.disableGui;
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x0003473C File Offset: 0x00032B3C
	public bool Enabled()
	{
		return this.enabled;
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x00034744 File Offset: 0x00032B44
	public virtual void Enable(bool skipAnimation)
	{
		this.enabled = true;
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x0003474D File Offset: 0x00032B4D
	public void Enable()
	{
		this.Enable(false);
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x00034756 File Offset: 0x00032B56
	public virtual void Disable(bool skipAnimation)
	{
		this.enabled = false;
		this.ReleaseTouches();
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x00034765 File Offset: 0x00032B65
	public void Disable()
	{
		this.Disable(false);
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x0003476E File Offset: 0x00032B6E
	public virtual void Show(bool skipAnim)
	{
		this.visible = true;
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x00034777 File Offset: 0x00032B77
	public void Show()
	{
		this.Show(false);
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x00034780 File Offset: 0x00032B80
	public virtual void Hide(bool skipAnim)
	{
		this.visible = false;
		this.ReleaseTouches();
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x0003478F File Offset: 0x00032B8F
	public void Hide()
	{
		this.Hide(false);
	}

	// Token: 0x040006E5 RID: 1765
	public bool initiallyDisabled;

	// Token: 0x040006E6 RID: 1766
	public bool initiallyHidden;

	// Token: 0x040006E7 RID: 1767
	protected bool enabled;

	// Token: 0x040006E8 RID: 1768
	protected bool visible;

	// Token: 0x040006E9 RID: 1769
	public int prio;

	// Token: 0x040006EA RID: 1770
	public float hitDistScale;

	// Token: 0x040006EB RID: 1771
	public string name;

	// Token: 0x040006EC RID: 1772
	public bool disableGui;

	// Token: 0x040006ED RID: 1773
	public int guiDepth;

	// Token: 0x040006EE RID: 1774
	public int layoutBoxId;

	// Token: 0x040006EF RID: 1775
	public bool acceptSharedTouches;

	// Token: 0x040006F0 RID: 1776
	protected TouchController joy;
}
