using System;
using UnityEngine;

// Token: 0x0200002B RID: 43
[Serializable]
public class PlayerData
{
	// Token: 0x06000074 RID: 116 RVA: 0x00006B9C File Offset: 0x00004D9C
	public PlayerData()
	{
		this.playerName = string.Empty;
	}

	// Token: 0x040000F2 RID: 242
	public string playerName;

	// Token: 0x040000F3 RID: 243
	public GameObject playerPrefab;

	// Token: 0x040000F4 RID: 244
	public GameObject characterSelectModel;

	// Token: 0x040000F5 RID: 245
	public TextDialogue description;

	// Token: 0x040000F6 RID: 246
	public Texture2D guiDescription;
}
