using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000149 RID: 329
public class PartiCleTrigger : MonoBehaviour
{
	// Token: 0x06000A24 RID: 2596 RVA: 0x0003DDF2 File Offset: 0x0003C1F2
	private void Start()
	{
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x0003DDF4 File Offset: 0x0003C1F4
	private void Update()
	{
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x0003DDF6 File Offset: 0x0003C1F6
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			MonoBehaviour.print("Cut Scene Ready");
			other.gameObject.SetActive(false);
			base.StartCoroutine(this.HeliUP());
		}
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x0003DE30 File Offset: 0x0003C230
	private IEnumerator HeliUP()
	{
		this.CutSceneModel.transform.GetChild(0).gameObject.SetActive(false);
		this.CutSceneModel.transform.GetChild(1).gameObject.SetActive(true);
		yield return new WaitForSeconds(4f);
		this.CutSceneModel.transform.GetChild(2).gameObject.SetActive(true);
		this.CutSceneModel.transform.GetChild(1).gameObject.SetActive(false);
		yield return new WaitForSeconds(1f);
		this.JumpHeli.gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x0400094A RID: 2378
	public GameObject CutSceneModel;

	// Token: 0x0400094B RID: 2379
	public Button JumpHeli;
}
