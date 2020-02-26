using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class ScreenTouch : MonoBehaviour
{
	// Token: 0x060004F6 RID: 1270 RVA: 0x0002694B File Offset: 0x00024D4B
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x0002695E File Offset: 0x00024D5E
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x00026966 File Offset: 0x00024D66
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x0002696E File Offset: 0x00024D6E
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x00026984 File Offset: 0x00024D84
	private void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickObject == null)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(8f);
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("GlowDisk01"), touchToWordlPoint, Quaternion.identity) as GameObject;
			float num = UnityEngine.Random.Range(0.5f, 0.8f);
			gameObject.transform.localScale = new Vector3(num, num, num);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Spot"), touchToWordlPoint, Quaternion.identity) as GameObject;
			gameObject2.transform.localScale = gameObject.transform.localScale / 2f;
			gameObject2.transform.parent = gameObject.transform;
			int num2 = UnityEngine.Random.Range(1, 6);
			Color white = Color.white;
			switch (num2)
			{
			case 1:
				white = new Color(1f, UnityEngine.Random.Range(0f, 0.8f), UnityEngine.Random.Range(0f, 0.8f), UnityEngine.Random.Range(0.3f, 0.9f));
				break;
			case 2:
				white = new Color(UnityEngine.Random.Range(0f, 0.8f), 1f, UnityEngine.Random.Range(0f, 0.8f), UnityEngine.Random.Range(0.3f, 0.9f));
				break;
			case 3:
				white = new Color(UnityEngine.Random.Range(0f, 0.8f), 1f, 1f, UnityEngine.Random.Range(0.3f, 0.9f));
				break;
			case 4:
				white = new Color(1f, UnityEngine.Random.Range(0f, 0.8f), 1f, UnityEngine.Random.Range(0.3f, 0.9f));
				break;
			case 5:
				white = new Color(1f, UnityEngine.Random.Range(0f, 0.8f), UnityEngine.Random.Range(0f, 0.8f), UnityEngine.Random.Range(0.3f, 0.9f));
				break;
			case 6:
				white = new Color(UnityEngine.Random.Range(0f, 0.8f), UnityEngine.Random.Range(0f, 0.8f), 1f, UnityEngine.Random.Range(0.3f, 0.9f));
				break;
			}
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", white);
			gameObject2.GetComponent<Renderer>().material.SetColor("_TintColor", white);
			gameObject.layer = 8;
			gameObject.AddComponent<ObjectTouch>();
			gameObject.GetComponent<Rigidbody>().mass = num;
		}
	}
}
