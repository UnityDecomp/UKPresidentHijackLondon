using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
public class CheckPointC : MonoBehaviour
{
	// Token: 0x06000365 RID: 869 RVA: 0x00010F05 File Offset: 0x0000F305
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.player = other.gameObject;
			this.SaveData();
		}
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00010F34 File Offset: 0x0000F334
	private void SaveData()
	{
		PlayerPrefs.SetInt("PreviousSave", 10);
		PlayerPrefs.SetFloat("PlayerX", this.player.transform.position.x);
		PlayerPrefs.SetFloat("PlayerY", this.player.transform.position.y);
		PlayerPrefs.SetFloat("PlayerZ", this.player.transform.position.z);
		MonoBehaviour.print("Saved");
	}

	// Token: 0x04000269 RID: 617
	private GameObject player;
}
