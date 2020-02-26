using System;
using UnityEngine;

// Token: 0x0200008B RID: 139
[RequireComponent(typeof(BulletStatus))]
[Serializable]
public class SpawnPet : MonoBehaviour
{
	// Token: 0x060001E6 RID: 486 RVA: 0x00018F48 File Offset: 0x00017148
	public SpawnPet()
	{
		this.additionY = 0.3f;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00018F5C File Offset: 0x0001715C
	public virtual void Start()
	{
		GameObject shooter = ((BulletStatus)this.GetComponent(typeof(BulletStatus))).shooter;
		if (((AttackTrigger)shooter.GetComponent(typeof(AttackTrigger))).pet)
		{
			((Status)((AttackTrigger)shooter.GetComponent(typeof(AttackTrigger))).pet.GetComponent(typeof(Status))).Death();
		}
		Vector3 position = this.transform.position;
		position.y += this.additionY;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.petPrefab, position, shooter.transform.rotation);
		((AIfriend)gameObject.GetComponent(typeof(AIfriend))).master = shooter.transform;
		((AttackTrigger)shooter.GetComponent(typeof(AttackTrigger))).pet = gameObject;
		UnityEngine.Object.Destroy(this.gameObject);
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0001905C File Offset: 0x0001725C
	public virtual void Main()
	{
	}

	// Token: 0x04000328 RID: 808
	public GameObject petPrefab;

	// Token: 0x04000329 RID: 809
	public float additionY;
}
