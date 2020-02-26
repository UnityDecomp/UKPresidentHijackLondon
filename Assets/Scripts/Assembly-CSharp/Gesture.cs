using System;
using UnityEngine;

// Token: 0x020000F3 RID: 243
public class Gesture
{
	// Token: 0x060006DE RID: 1758 RVA: 0x0002D39F File Offset: 0x0002B79F
	public Vector3 GetTouchToWordlPoint(float z)
	{
		return EasyTouch.GetCamera().ScreenToWorldPoint(new Vector3(this.position.x, this.position.y, z));
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x0002D3C8 File Offset: 0x0002B7C8
	public float GetSwipeOrDragAngle()
	{
		return Mathf.Atan2(this.swipeVector.normalized.y, this.swipeVector.normalized.x) * 57.29578f;
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x0002D406 File Offset: 0x0002B806
	public bool IsInRect(Rect rect)
	{
		return rect.Contains(this.position);
	}

	// Token: 0x040005D8 RID: 1496
	public int fingerIndex;

	// Token: 0x040005D9 RID: 1497
	public int touchCount;

	// Token: 0x040005DA RID: 1498
	public Vector2 startPosition;

	// Token: 0x040005DB RID: 1499
	public Vector2 position;

	// Token: 0x040005DC RID: 1500
	public Vector2 deltaPosition;

	// Token: 0x040005DD RID: 1501
	public float actionTime;

	// Token: 0x040005DE RID: 1502
	public float deltaTime;

	// Token: 0x040005DF RID: 1503
	public EasyTouch.SwipeType swipe;

	// Token: 0x040005E0 RID: 1504
	public float swipeLength;

	// Token: 0x040005E1 RID: 1505
	public Vector2 swipeVector;

	// Token: 0x040005E2 RID: 1506
	public float deltaPinch;

	// Token: 0x040005E3 RID: 1507
	public float twistAngle;

	// Token: 0x040005E4 RID: 1508
	public GameObject pickObject;

	// Token: 0x040005E5 RID: 1509
	public GameObject otherReceiver;
}
