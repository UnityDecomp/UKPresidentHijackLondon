using System;

// Token: 0x02000140 RID: 320
public class BikeStatics
{
	// Token: 0x06000A08 RID: 2568 RVA: 0x0003DA7A File Offset: 0x0003BE7A
	public BikeStatics(float topSpeed, float acceleration, float lean, float grip)
	{
		this.topSpeed = topSpeed;
		this.acceleration = acceleration;
		this.lean = lean;
		this.grip = grip;
	}

	// Token: 0x0400093C RID: 2364
	public float topSpeed;

	// Token: 0x0400093D RID: 2365
	public float acceleration;

	// Token: 0x0400093E RID: 2366
	public float lean;

	// Token: 0x0400093F RID: 2367
	public float grip;
}
