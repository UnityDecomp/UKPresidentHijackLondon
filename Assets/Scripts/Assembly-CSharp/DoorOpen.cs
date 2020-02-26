using System;
using UnityEngine;

// Token: 0x02000037 RID: 55
public class DoorOpen : MonoBehaviour
{
	// Token: 0x060002D9 RID: 729 RVA: 0x00009FAB File Offset: 0x000083AB
	private void Start()
	{
		MonoBehaviour.print("Door Open ha" + PlayerPrefs.GetInt("Quest"));
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00009FCB File Offset: 0x000083CB
	private void Update()
	{
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00009FD0 File Offset: 0x000083D0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			MonoBehaviour.print("Door Open" + PlayerPrefs.GetInt("Quest"));
			if (PlayerPrefs.GetInt("Quest") == 0)
			{
				this.Manager.GetComponent<QuestManager>().reached("Hero1");
			}
			base.gameObject.GetComponent<ParticleSystem>().Stop(true);
			other.gameObject.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animator>().SetBool("run", false);
			this.Manager.GetComponent<QuestManager>().joystick2.gameObject.SetActive(false);
			this.Door.GetComponent<Animator>().SetBool("dooropen", true);
		}
	}

	// Token: 0x0400014E RID: 334
	public GameObject Manager;

	// Token: 0x0400014F RID: 335
	public GameObject Door;
}
