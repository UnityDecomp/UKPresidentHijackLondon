using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class LongTap : MonoBehaviour
{
	// Token: 0x06000510 RID: 1296 RVA: 0x00026FEA File Offset: 0x000253EA
	private void OnEnable()
	{
		EasyTouch.On_LongTapStart += this.On_LongTapStart;
		EasyTouch.On_LongTap += this.On_LongTap;
		EasyTouch.On_LongTapEnd += this.On_LongTapEnd;
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x0002701F File Offset: 0x0002541F
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00027027 File Offset: 0x00025427
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x0002702F File Offset: 0x0002542F
	private void UnsubscribeEvent()
	{
		EasyTouch.On_LongTapStart -= this.On_LongTapStart;
		EasyTouch.On_LongTap -= this.On_LongTap;
		EasyTouch.On_LongTapEnd -= this.On_LongTapEnd;
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00027064 File Offset: 0x00025464
	private void Start()
	{
		this.textMesh = (base.transform.Find("TextLongTap").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x00027098 File Offset: 0x00025498
	private void On_LongTapStart(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00027102 File Offset: 0x00025502
	private void On_LongTap(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			this.textMesh.text = gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x00027138 File Offset: 0x00025538
	private void On_LongTapEnd(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = Color.white;
			this.textMesh.text = "Long tap";
		}
	}

	// Token: 0x040004E7 RID: 1255
	private TextMesh textMesh;
}
