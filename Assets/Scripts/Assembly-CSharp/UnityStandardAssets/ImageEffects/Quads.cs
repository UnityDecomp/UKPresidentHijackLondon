using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200019B RID: 411
	internal class Quads
	{
		// Token: 0x06000B92 RID: 2962 RVA: 0x00048144 File Offset: 0x00046544
		private static bool HasMeshes()
		{
			if (Quads.meshes == null)
			{
				return false;
			}
			foreach (Mesh y in Quads.meshes)
			{
				if (null == y)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0004818C File Offset: 0x0004658C
		public static void Cleanup()
		{
			if (Quads.meshes == null)
			{
				return;
			}
			for (int i = 0; i < Quads.meshes.Length; i++)
			{
				if (null != Quads.meshes[i])
				{
					UnityEngine.Object.DestroyImmediate(Quads.meshes[i]);
					Quads.meshes[i] = null;
				}
			}
			Quads.meshes = null;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x000481E8 File Offset: 0x000465E8
		public static Mesh[] GetMeshes(int totalWidth, int totalHeight)
		{
			if (Quads.HasMeshes() && Quads.currentQuads == totalWidth * totalHeight)
			{
				return Quads.meshes;
			}
			int num = 10833;
			int num2 = totalWidth * totalHeight;
			Quads.currentQuads = num2;
			int num3 = Mathf.CeilToInt(1f * (float)num2 / (1f * (float)num));
			Quads.meshes = new Mesh[num3];
			int num4 = 0;
			for (int i = 0; i < num2; i += num)
			{
				int triCount = Mathf.FloorToInt((float)Mathf.Clamp(num2 - i, 0, num));
				Quads.meshes[num4] = Quads.GetMesh(triCount, i, totalWidth, totalHeight);
				num4++;
			}
			return Quads.meshes;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0004828C File Offset: 0x0004668C
		private static Mesh GetMesh(int triCount, int triOffset, int totalWidth, int totalHeight)
		{
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.DontSave;
			Vector3[] array = new Vector3[triCount * 4];
			Vector2[] array2 = new Vector2[triCount * 4];
			Vector2[] array3 = new Vector2[triCount * 4];
			int[] array4 = new int[triCount * 6];
			for (int i = 0; i < triCount; i++)
			{
				int num = i * 4;
				int num2 = i * 6;
				int num3 = triOffset + i;
				float num4 = Mathf.Floor((float)(num3 % totalWidth)) / (float)totalWidth;
				float num5 = Mathf.Floor((float)(num3 / totalWidth)) / (float)totalHeight;
				Vector3 vector = new Vector3(num4 * 2f - 1f, num5 * 2f - 1f, 1f);
				array[num] = vector;
				array[num + 1] = vector;
				array[num + 2] = vector;
				array[num + 3] = vector;
				array2[num] = new Vector2(0f, 0f);
				array2[num + 1] = new Vector2(1f, 0f);
				array2[num + 2] = new Vector2(0f, 1f);
				array2[num + 3] = new Vector2(1f, 1f);
				array3[num] = new Vector2(num4, num5);
				array3[num + 1] = new Vector2(num4, num5);
				array3[num + 2] = new Vector2(num4, num5);
				array3[num + 3] = new Vector2(num4, num5);
				array4[num2] = num;
				array4[num2 + 1] = num + 1;
				array4[num2 + 2] = num + 2;
				array4[num2 + 3] = num + 1;
				array4[num2 + 4] = num + 2;
				array4[num2 + 5] = num + 3;
			}
			mesh.vertices = array;
			mesh.triangles = array4;
			mesh.uv = array2;
			mesh.uv2 = array3;
			return mesh;
		}

		// Token: 0x04000B71 RID: 2929
		private static Mesh[] meshes;

		// Token: 0x04000B72 RID: 2930
		private static int currentQuads;
	}
}
