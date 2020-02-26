using System;
using UnityEngine;

// Token: 0x0200013D RID: 317
public class DetectRay : MonoBehaviour
{
	// Token: 0x060009F8 RID: 2552 RVA: 0x0003D5EE File Offset: 0x0003B9EE
	private void Start()
	{
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x0003D60C File Offset: 0x0003BA0C
	private void Update()
	{
		Vector3 b = new Vector3(0f, 1.4f, 0f);
		Debug.DrawRay(base.transform.position + b, -base.transform.up * 20f, Color.blue);
		if (Physics.Raycast(base.transform.position, -base.transform.up, out this.hit, float.PositiveInfinity, this.layerMaskray))
		{
			if (this.hit.distance < 25f)
			{
				this.qms.players1[0].transform.GetChild(1).gameObject.SetActive(false);
				this.qms.players1[0].transform.GetChild(2).gameObject.SetActive(true);
			}
			if (this.hit.distance < 1f && (double)this.hit.distance > 0.5)
			{
				this.qms.players1[0].transform.GetChild(17).GetComponent<Animator>().SetBool("landunsafe", true);
				this.playerfail = true;
			}
		}
	}

	// Token: 0x04000922 RID: 2338
	private QuestManager qms;

	// Token: 0x04000923 RID: 2339
	private int layerMaskray = 2048;

	// Token: 0x04000924 RID: 2340
	private RaycastHit hit;

	// Token: 0x04000925 RID: 2341
	public bool playerfail;
}
