using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class MinimapCameraC : MonoBehaviour
{
	// Token: 0x060003BC RID: 956 RVA: 0x00016EC5 File Offset: 0x000152C5
	private void Start()
	{
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00016EC8 File Offset: 0x000152C8
	private void Update()
	{
		if (this.target)
		{
			Vector3 b = this.target.TransformPoint(0f, 30f, -0.5f);
			base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * this.damping);
			Quaternion b2 = Quaternion.LookRotation(this.target.position - base.transform.position, this.target.up);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, 10f);
		}
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00016F78 File Offset: 0x00015378
	private void FindTarget()
	{
		if (!this.target)
		{
			Transform transform = GameObject.FindWithTag("Player").transform;
			if (transform)
			{
				this.target = transform;
			}
		}
	}

	// Token: 0x0400031F RID: 799
	public Transform target;

	// Token: 0x04000320 RID: 800
	public float damping;
}
