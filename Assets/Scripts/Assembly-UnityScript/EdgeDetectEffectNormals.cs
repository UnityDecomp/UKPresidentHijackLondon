using System;
using UnityEngine;

// Token: 0x020000CF RID: 207
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Edge Detection/Edge Detection")]
[ExecuteInEditMode]
[Serializable]
public class EdgeDetectEffectNormals : PostEffectsBase
{
	// Token: 0x060002C4 RID: 708 RVA: 0x000237C8 File Offset: 0x000219C8
	public EdgeDetectEffectNormals()
	{
		this.mode = EdgeDetectMode.SobelDepthThin;
		this.sensitivityDepth = 1f;
		this.sensitivityNormals = 1f;
		this.lumThreshhold = 0.2f;
		this.edgeExp = 1f;
		this.sampleDist = 1f;
		this.edgesOnlyBgColor = Color.white;
		this.oldMode = EdgeDetectMode.SobelDepthThin;
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0002382C File Offset: 0x00021A2C
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.edgeDetectMaterial = this.CheckShaderAndCreateMaterial(this.edgeDetectShader, this.edgeDetectMaterial);
		if (this.mode != this.oldMode)
		{
			this.SetCameraFlag();
		}
		this.oldMode = this.mode;
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x00023894 File Offset: 0x00021A94
	public override void Start()
	{
		this.oldMode = this.mode;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x000238A4 File Offset: 0x00021AA4
	public virtual void SetCameraFlag()
	{
		if (this.mode > EdgeDetectMode.RobertsCrossDepthNormals)
		{
			this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.Depth);
		}
		else
		{
			this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.DepthNormals);
		}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x000238F4 File Offset: 0x00021AF4
	public override void OnEnable()
	{
		this.SetCameraFlag();
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x000238FC File Offset: 0x00021AFC
	[ImageEffectOpaque]
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			Vector2 vector = new Vector2(this.sensitivityDepth, this.sensitivityNormals);
			this.edgeDetectMaterial.SetVector("_Sensitivity", new Vector4(vector.x, vector.y, 1f, vector.y));
			this.edgeDetectMaterial.SetFloat("_BgFade", this.edgesOnly);
			this.edgeDetectMaterial.SetFloat("_SampleDistance", this.sampleDist);
			this.edgeDetectMaterial.SetVector("_BgColor", this.edgesOnlyBgColor);
			this.edgeDetectMaterial.SetFloat("_Exponent", this.edgeExp);
			this.edgeDetectMaterial.SetFloat("_Threshold", this.lumThreshhold);
			Graphics.Blit(source, destination, this.edgeDetectMaterial, (int)this.mode);
		}
	}

	// Token: 0x060002CA RID: 714 RVA: 0x000239E8 File Offset: 0x00021BE8
	public override void Main()
	{
	}

	// Token: 0x0400052C RID: 1324
	public EdgeDetectMode mode;

	// Token: 0x0400052D RID: 1325
	public float sensitivityDepth;

	// Token: 0x0400052E RID: 1326
	public float sensitivityNormals;

	// Token: 0x0400052F RID: 1327
	public float lumThreshhold;

	// Token: 0x04000530 RID: 1328
	public float edgeExp;

	// Token: 0x04000531 RID: 1329
	public float sampleDist;

	// Token: 0x04000532 RID: 1330
	public float edgesOnly;

	// Token: 0x04000533 RID: 1331
	public Color edgesOnlyBgColor;

	// Token: 0x04000534 RID: 1332
	public Shader edgeDetectShader;

	// Token: 0x04000535 RID: 1333
	private Material edgeDetectMaterial;

	// Token: 0x04000536 RID: 1334
	private EdgeDetectMode oldMode;
}
