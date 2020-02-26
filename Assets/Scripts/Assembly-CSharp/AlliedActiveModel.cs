using System;
using UnityEngine;

// Token: 0x020001D3 RID: 467
public class AlliedActiveModel : MonoBehaviour
{
	// Token: 0x06000C2A RID: 3114 RVA: 0x0004CD98 File Offset: 0x0004B198
	private void Awake()
	{
		if (CharacterSelection.characterID == 0)
		{
			if (gameplay.count == 0)
			{
				this.ally1models[1].SetActive(true);
				this.ally1.GetComponent<AIfriendC>().mainModel = this.ally1models[1];
				this.ally2models[2].SetActive(true);
				this.ally2.GetComponent<AIfriendC>().mainModel = this.ally2models[2];
			}
			if (gameplay.count == 1)
			{
				this.ally1models[0].SetActive(true);
				this.ally1.GetComponent<AIfriendC>().mainModel = this.ally1models[0];
				this.ally2models[2].SetActive(true);
				this.ally2.GetComponent<AIfriendC>().mainModel = this.ally2models[2];
			}
			if (gameplay.count == 2)
			{
				this.ally1models[0].SetActive(true);
				this.ally1.GetComponent<AIfriendC>().mainModel = this.ally1models[0];
				this.ally2models[1].SetActive(true);
				this.ally2.GetComponent<AIfriendC>().mainModel = this.ally2models[1];
			}
		}
		if (CharacterSelection.characterID == 1)
		{
			if (gameplay.count == 0)
			{
				this.ally1models[4].SetActive(true);
				this.ally1.GetComponent<AIfriendC>().mainModel = this.ally1models[4];
				this.ally2models[5].SetActive(true);
				this.ally2.GetComponent<AIfriendC>().mainModel = this.ally2models[5];
			}
			if (gameplay.count == 1)
			{
				this.ally1models[3].SetActive(true);
				this.ally1.GetComponent<AIfriendC>().mainModel = this.ally1models[3];
				this.ally2models[5].SetActive(true);
				this.ally2.GetComponent<AIfriendC>().mainModel = this.ally2models[5];
			}
			if (gameplay.count == 2)
			{
				this.ally1models[3].SetActive(true);
				this.ally1.GetComponent<AIfriendC>().mainModel = this.ally1models[3];
				this.ally2models[4].SetActive(true);
				this.ally2.GetComponent<AIfriendC>().mainModel = this.ally2models[4];
			}
		}
	}

	// Token: 0x04000C8B RID: 3211
	public GameObject ally1;

	// Token: 0x04000C8C RID: 3212
	public GameObject ally2;

	// Token: 0x04000C8D RID: 3213
	public GameObject[] ally1models;

	// Token: 0x04000C8E RID: 3214
	public GameObject[] ally2models;
}
