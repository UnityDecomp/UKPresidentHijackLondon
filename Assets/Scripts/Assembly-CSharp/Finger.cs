using System;
using UnityEngine;

// Token: 0x020000F2 RID: 242
public class Finger
{
	// Token: 0x040005CC RID: 1484
	public int fingerIndex;

	// Token: 0x040005CD RID: 1485
	public int touchCount;

	// Token: 0x040005CE RID: 1486
	public Vector2 startPosition;

	// Token: 0x040005CF RID: 1487
	public Vector2 complexStartPosition;

	// Token: 0x040005D0 RID: 1488
	public Vector2 position;

	// Token: 0x040005D1 RID: 1489
	public Vector2 deltaPosition;

	// Token: 0x040005D2 RID: 1490
	public Vector2 oldPosition;

	// Token: 0x040005D3 RID: 1491
	public int tapCount;

	// Token: 0x040005D4 RID: 1492
	public float deltaTime;

	// Token: 0x040005D5 RID: 1493
	public TouchPhase phase;

	// Token: 0x040005D6 RID: 1494
	public EasyTouch.GestureType gesture;

	// Token: 0x040005D7 RID: 1495
	public GameObject pickedObject;
}
