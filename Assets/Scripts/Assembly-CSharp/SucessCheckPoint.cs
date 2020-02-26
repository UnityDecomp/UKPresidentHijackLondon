using System;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class SucessCheckPoint : MonoBehaviour
{
	// Token: 0x060002F0 RID: 752 RVA: 0x0000AB70 File Offset: 0x00008F70
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0000AB8C File Offset: 0x00008F8C
	private void Update()
	{
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0000AB90 File Offset: 0x00008F90
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			MonoBehaviour.print("Success");
			this.qms.reached("Hero1");
			this.qms.hero1models[0].GetComponent<Animator>().SetBool("run", false);
			this.qms.joystick2.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400015D RID: 349
	private QuestManager qms;
}
