using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200002A RID: 42
[Serializable]
public class BulletStatus : MonoBehaviour
{
	// Token: 0x0600006F RID: 111 RVA: 0x00006700 File Offset: 0x00004900
	public BulletStatus()
	{
		this.damage = 10;
		this.damageMax = 20;
		this.playerAttack = 5;
		this.variance = 15;
		this.shooterTag = "Player";
		this.popDamage = string.Empty;
		this.AttackType = AtkType.Physic;
		this.element = Elementala.Normal;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00006758 File Offset: 0x00004958
	public virtual void Start()
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

	// Token: 0x06000071 RID: 113 RVA: 0x00006790 File Offset: 0x00004990
	public virtual void Setting(int str, int mag, string tag, GameObject owner)
	{
		if (this.AttackType == AtkType.Physic)
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

	// Token: 0x06000072 RID: 114 RVA: 0x00006810 File Offset: 0x00004A10
	public virtual void OnTriggerEnter(Collider other)
	{
		if (this.shooterTag == "Player" && other.tag == "Enemy")
		{
			Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Popup, other.transform.position, this.transform.rotation);
			if (this.AttackType == AtkType.Physic)
			{
				this.popDamage = ((Status)other.GetComponent(typeof(Status))).OnDamage(this.totalDamage, UnityBuiltins.parseInt((int)this.element));
			}
			else
			{
				this.popDamage = ((Status)other.GetComponent(typeof(Status))).OnMagicDamage(this.totalDamage, UnityBuiltins.parseInt((int)this.element));
			}
			if (this.shooter && (ShowEnemyHealth)this.shooter.GetComponent(typeof(ShowEnemyHealth)))
			{
				((ShowEnemyHealth)this.shooter.GetComponent(typeof(ShowEnemyHealth))).GetHP(((Status)other.GetComponent(typeof(Status))).maxHealth, other.gameObject, other.name);
			}
			((DamagePopup)transform.GetComponent(typeof(DamagePopup))).damage = this.popDamage;
			if (this.hitEffect)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, this.transform.position, this.transform.rotation);
			}
			if (this.flinch)
			{
				Vector3 normalized = (other.transform.position - this.transform.position).normalized;
				other.SendMessage("Flinch", normalized, SendMessageOptions.DontRequireReceiver);
			}
			if (!this.penetrate)
			{
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
		else if ((this.shooterTag == "Enemy" && other.tag == "Player") || (this.shooterTag == "Enemy" && other.tag == "Ally"))
		{
			if (this.AttackType == AtkType.Physic)
			{
				this.popDamage = ((Status)other.GetComponent(typeof(Status))).OnDamage(this.totalDamage, UnityBuiltins.parseInt((int)this.element));
			}
			else
			{
				this.popDamage = ((Status)other.GetComponent(typeof(Status))).OnMagicDamage(this.totalDamage, UnityBuiltins.parseInt((int)this.element));
			}
			Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Popup, this.transform.position, this.transform.rotation);
			((DamagePopup)transform.GetComponent(typeof(DamagePopup))).damage = this.popDamage;
			if (this.hitEffect)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, this.transform.position, this.transform.rotation);
			}
			if (this.flinch)
			{
				Vector3 normalized = (other.transform.position - this.transform.position).normalized;
				other.SendMessage("Flinch", normalized, SendMessageOptions.DontRequireReceiver);
			}
			if (!this.penetrate)
			{
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00006B98 File Offset: 0x00004D98
	public virtual void Main()
	{
	}

	// Token: 0x040000E4 RID: 228
	public int damage;

	// Token: 0x040000E5 RID: 229
	public int damageMax;

	// Token: 0x040000E6 RID: 230
	private int playerAttack;

	// Token: 0x040000E7 RID: 231
	public int totalDamage;

	// Token: 0x040000E8 RID: 232
	public int variance;

	// Token: 0x040000E9 RID: 233
	public string shooterTag;

	// Token: 0x040000EA RID: 234
	[HideInInspector]
	public GameObject shooter;

	// Token: 0x040000EB RID: 235
	public Transform Popup;

	// Token: 0x040000EC RID: 236
	public GameObject hitEffect;

	// Token: 0x040000ED RID: 237
	public bool flinch;

	// Token: 0x040000EE RID: 238
	public bool penetrate;

	// Token: 0x040000EF RID: 239
	private string popDamage;

	// Token: 0x040000F0 RID: 240
	public AtkType AttackType;

	// Token: 0x040000F1 RID: 241
	public Elementala element;
}
