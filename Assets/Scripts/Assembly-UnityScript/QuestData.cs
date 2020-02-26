using System;
using UnityEngine;

// Token: 0x02000075 RID: 117
[Serializable]
public class QuestData : MonoBehaviour
{
	// Token: 0x06000183 RID: 387 RVA: 0x0001208C File Offset: 0x0001028C
	public QuestData()
	{
		this.questData = new Quest[3];
	}

	// Token: 0x06000184 RID: 388 RVA: 0x000120A0 File Offset: 0x000102A0
	public virtual void QuestClear(int id, GameObject player)
	{
		((Inventory)player.GetComponent(typeof(Inventory))).cash = ((Inventory)player.GetComponent(typeof(Inventory))).cash + this.questData[id].rewardCash;
		((Status)player.GetComponent(typeof(Status))).gainEXP(this.questData[id].rewardExp);
		if (this.questData[id].rewardItemID.Length > 0)
		{
			for (int i = 0; i < this.questData[id].rewardItemID.Length; i++)
			{
				((Inventory)player.GetComponent(typeof(Inventory))).AddItem(this.questData[id].rewardItemID[i], 1);
			}
		}
		if (this.questData[id].rewardEquipmentID.Length > 0)
		{
			for (int i = 0; i < this.questData[id].rewardEquipmentID.Length; i++)
			{
				((Inventory)player.GetComponent(typeof(Inventory))).AddEquipment(this.questData[id].rewardEquipmentID[i]);
			}
		}
	}

	// Token: 0x06000185 RID: 389 RVA: 0x000121E4 File Offset: 0x000103E4
	public virtual void Main()
	{
	}

	// Token: 0x040002AA RID: 682
	public GameObject itemData;

	// Token: 0x040002AB RID: 683
	public Quest[] questData;
}
