using System;
using UnityEngine;

// Token: 0x02000075 RID: 117
public class MinimapOnOffC : MonoBehaviour
{
	// Token: 0x060003C0 RID: 960 RVA: 0x00016FBF File Offset: 0x000153BF
	private void Update()
	{
		if (Input.GetKeyDown("m") && this.minimapCam)
		{
			this.OnOffCamera();
		}
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00016FE6 File Offset: 0x000153E6
	private void OnOffCamera()
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

	// Token: 0x04000321 RID: 801
	public GameObject minimapCam;
}
