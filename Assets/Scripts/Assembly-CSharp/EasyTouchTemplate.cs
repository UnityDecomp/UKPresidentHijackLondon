using System;
using UnityEngine;

// Token: 0x020000F1 RID: 241
public class EasyTouchTemplate : MonoBehaviour
{
	// Token: 0x060006B7 RID: 1719 RVA: 0x0002CC5C File Offset: 0x0002B05C
	private void OnEnable()
	{
		EasyTouch.On_Cancel += this.On_Cancel;
		EasyTouch.On_TouchStart += this.On_TouchStart;
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchUp += this.On_TouchUp;
		EasyTouch.On_SimpleTap += this.On_SimpleTap;
		EasyTouch.On_DoubleTap += this.On_DoubleTap;
		EasyTouch.On_LongTapStart += this.On_LongTapStart;
		EasyTouch.On_LongTap += this.On_LongTap;
		EasyTouch.On_LongTapEnd += this.On_LongTapEnd;
		EasyTouch.On_DragStart += this.On_DragStart;
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_DragEnd += this.On_DragEnd;
		EasyTouch.On_SwipeStart += this.On_SwipeStart;
		EasyTouch.On_Swipe += this.On_Swipe;
		EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers += this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers += this.On_TouchUp2Fingers;
		EasyTouch.On_SimpleTap2Fingers += this.On_SimpleTap2Fingers;
		EasyTouch.On_DoubleTap2Fingers += this.On_DoubleTap2Fingers;
		EasyTouch.On_LongTapStart2Fingers += this.On_LongTapStart2Fingers;
		EasyTouch.On_LongTap2Fingers += this.On_LongTap2Fingers;
		EasyTouch.On_LongTapEnd2Fingers += this.On_LongTapEnd2Fingers;
		EasyTouch.On_Twist += this.On_Twist;
		EasyTouch.On_TwistEnd += this.On_TwistEnd;
		EasyTouch.On_PinchIn += this.On_PinchIn;
		EasyTouch.On_PinchOut += this.On_PinchOut;
		EasyTouch.On_PinchEnd += this.On_PinchEnd;
		EasyTouch.On_DragStart2Fingers += this.On_DragStart2Fingers;
		EasyTouch.On_Drag2Fingers += this.On_Drag2Fingers;
		EasyTouch.On_DragEnd2Fingers += this.On_DragEnd2Fingers;
		EasyTouch.On_SwipeStart2Fingers += this.On_SwipeStart2Fingers;
		EasyTouch.On_Swipe2Fingers += this.On_Swipe2Fingers;
		EasyTouch.On_SwipeEnd2Fingers += this.On_SwipeEnd2Fingers;
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x0002CEAC File Offset: 0x0002B2AC
	private void OnDisable()
	{
		EasyTouch.On_Cancel -= this.On_Cancel;
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_SimpleTap -= this.On_SimpleTap;
		EasyTouch.On_DoubleTap -= this.On_DoubleTap;
		EasyTouch.On_LongTapStart -= this.On_LongTapStart;
		EasyTouch.On_LongTap -= this.On_LongTap;
		EasyTouch.On_LongTapEnd -= this.On_LongTapEnd;
		EasyTouch.On_DragStart -= this.On_DragStart;
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_DragEnd -= this.On_DragEnd;
		EasyTouch.On_SwipeStart -= this.On_SwipeStart;
		EasyTouch.On_Swipe -= this.On_Swipe;
		EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers -= this.On_TouchUp2Fingers;
		EasyTouch.On_SimpleTap2Fingers -= this.On_SimpleTap2Fingers;
		EasyTouch.On_DoubleTap2Fingers -= this.On_DoubleTap2Fingers;
		EasyTouch.On_LongTapStart2Fingers -= this.On_LongTapStart2Fingers;
		EasyTouch.On_LongTap2Fingers -= this.On_LongTap2Fingers;
		EasyTouch.On_LongTapEnd2Fingers -= this.On_LongTapEnd2Fingers;
		EasyTouch.On_Twist -= this.On_Twist;
		EasyTouch.On_TwistEnd -= this.On_TwistEnd;
		EasyTouch.On_PinchIn -= this.On_PinchIn;
		EasyTouch.On_PinchOut -= this.On_PinchOut;
		EasyTouch.On_PinchEnd -= this.On_PinchEnd;
		EasyTouch.On_DragStart2Fingers -= this.On_DragStart2Fingers;
		EasyTouch.On_Drag2Fingers -= this.On_Drag2Fingers;
		EasyTouch.On_DragEnd2Fingers -= this.On_DragEnd2Fingers;
		EasyTouch.On_SwipeStart2Fingers -= this.On_SwipeStart2Fingers;
		EasyTouch.On_Swipe2Fingers -= this.On_Swipe2Fingers;
		EasyTouch.On_SwipeEnd2Fingers -= this.On_SwipeEnd2Fingers;
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x0002D0FC File Offset: 0x0002B4FC
	private void OnDestroy()
	{
		EasyTouch.On_Cancel -= this.On_Cancel;
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_SimpleTap -= this.On_SimpleTap;
		EasyTouch.On_DoubleTap -= this.On_DoubleTap;
		EasyTouch.On_LongTapStart -= this.On_LongTapStart;
		EasyTouch.On_LongTap -= this.On_LongTap;
		EasyTouch.On_LongTapEnd -= this.On_LongTapEnd;
		EasyTouch.On_DragStart -= this.On_DragStart;
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_DragEnd -= this.On_DragEnd;
		EasyTouch.On_SwipeStart -= this.On_SwipeStart;
		EasyTouch.On_Swipe -= this.On_Swipe;
		EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers -= this.On_TouchUp2Fingers;
		EasyTouch.On_SimpleTap2Fingers -= this.On_SimpleTap2Fingers;
		EasyTouch.On_DoubleTap2Fingers -= this.On_DoubleTap2Fingers;
		EasyTouch.On_LongTapStart2Fingers -= this.On_LongTapStart2Fingers;
		EasyTouch.On_LongTap2Fingers -= this.On_LongTap2Fingers;
		EasyTouch.On_LongTapEnd2Fingers -= this.On_LongTapEnd2Fingers;
		EasyTouch.On_Twist -= this.On_Twist;
		EasyTouch.On_TwistEnd -= this.On_TwistEnd;
		EasyTouch.On_PinchIn -= this.On_PinchIn;
		EasyTouch.On_PinchOut -= this.On_PinchOut;
		EasyTouch.On_PinchEnd -= this.On_PinchEnd;
		EasyTouch.On_DragStart2Fingers -= this.On_DragStart2Fingers;
		EasyTouch.On_Drag2Fingers -= this.On_Drag2Fingers;
		EasyTouch.On_DragEnd2Fingers -= this.On_DragEnd2Fingers;
		EasyTouch.On_SwipeStart2Fingers -= this.On_SwipeStart2Fingers;
		EasyTouch.On_Swipe2Fingers -= this.On_Swipe2Fingers;
		EasyTouch.On_SwipeEnd2Fingers -= this.On_SwipeEnd2Fingers;
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x0002D34B File Offset: 0x0002B74B
	private void On_Cancel(Gesture gesture)
	{
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x0002D34D File Offset: 0x0002B74D
	private void On_TouchStart(Gesture gesture)
	{
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0002D34F File Offset: 0x0002B74F
	private void On_TouchDown(Gesture gesture)
	{
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x0002D351 File Offset: 0x0002B751
	private void On_TouchUp(Gesture gesture)
	{
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x0002D353 File Offset: 0x0002B753
	private void On_SimpleTap(Gesture gesture)
	{
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x0002D355 File Offset: 0x0002B755
	private void On_DoubleTap(Gesture gesture)
	{
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x0002D357 File Offset: 0x0002B757
	private void On_LongTapStart(Gesture gesture)
	{
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x0002D359 File Offset: 0x0002B759
	private void On_LongTap(Gesture gesture)
	{
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x0002D35B File Offset: 0x0002B75B
	private void On_LongTapEnd(Gesture gesture)
	{
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x0002D35D File Offset: 0x0002B75D
	private void On_DragStart(Gesture gesture)
	{
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x0002D35F File Offset: 0x0002B75F
	private void On_Drag(Gesture gesture)
	{
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x0002D361 File Offset: 0x0002B761
	private void On_DragEnd(Gesture gesture)
	{
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x0002D363 File Offset: 0x0002B763
	private void On_SwipeStart(Gesture gesture)
	{
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x0002D365 File Offset: 0x0002B765
	private void On_Swipe(Gesture gesture)
	{
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x0002D367 File Offset: 0x0002B767
	private void On_SwipeEnd(Gesture gesture)
	{
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x0002D369 File Offset: 0x0002B769
	private void On_TouchStart2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x0002D36B File Offset: 0x0002B76B
	private void On_TouchDown2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x0002D36D File Offset: 0x0002B76D
	private void On_TouchUp2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x0002D36F File Offset: 0x0002B76F
	private void On_SimpleTap2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x0002D371 File Offset: 0x0002B771
	private void On_DoubleTap2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x0002D373 File Offset: 0x0002B773
	private void On_LongTapStart2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x0002D375 File Offset: 0x0002B775
	private void On_LongTap2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x0002D377 File Offset: 0x0002B777
	private void On_LongTapEnd2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x0002D379 File Offset: 0x0002B779
	private void On_Twist(Gesture gesture)
	{
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0002D37B File Offset: 0x0002B77B
	private void On_TwistEnd(Gesture gesture)
	{
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x0002D37D File Offset: 0x0002B77D
	private void On_PinchIn(Gesture gesture)
	{
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0002D37F File Offset: 0x0002B77F
	private void On_PinchOut(Gesture gesture)
	{
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0002D381 File Offset: 0x0002B781
	private void On_PinchEnd(Gesture gesture)
	{
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0002D383 File Offset: 0x0002B783
	private void On_DragStart2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x0002D385 File Offset: 0x0002B785
	private void On_Drag2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0002D387 File Offset: 0x0002B787
	private void On_DragEnd2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0002D389 File Offset: 0x0002B789
	private void On_SwipeStart2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x0002D38B File Offset: 0x0002B78B
	private void On_Swipe2Fingers(Gesture gesture)
	{
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x0002D38D File Offset: 0x0002B78D
	private void On_SwipeEnd2Fingers(Gesture gesture)
	{
	}
}
