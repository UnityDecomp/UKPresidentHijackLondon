using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
public class TouchLayer : MonoBehaviour
{
	// Token: 0x060004DF RID: 1247 RVA: 0x0002614E File Offset: 0x0002454E
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x00026161 File Offset: 0x00024561
	private void OnDisable()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x00026174 File Offset: 0x00024574
	private void OnDestroy()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x00026187 File Offset: 0x00024587
	private void Start()
	{
		this.textMesh = (TextMesh)GameObject.Find("TouchOnLayer").transform.gameObject.GetComponent("TextMesh");
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x000261B4 File Offset: 0x000245B4
	public void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickObject != null)
		{
			gesture.pickObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
			this.textMesh.text = "Touch a sphere on layer :" + LayerMask.LayerToName(gesture.pickObject.layer);
		}
		else
		{
			this.textMesh.text = "Touch a sphere on layer :";
		}
	}

	// Token: 0x040004E1 RID: 1249
	private TextMesh textMesh;
}
