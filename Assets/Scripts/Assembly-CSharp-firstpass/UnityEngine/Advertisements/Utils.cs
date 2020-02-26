using System;

namespace UnityEngine.Advertisements
{
	// Token: 0x0200002C RID: 44
	internal static class Utils
	{
		// Token: 0x06000146 RID: 326 RVA: 0x00004BFA File Offset: 0x00002DFA
		private static void Log(Advertisement.DebugLevel debugLevel, string message)
		{
			if ((Advertisement.debugLevel & debugLevel) != Advertisement.DebugLevel.None)
			{
				Debug.Log(message);
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004C0E File Offset: 0x00002E0E
		public static void LogDebug(string message)
		{
			Utils.Log(Advertisement.DebugLevel.Debug, "Debug: " + message);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004C21 File Offset: 0x00002E21
		public static void LogInfo(string message)
		{
			Utils.Log(Advertisement.DebugLevel.Info, "Info:" + message);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004C34 File Offset: 0x00002E34
		public static void LogWarning(string message)
		{
			Utils.Log(Advertisement.DebugLevel.Warning, "Warning:" + message);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00004C47 File Offset: 0x00002E47
		public static void LogError(string message)
		{
			Utils.Log(Advertisement.DebugLevel.Error, "Error: " + message);
		}
	}
}
