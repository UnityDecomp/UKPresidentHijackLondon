using System;
using UnityEngine;

// Token: 0x02000198 RID: 408
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Noise/Noise and Scratches")]
public class NoiseEffect : MonoBehaviour
{
	// Token: 0x06000B79 RID: 2937 RVA: 0x00047890 File Offset: 0x00045C90
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (this.shaderRGB == null || this.shaderYUV == null)
		{
			Debug.Log("Noise shaders are not set up! Disabling noise effect.");
			base.enabled = false;
		}
		else if (!this.shaderRGB.isSupported)
		{
			base.enabled = false;
		}
		else if (!this.shaderYUV.isSupported)
		{
			this.rgbFallback = true;
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x06000B7A RID: 2938 RVA: 0x0004791C File Offset: 0x00045D1C
	protected Material material
	{
		get
		{
			if (this.m_MaterialRGB == null)
			{
				this.m_MaterialRGB = new Material(this.shaderRGB);
				this.m_MaterialRGB.hideFlags = HideFlags.HideAndDontSave;
			}
			if (this.m_MaterialYUV == null && !this.rgbFallback)
			{
				this.m_MaterialYUV = new Material(this.shaderYUV);
				this.m_MaterialYUV.hideFlags = HideFlags.HideAndDontSave;
			}
			return (this.rgbFallback || this.monochrome) ? this.m_MaterialRGB : this.m_MaterialYUV;
		}
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x000479B9 File Offset: 0x00045DB9
	protected void OnDisable()
	{
		if (this.m_MaterialRGB)
		{
			UnityEngine.Object.DestroyImmediate(this.m_MaterialRGB);
		}
		if (this.m_MaterialYUV)
		{
			UnityEngine.Object.DestroyImmediate(this.m_MaterialYUV);
		}
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x000479F4 File Offset: 0x00045DF4
	private void SanitizeParameters()
	{
		this.grainIntensityMin = Mathf.Clamp(this.grainIntensityMin, 0f, 5f);
		this.grainIntensityMax = Mathf.Clamp(this.grainIntensityMax, 0f, 5f);
		this.scratchIntensityMin = Mathf.Clamp(this.scratchIntensityMin, 0f, 5f);
		this.scratchIntensityMax = Mathf.Clamp(this.scratchIntensityMax, 0f, 5f);
		this.scratchFPS = Mathf.Clamp(this.scratchFPS, 1f, 30f);
		this.scratchJitter = Mathf.Clamp(this.scratchJitter, 0f, 1f);
		this.grainSize = Mathf.Clamp(this.grainSize, 0.1f, 50f);
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x00047AC0 File Offset: 0x00045EC0
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.SanitizeParameters();
		if (this.scratchTimeLeft <= 0f)
		{
			this.scratchTimeLeft = UnityEngine.Random.value * 2f / this.scratchFPS;
			this.scratchX = UnityEngine.Random.value;
			this.scratchY = UnityEngine.Random.value;
		}
		this.scratchTimeLeft -= Time.deltaTime;
		Material material = this.material;
		material.SetTexture("_GrainTex", this.grainTexture);
		material.SetTexture("_ScratchTex", this.scratchTexture);
		float num = 1f / this.grainSize;
		material.SetVector("_GrainOffsetScale", new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, (float)Screen.width / (float)this.grainTexture.width * num, (float)Screen.height / (float)this.grainTexture.height * num));
		material.SetVector("_ScratchOffsetScale", new Vector4(this.scratchX + UnityEngine.Random.value * this.scratchJitter, this.scratchY + UnityEngine.Random.value * this.scratchJitter, (float)Screen.width / (float)this.scratchTexture.width, (float)Screen.height / (float)this.scratchTexture.height));
		material.SetVector("_Intensity", new Vector4(UnityEngine.Random.Range(this.grainIntensityMin, this.grainIntensityMax), UnityEngine.Random.Range(this.scratchIntensityMin, this.scratchIntensityMax), 0f, 0f));
		Graphics.Blit(source, destination, material);
	}

	// Token: 0x04000B5C RID: 2908
	public bool monochrome = true;

	// Token: 0x04000B5D RID: 2909
	private bool rgbFallback;

	// Token: 0x04000B5E RID: 2910
	public float grainIntensityMin = 0.1f;

	// Token: 0x04000B5F RID: 2911
	public float grainIntensityMax = 0.2f;

	// Token: 0x04000B60 RID: 2912
	public float grainSize = 2f;

	// Token: 0x04000B61 RID: 2913
	public float scratchIntensityMin = 0.05f;

	// Token: 0x04000B62 RID: 2914
	public float scratchIntensityMax = 0.25f;

	// Token: 0x04000B63 RID: 2915
	public float scratchFPS = 10f;

	// Token: 0x04000B64 RID: 2916
	public float scratchJitter = 0.01f;

	// Token: 0x04000B65 RID: 2917
	public Texture grainTexture;

	// Token: 0x04000B66 RID: 2918
	public Texture scratchTexture;

	// Token: 0x04000B67 RID: 2919
	public Shader shaderRGB;

	// Token: 0x04000B68 RID: 2920
	public Shader shaderYUV;

	// Token: 0x04000B69 RID: 2921
	private Material m_MaterialRGB;

	// Token: 0x04000B6A RID: 2922
	private Material m_MaterialYUV;

	// Token: 0x04000B6B RID: 2923
	private float scratchTimeLeft;

	// Token: 0x04000B6C RID: 2924
	private float scratchX;

	// Token: 0x04000B6D RID: 2925
	private float scratchY;
}
