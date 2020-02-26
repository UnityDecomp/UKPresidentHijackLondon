using System;
using UnityEngine;

// Token: 0x02000205 RID: 517
public class RaftControl : MonoBehaviour
{
	// Token: 0x06000D73 RID: 3443 RVA: 0x00056328 File Offset: 0x00054728
	private void Start()
	{
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x0005632C File Offset: 0x0005472C
	private void FixedUpdate()
	{
		if (this.targets[this.num] && this.move)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.targets[this.num].transform.position, this.speed / 100f);
		}
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x00056399 File Offset: 0x00054799
	public void stop()
	{
		this.move = false;
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x000563A2 File Offset: 0x000547A2
	public void start()
	{
		this.move = true;
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x000563AB File Offset: 0x000547AB
	public void next(int num)
	{
		this.num = num;
	}

	// Token: 0x04000E24 RID: 3620
	public GameObject[] targets;

	// Token: 0x04000E25 RID: 3621
	[HideInInspector]
	public int num;

	// Token: 0x04000E26 RID: 3622
	public float speed = 1f;

	// Token: 0x04000E27 RID: 3623
	private bool move = true;
}
