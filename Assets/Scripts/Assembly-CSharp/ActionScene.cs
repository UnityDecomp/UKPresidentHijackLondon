using System;
using UnityEngine;

// Token: 0x020001D2 RID: 466
public class ActionScene : MonoBehaviour
{
	// Token: 0x06000C25 RID: 3109 RVA: 0x0004CC64 File Offset: 0x0004B064
	private void Start()
	{
	}

	// Token: 0x06000C26 RID: 3110 RVA: 0x0004CC66 File Offset: 0x0004B066
	private void Update()
	{
		if (base.gameObject.name == "Whale")
		{
			base.GetComponent<CharacterController>().Move(Vector3.back * 0.08f);
		}
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x0004CCA0 File Offset: 0x0004B0A0
	private void OnControllerColliderHit(ControllerColliderHit other)
	{
		if (other.gameObject.name == "RAFT")
		{
			base.gameObject.name = "expired";
			this.Objects[0].GetComponent<Animator>().Play("jump");
			this.Objects[1].GetComponent<Animator>().Play("jump");
			other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			other.gameObject.GetComponent<Rigidbody>().AddForce(base.transform.forward * 400f);
		}
	}

	// Token: 0x06000C28 RID: 3112 RVA: 0x0004CD3C File Offset: 0x0004B13C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Trigger" && base.gameObject.name == "Robot")
		{
			base.GetComponent<Animation>().CrossFade("gun idle");
		}
	}

	// Token: 0x04000C89 RID: 3209
	public GameObject Controller;

	// Token: 0x04000C8A RID: 3210
	public GameObject[] Objects;
}
