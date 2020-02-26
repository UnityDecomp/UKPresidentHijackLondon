using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[RequireComponent(typeof(BulletStatusC))]
[RequireComponent(typeof(Rigidbody))]
public class BulletShotC : MonoBehaviour
{
	// Token: 0x0600033F RID: 831 RVA: 0x0000F773 File Offset: 0x0000DB73
	private void Start()
	{
		this.hitEffect = base.GetComponent<BulletStatusC>().hitEffect;
		base.GetComponent<Rigidbody>().isKinematic = true;
		UnityEngine.Object.Destroy(base.gameObject, this.duration);
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0000F7A4 File Offset: 0x0000DBA4
	private void Update()
	{
		Vector3 a = base.transform.rotation * this.relativeDirection;
		base.transform.position += a * this.Speed * Time.deltaTime;
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0000F7F4 File Offset: 0x0000DBF4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			if (this.wallEffect)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.wallEffect, base.transform.position, base.transform.rotation);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400020D RID: 525
	public float Speed = 20f;

	// Token: 0x0400020E RID: 526
	public Vector3 relativeDirection = Vector3.forward;

	// Token: 0x0400020F RID: 527
	public float duration = 1f;

	// Token: 0x04000210 RID: 528
	public string shooterTag = "Player";

	// Token: 0x04000211 RID: 529
	public GameObject hitEffect;

	// Token: 0x04000212 RID: 530
	public GameObject wallEffect;
}
