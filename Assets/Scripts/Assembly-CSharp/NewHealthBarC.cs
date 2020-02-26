using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F5 RID: 501
public class NewHealthBarC : MonoBehaviour
{
	// Token: 0x06000CDC RID: 3292 RVA: 0x00051001 File Offset: 0x0004F401
	private void Start()
	{
		this.maxHp = (float)this.player.GetComponent<StatusC>().maxHealth;
		this.questM = UnityEngine.Object.FindObjectOfType<QuestManager>();
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x00051025 File Offset: 0x0004F425
	private void Awake()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		this.hptext = 100f * this.barMultiply;
	}

	// Token: 0x06000CDE RID: 3294 RVA: 0x0005105C File Offset: 0x0004F45C
	public void increaseHealth(int amount)
	{
		if (this.player.GetComponent<StatusC>().health + amount < this.player.GetComponent<StatusC>().maxHealth)
		{
			this.player.GetComponent<StatusC>().health += amount;
		}
		else
		{
			this.player.GetComponent<StatusC>().health = this.player.GetComponent<StatusC>().maxHealth;
		}
	}

	// Token: 0x06000CDF RID: 3295 RVA: 0x000510CD File Offset: 0x0004F4CD
	public void fillHunger(float amount)
	{
		if (this.hunger < 100f)
		{
			this.hunger += amount;
			this.hungerBar.fillAmount = this.hunger;
		}
	}

	// Token: 0x06000CE0 RID: 3296 RVA: 0x000510FE File Offset: 0x0004F4FE
	public void fillThirst(float amount)
	{
		this.thirst = 100f;
		this.thirstBar.fillAmount = this.thirst;
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x0005111C File Offset: 0x0004F51C
	private void Update()
	{
		this.healthChange = (double)this.player.GetComponent<StatusC>().health / 200.0;
		this.health.fillAmount = (float)this.healthChange;
		if ((double)this.health.fillAmount < 0.08)
		{
			this.health.fillAmount = 0f;
		}
		this.stamina.fillAmount = this.player.GetComponent<PlayerInputControllerC>().stamina / 100f;
		if (this.allowHunger)
		{
			this.hunger -= 0.01f;
			this.thirst -= 0.02f;
			if (this.hunger < 0f)
			{
				base.GetComponent<StatusC>().Death("Your player is died of Hunger. GAME OVER !!!");
			}
			if (this.thirst < 0f)
			{
				base.GetComponent<StatusC>().Death("Your player is died of Thrist. GAME OVER !!!");
			}
		}
		if (this.hungerBar && this.thirstBar)
		{
			this.hungerBar.fillAmount = this.hunger / 100f;
			this.thirstBar.fillAmount = this.thirst / 100f;
		}
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00051264 File Offset: 0x0004F664
	public void showHurtImage()
	{
		if (this.hurtImage && this.hurting)
		{
			base.StartCoroutine(this.showHurt());
		}
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x00051290 File Offset: 0x0004F690
	private IEnumerator showHurt()
	{
		Color color = this.hurtImage.GetComponent<Image>().color;
		this.hurtImage.gameObject.SetActive(true);
		this.hurting = false;
		for (float i = 0.8f; i > 0f; i -= 0.05f)
		{
			yield return new WaitForSeconds(0.1f);
			color.a = i;
			this.hurtImage.GetComponent<Image>().color = color;
		}
		this.hurting = true;
		this.hurtImage.gameObject.SetActive(false);
		color.a = 0.8f;
		yield break;
	}

	// Token: 0x06000CE4 RID: 3300 RVA: 0x000512AC File Offset: 0x0004F6AC
	private void OnGUI()
	{
		if (!this.player)
		{
			return;
		}
		float num = (float)this.player.GetComponent<StatusC>().maxHealth;
		float num2 = (float)(this.player.GetComponent<StatusC>().health * 100) / num * this.barMultiply;
		float num3 = (float)this.player.GetComponent<StatusC>().maxMana;
		float num4 = (float)(this.player.GetComponent<StatusC>().mana * 100) / num3 * this.barMultiply;
		float num5 = (float)this.player.GetComponent<StatusC>().maxExp;
		float num6 = (float)(this.player.GetComponent<StatusC>().exp * 100) / num5 * this.barMultiply;
		float num7 = (float)this.player.GetComponent<StatusC>().level;
		int num8 = this.player.GetComponent<StatusC>().health;
		int mana = this.player.GetComponent<StatusC>().mana;
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x00051394 File Offset: 0x0004F794
	private void OnTriggerEnter(Collider other)
	{
	}

	// Token: 0x04000D53 RID: 3411
	public Image health;

	// Token: 0x04000D54 RID: 3412
	private float maxHp;

	// Token: 0x04000D55 RID: 3413
	public Image power;

	// Token: 0x04000D56 RID: 3414
	public Image stamina;

	// Token: 0x04000D57 RID: 3415
	public Image hungerBar;

	// Token: 0x04000D58 RID: 3416
	public Image thirstBar;

	// Token: 0x04000D59 RID: 3417
	public Image hurtImage;

	// Token: 0x04000D5A RID: 3418
	public bool allowHunger;

	// Token: 0x04000D5B RID: 3419
	public float hunger = 100f;

	// Token: 0x04000D5C RID: 3420
	public float thirst = 100f;

	// Token: 0x04000D5D RID: 3421
	public Vector2 maxHpBarPosition = new Vector2(20f, 20f);

	// Token: 0x04000D5E RID: 3422
	public Vector2 hpBarPosition = new Vector2(152f, 48f);

	// Token: 0x04000D5F RID: 3423
	public Vector2 mpBarPosition = new Vector2(152f, 71f);

	// Token: 0x04000D60 RID: 3424
	public Vector2 expBarPosition = new Vector2(152f, 94f);

	// Token: 0x04000D61 RID: 3425
	public Vector2 levelPosition = new Vector2(24f, 86f);

	// Token: 0x04000D62 RID: 3426
	public int maxHpBarWidth = 310;

	// Token: 0x04000D63 RID: 3427
	public int maxHpBarHeigh = 115;

	// Token: 0x04000D64 RID: 3428
	public int barHeight = 19;

	// Token: 0x04000D65 RID: 3429
	public int expBarHeight = 8;

	// Token: 0x04000D66 RID: 3430
	private double healthChange;

	// Token: 0x04000D67 RID: 3431
	private bool hurting = true;

	// Token: 0x04000D68 RID: 3432
	public GUIStyle textStyle;

	// Token: 0x04000D69 RID: 3433
	public GUIStyle hpTextStyle;

	// Token: 0x04000D6A RID: 3434
	private QuestManager questM;

	// Token: 0x04000D6B RID: 3435
	public float barMultiply = 1.6f;

	// Token: 0x04000D6C RID: 3436
	public GameObject player;

	// Token: 0x04000D6D RID: 3437
	private float hptext = 100f;
}
