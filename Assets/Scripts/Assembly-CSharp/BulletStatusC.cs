using System;
using UnityEngine;

// Token: 0x0200004F RID: 79
public class BulletStatusC : MonoBehaviour
{
	// Token: 0x06000343 RID: 835 RVA: 0x0000F895 File Offset: 0x0000DC95
	private void Start()
	{
		if (this.variance >= 100)
		{
			this.variance = 100;
		}
		if (this.variance <= 1)
		{
			this.variance = 1;
		}
	}

	// Token: 0x06000344 RID: 836 RVA: 0x0000F8C0 File Offset: 0x0000DCC0
	public void Setting(int str, int mag, string tag, GameObject owner)
	{
		if (this.AttackType == BulletStatusC.AtkType.Physic)
		{
			this.playerAttack = str;
		}
		else
		{
			this.playerAttack = mag;
		}
		this.shooterTag = tag;
		this.shooter = owner;
		int min = 100 - this.variance;
		int max = 100 + this.variance;
		int num = UnityEngine.Random.Range(this.damage, this.damageMax);
		this.totalDamage = (num + this.playerAttack) * UnityEngine.Random.Range(min, max) / 100;
	}

	// Token: 0x06000345 RID: 837 RVA: 0x0000F93C File Offset: 0x0000DD3C
	private void OnTriggerEnter(Collider other)
	{
		if (this.shooterTag == "Player" && other.tag == "Enemy")
		{
			Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Popup, other.transform.position, base.transform.rotation);
			if (this.AttackType == BulletStatusC.AtkType.Physic)
			{
				this.popDamage = other.GetComponent<StatusC>().OnDamage(this.totalDamage, (int)this.element);
			}
			else
			{
				this.popDamage = other.GetComponent<StatusC>().OnMagicDamage(this.totalDamage, (int)this.element);
			}
			if (this.shooter && this.shooter.GetComponent<ShowEnemyHealthC>())
			{
				this.shooter.GetComponent<ShowEnemyHealthC>().GetHP(other.GetComponent<StatusC>().maxHealth, other.gameObject, other.name);
			}
			transform.GetComponent<DamagePopupC>().damage = this.popDamage;
			if (this.hitEffect)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, base.transform.position, base.transform.rotation);
			}
			if (this.flinch)
			{
				Vector3 normalized = (other.transform.position - base.transform.position).normalized;
				other.SendMessage("Flinch", normalized, SendMessageOptions.DontRequireReceiver);
			}
			if (!this.penetrate)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		else if ((this.shooterTag == "Enemy" && other.tag == "Player") || (this.shooterTag == "Enemy" && other.tag == "Ally"))
		{
			if (this.AttackType == BulletStatusC.AtkType.Physic)
			{
				this.popDamage = other.GetComponent<StatusC>().OnDamage(this.totalDamage, (int)this.element);
			}
			else
			{
				this.popDamage = other.GetComponent<StatusC>().OnMagicDamage(this.totalDamage, (int)this.element);
			}
			Transform transform2 = UnityEngine.Object.Instantiate<Transform>(this.Popup, base.transform.position, base.transform.rotation);
			transform2.GetComponent<DamagePopupC>().damage = this.popDamage;
			if (this.hitEffect)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, base.transform.position, base.transform.rotation);
			}
			if (this.flinch)
			{
				Vector3 normalized2 = (other.transform.position - base.transform.position).normalized;
				other.SendMessage("Flinch", normalized2, SendMessageOptions.DontRequireReceiver);
			}
			if (!this.penetrate)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (this.shooterTag == "Player" && other.tag == "Tree")
		{
			if (this.woodEffect)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.woodEffect, base.transform.position, base.transform.rotation);
			}
			if (!this.penetrate)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04000213 RID: 531
	public int damage = 10;

	// Token: 0x04000214 RID: 532
	public int damageMax = 20;

	// Token: 0x04000215 RID: 533
	private int playerAttack = 5;

	// Token: 0x04000216 RID: 534
	public int totalDamage;

	// Token: 0x04000217 RID: 535
	public int variance = 15;

	// Token: 0x04000218 RID: 536
	public string shooterTag = "Player";

	// Token: 0x04000219 RID: 537
	[HideInInspector]
	public GameObject shooter;

	// Token: 0x0400021A RID: 538
	public Transform Popup;

	// Token: 0x0400021B RID: 539
	public GameObject hitEffect;

	// Token: 0x0400021C RID: 540
	public GameObject woodEffect;

	// Token: 0x0400021D RID: 541
	public bool flinch;

	// Token: 0x0400021E RID: 542
	public bool penetrate;

	// Token: 0x0400021F RID: 543
	private string popDamage = string.Empty;

	// Token: 0x04000220 RID: 544
	public BulletStatusC.AtkType AttackType;

	// Token: 0x04000221 RID: 545
	public BulletStatusC.Elementala element;

	// Token: 0x02000050 RID: 80
	public enum AtkType
	{
		// Token: 0x04000223 RID: 547
		Physic,
		// Token: 0x04000224 RID: 548
		Magic
	}

	// Token: 0x02000051 RID: 81
	public enum Elementala
	{
		// Token: 0x04000226 RID: 550
		Normal,
		// Token: 0x04000227 RID: 551
		Fire,
		// Token: 0x04000228 RID: 552
		Ice,
		// Token: 0x04000229 RID: 553
		Earth,
		// Token: 0x0400022A RID: 554
		Lightning
	}
}
