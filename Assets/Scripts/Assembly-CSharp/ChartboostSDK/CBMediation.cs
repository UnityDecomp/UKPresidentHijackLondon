using System;

namespace ChartboostSDK
{
	// Token: 0x02000010 RID: 16
	public sealed class CBMediation
	{
		// Token: 0x06000099 RID: 153 RVA: 0x0000515A File Offset: 0x0000355A
		private CBMediation(string name)
		{
			this.name = name;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00005169 File Offset: 0x00003569
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x0400008D RID: 141
		public static readonly CBMediation AdMarvel = new CBMediation("AdMarvel");

		// Token: 0x0400008E RID: 142
		public static readonly CBMediation Fuse = new CBMediation("Fuse");

		// Token: 0x0400008F RID: 143
		public static readonly CBMediation Fyber = new CBMediation("Fyber");

		// Token: 0x04000090 RID: 144
		public static readonly CBMediation HeyZap = new CBMediation("HeyZap");

		// Token: 0x04000091 RID: 145
		public static readonly CBMediation MoPub = new CBMediation("MoPub");

		// Token: 0x04000092 RID: 146
		public static readonly CBMediation Supersonic = new CBMediation("Supersonic");

		// Token: 0x04000093 RID: 147
		public static readonly CBMediation AdMob = new CBMediation("AdMob");

		// Token: 0x04000094 RID: 148
		public static readonly CBMediation HyprMX = new CBMediation("HyprMX");

		// Token: 0x04000095 RID: 149
		public static readonly CBMediation Other = new CBMediation("Other");

		// Token: 0x04000096 RID: 150
		private readonly string name;
	}
}
