using System;
using System.Collections;

namespace ChartboostSDK
{
	// Token: 0x0200000F RID: 15
	public sealed class CBLocation
	{
		// Token: 0x06000095 RID: 149 RVA: 0x00004FEB File Offset: 0x000033EB
		private CBLocation(string name)
		{
			this.name = name;
			CBLocation.map.Add(name, this);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00005006 File Offset: 0x00003406
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000500E File Offset: 0x0000340E
		public static CBLocation locationFromName(string name)
		{
			if (name == null)
			{
				return CBLocation.Default;
			}
			if (CBLocation.map[name] != null)
			{
				return CBLocation.map[name] as CBLocation;
			}
			return new CBLocation(name);
		}

		// Token: 0x0400007A RID: 122
		private readonly string name;

		// Token: 0x0400007B RID: 123
		private static Hashtable map = new Hashtable();

		// Token: 0x0400007C RID: 124
		public static readonly CBLocation Default = new CBLocation("Default");

		// Token: 0x0400007D RID: 125
		public static readonly CBLocation Startup = new CBLocation("Startup");

		// Token: 0x0400007E RID: 126
		public static readonly CBLocation HomeScreen = new CBLocation("Home Screen");

		// Token: 0x0400007F RID: 127
		public static readonly CBLocation MainMenu = new CBLocation("Main Menu");

		// Token: 0x04000080 RID: 128
		public static readonly CBLocation GameScreen = new CBLocation("Game Screen");

		// Token: 0x04000081 RID: 129
		public static readonly CBLocation Achievements = new CBLocation("Achievements");

		// Token: 0x04000082 RID: 130
		public static readonly CBLocation Quests = new CBLocation("Quests");

		// Token: 0x04000083 RID: 131
		public static readonly CBLocation Pause = new CBLocation("Pause");

		// Token: 0x04000084 RID: 132
		public static readonly CBLocation LevelStart = new CBLocation("Level Start");

		// Token: 0x04000085 RID: 133
		public static readonly CBLocation LevelComplete = new CBLocation("Level Complete");

		// Token: 0x04000086 RID: 134
		public static readonly CBLocation TurnComplete = new CBLocation("Turn Complete");

		// Token: 0x04000087 RID: 135
		public static readonly CBLocation IAPStore = new CBLocation("IAP Store");

		// Token: 0x04000088 RID: 136
		public static readonly CBLocation ItemStore = new CBLocation("Item Store");

		// Token: 0x04000089 RID: 137
		public static readonly CBLocation GameOver = new CBLocation("Game Over");

		// Token: 0x0400008A RID: 138
		public static readonly CBLocation LeaderBoard = new CBLocation("Leaderboard");

		// Token: 0x0400008B RID: 139
		public static readonly CBLocation Settings = new CBLocation("Settings");

		// Token: 0x0400008C RID: 140
		public static readonly CBLocation Quit = new CBLocation("Quit");
	}
}
