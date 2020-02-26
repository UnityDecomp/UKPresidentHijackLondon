using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class EasyTouch : MonoBehaviour
{
	// Token: 0x060005AC RID: 1452 RVA: 0x00029948 File Offset: 0x00027D48
	public EasyTouch()
	{
		this.enable = true;
		this.useBroadcastMessage = false;
		this.enable2FingersGesture = true;
		this.enableTwist = true;
		this.enablePinch = true;
		this.autoSelect = true;
		this.StationnaryTolerance = 25f;
		this.longTapTime = 1f;
		this.swipeTolerance = 0.85f;
		this.minPinchLength = 0f;
		this.minTwistAngle = 1f;
	}

	// Token: 0x1400006F RID: 111
	// (add) Token: 0x060005AD RID: 1453 RVA: 0x00029A4C File Offset: 0x00027E4C
	// (remove) Token: 0x060005AE RID: 1454 RVA: 0x00029A80 File Offset: 0x00027E80
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TouchCancelHandler On_Cancel;

	// Token: 0x14000070 RID: 112
	// (add) Token: 0x060005AF RID: 1455 RVA: 0x00029AB4 File Offset: 0x00027EB4
	// (remove) Token: 0x060005B0 RID: 1456 RVA: 0x00029AE8 File Offset: 0x00027EE8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.Cancel2FingersHandler On_Cancel2Fingers;

	// Token: 0x14000071 RID: 113
	// (add) Token: 0x060005B1 RID: 1457 RVA: 0x00029B1C File Offset: 0x00027F1C
	// (remove) Token: 0x060005B2 RID: 1458 RVA: 0x00029B50 File Offset: 0x00027F50
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TouchStartHandler On_TouchStart;

	// Token: 0x14000072 RID: 114
	// (add) Token: 0x060005B3 RID: 1459 RVA: 0x00029B84 File Offset: 0x00027F84
	// (remove) Token: 0x060005B4 RID: 1460 RVA: 0x00029BB8 File Offset: 0x00027FB8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TouchDownHandler On_TouchDown;

	// Token: 0x14000073 RID: 115
	// (add) Token: 0x060005B5 RID: 1461 RVA: 0x00029BEC File Offset: 0x00027FEC
	// (remove) Token: 0x060005B6 RID: 1462 RVA: 0x00029C20 File Offset: 0x00028020
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TouchUpHandler On_TouchUp;

	// Token: 0x14000074 RID: 116
	// (add) Token: 0x060005B7 RID: 1463 RVA: 0x00029C54 File Offset: 0x00028054
	// (remove) Token: 0x060005B8 RID: 1464 RVA: 0x00029C88 File Offset: 0x00028088
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.SimpleTapHandler On_SimpleTap;

	// Token: 0x14000075 RID: 117
	// (add) Token: 0x060005B9 RID: 1465 RVA: 0x00029CBC File Offset: 0x000280BC
	// (remove) Token: 0x060005BA RID: 1466 RVA: 0x00029CF0 File Offset: 0x000280F0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.DoubleTapHandler On_DoubleTap;

	// Token: 0x14000076 RID: 118
	// (add) Token: 0x060005BB RID: 1467 RVA: 0x00029D24 File Offset: 0x00028124
	// (remove) Token: 0x060005BC RID: 1468 RVA: 0x00029D58 File Offset: 0x00028158
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.LongTapStartHandler On_LongTapStart;

	// Token: 0x14000077 RID: 119
	// (add) Token: 0x060005BD RID: 1469 RVA: 0x00029D8C File Offset: 0x0002818C
	// (remove) Token: 0x060005BE RID: 1470 RVA: 0x00029DC0 File Offset: 0x000281C0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.LongTapHandler On_LongTap;

	// Token: 0x14000078 RID: 120
	// (add) Token: 0x060005BF RID: 1471 RVA: 0x00029DF4 File Offset: 0x000281F4
	// (remove) Token: 0x060005C0 RID: 1472 RVA: 0x00029E28 File Offset: 0x00028228
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.LongTapEndHandler On_LongTapEnd;

	// Token: 0x14000079 RID: 121
	// (add) Token: 0x060005C1 RID: 1473 RVA: 0x00029E5C File Offset: 0x0002825C
	// (remove) Token: 0x060005C2 RID: 1474 RVA: 0x00029E90 File Offset: 0x00028290
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.DragStartHandler On_DragStart;

	// Token: 0x1400007A RID: 122
	// (add) Token: 0x060005C3 RID: 1475 RVA: 0x00029EC4 File Offset: 0x000282C4
	// (remove) Token: 0x060005C4 RID: 1476 RVA: 0x00029EF8 File Offset: 0x000282F8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.DragHandler On_Drag;

	// Token: 0x1400007B RID: 123
	// (add) Token: 0x060005C5 RID: 1477 RVA: 0x00029F2C File Offset: 0x0002832C
	// (remove) Token: 0x060005C6 RID: 1478 RVA: 0x00029F60 File Offset: 0x00028360
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.DragEndHandler On_DragEnd;

	// Token: 0x1400007C RID: 124
	// (add) Token: 0x060005C7 RID: 1479 RVA: 0x00029F94 File Offset: 0x00028394
	// (remove) Token: 0x060005C8 RID: 1480 RVA: 0x00029FC8 File Offset: 0x000283C8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.SwipeStartHandler On_SwipeStart;

	// Token: 0x1400007D RID: 125
	// (add) Token: 0x060005C9 RID: 1481 RVA: 0x00029FFC File Offset: 0x000283FC
	// (remove) Token: 0x060005CA RID: 1482 RVA: 0x0002A030 File Offset: 0x00028430
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.SwipeHandler On_Swipe;

	// Token: 0x1400007E RID: 126
	// (add) Token: 0x060005CB RID: 1483 RVA: 0x0002A064 File Offset: 0x00028464
	// (remove) Token: 0x060005CC RID: 1484 RVA: 0x0002A098 File Offset: 0x00028498
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.SwipeEndHandler On_SwipeEnd;

	// Token: 0x1400007F RID: 127
	// (add) Token: 0x060005CD RID: 1485 RVA: 0x0002A0CC File Offset: 0x000284CC
	// (remove) Token: 0x060005CE RID: 1486 RVA: 0x0002A100 File Offset: 0x00028500
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TouchStart2FingersHandler On_TouchStart2Fingers;

	// Token: 0x14000080 RID: 128
	// (add) Token: 0x060005CF RID: 1487 RVA: 0x0002A134 File Offset: 0x00028534
	// (remove) Token: 0x060005D0 RID: 1488 RVA: 0x0002A168 File Offset: 0x00028568
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TouchDown2FingersHandler On_TouchDown2Fingers;

	// Token: 0x14000081 RID: 129
	// (add) Token: 0x060005D1 RID: 1489 RVA: 0x0002A19C File Offset: 0x0002859C
	// (remove) Token: 0x060005D2 RID: 1490 RVA: 0x0002A1D0 File Offset: 0x000285D0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TouchUp2FingersHandler On_TouchUp2Fingers;

	// Token: 0x14000082 RID: 130
	// (add) Token: 0x060005D3 RID: 1491 RVA: 0x0002A204 File Offset: 0x00028604
	// (remove) Token: 0x060005D4 RID: 1492 RVA: 0x0002A238 File Offset: 0x00028638
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.SimpleTap2FingersHandler On_SimpleTap2Fingers;

	// Token: 0x14000083 RID: 131
	// (add) Token: 0x060005D5 RID: 1493 RVA: 0x0002A26C File Offset: 0x0002866C
	// (remove) Token: 0x060005D6 RID: 1494 RVA: 0x0002A2A0 File Offset: 0x000286A0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.DoubleTap2FingersHandler On_DoubleTap2Fingers;

	// Token: 0x14000084 RID: 132
	// (add) Token: 0x060005D7 RID: 1495 RVA: 0x0002A2D4 File Offset: 0x000286D4
	// (remove) Token: 0x060005D8 RID: 1496 RVA: 0x0002A308 File Offset: 0x00028708
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.LongTapStart2FingersHandler On_LongTapStart2Fingers;

	// Token: 0x14000085 RID: 133
	// (add) Token: 0x060005D9 RID: 1497 RVA: 0x0002A33C File Offset: 0x0002873C
	// (remove) Token: 0x060005DA RID: 1498 RVA: 0x0002A370 File Offset: 0x00028770
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.LongTap2FingersHandler On_LongTap2Fingers;

	// Token: 0x14000086 RID: 134
	// (add) Token: 0x060005DB RID: 1499 RVA: 0x0002A3A4 File Offset: 0x000287A4
	// (remove) Token: 0x060005DC RID: 1500 RVA: 0x0002A3D8 File Offset: 0x000287D8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.LongTapEnd2FingersHandler On_LongTapEnd2Fingers;

	// Token: 0x14000087 RID: 135
	// (add) Token: 0x060005DD RID: 1501 RVA: 0x0002A40C File Offset: 0x0002880C
	// (remove) Token: 0x060005DE RID: 1502 RVA: 0x0002A440 File Offset: 0x00028840
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TwistHandler On_Twist;

	// Token: 0x14000088 RID: 136
	// (add) Token: 0x060005DF RID: 1503 RVA: 0x0002A474 File Offset: 0x00028874
	// (remove) Token: 0x060005E0 RID: 1504 RVA: 0x0002A4A8 File Offset: 0x000288A8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.TwistEndHandler On_TwistEnd;

	// Token: 0x14000089 RID: 137
	// (add) Token: 0x060005E1 RID: 1505 RVA: 0x0002A4DC File Offset: 0x000288DC
	// (remove) Token: 0x060005E2 RID: 1506 RVA: 0x0002A510 File Offset: 0x00028910
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.PinchInHandler On_PinchIn;

	// Token: 0x1400008A RID: 138
	// (add) Token: 0x060005E3 RID: 1507 RVA: 0x0002A544 File Offset: 0x00028944
	// (remove) Token: 0x060005E4 RID: 1508 RVA: 0x0002A578 File Offset: 0x00028978
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.PinchOutHandler On_PinchOut;

	// Token: 0x1400008B RID: 139
	// (add) Token: 0x060005E5 RID: 1509 RVA: 0x0002A5AC File Offset: 0x000289AC
	// (remove) Token: 0x060005E6 RID: 1510 RVA: 0x0002A5E0 File Offset: 0x000289E0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.PinchEndHandler On_PinchEnd;

	// Token: 0x1400008C RID: 140
	// (add) Token: 0x060005E7 RID: 1511 RVA: 0x0002A614 File Offset: 0x00028A14
	// (remove) Token: 0x060005E8 RID: 1512 RVA: 0x0002A648 File Offset: 0x00028A48
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.DragStart2FingersHandler On_DragStart2Fingers;

	// Token: 0x1400008D RID: 141
	// (add) Token: 0x060005E9 RID: 1513 RVA: 0x0002A67C File Offset: 0x00028A7C
	// (remove) Token: 0x060005EA RID: 1514 RVA: 0x0002A6B0 File Offset: 0x00028AB0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.Drag2FingersHandler On_Drag2Fingers;

	// Token: 0x1400008E RID: 142
	// (add) Token: 0x060005EB RID: 1515 RVA: 0x0002A6E4 File Offset: 0x00028AE4
	// (remove) Token: 0x060005EC RID: 1516 RVA: 0x0002A718 File Offset: 0x00028B18
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.DragEnd2FingersHandler On_DragEnd2Fingers;

	// Token: 0x1400008F RID: 143
	// (add) Token: 0x060005ED RID: 1517 RVA: 0x0002A74C File Offset: 0x00028B4C
	// (remove) Token: 0x060005EE RID: 1518 RVA: 0x0002A780 File Offset: 0x00028B80
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.SwipeStart2FingersHandler On_SwipeStart2Fingers;

	// Token: 0x14000090 RID: 144
	// (add) Token: 0x060005EF RID: 1519 RVA: 0x0002A7B4 File Offset: 0x00028BB4
	// (remove) Token: 0x060005F0 RID: 1520 RVA: 0x0002A7E8 File Offset: 0x00028BE8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.Swipe2FingersHandler On_Swipe2Fingers;

	// Token: 0x14000091 RID: 145
	// (add) Token: 0x060005F1 RID: 1521 RVA: 0x0002A81C File Offset: 0x00028C1C
	// (remove) Token: 0x060005F2 RID: 1522 RVA: 0x0002A850 File Offset: 0x00028C50
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event EasyTouch.SwipeEnd2FingersHandler On_SwipeEnd2Fingers;

	// Token: 0x060005F3 RID: 1523 RVA: 0x0002A884 File Offset: 0x00028C84
	private void OnEnable()
	{
		if (Application.isPlaying && Application.isEditor)
		{
			this.InitEasyTouch();
		}
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x0002A8A0 File Offset: 0x00028CA0
	private void Start()
	{
		this.InitEasyTouch();
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x0002A8A8 File Offset: 0x00028CA8
	private void InitEasyTouch()
	{
		this.input = new EasyTouchInput();
		if (EasyTouch.instance == null)
		{
			EasyTouch.instance = this;
		}
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x0002A8CB File Offset: 0x00028CCB
	private void OnGUI()
	{
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x0002A8CD File Offset: 0x00028CCD
	private void OnDrawGizmos()
	{
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x0002A8D0 File Offset: 0x00028CD0
	private void Update()
	{
		if (this.enable && EasyTouch.instance == this)
		{
			int num = this.input.TouchCount();
			if (this.oldTouchCount == 2 && num != 2 && num > 0)
			{
				this.CreateGesture2Finger(EasyTouch.EventName.On_Cancel2Fingers, Vector2.zero, Vector2.zero, Vector2.zero, 0f, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
			}
			this.UpdateTouches(true, num);
			this.oldPickObject2Finger = this.pickObject2Finger;
			if (this.enable2FingersGesture)
			{
				if (num == 2)
				{
					this.TwoFinger();
				}
				else
				{
					this.complexCurrentGesture = EasyTouch.GestureType.None;
					this.pickObject2Finger = null;
					this.twoFingerSwipeStart = false;
					this.twoFingerDragStart = false;
				}
			}
			for (int i = 0; i < 100; i++)
			{
				if (this.fingers[i] != null)
				{
					this.OneFinger(i);
				}
				else
				{
					this.fingers[i] = null;
				}
			}
			this.oldTouchCount = num;
		}
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x0002A9D8 File Offset: 0x00028DD8
	private void UpdateTouches(bool realTouch, int touchCount)
	{
		if (realTouch || this.enableRemote)
		{
			foreach (Touch touch in Input.touches)
			{
				if (this.fingers[touch.fingerId] == null)
				{
					this.fingers[touch.fingerId] = new Finger();
					this.fingers[touch.fingerId].fingerIndex = touch.fingerId;
					this.fingers[touch.fingerId].gesture = EasyTouch.GestureType.None;
				}
				this.fingers[touch.fingerId].position = touch.position;
				this.fingers[touch.fingerId].deltaPosition = touch.deltaPosition;
				this.fingers[touch.fingerId].tapCount = touch.tapCount;
				this.fingers[touch.fingerId].deltaTime = touch.deltaTime;
				this.fingers[touch.fingerId].phase = touch.phase;
				this.fingers[touch.fingerId].touchCount = touchCount;
			}
		}
		else
		{
			for (int j = 0; j < touchCount; j++)
			{
				this.fingers[j] = this.input.GetMouseTouch(j, this.fingers[j]);
				this.fingers[j].touchCount = touchCount;
			}
		}
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x0002AB48 File Offset: 0x00028F48
	private void OneFinger(int fingerIndex)
	{
		if (this.fingers[fingerIndex].gesture == EasyTouch.GestureType.None)
		{
			this.startTimeAction = Time.time;
			this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Tap;
			this.fingers[fingerIndex].startPosition = this.fingers[fingerIndex].position;
			if (this.autoSelect)
			{
				this.fingers[fingerIndex].pickedObject = this.GetPickeGameObject(this.fingers[fingerIndex].startPosition);
			}
			this.CreateGesture(EasyTouch.EventName.On_TouchStart, this.fingers[fingerIndex], 0f, EasyTouch.SwipeType.None, 0f, Vector2.zero);
		}
		float num = Time.time - this.startTimeAction;
		if (this.fingers[fingerIndex].phase == TouchPhase.Canceled)
		{
			this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Cancel;
		}
		if (this.fingers[fingerIndex].phase != TouchPhase.Ended && this.fingers[fingerIndex].phase != TouchPhase.Canceled)
		{
			if (this.fingers[fingerIndex].phase == TouchPhase.Stationary && num >= this.longTapTime && this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Tap)
			{
				this.fingers[fingerIndex].gesture = EasyTouch.GestureType.LongTap;
				this.CreateGesture(EasyTouch.EventName.On_LongTapStart, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
			}
			if ((this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Tap || this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap) && !this.FingerInTolerance(this.fingers[fingerIndex]))
			{
				if (this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap)
				{
					this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Cancel;
					this.CreateGesture(EasyTouch.EventName.On_LongTapEnd, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
				}
				else if (this.fingers[fingerIndex].pickedObject)
				{
					this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Drag;
					this.CreateGesture(EasyTouch.EventName.On_DragStart, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
				}
				else
				{
					this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Swipe;
					this.CreateGesture(EasyTouch.EventName.On_SwipeStart, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
				}
			}
			EasyTouch.EventName eventName = EasyTouch.EventName.None;
			EasyTouch.GestureType gesture = this.fingers[fingerIndex].gesture;
			if (gesture != EasyTouch.GestureType.LongTap)
			{
				if (gesture != EasyTouch.GestureType.Drag)
				{
					if (gesture == EasyTouch.GestureType.Swipe)
					{
						eventName = EasyTouch.EventName.On_Swipe;
					}
				}
				else
				{
					eventName = EasyTouch.EventName.On_Drag;
				}
			}
			else
			{
				eventName = EasyTouch.EventName.On_LongTap;
			}
			EasyTouch.SwipeType swipe = EasyTouch.SwipeType.None;
			if (eventName != EasyTouch.EventName.None)
			{
				swipe = this.GetSwipe(new Vector2(0f, 0f), this.fingers[fingerIndex].deltaPosition);
				this.CreateGesture(eventName, this.fingers[fingerIndex], num, swipe, 0f, this.fingers[fingerIndex].deltaPosition);
			}
			this.CreateGesture(EasyTouch.EventName.On_TouchDown, this.fingers[fingerIndex], num, swipe, 0f, this.fingers[fingerIndex].deltaPosition);
		}
		else
		{
			switch (this.fingers[fingerIndex].gesture)
			{
			case EasyTouch.GestureType.Tap:
				if (this.fingers[fingerIndex].tapCount < 2)
				{
					this.CreateGesture(EasyTouch.EventName.On_SimpleTap, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
				}
				else
				{
					this.CreateGesture(EasyTouch.EventName.On_DoubleTap, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
				}
				break;
			case EasyTouch.GestureType.Drag:
				this.CreateGesture(EasyTouch.EventName.On_DragEnd, this.fingers[fingerIndex], num, this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].startPosition - this.fingers[fingerIndex].position).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
				break;
			case EasyTouch.GestureType.Swipe:
				this.CreateGesture(EasyTouch.EventName.On_SwipeEnd, this.fingers[fingerIndex], num, this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
				break;
			case EasyTouch.GestureType.LongTap:
				this.CreateGesture(EasyTouch.EventName.On_LongTapEnd, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
				break;
			case EasyTouch.GestureType.Cancel:
				this.CreateGesture(EasyTouch.EventName.On_Cancel, this.fingers[fingerIndex], 0f, EasyTouch.SwipeType.None, 0f, Vector2.zero);
				break;
			}
			this.CreateGesture(EasyTouch.EventName.On_TouchUp, this.fingers[fingerIndex], num, EasyTouch.SwipeType.None, 0f, Vector2.zero);
			this.fingers[fingerIndex] = null;
		}
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x0002B03C File Offset: 0x0002943C
	private bool CreateGesture(EasyTouch.EventName message, Finger finger, float actionTime, EasyTouch.SwipeType swipe, float swipeLength, Vector2 swipeVector)
	{
		Gesture gesture = new Gesture();
		gesture.fingerIndex = finger.fingerIndex;
		gesture.touchCount = finger.touchCount;
		gesture.startPosition = finger.startPosition;
		gesture.position = finger.position;
		gesture.deltaPosition = finger.deltaPosition;
		gesture.actionTime = actionTime;
		gesture.deltaTime = finger.deltaTime;
		gesture.swipe = swipe;
		gesture.swipeLength = swipeLength;
		gesture.swipeVector = swipeVector;
		gesture.deltaPinch = 0f;
		gesture.twistAngle = 0f;
		gesture.pickObject = finger.pickedObject;
		gesture.otherReceiver = this.receiverObject;
		if (this.useBroadcastMessage)
		{
			this.SendGesture(message, gesture);
		}
		if (!this.useBroadcastMessage || this.joystickAddon)
		{
			this.RaiseEvent(message, gesture);
		}
		return true;
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x0002B118 File Offset: 0x00029518
	private void SendGesture(EasyTouch.EventName message, Gesture gesture)
	{
		if (this.useBroadcastMessage)
		{
			if (this.receiverObject != null && this.receiverObject != gesture.pickObject)
			{
				this.receiverObject.SendMessage(message.ToString(), gesture, SendMessageOptions.DontRequireReceiver);
			}
			if (gesture.pickObject)
			{
				gesture.pickObject.SendMessage(message.ToString(), gesture, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				base.SendMessage(message.ToString(), gesture, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x0002B1B8 File Offset: 0x000295B8
	private void TwoFinger()
	{
		float num = 0f;
		Vector2 zero = Vector2.zero;
		Vector2 vector = Vector2.zero;
		if (this.complexCurrentGesture == EasyTouch.GestureType.None)
		{
			this.twoFinger0 = this.GetTwoFinger(-1);
			this.twoFinger1 = this.GetTwoFinger(this.twoFinger0);
			this.startTimeAction = Time.time;
			this.complexCurrentGesture = EasyTouch.GestureType.Tap;
			this.fingers[this.twoFinger0].complexStartPosition = this.fingers[this.twoFinger0].position;
			this.fingers[this.twoFinger1].complexStartPosition = this.fingers[this.twoFinger1].position;
			this.fingers[this.twoFinger0].oldPosition = this.fingers[this.twoFinger0].position;
			this.fingers[this.twoFinger1].oldPosition = this.fingers[this.twoFinger1].position;
			this.oldFingerDistance = Mathf.Abs(Vector2.Distance(this.fingers[this.twoFinger0].position, this.fingers[this.twoFinger1].position));
			this.startPosition2Finger = new Vector2((this.fingers[this.twoFinger0].position.x + this.fingers[this.twoFinger1].position.x) / 2f, (this.fingers[this.twoFinger0].position.y + this.fingers[this.twoFinger1].position.y) / 2f);
			vector = Vector2.zero;
			if (this.autoSelect)
			{
				this.pickObject2Finger = this.GetPickeGameObject(this.fingers[this.twoFinger0].complexStartPosition);
				if (this.pickObject2Finger != this.GetPickeGameObject(this.fingers[this.twoFinger1].complexStartPosition))
				{
					this.pickObject2Finger = null;
				}
			}
			this.CreateGesture2Finger(EasyTouch.EventName.On_TouchStart2Fingers, this.startPosition2Finger, this.startPosition2Finger, vector, num, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
		}
		num = Time.time - this.startTimeAction;
		zero = new Vector2((this.fingers[this.twoFinger0].position.x + this.fingers[this.twoFinger1].position.x) / 2f, (this.fingers[this.twoFinger0].position.y + this.fingers[this.twoFinger1].position.y) / 2f);
		vector = zero - this.oldStartPosition2Finger;
		float num2 = Mathf.Abs(Vector2.Distance(this.fingers[this.twoFinger0].position, this.fingers[this.twoFinger1].position));
		if (this.fingers[this.twoFinger0].phase == TouchPhase.Canceled || this.fingers[this.twoFinger1].phase == TouchPhase.Canceled)
		{
			this.complexCurrentGesture = EasyTouch.GestureType.Cancel;
		}
		if (this.fingers[this.twoFinger0].phase != TouchPhase.Ended && this.fingers[this.twoFinger1].phase != TouchPhase.Ended && this.complexCurrentGesture != EasyTouch.GestureType.Cancel)
		{
			if (this.complexCurrentGesture == EasyTouch.GestureType.Tap && num >= this.longTapTime && this.FingerInTolerance(this.fingers[this.twoFinger0]) && this.FingerInTolerance(this.fingers[this.twoFinger1]))
			{
				this.complexCurrentGesture = EasyTouch.GestureType.LongTap;
				this.CreateGesture2Finger(EasyTouch.EventName.On_LongTapStart2Fingers, this.startPosition2Finger, zero, vector, num, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
			}
			bool flag = true;
			if (flag)
			{
				float num3 = Vector2.Dot(this.fingers[this.twoFinger0].deltaPosition.normalized, this.fingers[this.twoFinger1].deltaPosition.normalized);
				if (this.enablePinch && num2 != this.oldFingerDistance)
				{
					if (Mathf.Abs(num2 - this.oldFingerDistance) >= this.minPinchLength)
					{
						this.complexCurrentGesture = EasyTouch.GestureType.Pinch;
					}
					if (this.complexCurrentGesture == EasyTouch.GestureType.Pinch)
					{
						if (num2 < this.oldFingerDistance)
						{
							if (this.oldGesture != EasyTouch.GestureType.Pinch)
							{
								this.CreateStateEnd2Fingers(this.oldGesture, this.startPosition2Finger, zero, vector, num, false);
								this.startTimeAction = Time.time;
							}
							this.CreateGesture2Finger(EasyTouch.EventName.On_PinchIn, this.startPosition2Finger, zero, vector, num, this.GetSwipe(this.fingers[this.twoFinger0].complexStartPosition, this.fingers[this.twoFinger0].position), 0f, Vector2.zero, 0f, Mathf.Abs(num2 - this.oldFingerDistance));
							this.complexCurrentGesture = EasyTouch.GestureType.Pinch;
						}
						else if (num2 > this.oldFingerDistance)
						{
							if (this.oldGesture != EasyTouch.GestureType.Pinch)
							{
								this.CreateStateEnd2Fingers(this.oldGesture, this.startPosition2Finger, zero, vector, num, false);
								this.startTimeAction = Time.time;
							}
							this.CreateGesture2Finger(EasyTouch.EventName.On_PinchOut, this.startPosition2Finger, zero, vector, num, this.GetSwipe(this.fingers[this.twoFinger0].complexStartPosition, this.fingers[this.twoFinger0].position), 0f, Vector2.zero, 0f, Mathf.Abs(num2 - this.oldFingerDistance));
							this.complexCurrentGesture = EasyTouch.GestureType.Pinch;
						}
					}
				}
				if (this.enableTwist)
				{
					if (Mathf.Abs(this.TwistAngle()) > this.minTwistAngle)
					{
						if (this.complexCurrentGesture != EasyTouch.GestureType.Twist)
						{
							this.CreateStateEnd2Fingers(this.complexCurrentGesture, this.startPosition2Finger, zero, vector, num, false);
							this.startTimeAction = Time.time;
						}
						this.complexCurrentGesture = EasyTouch.GestureType.Twist;
					}
					if (this.complexCurrentGesture == EasyTouch.GestureType.Twist)
					{
						this.CreateGesture2Finger(EasyTouch.EventName.On_Twist, this.startPosition2Finger, zero, vector, num, EasyTouch.SwipeType.None, 0f, Vector2.zero, this.TwistAngle(), 0f);
					}
					this.fingers[this.twoFinger0].oldPosition = this.fingers[this.twoFinger0].position;
					this.fingers[this.twoFinger1].oldPosition = this.fingers[this.twoFinger1].position;
				}
				if (num3 > 0f)
				{
					if (this.pickObject2Finger && !this.twoFingerDragStart)
					{
						if (this.complexCurrentGesture != EasyTouch.GestureType.Tap)
						{
							this.CreateStateEnd2Fingers(this.complexCurrentGesture, this.startPosition2Finger, zero, vector, num, false);
							this.startTimeAction = Time.time;
						}
						this.CreateGesture2Finger(EasyTouch.EventName.On_DragStart2Fingers, this.startPosition2Finger, zero, vector, num, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
						this.twoFingerDragStart = true;
					}
					else if (!this.pickObject2Finger && !this.twoFingerSwipeStart)
					{
						if (this.complexCurrentGesture != EasyTouch.GestureType.Tap)
						{
							this.CreateStateEnd2Fingers(this.complexCurrentGesture, this.startPosition2Finger, zero, vector, num, false);
							this.startTimeAction = Time.time;
						}
						this.CreateGesture2Finger(EasyTouch.EventName.On_SwipeStart2Fingers, this.startPosition2Finger, zero, vector, num, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
						this.twoFingerSwipeStart = true;
					}
				}
				else if (num3 < 0f)
				{
					this.twoFingerDragStart = false;
					this.twoFingerSwipeStart = false;
				}
				if (this.twoFingerDragStart)
				{
					this.CreateGesture2Finger(EasyTouch.EventName.On_Drag2Fingers, this.startPosition2Finger, zero, vector, num, this.GetSwipe(this.oldStartPosition2Finger, zero), 0f, vector, 0f, 0f);
				}
				if (this.twoFingerSwipeStart)
				{
					this.CreateGesture2Finger(EasyTouch.EventName.On_Swipe2Fingers, this.startPosition2Finger, zero, vector, num, this.GetSwipe(this.oldStartPosition2Finger, zero), 0f, vector, 0f, 0f);
				}
			}
			else if (this.complexCurrentGesture == EasyTouch.GestureType.LongTap)
			{
				this.CreateGesture2Finger(EasyTouch.EventName.On_LongTap2Fingers, this.startPosition2Finger, zero, vector, num, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
			}
			this.CreateGesture2Finger(EasyTouch.EventName.On_TouchDown2Fingers, this.startPosition2Finger, zero, vector, num, this.GetSwipe(this.oldStartPosition2Finger, zero), 0f, vector, 0f, 0f);
			this.oldFingerDistance = num2;
			this.oldStartPosition2Finger = zero;
			this.oldGesture = this.complexCurrentGesture;
		}
		else
		{
			this.CreateStateEnd2Fingers(this.complexCurrentGesture, this.startPosition2Finger, zero, vector, num, true);
			this.complexCurrentGesture = EasyTouch.GestureType.None;
			this.pickObject2Finger = null;
			this.twoFingerSwipeStart = false;
			this.twoFingerDragStart = false;
		}
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x0002BA4C File Offset: 0x00029E4C
	private int GetTwoFinger(int index)
	{
		int num = index + 1;
		bool flag = false;
		while (num < 100 && !flag)
		{
			if (this.fingers[num] != null && num >= index)
			{
				flag = true;
			}
			num++;
		}
		return num - 1;
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x0002BA94 File Offset: 0x00029E94
	private void CreateStateEnd2Fingers(EasyTouch.GestureType gesture, Vector2 startPosition, Vector2 position, Vector2 deltaPosition, float time, bool realEnd)
	{
		switch (gesture)
		{
		case EasyTouch.GestureType.LongTap:
			this.CreateGesture2Finger(EasyTouch.EventName.On_LongTapEnd2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
			break;
		case EasyTouch.GestureType.Pinch:
			this.CreateGesture2Finger(EasyTouch.EventName.On_PinchEnd, startPosition, position, deltaPosition, time, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
			break;
		case EasyTouch.GestureType.Twist:
			this.CreateGesture2Finger(EasyTouch.EventName.On_TwistEnd, startPosition, position, deltaPosition, time, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
			break;
		default:
			if (gesture == EasyTouch.GestureType.Tap)
			{
				if (this.fingers[this.twoFinger0].tapCount < 2 && this.fingers[this.twoFinger1].tapCount < 2)
				{
					this.CreateGesture2Finger(EasyTouch.EventName.On_SimpleTap2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
				}
				else
				{
					this.CreateGesture2Finger(EasyTouch.EventName.On_DoubleTap2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
				}
			}
			break;
		}
		if (realEnd)
		{
			if (this.twoFingerDragStart)
			{
				this.CreateGesture2Finger(EasyTouch.EventName.On_DragEnd2Fingers, startPosition, position, deltaPosition, time, this.GetSwipe(startPosition, position), (position - startPosition).magnitude, position - startPosition, 0f, 0f);
			}
			if (this.twoFingerSwipeStart)
			{
				this.CreateGesture2Finger(EasyTouch.EventName.On_SwipeEnd2Fingers, startPosition, position, deltaPosition, time, this.GetSwipe(startPosition, position), (position - startPosition).magnitude, position - startPosition, 0f, 0f);
			}
			this.CreateGesture2Finger(EasyTouch.EventName.On_TouchUp2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeType.None, 0f, Vector2.zero, 0f, 0f);
		}
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x0002BC64 File Offset: 0x0002A064
	private void CreateGesture2Finger(EasyTouch.EventName message, Vector2 startPosition, Vector2 position, Vector2 deltaPosition, float actionTime, EasyTouch.SwipeType swipe, float swipeLength, Vector2 swipeVector, float twist, float pinch)
	{
		Gesture gesture = new Gesture();
		gesture.touchCount = 2;
		gesture.fingerIndex = -1;
		gesture.startPosition = startPosition;
		gesture.position = position;
		gesture.deltaPosition = deltaPosition;
		gesture.actionTime = actionTime;
		if (this.fingers[this.twoFinger0] != null)
		{
			gesture.deltaTime = this.fingers[this.twoFinger0].deltaTime;
		}
		else if (this.fingers[this.twoFinger1] != null)
		{
			gesture.deltaTime = this.fingers[this.twoFinger1].deltaTime;
		}
		else
		{
			gesture.deltaTime = 0f;
		}
		gesture.swipe = swipe;
		gesture.swipeLength = swipeLength;
		gesture.swipeVector = swipeVector;
		gesture.deltaPinch = pinch;
		gesture.twistAngle = twist;
		if (message != EasyTouch.EventName.On_Cancel2Fingers)
		{
			gesture.pickObject = this.pickObject2Finger;
		}
		else
		{
			gesture.pickObject = this.oldPickObject2Finger;
		}
		gesture.otherReceiver = this.receiverObject;
		if (this.useBroadcastMessage)
		{
			this.SendGesture2Finger(message, gesture);
		}
		else
		{
			this.RaiseEvent(message, gesture);
		}
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x0002BD84 File Offset: 0x0002A184
	private void SendGesture2Finger(EasyTouch.EventName message, Gesture gesture)
	{
		if (this.receiverObject != null && this.receiverObject != gesture.pickObject)
		{
			this.receiverObject.SendMessage(message.ToString(), gesture, SendMessageOptions.DontRequireReceiver);
		}
		if (gesture.pickObject != null)
		{
			gesture.pickObject.SendMessage(message.ToString(), gesture, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			base.SendMessage(message.ToString(), gesture, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x0002BE18 File Offset: 0x0002A218
	private void RaiseEvent(EasyTouch.EventName evnt, Gesture gesture)
	{
		switch (evnt)
		{
		case EasyTouch.EventName.On_Cancel:
			if (EasyTouch.On_Cancel != null)
			{
				EasyTouch.On_Cancel(gesture);
			}
			break;
		case EasyTouch.EventName.On_Cancel2Fingers:
			if (EasyTouch.On_Cancel2Fingers != null)
			{
				EasyTouch.On_Cancel2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_TouchStart:
			if (EasyTouch.On_TouchStart != null)
			{
				EasyTouch.On_TouchStart(gesture);
			}
			break;
		case EasyTouch.EventName.On_TouchDown:
			if (EasyTouch.On_TouchDown != null)
			{
				EasyTouch.On_TouchDown(gesture);
			}
			break;
		case EasyTouch.EventName.On_TouchUp:
			if (EasyTouch.On_TouchUp != null)
			{
				EasyTouch.On_TouchUp(gesture);
			}
			break;
		case EasyTouch.EventName.On_SimpleTap:
			if (EasyTouch.On_SimpleTap != null)
			{
				EasyTouch.On_SimpleTap(gesture);
			}
			break;
		case EasyTouch.EventName.On_DoubleTap:
			if (EasyTouch.On_DoubleTap != null)
			{
				EasyTouch.On_DoubleTap(gesture);
			}
			break;
		case EasyTouch.EventName.On_LongTapStart:
			if (EasyTouch.On_LongTapStart != null)
			{
				EasyTouch.On_LongTapStart(gesture);
			}
			break;
		case EasyTouch.EventName.On_LongTap:
			if (EasyTouch.On_LongTap != null)
			{
				EasyTouch.On_LongTap(gesture);
			}
			break;
		case EasyTouch.EventName.On_LongTapEnd:
			if (EasyTouch.On_LongTapEnd != null)
			{
				EasyTouch.On_LongTapEnd(gesture);
			}
			break;
		case EasyTouch.EventName.On_DragStart:
			if (EasyTouch.On_DragStart != null)
			{
				EasyTouch.On_DragStart(gesture);
			}
			break;
		case EasyTouch.EventName.On_Drag:
			if (EasyTouch.On_Drag != null)
			{
				EasyTouch.On_Drag(gesture);
			}
			break;
		case EasyTouch.EventName.On_DragEnd:
			if (EasyTouch.On_DragEnd != null)
			{
				EasyTouch.On_DragEnd(gesture);
			}
			break;
		case EasyTouch.EventName.On_SwipeStart:
			if (EasyTouch.On_SwipeStart != null)
			{
				EasyTouch.On_SwipeStart(gesture);
			}
			break;
		case EasyTouch.EventName.On_Swipe:
			if (EasyTouch.On_Swipe != null)
			{
				EasyTouch.On_Swipe(gesture);
			}
			break;
		case EasyTouch.EventName.On_SwipeEnd:
			if (EasyTouch.On_SwipeEnd != null)
			{
				EasyTouch.On_SwipeEnd(gesture);
			}
			break;
		case EasyTouch.EventName.On_TouchStart2Fingers:
			if (EasyTouch.On_TouchStart2Fingers != null)
			{
				EasyTouch.On_TouchStart2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_TouchDown2Fingers:
			if (EasyTouch.On_TouchDown2Fingers != null)
			{
				EasyTouch.On_TouchDown2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_TouchUp2Fingers:
			if (EasyTouch.On_TouchUp2Fingers != null)
			{
				EasyTouch.On_TouchUp2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_SimpleTap2Fingers:
			if (EasyTouch.On_SimpleTap2Fingers != null)
			{
				EasyTouch.On_SimpleTap2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_DoubleTap2Fingers:
			if (EasyTouch.On_DoubleTap2Fingers != null)
			{
				EasyTouch.On_DoubleTap2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_LongTapStart2Fingers:
			if (EasyTouch.On_LongTapStart2Fingers != null)
			{
				EasyTouch.On_LongTapStart2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_LongTap2Fingers:
			if (EasyTouch.On_LongTap2Fingers != null)
			{
				EasyTouch.On_LongTap2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_LongTapEnd2Fingers:
			if (EasyTouch.On_LongTapEnd2Fingers != null)
			{
				EasyTouch.On_LongTapEnd2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_Twist:
			if (EasyTouch.On_Twist != null)
			{
				EasyTouch.On_Twist(gesture);
			}
			break;
		case EasyTouch.EventName.On_TwistEnd:
			if (EasyTouch.On_TwistEnd != null)
			{
				EasyTouch.On_TwistEnd(gesture);
			}
			break;
		case EasyTouch.EventName.On_PinchIn:
			if (EasyTouch.On_PinchIn != null)
			{
				EasyTouch.On_PinchIn(gesture);
			}
			break;
		case EasyTouch.EventName.On_PinchOut:
			if (EasyTouch.On_PinchOut != null)
			{
				EasyTouch.On_PinchOut(gesture);
			}
			break;
		case EasyTouch.EventName.On_PinchEnd:
			if (EasyTouch.On_PinchEnd != null)
			{
				EasyTouch.On_PinchEnd(gesture);
			}
			break;
		case EasyTouch.EventName.On_DragStart2Fingers:
			if (EasyTouch.On_DragStart2Fingers != null)
			{
				EasyTouch.On_DragStart2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_Drag2Fingers:
			if (EasyTouch.On_Drag2Fingers != null)
			{
				EasyTouch.On_Drag2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_DragEnd2Fingers:
			if (EasyTouch.On_DragEnd2Fingers != null)
			{
				EasyTouch.On_DragEnd2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_SwipeStart2Fingers:
			if (EasyTouch.On_SwipeStart2Fingers != null)
			{
				EasyTouch.On_SwipeStart2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_Swipe2Fingers:
			if (EasyTouch.On_Swipe2Fingers != null)
			{
				EasyTouch.On_Swipe2Fingers(gesture);
			}
			break;
		case EasyTouch.EventName.On_SwipeEnd2Fingers:
			if (EasyTouch.On_SwipeEnd2Fingers != null)
			{
				EasyTouch.On_SwipeEnd2Fingers(gesture);
			}
			break;
		}
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x0002C24C File Offset: 0x0002A64C
	private GameObject GetPickeGameObject(Vector2 screenPos)
	{
		return null;
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x0002C250 File Offset: 0x0002A650
	private EasyTouch.SwipeType GetSwipe(Vector2 start, Vector2 end)
	{
		Vector2 normalized = (end - start).normalized;
		if (Mathf.Abs(normalized.y) > Mathf.Abs(normalized.x))
		{
			if (Vector2.Dot(normalized, Vector2.up) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeType.Up;
			}
			if (Vector2.Dot(normalized, -Vector2.up) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeType.Down;
			}
		}
		else
		{
			if (Vector2.Dot(normalized, Vector2.right) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeType.Right;
			}
			if (Vector2.Dot(normalized, -Vector2.right) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeType.Left;
			}
		}
		return EasyTouch.SwipeType.Other;
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x0002C2FC File Offset: 0x0002A6FC
	private bool FingerInTolerance(Finger finger)
	{
		return (finger.position - finger.startPosition).sqrMagnitude <= this.StationnaryTolerance * this.StationnaryTolerance;
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x0002C338 File Offset: 0x0002A738
	private float DeltaAngle(Vector2 start, Vector2 end)
	{
		float y = start.x * end.y - start.y * end.x;
		return Mathf.Atan2(y, Vector2.Dot(start, end));
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x0002C374 File Offset: 0x0002A774
	private float TwistAngle()
	{
		Vector2 end = this.fingers[this.twoFinger0].position - this.fingers[this.twoFinger1].position;
		Vector2 start = this.fingers[this.twoFinger0].oldPosition - this.fingers[this.twoFinger1].oldPosition;
		return 57.29578f * this.DeltaAngle(start, end);
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x0002C3E5 File Offset: 0x0002A7E5
	public static void SetEnabled(bool enable)
	{
		EasyTouch.instance.enable = enable;
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x0002C3F2 File Offset: 0x0002A7F2
	public static bool GetEnabled()
	{
		return EasyTouch.instance.enable;
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x0002C3FE File Offset: 0x0002A7FE
	public static int GetTouchCount()
	{
		return EasyTouch.instance.input.TouchCount();
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x0002C40F File Offset: 0x0002A80F
	public static Camera GetCamera()
	{
		return EasyTouch.instance.mainCam;
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x0002C41B File Offset: 0x0002A81B
	public static void SetEnable2FingersGesture(bool enable)
	{
		EasyTouch.instance.enable2FingersGesture = enable;
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x0002C428 File Offset: 0x0002A828
	public static bool GetEnable2FingersGesture()
	{
		return EasyTouch.instance.enable2FingersGesture;
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x0002C434 File Offset: 0x0002A834
	public static void SetEnableTwist(bool enable)
	{
		EasyTouch.instance.enableTwist = enable;
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x0002C441 File Offset: 0x0002A841
	public static bool GetEnableTwist()
	{
		return EasyTouch.instance.enableTwist;
	}

	// Token: 0x06000610 RID: 1552 RVA: 0x0002C44D File Offset: 0x0002A84D
	public static void SetEnablePinch(bool enable)
	{
		EasyTouch.instance.enablePinch = enable;
	}

	// Token: 0x06000611 RID: 1553 RVA: 0x0002C45A File Offset: 0x0002A85A
	public static bool GetEnablePinch()
	{
		return EasyTouch.instance.enablePinch;
	}

	// Token: 0x06000612 RID: 1554 RVA: 0x0002C466 File Offset: 0x0002A866
	public static void SetEnableAutoSelect(bool enable)
	{
		EasyTouch.instance.autoSelect = enable;
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x0002C473 File Offset: 0x0002A873
	public static bool GetEnableAutoSelect()
	{
		return EasyTouch.instance.autoSelect;
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x0002C47F File Offset: 0x0002A87F
	public static void SetOtherReceiverObject(GameObject receiver)
	{
		EasyTouch.instance.receiverObject = receiver;
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x0002C48C File Offset: 0x0002A88C
	public static GameObject GetOtherReceiverObject()
	{
		return EasyTouch.instance.receiverObject;
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x0002C498 File Offset: 0x0002A898
	public static void SetStationnaryTolerance(float tolerance)
	{
		EasyTouch.instance.StationnaryTolerance = tolerance;
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x0002C4A5 File Offset: 0x0002A8A5
	public static float GetStationnaryTolerance()
	{
		return EasyTouch.instance.StationnaryTolerance;
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x0002C4B1 File Offset: 0x0002A8B1
	public static void SetlongTapTime(float time)
	{
		EasyTouch.instance.longTapTime = time;
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x0002C4BE File Offset: 0x0002A8BE
	public static float GetlongTapTime()
	{
		return EasyTouch.instance.longTapTime;
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x0002C4CA File Offset: 0x0002A8CA
	public static void SetSwipeTolerance(float tolerance)
	{
		EasyTouch.instance.swipeTolerance = tolerance;
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x0002C4D7 File Offset: 0x0002A8D7
	public static float GetSwipeTolerance()
	{
		return EasyTouch.instance.swipeTolerance;
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x0002C4E3 File Offset: 0x0002A8E3
	public static void SetMinPinchLength(float length)
	{
		EasyTouch.instance.minPinchLength = length;
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x0002C4F0 File Offset: 0x0002A8F0
	public static float GetMinPinchLength()
	{
		return EasyTouch.instance.minPinchLength;
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x0002C4FC File Offset: 0x0002A8FC
	public static void SetMinTwistAngle(float angle)
	{
		EasyTouch.instance.minTwistAngle = angle;
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x0002C509 File Offset: 0x0002A909
	public static float GetMinTwistAngle()
	{
		return EasyTouch.instance.minTwistAngle;
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x0002C515 File Offset: 0x0002A915
	public static GameObject GetCurrentPickedObject(int fingerIndex)
	{
		return EasyTouch.instance.GetPickeGameObject(EasyTouch.instance.fingers[fingerIndex].position);
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x0002C534 File Offset: 0x0002A934
	public static bool IsRectUnderTouch(Rect rect)
	{
		bool result = false;
		for (int i = 0; i < 100; i++)
		{
			if (EasyTouch.instance.fingers[i] != null)
			{
				result = rect.Contains(EasyTouch.instance.fingers[i].position);
				break;
			}
		}
		return result;
	}

	// Token: 0x04000568 RID: 1384
	public bool enable = true;

	// Token: 0x04000569 RID: 1385
	public bool enableRemote;

	// Token: 0x0400056A RID: 1386
	public bool useBroadcastMessage = true;

	// Token: 0x0400056B RID: 1387
	public bool joystickAddon;

	// Token: 0x0400056C RID: 1388
	public bool enable2FingersGesture = true;

	// Token: 0x0400056D RID: 1389
	public bool enableTwist = true;

	// Token: 0x0400056E RID: 1390
	public bool enablePinch = true;

	// Token: 0x0400056F RID: 1391
	public bool autoSelect = true;

	// Token: 0x04000570 RID: 1392
	public LayerMask pickableLayers;

	// Token: 0x04000571 RID: 1393
	public float StationnaryTolerance = 25f;

	// Token: 0x04000572 RID: 1394
	public float longTapTime = 1f;

	// Token: 0x04000573 RID: 1395
	public float swipeTolerance = 0.85f;

	// Token: 0x04000574 RID: 1396
	public float minPinchLength;

	// Token: 0x04000575 RID: 1397
	public float minTwistAngle = 1f;

	// Token: 0x04000576 RID: 1398
	public bool showGeneral = true;

	// Token: 0x04000577 RID: 1399
	public bool showSelect = true;

	// Token: 0x04000578 RID: 1400
	public bool showGesture = true;

	// Token: 0x04000579 RID: 1401
	public bool showTwoFinger = true;

	// Token: 0x0400057A RID: 1402
	public static EasyTouch instance;

	// Token: 0x0400057B RID: 1403
	private EasyTouchInput input;

	// Token: 0x0400057C RID: 1404
	private EasyTouch.GestureType complexCurrentGesture = EasyTouch.GestureType.None;

	// Token: 0x0400057D RID: 1405
	private EasyTouch.GestureType oldGesture = EasyTouch.GestureType.None;

	// Token: 0x0400057E RID: 1406
	private float startTimeAction;

	// Token: 0x0400057F RID: 1407
	private Finger[] fingers = new Finger[100];

	// Token: 0x04000580 RID: 1408
	private Camera mainCam;

	// Token: 0x04000581 RID: 1409
	private GameObject pickObject2Finger;

	// Token: 0x04000582 RID: 1410
	private GameObject oldPickObject2Finger;

	// Token: 0x04000583 RID: 1411
	private GameObject receiverObject;

	// Token: 0x04000584 RID: 1412
	private Texture secondFingerTexture;

	// Token: 0x04000585 RID: 1413
	private Vector2 startPosition2Finger;

	// Token: 0x04000586 RID: 1414
	private int twoFinger0;

	// Token: 0x04000587 RID: 1415
	private int twoFinger1;

	// Token: 0x04000588 RID: 1416
	private Vector2 oldStartPosition2Finger;

	// Token: 0x04000589 RID: 1417
	private float oldFingerDistance;

	// Token: 0x0400058A RID: 1418
	private bool twoFingerDragStart;

	// Token: 0x0400058B RID: 1419
	private bool twoFingerSwipeStart;

	// Token: 0x0400058C RID: 1420
	private int oldTouchCount;

	// Token: 0x020000CA RID: 202
	// (Invoke) Token: 0x06000623 RID: 1571
	public delegate void TouchCancelHandler(Gesture gesture);

	// Token: 0x020000CB RID: 203
	// (Invoke) Token: 0x06000627 RID: 1575
	public delegate void Cancel2FingersHandler(Gesture gesture);

	// Token: 0x020000CC RID: 204
	// (Invoke) Token: 0x0600062B RID: 1579
	public delegate void TouchStartHandler(Gesture gesture);

	// Token: 0x020000CD RID: 205
	// (Invoke) Token: 0x0600062F RID: 1583
	public delegate void TouchDownHandler(Gesture gesture);

	// Token: 0x020000CE RID: 206
	// (Invoke) Token: 0x06000633 RID: 1587
	public delegate void TouchUpHandler(Gesture gesture);

	// Token: 0x020000CF RID: 207
	// (Invoke) Token: 0x06000637 RID: 1591
	public delegate void SimpleTapHandler(Gesture gesture);

	// Token: 0x020000D0 RID: 208
	// (Invoke) Token: 0x0600063B RID: 1595
	public delegate void DoubleTapHandler(Gesture gesture);

	// Token: 0x020000D1 RID: 209
	// (Invoke) Token: 0x0600063F RID: 1599
	public delegate void LongTapStartHandler(Gesture gesture);

	// Token: 0x020000D2 RID: 210
	// (Invoke) Token: 0x06000643 RID: 1603
	public delegate void LongTapHandler(Gesture gesture);

	// Token: 0x020000D3 RID: 211
	// (Invoke) Token: 0x06000647 RID: 1607
	public delegate void LongTapEndHandler(Gesture gesture);

	// Token: 0x020000D4 RID: 212
	// (Invoke) Token: 0x0600064B RID: 1611
	public delegate void DragStartHandler(Gesture gesture);

	// Token: 0x020000D5 RID: 213
	// (Invoke) Token: 0x0600064F RID: 1615
	public delegate void DragHandler(Gesture gesture);

	// Token: 0x020000D6 RID: 214
	// (Invoke) Token: 0x06000653 RID: 1619
	public delegate void DragEndHandler(Gesture gesture);

	// Token: 0x020000D7 RID: 215
	// (Invoke) Token: 0x06000657 RID: 1623
	public delegate void SwipeStartHandler(Gesture gesture);

	// Token: 0x020000D8 RID: 216
	// (Invoke) Token: 0x0600065B RID: 1627
	public delegate void SwipeHandler(Gesture gesture);

	// Token: 0x020000D9 RID: 217
	// (Invoke) Token: 0x0600065F RID: 1631
	public delegate void SwipeEndHandler(Gesture gesture);

	// Token: 0x020000DA RID: 218
	// (Invoke) Token: 0x06000663 RID: 1635
	public delegate void TouchStart2FingersHandler(Gesture gesture);

	// Token: 0x020000DB RID: 219
	// (Invoke) Token: 0x06000667 RID: 1639
	public delegate void TouchDown2FingersHandler(Gesture gesture);

	// Token: 0x020000DC RID: 220
	// (Invoke) Token: 0x0600066B RID: 1643
	public delegate void TouchUp2FingersHandler(Gesture gesture);

	// Token: 0x020000DD RID: 221
	// (Invoke) Token: 0x0600066F RID: 1647
	public delegate void SimpleTap2FingersHandler(Gesture gesture);

	// Token: 0x020000DE RID: 222
	// (Invoke) Token: 0x06000673 RID: 1651
	public delegate void DoubleTap2FingersHandler(Gesture gesture);

	// Token: 0x020000DF RID: 223
	// (Invoke) Token: 0x06000677 RID: 1655
	public delegate void LongTapStart2FingersHandler(Gesture gesture);

	// Token: 0x020000E0 RID: 224
	// (Invoke) Token: 0x0600067B RID: 1659
	public delegate void LongTap2FingersHandler(Gesture gesture);

	// Token: 0x020000E1 RID: 225
	// (Invoke) Token: 0x0600067F RID: 1663
	public delegate void LongTapEnd2FingersHandler(Gesture gesture);

	// Token: 0x020000E2 RID: 226
	// (Invoke) Token: 0x06000683 RID: 1667
	public delegate void TwistHandler(Gesture gesture);

	// Token: 0x020000E3 RID: 227
	// (Invoke) Token: 0x06000687 RID: 1671
	public delegate void TwistEndHandler(Gesture gesture);

	// Token: 0x020000E4 RID: 228
	// (Invoke) Token: 0x0600068B RID: 1675
	public delegate void PinchInHandler(Gesture gesture);

	// Token: 0x020000E5 RID: 229
	// (Invoke) Token: 0x0600068F RID: 1679
	public delegate void PinchOutHandler(Gesture gesture);

	// Token: 0x020000E6 RID: 230
	// (Invoke) Token: 0x06000693 RID: 1683
	public delegate void PinchEndHandler(Gesture gesture);

	// Token: 0x020000E7 RID: 231
	// (Invoke) Token: 0x06000697 RID: 1687
	public delegate void DragStart2FingersHandler(Gesture gesture);

	// Token: 0x020000E8 RID: 232
	// (Invoke) Token: 0x0600069B RID: 1691
	public delegate void Drag2FingersHandler(Gesture gesture);

	// Token: 0x020000E9 RID: 233
	// (Invoke) Token: 0x0600069F RID: 1695
	public delegate void DragEnd2FingersHandler(Gesture gesture);

	// Token: 0x020000EA RID: 234
	// (Invoke) Token: 0x060006A3 RID: 1699
	public delegate void SwipeStart2FingersHandler(Gesture gesture);

	// Token: 0x020000EB RID: 235
	// (Invoke) Token: 0x060006A7 RID: 1703
	public delegate void Swipe2FingersHandler(Gesture gesture);

	// Token: 0x020000EC RID: 236
	// (Invoke) Token: 0x060006AB RID: 1707
	public delegate void SwipeEnd2FingersHandler(Gesture gesture);

	// Token: 0x020000ED RID: 237
	public enum GestureType
	{
		// Token: 0x0400058E RID: 1422
		Tap,
		// Token: 0x0400058F RID: 1423
		Drag,
		// Token: 0x04000590 RID: 1424
		Swipe,
		// Token: 0x04000591 RID: 1425
		None,
		// Token: 0x04000592 RID: 1426
		LongTap,
		// Token: 0x04000593 RID: 1427
		Pinch,
		// Token: 0x04000594 RID: 1428
		Twist,
		// Token: 0x04000595 RID: 1429
		Cancel,
		// Token: 0x04000596 RID: 1430
		Acquisition
	}

	// Token: 0x020000EE RID: 238
	public enum SwipeType
	{
		// Token: 0x04000598 RID: 1432
		None,
		// Token: 0x04000599 RID: 1433
		Left,
		// Token: 0x0400059A RID: 1434
		Right,
		// Token: 0x0400059B RID: 1435
		Up,
		// Token: 0x0400059C RID: 1436
		Down,
		// Token: 0x0400059D RID: 1437
		Other
	}

	// Token: 0x020000EF RID: 239
	public enum EventName
	{
		// Token: 0x0400059F RID: 1439
		None,
		// Token: 0x040005A0 RID: 1440
		On_Cancel,
		// Token: 0x040005A1 RID: 1441
		On_Cancel2Fingers,
		// Token: 0x040005A2 RID: 1442
		On_TouchStart,
		// Token: 0x040005A3 RID: 1443
		On_TouchDown,
		// Token: 0x040005A4 RID: 1444
		On_TouchUp,
		// Token: 0x040005A5 RID: 1445
		On_SimpleTap,
		// Token: 0x040005A6 RID: 1446
		On_DoubleTap,
		// Token: 0x040005A7 RID: 1447
		On_LongTapStart,
		// Token: 0x040005A8 RID: 1448
		On_LongTap,
		// Token: 0x040005A9 RID: 1449
		On_LongTapEnd,
		// Token: 0x040005AA RID: 1450
		On_DragStart,
		// Token: 0x040005AB RID: 1451
		On_Drag,
		// Token: 0x040005AC RID: 1452
		On_DragEnd,
		// Token: 0x040005AD RID: 1453
		On_SwipeStart,
		// Token: 0x040005AE RID: 1454
		On_Swipe,
		// Token: 0x040005AF RID: 1455
		On_SwipeEnd,
		// Token: 0x040005B0 RID: 1456
		On_TouchStart2Fingers,
		// Token: 0x040005B1 RID: 1457
		On_TouchDown2Fingers,
		// Token: 0x040005B2 RID: 1458
		On_TouchUp2Fingers,
		// Token: 0x040005B3 RID: 1459
		On_SimpleTap2Fingers,
		// Token: 0x040005B4 RID: 1460
		On_DoubleTap2Fingers,
		// Token: 0x040005B5 RID: 1461
		On_LongTapStart2Fingers,
		// Token: 0x040005B6 RID: 1462
		On_LongTap2Fingers,
		// Token: 0x040005B7 RID: 1463
		On_LongTapEnd2Fingers,
		// Token: 0x040005B8 RID: 1464
		On_Twist,
		// Token: 0x040005B9 RID: 1465
		On_TwistEnd,
		// Token: 0x040005BA RID: 1466
		On_PinchIn,
		// Token: 0x040005BB RID: 1467
		On_PinchOut,
		// Token: 0x040005BC RID: 1468
		On_PinchEnd,
		// Token: 0x040005BD RID: 1469
		On_DragStart2Fingers,
		// Token: 0x040005BE RID: 1470
		On_Drag2Fingers,
		// Token: 0x040005BF RID: 1471
		On_DragEnd2Fingers,
		// Token: 0x040005C0 RID: 1472
		On_SwipeStart2Fingers,
		// Token: 0x040005C1 RID: 1473
		On_Swipe2Fingers,
		// Token: 0x040005C2 RID: 1474
		On_SwipeEnd2Fingers
	}
}
