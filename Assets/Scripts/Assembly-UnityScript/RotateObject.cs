using System;
using UnityEngine;

// Token: 0x0200007F RID: 127
[Serializable]
public class RotateObject : MonoBehaviour
{
	// Token: 0x060001AD RID: 429 RVA: 0x00013644 File Offset: 0x00011844
	public RotateObject()
	{
		this.rotateY = 5f;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00013658 File Offset: 0x00011858
	public virtual void Update()
	{
		this.transform.Rotate(this.rotateX * Time.deltaTime, this.rotateY * Time.deltaTime, this.rotateZ * Time.deltaTime);
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00013694 File Offset: 0x00011894
	public virtual void Main()
	{
	}

	// Token: 0x040002D2 RID: 722
	public float rotateX;

	// Token: 0x040002D3 RID: 723
	public float rotateY;

	// Token: 0x040002D4 RID: 724
	public float rotateZ;
}
