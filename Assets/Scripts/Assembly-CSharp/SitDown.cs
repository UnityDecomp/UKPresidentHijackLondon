using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class SitDown : MonoBehaviour
{
	// Token: 0x060002E6 RID: 742 RVA: 0x0000A731 File Offset: 0x00008B31
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0000A74D File Offset: 0x00008B4D
	private void Update()
	{
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0000A750 File Offset: 0x00008B50
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			MonoBehaviour.print("Sit Down");
			this.qms.hero1models[0].GetComponent<Animator>().SetBool("run", false);
			this.qms.joystick2.gameObject.SetActive(false);
			this.Manager.GetComponent<QuestManager>().Hero1.position = base.gameObject.transform.position;
			this.Manager.GetComponent<QuestManager>().Hero1.rotation = base.gameObject.transform.rotation;
			this.Manager.GetComponent<QuestManager>().hero1models[0].GetComponent<Animator>().SetBool("sitonchair", true);
			this.qms.Hero1Camera.GetComponent<VehicleCamera>().distance = 3.46f;
			this.qms.Hero1Camera.GetComponent<VehicleCamera>().height = 0.49f;
			this.qms.Hero1Camera.GetComponent<VehicleCamera>().Angle = 28f;
			base.GetComponent<ParticleSystem>().Stop();
			base.GetComponent<MapMarker>().isActive = false;
			this.qms.Hero1Camera.gameObject.SetActive(false);
			this.qms.Hero1.transform.GetChild(0).gameObject.SetActive(true);
			base.StartCoroutine(this.WaitCalling());
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0000A8C4 File Offset: 0x00008CC4
	private IEnumerator WaitCalling()
	{
		yield return new WaitForSeconds(2.5f);
		this.VirtualButtons.transform.GetChild(0).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x04000159 RID: 345
	public GameObject Manager;

	// Token: 0x0400015A RID: 346
	private QuestManager qms;

	// Token: 0x0400015B RID: 347
	public GameObject VirtualButtons;
}
