using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001E4 RID: 484
public class FootprintSystem : MonoBehaviour
{
	// Token: 0x06000C86 RID: 3206 RVA: 0x0004EFD8 File Offset: 0x0004D3D8
	public void drawFootprint(string state)
	{
		if (!this.allowFootprint)
		{
			return;
		}
		Vector3 position = new Vector3(this.players[gameplay.count].transform.position.x + 0.1f, this.players[gameplay.count].transform.position.y, this.players[gameplay.count].transform.position.z);
		Vector3 position2 = new Vector3(this.players[gameplay.count].transform.position.x - 0.1f, this.players[gameplay.count].transform.position.y, this.players[gameplay.count].transform.position.z);
		if (this.allowTrail)
		{
			if (this.foot == 0)
			{
				this.foot = 1;
				UnityEngine.Object.Instantiate<GameObject>(this.footprint, position, Quaternion.Euler(new Vector3(0f, this.players[gameplay.count].transform.eulerAngles.y + 180f, 0f)));
			}
			else
			{
				this.foot = 0;
				UnityEngine.Object.Instantiate<GameObject>(this.footprint, position2, Quaternion.Euler(new Vector3(0f, this.players[gameplay.count].transform.eulerAngles.y + 180f, 0f)));
			}
			if (state == "Walking")
			{
				this.time = 0.5f;
			}
			if (state == "Running")
			{
				this.time = 0.3f;
			}
			base.StartCoroutine(this.trails(this.time));
		}
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x0004F1C4 File Offset: 0x0004D5C4
	private IEnumerator trails(float time)
	{
		this.allowTrail = false;
		yield return new WaitForSeconds(time);
		this.allowTrail = true;
		yield break;
	}

	// Token: 0x04000CEA RID: 3306
	public GameObject footprint;

	// Token: 0x04000CEB RID: 3307
	public GameObject[] players;

	// Token: 0x04000CEC RID: 3308
	[HideInInspector]
	public bool allowFootprint = true;

	// Token: 0x04000CED RID: 3309
	private bool allowTrail = true;

	// Token: 0x04000CEE RID: 3310
	private int foot;

	// Token: 0x04000CEF RID: 3311
	private float time;
}
