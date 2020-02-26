using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class SlowRotate : MonoBehaviour
{
	// Token: 0x060004FC RID: 1276 RVA: 0x00026C1E File Offset: 0x0002501E
	private void Start()
	{
		this.rotateSpeed = UnityEngine.Random.Range(-60f, 60f);
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x00026C35 File Offset: 0x00025035
	private void Update()
	{
		base.transform.Rotate(new Vector3(0f, 0f, this.rotateSpeed) * Time.deltaTime);
	}

	// Token: 0x040004E4 RID: 1252
	public float rotateSpeed;
}
