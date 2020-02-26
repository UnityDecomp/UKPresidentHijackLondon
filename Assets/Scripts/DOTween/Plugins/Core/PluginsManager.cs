using System;
using System.Collections.Generic;
using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening.Plugins.Core
{
	// Token: 0x0200003D RID: 61
	internal static class PluginsManager
	{
		// Token: 0x0600020F RID: 527 RVA: 0x0000BD18 File Offset: 0x00009F18
		internal static ABSTweenPlugin<T1, T2, TPlugOptions> GetDefaultPlugin<T1, T2, TPlugOptions>() where TPlugOptions : struct
		{
			Type typeFromHandle = typeof(T1);
			Type typeFromHandle2 = typeof(T2);
			ITweenPlugin tweenPlugin = null;
			if (typeFromHandle == typeof(Vector3) && typeFromHandle == typeFromHandle2)
			{
				if (PluginsManager._vector3Plugin == null)
				{
					PluginsManager._vector3Plugin = new Vector3Plugin();
				}
				tweenPlugin = PluginsManager._vector3Plugin;
			}
			else if (typeFromHandle == typeof(Vector3) && typeFromHandle2 == typeof(Vector3[]))
			{
				if (PluginsManager._vector3ArrayPlugin == null)
				{
					PluginsManager._vector3ArrayPlugin = new Vector3ArrayPlugin();
				}
				tweenPlugin = PluginsManager._vector3ArrayPlugin;
			}
			else if (typeFromHandle == typeof(Quaternion))
			{
				if (typeFromHandle2 == typeof(Quaternion))
				{
					Debugger.LogError("Quaternion tweens require a Vector3 endValue");
				}
				else
				{
					if (PluginsManager._quaternionPlugin == null)
					{
						PluginsManager._quaternionPlugin = new QuaternionPlugin();
					}
					tweenPlugin = PluginsManager._quaternionPlugin;
				}
			}
			else if (typeFromHandle == typeof(Vector2))
			{
				if (PluginsManager._vector2Plugin == null)
				{
					PluginsManager._vector2Plugin = new Vector2Plugin();
				}
				tweenPlugin = PluginsManager._vector2Plugin;
			}
			else if (typeFromHandle == typeof(float))
			{
				if (PluginsManager._floatPlugin == null)
				{
					PluginsManager._floatPlugin = new FloatPlugin();
				}
				tweenPlugin = PluginsManager._floatPlugin;
			}
			else if (typeFromHandle == typeof(Color))
			{
				if (PluginsManager._colorPlugin == null)
				{
					PluginsManager._colorPlugin = new ColorPlugin();
				}
				tweenPlugin = PluginsManager._colorPlugin;
			}
			else if (typeFromHandle == typeof(int))
			{
				if (PluginsManager._intPlugin == null)
				{
					PluginsManager._intPlugin = new IntPlugin();
				}
				tweenPlugin = PluginsManager._intPlugin;
			}
			else if (typeFromHandle == typeof(Vector4))
			{
				if (PluginsManager._vector4Plugin == null)
				{
					PluginsManager._vector4Plugin = new Vector4Plugin();
				}
				tweenPlugin = PluginsManager._vector4Plugin;
			}
			else if (typeFromHandle == typeof(Rect))
			{
				if (PluginsManager._rectPlugin == null)
				{
					PluginsManager._rectPlugin = new RectPlugin();
				}
				tweenPlugin = PluginsManager._rectPlugin;
			}
			else if (typeFromHandle == typeof(RectOffset))
			{
				if (PluginsManager._rectOffsetPlugin == null)
				{
					PluginsManager._rectOffsetPlugin = new RectOffsetPlugin();
				}
				tweenPlugin = PluginsManager._rectOffsetPlugin;
			}
			else if (typeFromHandle == typeof(uint))
			{
				if (PluginsManager._uintPlugin == null)
				{
					PluginsManager._uintPlugin = new UintPlugin();
				}
				tweenPlugin = PluginsManager._uintPlugin;
			}
			else if (typeFromHandle == typeof(string))
			{
				if (PluginsManager._stringPlugin == null)
				{
					PluginsManager._stringPlugin = new StringPlugin();
				}
				tweenPlugin = PluginsManager._stringPlugin;
			}
			else if (typeFromHandle == typeof(Color2))
			{
				if (PluginsManager._color2Plugin == null)
				{
					PluginsManager._color2Plugin = new Color2Plugin();
				}
				tweenPlugin = PluginsManager._color2Plugin;
			}
			else if (typeFromHandle == typeof(long))
			{
				if (PluginsManager._longPlugin == null)
				{
					PluginsManager._longPlugin = new LongPlugin();
				}
				tweenPlugin = PluginsManager._longPlugin;
			}
			else if (typeFromHandle == typeof(ulong))
			{
				if (PluginsManager._ulongPlugin == null)
				{
					PluginsManager._ulongPlugin = new UlongPlugin();
				}
				tweenPlugin = PluginsManager._ulongPlugin;
			}
			else if (typeFromHandle == typeof(double))
			{
				if (PluginsManager._doublePlugin == null)
				{
					PluginsManager._doublePlugin = new DoublePlugin();
				}
				tweenPlugin = PluginsManager._doublePlugin;
			}
			if (tweenPlugin != null)
			{
				return tweenPlugin as ABSTweenPlugin<T1, T2, TPlugOptions>;
			}
			return null;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000BFF8 File Offset: 0x0000A1F8
		public static ABSTweenPlugin<T1, T2, TPlugOptions> GetCustomPlugin<TPlugin, T1, T2, TPlugOptions>() where TPlugin : ITweenPlugin, new() where TPlugOptions : struct
		{
			Type typeFromHandle = typeof(TPlugin);
			ITweenPlugin tweenPlugin;
			if (PluginsManager._customPlugins == null)
			{
				PluginsManager._customPlugins = new Dictionary<Type, ITweenPlugin>(20);
			}
			else if (PluginsManager._customPlugins.TryGetValue(typeFromHandle, out tweenPlugin))
			{
				return tweenPlugin as ABSTweenPlugin<T1, T2, TPlugOptions>;
			}
			tweenPlugin = Activator.CreateInstance<TPlugin>();
			PluginsManager._customPlugins.Add(typeFromHandle, tweenPlugin);
			return tweenPlugin as ABSTweenPlugin<T1, T2, TPlugOptions>;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000C058 File Offset: 0x0000A258
		internal static void PurgeAll()
		{
			PluginsManager._floatPlugin = null;
			PluginsManager._intPlugin = null;
			PluginsManager._uintPlugin = null;
			PluginsManager._longPlugin = null;
			PluginsManager._ulongPlugin = null;
			PluginsManager._vector2Plugin = null;
			PluginsManager._vector3Plugin = null;
			PluginsManager._vector4Plugin = null;
			PluginsManager._quaternionPlugin = null;
			PluginsManager._colorPlugin = null;
			PluginsManager._rectPlugin = null;
			PluginsManager._rectOffsetPlugin = null;
			PluginsManager._stringPlugin = null;
			PluginsManager._vector3ArrayPlugin = null;
			PluginsManager._color2Plugin = null;
			if (PluginsManager._customPlugins != null)
			{
				PluginsManager._customPlugins.Clear();
			}
		}

		// Token: 0x040000E9 RID: 233
		private static ITweenPlugin _floatPlugin;

		// Token: 0x040000EA RID: 234
		private static ITweenPlugin _doublePlugin;

		// Token: 0x040000EB RID: 235
		private static ITweenPlugin _intPlugin;

		// Token: 0x040000EC RID: 236
		private static ITweenPlugin _uintPlugin;

		// Token: 0x040000ED RID: 237
		private static ITweenPlugin _longPlugin;

		// Token: 0x040000EE RID: 238
		private static ITweenPlugin _ulongPlugin;

		// Token: 0x040000EF RID: 239
		private static ITweenPlugin _vector2Plugin;

		// Token: 0x040000F0 RID: 240
		private static ITweenPlugin _vector3Plugin;

		// Token: 0x040000F1 RID: 241
		private static ITweenPlugin _vector4Plugin;

		// Token: 0x040000F2 RID: 242
		private static ITweenPlugin _quaternionPlugin;

		// Token: 0x040000F3 RID: 243
		private static ITweenPlugin _colorPlugin;

		// Token: 0x040000F4 RID: 244
		private static ITweenPlugin _rectPlugin;

		// Token: 0x040000F5 RID: 245
		private static ITweenPlugin _rectOffsetPlugin;

		// Token: 0x040000F6 RID: 246
		private static ITweenPlugin _stringPlugin;

		// Token: 0x040000F7 RID: 247
		private static ITweenPlugin _vector3ArrayPlugin;

		// Token: 0x040000F8 RID: 248
		private static ITweenPlugin _color2Plugin;

		// Token: 0x040000F9 RID: 249
		private const int _MaxCustomPlugins = 20;

		// Token: 0x040000FA RID: 250
		private static Dictionary<Type, ITweenPlugin> _customPlugins;
	}
}
