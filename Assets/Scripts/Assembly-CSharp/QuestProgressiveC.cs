using System;
using UnityEngine;

// Token: 0x02000082 RID: 130
public class QuestProgressiveC : MonoBehaviour
{
	// Token: 0x06000416 RID: 1046 RVA: 0x0001AC5C File Offset: 0x0001905C
	private void Start()
	{
		if (this.type == QuestProgressiveC.progressType.Auto)
		{
			this.player = GameObject.FindWithTag("Player");
			QuestStatC component = this.player.GetComponent<QuestStatC>();
			if (component)
			{
				this.player.GetComponent<QuestStatC>().Progress(this.questId);
			}
		}
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0001ACB4 File Offset: 0x000190B4
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && this.type == QuestProgressiveC.progressType.Trigger)
		{
			QuestStatC component = other.GetComponent<QuestStatC>();
			if (component)
			{
				bool flag = other.GetComponent<QuestStatC>().Progress(this.questId);
				if (flag)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x040003D5 RID: 981
	public int questId = 1;

	// Token: 0x040003D6 RID: 982
	private GameObject player;

	// Token: 0x040003D7 RID: 983
	public QuestProgressiveC.progressType type;

	// Token: 0x02000083 RID: 131
	public enum progressType
	{
		// Token: 0x040003D9 RID: 985
		Auto,
		// Token: 0x040003DA RID: 986
		Trigger
	}
}
