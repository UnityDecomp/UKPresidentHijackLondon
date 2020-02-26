using System;
using UnityEngine;

// Token: 0x02000080 RID: 128
public class QuestDataC : MonoBehaviour
{
	// Token: 0x06000413 RID: 1043 RVA: 0x0001AB3C File Offset: 0x00018F3C
	public void QuestClear(int id, GameObject player)
	{
		player.GetComponent<InventoryC>().cash += this.questData[id].rewardCash;
		player.GetComponent<StatusC>().gainEXP(this.questData[id].rewardExp);
		if (this.questData[id].rewardItemID.Length > 0)
		{
			for (int i = 0; i < this.questData[id].rewardItemID.Length; i++)
			{
				player.GetComponent<InventoryC>().AddItem(this.questData[id].rewardItemID[i], 1);
			}
		}
		if (this.questData[id].rewardEquipmentID.Length > 0)
		{
			for (int i = 0; i < this.questData[id].rewardEquipmentID.Length; i++)
			{
				player.GetComponent<InventoryC>().AddEquipment(this.questData[id].rewardEquipmentID[i]);
			}
		}
	}

	// Token: 0x040003CB RID: 971
	public GameObject itemData;

	// Token: 0x040003CC RID: 972
	public QuestDataC.Quest[] questData = new QuestDataC.Quest[3];

	// Token: 0x02000081 RID: 129
	[Serializable]
	public class Quest
	{
		// Token: 0x040003CD RID: 973
		public string questName = string.Empty;

		// Token: 0x040003CE RID: 974
		public Texture2D icon;

		// Token: 0x040003CF RID: 975
		public string description;

		// Token: 0x040003D0 RID: 976
		public int finishProgress = 5;

		// Token: 0x040003D1 RID: 977
		public int rewardCash = 100;

		// Token: 0x040003D2 RID: 978
		public int rewardExp = 100;

		// Token: 0x040003D3 RID: 979
		public int[] rewardItemID;

		// Token: 0x040003D4 RID: 980
		public int[] rewardEquipmentID;
	}
}
