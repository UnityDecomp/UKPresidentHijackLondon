using System;
using UnityEngine;

// Token: 0x02000219 RID: 537
public class WatchingOut : MonoBehaviour
{
	// Token: 0x06000DCF RID: 3535 RVA: 0x00058278 File Offset: 0x00056678
	private void Start()
	{
	}

	// Token: 0x06000DD0 RID: 3536 RVA: 0x0005827C File Offset: 0x0005667C
	private void Update()
	{
		if (!this.lookingOut)
		{
			base.gameObject.SetActive(false);
			return;
		}
		for (int i = 0; i < this.origins.Length; i++)
		{
			Vector3 vector = this.origins[i].transform.TransformDirection(Vector3.forward);
			Debug.DrawRay(this.origins[i].transform.position, vector * this.rayDistance, Color.green);
			this.origins[i].GetComponent<LineRenderer>().SetPosition(0, this.origins[i].transform.position);
			this.origins[i].GetComponent<LineRenderer>().SetPosition(1, vector);
			RaycastHit raycastHit;
			if (Physics.Raycast(this.origins[i].transform.position, vector, out raycastHit, this.rayDistance) && raycastHit.collider.tag == "Player")
			{
				this.playerDetection();
			}
		}
	}

	// Token: 0x06000DD1 RID: 3537 RVA: 0x00058379 File Offset: 0x00056779
	private void playerDetection()
	{
		base.GetComponent<AIsetC>().approachDistance = 198f;
		base.GetComponent<AIsetC>().detectRange = 200f;
		base.GetComponent<AIsetC>().lostSight = 300f;
	}

	// Token: 0x04000E8E RID: 3726
	public Transform[] origins;

	// Token: 0x04000E8F RID: 3727
	public float rayDistance = 50f;

	// Token: 0x04000E90 RID: 3728
	private bool lookingOut = true;
}
