using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200021B RID: 539
public class WaterDeath : MonoBehaviour
{
	// Token: 0x06000DDB RID: 3547 RVA: 0x00058525 File Offset: 0x00056925
	private void Start()
	{
		base.StartCoroutine(this.wait());
	}

	// Token: 0x06000DDC RID: 3548 RVA: 0x00058534 File Offset: 0x00056934
	private void Update()
	{
		if (this.rotate)
		{
			base.transform.rotation = Quaternion.Euler(new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z - this.rotateSpeed));
		}
		else
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - this.moveSpeed * Time.deltaTime, base.transform.position.z);
		}
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x00058600 File Offset: 0x00056A00
	private IEnumerator wait()
	{
		this.rotate = true;
		yield return new WaitForSeconds(2f);
		this.rotate = false;
		yield return new WaitForSeconds((float)this.delay);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04000E93 RID: 3731
	private float rotateSpeed = 4f;

	// Token: 0x04000E94 RID: 3732
	public float moveSpeed;

	// Token: 0x04000E95 RID: 3733
	private bool rotate = true;

	// Token: 0x04000E96 RID: 3734
	public int delay;
}
