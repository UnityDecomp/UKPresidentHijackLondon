using System;
using UnityEngine;

// Token: 0x020000BC RID: 188
public class TwoLongTap : MonoBehaviour
{
	// Token: 0x0600055C RID: 1372 RVA: 0x00028024 File Offset: 0x00026424
	private void OnEnable()
	{
		EasyTouch.On_LongTapStart2Fingers += this.On_LongTapStart2Fingers;
		EasyTouch.On_LongTap2Fingers += this.On_LongTap2Fingers;
		EasyTouch.On_LongTapEnd2Fingers += this.On_LongTapEnd2Fingers;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x00028075 File Offset: 0x00026475
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x0002807D File Offset: 0x0002647D
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x00028088 File Offset: 0x00026488
	private void UnsubscribeEvent()
	{
		EasyTouch.On_LongTapStart2Fingers -= this.On_LongTapStart2Fingers;
		EasyTouch.On_LongTap2Fingers -= this.On_LongTap2Fingers;
		EasyTouch.On_LongTapEnd2Fingers -= this.On_LongTapEnd2Fingers;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x000280D9 File Offset: 0x000264D9
	private void Start()
	{
		this.textMesh = (base.transform.Find("TextLongTap").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0002810C File Offset: 0x0002650C
	private void On_LongTapStart2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x00028176 File Offset: 0x00026576
	private void On_LongTap2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			this.textMesh.text = gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x000281AC File Offset: 0x000265AC
	private void On_LongTapEnd2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
			this.textMesh.text = "Long tap";
		}
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x00028208 File Offset: 0x00026608
	private void On_Cancel2Fingers(Gesture gesture)
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
		this.textMesh.text = "Long tap";
	}

	// Token: 0x040004EF RID: 1263
	private TextMesh textMesh;
}
