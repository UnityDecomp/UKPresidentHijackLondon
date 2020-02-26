using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000146 RID: 326
public class ItemRotator : MonoBehaviour
{
	// Token: 0x06000A1A RID: 2586 RVA: 0x0003DC88 File Offset: 0x0003C088
	private void Start()
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			this.itemsPositions.Add(base.transform.GetChild(i).position);
		}
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x0003DCD0 File Offset: 0x0003C0D0
	private void Update()
	{
		if (this.rotate)
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				child.RotateAround(child.position, Vector3.down, 40f * Time.deltaTime);
				Vector3 position = this.itemsPositions[i] + new Vector3(this.offset.x, Mathf.PingPong(this.speed * Time.time, this.offset.y), this.offset.z);
				child.position = position;
			}
		}
	}

	// Token: 0x04000944 RID: 2372
	public bool rotate;

	// Token: 0x04000945 RID: 2373
	[HideInInspector]
	public Transform target;

	// Token: 0x04000946 RID: 2374
	private Vector3 offset = new Vector3(0f, 1f, 0f);

	// Token: 0x04000947 RID: 2375
	private float speed = 0.7f;

	// Token: 0x04000948 RID: 2376
	private List<Vector3> itemsPositions = new List<Vector3>();
}
