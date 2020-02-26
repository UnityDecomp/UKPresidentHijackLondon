using System;
using UnityEngine;

// Token: 0x02000122 RID: 290
public class RotateCamera : MonoBehaviour
{
	// Token: 0x060007B6 RID: 1974 RVA: 0x00033586 File Offset: 0x00031986
	private void Start()
	{
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x00033588 File Offset: 0x00031988
	private void Update()
	{
		base.transform.RotateAround(this.target.transform.position, Vector3.up, 25f * Time.deltaTime);
	}

	// Token: 0x040006C0 RID: 1728
	public Transform target;
}
