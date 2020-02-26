using System;
using UnityEngine;

// Token: 0x02000027 RID: 39
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BulletStatus))]
[AddComponentMenu("Action-RPG Kit/Create Bullet")]
[Serializable]
public class BulletShot : MonoBehaviour
{
	// Token: 0x06000069 RID: 105 RVA: 0x0000659C File Offset: 0x0000479C
	public BulletShot()
	{
		this.Speed = (float)20;
		this.relativeDirection = Vector3.forward;
		this.duration = 1f;
		this.shooterTag = "Player";
	}

	// Token: 0x0600006A RID: 106 RVA: 0x000065DC File Offset: 0x000047DC
	public virtual void Start()
	{
		this.hitEffect = ((BulletStatus)this.GetComponent(typeof(BulletStatus))).hitEffect;
		((Rigidbody)this.GetComponent(typeof(Rigidbody))).isKinematic = true;
		this.Destroy();
	}

	// Token: 0x0600006B RID: 107 RVA: 0x0000662C File Offset: 0x0000482C
	public virtual void Update()
	{
		Vector3 a = this.transform.rotation * this.relativeDirection;
		this.transform.position = this.transform.position + a * this.Speed * Time.deltaTime;
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00006684 File Offset: 0x00004884
	public virtual void Destroy()
	{
		UnityEngine.Object.Destroy(this.gameObject, this.duration);
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00006698 File Offset: 0x00004898
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			if (this.hitEffect)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, this.transform.position, this.transform.rotation);
			}
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x0600006E RID: 110 RVA: 0x000066FC File Offset: 0x000048FC
	public virtual void Main()
	{
	}

	// Token: 0x040000D6 RID: 214
	public float Speed;

	// Token: 0x040000D7 RID: 215
	public Vector3 relativeDirection;

	// Token: 0x040000D8 RID: 216
	public float duration;

	// Token: 0x040000D9 RID: 217
	public string shooterTag;

	// Token: 0x040000DA RID: 218
	public GameObject hitEffect;
}
