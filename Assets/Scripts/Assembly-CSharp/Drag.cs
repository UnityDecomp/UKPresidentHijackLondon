using System;
using UnityEngine;

// Token: 0x020000B0 RID: 176
public class Drag : MonoBehaviour
{
	// Token: 0x06000505 RID: 1285 RVA: 0x00026D12 File Offset: 0x00025112
	private void OnEnable()
	{
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_DragStart += this.On_DragStart;
		EasyTouch.On_DragEnd += this.On_DragEnd;
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x00026D47 File Offset: 0x00025147
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x00026D4F File Offset: 0x0002514F
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00026D57 File Offset: 0x00025157
	private void UnsubscribeEvent()
	{
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_DragStart -= this.On_DragStart;
		EasyTouch.On_DragEnd -= this.On_DragEnd;
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x00026D8C File Offset: 0x0002518C
	private void Start()
	{
		this.textMesh = (base.transform.Find("TextDrag").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00026DC0 File Offset: 0x000251C0
	private void On_DragStart(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			this.deltaPosition = touchToWordlPoint - base.transform.position;
		}
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x00026E50 File Offset: 0x00025250
	private void On_Drag(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			base.transform.position = touchToWordlPoint - this.deltaPosition;
			float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
			this.textMesh.text = gesture.swipe.ToString() + " / angle :" + swipeOrDragAngle.ToString("f2");
		}
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00026ED0 File Offset: 0x000252D0
	private void On_DragEnd(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.transform.position = new Vector3(3f, 1.8f, -5f);
			base.gameObject.GetComponent<Renderer>().material.color = Color.white;
			this.textMesh.text = "Drag me";
		}
	}

	// Token: 0x040004E5 RID: 1253
	private TextMesh textMesh;

	// Token: 0x040004E6 RID: 1254
	private Vector3 deltaPosition;
}
