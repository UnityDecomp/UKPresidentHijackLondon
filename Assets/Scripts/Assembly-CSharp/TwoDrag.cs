using System;
using UnityEngine;

// Token: 0x020000BB RID: 187
public class TwoDrag : MonoBehaviour
{
	// Token: 0x06000552 RID: 1362 RVA: 0x00027D40 File Offset: 0x00026140
	private void OnEnable()
	{
		EasyTouch.On_DragStart2Fingers += this.On_DragStart2Fingers;
		EasyTouch.On_Drag2Fingers += this.On_Drag2Fingers;
		EasyTouch.On_DragEnd2Fingers += this.On_DragEnd2Fingers;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00027D91 File Offset: 0x00026191
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x00027D99 File Offset: 0x00026199
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x00027DA4 File Offset: 0x000261A4
	private void UnsubscribeEvent()
	{
		EasyTouch.On_DragStart2Fingers -= this.On_DragStart2Fingers;
		EasyTouch.On_Drag2Fingers -= this.On_Drag2Fingers;
		EasyTouch.On_DragEnd2Fingers -= this.On_DragEnd2Fingers;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x00027DF5 File Offset: 0x000261F5
	private void Start()
	{
		this.textMesh = (base.transform.Find("TextDrag").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x00027E28 File Offset: 0x00026228
	private void On_DragStart2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			this.deltaPosition = touchToWordlPoint - base.transform.position;
		}
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x00027EB8 File Offset: 0x000262B8
	private void On_Drag2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			base.transform.position = touchToWordlPoint - this.deltaPosition;
			float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
			this.textMesh.text = gesture.swipe.ToString() + " / angle :" + swipeOrDragAngle.ToString("f2");
		}
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x00027F38 File Offset: 0x00026338
	private void On_DragEnd2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.transform.position = new Vector3(2.5f, -0.5f, -5f);
			base.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
			this.textMesh.text = "Drag me";
		}
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x00027FB4 File Offset: 0x000263B4
	private void On_Cancel2Fingers(Gesture gesture)
	{
		base.transform.position = new Vector3(2.5f, -0.5f, -5f);
		base.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
		this.textMesh.text = "Drag me";
	}

	// Token: 0x040004ED RID: 1261
	private TextMesh textMesh;

	// Token: 0x040004EE RID: 1262
	private Vector3 deltaPosition;
}
