using System;
using UnityEngine;

// Token: 0x0200019F RID: 415
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Rendering/Screen Space Ambient Occlusion")]
public class SSAOEffect : MonoBehaviour
{
	// Token: 0x06000B9F RID: 2975 RVA: 0x000488D4 File Offset: 0x00046CD4
	private static Material CreateMaterial(Shader shader)
	{
		if (!shader)
		{
			return null;
		}
		return new Material(shader)
		{
			hideFlags = HideFlags.HideAndDontSave
		};
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x000488FE File Offset: 0x00046CFE
	private static void DestroyMaterial(Material mat)
	{
		if (mat)
		{
			UnityEngine.Object.DestroyImmediate(mat);
			mat = null;
		}
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x00048914 File Offset: 0x00046D14
	private void OnDisable()
	{
		SSAOEffect.DestroyMaterial(this.m_SSAOMaterial);
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x00048924 File Offset: 0x00046D24
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects || !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.m_Supported = false;
			base.enabled = false;
			return;
		}
		this.CreateMaterials();
		if (!this.m_SSAOMaterial || this.m_SSAOMaterial.passCount != 5)
		{
			this.m_Supported = false;
			base.enabled = false;
			return;
		}
		this.m_Supported = true;
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x00048992 File Offset: 0x00046D92
	private void OnEnable()
	{
		base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x000489A8 File Offset: 0x00046DA8
	private void CreateMaterials()
	{
		if (!this.m_SSAOMaterial && this.m_SSAOShader.isSupported)
		{
			this.m_SSAOMaterial = SSAOEffect.CreateMaterial(this.m_SSAOShader);
			this.m_SSAOMaterial.SetTexture("_RandomTexture", this.m_RandomTexture);
		}
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x000489FC File Offset: 0x00046DFC
	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.m_Supported || !this.m_SSAOShader.isSupported)
		{
			base.enabled = false;
			return;
		}
		this.CreateMaterials();
		this.m_Downsampling = Mathf.Clamp(this.m_Downsampling, 1, 6);
		this.m_Radius = Mathf.Clamp(this.m_Radius, 0.05f, 1f);
		this.m_MinZ = Mathf.Clamp(this.m_MinZ, 1E-05f, 0.5f);
		this.m_OcclusionIntensity = Mathf.Clamp(this.m_OcclusionIntensity, 0.5f, 4f);
		this.m_OcclusionAttenuation = Mathf.Clamp(this.m_OcclusionAttenuation, 0.2f, 2f);
		this.m_Blur = Mathf.Clamp(this.m_Blur, 0, 4);
		RenderTexture renderTexture = RenderTexture.GetTemporary(source.width / this.m_Downsampling, source.height / this.m_Downsampling, 0);
		float fieldOfView = base.GetComponent<Camera>().fieldOfView;
		float farClipPlane = base.GetComponent<Camera>().farClipPlane;
		float num = Mathf.Tan(fieldOfView * 0.0174532924f * 0.5f) * farClipPlane;
		float x = num * base.GetComponent<Camera>().aspect;
		this.m_SSAOMaterial.SetVector("_FarCorner", new Vector3(x, num, farClipPlane));
		int num2;
		int num3;
		if (this.m_RandomTexture)
		{
			num2 = this.m_RandomTexture.width;
			num3 = this.m_RandomTexture.height;
		}
		else
		{
			num2 = 1;
			num3 = 1;
		}
		this.m_SSAOMaterial.SetVector("_NoiseScale", new Vector3((float)renderTexture.width / (float)num2, (float)renderTexture.height / (float)num3, 0f));
		this.m_SSAOMaterial.SetVector("_Params", new Vector4(this.m_Radius, this.m_MinZ, 1f / this.m_OcclusionAttenuation, this.m_OcclusionIntensity));
		bool flag = this.m_Blur > 0;
		Graphics.Blit((!flag) ? source : null, renderTexture, this.m_SSAOMaterial, (int)this.m_SampleCount);
		if (flag)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0);
			this.m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4((float)this.m_Blur / (float)source.width, 0f, 0f, 0f));
			this.m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
			Graphics.Blit(null, temporary, this.m_SSAOMaterial, 3);
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0);
			this.m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4(0f, (float)this.m_Blur / (float)source.height, 0f, 0f));
			this.m_SSAOMaterial.SetTexture("_SSAO", temporary);
			Graphics.Blit(source, temporary2, this.m_SSAOMaterial, 3);
			RenderTexture.ReleaseTemporary(temporary);
			renderTexture = temporary2;
		}
		this.m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
		Graphics.Blit(source, destination, this.m_SSAOMaterial, 4);
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	// Token: 0x04000B86 RID: 2950
	public float m_Radius = 0.4f;

	// Token: 0x04000B87 RID: 2951
	public SSAOEffect.SSAOSamples m_SampleCount = SSAOEffect.SSAOSamples.Medium;

	// Token: 0x04000B88 RID: 2952
	public float m_OcclusionIntensity = 1.5f;

	// Token: 0x04000B89 RID: 2953
	public int m_Blur = 2;

	// Token: 0x04000B8A RID: 2954
	public int m_Downsampling = 2;

	// Token: 0x04000B8B RID: 2955
	public float m_OcclusionAttenuation = 1f;

	// Token: 0x04000B8C RID: 2956
	public float m_MinZ = 0.01f;

	// Token: 0x04000B8D RID: 2957
	public Shader m_SSAOShader;

	// Token: 0x04000B8E RID: 2958
	private Material m_SSAOMaterial;

	// Token: 0x04000B8F RID: 2959
	public Texture2D m_RandomTexture;

	// Token: 0x04000B90 RID: 2960
	private bool m_Supported;

	// Token: 0x020001A0 RID: 416
	public enum SSAOSamples
	{
		// Token: 0x04000B92 RID: 2962
		Low,
		// Token: 0x04000B93 RID: 2963
		Medium,
		// Token: 0x04000B94 RID: 2964
		High
	}
}
