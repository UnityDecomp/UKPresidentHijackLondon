using System;

namespace admob
{
	// Token: 0x02000009 RID: 9
	public class AdSize
	{
		// Token: 0x0600002D RID: 45 RVA: 0x000027A6 File Offset: 0x000009A6
		public AdSize(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000027BC File Offset: 0x000009BC
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000027C4 File Offset: 0x000009C4
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x0400001D RID: 29
		private int width;

		// Token: 0x0400001E RID: 30
		private int height;

		// Token: 0x0400001F RID: 31
		public static readonly AdSize Banner = new AdSize(320, 50);

		// Token: 0x04000020 RID: 32
		public static readonly AdSize MediumRectangle = new AdSize(300, 250);

		// Token: 0x04000021 RID: 33
		public static readonly AdSize IABBanner = new AdSize(468, 60);

		// Token: 0x04000022 RID: 34
		public static readonly AdSize Leaderboard = new AdSize(728, 90);

		// Token: 0x04000023 RID: 35
		public static readonly AdSize WideSkyscraper = new AdSize(120, 600);

		// Token: 0x04000024 RID: 36
		public static readonly AdSize SmartBanner = new AdSize(-1, -2);
	}
}
