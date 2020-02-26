using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
[Serializable]
public class cameraViewObject1 : MonoBehaviour
{
	// Token: 0x0600025C RID: 604 RVA: 0x0001DC7C File Offset: 0x0001BE7C
	public virtual void Start()
	{
	}

	// Token: 0x0600025D RID: 605 RVA: 0x0001DC80 File Offset: 0x0001BE80
	public virtual void Update()
	{
		bool flag = false;
		if (this.guiObject != null)
		{
			GUITexture[] componentsInChildren = this.guiObject.GetComponentsInChildren<GUITexture>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].HitTest(Input.mousePosition))
				{
					flag = true;
				}
			}
		}
		if (!flag && (Input.GetMouseButton(0) || Input.GetMouseButton(1)))
		{
			this.rotationVelocity.x = this.rotationVelocity.x + Mathf.Pow(Mathf.Abs(Input.GetAxis("Mouse X")), 1.5f) * Mathf.Sign(Input.GetAxis("Mouse X"));
			this.rotationVelocity.y = this.rotationVelocity.y - Input.GetAxis("Mouse Y") * 0.04f;
		}
		float y = this.transform.position.y + this.rotationVelocity.y;
		Vector3 position = this.transform.position;
		float num = position.y = y;
		Vector3 vector = this.transform.position = position;
		this.transform.RotateAround(Vector3.zero, Vector3.up, this.rotationVelocity.x);
		this.rotationVelocity = Vector2.Lerp(this.rotationVelocity, Vector2.zero, Time.deltaTime * 10f);
		float y2 = Mathf.Clamp(this.transform.position.y, (float)0, (float)5);
		Vector3 position2 = this.transform.position;
		float num2 = position2.y = y2;
		Vector3 vector2 = this.transform.position = position2;
		this.transform.LookAt(new Vector3((float)0, (float)1, (float)0));
	}

	// Token: 0x0600025E RID: 606 RVA: 0x0001DE58 File Offset: 0x0001C058
	public virtual void Main()
	{
	}

	// Token: 0x040003E7 RID: 999
	public GameObject guiObject;

	// Token: 0x040003E8 RID: 1000
	private Vector2 rotationVelocity;
}
