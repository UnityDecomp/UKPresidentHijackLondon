using System;
using UnityEngine;

// Token: 0x0200020C RID: 524
public class SimpleRotation : MonoBehaviour
{
	// Token: 0x06000D8E RID: 3470 RVA: 0x00056B02 File Offset: 0x00054F02
	private void Start()
	{
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x00056B04 File Offset: 0x00054F04
	private void Update()
	{
		if (this.oneTimeRotation)
		{
			base.transform.rotation = Quaternion.Euler(new Vector3(base.transform.localEulerAngles.x, base.transform.eulerAngles.y + this.speed * Time.deltaTime, base.transform.localEulerAngles.z));
		}
		if (this.leftRightLoop)
		{
			base.transform.rotation = Quaternion.Euler(new Vector3(base.transform.localEulerAngles.x, base.transform.eulerAngles.y + this.speed * Time.deltaTime, base.transform.localEulerAngles.z));
			if (this.allowRot)
			{
				this.allowRot = false;
				base.Invoke("changeDir", 4f);
			}
		}
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x00056C01 File Offset: 0x00055001
	private void stopDoor()
	{
		this.oneTimeRotation = false;
	}

	// Token: 0x06000D91 RID: 3473 RVA: 0x00056C0A File Offset: 0x0005500A
	public void openDoor()
	{
		this.oneTimeRotation = true;
		MonoBehaviour.print("open door of " + base.gameObject.name);
		base.Invoke("stopDoor", 2.5f);
	}

	// Token: 0x06000D92 RID: 3474 RVA: 0x00056C40 File Offset: 0x00055040
	private void changeDir()
	{
		float num = this.speed * -1f;
		this.speed = num;
		this.allowRot = true;
	}

	// Token: 0x04000E46 RID: 3654
	public bool oneTimeRotation;

	// Token: 0x04000E47 RID: 3655
	public bool leftRightLoop;

	// Token: 0x04000E48 RID: 3656
	public float doorYLimit = 180f;

	// Token: 0x04000E49 RID: 3657
	public float speed = 1f;

	// Token: 0x04000E4A RID: 3658
	private bool allowRot = true;
}
