using System;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000019 RID: 25
	public class AdSize
	{
		// Token: 0x06000160 RID: 352 RVA: 0x00006B7A File Offset: 0x00004F7A
		public AdSize(int width, int height)
		{
			this.isSmartBanner = false;
			this.width = width;
			this.height = height;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00006B97 File Offset: 0x00004F97
		private AdSize(bool isSmartBanner) : this(0, 0)
		{
			this.isSmartBanner = isSmartBanner;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00006BA8 File Offset: 0x00004FA8
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00006BB0 File Offset: 0x00004FB0
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00006BB8 File Offset: 0x00004FB8
		public bool IsSmartBanner
		{
			get
			{
				return this.isSmartBanner;
			}
		}

		// Token: 0x040000DE RID: 222
		private bool isSmartBanner;

		// Token: 0x040000DF RID: 223
		private int width;

		// Token: 0x040000E0 RID: 224
		private int height;

		// Token: 0x040000E1 RID: 225
		public static readonly AdSize Banner = new AdSize(320, 50);

		// Token: 0x040000E2 RID: 226
		public static readonly AdSize MediumRectangle = new AdSize(300, 250);

		// Token: 0x040000E3 RID: 227
		public static readonly AdSize IABBanner = new AdSize(468, 60);

		// Token: 0x040000E4 RID: 228
		public static readonly AdSize Leaderboard = new AdSize(728, 90);

		// Token: 0x040000E5 RID: 229
		public static readonly AdSize SmartBanner = new AdSize(true);

		// Token: 0x040000E6 RID: 230
		public static readonly int FullWidth = -1;
	}
}
