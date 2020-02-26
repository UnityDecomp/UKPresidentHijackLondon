using System;
using System.Collections;
using SWS;
using UnityEngine;

// Token: 0x0200003B RID: 59
public class SuccessCutSceen : MonoBehaviour
{
	// Token: 0x060002EB RID: 747 RVA: 0x0000A994 File Offset: 0x00008D94
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0000A9B0 File Offset: 0x00008DB0
	private void Update()
	{
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0000A9B4 File Offset: 0x00008DB4
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			base.GetComponent<ParticleSystem>().Stop(true);
			other.gameObject.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animator>().SetBool("run", false);
			this.qms.joystick2.gameObject.SetActive(false);
			this.qms.Hero1Camera.gameObject.SetActive(false);
			this.qms.zone4enemies.transform.GetChild(1).gameObject.SetActive(true);
			this.qms.zone4enemies.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
			this.qms.zone4enemies.transform.GetChild(2).GetChild(0).GetComponent<splineMove>().enabled = true;
			base.StartCoroutine(this.SuccessCutS());
		}
	}

	// Token: 0x060002EE RID: 750 RVA: 0x0000AAAC File Offset: 0x00008EAC
	private IEnumerator SuccessCutS()
	{
		yield return new WaitForSeconds(8f);
		this.qms.reached("Hero1");
		yield break;
	}

	// Token: 0x0400015C RID: 348
	private QuestManager qms;
}
