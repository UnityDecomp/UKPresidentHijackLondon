using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.CustomPlugins;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000014 RID: 20
	public static class ShortcutExtensions
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00004370 File Offset: 0x00002570
		public static Tweener DOFade(this AudioSource target, float endValue, float duration)
		{
			if (endValue < 0f)
			{
				endValue = 0f;
			}
			else if (endValue > 1f)
			{
				endValue = 1f;
			}
			return DOTween.To(() => target.volume, delegate(float x)
			{
				target.volume = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000043D4 File Offset: 0x000025D4
		public static Tweener DOPitch(this AudioSource target, float endValue, float duration)
		{
			return DOTween.To(() => target.pitch, delegate(float x)
			{
				target.pitch = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004418 File Offset: 0x00002618
		public static Tweener DOAspect(this Camera target, float endValue, float duration)
		{
			return DOTween.To(() => target.aspect, delegate(float x)
			{
				target.aspect = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000445C File Offset: 0x0000265C
		public static Tweener DOColor(this Camera target, Color endValue, float duration)
		{
			return DOTween.To(() => target.backgroundColor, delegate(Color x)
			{
				target.backgroundColor = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000044A0 File Offset: 0x000026A0
		public static Tweener DOFarClipPlane(this Camera target, float endValue, float duration)
		{
			return DOTween.To(() => target.farClipPlane, delegate(float x)
			{
				target.farClipPlane = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000044E4 File Offset: 0x000026E4
		public static Tweener DOFieldOfView(this Camera target, float endValue, float duration)
		{
			return DOTween.To(() => target.fieldOfView, delegate(float x)
			{
				target.fieldOfView = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004528 File Offset: 0x00002728
		public static Tweener DONearClipPlane(this Camera target, float endValue, float duration)
		{
			return DOTween.To(() => target.nearClipPlane, delegate(float x)
			{
				target.nearClipPlane = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000456C File Offset: 0x0000276C
		public static Tweener DOOrthoSize(this Camera target, float endValue, float duration)
		{
			return DOTween.To(() => target.orthographicSize, delegate(float x)
			{
				target.orthographicSize = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000045B0 File Offset: 0x000027B0
		public static Tweener DOPixelRect(this Camera target, Rect endValue, float duration)
		{
			return DOTween.To(() => target.pixelRect, delegate(Rect x)
			{
				target.pixelRect = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000045F4 File Offset: 0x000027F4
		public static Tweener DORect(this Camera target, Rect endValue, float duration)
		{
			return DOTween.To(() => target.rect, delegate(Rect x)
			{
				target.rect = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004638 File Offset: 0x00002838
		public static Tweener DOShakePosition(this Camera target, float duration, float strength = 3f, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.transform.localPosition, delegate(Vector3 x)
			{
				target.transform.localPosition = x;
			}, duration, strength, vibrato, randomness, true).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004688 File Offset: 0x00002888
		public static Tweener DOShakePosition(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.transform.localPosition, delegate(Vector3 x)
			{
				target.transform.localPosition = x;
			}, duration, strength, vibrato, randomness).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000046D8 File Offset: 0x000028D8
		public static Tweener DOShakeRotation(this Camera target, float duration, float strength = 90f, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.transform.localEulerAngles, delegate(Vector3 x)
			{
				target.transform.localRotation = Quaternion.Euler(x);
			}, duration, strength, vibrato, randomness, false).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004728 File Offset: 0x00002928
		public static Tweener DOShakeRotation(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.transform.localEulerAngles, delegate(Vector3 x)
			{
				target.transform.localRotation = Quaternion.Euler(x);
			}, duration, strength, vibrato, randomness).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004778 File Offset: 0x00002978
		public static Tweener DOColor(this Light target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000047BC File Offset: 0x000029BC
		public static Tweener DOIntensity(this Light target, float endValue, float duration)
		{
			return DOTween.To(() => target.intensity, delegate(float x)
			{
				target.intensity = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004800 File Offset: 0x00002A00
		public static Tweener DOShadowStrength(this Light target, float endValue, float duration)
		{
			return DOTween.To(() => target.shadowStrength, delegate(float x)
			{
				target.shadowStrength = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004844 File Offset: 0x00002A44
		public static Tweener DOColor(this LineRenderer target, Color2 startValue, Color2 endValue, float duration)
		{
			return DOTween.To(() => startValue, delegate(Color2 x)
			{
				target.SetColors(x.ca, x.cb);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004890 File Offset: 0x00002A90
		public static Tweener DOColor(this Material target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000048D4 File Offset: 0x00002AD4
		public static Tweener DOColor(this Material target, Color endValue, string property, float duration)
		{
			if (!target.HasProperty(property))
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogMissingMaterialProperty(property);
				}
				return null;
			}
			return DOTween.To(() => target.GetColor(property), delegate(Color x)
			{
				target.SetColor(property, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004948 File Offset: 0x00002B48
		public static Tweener DOFade(this Material target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000498C File Offset: 0x00002B8C
		public static Tweener DOFade(this Material target, float endValue, string property, float duration)
		{
			if (!target.HasProperty(property))
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogMissingMaterialProperty(property);
				}
				return null;
			}
			return DOTween.ToAlpha(() => target.GetColor(property), delegate(Color x)
			{
				target.SetColor(property, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004A00 File Offset: 0x00002C00
		public static Tweener DOFloat(this Material target, float endValue, string property, float duration)
		{
			if (!target.HasProperty(property))
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogMissingMaterialProperty(property);
				}
				return null;
			}
			return DOTween.To(() => target.GetFloat(property), delegate(float x)
			{
				target.SetFloat(property, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00004A74 File Offset: 0x00002C74
		public static Tweener DOOffset(this Material target, Vector2 endValue, float duration)
		{
			return DOTween.To(() => target.mainTextureOffset, delegate(Vector2 x)
			{
				target.mainTextureOffset = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004AB8 File Offset: 0x00002CB8
		public static Tweener DOOffset(this Material target, Vector2 endValue, string property, float duration)
		{
			if (!target.HasProperty(property))
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogMissingMaterialProperty(property);
				}
				return null;
			}
			return DOTween.To(() => target.GetTextureOffset(property), delegate(Vector2 x)
			{
				target.SetTextureOffset(property, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004B2C File Offset: 0x00002D2C
		public static Tweener DOTiling(this Material target, Vector2 endValue, float duration)
		{
			return DOTween.To(() => target.mainTextureScale, delegate(Vector2 x)
			{
				target.mainTextureScale = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004B70 File Offset: 0x00002D70
		public static Tweener DOTiling(this Material target, Vector2 endValue, string property, float duration)
		{
			if (!target.HasProperty(property))
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogMissingMaterialProperty(property);
				}
				return null;
			}
			return DOTween.To(() => target.GetTextureScale(property), delegate(Vector2 x)
			{
				target.SetTextureScale(property, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004BE4 File Offset: 0x00002DE4
		public static Tweener DOVector(this Material target, Vector4 endValue, string property, float duration)
		{
			if (!target.HasProperty(property))
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogMissingMaterialProperty(property);
				}
				return null;
			}
			return DOTween.To(() => target.GetVector(property), delegate(Vector4 x)
			{
				target.SetVector(property, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004C58 File Offset: 0x00002E58
		public static Tweener DOMove(this Rigidbody target, Vector3 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, new DOSetter<Vector3>(target.MovePosition), endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004CA8 File Offset: 0x00002EA8
		public static Tweener DOMoveX(this Rigidbody target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, new DOSetter<Vector3>(target.MovePosition), new Vector3(endValue, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetTarget(target);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004D08 File Offset: 0x00002F08
		public static Tweener DOMoveY(this Rigidbody target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, new DOSetter<Vector3>(target.MovePosition), new Vector3(0f, endValue, 0f), duration).SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004D68 File Offset: 0x00002F68
		public static Tweener DOMoveZ(this Rigidbody target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, new DOSetter<Vector3>(target.MovePosition), new Vector3(0f, 0f, endValue), duration).SetOptions(AxisConstraint.Z, snapping).SetTarget(target);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004DC8 File Offset: 0x00002FC8
		public static Tweener DORotate(this Rigidbody target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => target.rotation, new DOSetter<Quaternion>(target.MoveRotation), endValue, duration);
			tweenerCore.SetTarget(target);
			tweenerCore.plugOptions.rotateMode = mode;
			return tweenerCore;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004E20 File Offset: 0x00003020
		public static Tweener DOLookAt(this Rigidbody target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
		{
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => target.rotation, new DOSetter<Quaternion>(target.MoveRotation), towards, duration).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetLookAt);
			tweenerCore.plugOptions.axisConstraint = axisConstraint;
			tweenerCore.plugOptions.up = ((up == null) ? Vector3.up : up.Value);
			return tweenerCore;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004EA0 File Offset: 0x000030A0
		public static Sequence DOJump(this Rigidbody target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			ShortcutExtensions.<>c__DisplayClass34_0 CS$<>8__locals1 = new ShortcutExtensions.<>c__DisplayClass34_0();
			CS$<>8__locals1.target = target;
			CS$<>8__locals1.endValue = endValue;
			if (numJumps < 1)
			{
				numJumps = 1;
			}
			ShortcutExtensions.<>c__DisplayClass34_0 CS$<>8__locals2 = CS$<>8__locals1;
			CS$<>8__locals2.startPosY = CS$<>8__locals2.target.position.y;
			CS$<>8__locals1.offsetY = -1f;
			CS$<>8__locals1.offsetYSet = false;
			CS$<>8__locals1.s = DOTween.Sequence();
			CS$<>8__locals1.s.Append(DOTween.To(() => CS$<>8__locals1.target.position, new DOSetter<Vector3>(CS$<>8__locals1.target.MovePosition), new Vector3(CS$<>8__locals1.endValue.x, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetEase(Ease.Linear).OnUpdate(delegate
			{
				if (!CS$<>8__locals1.offsetYSet)
				{
					CS$<>8__locals1.offsetYSet = true;
					CS$<>8__locals1.offsetY = (CS$<>8__locals1.s.isRelative ? CS$<>8__locals1.endValue.y : (CS$<>8__locals1.endValue.y - CS$<>8__locals1.startPosY));
				}
				Vector3 position = CS$<>8__locals1.target.position;
				position.y += DOVirtual.EasedValue(0f, CS$<>8__locals1.offsetY, CS$<>8__locals1.s.ElapsedDirectionalPercentage(), Ease.OutQuad);
				CS$<>8__locals1.target.MovePosition(position);
			})).Join(DOTween.To(() => CS$<>8__locals1.target.position, new DOSetter<Vector3>(CS$<>8__locals1.target.MovePosition), new Vector3(0f, 0f, CS$<>8__locals1.endValue.z), duration).SetOptions(AxisConstraint.Z, snapping).SetEase(Ease.Linear)).Join(DOTween.To(() => CS$<>8__locals1.target.position, new DOSetter<Vector3>(CS$<>8__locals1.target.MovePosition), new Vector3(0f, jumpPower, 0f), duration / (float)(numJumps * 2)).SetOptions(AxisConstraint.Y, snapping).SetEase(Ease.OutQuad).SetLoops(numJumps * 2, LoopType.Yoyo).SetRelative<Tweener>()).SetTarget(CS$<>8__locals1.target).SetEase(DOTween.defaultEaseType);
			return CS$<>8__locals1.s;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000502C File Offset: 0x0000322C
		public static Tweener DOResize(this TrailRenderer target, float toStartWidth, float toEndWidth, float duration)
		{
			return DOTween.To(() => new Vector2(target.startWidth, target.endWidth), delegate(Vector2 x)
			{
				target.startWidth = x.x;
				target.endWidth = x.y;
			}, new Vector2(toStartWidth, toEndWidth), duration).SetTarget(target);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00005078 File Offset: 0x00003278
		public static Tweener DOTime(this TrailRenderer target, float endValue, float duration)
		{
			return DOTween.To(() => target.time, delegate(float x)
			{
				target.time = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000050BC File Offset: 0x000032BC
		public static Tweener DOMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, delegate(Vector3 x)
			{
				target.position = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00005108 File Offset: 0x00003308
		public static Tweener DOMoveX(this Transform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, delegate(Vector3 x)
			{
				target.position = x;
			}, new Vector3(endValue, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetTarget(target);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00005164 File Offset: 0x00003364
		public static Tweener DOMoveY(this Transform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, delegate(Vector3 x)
			{
				target.position = x;
			}, new Vector3(0f, endValue, 0f), duration).SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000051C0 File Offset: 0x000033C0
		public static Tweener DOMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.position, delegate(Vector3 x)
			{
				target.position = x;
			}, new Vector3(0f, 0f, endValue), duration).SetOptions(AxisConstraint.Z, snapping).SetTarget(target);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000521C File Offset: 0x0000341C
		public static Tweener DOLocalMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00005268 File Offset: 0x00003468
		public static Tweener DOLocalMoveX(this Transform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, new Vector3(endValue, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetTarget(target);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000052C4 File Offset: 0x000034C4
		public static Tweener DOLocalMoveY(this Transform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, new Vector3(0f, endValue, 0f), duration).SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00005320 File Offset: 0x00003520
		public static Tweener DOLocalMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, new Vector3(0f, 0f, endValue), duration).SetOptions(AxisConstraint.Z, snapping).SetTarget(target);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000537C File Offset: 0x0000357C
		public static Tweener DORotate(this Transform target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => target.rotation, delegate(Quaternion x)
			{
				target.rotation = x;
			}, endValue, duration);
			tweenerCore.SetTarget(target);
			tweenerCore.plugOptions.rotateMode = mode;
			return tweenerCore;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000053D0 File Offset: 0x000035D0
		public static Tweener DORotateQuaternion(this Transform target, Quaternion endValue, float duration)
		{
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore = DOTween.To<Quaternion, Quaternion, NoOptions>(PureQuaternionPlugin.Plug(), () => target.rotation, delegate(Quaternion x)
			{
				target.rotation = x;
			}, endValue, duration);
			tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000541C File Offset: 0x0000361C
		public static Tweener DOLocalRotate(this Transform target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => target.localRotation, delegate(Quaternion x)
			{
				target.localRotation = x;
			}, endValue, duration);
			tweenerCore.SetTarget(target);
			tweenerCore.plugOptions.rotateMode = mode;
			return tweenerCore;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005470 File Offset: 0x00003670
		public static Tweener DOLocalRotateQuaternion(this Transform target, Quaternion endValue, float duration)
		{
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore = DOTween.To<Quaternion, Quaternion, NoOptions>(PureQuaternionPlugin.Plug(), () => target.localRotation, delegate(Quaternion x)
			{
				target.localRotation = x;
			}, endValue, duration);
			tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000054BC File Offset: 0x000036BC
		public static Tweener DOScale(this Transform target, Vector3 endValue, float duration)
		{
			return DOTween.To(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00005500 File Offset: 0x00003700
		public static Tweener DOScale(this Transform target, float endValue, float duration)
		{
			Vector3 endValue2 = new Vector3(endValue, endValue, endValue);
			return DOTween.To(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, endValue2, duration).SetTarget(target);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005550 File Offset: 0x00003750
		public static Tweener DOScaleX(this Transform target, float endValue, float duration)
		{
			return DOTween.To(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, new Vector3(endValue, 0f, 0f), duration).SetOptions(AxisConstraint.X, false).SetTarget(target);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000055AC File Offset: 0x000037AC
		public static Tweener DOScaleY(this Transform target, float endValue, float duration)
		{
			return DOTween.To(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, new Vector3(0f, endValue, 0f), duration).SetOptions(AxisConstraint.Y, false).SetTarget(target);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005608 File Offset: 0x00003808
		public static Tweener DOScaleZ(this Transform target, float endValue, float duration)
		{
			return DOTween.To(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, new Vector3(0f, 0f, endValue), duration).SetOptions(AxisConstraint.Z, false).SetTarget(target);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00005664 File Offset: 0x00003864
		public static Tweener DOLookAt(this Transform target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
		{
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => target.rotation, delegate(Quaternion x)
			{
				target.rotation = x;
			}, towards, duration).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetLookAt);
			tweenerCore.plugOptions.axisConstraint = axisConstraint;
			tweenerCore.plugOptions.up = ((up == null) ? Vector3.up : up.Value);
			return tweenerCore;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000056DC File Offset: 0x000038DC
		public static Tweener DOPunchPosition(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
		{
			return DOTween.Punch(() => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, punch, duration, vibrato, elasticity).SetTarget(target).SetOptions(snapping);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000572C File Offset: 0x0000392C
		public static Tweener DOPunchScale(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f)
		{
			return DOTween.Punch(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, punch, duration, vibrato, elasticity).SetTarget(target);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005774 File Offset: 0x00003974
		public static Tweener DOPunchRotation(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f)
		{
			return DOTween.Punch(() => target.localEulerAngles, delegate(Vector3 x)
			{
				target.localRotation = Quaternion.Euler(x);
			}, punch, duration, vibrato, elasticity).SetTarget(target);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000057BC File Offset: 0x000039BC
		public static Tweener DOShakePosition(this Transform target, float duration, float strength = 1f, int vibrato = 10, float randomness = 90f, bool snapping = false)
		{
			return DOTween.Shake(() => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, duration, strength, vibrato, randomness, false).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake).SetOptions(snapping);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00005814 File Offset: 0x00003A14
		public static Tweener DOShakePosition(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool snapping = false)
		{
			return DOTween.Shake(() => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, duration, strength, vibrato, randomness).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake).SetOptions(snapping);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00005868 File Offset: 0x00003A68
		public static Tweener DOShakeRotation(this Transform target, float duration, float strength = 90f, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.localEulerAngles, delegate(Vector3 x)
			{
				target.localRotation = Quaternion.Euler(x);
			}, duration, strength, vibrato, randomness, false).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000058B8 File Offset: 0x00003AB8
		public static Tweener DOShakeRotation(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.localEulerAngles, delegate(Vector3 x)
			{
				target.localRotation = Quaternion.Euler(x);
			}, duration, strength, vibrato, randomness).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005908 File Offset: 0x00003B08
		public static Tweener DOShakeScale(this Transform target, float duration, float strength = 1f, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, duration, strength, vibrato, randomness, false).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00005958 File Offset: 0x00003B58
		public static Tweener DOShakeScale(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(() => target.localScale, delegate(Vector3 x)
			{
				target.localScale = x;
			}, duration, strength, vibrato, randomness).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000059A8 File Offset: 0x00003BA8
		public static Sequence DOJump(this Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			ShortcutExtensions.<>c__DisplayClass64_0 CS$<>8__locals1 = new ShortcutExtensions.<>c__DisplayClass64_0();
			CS$<>8__locals1.target = target;
			CS$<>8__locals1.endValue = endValue;
			if (numJumps < 1)
			{
				numJumps = 1;
			}
			ShortcutExtensions.<>c__DisplayClass64_0 CS$<>8__locals2 = CS$<>8__locals1;
			CS$<>8__locals2.startPosY = CS$<>8__locals2.target.position.y;
			CS$<>8__locals1.offsetY = -1f;
			CS$<>8__locals1.offsetYSet = false;
			CS$<>8__locals1.s = DOTween.Sequence();
			CS$<>8__locals1.s.Append(DOTween.To(() => CS$<>8__locals1.target.position, delegate(Vector3 x)
			{
				CS$<>8__locals1.target.position = x;
			}, new Vector3(CS$<>8__locals1.endValue.x, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetEase(Ease.Linear).OnUpdate(delegate
			{
				if (!CS$<>8__locals1.offsetYSet)
				{
					CS$<>8__locals1.offsetYSet = true;
					CS$<>8__locals1.offsetY = (CS$<>8__locals1.s.isRelative ? CS$<>8__locals1.endValue.y : (CS$<>8__locals1.endValue.y - CS$<>8__locals1.startPosY));
				}
				Vector3 position = CS$<>8__locals1.target.position;
				position.y += DOVirtual.EasedValue(0f, CS$<>8__locals1.offsetY, CS$<>8__locals1.s.ElapsedDirectionalPercentage(), Ease.OutQuad);
				CS$<>8__locals1.target.position = position;
			})).Join(DOTween.To(() => CS$<>8__locals1.target.position, delegate(Vector3 x)
			{
				CS$<>8__locals1.target.position = x;
			}, new Vector3(0f, 0f, CS$<>8__locals1.endValue.z), duration).SetOptions(AxisConstraint.Z, snapping).SetEase(Ease.Linear)).Join(DOTween.To(() => CS$<>8__locals1.target.position, delegate(Vector3 x)
			{
				CS$<>8__locals1.target.position = x;
			}, new Vector3(0f, jumpPower, 0f), duration / (float)(numJumps * 2)).SetOptions(AxisConstraint.Y, snapping).SetEase(Ease.OutQuad).SetRelative<Tweener>().SetLoops(numJumps * 2, LoopType.Yoyo)).SetTarget(CS$<>8__locals1.target).SetEase(DOTween.defaultEaseType);
			return CS$<>8__locals1.s;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005B24 File Offset: 0x00003D24
		public static Sequence DOLocalJump(this Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			ShortcutExtensions.<>c__DisplayClass65_0 CS$<>8__locals1 = new ShortcutExtensions.<>c__DisplayClass65_0();
			CS$<>8__locals1.target = target;
			CS$<>8__locals1.endValue = endValue;
			if (numJumps < 1)
			{
				numJumps = 1;
			}
			ShortcutExtensions.<>c__DisplayClass65_0 CS$<>8__locals2 = CS$<>8__locals1;
			CS$<>8__locals2.startPosY = CS$<>8__locals2.target.localPosition.y;
			CS$<>8__locals1.offsetY = -1f;
			CS$<>8__locals1.offsetYSet = false;
			CS$<>8__locals1.s = DOTween.Sequence();
			CS$<>8__locals1.s.Append(DOTween.To(() => CS$<>8__locals1.target.localPosition, delegate(Vector3 x)
			{
				CS$<>8__locals1.target.localPosition = x;
			}, new Vector3(CS$<>8__locals1.endValue.x, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetEase(Ease.Linear).OnUpdate(delegate
			{
				if (!CS$<>8__locals1.offsetYSet)
				{
					CS$<>8__locals1.offsetYSet = false;
					CS$<>8__locals1.offsetY = (CS$<>8__locals1.s.isRelative ? CS$<>8__locals1.endValue.y : (CS$<>8__locals1.endValue.y - CS$<>8__locals1.startPosY));
				}
				Vector3 localPosition = CS$<>8__locals1.target.localPosition;
				localPosition.y += DOVirtual.EasedValue(0f, CS$<>8__locals1.offsetY, CS$<>8__locals1.s.ElapsedDirectionalPercentage(), Ease.OutQuad);
				CS$<>8__locals1.target.localPosition = localPosition;
			})).Join(DOTween.To(() => CS$<>8__locals1.target.localPosition, delegate(Vector3 x)
			{
				CS$<>8__locals1.target.localPosition = x;
			}, new Vector3(0f, 0f, CS$<>8__locals1.endValue.z), duration).SetOptions(AxisConstraint.Z, snapping).SetEase(Ease.Linear)).Join(DOTween.To(() => CS$<>8__locals1.target.localPosition, delegate(Vector3 x)
			{
				CS$<>8__locals1.target.localPosition = x;
			}, new Vector3(0f, jumpPower, 0f), duration / (float)(numJumps * 2)).SetOptions(AxisConstraint.Y, snapping).SetEase(Ease.OutQuad).SetRelative<Tweener>().SetLoops(numJumps * 2, LoopType.Yoyo)).SetTarget(CS$<>8__locals1.target).SetEase(DOTween.defaultEaseType);
			return CS$<>8__locals1.s;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005CA0 File Offset: 0x00003EA0
		public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			if (resolution < 1)
			{
				resolution = 1;
			}
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = DOTween.To<Vector3, Path, PathOptions>(PathPlugin.Get(), () => target.position, delegate(Vector3 x)
			{
				target.position = x;
			}, new Path(pathType, path, resolution, gizmoColor), duration).SetTarget(target);
			tweenerCore.plugOptions.mode = pathMode;
			return tweenerCore;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00005D08 File Offset: 0x00003F08
		public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			if (resolution < 1)
			{
				resolution = 1;
			}
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = DOTween.To<Vector3, Path, PathOptions>(PathPlugin.Get(), () => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, new Path(pathType, path, resolution, gizmoColor), duration).SetTarget(target);
			tweenerCore.plugOptions.mode = pathMode;
			tweenerCore.plugOptions.useLocalPosition = true;
			return tweenerCore;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005D7C File Offset: 0x00003F7C
		internal static TweenerCore<Vector3, Path, PathOptions> DOPath(this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = DOTween.To<Vector3, Path, PathOptions>(PathPlugin.Get(), () => target.position, delegate(Vector3 x)
			{
				target.position = x;
			}, path, duration).SetTarget(target);
			tweenerCore.plugOptions.mode = pathMode;
			return tweenerCore;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005DD4 File Offset: 0x00003FD4
		internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = DOTween.To<Vector3, Path, PathOptions>(PathPlugin.Get(), () => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, path, duration).SetTarget(target);
			tweenerCore.plugOptions.mode = pathMode;
			tweenerCore.plugOptions.useLocalPosition = true;
			return tweenerCore;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005E38 File Offset: 0x00004038
		public static Tweener DOBlendableColor(this Light target, Color endValue, float duration)
		{
			endValue -= target.color;
			Color to = new Color(0f, 0f, 0f, 0f);
			return DOTween.To(() => to, delegate(Color x)
			{
				Color b = x - to;
				to = x;
				Light target2 = target;
				target2.color += b;
			}, endValue, duration).Blendable<Color, Color, ColorOptions>().SetTarget(target);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005EB4 File Offset: 0x000040B4
		public static Tweener DOBlendableColor(this Material target, Color endValue, float duration)
		{
			endValue -= target.color;
			Color to = new Color(0f, 0f, 0f, 0f);
			return DOTween.To(() => to, delegate(Color x)
			{
				Color b = x - to;
				to = x;
				Material target2 = target;
				target2.color += b;
			}, endValue, duration).Blendable<Color, Color, ColorOptions>().SetTarget(target);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00005F30 File Offset: 0x00004130
		public static Tweener DOBlendableColor(this Material target, Color endValue, string property, float duration)
		{
			if (!target.HasProperty(property))
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogMissingMaterialProperty(property);
				}
				return null;
			}
			endValue -= target.color;
			Color to = new Color(0f, 0f, 0f, 0f);
			return DOTween.To(() => to, delegate(Color x)
			{
				Color b = x - to;
				to = x;
				target.SetColor(property, target.GetColor(property) + b);
			}, endValue, duration).Blendable<Color, Color, ColorOptions>().SetTarget(target);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00005FDC File Offset: 0x000041DC
		public static Tweener DOBlendableMoveBy(this Transform target, Vector3 byValue, float duration, bool snapping = false)
		{
			Vector3 to = Vector3.zero;
			return DOTween.To(() => to, delegate(Vector3 x)
			{
				Vector3 b = x - to;
				to = x;
				Transform target2 = target;
				target2.position += b;
			}, byValue, duration).Blendable<Vector3, Vector3, VectorOptions>().SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006038 File Offset: 0x00004238
		public static Tweener DOBlendableLocalMoveBy(this Transform target, Vector3 byValue, float duration, bool snapping = false)
		{
			Vector3 to = Vector3.zero;
			return DOTween.To(() => to, delegate(Vector3 x)
			{
				Vector3 b = x - to;
				to = x;
				Transform target2 = target;
				target2.localPosition += b;
			}, byValue, duration).Blendable<Vector3, Vector3, VectorOptions>().SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006094 File Offset: 0x00004294
		public static Tweener DOBlendableRotateBy(this Transform target, Vector3 byValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			ShortcutExtensions.<>c__DisplayClass75_0 CS$<>8__locals1 = new ShortcutExtensions.<>c__DisplayClass75_0();
			CS$<>8__locals1.target = target;
			ShortcutExtensions.<>c__DisplayClass75_0 CS$<>8__locals2 = CS$<>8__locals1;
			CS$<>8__locals2.to = CS$<>8__locals2.target.rotation;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => CS$<>8__locals1.to, delegate(Quaternion x)
			{
				Quaternion rhs = x * Quaternion.Inverse(CS$<>8__locals1.to);
				CS$<>8__locals1.to = x;
				CS$<>8__locals1.target.rotation = CS$<>8__locals1.target.rotation * Quaternion.Inverse(CS$<>8__locals1.target.rotation) * rhs * CS$<>8__locals1.target.rotation;
			}, byValue, duration).Blendable<Quaternion, Vector3, QuaternionOptions>().SetTarget(CS$<>8__locals1.target);
			tweenerCore.plugOptions.rotateMode = mode;
			return tweenerCore;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000060FC File Offset: 0x000042FC
		public static Tweener DOBlendableLocalRotateBy(this Transform target, Vector3 byValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			ShortcutExtensions.<>c__DisplayClass76_0 CS$<>8__locals1 = new ShortcutExtensions.<>c__DisplayClass76_0();
			CS$<>8__locals1.target = target;
			ShortcutExtensions.<>c__DisplayClass76_0 CS$<>8__locals2 = CS$<>8__locals1;
			CS$<>8__locals2.to = CS$<>8__locals2.target.localRotation;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => CS$<>8__locals1.to, delegate(Quaternion x)
			{
				Quaternion rhs = x * Quaternion.Inverse(CS$<>8__locals1.to);
				CS$<>8__locals1.to = x;
				CS$<>8__locals1.target.localRotation = CS$<>8__locals1.target.localRotation * Quaternion.Inverse(CS$<>8__locals1.target.localRotation) * rhs * CS$<>8__locals1.target.localRotation;
			}, byValue, duration).Blendable<Quaternion, Vector3, QuaternionOptions>().SetTarget(CS$<>8__locals1.target);
			tweenerCore.plugOptions.rotateMode = mode;
			return tweenerCore;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006164 File Offset: 0x00004364
		public static Tweener DOBlendableScaleBy(this Transform target, Vector3 byValue, float duration)
		{
			Vector3 to = Vector3.zero;
			return DOTween.To(() => to, delegate(Vector3 x)
			{
				Vector3 b = x - to;
				to = x;
				Transform target2 = target;
				target2.localScale += b;
			}, byValue, duration).Blendable<Vector3, Vector3, VectorOptions>().SetTarget(target);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000061B8 File Offset: 0x000043B8
		public static int DOComplete(this Component target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000061B8 File Offset: 0x000043B8
		public static int DOComplete(this Material target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000061C1 File Offset: 0x000043C1
		public static int DOKill(this Component target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000061C1 File Offset: 0x000043C1
		public static int DOKill(this Material target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000061CA File Offset: 0x000043CA
		public static int DOFlip(this Component target)
		{
			return DOTween.Flip(target);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000061CA File Offset: 0x000043CA
		public static int DOFlip(this Material target)
		{
			return DOTween.Flip(target);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000061D2 File Offset: 0x000043D2
		public static int DOGoto(this Component target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000061D2 File Offset: 0x000043D2
		public static int DOGoto(this Material target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000061DC File Offset: 0x000043DC
		public static int DOPause(this Component target)
		{
			return DOTween.Pause(target);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000061DC File Offset: 0x000043DC
		public static int DOPause(this Material target)
		{
			return DOTween.Pause(target);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000061E4 File Offset: 0x000043E4
		public static int DOPlay(this Component target)
		{
			return DOTween.Play(target);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000061E4 File Offset: 0x000043E4
		public static int DOPlay(this Material target)
		{
			return DOTween.Play(target);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000061EC File Offset: 0x000043EC
		public static int DOPlayBackwards(this Component target)
		{
			return DOTween.PlayBackwards(target);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000061EC File Offset: 0x000043EC
		public static int DOPlayBackwards(this Material target)
		{
			return DOTween.PlayBackwards(target);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000061F4 File Offset: 0x000043F4
		public static int DOPlayForward(this Component target)
		{
			return DOTween.PlayForward(target);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000061F4 File Offset: 0x000043F4
		public static int DOPlayForward(this Material target)
		{
			return DOTween.PlayForward(target);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000061FC File Offset: 0x000043FC
		public static int DORestart(this Component target, bool includeDelay = true)
		{
			return DOTween.Restart(target, includeDelay);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000061FC File Offset: 0x000043FC
		public static int DORestart(this Material target, bool includeDelay = true)
		{
			return DOTween.Restart(target, includeDelay);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006205 File Offset: 0x00004405
		public static int DORewind(this Component target, bool includeDelay = true)
		{
			return DOTween.Rewind(target, includeDelay);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006205 File Offset: 0x00004405
		public static int DORewind(this Material target, bool includeDelay = true)
		{
			return DOTween.Rewind(target, includeDelay);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000620E File Offset: 0x0000440E
		public static int DOSmoothRewind(this Component target)
		{
			return DOTween.SmoothRewind(target);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000620E File Offset: 0x0000440E
		public static int DOSmoothRewind(this Material target)
		{
			return DOTween.SmoothRewind(target);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006216 File Offset: 0x00004416
		public static int DOTogglePause(this Component target)
		{
			return DOTween.TogglePause(target);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00006216 File Offset: 0x00004416
		public static int DOTogglePause(this Material target)
		{
			return DOTween.TogglePause(target);
		}
	}
}
