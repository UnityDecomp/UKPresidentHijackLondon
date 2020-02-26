using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
public class DamageAreaC : MonoBehaviour
{
	// Token: 0x06000376 RID: 886 RVA: 0x000126B4 File Offset: 0x00010AB4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.GetComponent<StatusC>().OnDamage(this.damage, 0);
		}
	}

	// Token: 0x04000285 RID: 645
	public int damage = 50;
}
