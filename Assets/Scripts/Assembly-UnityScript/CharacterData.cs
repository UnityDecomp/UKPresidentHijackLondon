using System;
using UnityEngine;

// Token: 0x0200002C RID: 44
[Serializable]
public class CharacterData : MonoBehaviour
{
	// Token: 0x06000075 RID: 117 RVA: 0x00006BB0 File Offset: 0x00004DB0
	public CharacterData()
	{
		this.player = new PlayerData[3];
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00006BC4 File Offset: 0x00004DC4
	public virtual void Main()
	{
	}

	// Token: 0x040000F7 RID: 247
	public PlayerData[] player;
}
