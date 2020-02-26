using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class Pinch : MonoBehaviour
{
	// Token: 0x06000537 RID: 1335 RVA: 0x00027800 File Offset: 0x00025C00
	private void OnEnable()
	{
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_PinchIn += this.On_PinchIn;
		EasyTouch.On_PinchOut += this.On_PinchOut;
		EasyTouch.On_PinchEnd += this.On_PinchEnd;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x00027862 File Offset: 0x00025C62
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x0002786A File Offset: 0x00025C6A
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x00027874 File Offset: 0x00025C74
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_PinchIn -= this.On_PinchIn;
		EasyTouch.On_PinchOut -= this.On_PinchOut;
		EasyTouch.On_PinchEnd -= this.On_PinchEnd;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x000278D6 File Offset: 0x00025CD6
	private void Start()
	{
		this.textMesh = (base.transform.Find("TextPinch").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x00027907 File Offset: 0x00025D07
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			EasyTouch.SetEnableTwist(false);
			EasyTouch.SetEnablePinch(true);
		}
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x0002792C File Offset: 0x00025D2C
	private void On_PinchIn(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			float num = Time.deltaTime * gesture.deltaPinch;
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = new Vector3(localScale.x - num, localScale.y - num, localScale.z - num);
			this.textMesh.text = "Delta pinch : " + gesture.deltaPinch.ToString();
		}
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x000279BC File Offset: 0x00025DBC
	private void On_PinchOut(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			float num = Time.deltaTime * gesture.deltaPinch;
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = new Vector3(localScale.x + num, localScale.y + num, localScale.z + num);
			this.textMesh.text = "Delta pinch : " + gesture.deltaPinch.ToString();
		}
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x00027A4C File Offset: 0x00025E4C
	private void On_PinchEnd(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
			EasyTouch.SetEnableTwist(true);
			this.textMesh.text = "Pinch me";
		}
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x00027AA4 File Offset: 0x00025EA4
	private void On_Cancel2Fingers(Gesture gesture)
	{
	}

	// Token: 0x040004EB RID: 1259
	private TextMesh textMesh;
}
