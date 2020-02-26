using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000224 RID: 548
public class WeatherSystem : MonoBehaviour
{
	// Token: 0x06000DFF RID: 3583 RVA: 0x0005995E File Offset: 0x00057D5E
	private void Start()
	{
		this.player = base.GetComponent<dogsactive>().getActivePlayer();
		this.startCounter();
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x00059977 File Offset: 0x00057D77
	public void startCounter()
	{
		this.snow.SetActive(false);
		base.StartCoroutine(this.wait());
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x00059994 File Offset: 0x00057D94
	private IEnumerator wait()
	{
		yield return new WaitForSeconds(this.delay);
		if (this.player)
		{
			this.snow.transform.position = new Vector3(this.player.transform.position.x, this.snow.transform.position.y, this.player.transform.position.z);
			this.snow.SetActive(true);
			yield return new WaitForSeconds(this.delay + 5f);
			this.startCounter();
		}
		yield break;
	}

	// Token: 0x04000EEA RID: 3818
	public GameObject snow;

	// Token: 0x04000EEB RID: 3819
	public float delay = 20f;

	// Token: 0x04000EEC RID: 3820
	private GameObject player;
}
