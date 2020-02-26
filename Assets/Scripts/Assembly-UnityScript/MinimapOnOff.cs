using System;
using UnityEngine;

// Token: 0x0200005E RID: 94
[Serializable]
public class MinimapOnOff : MonoBehaviour
{
	// Token: 0x06000128 RID: 296 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
	public MinimapOnOff()
	{
		this.state = true;
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
	public virtual void Update()
	{
		if (Input.GetKeyDown("m") && this.minimapCam)
		{
			this.OnOffCamera();
		}
	}

	// Token: 0x0600012A RID: 298 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
	public virtual void OnOffCamera()
	{
		if (this.minimapCam.activeSelf)
		{
			this.minimapCam.SetActive(false);
		}
		else
		{
			this.minimapCam.SetActive(true);
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0000F52C File Offset: 0x0000D72C
	public virtual void Main()
	{
	}

	// Token: 0x0400020E RID: 526
	public GameObject minimapCam;

	// Token: 0x0400020F RID: 527
	private bool state;
}
