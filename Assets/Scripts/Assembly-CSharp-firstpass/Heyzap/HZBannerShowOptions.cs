using System;

namespace Heyzap
{
	// Token: 0x02000021 RID: 33
	public class HZBannerShowOptions : HZShowOptions
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00003D4B File Offset: 0x00001F4B
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00003D53 File Offset: 0x00001F53
		public string Position
		{
			get
			{
				return this.position;
			}
			set
			{
				if (value == "top" || value == "bottom")
				{
					this.position = value;
				}
			}
		}

		// Token: 0x0400008C RID: 140
		public const string POSITION_TOP = "top";

		// Token: 0x0400008D RID: 141
		public const string POSITION_BOTTOM = "bottom";

		// Token: 0x0400008E RID: 142
		private const string DEFAULT_POSITION = "bottom";

		// Token: 0x0400008F RID: 143
		private string position = "bottom";
	}
}
