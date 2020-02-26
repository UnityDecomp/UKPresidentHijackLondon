using System;
using UnityEngine;

// Token: 0x020000A3 RID: 163
[AddComponentMenu("Action-RPG Kit/Create Teleporter")]
[Serializable]
public class Teleporter : MonoBehaviour
{
	// Token: 0x06000234 RID: 564 RVA: 0x0001BFA4 File Offset: 0x0001A1A4
	public Teleporter()
	{
		this.teleportToMap = "Level1";
		this.spawnPointName = "PlayerSpawnPoint";
	}

	// Token: 0x06000235 RID: 565 RVA: 0x0001BFC4 File Offset: 0x0001A1C4
	public virtual void Start()
	{
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0001BFC8 File Offset: 0x0001A1C8
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			((Status)other.GetComponent(typeof(Status))).spawnPointName = this.spawnPointName;
			this.ChangeMap();
		}
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0001C010 File Offset: 0x0001A210
	public virtual void ChangeMap()
	{
		Application.LoadLevel(this.teleportToMap);
	}

	// Token: 0x06000238 RID: 568 RVA: 0x0001C020 File Offset: 0x0001A220
	public virtual void Main()
	{
	}

	// Token: 0x040003A8 RID: 936
	public string teleportToMap;

	// Token: 0x040003A9 RID: 937
	public string spawnPointName;
}
