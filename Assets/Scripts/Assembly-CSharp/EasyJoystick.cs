using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020000C0 RID: 192
[ExecuteInEditMode]
public class EasyJoystick : MonoBehaviour
{
	// Token: 0x1400006D RID: 109
	// (add) Token: 0x06000580 RID: 1408 RVA: 0x00028818 File Offset: 0x00026C18
	// (remove) Token: 0x06000581 RID: 1409 RVA: 0x0002884C File Offset: 0x00026C4C
	
	public static event EasyJoystick.JoystickMoveHandler On_JoystickMove;

	// Token: 0x1400006E RID: 110
	// (add) Token: 0x06000582 RID: 1410 RVA: 0x00028880 File Offset: 0x00026C80
	// (remove) Token: 0x06000583 RID: 1411 RVA: 0x000288B4 File Offset: 0x00026CB4
	
	public static event EasyJoystick.JoystickMoveEndHandler On_JoystickMoveEnd;

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000584 RID: 1412 RVA: 0x000288E8 File Offset: 0x00026CE8
	public Vector2 JoystickAxis
	{
		get
		{
			return this.joystickAxis;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x06000585 RID: 1413 RVA: 0x000288F0 File Offset: 0x00026CF0
	public Vector2 JoystickValue
	{
		get
		{
			return this.joystickValue;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x06000586 RID: 1414 RVA: 0x000288F8 File Offset: 0x00026CF8
	// (set) Token: 0x06000587 RID: 1415 RVA: 0x00028900 File Offset: 0x00026D00
	public float TouchSize
	{
		get
		{
			return this.touchSize;
		}
		set
		{
			this.touchSize = value;
			if (this.touchSize > this.zoneRadius / 2f && this.restrictArea)
			{
				this.touchSize = this.zoneRadius / 2f;
			}
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x06000588 RID: 1416 RVA: 0x0002893D File Offset: 0x00026D3D
	// (set) Token: 0x06000589 RID: 1417 RVA: 0x00028945 File Offset: 0x00026D45
	public bool DynamicJoystick
	{
		get
		{
			return this.dynamicJoystick;
		}
		set
		{
			this.joystickIndex = -1;
			this.dynamicJoystick = value;
			if (this.dynamicJoystick)
			{
				this.virtualJoystick = false;
			}
			else
			{
				this.virtualJoystick = true;
				this.joystickCenter = this.joystickPosition;
			}
		}
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x0600058A RID: 1418 RVA: 0x0002897F File Offset: 0x00026D7F
	// (set) Token: 0x0600058B RID: 1419 RVA: 0x00028987 File Offset: 0x00026D87
	public bool RestrictArea
	{
		get
		{
			return this.restrictArea;
		}
		set
		{
			this.restrictArea = value;
			if (this.restrictArea)
			{
				this.touchSizeCoef = this.touchSize;
			}
			else
			{
				this.touchSizeCoef = 0f;
			}
		}
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x0600058C RID: 1420 RVA: 0x000289B7 File Offset: 0x00026DB7
	// (set) Token: 0x0600058D RID: 1421 RVA: 0x000289C0 File Offset: 0x00026DC0
	public Vector2 Smoothing
	{
		get
		{
			return this.smoothing;
		}
		set
		{
			this.smoothing = value;
			if (this.smoothing.x < 0.1f)
			{
				this.smoothing.x = 0.1f;
			}
			if ((double)this.smoothing.y < 0.1)
			{
				this.smoothing.y = 0.1f;
			}
		}
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x0600058E RID: 1422 RVA: 0x00028A23 File Offset: 0x00026E23
	// (set) Token: 0x0600058F RID: 1423 RVA: 0x00028A2C File Offset: 0x00026E2C
	public Vector2 Inertia
	{
		get
		{
			return this.inertia;
		}
		set
		{
			this.inertia = value;
			if (this.inertia.x <= 0f)
			{
				this.inertia.x = 1f;
			}
			if (this.inertia.y <= 0f)
			{
				this.inertia.y = 1f;
			}
		}
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x06000590 RID: 1424 RVA: 0x00028A8A File Offset: 0x00026E8A
	// (set) Token: 0x06000591 RID: 1425 RVA: 0x00028A94 File Offset: 0x00026E94
	public Transform XAxisTransform
	{
		get
		{
			return this.xAxisTransform;
		}
		set
		{
			this.xAxisTransform = value;
			if (this.xAxisTransform != null)
			{
				this.xAxisCharacterController = this.xAxisTransform.GetComponent<CharacterController>();
			}
			else
			{
				this.xAxisCharacterController = null;
				this.xAxisGravity = 0f;
			}
		}
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x06000592 RID: 1426 RVA: 0x00028AE1 File Offset: 0x00026EE1
	// (set) Token: 0x06000593 RID: 1427 RVA: 0x00028AEC File Offset: 0x00026EEC
	public Transform YAxisTransform
	{
		get
		{
			return this.yAxisTransform;
		}
		set
		{
			this.yAxisTransform = value;
			if (this.yAxisTransform != null)
			{
				this.yAxisCharacterController = this.yAxisTransform.GetComponent<CharacterController>();
			}
			else
			{
				this.yAxisCharacterController = null;
				this.yAxisGravity = 0f;
			}
		}
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x00028B39 File Offset: 0x00026F39
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
		EasyTouch.On_TouchUp += this.On_TouchUp;
		EasyTouch.On_TouchDown += this.On_TouchDown;
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00028B6E File Offset: 0x00026F6E
	private void OnDisable()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_TouchDown -= this.On_TouchDown;
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x00028BA3 File Offset: 0x00026FA3
	private void OnDestroy()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_TouchDown -= this.On_TouchDown;
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x00028BD8 File Offset: 0x00026FD8
	private void Start()
	{
		this.enable = true;
		if (!this.dynamicJoystick)
		{
			this.joystickCenter = this.joystickPosition;
			this.virtualJoystick = true;
		}
		else
		{
			this.virtualJoystick = false;
		}
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x00028C0B File Offset: 0x0002700B
	private void Update()
	{
		if (!this.useFixedUpdate && this.enable)
		{
			this.UpdateJoystick();
		}
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00028C29 File Offset: 0x00027029
	private void FixedUpdate()
	{
		if (this.useFixedUpdate && this.enable)
		{
			this.UpdateJoystick();
		}
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x00028C48 File Offset: 0x00027048
	public void UpdateJoystick()
	{
		if (Application.isPlaying)
		{
			if (this.joystickIndex == -1)
			{
				if (!this.enableSmoothing)
				{
					this.joyTouch = Vector2.zero;
				}
				else if ((double)this.joyTouch.sqrMagnitude > 0.1)
				{
					this.joyTouch = new Vector2(this.joyTouch.x - this.joyTouch.x * this.smoothing.x * Time.deltaTime, this.joyTouch.y - this.joyTouch.y * this.smoothing.y * Time.deltaTime);
				}
				else
				{
					this.joyTouch = Vector2.zero;
				}
			}
			if (this.joyTouch.sqrMagnitude > this.deadZone * this.deadZone)
			{
				this.joystickAxis = Vector2.zero;
				if (Mathf.Abs(this.joyTouch.x) > this.deadZone)
				{
					this.joystickAxis = new Vector2((this.joyTouch.x - this.deadZone * Mathf.Sign(this.joyTouch.x)) / (this.zoneRadius - this.touchSizeCoef - this.deadZone), this.joystickAxis.y);
				}
				else
				{
					this.joystickAxis = new Vector2(this.joyTouch.x / (this.zoneRadius - this.touchSizeCoef), this.joystickAxis.y);
				}
				if (Mathf.Abs(this.joyTouch.y) > this.deadZone)
				{
					this.joystickAxis = new Vector2(this.joystickAxis.x, (this.joyTouch.y - this.deadZone * Mathf.Sign(this.joyTouch.y)) / (this.zoneRadius - this.touchSizeCoef - this.deadZone));
				}
				else
				{
					this.joystickAxis = new Vector2(this.joystickAxis.x, this.joyTouch.y / (this.zoneRadius - this.touchSizeCoef));
				}
			}
			else
			{
				this.joystickAxis = new Vector2(0f, 0f);
			}
			if (this.inverseXAxis)
			{
				this.joystickAxis.x = this.joystickAxis.x * -1f;
			}
			if (this.inverseYAxis)
			{
				this.joystickAxis.y = this.joystickAxis.y * -1f;
			}
			Vector2 a = new Vector2(this.speed.x * this.joystickAxis.x, this.speed.y * this.joystickAxis.y);
			if (this.enableInertia)
			{
				Vector2 b = a - this.joystickValue;
				b.x /= this.inertia.x;
				b.y /= this.inertia.y;
				this.joystickValue += b;
			}
			else
			{
				this.joystickValue = a;
			}
			if (this.joystickAxis != Vector2.zero)
			{
				this.sendEnd = false;
				EasyJoystick.InteractionType interactionType = this.interaction;
				if (interactionType != EasyJoystick.InteractionType.Direct)
				{
					if (interactionType != EasyJoystick.InteractionType.EventNotification)
					{
						if (interactionType == EasyJoystick.InteractionType.DirectAndEvent)
						{
							this.UpdateDirect();
							this.CreateEvent(EasyJoystick.MessageName.On_JoystickMove);
						}
					}
					else
					{
						this.CreateEvent(EasyJoystick.MessageName.On_JoystickMove);
					}
				}
				else
				{
					this.UpdateDirect();
				}
			}
			else if (!this.sendEnd)
			{
				this.CreateEvent(EasyJoystick.MessageName.On_JoystickMoveEnd);
				this.sendEnd = true;
			}
		}
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x00028FF0 File Offset: 0x000273F0
	private void OnGUI()
	{
		if ((this.showZone && this.areaTexture != null && !this.dynamicJoystick && this.enable) || (this.showZone && this.dynamicJoystick && this.virtualJoystick && this.areaTexture != null && this.enable))
		{
			GUI.DrawTexture(new Rect(this.joystickCenter.x - this.zoneRadius, (float)Screen.height - this.joystickCenter.y - this.zoneRadius, this.zoneRadius * 2f, this.zoneRadius * 2f), this.areaTexture, ScaleMode.ScaleToFit, true);
		}
		if ((this.showTouch && this.touchTexture != null && !this.dynamicJoystick && this.enable) || (this.showTouch && this.dynamicJoystick && this.virtualJoystick && (this.touchTexture != null & this.enable)))
		{
			GUI.DrawTexture(new Rect(this.joystickCenter.x + (this.joyTouch.x - this.touchSize), (float)Screen.height - this.joystickCenter.y - (this.joyTouch.y + this.touchSize), this.touchSize * 2f, this.touchSize * 2f), this.touchTexture, ScaleMode.ScaleToFit, true);
		}
		if ((this.showDeadZone && this.deadTexture != null && !this.dynamicJoystick && this.enable) || (this.showDeadZone && this.dynamicJoystick && this.virtualJoystick && this.deadTexture != null && this.enable))
		{
			GUI.DrawTexture(new Rect(this.joystickCenter.x - this.deadZone, (float)Screen.height - this.joystickCenter.y - this.deadZone, this.deadZone * 2f, this.deadZone * 2f), this.deadTexture, ScaleMode.ScaleToFit, true);
		}
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x0002925D File Offset: 0x0002765D
	private void OnDrawGizmos()
	{
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x00029260 File Offset: 0x00027660
	private void CreateEvent(EasyJoystick.MessageName message)
	{
		MovingJoystick movingJoystick = new MovingJoystick();
		movingJoystick.joystickName = base.gameObject.name;
		movingJoystick.joystickAxis = this.joystickAxis;
		movingJoystick.joystickValue = this.joystickValue;
		if (!this.useBroadcast)
		{
			if (message != EasyJoystick.MessageName.On_JoystickMove)
			{
				if (message == EasyJoystick.MessageName.On_JoystickMoveEnd)
				{
					if (EasyJoystick.On_JoystickMoveEnd != null)
					{
						EasyJoystick.On_JoystickMoveEnd(movingJoystick);
					}
				}
			}
			else if (EasyJoystick.On_JoystickMove != null)
			{
				EasyJoystick.On_JoystickMove(movingJoystick);
			}
		}
		else
		{
			EasyJoystick.Broadcast broadcast = this.messageMode;
			if (broadcast != EasyJoystick.Broadcast.BroadcastMessage)
			{
				if (broadcast != EasyJoystick.Broadcast.SendMessage)
				{
					if (broadcast == EasyJoystick.Broadcast.SendMessageUpwards)
					{
						this.ReceiverObjectGame.SendMessageUpwards(message.ToString(), movingJoystick, SendMessageOptions.DontRequireReceiver);
					}
				}
				else
				{
					this.ReceiverObjectGame.SendMessage(message.ToString(), movingJoystick, SendMessageOptions.DontRequireReceiver);
				}
			}
			else
			{
				this.ReceiverObjectGame.BroadcastMessage(message.ToString(), movingJoystick, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x00029370 File Offset: 0x00027770
	private void UpdateDirect()
	{
		if (this.xAxisCharacterController != null && this.xAxisGravity > 0f)
		{
			this.xAxisCharacterController.Move(Vector3.down * this.xAxisGravity * Time.deltaTime);
		}
		if (this.yAxisCharacterController != null && this.yAxisGravity > 0f)
		{
			this.yAxisCharacterController.Move(Vector3.down * this.yAxisGravity * Time.deltaTime);
		}
		if (this.xAxisTransform != null)
		{
			Vector3 influencedAxis = this.GetInfluencedAxis(this.xAI);
			this.DoActionDirect(this.xAxisTransform, this.xTI, influencedAxis, this.joystickValue.x, this.xAxisCharacterController);
		}
		if (this.YAxisTransform != null)
		{
			Vector3 influencedAxis2 = this.GetInfluencedAxis(this.yAI);
			this.DoActionDirect(this.yAxisTransform, this.yTI, influencedAxis2, this.joystickValue.y, this.yAxisCharacterController);
		}
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x00029490 File Offset: 0x00027890
	private Vector3 GetInfluencedAxis(EasyJoystick.AxisInfluenced axisInfluenced)
	{
		Vector3 result = Vector3.zero;
		switch (axisInfluenced)
		{
		case EasyJoystick.AxisInfluenced.X:
			result = Vector3.right;
			break;
		case EasyJoystick.AxisInfluenced.Y:
			result = Vector3.up;
			break;
		case EasyJoystick.AxisInfluenced.Z:
			result = Vector3.forward;
			break;
		case EasyJoystick.AxisInfluenced.XYZ:
			result = Vector3.one;
			break;
		}
		return result;
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x000294EC File Offset: 0x000278EC
	private void DoActionDirect(Transform axisTransform, EasyJoystick.PropertiesInfluenced inlfuencedProperty, Vector3 axis, float sensibility, CharacterController charact)
	{
		switch (inlfuencedProperty)
		{
		case EasyJoystick.PropertiesInfluenced.Rotate:
			axisTransform.Rotate(axis * sensibility * Time.deltaTime, Space.World);
			break;
		case EasyJoystick.PropertiesInfluenced.RotateLocal:
			axisTransform.Rotate(axis * sensibility * Time.deltaTime, Space.Self);
			break;
		case EasyJoystick.PropertiesInfluenced.Translate:
			if (charact == null)
			{
				axisTransform.Translate(axis * sensibility * Time.deltaTime, Space.World);
			}
			else
			{
				charact.Move(axis * sensibility * Time.deltaTime);
			}
			break;
		case EasyJoystick.PropertiesInfluenced.TranslateLocal:
			if (charact == null)
			{
				axisTransform.Translate(axis * sensibility * Time.deltaTime, Space.Self);
			}
			else
			{
				charact.Move(charact.transform.TransformDirection(axis) * sensibility * Time.deltaTime);
			}
			break;
		case EasyJoystick.PropertiesInfluenced.Scale:
			axisTransform.localScale += axis * sensibility * Time.deltaTime;
			break;
		}
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x0002961C File Offset: 0x00027A1C
	private void On_TouchStart(Gesture gesture)
	{
		if (!this.dynamicJoystick)
		{
			if ((gesture.position - this.joystickCenter).sqrMagnitude < (this.zoneRadius + this.touchSizeCoef / 2f) * (this.zoneRadius + this.touchSizeCoef / 2f))
			{
				this.joystickIndex = gesture.fingerIndex;
			}
		}
		else if (!this.virtualJoystick)
		{
			switch (this.area)
			{
			case EasyJoystick.DynamicArea.FullScreen:
				this.virtualJoystick = true;
				break;
			case EasyJoystick.DynamicArea.Left:
				if (gesture.position.x < (float)(Screen.width / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			case EasyJoystick.DynamicArea.Right:
				if (gesture.position.x > (float)(Screen.width / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			case EasyJoystick.DynamicArea.Top:
				if (gesture.position.y > (float)(Screen.height / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			case EasyJoystick.DynamicArea.Bottom:
				if (gesture.position.y < (float)(Screen.height / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			case EasyJoystick.DynamicArea.TopLeft:
				if (gesture.position.y > (float)(Screen.height / 2) && gesture.position.x < (float)(Screen.width / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			case EasyJoystick.DynamicArea.TopRight:
				if (gesture.position.y > (float)(Screen.height / 2) && gesture.position.x > (float)(Screen.width / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			case EasyJoystick.DynamicArea.BottomLeft:
				if (gesture.position.y < (float)(Screen.height / 2) && gesture.position.x < (float)(Screen.width / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			case EasyJoystick.DynamicArea.BottomRight:
				if (gesture.position.y < (float)(Screen.height / 2) && gesture.position.x > (float)(Screen.width / 2))
				{
					this.virtualJoystick = true;
				}
				break;
			}
			if (this.virtualJoystick)
			{
				this.joystickCenter = gesture.position;
				this.joystickIndex = gesture.fingerIndex;
			}
		}
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x0002987C File Offset: 0x00027C7C
	private void On_TouchDown(Gesture gesture)
	{
		if (gesture.fingerIndex == this.joystickIndex)
		{
			this.joyTouch = new Vector2(gesture.position.x, gesture.position.y) - this.joystickCenter;
			if ((this.joyTouch / (this.zoneRadius - this.touchSizeCoef)).sqrMagnitude > 1f)
			{
				this.joyTouch.Normalize();
				this.joyTouch *= this.zoneRadius - this.touchSizeCoef;
			}
		}
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x00029919 File Offset: 0x00027D19
	private void On_TouchUp(Gesture gesture)
	{
		if (gesture.fingerIndex == this.joystickIndex)
		{
			this.joystickIndex = -1;
			if (this.dynamicJoystick)
			{
				this.virtualJoystick = false;
			}
		}
	}

	// Token: 0x040004F5 RID: 1269
	private Vector2 joystickAxis;

	// Token: 0x040004F6 RID: 1270
	private Vector2 joystickValue;

	// Token: 0x040004F7 RID: 1271
	public bool enable;

	// Token: 0x040004F8 RID: 1272
	public bool useFixedUpdate;

	// Token: 0x040004F9 RID: 1273
	public float zoneRadius = 100f;

	// Token: 0x040004FA RID: 1274
	[SerializeField]
	private float touchSize = 30f;

	// Token: 0x040004FB RID: 1275
	public float deadZone = 20f;

	// Token: 0x040004FC RID: 1276
	[SerializeField]
	private bool dynamicJoystick;

	// Token: 0x040004FD RID: 1277
	public EasyJoystick.DynamicArea area;

	// Token: 0x040004FE RID: 1278
	public Vector2 joystickPosition = new Vector2(135f, 135f);

	// Token: 0x040004FF RID: 1279
	[SerializeField]
	private bool restrictArea;

	// Token: 0x04000500 RID: 1280
	public GameObject ReceiverObjectGame;

	// Token: 0x04000501 RID: 1281
	public EasyJoystick.Broadcast messageMode;

	// Token: 0x04000502 RID: 1282
	public bool enableSmoothing;

	// Token: 0x04000503 RID: 1283
	[SerializeField]
	private Vector2 smoothing = new Vector2(2f, 2f);

	// Token: 0x04000504 RID: 1284
	public bool enableInertia;

	// Token: 0x04000505 RID: 1285
	[SerializeField]
	public Vector2 inertia = new Vector2(100f, 100f);

	// Token: 0x04000506 RID: 1286
	public bool showZone = true;

	// Token: 0x04000507 RID: 1287
	public bool showTouch = true;

	// Token: 0x04000508 RID: 1288
	public bool showDeadZone = true;

	// Token: 0x04000509 RID: 1289
	public Texture areaTexture;

	// Token: 0x0400050A RID: 1290
	public Texture touchTexture;

	// Token: 0x0400050B RID: 1291
	public Texture deadTexture;

	// Token: 0x0400050C RID: 1292
	public bool useBroadcast;

	// Token: 0x0400050D RID: 1293
	public Vector2 speed;

	// Token: 0x0400050E RID: 1294
	public EasyJoystick.InteractionType interaction;

	// Token: 0x0400050F RID: 1295
	[SerializeField]
	private Transform xAxisTransform;

	// Token: 0x04000510 RID: 1296
	public CharacterController xAxisCharacterController;

	// Token: 0x04000511 RID: 1297
	public float xAxisGravity;

	// Token: 0x04000512 RID: 1298
	public EasyJoystick.PropertiesInfluenced xTI;

	// Token: 0x04000513 RID: 1299
	public EasyJoystick.AxisInfluenced xAI;

	// Token: 0x04000514 RID: 1300
	public bool inverseXAxis;

	// Token: 0x04000515 RID: 1301
	[SerializeField]
	private Transform yAxisTransform;

	// Token: 0x04000516 RID: 1302
	public CharacterController yAxisCharacterController;

	// Token: 0x04000517 RID: 1303
	public float yAxisGravity;

	// Token: 0x04000518 RID: 1304
	public EasyJoystick.PropertiesInfluenced yTI;

	// Token: 0x04000519 RID: 1305
	public EasyJoystick.AxisInfluenced yAI;

	// Token: 0x0400051A RID: 1306
	public bool inverseYAxis;

	// Token: 0x0400051B RID: 1307
	private Vector2 joystickCenter;

	// Token: 0x0400051C RID: 1308
	private Vector2 joyTouch;

	// Token: 0x0400051D RID: 1309
	private bool virtualJoystick = true;

	// Token: 0x0400051E RID: 1310
	private int joystickIndex = -1;

	// Token: 0x0400051F RID: 1311
	private float touchSizeCoef;

	// Token: 0x04000520 RID: 1312
	private bool sendEnd;

	// Token: 0x04000521 RID: 1313
	public bool showProperties = true;

	// Token: 0x04000522 RID: 1314
	public bool showInteraction = true;

	// Token: 0x04000523 RID: 1315
	public bool showAppearance = true;

	// Token: 0x020000C1 RID: 193
	// (Invoke) Token: 0x060005A5 RID: 1445
	public delegate void JoystickMoveHandler(MovingJoystick move);

	// Token: 0x020000C2 RID: 194
	// (Invoke) Token: 0x060005A9 RID: 1449
	public delegate void JoystickMoveEndHandler(MovingJoystick move);

	// Token: 0x020000C3 RID: 195
	public enum PropertiesInfluenced
	{
		// Token: 0x04000525 RID: 1317
		Rotate,
		// Token: 0x04000526 RID: 1318
		RotateLocal,
		// Token: 0x04000527 RID: 1319
		Translate,
		// Token: 0x04000528 RID: 1320
		TranslateLocal,
		// Token: 0x04000529 RID: 1321
		Scale
	}

	// Token: 0x020000C4 RID: 196
	public enum AxisInfluenced
	{
		// Token: 0x0400052B RID: 1323
		X,
		// Token: 0x0400052C RID: 1324
		Y,
		// Token: 0x0400052D RID: 1325
		Z,
		// Token: 0x0400052E RID: 1326
		XYZ
	}

	// Token: 0x020000C5 RID: 197
	public enum DynamicArea
	{
		// Token: 0x04000530 RID: 1328
		FullScreen,
		// Token: 0x04000531 RID: 1329
		Left,
		// Token: 0x04000532 RID: 1330
		Right,
		// Token: 0x04000533 RID: 1331
		Top,
		// Token: 0x04000534 RID: 1332
		Bottom,
		// Token: 0x04000535 RID: 1333
		TopLeft,
		// Token: 0x04000536 RID: 1334
		TopRight,
		// Token: 0x04000537 RID: 1335
		BottomLeft,
		// Token: 0x04000538 RID: 1336
		BottomRight
	}

	// Token: 0x020000C6 RID: 198
	public enum InteractionType
	{
		// Token: 0x0400053A RID: 1338
		Direct,
		// Token: 0x0400053B RID: 1339
		Include,
		// Token: 0x0400053C RID: 1340
		EventNotification,
		// Token: 0x0400053D RID: 1341
		DirectAndEvent
	}

	// Token: 0x020000C7 RID: 199
	public enum Broadcast
	{
		// Token: 0x0400053F RID: 1343
		SendMessage,
		// Token: 0x04000540 RID: 1344
		SendMessageUpwards,
		// Token: 0x04000541 RID: 1345
		BroadcastMessage
	}

	// Token: 0x020000C8 RID: 200
	private enum MessageName
	{
		// Token: 0x04000543 RID: 1347
		On_JoystickMove,
		// Token: 0x04000544 RID: 1348
		On_JoystickMoveEnd
	}
}
