using System;
using System.Collections;
using SWS;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200003D RID: 61
public class VirtualScript : MonoBehaviour
{
	// Token: 0x060002F4 RID: 756 RVA: 0x0000AC14 File Offset: 0x00009014
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
		int questID = this.qms.getQuestID();
		MonoBehaviour.print("ya questid ha" + questID);
		if (questID == 2)
		{
			base.StartCoroutine(this.MeetingEnd());
		}
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0000AC70 File Offset: 0x00009070
	private void Update()
	{
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x0000AC72 File Offset: 0x00009072
	public void SStright()
	{
		base.StartCoroutine(this.SitStriaght());
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0000AC84 File Offset: 0x00009084
	private IEnumerator SitStriaght()
	{
		base.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animator>().SetBool("sitstright", true);
		this.VirtualButtons.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		yield return new WaitForSeconds(3f);
		base.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animator>().SetBool("sitstright", false);
		yield return new WaitForSeconds(3f);
		this.VirtualButtons.gameObject.transform.GetChild(1).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0000AC9F File Offset: 0x0000909F
	public void UseLap()
	{
		base.StartCoroutine(this.ULap());
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0000ACB0 File Offset: 0x000090B0
	private IEnumerator ULap()
	{
		this.VirtualButtons.gameObject.transform.GetChild(1).gameObject.SetActive(false);
		base.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animator>().SetBool("uselap", true);
		yield return new WaitForSeconds(2f);
		base.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animator>().SetBool("uselap", false);
		yield return new WaitForSeconds(3f);
		this.VirtualButtons.gameObject.transform.GetChild(2).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0000ACCB File Offset: 0x000090CB
	public void StandUp()
	{
		base.StartCoroutine(this.StndUP());
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0000ACDC File Offset: 0x000090DC
	private IEnumerator StndUP()
	{
		this.VirtualButtons.gameObject.transform.GetChild(2).gameObject.SetActive(false);
		base.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animator>().SetBool("sitonchair", false);
		yield return new WaitForSeconds(2f);
		this.qms.Hero1Camera.gameObject.SetActive(true);
		base.transform.GetChild(0).gameObject.SetActive(false);
		this.qms.Hero1.transform.GetChild(15).gameObject.SetActive(true);
		this.qms.zone2enemies.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0000ACF8 File Offset: 0x000090F8
	private IEnumerator MeetingEnd()
	{
		yield return new WaitForSeconds(5f);
		this.VirtualButtons.gameObject.transform.GetChild(3).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0000AD13 File Offset: 0x00009113
	public void MeetEnd()
	{
		base.StartCoroutine(this.MeetE());
	}

	// Token: 0x060002FE RID: 766 RVA: 0x0000AD24 File Offset: 0x00009124
	private IEnumerator MeetE()
	{
		this.VirtualButtons.gameObject.transform.GetChild(3).gameObject.SetActive(false);
		yield return new WaitForSeconds(2f);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(1).GetComponent<Animator>().SetBool("walk", true);
		yield return new WaitForSeconds(3f);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(1).GetComponent<splineMove>().enabled = true;
		yield return new WaitForSeconds(3f);
		this.VirtualButtons.gameObject.transform.GetChild(4).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0000AD3F File Offset: 0x0000913F
	public void MeetNext()
	{
		base.StartCoroutine(this.MetNxt());
	}

	// Token: 0x06000300 RID: 768 RVA: 0x0000AD50 File Offset: 0x00009150
	private IEnumerator MetNxt()
	{
		this.VirtualButtons.transform.GetChild(4).gameObject.SetActive(false);
		yield return new WaitForSeconds(1f);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(2).GetComponent<Animator>().SetBool("walk", true);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(3).GetComponent<Animator>().SetBool("walk", true);
		yield return new WaitForSeconds(3f);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(2).GetComponent<splineMove>().enabled = true;
		yield return new WaitForSeconds(0.5f);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(3).GetComponent<splineMove>().enabled = true;
		yield break;
	}

	// Token: 0x06000301 RID: 769 RVA: 0x0000AD6B File Offset: 0x0000916B
	public void CallSecurity()
	{
		base.StartCoroutine(this.CalSecurity());
	}

	// Token: 0x06000302 RID: 770 RVA: 0x0000AD7C File Offset: 0x0000917C
	private IEnumerator CalSecurity()
	{
		this.VirtualButtons.transform.GetChild(5).gameObject.SetActive(false);
		yield return new WaitForSeconds(1f);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(7).GetComponent<splineMove>().enabled = true;
		this.qms.zone3enemies.transform.GetChild(0).GetChild(8).GetComponent<splineMove>().enabled = true;
		this.qms.zone3enemies.transform.GetChild(0).GetChild(9).GetComponent<splineMove>().enabled = true;
		this.VirtualPanel.transform.GetChild(8).gameObject.SetActive(true);
		yield return new WaitForSeconds(4f);
		this.VirtualPanel.transform.GetChild(8).gameObject.SetActive(false);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
		this.qms.Hero1Camera.gameObject.SetActive(true);
		this.qms.hero1models[0].gameObject.SetActive(true);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
		this.qms.Hero1.transform.GetChild(15).gameObject.SetActive(true);
		this.qms.zone3enemies.transform.GetChild(0).GetChild(10).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x0400015E RID: 350
	private QuestManager qms;

	// Token: 0x0400015F RID: 351
	public GameObject VirtualButtons;

	// Token: 0x04000160 RID: 352
	public Image VirtualPanel;
}
