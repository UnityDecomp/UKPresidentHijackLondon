using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
public class SpawnFromQuestC : MonoBehaviour
{
	// Token: 0x0600042A RID: 1066 RVA: 0x0001B994 File Offset: 0x00019D94
	private void Start()
	{
		this.CheckCondition();
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x0001B99C File Offset: 0x00019D9C
	public void CheckCondition()
	{
		if (this.by == SpawnFromQuestC.SpawmQType.Instantiate)
		{
			this.Spawn();
		}
		if (this.by == SpawnFromQuestC.SpawmQType.Active)
		{
			this.Activate();
		}
		if (this.by == SpawnFromQuestC.SpawmQType.Deactivate)
		{
			this.Deactivate();
		}
		if (this.by == SpawnFromQuestC.SpawmQType.Destroy)
		{
			this.DeleteObj();
		}
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0001B9F0 File Offset: 0x00019DF0
	private void Spawn()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStatC component = this.player.GetComponent<QuestStatC>();
			if (component)
			{
				bool flag = this.player.GetComponent<QuestStatC>().CheckQuestSlot(this.questId);
				int num = this.player.GetComponent<QuestStatC>().CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnObject, base.transform.position, base.transform.rotation);
					gameObject.name = this.spawnObject.name;
				}
			}
		}
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0001BAB4 File Offset: 0x00019EB4
	private void Activate()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStatC component = this.player.GetComponent<QuestStatC>();
			if (component)
			{
				bool flag = this.player.GetComponent<QuestStatC>().CheckQuestSlot(this.questId);
				int num = this.player.GetComponent<QuestStatC>().CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					this.spawnObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0001BB50 File Offset: 0x00019F50
	private void Deactivate()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStatC component = this.player.GetComponent<QuestStatC>();
			if (component)
			{
				bool flag = this.player.GetComponent<QuestStatC>().CheckQuestSlot(this.questId);
				int num = this.player.GetComponent<QuestStatC>().CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					this.spawnObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0001BBEC File Offset: 0x00019FEC
	private void DeleteObj()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStatC component = this.player.GetComponent<QuestStatC>();
			if (component)
			{
				bool flag = this.player.GetComponent<QuestStatC>().CheckQuestSlot(this.questId);
				int num = this.player.GetComponent<QuestStatC>().CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					UnityEngine.Object.Destroy(this.spawnObject);
				}
			}
		}
	}

	// Token: 0x040003E5 RID: 997
	public int questId = 1;

	// Token: 0x040003E6 RID: 998
	public GameObject spawnObject;

	// Token: 0x040003E7 RID: 999
	public int progressAbove;

	// Token: 0x040003E8 RID: 1000
	public int progressBelow = 9999;

	// Token: 0x040003E9 RID: 1001
	private GameObject player;

	// Token: 0x040003EA RID: 1002
	public SpawnFromQuestC.SpawmQType by;

	// Token: 0x02000087 RID: 135
	public enum SpawmQType
	{
		// Token: 0x040003EC RID: 1004
		Instantiate,
		// Token: 0x040003ED RID: 1005
		Active,
		// Token: 0x040003EE RID: 1006
		Deactivate,
		// Token: 0x040003EF RID: 1007
		Destroy
	}
}
