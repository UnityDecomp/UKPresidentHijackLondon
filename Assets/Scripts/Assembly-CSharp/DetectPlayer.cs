using System;
using UnityEngine;

// Token: 0x0200013C RID: 316
public class DetectPlayer : MonoBehaviour
{
	// Token: 0x060009F4 RID: 2548 RVA: 0x0003D46C File Offset: 0x0003B86C
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x0003D488 File Offset: 0x0003B888
	private void Update()
	{
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x0003D48C File Offset: 0x0003B88C
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (!this.qms.players1[0].transform.GetChild(17).GetChild(0).gameObject.activeSelf)
			{
				MonoBehaviour.print(this.qms.players1[0].transform.GetChild(17).GetChild(0).gameObject);
				this.qms.GameOver();
			}
			else
			{
				this.qms.players1[0].transform.GetChild(17).GetChild(0).gameObject.SetActive(false);
				this.qms.players1[0].transform.GetChild(15).gameObject.SetActive(false);
				this.qms.players1[0].transform.GetChild(17).GetComponent<Animator>().SetBool("run", false);
				this.qms.players1[0].transform.GetChild(17).GetComponent<Animator>().SetBool("crouch", true);
				this.qms.LandingText.gameObject.SetActive(true);
				this.qms.reached("Hero1");
			}
		}
	}

	// Token: 0x04000921 RID: 2337
	private QuestManager qms;
}
