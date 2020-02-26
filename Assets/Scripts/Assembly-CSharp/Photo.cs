using System;
using UnityEngine;

// Token: 0x020000A8 RID: 168
public class Photo : MonoBehaviour
{
	// Token: 0x060004D0 RID: 1232 RVA: 0x00025D54 File Offset: 0x00024154
	private void OnEnable()
	{
		EasyTouch.On_DragStart += this.On_DragStart;
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers += this.On_TouchDown2Fingers;
		EasyTouch.On_PinchIn += this.On_PinchIn;
		EasyTouch.On_PinchOut += this.On_PinchOut;
		EasyTouch.On_Twist += this.On_Twist;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x00025DE9 File Offset: 0x000241E9
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x00025DF1 File Offset: 0x000241F1
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x00025DFC File Offset: 0x000241FC
	private void UnsubscribeEvent()
	{
		EasyTouch.On_DragStart -= this.On_DragStart;
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
		EasyTouch.On_PinchIn -= this.On_PinchIn;
		EasyTouch.On_PinchOut -= this.On_PinchOut;
		EasyTouch.On_Twist -= this.On_Twist;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x00025E91 File Offset: 0x00024291
	private void On_Cancel2Fingers(Gesture gesture)
	{
		if (gesture.touchCount > 0)
		{
			this.newPivot = true;
		}
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x00025EA8 File Offset: 0x000242A8
	private void On_DragStart(Gesture gesture)
	{
		if (gesture.touchCount == 1)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(1f);
			this.deltaPosition = touchToWordlPoint - base.transform.position;
		}
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x00025EE4 File Offset: 0x000242E4
	private void On_Drag(Gesture gesture)
	{
		if (gesture.touchCount == 1)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(1f);
			if (this.newPivot)
			{
				this.deltaPosition = touchToWordlPoint - base.transform.position;
				this.newPivot = false;
			}
			base.transform.position = touchToWordlPoint - this.deltaPosition;
		}
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x00025F4C File Offset: 0x0002434C
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(1f);
		this.deltaPosition = touchToWordlPoint - base.transform.position;
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x00025F7C File Offset: 0x0002437C
	private void On_TouchDown2Fingers(Gesture gesture)
	{
		Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(1f);
		base.transform.position = touchToWordlPoint - this.deltaPosition;
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x00025FAC File Offset: 0x000243AC
	private void On_PinchIn(Gesture gesture)
	{
		float num = Time.deltaTime * gesture.deltaPinch / 25f;
		Vector3 localScale = base.transform.localScale;
		if ((double)(localScale.x - num) > 0.1)
		{
			base.transform.localScale = new Vector3(localScale.x - num, localScale.y - num, 1f);
		}
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x00026018 File Offset: 0x00024418
	private void On_PinchOut(Gesture gesture)
	{
		float num = Time.deltaTime * gesture.deltaPinch / 25f;
		Vector3 localScale = base.transform.localScale;
		if (localScale.x + num < 3f)
		{
			base.transform.localScale = new Vector3(localScale.x + num, localScale.y + num, 1f);
		}
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x0002607E File Offset: 0x0002447E
	private void On_Twist(Gesture gesture)
	{
		base.transform.Rotate(new Vector3(0f, 0f, gesture.twistAngle));
	}

	// Token: 0x040004DE RID: 1246
	private Vector3 deltaPosition;

	// Token: 0x040004DF RID: 1247
	private Vector3 rotation;

	// Token: 0x040004E0 RID: 1248
	private bool newPivot;
}
