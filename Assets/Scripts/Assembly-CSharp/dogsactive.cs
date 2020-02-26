using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001E1 RID: 481
public class dogsactive : MonoBehaviour
{
	// Token: 0x06000C73 RID: 3187 RVA: 0x0004E939 File Offset: 0x0004CD39
	private void Awake()
	{
		Time.timeScale = 1f;
		this.germanshepherds.SetActive(true);
		this.ActivateModels();
		this.SettingModels();
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x0004E95D File Offset: 0x0004CD5D
	private void Start()
	{
		this.joysticks.SetActive(true);
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x0004E96B File Offset: 0x0004CD6B
	public void enableComponents()
	{
		this.joysticks.SetActive(true);
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x0004E979 File Offset: 0x0004CD79
	public void disableComponents()
	{
		base.StartCoroutine(this.disable());
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x0004E988 File Offset: 0x0004CD88
	private IEnumerator disable()
	{
		yield return new WaitForSeconds(0f);
		this.joysticks.SetActive(false);
		yield break;
	}

	// Token: 0x06000C78 RID: 3192 RVA: 0x0004E9A3 File Offset: 0x0004CDA3
	public GameObject getActivePlayer()
	{
		if (PlayerPrefs.GetInt("Quest") >= 0 || PlayerPrefs.GetInt("Quest") <= 4)
		{
			return this.panthersheperd;
		}
		return this.germanshepherds;
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x0004E9D2 File Offset: 0x0004CDD2
	public GameObject getActiveJoystick()
	{
		return this.joysticks;
	}

	// Token: 0x06000C7A RID: 3194 RVA: 0x0004E9DA File Offset: 0x0004CDDA
	public GameObject getActiveCamera()
	{
		return this.cams;
	}

	// Token: 0x06000C7B RID: 3195 RVA: 0x0004E9E4 File Offset: 0x0004CDE4
	private void ActivateModels()
	{
		if (PlayerPrefs.GetInt("Quest") >= 0 || PlayerPrefs.GetInt("Quest") <= 4)
		{
			this.squad2Models[gameplay.count].SetActive(true);
			this.currentModel = this.squad2Models[gameplay.count];
		}
		else
		{
			this.squad1Models[gameplay.count].SetActive(true);
			this.currentModel = this.squad1Models[gameplay.count];
		}
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x0004EA60 File Offset: 0x0004CE60
	private void SettingModels()
	{
		this.germanshepherds.GetComponent<AttackTriggerC>().mainModel = this.currentModel;
		this.germanshepherds.GetComponent<PlayerMecanimAnimationC>().animator = this.currentModel.GetComponent<Animator>();
		this.germanshepherds.GetComponent<WeaponSwitch>().mainModel = this.currentModel.transform;
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x0004EABC File Offset: 0x0004CEBC
	public void FpsCamera()
	{
		if (this.tps)
		{
			GameObject gameObject = this.germanshepherds.transform.Find("ActionCamera").gameObject;
			gameObject.SetActive(true);
			this.cams.SetActive(false);
			this.tps = false;
		}
		else
		{
			GameObject gameObject2 = this.germanshepherds.transform.Find("ActionCamera").gameObject;
			gameObject2.SetActive(false);
			this.cams.SetActive(true);
			this.tps = true;
		}
	}

	// Token: 0x04000CDE RID: 3294
	public GameObject germanshepherds;

	// Token: 0x04000CDF RID: 3295
	public GameObject panthersheperd;

	// Token: 0x04000CE0 RID: 3296
	public GameObject joysticks;

	// Token: 0x04000CE1 RID: 3297
	public GameObject cams;

	// Token: 0x04000CE2 RID: 3298
	public GameObject[] squad1Models;

	// Token: 0x04000CE3 RID: 3299
	public GameObject[] squad2Models;

	// Token: 0x04000CE4 RID: 3300
	public GameObject currentModel;

	// Token: 0x04000CE5 RID: 3301
	private bool tps = true;

	// Token: 0x04000CE6 RID: 3302
	private bool completed;
}
