using System;
using UnityEngine;

// Token: 0x020001DF RID: 479
public class DayNight : MonoBehaviour
{
	// Token: 0x06000C6B RID: 3179 RVA: 0x0004E84B File Offset: 0x0004CC4B
	private void Start()
	{
		this.MainCam = this.Cams[gameplay.count];
	}

	// Token: 0x06000C6C RID: 3180 RVA: 0x0004E85F File Offset: 0x0004CC5F
	private void Update()
	{
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x0004E861 File Offset: 0x0004CC61
	public void startDay()
	{
		this.Day.SetActive(true);
		this.Night.SetActive(false);
		this.MainCam.SetActive(true);
		this.NightCam.SetActive(false);
	}

	// Token: 0x06000C6E RID: 3182 RVA: 0x0004E893 File Offset: 0x0004CC93
	public void startNight()
	{
		this.Day.SetActive(false);
		this.Night.SetActive(true);
		this.MainCam.SetActive(false);
		this.NightCam.SetActive(true);
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x0004E8C5 File Offset: 0x0004CCC5
	public void Sleep()
	{
		base.GetComponent<dogsactive>().getActivePlayer().GetComponent<PlayerInputControllerC>().Sleep();
	}

	// Token: 0x04000CD7 RID: 3287
	public GameObject Day;

	// Token: 0x04000CD8 RID: 3288
	public GameObject Night;

	// Token: 0x04000CD9 RID: 3289
	public GameObject[] Cams = new GameObject[3];

	// Token: 0x04000CDA RID: 3290
	[HideInInspector]
	public GameObject MainCam;

	// Token: 0x04000CDB RID: 3291
	public GameObject NightCam;

	// Token: 0x04000CDC RID: 3292
	private bool startFlow = true;
}
