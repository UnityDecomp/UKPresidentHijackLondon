using System;
using UnityEngine;

// Token: 0x020000D7 RID: 215
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[Serializable]
public class PostEffectsBase : MonoBehaviour
{
	// Token: 0x060002DF RID: 735 RVA: 0x00024858 File Offset: 0x00022A58
	public PostEffectsBase()
	{
		this.supportHDRTextures = true;
		this.isSupported = true;
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00024870 File Offset: 0x00022A70
	public virtual Material CheckShaderAndCreateMaterial(Shader s, Material m2Create)
	{
		Material result;
		if (!s)
		{
			Debug.Log("Missing shader in " + this.ToString());
			this.enabled = false;
			result = null;
		}
		else if (s.isSupported && m2Create && m2Create.shader == s)
		{
			result = m2Create;
		}
		else if (!s.isSupported)
		{
			this.NotSupported();
			Debug.Log("The shader " + s.ToString() + " on effect " + this.ToString() + " is not supported on this platform!");
			result = null;
		}
		else
		{
			m2Create = new Material(s);
			m2Create.hideFlags = HideFlags.DontSave;
			result = ((!m2Create) ? null : m2Create);
		}
		return result;
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00024950 File Offset: 0x00022B50
	public virtual Material CreateMaterial(Shader s, Material m2Create)
	{
		Material result;
		if (!s)
		{
			Debug.Log("Missing shader in " + this.ToString());
			result = null;
		}
		else if (m2Create && m2Create.shader == s && s.isSupported)
		{
			result = m2Create;
		}
		else if (!s.isSupported)
		{
			result = null;
		}
		else
		{
			m2Create = new Material(s);
			m2Create.hideFlags = HideFlags.DontSave;
			result = ((!m2Create) ? null : m2Create);
		}
		return result;
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x000249EC File Offset: 0x00022BEC
	public virtual void OnEnable()
	{
		this.isSupported = true;
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x000249F8 File Offset: 0x00022BF8
	public virtual bool CheckSupport()
	{
		return this.CheckSupport(false);
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x00024A04 File Offset: 0x00022C04
	public virtual bool CheckResources()
	{
		Debug.LogWarning("CheckResources () for " + this.ToString() + " should be overwritten.");
		return this.isSupported;
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00024A2C File Offset: 0x00022C2C
	public virtual void Start()
	{
		this.CheckResources();
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x00024A38 File Offset: 0x00022C38
	public virtual bool CheckSupport(bool needDepth)
	{
		this.isSupported = true;
		this.supportHDRTextures = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf);
		bool flag;
		if (flag = (SystemInfo.graphicsShaderLevel >= 50))
		{
			flag = SystemInfo.supportsComputeShaders;
		}
		this.supportDX11 = flag;
		bool result;
		if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures)
		{
			this.NotSupported();
			result = false;
		}
		else if (needDepth && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.NotSupported();
			result = false;
		}
		else
		{
			if (needDepth)
			{
				this.GetComponent<Camera>().depthTextureMode = (this.GetComponent<Camera>().depthTextureMode | DepthTextureMode.Depth);
			}
			result = true;
		}
		return result;
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x00024AD4 File Offset: 0x00022CD4
	public virtual bool CheckSupport(bool needDepth, bool needHdr)
	{
		bool result;
		if (!this.CheckSupport(needDepth))
		{
			result = false;
		}
		else if (needHdr && !this.supportHDRTextures)
		{
			this.NotSupported();
			result = false;
		}
		else
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x00024B14 File Offset: 0x00022D14
	public virtual bool Dx11Support()
	{
		return this.supportDX11;
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x00024B1C File Offset: 0x00022D1C
	public virtual void ReportAutoDisable()
	{
		Debug.LogWarning("The image effect " + this.ToString() + " has been disabled as it's not supported on the current platform.");
	}

	// Token: 0x060002EA RID: 746 RVA: 0x00024B40 File Offset: 0x00022D40
	public virtual bool CheckShader(Shader s)
	{
		Debug.Log("The shader " + s.ToString() + " on effect " + this.ToString() + " is not part of the Unity 3.2+ effects suite anymore. For best performance and quality, please ensure you are using the latest Standard Assets Image Effects (Pro only) package.");
		bool result;
		if (!s.isSupported)
		{
			this.NotSupported();
			result = false;
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060002EB RID: 747 RVA: 0x00024BA0 File Offset: 0x00022DA0
	public virtual void NotSupported()
	{
		this.enabled = false;
		this.isSupported = false;
	}

	// Token: 0x060002EC RID: 748 RVA: 0x00024BB0 File Offset: 0x00022DB0
	public virtual void DrawBorder(RenderTexture dest, Material material)
	{
		float x = 0f;
		float x2 = 0f;
		float y = 0f;
		float y2 = 0f;
		RenderTexture.active = dest;
		bool flag = true;
		GL.PushMatrix();
		GL.LoadOrtho();
		for (int i = 0; i < material.passCount; i++)
		{
			material.SetPass(i);
			float y3 = 0f;
			float y4 = 0f;
			if (flag)
			{
				y3 = 1f;
				y4 = (float)0;
			}
			else
			{
				y3 = (float)0;
				y4 = 1f;
			}
			x = (float)0;
			x2 = (float)0 + 1f / ((float)dest.width * 1f);
			y = (float)0;
			y2 = 1f;
			GL.Begin(7);
			GL.TexCoord2((float)0, y3);
			GL.Vertex3(x, y, 0.1f);
			GL.TexCoord2(1f, y3);
			GL.Vertex3(x2, y, 0.1f);
			GL.TexCoord2(1f, y4);
			GL.Vertex3(x2, y2, 0.1f);
			GL.TexCoord2((float)0, y4);
			GL.Vertex3(x, y2, 0.1f);
			x = 1f - 1f / ((float)dest.width * 1f);
			x2 = 1f;
			y = (float)0;
			y2 = 1f;
			GL.TexCoord2((float)0, y3);
			GL.Vertex3(x, y, 0.1f);
			GL.TexCoord2(1f, y3);
			GL.Vertex3(x2, y, 0.1f);
			GL.TexCoord2(1f, y4);
			GL.Vertex3(x2, y2, 0.1f);
			GL.TexCoord2((float)0, y4);
			GL.Vertex3(x, y2, 0.1f);
			x = (float)0;
			x2 = 1f;
			y = (float)0;
			y2 = (float)0 + 1f / ((float)dest.height * 1f);
			GL.TexCoord2((float)0, y3);
			GL.Vertex3(x, y, 0.1f);
			GL.TexCoord2(1f, y3);
			GL.Vertex3(x2, y, 0.1f);
			GL.TexCoord2(1f, y4);
			GL.Vertex3(x2, y2, 0.1f);
			GL.TexCoord2((float)0, y4);
			GL.Vertex3(x, y2, 0.1f);
			x = (float)0;
			x2 = 1f;
			y = 1f - 1f / ((float)dest.height * 1f);
			y2 = 1f;
			GL.TexCoord2((float)0, y3);
			GL.Vertex3(x, y, 0.1f);
			GL.TexCoord2(1f, y3);
			GL.Vertex3(x2, y, 0.1f);
			GL.TexCoord2(1f, y4);
			GL.Vertex3(x2, y2, 0.1f);
			GL.TexCoord2((float)0, y4);
			GL.Vertex3(x, y2, 0.1f);
			GL.End();
		}
		GL.PopMatrix();
	}

	// Token: 0x060002ED RID: 749 RVA: 0x00024E58 File Offset: 0x00023058
	public virtual void Main()
	{
	}

	// Token: 0x0400056C RID: 1388
	protected bool supportHDRTextures;

	// Token: 0x0400056D RID: 1389
	protected bool supportDX11;

	// Token: 0x0400056E RID: 1390
	protected bool isSupported;
}
