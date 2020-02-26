using System;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	// Token: 0x02000042 RID: 66
	[Serializable]
	public class Path
	{
		// Token: 0x06000221 RID: 545 RVA: 0x0000C68C File Offset: 0x0000A88C
		public Path(PathType type, Vector3[] waypoints, int subdivisionsXSegment, Color? gizmoColor = null)
		{
			this.type = type;
			this.subdivisionsXSegment = subdivisionsXSegment;
			if (gizmoColor != null)
			{
				this.gizmoColor = gizmoColor.Value;
			}
			this.AssignWaypoints(waypoints, true);
			this.AssignDecoder(type);
			if (DOTween.isUnityEditor)
			{
				DOTween.GizmosDelegates.Add(new TweenCallback(this.Draw));
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000C715 File Offset: 0x0000A915
		internal Path()
		{
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000C744 File Offset: 0x0000A944
		internal void FinalizePath(bool isClosedPath, AxisConstraint lockPositionAxes, Vector3 currTargetVal)
		{
			if (lockPositionAxes != AxisConstraint.None)
			{
				bool flag = (lockPositionAxes & AxisConstraint.X) == AxisConstraint.X;
				bool flag2 = (lockPositionAxes & AxisConstraint.Y) == AxisConstraint.Y;
				bool flag3 = (lockPositionAxes & AxisConstraint.Z) == AxisConstraint.Z;
				for (int i = 0; i < this.wps.Length; i++)
				{
					Vector3 vector = this.wps[i];
					this.wps[i] = new Vector3(flag ? currTargetVal.x : vector.x, flag2 ? currTargetVal.y : vector.y, flag3 ? currTargetVal.z : vector.z);
				}
			}
			this._decoder.FinalizePath(this, this.wps, isClosedPath);
			this.isFinalized = true;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000C7EB File Offset: 0x0000A9EB
		internal Vector3 GetPoint(float perc, bool convertToConstantPerc = false)
		{
			if (convertToConstantPerc)
			{
				perc = this.ConvertToConstantPathPerc(perc);
			}
			return this._decoder.GetPoint(perc, this.wps, this, this.controlPoints);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000C814 File Offset: 0x0000AA14
		internal float ConvertToConstantPathPerc(float perc)
		{
			if (this.type == PathType.Linear)
			{
				return perc;
			}
			if (perc > 0f && perc < 1f)
			{
				float num = this.length * perc;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				int num6 = this.lengthsTable.Length;
				int i = 0;
				while (i < num6)
				{
					if (this.lengthsTable[i] > num)
					{
						num4 = this.timesTable[i];
						num5 = this.lengthsTable[i];
						if (i > 0)
						{
							num3 = this.lengthsTable[i - 1];
							break;
						}
						break;
					}
					else
					{
						num2 = this.timesTable[i];
						i++;
					}
				}
				perc = num2 + (num - num3) / (num5 - num3) * (num4 - num2);
			}
			if (perc > 1f)
			{
				perc = 1f;
			}
			else if (perc < 0f)
			{
				perc = 0f;
			}
			return perc;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000C8F0 File Offset: 0x0000AAF0
		internal int GetWaypointIndexFromPerc(float perc, bool isMovingForward)
		{
			if (perc >= 1f)
			{
				return this.wps.Length - 1;
			}
			if (perc <= 0f)
			{
				return 0;
			}
			float num = this.length * perc;
			float num2 = 0f;
			int i = 0;
			int num3 = this.wpLengths.Length;
			while (i < num3)
			{
				num2 += this.wpLengths[i];
				if (num2 >= num)
				{
					if (num2 <= num)
					{
						return i;
					}
					if (!isMovingForward)
					{
						return i;
					}
					return i - 1;
				}
				else
				{
					i++;
				}
			}
			return 0;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000C960 File Offset: 0x0000AB60
		internal static Vector3[] GetDrawPoints(Path p, int drawSubdivisionsXSegment)
		{
			int num = p.wps.Length;
			if (p.type == PathType.Linear)
			{
				return p.wps;
			}
			int num2 = num * drawSubdivisionsXSegment;
			Vector3[] array = new Vector3[num2 + 1];
			for (int i = 0; i <= num2; i++)
			{
				float perc = (float)i / (float)num2;
				Vector3 point = p.GetPoint(perc, false);
				array[i] = point;
			}
			return array;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000C9BC File Offset: 0x0000ABBC
		internal static void RefreshNonLinearDrawWps(Path p)
		{
			int num = p.wps.Length * 10;
			if (p.nonLinearDrawWps == null || p.nonLinearDrawWps.Length != num + 1)
			{
				p.nonLinearDrawWps = new Vector3[num + 1];
			}
			for (int i = 0; i <= num; i++)
			{
				float perc = (float)i / (float)num;
				Vector3 point = p.GetPoint(perc, false);
				p.nonLinearDrawWps[i] = point;
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000CA20 File Offset: 0x0000AC20
		internal void Destroy()
		{
			if (DOTween.isUnityEditor)
			{
				DOTween.GizmosDelegates.Remove(new TweenCallback(this.Draw));
			}
			this.wps = null;
			this.wpLengths = (this.timesTable = (this.lengthsTable = null));
			this.nonLinearDrawWps = null;
			this.isFinalized = false;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000CA7C File Offset: 0x0000AC7C
		internal Path CloneIncremental(int loopIncrement)
		{
			if (this._incrementalClone != null)
			{
				if (this._incrementalIndex == loopIncrement)
				{
					return this._incrementalClone;
				}
				this._incrementalClone.Destroy();
			}
			int num = this.wps.Length;
			Vector3 a = this.wps[num - 1] - this.wps[0];
			Vector3[] array = new Vector3[this.wps.Length];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.wps[i] + a * (float)loopIncrement;
			}
			int num2 = this.controlPoints.Length;
			ControlPoint[] array2 = new ControlPoint[num2];
			for (int j = 0; j < num2; j++)
			{
				array2[j] = this.controlPoints[j] + a * (float)loopIncrement;
			}
			Vector3[] array3 = null;
			if (this.nonLinearDrawWps != null)
			{
				int num3 = this.nonLinearDrawWps.Length;
				array3 = new Vector3[num3];
				for (int k = 0; k < num3; k++)
				{
					array3[k] = this.nonLinearDrawWps[k] + a * (float)loopIncrement;
				}
			}
			this._incrementalClone = new Path();
			this._incrementalIndex = loopIncrement;
			this._incrementalClone.type = this.type;
			this._incrementalClone.subdivisionsXSegment = this.subdivisionsXSegment;
			this._incrementalClone.subdivisions = this.subdivisions;
			this._incrementalClone.wps = array;
			this._incrementalClone.controlPoints = array2;
			if (DOTween.isUnityEditor)
			{
				DOTween.GizmosDelegates.Add(new TweenCallback(this._incrementalClone.Draw));
			}
			this._incrementalClone.length = this.length;
			this._incrementalClone.wpLengths = this.wpLengths;
			this._incrementalClone.timesTable = this.timesTable;
			this._incrementalClone.lengthsTable = this.lengthsTable;
			this._incrementalClone._decoder = this._decoder;
			this._incrementalClone.nonLinearDrawWps = array3;
			this._incrementalClone.targetPosition = this.targetPosition;
			this._incrementalClone.lookAtPosition = this.lookAtPosition;
			this._incrementalClone.isFinalized = true;
			return this._incrementalClone;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000CCC4 File Offset: 0x0000AEC4
		internal void AssignWaypoints(Vector3[] newWps, bool cloneWps = false)
		{
			if (cloneWps)
			{
				int num = newWps.Length;
				this.wps = new Vector3[num];
				for (int i = 0; i < num; i++)
				{
					this.wps[i] = newWps[i];
				}
				return;
			}
			this.wps = newWps;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000CD0C File Offset: 0x0000AF0C
		internal void AssignDecoder(PathType pathType)
		{
			this.type = pathType;
			if (pathType == PathType.Linear)
			{
				if (Path._linearDecoder == null)
				{
					Path._linearDecoder = new LinearDecoder();
				}
				this._decoder = Path._linearDecoder;
				return;
			}
			if (Path._catmullRomDecoder == null)
			{
				Path._catmullRomDecoder = new CatmullRomDecoder();
			}
			this._decoder = Path._catmullRomDecoder;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000CD5C File Offset: 0x0000AF5C
		internal void Draw()
		{
			Path.Draw(this);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000CD64 File Offset: 0x0000AF64
		private static void Draw(Path p)
		{
			if (p.timesTable == null)
			{
				return;
			}
			Color color = p.gizmoColor;
			color.a *= 0.5f;
			Gizmos.color = p.gizmoColor;
			int num = p.wps.Length;
			if (p._changed || (p.type != PathType.Linear && p.nonLinearDrawWps == null))
			{
				p._changed = false;
				if (p.type != PathType.Linear)
				{
					Path.RefreshNonLinearDrawWps(p);
				}
			}
			if (p.type == PathType.Linear)
			{
				Vector3 to = p.wps[0];
				for (int i = 0; i < num; i++)
				{
					Vector3 vector = p.wps[i];
					Gizmos.DrawLine(vector, to);
					to = vector;
				}
			}
			else
			{
				Vector3 to = p.nonLinearDrawWps[0];
				int num2 = p.nonLinearDrawWps.Length;
				for (int j = 1; j < num2; j++)
				{
					Vector3 vector2 = p.nonLinearDrawWps[j];
					Gizmos.DrawLine(vector2, to);
					to = vector2;
				}
			}
			Gizmos.color = color;
			for (int k = 0; k < num; k++)
			{
				Gizmos.DrawSphere(p.wps[k], 0.075f);
			}
			if (p.lookAtPosition != null)
			{
				Vector3 value = p.lookAtPosition.Value;
				Gizmos.DrawLine(p.targetPosition, value);
				Gizmos.DrawWireSphere(value, 0.075f);
			}
		}

		// Token: 0x040000FD RID: 253
		private static CatmullRomDecoder _catmullRomDecoder;

		// Token: 0x040000FE RID: 254
		private static LinearDecoder _linearDecoder;

		// Token: 0x040000FF RID: 255
		[SerializeField]
		internal PathType type;

		// Token: 0x04000100 RID: 256
		[SerializeField]
		internal int subdivisionsXSegment;

		// Token: 0x04000101 RID: 257
		[SerializeField]
		internal int subdivisions;

		// Token: 0x04000102 RID: 258
		[SerializeField]
		internal Vector3[] wps;

		// Token: 0x04000103 RID: 259
		[SerializeField]
		internal ControlPoint[] controlPoints;

		// Token: 0x04000104 RID: 260
		[SerializeField]
		internal float length;

		// Token: 0x04000105 RID: 261
		[SerializeField]
		internal float[] wpLengths;

		// Token: 0x04000106 RID: 262
		[SerializeField]
		internal bool isFinalized;

		// Token: 0x04000107 RID: 263
		[SerializeField]
		internal float[] timesTable;

		// Token: 0x04000108 RID: 264
		[SerializeField]
		internal float[] lengthsTable;

		// Token: 0x04000109 RID: 265
		internal int linearWPIndex = -1;

		// Token: 0x0400010A RID: 266
		private Path _incrementalClone;

		// Token: 0x0400010B RID: 267
		private int _incrementalIndex;

		// Token: 0x0400010C RID: 268
		private ABSPathDecoder _decoder;

		// Token: 0x0400010D RID: 269
		private bool _changed;

		// Token: 0x0400010E RID: 270
		internal Vector3[] nonLinearDrawWps;

		// Token: 0x0400010F RID: 271
		internal Vector3 targetPosition;

		// Token: 0x04000110 RID: 272
		internal Vector3? lookAtPosition;

		// Token: 0x04000111 RID: 273
		internal Color gizmoColor = new Color(1f, 1f, 1f, 0.7f);
	}
}
