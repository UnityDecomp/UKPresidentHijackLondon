using System;

// Token: 0x020000CE RID: 206
[Serializable]
public enum EdgeDetectMode
{
	// Token: 0x04000527 RID: 1319
	TriangleDepthNormals,
	// Token: 0x04000528 RID: 1320
	RobertsCrossDepthNormals,
	// Token: 0x04000529 RID: 1321
	SobelDepth,
	// Token: 0x0400052A RID: 1322
	SobelDepthThin,
	// Token: 0x0400052B RID: 1323
	TriangleLuminance
}
