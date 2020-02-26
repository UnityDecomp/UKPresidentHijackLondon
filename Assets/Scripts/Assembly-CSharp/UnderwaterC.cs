using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class UnderwaterC : MonoBehaviour
{
	// Token: 0x06000497 RID: 1175 RVA: 0x00023F04 File Offset: 0x00022304
	private void Start()
	{
		if (!this.mainCam)
		{
			this.mainCam = GameObject.FindWithTag("MainCamera");
		}
		if (!this.surface)
		{
			this.surface = base.gameObject;
		}
		this.defaultFog = RenderSettings.fog;
		this.defaultFogColor = RenderSettings.fogColor;
		this.defaultFogDensity = RenderSettings.fogDensity;
		if (this.mainLight)
		{
			this.defaultLightColor = this.mainLight.GetComponent<Light>().color;
			this.defaultLightIntensity = this.mainLight.GetComponent<Light>().intensity;
		}
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x00023FAC File Offset: 0x000223AC
	private void Update()
	{
		if (!this.mainCam)
		{
			this.mainCam = GameObject.FindWithTag("MainCamera");
		}
		if (this.mainCam.transform.position.y < this.surface.transform.position.y)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = this.fogColor;
			RenderSettings.fogDensity = this.fogDensity;
			if (this.mainLight)
			{
				this.mainLight.GetComponent<Light>().color = this.underWaterLightColor;
				this.mainLight.GetComponent<Light>().intensity = this.underWaterIntensity;
			}
		}
		else
		{
			RenderSettings.fog = this.defaultFog;
			RenderSettings.fogColor = this.defaultFogColor;
			RenderSettings.fogDensity = this.defaultFogDensity;
			if (this.mainLight)
			{
				this.mainLight.GetComponent<Light>().color = this.defaultLightColor;
				this.mainLight.GetComponent<Light>().intensity = this.defaultLightIntensity;
			}
		}
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
			return;
		}
		if (this.jumping && this.player)
		{
			this.player.GetComponent<CharacterController>().Move(Vector3.up * 6f * Time.deltaTime);
		}
		if (this.player.transform.position.y < this.surface.transform.position.y - this.surfaceEnterPlus && !this.onUnderwater)
		{
			if (this.hitEffect)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, this.player.transform.position, this.player.transform.rotation);
			}
			base.StartCoroutine("ActivateWaterController");
		}
		else if (this.onUnderwater && this.player.transform.position.y > this.surface.transform.position.y - this.surfaceExitPlus)
		{
			base.StartCoroutine("ActivateGroundController");
		}
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00024218 File Offset: 0x00022618
	private IEnumerator ActivateWaterController()
	{
		if (!this.onEnter)
		{
			if (this.player.GetComponent<UnderwaterControllerC>())
			{
				this.onEnter = true;
				yield return new WaitForSeconds(this.divingTime);
				this.player.GetComponent<PlayerInputControllerC>().enabled = false;
				this.player.GetComponent<CharacterMotorC>().enabled = false;
				this.player.GetComponent<UnderwaterControllerC>().enabled = true;
				if (this.player.GetComponent<PlayerAnimationC>())
				{
					this.player.GetComponent<PlayerAnimationC>().enabled = false;
				}
				else
				{
					this.player.GetComponent<PlayerMecanimAnimationC>().enabled = false;
					this.player.GetComponent<UnderwaterControllerC>().MecanimEnterWater();
				}
				this.player.GetComponent<UnderwaterControllerC>().surfaceExit = this.surface.transform.position.y - this.surfaceExitPlus - 0.7f;
				if (this.cannotAttack)
				{
					this.player.GetComponent<AttackTriggerC>().freeze = true;
				}
				this.onEnter = false;
			}
			this.onUnderwater = true;
		}
		yield break;
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x00024234 File Offset: 0x00022634
	private IEnumerator ActivateGroundController()
	{
		if (!this.onEnter)
		{
			if (this.player.GetComponent<UnderwaterControllerC>() && this.player.GetComponent<UnderwaterControllerC>().enabled)
			{
				this.onEnter = true;
				this.jumping = true;
				yield return new WaitForSeconds(0.2f);
				this.jumping = false;
				this.player.GetComponent<PlayerInputControllerC>().enabled = true;
				if (this.player.GetComponent<PlayerAnimationC>())
				{
					this.player.GetComponent<PlayerAnimationC>().enabled = true;
				}
				else
				{
					this.player.GetComponent<PlayerMecanimAnimationC>().enabled = true;
					this.player.GetComponent<UnderwaterControllerC>().MecanimExitWater();
				}
				this.player.GetComponent<CharacterMotorC>().enabled = true;
				this.player.GetComponent<UnderwaterControllerC>().enabled = false;
				this.player.GetComponent<AttackTriggerC>().freeze = false;
				this.onEnter = false;
			}
			this.onUnderwater = false;
		}
		yield break;
	}

	// Token: 0x040004A2 RID: 1186
	public GameObject surface;

	// Token: 0x040004A3 RID: 1187
	public float surfaceEnterPlus = 0.4f;

	// Token: 0x040004A4 RID: 1188
	public float surfaceExitPlus = 0.95f;

	// Token: 0x040004A5 RID: 1189
	public float fogDensity = 0.04f;

	// Token: 0x040004A6 RID: 1190
	public Color fogColor = new Color(0f, 0.4f, 0.7f, 0.6f);

	// Token: 0x040004A7 RID: 1191
	public float divingTime = 1f;

	// Token: 0x040004A8 RID: 1192
	public GameObject hitEffect;

	// Token: 0x040004A9 RID: 1193
	private bool defaultFog;

	// Token: 0x040004AA RID: 1194
	private Color defaultFogColor;

	// Token: 0x040004AB RID: 1195
	private float defaultFogDensity;

	// Token: 0x040004AC RID: 1196
	private Color defaultLightColor;

	// Token: 0x040004AD RID: 1197
	private float defaultLightIntensity;

	// Token: 0x040004AE RID: 1198
	public GameObject mainLight;

	// Token: 0x040004AF RID: 1199
	public Color underWaterLightColor = new Color(0f, 0.4f, 0.7f, 0.6f);

	// Token: 0x040004B0 RID: 1200
	public float underWaterIntensity = 0.5f;

	// Token: 0x040004B1 RID: 1201
	public bool cannotAttack = true;

	// Token: 0x040004B2 RID: 1202
	private bool onEnter;

	// Token: 0x040004B3 RID: 1203
	private bool onUnderwater;

	// Token: 0x040004B4 RID: 1204
	private GameObject mainCam;

	// Token: 0x040004B5 RID: 1205
	private GameObject player;

	// Token: 0x040004B6 RID: 1206
	private bool jumping;
}
