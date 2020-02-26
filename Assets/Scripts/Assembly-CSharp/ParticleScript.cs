using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
public class ParticleScript : MonoBehaviour
{
	// Token: 0x060002E2 RID: 738 RVA: 0x0000A6AF File Offset: 0x00008AAF
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0000A6CB File Offset: 0x00008ACB
	private void Update()
	{
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0000A6D0 File Offset: 0x00008AD0
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			this.qms.zone4enemies.transform.GetChild(0).GetChild(this.i).gameObject.SetActive(true);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000157 RID: 343
	private QuestManager qms;

	// Token: 0x04000158 RID: 344
	private int i = 1;
}
