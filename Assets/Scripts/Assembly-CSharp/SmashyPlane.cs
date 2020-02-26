using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200014D RID: 333
public class SmashyPlane : MonoBehaviour
{
	// Token: 0x06000A2F RID: 2607 RVA: 0x0003DFF0 File Offset: 0x0003C3F0
	private void Update()
	{
		if (Input.GetKey(KeyCode.K))
		{
			this.smashMiddle();
		}
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x0003E004 File Offset: 0x0003C404
	private void flumph(GameObject go)
	{
		if (go.GetComponent<Rigidbody>() == null)
		{
			go.AddComponent<Rigidbody>();
			go.GetComponent<Rigidbody>().mass = 10000f;
			go.AddComponent<CDestroy>();
		}
		if (go.GetComponent<Collider>() != null)
		{
			go.GetComponent<Collider>().enabled = true;
		}
		IEnumerator enumerator = go.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.gameObject.SetActive(false);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x0003E0BC File Offset: 0x0003C4BC
	public void smashMiddle()
	{
		if (!this.leftWingSmashed)
		{
			this.smashLeftWing();
		}
		if (!this.rightWingSmashed)
		{
			this.smashRightWing();
		}
		if (!this.bodySmashed)
		{
			this.flumph(this.body);
		}
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x0003E0F7 File Offset: 0x0003C4F7
	public void smashLeftWing()
	{
		this.leftWingSmashed = true;
		this.flumph(this.leftWing);
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x0003E10C File Offset: 0x0003C50C
	public void smashRightWing()
	{
		this.rightWingSmashed = true;
		this.flumph(this.rightWing);
	}

	// Token: 0x0400094E RID: 2382
	public bool leftWingSmashed;

	// Token: 0x0400094F RID: 2383
	public bool rightWingSmashed;

	// Token: 0x04000950 RID: 2384
	public bool bodySmashed;

	// Token: 0x04000951 RID: 2385
	public GameObject leftWing;

	// Token: 0x04000952 RID: 2386
	public GameObject rightWing;

	// Token: 0x04000953 RID: 2387
	public GameObject body;
}
