using System;
using UnityEngine;

// Token: 0x020000BF RID: 191
public class TwoTouchStart : MonoBehaviour
{
	// Token: 0x06000576 RID: 1398 RVA: 0x0002853C File Offset: 0x0002693C
	private void OnEnable()
	{
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers += this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers += this.On_TouchUp2Fingers;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x0002858D File Offset: 0x0002698D
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x00028595 File Offset: 0x00026995
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x000285A0 File Offset: 0x000269A0
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers -= this.On_TouchUp2Fingers;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x000285F1 File Offset: 0x000269F1
	private void Start()
	{
		this.textMesh = (base.transform.Find("TexttouchStart").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x00028624 File Offset: 0x00026A24
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}

	// Token: 0x0600057C RID: 1404 RVA: 0x0002868E File Offset: 0x00026A8E
	private void On_TouchDown2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			this.textMesh.text = "Down since :" + gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x000286CC File Offset: 0x00026ACC
	private void On_TouchUp2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = Color.white;
			this.textMesh.text = "Touch Start/Up";
		}
	}

	// Token: 0x0600057E RID: 1406 RVA: 0x0002871C File Offset: 0x00026B1C
	private void On_Cancel2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = Color.white;
			this.textMesh.text = "Touch Start/Up";
		}
	}

	// Token: 0x040004F2 RID: 1266
	private TextMesh textMesh;
}
