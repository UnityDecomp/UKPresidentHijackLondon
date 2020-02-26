using System;
using UnityEngine;

// Token: 0x020000B5 RID: 181
public class TouchStart : MonoBehaviour
{
	// Token: 0x06000528 RID: 1320 RVA: 0x0002740E File Offset: 0x0002580E
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchUp += this.On_TouchUp;
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00027443 File Offset: 0x00025843
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x0002744B File Offset: 0x0002584B
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x00027453 File Offset: 0x00025853
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00027488 File Offset: 0x00025888
	private void Start()
	{
		this.textMesh = (TextMesh)base.transform.Find("TexttouchStart").transform.gameObject.GetComponent("TextMesh");
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x000274BC File Offset: 0x000258BC
	public void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x00027526 File Offset: 0x00025926
	public void On_TouchDown(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			this.textMesh.text = "Down since :" + gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00027564 File Offset: 0x00025964
	public void On_TouchUp(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
			this.textMesh.text = "Touch Start/Up";
		}
	}

	// Token: 0x040004EA RID: 1258
	private TextMesh textMesh;
}
