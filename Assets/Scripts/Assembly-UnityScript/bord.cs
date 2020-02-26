using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
[Serializable]
public class bord : MonoBehaviour
{
	// Token: 0x06000260 RID: 608 RVA: 0x0001DE64 File Offset: 0x0001C064
	public virtual void Start()
	{
		this.cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		if (this.type == 1)
		{
			this.transform.position = this.cam.ScreenToWorldPoint(new Vector3((float)0, (float)0, (float)8));
		}
		else if (this.type == 2)
		{
			this.transform.position = this.cam.ScreenToWorldPoint(new Vector3((float)Screen.width, (float)0, (float)8));
		}
	}

	// Token: 0x06000261 RID: 609 RVA: 0x0001DEEC File Offset: 0x0001C0EC
	public virtual void Main()
	{
	}

	// Token: 0x040003E9 RID: 1001
	public int type;

	// Token: 0x040003EA RID: 1002
	private Camera cam;
}
