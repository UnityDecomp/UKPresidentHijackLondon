using System;
using UnityEngine;

// Token: 0x02000124 RID: 292
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Bloom and Glow/Glow (Deprecated)")]
public class GlowEffect : MonoBehaviour
{
	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060007C0 RID: 1984 RVA: 0x00033E33 File Offset: 0x00032233
	protected Material compositeMaterial
	{
		get
		{
			if (this.m_CompositeMaterial == null)
			{
				this.m_CompositeMaterial = new Material(this.compositeShader);
				this.m_CompositeMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_CompositeMaterial;
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060007C1 RID: 1985 RVA: 0x00033E6A File Offset: 0x0003226A
	protected Material blurMaterial
	{
		get
		{
			if (this.m_BlurMaterial == null)
			{
				this.m_BlurMaterial = new Material(this.blurShader);
				this.m_BlurMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_BlurMaterial;
		}
	}

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060007C2 RID: 1986 RVA: 0x00033EA1 File Offset: 0x000322A1
	protected Material downsampleMaterial
	{
		get
		{
			if (this.m_DownsampleMaterial == null)
			{
				this.m_DownsampleMaterial = new Material(this.downsampleShader);
				this.m_DownsampleMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_DownsampleMaterial;
		}
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x00033ED8 File Offset: 0x000322D8
	protected void OnDisable()
	{
		if (this.m_CompositeMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.m_CompositeMaterial);
		}
		if (this.m_BlurMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.m_BlurMaterial);
		}
		if (this.m_DownsampleMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.m_DownsampleMaterial);
		}
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x00033F38 File Offset: 0x00032338
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (this.downsampleShader == null)
		{
			Debug.Log("No downsample shader assigned! Disabling glow.");
			base.enabled = false;
		}
		else
		{
			if (!this.blurMaterial.shader.isSupported)
			{
				base.enabled = false;
			}
			if (!this.compositeMaterial.shader.isSupported)
			{
				base.enabled = false;
			}
			if (!this.downsampleMaterial.shader.isSupported)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x00033FD4 File Offset: 0x000323D4
	public void FourTapCone(RenderTexture source, RenderTexture dest, int iteration)
	{
		float num = 0.5f + (float)iteration * this.blurSpread;
		Graphics.BlitMultiTap(source, dest, this.blurMaterial, new Vector2[]
		{
			new Vector2(num, num),
			new Vector2(-num, num),
			new Vector2(num, -num),
			new Vector2(-num, -num)
		});
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x00034054 File Offset: 0x00032454
	private void DownSample4x(RenderTexture source, RenderTexture dest)
	{
		this.downsampleMaterial.color = new Color(this.glowTint.r, this.glowTint.g, this.glowTint.b, this.glowTint.a / 4f);
		Graphics.Blit(source, dest, this.downsampleMaterial);
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x000340B0 File Offset: 0x000324B0
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.glowIntensity = Mathf.Clamp(this.glowIntensity, 0f, 10f);
		this.blurIterations = Mathf.Clamp(this.blurIterations, 0, 30);
		this.blurSpread = Mathf.Clamp(this.blurSpread, 0.5f, 1f);
		int width = source.width / 4;
		int height = source.height / 4;
		RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 0);
		this.DownSample4x(source, renderTexture);
		float num = Mathf.Clamp01((this.glowIntensity - 1f) / 4f);
		this.blurMaterial.color = new Color(1f, 1f, 1f, 0.25f + num);
		for (int i = 0; i < this.blurIterations; i++)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			this.FourTapCone(renderTexture, temporary, i);
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = temporary;
		}
		Graphics.Blit(source, destination);
		this.BlitGlow(renderTexture, destination);
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x000341B6 File Offset: 0x000325B6
	public void BlitGlow(RenderTexture source, RenderTexture dest)
	{
		this.compositeMaterial.color = new Color(1f, 1f, 1f, Mathf.Clamp01(this.glowIntensity));
		Graphics.Blit(source, dest, this.compositeMaterial);
	}

	// Token: 0x040006D4 RID: 1748
	public float glowIntensity = 1.5f;

	// Token: 0x040006D5 RID: 1749
	public int blurIterations = 3;

	// Token: 0x040006D6 RID: 1750
	public float blurSpread = 0.7f;

	// Token: 0x040006D7 RID: 1751
	public Color glowTint = new Color(1f, 1f, 1f, 0f);

	// Token: 0x040006D8 RID: 1752
	public Shader compositeShader;

	// Token: 0x040006D9 RID: 1753
	private Material m_CompositeMaterial;

	// Token: 0x040006DA RID: 1754
	public Shader blurShader;

	// Token: 0x040006DB RID: 1755
	private Material m_BlurMaterial;

	// Token: 0x040006DC RID: 1756
	public Shader downsampleShader;

	// Token: 0x040006DD RID: 1757
	private Material m_DownsampleMaterial;
}
