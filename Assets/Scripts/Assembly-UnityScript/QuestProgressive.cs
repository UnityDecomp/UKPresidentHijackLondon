using System;
using UnityEngine;

// Token: 0x02000077 RID: 119
[Serializable]
public class QuestProgressive : MonoBehaviour
{
	// Token: 0x06000186 RID: 390 RVA: 0x000121E8 File Offset: 0x000103E8
	public QuestProgressive()
	{
		this.questId = 1;
		this.type = progressType.Auto;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00012200 File Offset: 0x00010400
	public virtual void Start()
	{
		if (this.type == progressType.Auto)
		{
			this.player = GameObject.FindWithTag("Player");
			QuestStat exists = (QuestStat)this.player.GetComponent(typeof(QuestStat));
			if (exists)
			{
				((QuestStat)this.player.GetComponent(typeof(QuestStat))).Progress(this.questId);
			}
		}
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00012278 File Offset: 0x00010478
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && this.type == progressType.Trigger)
		{
			QuestStat exists = (QuestStat)other.GetComponent(typeof(QuestStat));
			if (exists)
			{
				bool flag = ((QuestStat)other.GetComponent(typeof(QuestStat))).Progress(this.questId);
				if (flag)
				{
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}
	}

	// Token: 0x06000189 RID: 393 RVA: 0x000122FC File Offset: 0x000104FC
	public virtual void Main()
	{
	}

	// Token: 0x040002AF RID: 687
	public int questId;

	// Token: 0x040002B0 RID: 688
	private GameObject player;

	// Token: 0x040002B1 RID: 689
	public progressType type;
}
