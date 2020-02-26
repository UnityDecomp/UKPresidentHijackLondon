using System;

namespace Heyzap
{
	// Token: 0x0200001F RID: 31
	public class HZShowOptions
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00003CD7 File Offset: 0x00001ED7
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00003CDF File Offset: 0x00001EDF
		public string Tag
		{
			get
			{
				return this.tag;
			}
			set
			{
				if (value != null)
				{
					this.tag = value;
				}
				else
				{
					this.tag = "default";
				}
			}
		}

		// Token: 0x04000089 RID: 137
		private string tag = "default";
	}
}
