using System;
using UnityEngine;

namespace ChartboostSDK
{
	// Token: 0x0200000A RID: 10
	public class CBSettings : ScriptableObject
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000049AC File Offset: 0x00002DAC
		private static CBSettings Instance
		{
			get
			{
				if (CBSettings.instance == null)
				{
					CBSettings.instance = (Resources.Load("ChartboostSettings") as CBSettings);
					if (CBSettings.instance == null)
					{
						CBSettings.instance = ScriptableObject.CreateInstance<CBSettings>();
					}
				}
				return CBSettings.instance;
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000049FC File Offset: 0x00002DFC
		public static void setAppId(string appId, string appSignature)
		{
			if (CBSettings.Instance.selectedAndroidPlatformIndex == 0)
			{
				Debug.Log("Overriding Google AppId: " + appId);
				CBSettings.Instance.SetAndroidAppId(appId);
				CBSettings.Instance.SetAndroidAppSecret(appSignature);
			}
			else
			{
				Debug.Log("Overriding Amazon AppId: " + appId);
				CBSettings.Instance.SetAmazonAppId(appId);
				CBSettings.Instance.SetAmazonAppSecret(appSignature);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00004A69 File Offset: 0x00002E69
		public void SetAndroidPlatformIndex(int index)
		{
			if (this.selectedAndroidPlatformIndex != index)
			{
				this.selectedAndroidPlatformIndex = index;
				CBSettings.DirtyEditor();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00004A83 File Offset: 0x00002E83
		public int SelectedAndroidPlatformIndex
		{
			get
			{
				return this.selectedAndroidPlatformIndex;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00004A8B File Offset: 0x00002E8B
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00004A93 File Offset: 0x00002E93
		public string[] AndroidPlatformLabels
		{
			get
			{
				return this.androidPlatformLabels;
			}
			set
			{
				if (!this.androidPlatformLabels.Equals(value))
				{
					this.androidPlatformLabels = value;
					CBSettings.DirtyEditor();
				}
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00004AB2 File Offset: 0x00002EB2
		public void SetIOSAppId(string id)
		{
			if (!CBSettings.Instance.iOSAppId.Equals(id))
			{
				CBSettings.Instance.iOSAppId = id;
				CBSettings.DirtyEditor();
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004ADC File Offset: 0x00002EDC
		public static string getIOSAppId()
		{
			if (CBSettings.Instance.iOSAppId.Equals("CB_IOS_APP_ID"))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using the Chartboost {0} example {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "IOS", "App ID");
				return "4f21c409cd1cb2fb7000001b";
			}
			if (CBSettings.Instance.iOSAppId.Equals(string.Empty))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using an empty string for the {0} {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "IOS", "App ID");
			}
			return CBSettings.Instance.iOSAppId;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004B53 File Offset: 0x00002F53
		public void SetIOSAppSecret(string secret)
		{
			if (!CBSettings.Instance.iOSAppSecret.Equals(secret))
			{
				CBSettings.Instance.iOSAppSecret = secret;
				CBSettings.DirtyEditor();
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004B7C File Offset: 0x00002F7C
		public static string getIOSAppSecret()
		{
			if (CBSettings.Instance.iOSAppSecret.Equals("CB_IOS_APP_SIGNATURE"))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using the Chartboost {0} example {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "IOS", "App Signature");
				return "92e2de2fd7070327bdeb54c15a5295309c6fcd2d";
			}
			if (CBSettings.Instance.iOSAppSecret.Equals(string.Empty))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using an empty string for the {0} {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "IOS", "App Signature");
			}
			return CBSettings.Instance.iOSAppSecret;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004BF3 File Offset: 0x00002FF3
		public void SetAndroidAppId(string id)
		{
			if (!CBSettings.Instance.androidAppId.Equals(id))
			{
				CBSettings.Instance.androidAppId = id;
				CBSettings.DirtyEditor();
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004C1C File Offset: 0x0000301C
		public static string getAndroidAppId()
		{
			if (CBSettings.Instance.androidAppId.Equals("CB_ANDROID_APP_ID"))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using the Chartboost {0} example {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Android", "App ID");
				return "4f7b433509b6025804000002";
			}
			if (CBSettings.Instance.androidAppId.Equals(string.Empty))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using an empty string for the {0} {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Android", "App ID");
			}
			return CBSettings.Instance.androidAppId;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004C93 File Offset: 0x00003093
		public void SetAndroidAppSecret(string secret)
		{
			if (!CBSettings.Instance.androidAppSecret.Equals(secret))
			{
				CBSettings.Instance.androidAppSecret = secret;
				CBSettings.DirtyEditor();
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004CBC File Offset: 0x000030BC
		public static string getAndroidAppSecret()
		{
			if (CBSettings.Instance.androidAppSecret.Equals("CB_ANDROID_APP_SIGNATURE"))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using the Chartboost {0} example {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Android", "App Signature");
				return "dd2d41b69ac01b80f443f5b6cf06096d457f82bd";
			}
			if (CBSettings.Instance.androidAppSecret.Equals(string.Empty))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using an empty string for the {0} {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Android", "App Signature");
			}
			return CBSettings.Instance.androidAppSecret;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004D33 File Offset: 0x00003133
		public void SetAmazonAppId(string id)
		{
			if (!CBSettings.Instance.amazonAppId.Equals(id))
			{
				CBSettings.Instance.amazonAppId = id;
				CBSettings.DirtyEditor();
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004D5C File Offset: 0x0000315C
		public static string getAmazonAppId()
		{
			if (CBSettings.Instance.amazonAppId.Equals("CB_AMAZON_APP_ID"))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using the Chartboost {0} example {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Amazon", "App ID");
				return "542ca35d1873da32dbc90488";
			}
			if (CBSettings.Instance.amazonAppId.Equals(string.Empty))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using an empty string for the {0} {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Amazon", "App ID");
			}
			return CBSettings.Instance.amazonAppId;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004DD3 File Offset: 0x000031D3
		public void SetAmazonAppSecret(string secret)
		{
			if (!CBSettings.Instance.amazonAppSecret.Equals(secret))
			{
				CBSettings.Instance.amazonAppSecret = secret;
				CBSettings.DirtyEditor();
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004DFC File Offset: 0x000031FC
		public static string getAmazonAppSecret()
		{
			if (CBSettings.Instance.amazonAppSecret.Equals("CB_AMAZON_APP_SIGNATURE"))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using the Chartboost {0} example {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Amazon", "App Signature");
				return "90654a340386c9fb8de33315e4210d7c09989c43";
			}
			if (CBSettings.Instance.amazonAppSecret.Equals(string.Empty))
			{
				CBSettings.CredentialsWarning("CHARTBOOST: You are using an empty string for the {0} {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com", "Amazon", "App Signature");
			}
			return CBSettings.Instance.amazonAppSecret;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004E73 File Offset: 0x00003273
		public static string getSelectAndroidAppId()
		{
			if (CBSettings.Instance.selectedAndroidPlatformIndex == 0)
			{
				return CBSettings.getAndroidAppId();
			}
			return CBSettings.getAmazonAppId();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004E8F File Offset: 0x0000328F
		public static string getSelectAndroidAppSecret()
		{
			if (CBSettings.Instance.selectedAndroidPlatformIndex == 0)
			{
				return CBSettings.getAndroidAppSecret();
			}
			return CBSettings.getAmazonAppSecret();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004EAB File Offset: 0x000032AB
		public static void enableLogging(bool enabled)
		{
			CBSettings.Instance.isLoggingEnabled = enabled;
			CBSettings.DirtyEditor();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004EBD File Offset: 0x000032BD
		public static bool isLogging()
		{
			return CBSettings.Instance.isLoggingEnabled;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004EC9 File Offset: 0x000032C9
		private static void DirtyEditor()
		{
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004ECB File Offset: 0x000032CB
		private static void CredentialsWarning(string warning, string platform, string field)
		{
			if (!CBSettings.credentialsWarning)
			{
				CBSettings.credentialsWarning = true;
				Debug.LogWarning(string.Format(warning, platform, field));
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004EEC File Offset: 0x000032EC
		public static void resetSettings()
		{
			if (CBSettings.Instance.iOSAppId.Equals("4f21c409cd1cb2fb7000001b"))
			{
				CBSettings.Instance.SetIOSAppId("CB_IOS_APP_ID");
			}
			if (CBSettings.Instance.iOSAppSecret.Equals("92e2de2fd7070327bdeb54c15a5295309c6fcd2d"))
			{
				CBSettings.Instance.SetIOSAppSecret("CB_IOS_APP_SIGNATURE");
			}
			if (CBSettings.Instance.androidAppId.Equals("4f7b433509b6025804000002"))
			{
				CBSettings.Instance.SetAndroidAppId("CB_ANDROID_APP_ID");
			}
			if (CBSettings.Instance.androidAppSecret.Equals("dd2d41b69ac01b80f443f5b6cf06096d457f82bd"))
			{
				CBSettings.Instance.SetAndroidAppSecret("CB_ANDROID_APP_SIGNATURE");
			}
			if (CBSettings.Instance.amazonAppId.Equals("542ca35d1873da32dbc90488"))
			{
				CBSettings.Instance.SetAmazonAppId("CB_AMAZON_APP_ID");
			}
			if (CBSettings.Instance.amazonAppSecret.Equals("90654a340386c9fb8de33315e4210d7c09989c43"))
			{
				CBSettings.Instance.SetAmazonAppSecret("CB_AMAZON_APP_SIGNATURE");
			}
		}

		// Token: 0x04000035 RID: 53
		private const string cbSettingsAssetName = "ChartboostSettings";

		// Token: 0x04000036 RID: 54
		private const string cbSettingsPath = "Chartboost/Resources";

		// Token: 0x04000037 RID: 55
		private const string cbSettingsAssetExtension = ".asset";

		// Token: 0x04000038 RID: 56
		private const string iOSExampleAppIDLabel = "CB_IOS_APP_ID";

		// Token: 0x04000039 RID: 57
		private const string iOSExampleAppSignatureLabel = "CB_IOS_APP_SIGNATURE";

		// Token: 0x0400003A RID: 58
		private const string iOSExampleAppID = "4f21c409cd1cb2fb7000001b";

		// Token: 0x0400003B RID: 59
		private const string iOSExampleAppSignature = "92e2de2fd7070327bdeb54c15a5295309c6fcd2d";

		// Token: 0x0400003C RID: 60
		private const string androidExampleAppIDLabel = "CB_ANDROID_APP_ID";

		// Token: 0x0400003D RID: 61
		private const string androidExampleAppSignatureLabel = "CB_ANDROID_APP_SIGNATURE";

		// Token: 0x0400003E RID: 62
		private const string androidExampleAppID = "4f7b433509b6025804000002";

		// Token: 0x0400003F RID: 63
		private const string androidExampleAppSignature = "dd2d41b69ac01b80f443f5b6cf06096d457f82bd";

		// Token: 0x04000040 RID: 64
		private const string amazonExampleAppIDLabel = "CB_AMAZON_APP_ID";

		// Token: 0x04000041 RID: 65
		private const string amazonExampleAppSignatureLabel = "CB_AMAZON_APP_SIGNATURE";

		// Token: 0x04000042 RID: 66
		private const string amazonExampleAppID = "542ca35d1873da32dbc90488";

		// Token: 0x04000043 RID: 67
		private const string amazonExampleAppSignature = "90654a340386c9fb8de33315e4210d7c09989c43";

		// Token: 0x04000044 RID: 68
		private const string credentialsWarningDefaultFormat = "CHARTBOOST: You are using the Chartboost {0} example {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com";

		// Token: 0x04000045 RID: 69
		private const string credentialsWarningEmptyFormat = "CHARTBOOST: You are using an empty string for the {0} {1}! Go to the Chartboost dashboard and replace these with an App ID & App Signature from your account! If you need help, email us: support@chartboost.com";

		// Token: 0x04000046 RID: 70
		private const string credentialsWarningIOS = "IOS";

		// Token: 0x04000047 RID: 71
		private const string credentialsWarningAndroid = "Android";

		// Token: 0x04000048 RID: 72
		private const string credentialsWarningAmazon = "Amazon";

		// Token: 0x04000049 RID: 73
		private const string credentialsWarningAppID = "App ID";

		// Token: 0x0400004A RID: 74
		private const string credentialsWarningAppSignature = "App Signature";

		// Token: 0x0400004B RID: 75
		private static bool credentialsWarning;

		// Token: 0x0400004C RID: 76
		private static CBSettings instance;

		// Token: 0x0400004D RID: 77
		[SerializeField]
		public string iOSAppId = "CB_IOS_APP_ID";

		// Token: 0x0400004E RID: 78
		[SerializeField]
		public string iOSAppSecret = "CB_IOS_APP_SIGNATURE";

		// Token: 0x0400004F RID: 79
		[SerializeField]
		public string androidAppId = "CB_ANDROID_APP_ID";

		// Token: 0x04000050 RID: 80
		[SerializeField]
		public string androidAppSecret = "CB_ANDROID_APP_SIGNATURE";

		// Token: 0x04000051 RID: 81
		[SerializeField]
		public string amazonAppId = "CB_AMAZON_APP_ID";

		// Token: 0x04000052 RID: 82
		[SerializeField]
		public string amazonAppSecret = "CB_AMAZON_APP_SIGNATURE";

		// Token: 0x04000053 RID: 83
		[SerializeField]
		public bool isLoggingEnabled;

		// Token: 0x04000054 RID: 84
		[SerializeField]
		public string[] androidPlatformLabels = new string[]
		{
			"Google Play",
			"Amazon"
		};

		// Token: 0x04000055 RID: 85
		[SerializeField]
		public int selectedAndroidPlatformIndex;
	}
}
