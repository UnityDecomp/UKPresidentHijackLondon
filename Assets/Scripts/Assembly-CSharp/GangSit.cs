using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000038 RID: 56
public class GangSit : MonoBehaviour
{
	// Token: 0x060002DD RID: 733 RVA: 0x0000A09E File Offset: 0x0000849E
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060002DE RID: 734 RVA: 0x0000A0BA File Offset: 0x000084BA
	private void Update()
	{
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0000A0BC File Offset: 0x000084BC
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Gang"))
		{
			other.gameObject.GetComponent<Animator>().SetBool("walk", false);
			this.qms.zone3enemies.transform.GetChild(0).GetChild(2).transform.position = this.OfficeChair.position + this.Offset1;
			this.qms.zone3enemies.transform.GetChild(0).GetChild(2).transform.rotation = this.OfficeChair.rotation;
			this.qms.zone3enemies.transform.GetChild(0).GetChild(3).transform.position = this.OfficeChair1.position + this.offset;
			this.qms.zone3enemies.transform.GetChild(0).GetChild(3).transform.rotation = this.OfficeChair1.rotation;
			this.qms.Hero1Camera.gameObject.SetActive(false);
			this.qms.zone3enemies.transform.GetChild(0).GetChild(5).gameObject.SetActive(true);
			base.StartCoroutine(this.GanGTalk());
		}
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0000A218 File Offset: 0x00008618
	private IEnumerator GanGTalk()
	{
		yield return new WaitForSeconds(2f);
		this.VirtualPanel.transform.GetChild(0).gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		this.VirtualPanel.transform.GetChild(0).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(1).gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		this.VirtualPanel.transform.GetChild(1).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(2).gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		this.VirtualPanel.transform.GetChild(2).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(3).gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		this.VirtualPanel.transform.GetChild(3).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(4).gameObject.SetActive(true);
		yield return new WaitForSeconds(5f);
		this.VirtualPanel.transform.GetChild(4).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(5).gameObject.SetActive(true);
		yield return new WaitForSeconds(5f);
		this.VirtualPanel.transform.GetChild(5).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(6).gameObject.SetActive(true);
		yield return new WaitForSeconds(5f);
		this.VirtualPanel.transform.GetChild(6).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(9).gameObject.SetActive(true);
		yield return new WaitForSeconds(5f);
		this.VirtualPanel.transform.GetChild(9).gameObject.SetActive(false);
		this.VirtualPanel.transform.GetChild(10).gameObject.SetActive(true);
		yield return new WaitForSeconds(5f);
		this.VirtualPanel.transform.GetChild(10).gameObject.SetActive(false);
		this.VirtualButtons.transform.GetChild(5).gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x04000150 RID: 336
	public Transform OfficeChair;

	// Token: 0x04000151 RID: 337
	public Transform OfficeChair1;

	// Token: 0x04000152 RID: 338
	private QuestManager qms;

	// Token: 0x04000153 RID: 339
	public Vector3 offset;

	// Token: 0x04000154 RID: 340
	public Vector3 Offset1;

	// Token: 0x04000155 RID: 341
	public GameObject VirtualButtons;

	// Token: 0x04000156 RID: 342
	public Image VirtualPanel;
}
