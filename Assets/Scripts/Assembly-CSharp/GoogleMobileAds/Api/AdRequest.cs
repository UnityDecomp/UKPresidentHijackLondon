using System;
using System.Collections.Generic;
using GoogleMobileAds.Api.Mediation;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000017 RID: 23
	public class AdRequest
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00006934 File Offset: 0x00004D34
		private AdRequest(AdRequest.Builder builder)
		{
			this.TestDevices = new List<string>(builder.TestDevices);
			this.Keywords = new HashSet<string>(builder.Keywords);
			this.Birthday = builder.Birthday;
			this.Gender = builder.Gender;
			this.TagForChildDirectedTreatment = builder.ChildDirectedTreatmentTag;
			this.Extras = new Dictionary<string, string>(builder.Extras);
			this.MediationExtras = builder.MediationExtras;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600013B RID: 315 RVA: 0x000069AA File Offset: 0x00004DAA
		// (set) Token: 0x0600013C RID: 316 RVA: 0x000069B2 File Offset: 0x00004DB2
		public List<string> TestDevices { get; private set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600013D RID: 317 RVA: 0x000069BB File Offset: 0x00004DBB
		// (set) Token: 0x0600013E RID: 318 RVA: 0x000069C3 File Offset: 0x00004DC3
		public HashSet<string> Keywords { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600013F RID: 319 RVA: 0x000069CC File Offset: 0x00004DCC
		// (set) Token: 0x06000140 RID: 320 RVA: 0x000069D4 File Offset: 0x00004DD4
		public DateTime? Birthday { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000069DD File Offset: 0x00004DDD
		// (set) Token: 0x06000142 RID: 322 RVA: 0x000069E5 File Offset: 0x00004DE5
		public Gender? Gender { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000143 RID: 323 RVA: 0x000069EE File Offset: 0x00004DEE
		// (set) Token: 0x06000144 RID: 324 RVA: 0x000069F6 File Offset: 0x00004DF6
		public bool? TagForChildDirectedTreatment { get; private set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000145 RID: 325 RVA: 0x000069FF File Offset: 0x00004DFF
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00006A07 File Offset: 0x00004E07
		public Dictionary<string, string> Extras { get; private set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00006A10 File Offset: 0x00004E10
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00006A18 File Offset: 0x00004E18
		public List<MediationExtras> MediationExtras { get; private set; }

		// Token: 0x040000CE RID: 206
		public const string Version = "3.6.0";

		// Token: 0x040000CF RID: 207
		public const string TestDeviceSimulator = "SIMULATOR";

		// Token: 0x02000018 RID: 24
		public class Builder
		{
			// Token: 0x06000149 RID: 329 RVA: 0x00006A24 File Offset: 0x00004E24
			public Builder()
			{
				this.TestDevices = new List<string>();
				this.Keywords = new HashSet<string>();
				this.Birthday = null;
				this.Gender = null;
				this.ChildDirectedTreatmentTag = null;
				this.Extras = new Dictionary<string, string>();
				this.MediationExtras = new List<MediationExtras>();
			}

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600014A RID: 330 RVA: 0x00006A90 File Offset: 0x00004E90
			// (set) Token: 0x0600014B RID: 331 RVA: 0x00006A98 File Offset: 0x00004E98
			internal List<string> TestDevices { get; private set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600014C RID: 332 RVA: 0x00006AA1 File Offset: 0x00004EA1
			// (set) Token: 0x0600014D RID: 333 RVA: 0x00006AA9 File Offset: 0x00004EA9
			internal HashSet<string> Keywords { get; private set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600014E RID: 334 RVA: 0x00006AB2 File Offset: 0x00004EB2
			// (set) Token: 0x0600014F RID: 335 RVA: 0x00006ABA File Offset: 0x00004EBA
			internal DateTime? Birthday { get; private set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000150 RID: 336 RVA: 0x00006AC3 File Offset: 0x00004EC3
			// (set) Token: 0x06000151 RID: 337 RVA: 0x00006ACB File Offset: 0x00004ECB
			internal Gender? Gender { get; private set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000152 RID: 338 RVA: 0x00006AD4 File Offset: 0x00004ED4
			// (set) Token: 0x06000153 RID: 339 RVA: 0x00006ADC File Offset: 0x00004EDC
			internal bool? ChildDirectedTreatmentTag { get; private set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000154 RID: 340 RVA: 0x00006AE5 File Offset: 0x00004EE5
			// (set) Token: 0x06000155 RID: 341 RVA: 0x00006AED File Offset: 0x00004EED
			internal Dictionary<string, string> Extras { get; private set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000156 RID: 342 RVA: 0x00006AF6 File Offset: 0x00004EF6
			// (set) Token: 0x06000157 RID: 343 RVA: 0x00006AFE File Offset: 0x00004EFE
			internal List<MediationExtras> MediationExtras { get; private set; }

			// Token: 0x06000158 RID: 344 RVA: 0x00006B07 File Offset: 0x00004F07
			public AdRequest.Builder AddKeyword(string keyword)
			{
				this.Keywords.Add(keyword);
				return this;
			}

			// Token: 0x06000159 RID: 345 RVA: 0x00006B17 File Offset: 0x00004F17
			public AdRequest.Builder AddTestDevice(string deviceId)
			{
				this.TestDevices.Add(deviceId);
				return this;
			}

			// Token: 0x0600015A RID: 346 RVA: 0x00006B26 File Offset: 0x00004F26
			public AdRequest Build()
			{
				return new AdRequest(this);
			}

			// Token: 0x0600015B RID: 347 RVA: 0x00006B2E File Offset: 0x00004F2E
			public AdRequest.Builder SetBirthday(DateTime birthday)
			{
				this.Birthday = new DateTime?(birthday);
				return this;
			}

			// Token: 0x0600015C RID: 348 RVA: 0x00006B3D File Offset: 0x00004F3D
			public AdRequest.Builder SetGender(Gender gender)
			{
				this.Gender = new Gender?(gender);
				return this;
			}

			// Token: 0x0600015D RID: 349 RVA: 0x00006B4C File Offset: 0x00004F4C
			public AdRequest.Builder AddMediationExtras(MediationExtras extras)
			{
				this.MediationExtras.Add(extras);
				return this;
			}

			// Token: 0x0600015E RID: 350 RVA: 0x00006B5B File Offset: 0x00004F5B
			public AdRequest.Builder TagForChildDirectedTreatment(bool tagForChildDirectedTreatment)
			{
				this.ChildDirectedTreatmentTag = new bool?(tagForChildDirectedTreatment);
				return this;
			}

			// Token: 0x0600015F RID: 351 RVA: 0x00006B6A File Offset: 0x00004F6A
			public AdRequest.Builder AddExtra(string key, string value)
			{
				this.Extras.Add(key, value);
				return this;
			}
		}
	}
}
