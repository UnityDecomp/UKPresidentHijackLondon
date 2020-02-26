using System;

// Token: 0x0200013E RID: 318
public class GameSettings
{
	// Token: 0x060009FB RID: 2555 RVA: 0x0003D75C File Offset: 0x0003BB5C
	public static BikeStatics getCurrentBikeStatistics(int currentBike)
	{
		return GameSettings.bikeStatisticsArray[currentBike];
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x0003D765 File Offset: 0x0003BB65
	public static int getLevelForUnlockBike(int currentBike)
	{
		return GameSettings.listUnlockingBike[currentBike];
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x0003D76E File Offset: 0x0003BB6E
	public static int[] getListUnlockingBike()
	{
		return GameSettings.listUnlockingBike;
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x0003D775 File Offset: 0x0003BB75
	public static float getTime_3(int currentLevel)
	{
		return GameSettings.listTime_3[currentLevel];
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x0003D77E File Offset: 0x0003BB7E
	public static float getTime_2(int currentLevel)
	{
		return GameSettings.listTime_2[currentLevel];
	}

	// Token: 0x06000A00 RID: 2560 RVA: 0x0003D787 File Offset: 0x0003BB87
	public static float getTime_1(int currentLevel)
	{
		return GameSettings.listTime_1[currentLevel];
	}

	// Token: 0x06000A01 RID: 2561 RVA: 0x0003D790 File Offset: 0x0003BB90
	public static float[] GetParameters()
	{
		return GameSettings.parameters[(int)GameSettings.currentComplexity];
	}

	// Token: 0x06000A02 RID: 2562 RVA: 0x0003D79D File Offset: 0x0003BB9D
	public static float GetKMParameter()
	{
		return GameSettings.KMparametersChange[(int)GameSettings.currentComplexity];
	}

	// Token: 0x06000A03 RID: 2563 RVA: 0x0003D7AA File Offset: 0x0003BBAA
	public static float GetNtime()
	{
		return GameSettings.Ntimes[(int)GameSettings.currentComplexity];
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x0003D7B7 File Offset: 0x0003BBB7
	public static int GetPoints()
	{
		return GameSettings.correctlyPoints[(int)GameSettings.currentComplexity];
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x0003D7C4 File Offset: 0x0003BBC4
	public static float GetFactor()
	{
		return GameSettings.factorPoints[(int)GameSettings.currentComplexity];
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x0003D7D1 File Offset: 0x0003BBD1
	public static float GetStep()
	{
		return GameSettings.stepForFactors[(int)GameSettings.currentComplexity];
	}

	// Token: 0x04000926 RID: 2342
	public static GameSettings.Complexity currentComplexity = GameSettings.Complexity.Hard;

	// Token: 0x04000927 RID: 2343
	public static int countLevels = 15;

	// Token: 0x04000928 RID: 2344
	public static int startLives = 3;

	// Token: 0x04000929 RID: 2345
	private static float[] lowParameters = new float[]
	{
		4f,
		4f,
		1f
	};

	// Token: 0x0400092A RID: 2346
	private static float[] middleParameters = new float[]
	{
		3f,
		3f,
		1f
	};

	// Token: 0x0400092B RID: 2347
	private static float[] hardParameters = new float[]
	{
		2f,
		2f,
		2f
	};

	// Token: 0x0400092C RID: 2348
	private static float[][] parameters = new float[][]
	{
		GameSettings.lowParameters,
		GameSettings.middleParameters,
		GameSettings.hardParameters
	};

	// Token: 0x0400092D RID: 2349
	private static float[] KMparametersChange = new float[]
	{
		1.25f,
		1.5f,
		1.75f
	};

	// Token: 0x0400092E RID: 2350
	private static float[] Ntimes = new float[]
	{
		120f,
		90f,
		60f
	};

	// Token: 0x0400092F RID: 2351
	private static int[] correctlyPoints = new int[]
	{
		100,
		200,
		300
	};

	// Token: 0x04000930 RID: 2352
	private static float[] factorPoints = new float[]
	{
		1f,
		1.25f,
		1.5f
	};

	// Token: 0x04000931 RID: 2353
	private static float[] stepForFactors = new float[]
	{
		0.25f,
		0.5f,
		1.5f
	};

	// Token: 0x04000932 RID: 2354
	public static float deltaGoodTime = 10f;

	// Token: 0x04000933 RID: 2355
	private static float[] listTime_3 = new float[]
	{
		30f,
		36f,
		45f,
		53f,
		90f,
		58f,
		60f,
		70f,
		86f,
		102f,
		100f,
		90f,
		120f,
		120f,
		180f
	};

	// Token: 0x04000934 RID: 2356
	private static float[] listTime_2 = new float[]
	{
		45f,
		48f,
		60f,
		70f,
		105f,
		75f,
		75f,
		85f,
		100f,
		115f,
		115f,
		105f,
		135f,
		135f,
		195f
	};

	// Token: 0x04000935 RID: 2357
	private static float[] listTime_1 = new float[]
	{
		60f,
		60f,
		75f,
		80f,
		120f,
		90f,
		90f,
		100f,
		115f,
		130f,
		130f,
		120f,
		150f,
		150f,
		210f
	};

	// Token: 0x04000936 RID: 2358
	private static int[] listUnlockingBike = new int[]
	{
		1,
		1,
		1,
		1,
		1,
		1
	};

	// Token: 0x04000937 RID: 2359
	private static BikeStatics[] bikeStatisticsArray = new BikeStatics[]
	{
		new BikeStatics(0.45f, 0.5f, 0.5f, 0.45f),
		new BikeStatics(0.85f, 0.8f, 0.65f, 0.5f),
		new BikeStatics(0.75f, 0.75f, 0.8f, 0.6f),
		new BikeStatics(0.75f, 0.8f, 0.85f, 0.7f),
		new BikeStatics(0.85f, 0.88f, 0.88f, 0.8f),
		new BikeStatics(0.95f, 0.9f, 0.95f, 0.9f),
		new BikeStatics(0.95f, 0.9f, 0.95f, 0.9f),
		new BikeStatics(0.95f, 0.9f, 0.95f, 0.9f),
		new BikeStatics(0.95f, 0.9f, 0.95f, 0.9f),
		new BikeStatics(0.95f, 0.9f, 0.95f, 0.9f),
		new BikeStatics(0.95f, 0.9f, 0.95f, 0.9f)
	};

	// Token: 0x0200013F RID: 319
	public enum Complexity
	{
		// Token: 0x04000939 RID: 2361
		Low,
		// Token: 0x0400093A RID: 2362
		Middle,
		// Token: 0x0400093B RID: 2363
		Hard
	}
}
