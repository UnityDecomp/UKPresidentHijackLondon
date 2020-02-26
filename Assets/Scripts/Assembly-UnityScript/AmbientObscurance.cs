using System;
using UnityEngine;

// Token: 0x020000AF RID: 175
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Rendering/Screen Space Ambient Obscurance")]
[Serializable]
public class AmbientObscurance : PostEffectsBase
{
	// Token: 0x06000262 RID: 610 RVA: 0x0001DEF0 File Offset: 0x0001C0F0
	public AmbientObscurance()
	{
		this.intensity = 0.5f;
		this.radius = 0.2f;
		this.blurIterations = 1;
		this.blurFilterDistance = 1.25f;
	}

	// Token: 0x06000263 RID: 611 RVA: 0x0001DF2C File Offset: 0x0001C12C
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.aoMaterial = this.CheckShaderAndCreateMaterial(this.aoShader, this.aoMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000264 RID: 612 RVA: 0x0001DF68 File Offset: 0x0001C168
	public virtual void OnDisable()
	{
		if (this.aoMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.aoMaterial);
		}
		this.aoMaterial = null;
	}

	// Token: 0x06000265 RID: 613 RVA: 0x0001DF98 File Offset: 0x0001C198
	[ImageEffectOpaque]
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			Matrix4x4 projectionMatrix = this.GetComponent<Camera>().projectionMatrix;
			Matrix4x4 inverse = projectionMatrix.inverse;
			Vector4 value = new Vector4(-2f / ((float)Screen.width * projectionMatrix[0]), -2f / ((float)Screen.height * projectionMatrix[5]), (1f - projectionMatrix[2]) / projectionMatrix[0], (1f + projectionMatrix[6]) / projectionMatrix[5]);
			this.aoMaterial.SetVector("_ProjInfo", value);
			this.aoMaterial.SetMatrix("_ProjectionInv", inverse);
			this.aoMaterial.SetTexture("_Rand", this.rand);
			this.aoMaterial.SetFloat("_Radius", this.radius);
			this.aoMaterial.SetFloat("_Radius2", this.radius * this.radius);
			this.aoMaterial.SetFloat("_Intensity", this.intensity);
			this.aoMaterial.SetFloat("_BlurFilterDistance", this.blurFilterDistance);
			int width = source.width;
			int height = source.height;
			RenderTexture renderTexture = RenderTexture.GetTemporary(width >> this.downsample, height >> this.downsample);
			Graphics.Blit(source, renderTexture, this.aoMaterial, 0);
			if (this.downsample > 0)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(width, height);
				Graphics.Blit(renderTexture, temporary, this.aoMaterial, 4);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
			}
			for (int i = 0; i < this.blurIterations; i++)
			{
				this.aoMaterial.SetVector("_Axis", new Vector2(1f, (float)0));
				RenderTexture temporary = RenderTexture.GetTemporary(width, height);
				Graphics.Blit(renderTexture, temporary, this.aoMaterial, 1);
				RenderTexture.ReleaseTemporary(renderTexture);
				this.aoMaterial.SetVector("_Axis", new Vector2((float)0, 1f));
				renderTexture = RenderTexture.GetTemporary(width, height);
				Graphics.Blit(temporary, renderTexture, this.aoMaterial, 1);
				RenderTexture.ReleaseTemporary(temporary);
			}
			this.aoMaterial.SetTexture("_AOTex", renderTexture);
			Graphics.Blit(source, destination, this.aoMaterial, 2);
			RenderTexture.ReleaseTemporary(renderTexture);
		}
	}

	// Token: 0x06000266 RID: 614 RVA: 0x0001E1F8 File Offset: 0x0001C3F8
	public override void Main()
	{
	}

	// Token: 0x040003EB RID: 1003
	[Range(0f, 3f)]
	public float intensity;

	// Token: 0x040003EC RID: 1004
	[Range(0.1f, 3f)]
	public float radius;

	// Token: 0x040003ED RID: 1005
	[Range(0f, 3f)]
	public int blurIterations;

	// Token: 0x040003EE RID: 1006
	[Range(0f, 5f)]
	public float blurFilterDistance;

	// Token: 0x040003EF RID: 1007
	[Range(0f, 1f)]
	public int downsample;

	// Token: 0x040003F0 RID: 1008
	public Texture2D rand;

	// Token: 0x040003F1 RID: 1009
	public Shader aoShader;

	// Token: 0x040003F2 RID: 1010
	private Material aoMaterial;
}
