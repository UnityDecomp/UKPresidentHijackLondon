using System;
using UnityEngine;

// Token: 0x02000098 RID: 152
public class TeleporterC : MonoBehaviour
{
	// Token: 0x06000489 RID: 1161 RVA: 0x00023176 File Offset: 0x00021576
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<StatusC>().spawnPointName = this.spawnPointName;
			this.ChangeMap();
		}
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x000231A4 File Offset: 0x000215A4
	private void ChangeMap()
	{
		Application.LoadLevel(this.teleportToMap);
	}

	// Token: 0x0400048D RID: 1165
	public string teleportToMap = "Level1";

	// Token: 0x0400048E RID: 1166
	public string spawnPointName = "PlayerSpawn1";
}
