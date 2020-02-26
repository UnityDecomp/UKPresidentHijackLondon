using System;
using UnityEngine;

// Token: 0x020000BF RID: 191
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Camera/Camera Motion Blur")]
[Serializable]
public class CameraMotionBlur : PostEffectsBase
{
	// Token: 0x06000282 RID: 642 RVA: 0x0001FDF8 File Offset: 0x0001DFF8
	public CameraMotionBlur()
	{
		this.filterType = CameraMotionBlur.MotionBlurFilter.Reconstruction;
		this.previewScale = Vector3.one;
		this.rotationScale = 1f;
		this.maxVelocity = 8f;
		this.minVelocity = 0.1f;
		this.velocityScale = 0.375f;
		this.softZDistance = 0.005f;
		this.velocityDownsample = 1;
		this.jitter = 0.05f;
		this.showVelocityScale = 1f;
		this.prevFrameForward = Vector3.forward;
		this.prevFrameRight = Vector3.right;
		this.prevFrameUp = Vector3.up;
		this.prevFramePos = Vector3.zero;
	}

	// Token: 0x06000284 RID: 644 RVA: 0x0001FEB0 File Offset: 0x0001E0B0
	private void CalculateViewProjection()
	{
		Matrix4x4 worldToCameraMatrix = this.GetComponent<Camera>().worldToCameraMatrix;
		Matrix4x4 gpuprojectionMatrix = GL.GetGPUProjectionMatrix(this.GetComponent<Camera>().projectionMatrix, true);
		this.currentViewProjMat = gpuprojectionMatrix * worldToCameraMatrix;
	}

	// Token: 0x06000285 RID: 645 RVA: 0x0001FEE8 File Offset: 0x0001E0E8
	public override void Start()
	{
		this.CheckResources();
		this.wasActive = this.gameObject.activeInHierarchy;
		this.CalculateViewProjection();
		this.Remember();
		this.wasActive = false;
	}

