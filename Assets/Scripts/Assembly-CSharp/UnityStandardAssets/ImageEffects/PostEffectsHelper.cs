﻿using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200019A RID: 410
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	internal class PostEffectsHelper : MonoBehaviour
	{
		// Token: 0x06000B8D RID: 2957 RVA: 0x00047C45 File Offset: 0x00046045
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Debug.Log("OnRenderImage in Helper called ...");
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00047C54 File Offset: 0x00046054
		private static void DrawLowLevelPlaneAlignedWithCamera(float dist, RenderTexture source, RenderTexture dest, Material material, Camera cameraForProjectionMatrix)
		{
			RenderTexture.active = dest;
			material.SetTexture("_MainTex", source);
			bool flag = true;
			GL.PushMatrix();
			GL.LoadIdentity();
			GL.LoadProjectionMatrix(cameraForProjectionMatrix.projectionMatrix);
			float f = cameraForProjectionMatrix.fieldOfView * 0.5f * 0.0174532924f;
			float num = Mathf.Cos(f) / Mathf.Sin(f);
			float aspect = cameraForProjectionMatrix.aspect;
			float num2 = aspect / -num;
			float num3 = aspect / num;
			float num4 = 1f / -num;
			float num5 = 1f / num;
			float num6 = 1f;
			num2 *= dist * num6;
			num3 *= dist * num6;
			num4 *= dist * num6;
			num5 *= dist * num6;
			float z = -dist;
			for (int i = 0; i < material.passCount; i++)
			{
				material.SetPass(i);
				GL.Begin(7);
				float y;
				float y2;
				if (flag)
				{
					y = 1f;
					y2 = 0f;
				}
				else
				{
					y = 0f;
					y2 = 1f;
				}
				GL.TexCoord2(0f, y);
				GL.Vertex3(num2, num4, z);
				GL.TexCoord2(1f, y);
				GL.Vertex3(num3, num4, z);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(num3, num5, z);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(num2, num5, z);
				GL.End();
			}
			GL.PopMatrix();
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x00047DBC File Offset: 0x000461BC
		private static void DrawBorder(RenderTexture dest, Material material)
		{
			RenderTexture.active = dest;
			bool flag = true;
			GL.PushMatrix();
			GL.LoadOrtho();
			for (int i = 0; i < material.passCount; i++)
			{
				material.SetPass(i);
				float y;
				float y2;
				if (flag)
				{
					y = 1f;
					y2 = 0f;
				}
				else
				{
					y = 0f;
					y2 = 1f;
				}
				float x = 0f;
				float x2 = 1f / ((float)dest.width * 1f);
				float y3 = 0f;
				float y4 = 1f;
				GL.Begin(7);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 1f - 1f / ((float)dest.width * 1f);
				x2 = 1f;
				y3 = 0f;
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 0f;
				x2 = 1f;
				y3 = 0f;
				y4 = 1f / ((float)dest.height * 1f);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 0f;
				x2 = 1f;
				y3 = 1f - 1f / ((float)dest.height * 1f);
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				GL.End();
			}
			GL.PopMatrix();
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0004805C File Offset: 0x0004645C
		private static void DrawLowLevelQuad(float x1, float x2, float y1, float y2, RenderTexture source, RenderTexture dest, Material material)
		{
			RenderTexture.active = dest;
			material.SetTexture("_MainTex", source);
			bool flag = true;
			GL.PushMatrix();
			GL.LoadOrtho();
			for (int i = 0; i < material.passCount; i++)
			{
				material.SetPass(i);
				GL.Begin(7);
				float y3;
				float y4;
				if (flag)
				{
					y3 = 1f;
					y4 = 0f;
				}
				else
				{
					y3 = 0f;
					y4 = 1f;
				}
				GL.TexCoord2(0f, y3);
				GL.Vertex3(x1, y1, 0.1f);
				GL.TexCoord2(1f, y3);
				GL.Vertex3(x2, y1, 0.1f);
				GL.TexCoord2(1f, y4);
				GL.Vertex3(x2, y2, 0.1f);
				GL.TexCoord2(0f, y4);
				GL.Vertex3(x1, y2, 0.1f);
				GL.End();
			}
			GL.PopMatrix();
		}
	}
}
