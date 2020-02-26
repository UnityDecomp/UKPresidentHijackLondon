using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200003E RID: 62
public class WarnPresident : MonoBehaviour
{
	// Token: 0x06000304 RID: 772 RVA: 0x0000B8C7 File Offset: 0x00009CC7
	private void Start()
	{
	}

	// Token: 0x06000305 RID: 773 RVA: 0x0000B8C9 File Offset: 0x00009CC9
	private void Update()
	{
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0000B8CB File Offset: 0x00009CCB
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Gang"))
		{
			this.game = other.gameObject;
			base.StartCoroutine(this.Warning());
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0000B8FC File Offset: 0x00009CFC
	private IEnumerator Warning()
	{
		this.game.GetComponent<Animator>().SetBool("talk", true);
		this.VirtualPanel.transform.GetChild(7).gameObject.SetActive(true);
		yield return new WaitForSeconds(2f);
		this.game.GetComponent<Animator>().SetBool("talk", false);
		yield break;
	}

	// Token: 0x04000161 RID: 353
	public Image VirtualPanel;

	// Token: 0x04000162 RID: 354
	public GameObject game;
}