	// Token: 0x06000286 RID: 646 RVA: 0x0001FF20 File Offset: 0x0001E120
	public override void OnEnable()
	{
		this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.Depth);
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0001FF48 File Offset: 0x0001E148
	public virtual void OnDisable()
	{
		if (null != this.motionBlurMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.motionBlurMaterial);
			this.motionBlurMaterial = null;
		}
		if (null != this.dx11MotionBlurMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.dx11MotionBlurMaterial);
			this.dx11MotionBlurMaterial = null;
		}
		if (null != this.tmpCam)
		{
			UnityEngine.Object.DestroyImmediate(this.tmpCam);
			this.tmpCam = null;
		}
	}

	// Token: 0x06000288 RID: 648 RVA: 0x0001FFC0 File Offset: 0x0001E1C0
	public override bool CheckResources()
	{
		this.CheckSupport(true, true);
		this.motionBlurMaterial = this.CheckShaderAndCreateMaterial(this.shader, this.motionBlurMaterial);
		if (this.supportDX11 && this.filterType == CameraMotionBlur.MotionBlurFilter.ReconstructionDX11)
		{
			this.dx11MotionBlurMaterial = this.CheckShaderAndCreateMaterial(this.dx11MotionBlurShader, this.dx11MotionBlurMaterial);
		}
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00020034 File Offset: 0x0001E234
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			if (this.filterType == CameraMotionBlur.MotionBlurFilter.CameraMotion)
			{
				this.StartFrame();
			}
			RenderTextureFormat format = (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGHalf)) ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.RGHalf;
			RenderTexture temporary = RenderTexture.GetTemporary(this.divRoundUp(source.width, this.velocityDownsample), this.divRoundUp(source.height, this.velocityDownsample), 0, format);
			this.maxVelocity = Mathf.Max(2f, this.maxVelocity);
			float value = this.maxVelocity;
			bool flag = false;
			if (this.filterType == CameraMotionBlur.MotionBlurFilter.ReconstructionDX11 && this.dx11MotionBlurMaterial == null)
			{
				flag = true;
			}
			int num;
			int height;
			if (this.filterType == CameraMotionBlur.MotionBlurFilter.Reconstruction || flag || this.filterType == CameraMotionBlur.MotionBlurFilter.ReconstructionDisc)
			{
				this.maxVelocity = Mathf.Min(this.maxVelocity, (float)CameraMotionBlur.MAX_RADIUS);
				num = this.divRoundUp(temporary.width, (int)this.maxVelocity);
				height = this.divRoundUp(temporary.height, (int)this.maxVelocity);
				value = (float)(temporary.width / num);
			}
			else
			{
				num = this.divRoundUp(temporary.width, (int)this.maxVelocity);
				height = this.divRoundUp(temporary.height, (int)this.maxVelocity);
				value = (float)(temporary.width / num);
			}
			RenderTexture temporary2 = RenderTexture.GetTemporary(num, height, 0, format);
			RenderTexture temporary3 = RenderTexture.GetTemporary(num, height, 0, format);
			temporary.filterMode = FilterMode.Point;
			temporary2.filterMode = FilterMode.Point;
			temporary3.filterMode = FilterMode.Point;
			if (this.noiseTexture)
			{
				this.noiseTexture.filterMode = FilterMode.Point;
			}
			source.wrapMode = TextureWrapMode.Clamp;
			temporary.wrapMode = TextureWrapMode.Clamp;
			temporary3.wrapMode = TextureWrapMode.Clamp;
			temporary2.wrapMode = TextureWrapMode.Clamp;
			this.CalculateViewProjection();
			if (this.gameObject.activeInHierarchy && !this.wasActive)
			{
				this.Remember();
			}
			this.wasActive = this.gameObject.activeInHierarchy;
			Matrix4x4 matrix4x = Matrix4x4.Inverse(this.currentViewProjMat);
			this.motionBlurMaterial.SetMatrix("_InvViewProj", matrix4x);
			this.motionBlurMaterial.SetMatrix("_PrevViewProj", this.prevViewProjMat);
			this.motionBlurMaterial.SetMatrix("_ToPrevViewProjCombined", this.prevViewProjMat * matrix4x);
			this.motionBlurMaterial.SetFloat("_MaxVelocity", value);
			this.motionBlurMaterial.SetFloat("_MaxRadiusOrKInPaper", value);
			this.motionBlurMaterial.SetFloat("_MinVelocity", this.minVelocity);
			this.motionBlurMaterial.SetFloat("_VelocityScale", this.velocityScale);
			this.motionBlurMaterial.SetFloat("_Jitter", this.jitter);
			this.motionBlurMaterial.SetTexture("_NoiseTex", this.noiseTexture);
			this.motionBlurMaterial.SetTexture("_VelTex", temporary);
			this.motionBlurMaterial.SetTexture("_NeighbourMaxTex", temporary3);
			this.motionBlurMaterial.SetTexture("_TileTexDebug", temporary2);
			if (this.preview)
			{
				Matrix4x4 worldToCameraMatrix = this.GetComponent<Camera>().worldToCameraMatrix;
				Matrix4x4 identity = Matrix4x4.identity;
				identity.SetTRS(this.previewScale * 0.3333f, Quaternion.identity, Vector3.one);
				Matrix4x4 gpuprojectionMatrix = GL.GetGPUProjectionMatrix(this.GetComponent<Camera>().projectionMatrix, true);
				this.prevViewProjMat = gpuprojectionMatrix * identity * worldToCameraMatrix;
				this.motionBlurMaterial.SetMatrix("_PrevViewProj", this.prevViewProjMat);
				this.motionBlurMaterial.SetMatrix("_ToPrevViewProjCombined", this.prevViewProjMat * matrix4x);
			}
			if (this.filterType == CameraMotionBlur.MotionBlurFilter.CameraMotion)
			{
				Vector4 zero = Vector4.zero;
				float num2 = Vector3.Dot(this.transform.up, Vector3.up);
				Vector3 rhs = this.prevFramePos - this.transform.position;
				float magnitude = rhs.magnitude;
				float num3 = Vector3.Angle(this.transform.up, this.prevFrameUp) / this.GetComponent<Camera>().fieldOfView * ((float)source.width * 0.75f);
				zero.x = this.rotationScale * num3;
				num3 = Vector3.Angle(this.transform.forward, this.prevFrameForward) / this.GetComponent<Camera>().fieldOfView * ((float)source.width * 0.75f);
				zero.y = this.rotationScale * num2 * num3;
				num3 = Vector3.Angle(this.transform.forward, this.prevFrameForward) / this.GetComponent<Camera>().fieldOfView * ((float)source.width * 0.75f);
				zero.z = this.rotationScale * (1f - num2) * num3;
				if (magnitude > Mathf.Epsilon && this.movementScale > Mathf.Epsilon)
				{
					zero.w = this.movementScale * Vector3.Dot(this.transform.forward, rhs) * ((float)source.width * 0.5f);
					zero.x += this.movementScale * Vector3.Dot(this.transform.up, rhs) * ((float)source.width * 0.5f);
					zero.y += this.movementScale * Vector3.Dot(this.transform.right, rhs) * ((float)source.width * 0.5f);
				}
				if (this.preview)
				{
					this.motionBlurMaterial.SetVector("_BlurDirectionPacked", new Vector4(this.previewScale.y, this.previewScale.x, (float)0, this.previewScale.z) * 0.5f * this.GetComponent<Camera>().fieldOfView);
				}
				else
				{
					this.motionBlurMaterial.SetVector("_BlurDirectionPacked", zero);
				}
			}
			else
			{
				Graphics.Blit(source, temporary, this.motionBlurMaterial, 0);
				Camera camera = null;
				if (this.excludeLayers.value != 0)
				{
					camera = this.GetTmpCam();
				}
				if (camera && this.excludeLayers.value != 0 && this.replacementClear && this.replacementClear.isSupported)
				{
					camera.targetTexture = temporary;
					camera.cullingMask = this.excludeLayers;
					camera.RenderWithShader(this.replacementClear, string.Empty);
				}
			}
			if (!this.preview && Time.frameCount != this.prevFrameCount)
			{
				this.prevFrameCount = Time.frameCount;
				this.Remember();
			}
			source.filterMode = FilterMode.Bilinear;
			if (this.showVelocity)
			{
				this.motionBlurMaterial.SetFloat("_DisplayVelocityScale", this.showVelocityScale);
				Graphics.Blit(temporary, destination, this.motionBlurMaterial, 1);
			}
			else if (this.filterType == CameraMotionBlur.MotionBlurFilter.ReconstructionDX11 && !flag)
			{
				this.dx11MotionBlurMaterial.SetFloat("_MinVelocity", this.minVelocity);
				this.dx11MotionBlurMaterial.SetFloat("_VelocityScale", this.velocityScale);
				this.dx11MotionBlurMaterial.SetFloat("_Jitter", this.jitter);
				this.dx11MotionBlurMaterial.SetTexture("_NoiseTex", this.noiseTexture);
				this.dx11MotionBlurMaterial.SetTexture("_VelTex", temporary);
				this.dx11MotionBlurMaterial.SetTexture("_NeighbourMaxTex", temporary3);
				this.dx11MotionBlurMaterial.SetFloat("_SoftZDistance", Mathf.Max(0.00025f, this.softZDistance));
				this.dx11MotionBlurMaterial.SetFloat("_MaxRadiusOrKInPaper", value);
				Graphics.Blit(temporary, temporary2, this.dx11MotionBlurMaterial, 0);
				Graphics.Blit(temporary2, temporary3, this.dx11MotionBlurMaterial, 1);
				Graphics.Blit(source, destination, this.dx11MotionBlurMaterial, 2);
			}
			else if (this.filterType == CameraMotionBlur.MotionBlurFilter.Reconstruction || flag)
			{
				this.motionBlurMaterial.SetFloat("_SoftZDistance", Mathf.Max(0.00025f, this.softZDistance));
				Graphics.Blit(temporary, temporary2, this.motionBlurMaterial, 2);
				Graphics.Blit(temporary2, temporary3, this.motionBlurMaterial, 3);
				Graphics.Blit(source, destination, this.motionBlurMaterial, 4);
			}
			else if (this.filterType == CameraMotionBlur.MotionBlurFilter.CameraMotion)
			{
				Graphics.Blit(source, destination, this.motionBlurMaterial, 6);
			}
			else if (this.filterType == CameraMotionBlur.MotionBlurFilter.ReconstructionDisc)
			{
				this.motionBlurMaterial.SetFloat("_SoftZDistance", Mathf.Max(0.00025f, this.softZDistance));
				Graphics.Blit(temporary, temporary2, this.motionBlurMaterial, 2);
				Graphics.Blit(temporary2, temporary3, this.motionBlurMaterial, 3);
				Graphics.Blit(source, destination, this.motionBlurMaterial, 7);
			}
			else
			{
				Graphics.Blit(source, destination, this.motionBlurMaterial, 5);
			}
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary3);
		}
	}

	// Token: 0x0600028A RID: 650 RVA: 0x00020910 File Offset: 0x0001EB10
	public virtual void Remember()
	{
		this.prevViewProjMat = this.currentViewProjMat;
		this.prevFrameForward = this.transform.forward;
		this.prevFrameRight = this.transform.right;
		this.prevFrameUp = this.transform.up;
		this.prevFramePos = this.transform.position;
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00020970 File Offset: 0x0001EB70
	public virtual Camera GetTmpCam()
	{
		if (this.tmpCam == null)
		{
			string name = "_" + this.GetComponent<Camera>().name + "_MotionBlurTmpCam";
			GameObject y = GameObject.Find(name);
			if (null == y)
			{
				this.tmpCam = new GameObject(name, new Type[]
				{
					typeof(Camera)
				});
			}
			else
			{
				this.tmpCam = y;
			}
		}
		this.tmpCam.hideFlags = HideFlags.DontSave;
		this.tmpCam.transform.position = this.GetComponent<Camera>().transform.position;
		this.tmpCam.transform.rotation = this.GetComponent<Camera>().transform.rotation;
		this.tmpCam.transform.localScale = this.GetComponent<Camera>().transform.localScale;
		this.tmpCam.GetComponent<Camera>().CopyFrom(this.GetComponent<Camera>());
		this.tmpCam.GetComponent<Camera>().enabled = false;
		this.tmpCam.GetComponent<Camera>().depthTextureMode = DepthTextureMode.None;
		this.tmpCam.GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;
		return this.tmpCam.GetComponent<Camera>();
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00020AB0 File Offset: 0x0001ECB0
	public virtual void StartFrame()
	{
		this.prevFramePos = Vector3.Slerp(this.prevFramePos, this.transform.position, 0.75f);
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00020AE0 File Offset: 0x0001ECE0
	public virtual int divRoundUp(int x, int d)
	{
		return (x + d - 1) / d;
	}

	// Token: 0x0600028E RID: 654 RVA: 0x00020AEC File Offset: 0x0001ECEC
	public override void Main()
	{
	}

	// Token: 0x0400047B RID: 1147
	[NonSerialized]
	public static int MAX_RADIUS = (int)10f;

	// Token: 0x0400047C RID: 1148
	public CameraMotionBlur.MotionBlurFilter filterType;

	// Token: 0x0400047D RID: 1149
	public bool preview;

	// Token: 0x0400047E RID: 1150
	public Vector3 previewScale;

	// Token: 0x0400047F RID: 1151
	public float movementScale;

	// Token: 0x04000480 RID: 1152
	public float rotationScale;

	// Token: 0x04000481 RID: 1153
	public float maxVelocity;

	// Token: 0x04000482 RID: 1154
	public float minVelocity;

	// Token: 0x04000483 RID: 1155
	public float velocityScale;

	// Token: 0x04000484 RID: 1156
	public float softZDistance;

	// Token: 0x04000485 RID: 1157
	public int velocityDownsample;

	// Token: 0x04000486 RID: 1158
	public LayerMask excludeLayers;

	// Token: 0x04000487 RID: 1159
	private GameObject tmpCam;

	// Token: 0x04000488 RID: 1160
	public Shader shader;

	// Token: 0x04000489 RID: 1161
	public Shader dx11MotionBlurShader;

	// Token: 0x0400048A RID: 1162
	public Shader replacementClear;

	// Token: 0x0400048B RID: 1163
	private Material motionBlurMaterial;

	// Token: 0x0400048C RID: 1164
	private Material dx11MotionBlurMaterial;

	// Token: 0x0400048D RID: 1165
	public Texture2D noiseTexture;

	// Token: 0x0400048E RID: 1166
	public float jitter;

	// Token: 0x0400048F RID: 1167
	public bool showVelocity;

	// Token: 0x04000490 RID: 1168
	public float showVelocityScale;

	// Token: 0x04000491 RID: 1169
	private Matrix4x4 currentViewProjMat;

	// Token: 0x04000492 RID: 1170
	private Matrix4x4 prevViewProjMat;

	// Token: 0x04000493 RID: 1171
	private int prevFrameCount;

	// Token: 0x04000494 RID: 1172
	private bool wasActive;

	// Token: 0x04000495 RID: 1173
	private Vector3 prevFrameForward;

	// Token: 0x04000496 RID: 1174
	private Vector3 prevFrameRight;

	// Token: 0x04000497 RID: 1175
	private Vector3 prevFrameUp;

	// Token: 0x04000498 RID: 1176
	private Vector3 prevFramePos;

	// Token: 0x020000C0 RID: 192
	[Serializable]
	public enum MotionBlurFilter
	{
		// Token: 0x0400049A RID: 1178
		CameraMotion,
		// Token: 0x0400049B RID: 1179
		LocalBlur,
		// Token: 0x0400049C RID: 1180
		Reconstruction,
		// Token: 0x0400049D RID: 1181
		ReconstructionDX11,
		// Token: 0x0400049E RID: 1182
		ReconstructionDisc
	}
}
