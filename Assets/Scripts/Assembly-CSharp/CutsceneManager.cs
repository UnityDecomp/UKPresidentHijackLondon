using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001DD RID: 477
public class CutsceneManager : MonoBehaviour
{
	// Token: 0x06000C65 RID: 3173 RVA: 0x0004E657 File Offset: 0x0004CA57
	private void Start()
	{
	}

	// Token: 0x06000C66 RID: 3174 RVA: 0x0004E65C File Offset: 0x0004CA5C
	private void Update()
	{
		if (this.started)
		{
			base.transform.LookAt(this.scene[this.questNo].actor.transform.position);
			base.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
		}
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x0004E6C0 File Offset: 0x0004CAC0
	private IEnumerator startScene(float time)
	{
		this.started = true;
		yield return new WaitForSeconds(time - 0.5f);
		this.started = false;
		yield return new WaitForSeconds(1f);
		base.transform.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000C68 RID: 3176 RVA: 0x0004E6E4 File Offset: 0x0004CAE4
	public void StartCutscene(int quest, float time)
	{
		base.transform.gameObject.SetActive(true);
		this.questNo = quest;
		base.transform.position = this.scene[this.questNo].initialPoint.transform.position;
		base.StartCoroutine(this.startScene(time));
	}

	// Token: 0x04000CD1 RID: 3281
	private bool started;

	// Token: 0x04000CD2 RID: 3282
	private int questNo;

	// Token: 0x04000CD3 RID: 3283
	public float speed;

	// Token: 0x04000CD4 RID: 3284
	public CutsceneManager.Scenes[] scene;

	// Token: 0x020001DE RID: 478
	[Serializable]
	public class Scenes
	{
		// Token: 0x04000CD5 RID: 3285
		public GameObject actor;

		// Token: 0x04000CD6 RID: 3286
		public GameObject initialPoint;
	}
}
