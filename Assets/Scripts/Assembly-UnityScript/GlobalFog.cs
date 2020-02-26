using System;
using UnityEngine;

// Token: 0x020000D4 RID: 212
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Rendering/Global Fog")]
[RequireComponent(typeof(Camera))]
[Serializable]
public class GlobalFog : PostEffectsBase
{
	// Token: 0x060002D4 RID: 724 RVA: 0x00023D3C File Offset: 0x00021F3C
	public GlobalFog()
	{
		this.fogMode = GlobalFog.FogMode.AbsoluteYAndDistance;
		this.CAMERA_NEAR = 0.5f;
		this.CAMERA_FAR = 50f;
		this.CAMERA_FOV = 60f;
		this.CAMERA_ASPECT_RATIO = 1.333333f;
		this.startDistance = 200f;
		this.globalDensity = 1f;
		this.heightScale = 100f;
		this.globalFogColor = Color.grey;
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x00023DB0 File Offset: 0x00021FB0
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.fogMaterial = this.CheckShaderAndCreateMaterial(this.fogShader, this.fogMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00023DEC File Offset: 0x00021FEC
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			this.CAMERA_NEAR = this.GetComponent<Camera>().nearClipPlane;
			this.CAMERA_FAR = this.GetComponent<Camera>().farClipPlane;
			this.CAMERA_FOV = this.GetComponent<Camera>().fieldOfView;
			this.CAMERA_ASPECT_RATIO = this.GetComponent<Camera>().aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			Vector4 vector = default(Vector4);
			Vector3 vector2 = default(Vector3);
			float num = this.CAMERA_FOV * 0.5f;
			Vector3 b = this.GetComponent<Camera>().transform.right * this.CAMERA_NEAR * Mathf.Tan(num * 0.0174532924f) * this.CAMERA_ASPECT_RATIO;
			Vector3 b2 = this.GetComponent<Camera>().transform.up * this.CAMERA_NEAR * Mathf.Tan(num * 0.0174532924f);
			Vector3 vector3 = this.GetComponent<Camera>().transform.forward * this.CAMERA_NEAR - b + b2;
			float num2 = vector3.magnitude * this.CAMERA_FAR / this.CAMERA_NEAR;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = this.GetComponent<Camera>().transform.forward * this.CAMERA_NEAR + b + b2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = this.GetComponent<Camera>().transform.forward * this.CAMERA_NEAR + b - b2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = this.GetComponent<Camera>().transform.forward * this.CAMERA_NEAR - b - b2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(0, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(2, vector5);
			identity.SetRow(3, vector6);
			this.fogMaterial.SetMatrix("_FrustumCornersWS", identity);
			this.fogMaterial.SetVector("_CameraWS", this.GetComponent<Camera>().transform.position);
			this.fogMaterial.SetVector("_StartDistance", new Vector4(1f / this.startDistance, num2 - this.startDistance));
			this.fogMaterial.SetVector("_Y", new Vector4(this.height, 1f / this.heightScale));
			this.fogMaterial.SetFloat("_GlobalDensity", this.globalDensity * 0.01f);
			this.fogMaterial.SetColor("_FogColor", this.globalFogColor);
			GlobalFog.CustomGraphicsBlit(source, destination, this.fogMaterial, (int)this.fogMode);
		}
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x000240F4 File Offset: 0x000222F4
	public static void CustomGraphicsBlit(RenderTexture source, RenderTexture dest, Material fxMaterial, int passNr)
	{
		RenderTexture.active = dest;
		fxMaterial.SetTexture("_MainTex", source);
		GL.PushMatrix();
		GL.LoadOrtho();
		fxMaterial.SetPass(passNr);
		GL.Begin(7);
		GL.MultiTexCoord2(0, (float)0, (float)0);
		GL.Vertex3((float)0, (float)0, 3f);
		GL.MultiTexCoord2(0, 1f, (float)0);
		GL.Vertex3(1f, (float)0, 2f);
		GL.MultiTexCoord2(0, 1f, 1f);
		GL.Vertex3(1f, 1f, 1f);
		GL.MultiTexCoord2(0, (float)0, 1f);
		GL.Vertex3((float)0, 1f, (float)0);
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x000241AC File Offset: 0x000223AC
	public override void Main()
	{
	}

	// Token: 0x04000549 RID: 1353
	public GlobalFog.FogMode fogMode;

	// Token: 0x0400054A RID: 1354
	private float CAMERA_NEAR;

	// Token: 0x0400054B RID: 1355
	private float CAMERA_FAR;

	// Token: 0x0400054C RID: 1356
	private float CAMERA_FOV;

	// Token: 0x0400054D RID: 1357
	private float CAMERA_ASPECT_RATIO;

	// Token: 0x0400054E RID: 1358
	public float startDistance;

	// Token: 0x0400054F RID: 1359
	public float globalDensity;

	// Token: 0x04000550 RID: 1360
	public float heightScale;

	// Token: 0x04000551 RID: 1361
	public float height;

	// Token: 0x04000552 RID: 1362
	public Color globalFogColor;

	// Token: 0x04000553 RID: 1363
	public Shader fogShader;

	// Token: 0x04000554 RID: 1364
	private Material fogMaterial;

	// Token: 0x020000D5 RID: 213
	[Serializable]
	public enum FogMode
	{
		// Token: 0x04000556 RID: 1366
		AbsoluteYAndDistance,
		// Token: 0x04000557 RID: 1367
		AbsoluteY,
		// Token: 0x04000558 RID: 1368
		Distance,
		// Token: 0x04000559 RID: 1369
		RelativeYAndDistance
	}
}
