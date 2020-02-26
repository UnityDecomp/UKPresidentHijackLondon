using System;

// Token: 0x02000126 RID: 294
public struct AnimTimer
{
	// Token: 0x17000040 RID: 64
	// (get) Token: 0x060007CC RID: 1996 RVA: 0x000341FB File Offset: 0x000325FB
	public bool Enabled
	{
		get
		{
			return this.enabled;
		}
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x060007CD RID: 1997 RVA: 0x00034203 File Offset: 0x00032603
	public bool Running
	{
		get
		{
			return this.running;
		}
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x060007CE RID: 1998 RVA: 0x0003420B File Offset: 0x0003260B
	public bool Completed
	{
		get
		{
			return !this.running;
		}
	}

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x060007CF RID: 1999 RVA: 0x00034216 File Offset: 0x00032616
	public float Elapsed
	{
		get
		{
			return this.elapsed;
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x060007D0 RID: 2000 RVA: 0x0003421E File Offset: 0x0003261E
	public float Duration
	{
		get
		{
			return this.duration;
		}
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x060007D1 RID: 2001 RVA: 0x00034226 File Offset: 0x00032626
	public float Nt
	{
		get
		{
			return this.nt;
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0003422E File Offset: 0x0003262E
	public float NtPrev
	{
		get
		{
			return this.ntPrev;
		}
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x00034236 File Offset: 0x00032636
	public void Reset(float t = 0f)
	{
		this.enabled = false;
		this.running = false;
		this.elapsed = 0f;
		this.nt = t;
		this.ntPrev = t;
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x00034260 File Offset: 0x00032660
	public void Start(float duration)
	{
		this.enabled = true;
		this.running = true;
		this.nt = 0f;
		this.ntPrev = 0f;
		this.elapsed = 0f;
		this.duration = ((duration <= 0f) ? 0f : duration);
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x000342B8 File Offset: 0x000326B8
	public void Update(float dt)
	{
		if (!this.enabled)
		{
			return;
		}
		this.ntPrev = this.nt;
		if (this.running)
		{
			this.elapsed += dt;
			if (this.elapsed > this.duration)
			{
				this.nt = 1f;
				this.running = false;
			}
			else if (this.duration > 0.0001f)
			{
				this.nt = this.elapsed / this.duration;
			}
			else
			{
				this.nt = 0f;
			}
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x00034351 File Offset: 0x00032751
	public void Disable()
	{
		this.enabled = false;
		this.running = false;
	}

	// Token: 0x040006DE RID: 1758
	private bool enabled;

	// Token: 0x040006DF RID: 1759
	private bool running;

	// Token: 0x040006E0 RID: 1760
	private float elapsed;

	// Token: 0x040006E1 RID: 1761
	private float duration;

	// Token: 0x040006E2 RID: 1762
	private float nt;

	// Token: 0x040006E3 RID: 1763
	private float ntPrev;
}
