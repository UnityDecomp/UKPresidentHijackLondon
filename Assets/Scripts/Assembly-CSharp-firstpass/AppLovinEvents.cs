using System;

// Token: 0x0200000E RID: 14
public class AppLovinEvents
{
	// Token: 0x0200000F RID: 15
	public class Types
	{
		// Token: 0x04000039 RID: 57
		public const string UserLoggedIn = "login";

		// Token: 0x0400003A RID: 58
		public const string UserCreatedAccount = "registration";

		// Token: 0x0400003B RID: 59
		public const string UserCompletedTutorial = "tutorial";

		// Token: 0x0400003C RID: 60
		public const string UserCompletedLevel = "level";

		// Token: 0x0400003D RID: 61
		public const string UserCompletedAchievement = "achievement";

		// Token: 0x0400003E RID: 62
		public const string UserSpentVirtualCurrency = "vcpurchase";

		// Token: 0x0400003F RID: 63
		public const string UserCompletedInAppPurchase = "iap";

		// Token: 0x04000040 RID: 64
		public const string UserSentInvitation = "invite";

		// Token: 0x04000041 RID: 65
		public const string UserSharedLink = "share";
	}

	// Token: 0x02000010 RID: 16
	public class Parameters
	{
		// Token: 0x04000042 RID: 66
		public const string UserAccountIdentifier = "username";

		// Token: 0x04000043 RID: 67
		public const string SearchQuery = "query";

		// Token: 0x04000044 RID: 68
		public const string CompletedLevelIdentifier = "level_id";

		// Token: 0x04000045 RID: 69
		public const string CompletedAchievementIdentifier = "achievement_id";

		// Token: 0x04000046 RID: 70
		public const string VirtualCurrencyAmount = "vcamount";

		// Token: 0x04000047 RID: 71
		public const string VirtualCurrencyName = "vcname";

		// Token: 0x04000048 RID: 72
		public const string InAppPurchaseTransactionIdentifier = "store_id";

		// Token: 0x04000049 RID: 73
		public const string InAppPurchaseProductIdentifier = "product_id";

		// Token: 0x0400004A RID: 74
		public const string GooglePlayInAppPurchaseData = "receipt_data";

		// Token: 0x0400004B RID: 75
		public const string GooglePlayInAppPurchaseDataSignature = "receipt_data_signature";

		// Token: 0x0400004C RID: 76
		public const string RevenueAmount = "amount";

		// Token: 0x0400004D RID: 77
		public const string RevenueCurrency = "currency";
	}
}
