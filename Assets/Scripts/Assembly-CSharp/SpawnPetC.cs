using System;
using UnityEngine;

// Token: 0x02000091 RID: 145
[RequireComponent(typeof(BulletStatusC))]
public class SpawnPetC : MonoBehaviour
{
	// Token: 0x06000462 RID: 1122 RVA: 0x00020E10 File Offset: 0x0001F210
	private void Start()
	{
		GameObject shooter = base.GetComponent<BulletStatusC>().shooter;
		if (shooter.GetComponent<AttackTriggerC>().pet)
		{
			shooter.GetComponent<AttackTriggerC>().pet.GetComponent<StatusC>().Death();
		}
		Vector3 position = base.transform.position;
		position.y += this.additionY;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.petPrefab, position, shooter.transform.rotation);
		gameObject.GetComponent<AIfriendC>().master = shooter.transform;
		shooter.GetComponent<AttackTriggerC>().pet = gameObject;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x04000443 RID: 1091
	public GameObject petPrefab;

	// Token: 0x04000444 RID: 1092
	public float additionY = 0.3f;
}
