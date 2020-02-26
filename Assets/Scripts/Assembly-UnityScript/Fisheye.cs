using System;
using UnityEngine;

// Token: 0x020000D3 RID: 211
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Displacement/Fisheye")]
[Serializable]
public class Fisheye : PostEffectsBase
{
	// Token: 0x060002D0 RID: 720 RVA: 0x00023C50 File Offset: 0x00021E50
	public Fisheye()
	{
		this.strengthX = 0.05f;
		this.strengthY = 0.05f;
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x00023C70 File Offset: 0x00021E70
	public override bool CheckResources()
	{
		this.CheckSupport(false);
		this.fisheyeMaterial = this.CheckShaderAndCreateMaterial(this.fishEyeShader, this.fisheyeMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x00023CAC File Offset: 0x00021EAC
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			float num = 0.15625f;
			float num2 = (float)source.width * 1f / ((float)source.height * 1f);
			this.fisheyeMaterial.SetVector("intensity", new Vector4(this.strengthX * num2 * num, this.strengthY * num, this.strengthX * num2 * num, this.strengthY * num));
			Graphics.Blit(source, destination, this.fisheyeMaterial);
		}
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x00023D38 File Offset: 0x00021F38
	public override void Main()
	{
	}

	// Token: 0x04000545 RID: 1349
	public float strengthX;

	// Token: 0x04000546 RID: 1350
	public float strengthY;

	// Token: 0x04000547 RID: 1351
	public Shader fishEyeShader;

	// Token: 0x04000548 RID: 1352
	private Material fisheyeMaterial;
}
