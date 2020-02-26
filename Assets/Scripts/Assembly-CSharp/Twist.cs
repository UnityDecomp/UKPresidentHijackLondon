using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
public class Twist : MonoBehaviour
{
	// Token: 0x06000542 RID: 1346 RVA: 0x00027AB0 File Offset: 0x00025EB0
	private void OnEnable()
	{
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_Twist += this.On_Twist;
		EasyTouch.On_TwistEnd += this.On_TwistEnd;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00027B01 File Offset: 0x00025F01
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x00027B09 File Offset: 0x00025F09
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x00027B14 File Offset: 0x00025F14
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_Twist -= this.On_Twist;
		EasyTouch.On_TwistEnd -= this.On_TwistEnd;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x00027B65 File Offset: 0x00025F65
	private void Start()
	{
		this.textMesh = (base.transform.Find("TextTwist").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x00027B96 File Offset: 0x00025F96
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			EasyTouch.SetEnablePinch(false);
			EasyTouch.SetEnableTwist(true);
		}
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x00027BBC File Offset: 0x00025FBC
	private void On_Twist(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.transform.Rotate(new Vector3(0f, 0f, gesture.twistAngle));
			this.textMesh.text = "Delta angle : " + gesture.twistAngle.ToString();
		}
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x00027C25 File Offset: 0x00026025
	private void On_TwistEnd(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			EasyTouch.SetEnablePinch(true);
			base.transform.rotation = Quaternion.identity;
			this.textMesh.text = "Twist me";
		}
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x00027C63 File Offset: 0x00026063
	private void On_Cancel2Fingers(Gesture gesture)
	{
		EasyTouch.SetEnablePinch(true);
		base.transform.rotation = Quaternion.identity;
		this.textMesh.text = "Twist me";
	}

	// Token: 0x040004EC RID: 1260
	private TextMesh textMesh;
}
