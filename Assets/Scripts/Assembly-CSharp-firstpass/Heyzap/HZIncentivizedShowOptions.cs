using System;

namespace Heyzap
{
	// Token: 0x02000020 RID: 32
	public class HZIncentivizedShowOptions : HZShowOptions
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00003D11 File Offset: 0x00001F11
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00003D19 File Offset: 0x00001F19
		public string IncentivizedInfo
		{
			get
			{
				return this.incentivizedInfo;
			}
			set
			{
				if (value != null)
				{
					this.incentivizedInfo = value;
				}
				else
				{
					this.incentivizedInfo = string.Empty;
				}
			}
		}

		// Token: 0x0400008A RID: 138
		private const string DEFAULT_INCENTIVIZED_INFO = "";

		// Token: 0x0400008B RID: 139
		private string incentivizedInfo = string.Empty;
	}
}
