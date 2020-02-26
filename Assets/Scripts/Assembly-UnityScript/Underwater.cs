using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x020000A7 RID: 167
[Serializable]
public class Underwater : MonoBehaviour
{
	// Token: 0x06000247 RID: 583 RVA: 0x0001CD94 File Offset: 0x0001AF94
	public Underwater()
	{
		this.surfaceEnterPlus = 0.4f;
		this.surfaceExitPlus = 0.95f;
		this.fogDensity = 0.04f;
		this.fogColor = new Color((float)0, 0.4f, 0.7f, 0.6f);
		this.divingTime = 1f;
		this.underWaterLightColor = new Color((float)0, 0.4f, 0.7f, 0.6f);
		this.underWaterIntensity = 0.5f;
		this.cannotAttack = true;
	}

	// Token: 0x06000248 RID: 584 RVA: 0x0001CE20 File Offset: 0x0001B020
	public virtual void Start()
	{
		if (!this.mainCam)
		{
			this.mainCam = GameObject.FindWithTag("MainCamera");
		}
		if (!this.surface)
		{
			this.surface = this.gameObject;
		}
		this.defaultFog = RenderSettings.fog;
		this.defaultFogColor = RenderSettings.fogColor;
		this.defaultFogDensity = RenderSettings.fogDensity;
		if (this.mainLight)
		{
			this.defaultLightColor = ((Light)this.mainLight.GetComponent(typeof(Light))).color;
			this.defaultLightIntensity = ((Light)this.mainLight.GetComponent(typeof(Light))).intensity;
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0001CEE4 File Offset: 0x0001B0E4
	public virtual void Update()
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
				((Light)this.mainLight.GetComponent(typeof(Light))).color = this.underWaterLightColor;
				((Light)this.mainLight.GetComponent(typeof(Light))).intensity = this.underWaterIntensity;
			}
		}
		else
		{
			RenderSettings.fog = this.defaultFog;
			RenderSettings.fogColor = this.defaultFogColor;
			RenderSettings.fogDensity = this.defaultFogDensity;
			if (this.mainLight)
			{
				((Light)this.mainLight.GetComponent(typeof(Light))).color = this.defaultLightColor;
				((Light)this.mainLight.GetComponent(typeof(Light))).intensity = this.defaultLightIntensity;
			}
		}
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		else
		{
			if (this.jumping && this.player)
			{
				((CharacterController)this.player.GetComponent(typeof(CharacterController))).Move(Vector3.up * (float)6 * Time.deltaTime);
			}
			if (this.player.transform.position.y < this.surface.transform.position.y - this.surfaceEnterPlus && !this.onUnderwater)
			{
				if (this.hitEffect)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, this.player.transform.position, this.player.transform.rotation);
				}
				this.StartCoroutine(this.ActivateWaterController());
			}
			else if (this.onUnderwater && this.player.transform.position.y > this.surface.transform.position.y - this.surfaceExitPlus)
			{
				this.StartCoroutine(this.ActivateGroundController());
			}
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0001D1A0 File Offset: 0x0001B3A0
	public virtual IEnumerator ActivateWaterController()
	{
		return new Underwater.$ActivateWaterController$283(this).GetEnumerator();
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0001D1B0 File Offset: 0x0001B3B0
	public virtual IEnumerator ActivateGroundController()
	{
		return new Underwater.$ActivateGroundController$286(this).GetEnumerator();
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0001D1C0 File Offset: 0x0001B3C0
	public virtual void Main()
	{
	}

	// Token: 0x040003BE RID: 958
	public GameObject surface;

	// Token: 0x040003BF RID: 959
	public float surfaceEnterPlus;

	// Token: 0x040003C0 RID: 960
	public float surfaceExitPlus;

	// Token: 0x040003C1 RID: 961
	public float fogDensity;

	// Token: 0x040003C2 RID: 962
	public Color fogColor;

	// Token: 0x040003C3 RID: 963
	public float divingTime;

	// Token: 0x040003C4 RID: 964
	public GameObject hitEffect;

	// Token: 0x040003C5 RID: 965
	private bool defaultFog;

	// Token: 0x040003C6 RID: 966
	private Color defaultFogColor;

	// Token: 0x040003C7 RID: 967
	private float defaultFogDensity;

	// Token: 0x040003C8 RID: 968
	private Color defaultLightColor;

	// Token: 0x040003C9 RID: 969
	private float defaultLightIntensity;

	// Token: 0x040003CA RID: 970
	public GameObject mainLight;

	// Token: 0x040003CB RID: 971
	public Color underWaterLightColor;

	// Token: 0x040003CC RID: 972
	public float underWaterIntensity;

	// Token: 0x040003CD RID: 973
	public bool cannotAttack;

	// Token: 0x040003CE RID: 974
	private bool onEnter;

	// Token: 0x040003CF RID: 975
	private bool onUnderwater;

	// Token: 0x040003D0 RID: 976
	private GameObject mainCam;

	// Token: 0x040003D1 RID: 977
	private GameObject player;

	// Token: 0x040003D2 RID: 978
	private bool jumping;

	// Token: 0x020000A8 RID: 168
	[CompilerGenerated]
	[Serializable]
	internal sealed class $ActivateWaterController$283 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x0600024D RID: 589 RVA: 0x0001D1C4 File Offset: 0x0001B3C4
		public $ActivateWaterController$283(Underwater self_)
		{
			this.$self_$285 = self_;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0001D1D4 File Offset: 0x0001B3D4
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Underwater.$ActivateWaterController$283.$(this.$self_$285);
		}

		// Token: 0x040003D3 RID: 979
		internal Underwater $self_$285;
	}

	// Token: 0x020000AA RID: 170
	[CompilerGenerated]
	[Serializable]
	internal sealed class $ActivateGroundController$286 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000251 RID: 593 RVA: 0x0001D434 File Offset: 0x0001B634
		public $ActivateGroundController$286(Underwater self_)
		{
			this.$self_$288 = self_;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0001D444 File Offset: 0x0001B644
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Underwater.$ActivateGroundController$286.$(this.$self_$288);
		}

		// Token: 0x040003D5 RID: 981
		internal Underwater $self_$288;
	}
}
