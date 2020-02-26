using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
[Serializable]
public class DontDestroyOnload : MonoBehaviour
{
	// Token: 0x060000C5 RID: 197 RVA: 0x0000A100 File Offset: 0x00008300
	public virtual void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this.transform.gameObject);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x0000A114 File Offset: 0x00008314
	public virtual void Main()
	{
	}
}
