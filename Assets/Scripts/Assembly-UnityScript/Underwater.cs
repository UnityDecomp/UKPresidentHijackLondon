
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class Underwater : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ActivateWaterController_0024283
	{
		internal Underwater _0024self__0024285;

		public _0024ActivateWaterController_0024283(Underwater self_)
		{
			_0024self__0024285 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024285);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ActivateGroundController_0024286
	{
		internal Underwater _0024self__0024288;

		public _0024ActivateGroundController_0024286(Underwater self_)
		{
			_0024self__0024288 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024288);
		}
	}

	public GameObject surface;

	public float surfaceEnterPlus;

	public float surfaceExitPlus;

	public float fogDensity;

	public Color fogColor;

	public float divingTime;

	public GameObject hitEffect;

	private bool defaultFog;

	private Color defaultFogColor;

	private float defaultFogDensity;

	private Color defaultLightColor;

	private float defaultLightIntensity;

	public GameObject mainLight;

	public Color underWaterLightColor;

	public float underWaterIntensity;

	public bool cannotAttack;

	private bool onEnter;

	private bool onUnderwater;

	private GameObject mainCam;

	private GameObject player;

	private bool jumping;

	public Underwater()
	{
		surfaceEnterPlus = 0.4f;
		surfaceExitPlus = 0.95f;
		fogDensity = 0.04f;
		fogColor = new Color(0f, 0.4f, 0.7f, 0.6f);
		divingTime = 1f;
		underWaterLightColor = new Color(0f, 0.4f, 0.7f, 0.6f);
		underWaterIntensity = 0.5f;
		cannotAttack = true;
	}

	public  void Start()
	{
		if (!mainCam)
		{
			mainCam = GameObject.FindWithTag("MainCamera");
		}
		if (!surface)
		{
			surface = gameObject;
		}
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		if ((bool)mainLight)
		{
			defaultLightColor = ((Light)mainLight.GetComponent(typeof(Light))).color;
			defaultLightIntensity = ((Light)mainLight.GetComponent(typeof(Light))).intensity;
		}
	}

	public  void Update()
	{
		if (!mainCam)
		{
			mainCam = GameObject.FindWithTag("MainCamera");
		}
		Vector3 position = mainCam.transform.position;
		float y = position.y;
		Vector3 position2 = surface.transform.position;
		if (!(y >= position2.y))
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = fogColor;
			RenderSettings.fogDensity = fogDensity;
			if ((bool)mainLight)
			{
				((Light)mainLight.GetComponent(typeof(Light))).color = underWaterLightColor;
				((Light)mainLight.GetComponent(typeof(Light))).intensity = underWaterIntensity;
			}
		}
		else
		{
			RenderSettings.fog = defaultFog;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogDensity = defaultFogDensity;
			if ((bool)mainLight)
			{
				((Light)mainLight.GetComponent(typeof(Light))).color = defaultLightColor;
				((Light)mainLight.GetComponent(typeof(Light))).intensity = defaultLightIntensity;
			}
		}
		if (!player)
		{
			player = GameObject.FindWithTag("Player");
			return;
		}
		if (jumping && (bool)player)
		{
			((CharacterController)player.GetComponent(typeof(CharacterController))).Move(Vector3.up * 6f * Time.deltaTime);
		}
		Vector3 position3 = player.transform.position;
		float y2 = position3.y;
		Vector3 position4 = surface.transform.position;
		if (!(y2 >= position4.y - surfaceEnterPlus) && !onUnderwater)
		{
			if ((bool)hitEffect)
			{
				UnityEngine.Object.Instantiate(hitEffect, player.transform.position, player.transform.rotation);
			}
			StartCoroutine(ActivateWaterController());
		}
		else if (onUnderwater)
		{
			Vector3 position5 = player.transform.position;
			float y3 = position5.y;
			Vector3 position6 = surface.transform.position;
			if (!(y3 <= position6.y - surfaceExitPlus))
			{
				StartCoroutine(ActivateGroundController());
			}
		}
	}

	public  IEnumerator ActivateWaterController()
	{
		return new _0024ActivateWaterController_0024283(this).GetEnumerator();
	}

	public  IEnumerator ActivateGroundController()
	{
		return new _0024ActivateGroundController_0024286(this).GetEnumerator();
	}

	public  void Main()
	{
	}
}
