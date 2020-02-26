using System;
using UnityEngine;

// Token: 0x02000135 RID: 309
[Serializable]
public class TouchStick : TouchableControl
{
	// Token: 0x1700004B RID: 75
	// (get) Token: 0x0600087F RID: 2175 RVA: 0x00037326 File Offset: 0x00035726
	public bool dynamicVisible
	{
		get
		{
			return this.animAlpha.cur > 0.01f;
		}
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x0003733A File Offset: 0x0003573A
	public bool Pressed()
	{
		return this.pressedCur;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x00037342 File Offset: 0x00035742
	public bool JustPressed()
	{
		return this.pressedCur && !this.pressedPrev;
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x0003735B File Offset: 0x0003575B
	public bool JustReleased()
	{
		return !this.pressedCur && this.pressedPrev;
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x00037371 File Offset: 0x00035771
	public float GetTilt()
	{
		return this.tilt;
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x00037379 File Offset: 0x00035779
	public float GetAngle()
	{
		return this.angle;
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x00037381 File Offset: 0x00035781
	public Vector2 GetVec()
	{
		return this.posRaw;
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x00037389 File Offset: 0x00035789
	public Vector2 GetNormalizedVec()
	{
		return this.dirVec;
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x00037394 File Offset: 0x00035794
	public Vector2 GetVecEx(TouchStick.StickPosMode vis)
	{
		float dirCodeAngle = this.angle;
		float num = this.tilt;
		switch (vis)
		{
		case TouchStick.StickPosMode.FULL_ANALOG:
			return this.posRaw;
		case TouchStick.StickPosMode.ANALOG_8WAY:
			dirCodeAngle = TouchStick.GetDirCodeAngle(this.dir8way);
			num = ((this.dir8way == TouchStick.StickDir.NEUTRAL) ? 0f : num);
			break;
		case TouchStick.StickPosMode.ANALOG_4WAY:
			dirCodeAngle = TouchStick.GetDirCodeAngle(this.dir4way);
			num = ((this.dir4way == TouchStick.StickDir.NEUTRAL) ? 0f : num);
			break;
		case TouchStick.StickPosMode.DIGITAL_8WAY:
			dirCodeAngle = TouchStick.GetDirCodeAngle(this.dir8way);
			num = (float)((this.dir8way == TouchStick.StickDir.NEUTRAL) ? 0 : 1);
			break;
		case TouchStick.StickPosMode.DIGITAL_4WAY:
			dirCodeAngle = TouchStick.GetDirCodeAngle(this.dir4way);
			num = (float)((this.dir4way == TouchStick.StickDir.NEUTRAL) ? 0 : 1);
			break;
		}
		return TouchStick.RotateVec2(new Vector2(0f, 1f), dirCodeAngle) * num;
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x0003748C File Offset: 0x0003588C
	public Vector3 GetVec3d(bool normalized, float orientByAngle)
	{
		Vector2 pos = (!normalized) ? this.posRaw : this.dirVec;
		if (orientByAngle != 0f)
		{
			pos = TouchStick.RotateVec2(pos, orientByAngle);
		}
		return new Vector3(pos.x, 0f, pos.y);
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x000374DC File Offset: 0x000358DC
	public Vector3 GetVec3d(TouchStick.Vec3DMode vecMode, bool normalized, float orientByAngle)
	{
		Vector2 pos = (!normalized) ? this.posRaw : this.dirVec;
		if (orientByAngle != 0f)
		{
			pos = TouchStick.RotateVec2(pos, orientByAngle);
		}
		if (vecMode == TouchStick.Vec3DMode.XY)
		{
			return new Vector3(pos.x, pos.y, 0f);
		}
		if (vecMode != TouchStick.Vec3DMode.XZ)
		{
			return Vector3.zero;
		}
		return new Vector3(pos.x, 0f, pos.y);
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x0003755D File Offset: 0x0003595D
	public Vector3 GetVec3d(TouchStick.Vec3DMode vecMode, bool normalized)
	{
		return this.GetVec3d(vecMode, normalized, 0f);
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x0003756C File Offset: 0x0003596C
	public TouchStick.StickDir GetDigitalDir(bool eightWayMode)
	{
		return (!eightWayMode) ? this.dir4way : this.dir8way;
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x00037585 File Offset: 0x00035985
	public TouchStick.StickDir GetDigitalDir()
	{
		return this.dir8way;
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x0003758D File Offset: 0x0003598D
	public TouchStick.StickDir GetFourWayDir()
	{
		return this.dir4way;
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x00037595 File Offset: 0x00035995
	public TouchStick.StickDir GetPrevDigitalDir(bool eightWayMode = true)
	{
		return (!eightWayMode) ? this.dir4wayPrev : this.dir8wayPrev;
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x000375AE File Offset: 0x000359AE
	public TouchStick.StickDir GetPrevDigitalDir()
	{
		return this.dir8wayPrev;
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x000375B6 File Offset: 0x000359B6
	public TouchStick.StickDir GetPrevFourWayDir()
	{
		return this.dir4wayPrev;
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x000375BE File Offset: 0x000359BE
	public bool DigitalJustChanged(bool eightWayMode)
	{
		return (!eightWayMode) ? (this.dir4way != this.dir4wayPrev) : (this.dir8way != this.dir8wayPrev);
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x000375ED File Offset: 0x000359ED
	public bool DigitalJustChanged()
	{
		return this.dir8way != this.dir8wayPrev;
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x00037600 File Offset: 0x00035A00
	public bool FourWayJustChanged()
	{
		return this.dir4way != this.dir4wayPrev;
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x00037614 File Offset: 0x00035A14
	private static bool KeyCodeInDir(KeyCode keyCode, TouchStick.StickDir dir)
	{
		if (dir == TouchStick.StickDir.NEUTRAL)
		{
			return false;
		}
		switch (keyCode)
		{
		case KeyCode.UpArrow:
			break;
		case KeyCode.DownArrow:
			goto IL_68;
		case KeyCode.RightArrow:
			goto IL_94;
		case KeyCode.LeftArrow:
			goto IL_7E;
		default:
			switch (keyCode)
			{
			case KeyCode.A:
				goto IL_7E;
			default:
				if (keyCode == KeyCode.S)
				{
					goto IL_68;
				}
				if (keyCode != KeyCode.W)
				{
					return false;
				}
				break;
			case KeyCode.D:
				goto IL_94;
			}
			break;
		}
		return dir == TouchStick.StickDir.U || dir == TouchStick.StickDir.UL || dir == TouchStick.StickDir.UR;
		IL_68:
		return dir == TouchStick.StickDir.D || dir == TouchStick.StickDir.DL || dir == TouchStick.StickDir.DR;
		IL_7E:
		return dir == TouchStick.StickDir.L || dir == TouchStick.StickDir.DL || dir == TouchStick.StickDir.UL;
		IL_94:
		return dir == TouchStick.StickDir.R || dir == TouchStick.StickDir.DR || dir == TouchStick.StickDir.UR;
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x000376CC File Offset: 0x00035ACC
	public float GetAxis(string name)
	{
		bool flag = false;
		return this.GetAxisEx(name, out flag);
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x000376E4 File Offset: 0x00035AE4
	public float GetAxisEx(string name, out bool supported)
	{
		if (!this.enableGetAxis)
		{
			supported = false;
			return 0f;
		}
		if (name == this.axisHorzName)
		{
			supported = true;
			return (!this.axisHorzFlip) ? this.posRaw.x : (-this.posRaw.x);
		}
		if (name == this.axisVertName)
		{
			supported = true;
			return (!this.axisVertFlip) ? this.posRaw.y : (-this.posRaw.y);
		}
		supported = false;
		return 0f;
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x00037788 File Offset: 0x00035B88
	public bool GetButton(string buttonName)
	{
		bool flag = false;
		return this.GetButtonEx(buttonName, out flag);
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x000377A0 File Offset: 0x00035BA0
	public bool GetButtonDown(string buttonName)
	{
		bool flag = false;
		return this.GetButtonDownEx(buttonName, out flag);
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x000377B8 File Offset: 0x00035BB8
	public bool GetButtonUp(string buttonName)
	{
		bool flag = false;
		return this.GetButtonUpEx(buttonName, out flag);
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x000377D0 File Offset: 0x00035BD0
	public bool GetButtonEx(string buttonName, out bool buttonSupported)
	{
		return (buttonSupported = (this.enableGetButton && buttonName == this.getButtonName)) && this.Pressed();
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x0003780C File Offset: 0x00035C0C
	public bool GetButtonDownEx(string buttonName, out bool buttonSupported)
	{
		return (buttonSupported = (this.enableGetButton && buttonName == this.getButtonName)) && this.JustPressed();
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x00037848 File Offset: 0x00035C48
	public bool GetButtonUpEx(string buttonName, out bool buttonSupported)
	{
		return (buttonSupported = (this.enableGetButton && buttonName == this.getButtonName)) && this.JustReleased();
	}

	// Token: 0x0600089D RID: 2205 RVA: 0x00037884 File Offset: 0x00035C84
	public bool GetKey(KeyCode key)
	{
		return this.enableGetKey && key != KeyCode.None && (((key == this.getKeyCodePress || key == this.getKeyCodePressAlt) && this.Pressed()) || (this.dir8way != TouchStick.StickDir.NEUTRAL && this.CheckKeyCode(key, this.dir8way)));
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x000378E4 File Offset: 0x00035CE4
	public bool GetKeyDown(KeyCode key)
	{
		return this.enableGetKey && key != KeyCode.None && (((key == this.getKeyCodePress || key == this.getKeyCodePressAlt) && this.JustPressed()) || (this.dir8way != this.dir8wayPrev && this.CheckKeyCode(key, this.dir8way) && !this.CheckKeyCode(key, this.dir8wayPrev)));
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x00037960 File Offset: 0x00035D60
	public bool GetKeyUp(KeyCode key)
	{
		return this.enableGetKey && key != KeyCode.None && (((key == this.getKeyCodePress || key == this.getKeyCodePressAlt) && this.JustReleased()) || (this.dir8way != this.dir8wayPrev && !this.CheckKeyCode(key, this.dir8way) && this.CheckKeyCode(key, this.dir8wayPrev)));
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x000379D8 File Offset: 0x00035DD8
	public bool GetKeyEx(KeyCode key, out bool keySupported)
	{
		keySupported = this.IsKeySupported(key);
		return this.GetKey(key);
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x000379EA File Offset: 0x00035DEA
	public bool GetKeyDownEx(KeyCode key, out bool keySupported)
	{
		keySupported = this.IsKeySupported(key);
		return this.GetKeyDown(key);
	}

	// Token: 0x060008A2 RID: 2210 RVA: 0x000379FC File Offset: 0x00035DFC
	public bool GetKeyUpEx(KeyCode key, out bool keySupported)
	{
		keySupported = this.IsKeySupported(key);
		return this.GetKeyUp(key);
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x00037A10 File Offset: 0x00035E10
	public bool IsKeySupported(KeyCode key)
	{
		return !this.enableGetKey || key == this.getKeyCodePress || key == this.getKeyCodePressAlt || key == this.getKeyCodeUp || key == this.getKeyCodeUpAlt || key == this.getKeyCodeDown || key == this.getKeyCodeDownAlt || key == this.getKeyCodeLeft || key == this.getKeyCodeLeftAlt || key == this.getKeyCodeRight || key == this.getKeyCodeRightAlt;
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x00037AA4 File Offset: 0x00035EA4
	private bool CheckKeyCode(KeyCode key, TouchStick.StickDir dir)
	{
		if (dir == TouchStick.StickDir.NEUTRAL)
		{
			return false;
		}
		if (key == this.getKeyCodeUp || key == this.getKeyCodeUpAlt)
		{
			return dir == TouchStick.StickDir.U || dir == TouchStick.StickDir.UL || dir == TouchStick.StickDir.UR;
		}
		if (key == this.getKeyCodeDown || key == this.getKeyCodeDownAlt)
		{
			return dir == TouchStick.StickDir.D || dir == TouchStick.StickDir.DL || dir == TouchStick.StickDir.DR;
		}
		if (key == this.getKeyCodeLeft || key == this.getKeyCodeLeftAlt)
		{
			return dir == TouchStick.StickDir.L || dir == TouchStick.StickDir.DL || dir == TouchStick.StickDir.UL;
		}
		return (key == this.getKeyCodeRight || key == this.getKeyCodeRightAlt) && (dir == TouchStick.StickDir.R || dir == TouchStick.StickDir.DR || dir == TouchStick.StickDir.UR);
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x00037B72 File Offset: 0x00035F72
	public void SetDynamicMode(bool dynamicMode)
	{
		if (this.dynamicMode != dynamicMode)
		{
			this.dynamicMode = dynamicMode;
			this.joy.SetLayoutDirtyFlag();
		}
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x00037B94 File Offset: 0x00035F94
	public override void Enable(bool skipAnimation)
	{
		this.enabled = true;
		this.AnimateParams((!this.overrideScale) ? this.joy.releasedStickHatScale : this.releasedHatScale, (!this.overrideScale) ? this.joy.releasedStickBaseScale : this.releasedBaseScale, (!this.overrideColors) ? this.joy.defaultReleasedStickHatColor : this.releasedHatColor, (!this.overrideColors) ? this.joy.defaultReleasedStickBaseColor : this.releasedBaseColor, (float)((!this.dynamicMode) ? 1 : 0), (!skipAnimation) ? ((!this.overrideAnimDuration) ? this.joy.enableAnimDuration : this.enableAnimDuration) : 0f);
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x00037C78 File Offset: 0x00036078
	public override void Disable(bool skipAnimation)
	{
		this.enabled = false;
		this.ReleaseTouches();
		this.AnimateParams((!this.overrideScale) ? this.joy.disabledStickHatScale : this.disabledHatScale, (!this.overrideScale) ? this.joy.disabledStickBaseScale : this.disabledBaseScale, (!this.overrideColors) ? this.joy.defaultDisabledStickHatColor : this.disabledHatColor, (!this.overrideColors) ? this.joy.defaultDisabledStickBaseColor : this.disabledBaseColor, (float)((!this.dynamicMode) ? 1 : 0), (!skipAnimation) ? ((!this.overrideAnimDuration) ? this.joy.disableAnimDuration : this.disableAnimDuration) : 0f);
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x00037D60 File Offset: 0x00036160
	public override void Show(bool skipAnim)
	{
		this.visible = true;
		this.AnimateParams((!this.overrideScale) ? ((!this.enabled) ? this.joy.disabledStickHatScale : this.joy.releasedStickHatScale) : ((!this.enabled) ? this.disabledHatScale : this.releasedHatScale), (!this.overrideScale) ? ((!this.enabled) ? this.joy.disabledStickBaseScale : this.joy.releasedStickBaseScale) : ((!this.enabled) ? this.disabledBaseScale : this.releasedBaseScale), (!this.overrideColors) ? ((!this.enabled) ? this.joy.defaultDisabledStickHatColor : this.joy.defaultReleasedStickHatColor) : ((!this.enabled) ? this.disabledHatColor : this.releasedHatColor), (!this.overrideColors) ? ((!this.enabled) ? this.joy.defaultDisabledStickBaseColor : this.joy.defaultReleasedStickBaseColor) : ((!this.enabled) ? this.disabledBaseColor : this.releasedBaseColor), (float)((!this.dynamicMode) ? 1 : ((!this.Pressed()) ? 0 : 1)), (!skipAnim) ? ((!this.overrideAnimDuration) ? this.joy.showAnimDuration : this.showAnimDuration) : 0f);
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00037F18 File Offset: 0x00036318
	public override void Hide(bool skipAnim)
	{
		this.visible = false;
		this.ReleaseTouches();
		Color end = this.animHatColor.end;
		Color end2 = this.animBaseColor.end;
		this.AnimateParams(this.animHatScale.end, this.animBaseScale.end, end, end2, 0f, (!skipAnim) ? ((!this.overrideAnimDuration) ? this.joy.hideAnimDuration : this.hideAnimDuration) : 0f);
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x00037FA0 File Offset: 0x000363A0
	public void SetRect(Rect r)
	{
		Vector2 center = r.center;
		float num = Mathf.Min(r.width, r.height) / 2f;
		if (!this.dynamicMode && (this.posPx != center || this.radPx != num))
		{
			this.posPx = center;
			this.radPx = num;
			this.OnReset();
		}
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x0003800B File Offset: 0x0003640B
	public override void ResetRect()
	{
		if (!this.dynamicMode)
		{
			this.posPx = this.layoutPosPx;
			this.radPx = this.layoutRadPx;
		}
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x00038030 File Offset: 0x00036430
	public Rect GetRect(bool getAutoRect)
	{
		return TouchController.GetCenRect((!getAutoRect) ? this.posPx : this.layoutPosPx, ((!getAutoRect) ? this.radPx : this.layoutRadPx) * 2f);
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x0003806B File Offset: 0x0003646B
	public Rect GetRect()
	{
		return this.GetRect(false);
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x00038074 File Offset: 0x00036474
	public Vector2 GetScreenPos()
	{
		return this.posPx;
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x0003807C File Offset: 0x0003647C
	public float GetScreenRad()
	{
		return this.radPx;
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x00038084 File Offset: 0x00036484
	public Rect GetHatDisplayRect(bool applyScale)
	{
		return TouchController.GetCenRect(this.posPx + TouchStick.InternalToScreenPos(this.displayPos) * this.radPx * this.hatMoveScale, 2f * this.radPx * ((!applyScale) ? 1f : this.animHatScale.cur));
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x000380EA File Offset: 0x000364EA
	public Rect GetHatDisplayRect()
	{
		return this.GetHatDisplayRect(true);
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x000380F3 File Offset: 0x000364F3
	public Rect GetBaseDisplayRect(bool applyScale = true)
	{
		return TouchController.GetCenRect(this.posPx, this.radPx * 2f * ((!applyScale) ? 1f : this.animBaseScale.cur));
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x00038128 File Offset: 0x00036528
	public Rect GetBaseDisplayRect()
	{
		return this.GetBaseDisplayRect(true);
	}

	// Token: 0x060008B4 RID: 2228 RVA: 0x00038131 File Offset: 0x00036531
	public Color GetHatColor()
	{
		return this.animHatColor.cur;
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x0003813E File Offset: 0x0003653E
	public Color GetBaseColor()
	{
		return this.animBaseColor.cur;
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x0003814B File Offset: 0x0003654B
	public int GetGUIDepth()
	{
		return this.joy.guiDepth + this.guiDepth + ((!this.Pressed()) ? 0 : this.joy.guiPressedOfs);
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x0003817C File Offset: 0x0003657C
	public Texture2D GetBaseDisplayTex()
	{
		return (!this.enabled || !this.Pressed()) ? this.releasedBaseImg : this.pressedBaseImg;
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x000381A5 File Offset: 0x000365A5
	public Texture2D GetHatDisplayTex()
	{
		return (!this.enabled || !this.Pressed()) ? this.releasedHatImg : this.pressedHatImg;
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x000381CE File Offset: 0x000365CE
	public static bool IsDiagonalAxis(TouchStick.StickDir dir)
	{
		return (dir - TouchStick.StickDir.U & 1) == 1;
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x000381D8 File Offset: 0x000365D8
	public static float GetDirCodeAngle(TouchStick.StickDir d)
	{
		if (d < TouchStick.StickDir.U || d > TouchStick.StickDir.UL)
		{
			return 0f;
		}
		return (float)(d - TouchStick.StickDir.U) * 45f;
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x000381F8 File Offset: 0x000365F8
	public static TouchStick.StickDir GetDirCodeFromAngle(float ang, bool as8way)
	{
		ang += ((!as8way) ? 45f : 22.5f);
		ang = TouchStick.NormalizeAnglePositive(ang);
		if (as8way)
		{
			if (ang < 45f)
			{
				return TouchStick.StickDir.U;
			}
			if (ang < 90f)
			{
				return TouchStick.StickDir.UR;
			}
			if (ang < 135f)
			{
				return TouchStick.StickDir.R;
			}
			if (ang < 180f)
			{
				return TouchStick.StickDir.DR;
			}
			if (ang < 225f)
			{
				return TouchStick.StickDir.D;
			}
			if (ang < 270f)
			{
				return TouchStick.StickDir.DL;
			}
			if (ang < 315f)
			{
				return TouchStick.StickDir.L;
			}
			return TouchStick.StickDir.UL;
		}
		else
		{
			if (ang < 90f)
			{
				return TouchStick.StickDir.U;
			}
			if (ang < 180f)
			{
				return TouchStick.StickDir.R;
			}
			if (ang < 270f)
			{
				return TouchStick.StickDir.D;
			}
			return TouchStick.StickDir.L;
		}
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x000382B4 File Offset: 0x000366B4
	private void AnimateParams(float hatScale, float baseScale, Color hatColor, Color baseColor, float alpha, float duration)
	{
		if (duration <= 0f)
		{
			this.animTimer.Reset(0f);
			this.animTimer.Disable();
			this.animHatColor.Reset(hatColor);
			this.animHatScale.Reset(hatScale);
			this.animBaseColor.Reset(baseColor);
			this.animBaseScale.Reset(baseScale);
			this.animAlpha.Reset(alpha);
			this.displayPosStart = (this.displayPos = ((!this.Pressed()) ? Vector2.zero : this.GetVecEx(this.stickVis)));
		}
		else
		{
			this.animTimer.Start(duration);
			this.animHatScale.MoveTo(hatScale);
			this.animHatColor.MoveTo(hatColor);
			this.animBaseScale.MoveTo(baseScale);
			this.animBaseColor.MoveTo(baseColor);
			this.animAlpha.MoveTo(alpha);
		}
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x000383A6 File Offset: 0x000367A6
	public override void Init(TouchController joy)
	{
		base.Init(joy);
		this.OnReset();
		if (this.initiallyDisabled)
		{
			this.Disable(true);
		}
		if (this.initiallyHidden)
		{
			this.Hide(true);
		}
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x000383DC File Offset: 0x000367DC
	public override void OnReset()
	{
		this.pressedCur = false;
		this.pressedPrev = false;
		this.touchId = -1;
		this.dir4way = TouchStick.StickDir.NEUTRAL;
		this.dir8way = TouchStick.StickDir.NEUTRAL;
		this.dir4wayLastNonNeutral = TouchStick.StickDir.NEUTRAL;
		this.dir8wayLastNonNeutral = TouchStick.StickDir.NEUTRAL;
		this.dir4wayPrev = TouchStick.StickDir.NEUTRAL;
		this.dir8wayPrev = TouchStick.StickDir.NEUTRAL;
		this.touchCanceled = false;
		this.SetInternalPos(Vector2.zero);
		this.tilt = 0f;
		this.dirVec = Vector2.zero;
		this.posRaw = Vector2.zero;
		this.displayPos = Vector2.zero;
		this.displayPosStart = Vector2.zero;
		this.AnimateParams((!this.overrideScale) ? this.joy.releasedStickHatScale : this.releasedHatScale, (!this.overrideScale) ? this.joy.releasedStickBaseScale : this.releasedBaseScale, (!this.overrideColors) ? this.joy.defaultReleasedStickHatColor : this.releasedHatColor, (!this.overrideColors) ? this.joy.defaultReleasedStickBaseColor : this.releasedBaseColor, (float)((!this.dynamicMode) ? 1 : 0), 0f);
		if (!this.enabled)
		{
			this.Disable(true);
		}
		if (!this.visible)
		{
			this.Hide(true);
		}
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x00038537 File Offset: 0x00036937
	public static Vector2 InternalToScreenPos(Vector2 internalStickPos)
	{
		internalStickPos.y = -internalStickPos.y;
		return internalStickPos;
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x00038549 File Offset: 0x00036949
	private void SetPollPos(Vector2 pos, bool screenPos)
	{
		if (screenPos)
		{
			pos = (pos - this.posPx) / this.radPx;
			pos.y = -pos.y;
		}
		this.pollPos = pos;
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x00038580 File Offset: 0x00036980
	private void SetInternalPos(Vector2 pos)
	{
		this.pollPos = pos;
		if (this.disableX)
		{
			pos.x = 0f;
		}
		if (this.disableY)
		{
			pos.y = 0f;
		}
		float num = Mathf.Clamp01(pos.magnitude);
		Vector2 normalized = this.dirVec;
		float num2 = this.safeAngle;
		if (num > 0.01f)
		{
			normalized = pos.normalized;
			num2 = Mathf.Atan2(normalized.x, normalized.y) * 57.29578f;
		}
		if (num > ((this.dir8way != TouchStick.StickDir.NEUTRAL) ? this.joy.stickDigitalLeaveThresh : this.joy.stickDigitalEnterThresh))
		{
			if (this.dir8wayLastNonNeutral == TouchStick.StickDir.NEUTRAL)
			{
				this.dir4way = TouchStick.GetDirCodeFromAngle(num2, false);
				this.dir8way = TouchStick.GetDirCodeFromAngle(num2, true);
			}
			else if (num > this.joy.stickDigitalEnterThresh)
			{
				float dirCodeAngle = TouchStick.GetDirCodeAngle(this.dir8wayLastNonNeutral);
				if (Mathf.Abs(Mathf.DeltaAngle(dirCodeAngle, num2)) > 22.5f + this.joy.stickMagnetAngleMargin)
				{
					this.dir8way = TouchStick.GetDirCodeFromAngle(num2, true);
				}
				else
				{
					this.dir8way = this.dir8wayLastNonNeutral;
				}
				float dirCodeAngle2 = TouchStick.GetDirCodeAngle(this.dir4wayLastNonNeutral);
				if (Mathf.Abs(Mathf.DeltaAngle(dirCodeAngle2, num2)) > 45f + this.joy.stickMagnetAngleMargin)
				{
					this.dir4way = TouchStick.GetDirCodeFromAngle(num2, false);
				}
				else
				{
					this.dir4way = this.dir4wayLastNonNeutral;
				}
			}
		}
		else
		{
			this.dir4way = TouchStick.StickDir.NEUTRAL;
			this.dir8way = TouchStick.StickDir.NEUTRAL;
		}
		if (this.dir4way != TouchStick.StickDir.NEUTRAL)
		{
			this.dir4wayLastNonNeutral = this.dir4way;
		}
		if (this.dir8way != TouchStick.StickDir.NEUTRAL)
		{
			this.dir8wayLastNonNeutral = this.dir8way;
		}
		this.tilt = num;
		this.angle = num2;
		this.safeAngle = num2;
		this.posRaw = normalized * num;
		this.dirVec = normalized;
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x00038775 File Offset: 0x00036B75
	public override void OnPrePoll()
	{
		this.touchVerified = false;
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x0003877E File Offset: 0x00036B7E
	public override void OnPostPoll()
	{
		if (!this.touchVerified && this.touchId >= 0)
		{
			this.OnTouchEnd(this.touchId, false);
		}
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x000387A5 File Offset: 0x00036BA5
	public override void ReleaseTouches()
	{
		if (this.touchId >= 0)
		{
			this.OnTouchEnd(this.touchId, true);
		}
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x000387C1 File Offset: 0x00036BC1
	public override void TakeoverTouches(TouchableControl controlToUntouch)
	{
		if (controlToUntouch != null && this.touchId >= 0)
		{
			controlToUntouch.OnTouchEnd(this.touchId, true);
		}
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x000387E4 File Offset: 0x00036BE4
	public override void OnUpdate(bool firstUpdate)
	{
		this.dir8wayPrev = this.dir8way;
		this.dir4wayPrev = this.dir4way;
		this.pressedPrev = this.pressedCur;
		this.pressedCur = (this.touchId >= 0);
		this.SetInternalPos(this.pollPos);
		if (this.pressedCur)
		{
			this.displayPos = (this.displayPosStart = this.GetVecEx(this.stickVis));
		}
		else if (!this.smoothReturn)
		{
			this.displayPos = (this.displayPosStart = Vector2.zero);
		}
		if (this.pressedCur != this.pressedPrev && this.enabled)
		{
			if (this.pressedCur)
			{
				this.dynamicFadeOutAnimPending = false;
				this.AnimateParams((!this.overrideScale) ? this.joy.pressedStickHatScale : this.pressedHatScale, (!this.overrideScale) ? this.joy.pressedStickBaseScale : this.pressedBaseScale, (!this.overrideColors) ? this.joy.defaultPressedStickHatColor : this.pressedHatColor, (!this.overrideColors) ? this.joy.defaultPressedStickBaseColor : this.pressedBaseColor, 1f, (!this.overrideAnimDuration) ? this.joy.pressAnimDuration : this.pressAnimDuration);
			}
			else
			{
				this.dynamicFadeOutAnimPending = (this.dynamicMode && !this.touchCanceled);
				this.AnimateParams((!this.overrideScale) ? this.joy.releasedStickHatScale : this.releasedHatScale, (!this.overrideScale) ? this.joy.releasedStickBaseScale : this.releasedBaseScale, (!this.overrideColors) ? this.joy.defaultReleasedStickHatColor : this.releasedHatColor, (!this.overrideColors) ? this.joy.defaultReleasedStickBaseColor : this.releasedBaseColor, (!this.dynamicMode) ? 1f : ((!this.touchCanceled) ? this.animAlpha.cur : 0f), (!this.touchCanceled) ? ((!this.overrideAnimDuration) ? this.joy.releaseAnimDuration : this.releaseAnimDuration) : this.joy.cancelAnimDuration);
			}
		}
		if (this.animTimer.Enabled)
		{
			this.animTimer.Update(this.joy.deltaTime);
			float num = TouchController.SlowDownEase(this.animTimer.Nt);
			this.animAlpha.Update(num);
			this.animHatColor.Update(num);
			this.animHatScale.Update(num);
			this.animBaseColor.Update(num);
			this.animBaseScale.Update(num);
			if (this.smoothReturn && !this.Pressed())
			{
				this.displayPos = Vector2.Lerp(this.displayPosStart, Vector2.zero, num);
			}
			if (this.animTimer.Completed)
			{
				this.displayPosStart = this.displayPos;
				if (this.dynamicMode && this.dynamicFadeOutAnimPending)
				{
					this.dynamicFadeOutAnimPending = false;
					this.AnimateParams((!this.overrideScale) ? this.joy.releasedStickHatScale : this.releasedHatScale, (!this.overrideScale) ? this.joy.releasedStickBaseScale : this.releasedBaseScale, (!this.overrideColors) ? this.joy.defaultReleasedStickHatColor : this.releasedHatColor, (!this.overrideColors) ? this.joy.defaultReleasedStickBaseColor : this.releasedBaseColor, 0f, this.dynamicFadeOutDuration);
				}
				else
				{
					this.animTimer.Disable();
				}
			}
		}
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x00038BF8 File Offset: 0x00036FF8
	public override TouchController.HitTestResult HitTest(Vector2 pos, int touchId)
	{
		if (this.touchId >= 0 || !this.enabled || !this.visible)
		{
			return new TouchController.HitTestResult(false);
		}
		TouchController.HitTestResult result;
		if (this.dynamicMode)
		{
			if (!this.dynamicAlwaysReset && this.dynamicVisible)
			{
				TouchController.HitTestResult hitTestResult;
				result = (hitTestResult = this.joy.HitTestCircle(this.posPx, this.radPx, pos, true));
				if (hitTestResult.hit)
				{
					result.prio = this.prio;
					this.dynamicResetPos = false;
					return result;
				}
			}
			this.dynamicResetPos = true;
			result = this.joy.HitTestRect(this.dynamicRegionPx, pos, true);
			result.prio = this.dynamicRegionPrio;
			result.distScale = this.hitDistScale;
			return result;
		}
		result = this.joy.HitTestCircle(this.posPx, this.radPx, pos, true);
		result.prio = this.prio;
		result.distScale = this.hitDistScale;
		return result;
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x00038CFC File Offset: 0x000370FC
	public override TouchController.EventResult OnTouchStart(int touchId, Vector2 touchPos)
	{
		if (this.dynamicMode && this.dynamicResetPos)
		{
			float num = Mathf.Min(this.joy.GetScreenHeight(), this.joy.GetScreenWidth());
			if (this.dynamicClamp)
			{
				float num2 = this.radPx + this.dynamicMarginCm * this.joy.GetDPCM();
				float num3 = (num - this.radPx * 2f) / 2f;
				num2 = ((num3 > 0f) ? Mathf.Clamp(num2, 0f, num3) : 0f);
				this.posPx.x = Mathf.Clamp(touchPos.x, this.joy.GetScreenX(0f) + num2, this.joy.GetScreenX(1f) - num2);
				this.posPx.y = Mathf.Clamp(touchPos.y, this.joy.GetScreenY(0f) + num2, this.joy.GetScreenY(1f) - num2);
			}
			else
			{
				this.posPx = touchPos;
			}
		}
		this.touchCanceled = false;
		this.touchId = touchId;
		this.touchVerified = true;
		this.SetPollPos(touchPos, true);
		return TouchController.EventResult.HANDLED;
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x00038E37 File Offset: 0x00037237
	public override TouchController.EventResult OnTouchEnd(int touchId, bool cancelMode = false)
	{
		if (this.touchId != touchId)
		{
			return TouchController.EventResult.NOT_HANDLED;
		}
		if (this.dynamicMode)
		{
		}
		this.touchId = -1;
		this.touchVerified = true;
		this.touchCanceled = cancelMode;
		this.SetPollPos(Vector2.zero, false);
		return TouchController.EventResult.HANDLED;
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x00038E74 File Offset: 0x00037274
	public override TouchController.EventResult OnTouchMove(int touchId, Vector2 touchPos)
	{
		if (this.touchId != touchId)
		{
			return TouchController.EventResult.NOT_HANDLED;
		}
		this.touchVerified = true;
		this.SetPollPos(touchPos, true);
		return TouchController.EventResult.HANDLED;
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x00038E94 File Offset: 0x00037294
	public override void OnLayoutAddContent()
	{
		if (this.dynamicMode)
		{
			return;
		}
		this.joy.layoutBoxes[this.layoutBoxId].AddContent(this.posCm, this.sizeCm);
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x00038EC8 File Offset: 0x000372C8
	public override void OnLayout()
	{
		this.dynamicRegionPx = this.joy.NormalizedRectToPx(this.dynamicRegion, true);
		if (this.dynamicMode)
		{
			this.radPx = this.CalculateDynamicRad();
		}
		else
		{
			this.layoutPosPx = this.joy.layoutBoxes[this.layoutBoxId].GetScreenPos(this.posCm);
			this.layoutRadPx = this.joy.layoutBoxes[this.layoutBoxId].GetScreenSize(this.sizeCm / 2f);
			this.posPx = this.layoutPosPx;
			this.radPx = this.layoutRadPx;
		}
		this.OnReset();
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x00038F74 File Offset: 0x00037374
	public override void DrawGUI()
	{
		if (this.disableGui || this.joy.GetAlpha() * this.animAlpha.cur < 0.001f)
		{
			return;
		}
		GUI.color = Color.white;
		bool flag = this.Pressed();
		Color cur = this.animHatColor.cur;
		Color cur2 = this.animBaseColor.cur;
		Texture2D texture2D = (!flag) ? this.releasedHatImg : this.pressedHatImg;
		Texture2D texture2D2 = (!flag) ? this.releasedBaseImg : this.pressedBaseImg;
		GUI.depth = this.joy.guiDepth + this.guiDepth + ((!this.Pressed()) ? 0 : this.joy.guiPressedOfs);
		if (texture2D2 != null)
		{
			GUI.color = TouchController.ScaleAlpha(cur2, this.joy.GetAlpha() * this.animAlpha.cur);
			GUI.DrawTexture(this.GetBaseDisplayRect(true), texture2D2);
		}
		if (texture2D != null)
		{
			GUI.color = TouchController.ScaleAlpha(cur, this.joy.GetAlpha() * this.animAlpha.cur);
			GUI.DrawTexture(this.GetHatDisplayRect(true), texture2D);
		}
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x000390B4 File Offset: 0x000374B4
	private float CalculateDynamicRad()
	{
		float num = Mathf.Min(this.joy.GetScreenHeight(), this.joy.GetScreenWidth());
		return Mathf.Max(4f, 0.5f * Mathf.Min(this.sizeCm * this.joy.GetDPCM(), num * Mathf.Clamp(this.dynamicMaxRelativeSize, 0.01f, 1f)));
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x0003911C File Offset: 0x0003751C
	private static Vector2 RotateVec2(Vector2 pos, float ang)
	{
		float num = Mathf.Sin(-ang * 0.0174532924f);
		float num2 = Mathf.Cos(-ang * 0.0174532924f);
		return new Vector2(pos.x * num2 - pos.y * num, pos.x * num + pos.y * num2);
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x00039170 File Offset: 0x00037570
	private static float NormalizeAnglePositive(float a)
	{
		if (a >= 360f)
		{
			return Mathf.Repeat(a, 360f);
		}
		if (a >= 0f)
		{
			return a;
		}
		if (a <= -360f)
		{
			a = Mathf.Repeat(a, 360f);
		}
		return 360f + a;
	}

	// Token: 0x040007A4 RID: 1956
	private float safeAngle;

	// Token: 0x040007A5 RID: 1957
	public TouchStick.StickPosMode stickVis;

	// Token: 0x040007A6 RID: 1958
	public bool smoothReturn = true;

	// Token: 0x040007A7 RID: 1959
	public Vector2 posCm = new Vector2(2f, 5f);

	// Token: 0x040007A8 RID: 1960
	public float sizeCm = 2f;

	// Token: 0x040007A9 RID: 1961
	private Vector2 layoutPosPx;

	// Token: 0x040007AA RID: 1962
	private float layoutRadPx;

	// Token: 0x040007AB RID: 1963
	private Vector2 posPx = new Vector2(100f, 100f);

	// Token: 0x040007AC RID: 1964
	private float radPx = 40f;

	// Token: 0x040007AD RID: 1965
	public bool overrideAnimDuration;

	// Token: 0x040007AE RID: 1966
	public float pressAnimDuration;

	// Token: 0x040007AF RID: 1967
	public float releaseAnimDuration;

	// Token: 0x040007B0 RID: 1968
	public float disableAnimDuration;

	// Token: 0x040007B1 RID: 1969
	public float enableAnimDuration;

	// Token: 0x040007B2 RID: 1970
	public float hideAnimDuration;

	// Token: 0x040007B3 RID: 1971
	public float showAnimDuration;

	// Token: 0x040007B4 RID: 1972
	private AnimTimer animTimer;

	// Token: 0x040007B5 RID: 1973
	private TouchController.AnimFloat animHatScale;

	// Token: 0x040007B6 RID: 1974
	private TouchController.AnimFloat animBaseScale;

	// Token: 0x040007B7 RID: 1975
	private TouchController.AnimFloat animAlpha;

	// Token: 0x040007B8 RID: 1976
	private TouchController.AnimColor animHatColor;

	// Token: 0x040007B9 RID: 1977
	private TouchController.AnimColor animBaseColor;

	// Token: 0x040007BA RID: 1978
	private bool dynamicFadeOutAnimPending;

	// Token: 0x040007BB RID: 1979
	public bool keyboardEmu;

	// Token: 0x040007BC RID: 1980
	public KeyCode keyUp = KeyCode.W;

	// Token: 0x040007BD RID: 1981
	public KeyCode keyDown = KeyCode.S;

	// Token: 0x040007BE RID: 1982
	public KeyCode keyLeft = KeyCode.A;

	// Token: 0x040007BF RID: 1983
	public KeyCode keyRight = KeyCode.D;

	// Token: 0x040007C0 RID: 1984
	public bool dynamicMode;

	// Token: 0x040007C1 RID: 1985
	public int dynamicRegionPrio;

	// Token: 0x040007C2 RID: 1986
	public bool dynamicClamp;

	// Token: 0x040007C3 RID: 1987
	public float dynamicMaxRelativeSize = 0.2f;

	// Token: 0x040007C4 RID: 1988
	public float dynamicMarginCm = 0.5f;

	// Token: 0x040007C5 RID: 1989
	public float dynamicFadeOutDelay;

	// Token: 0x040007C6 RID: 1990
	public float dynamicFadeOutDuration = 2f;

	// Token: 0x040007C7 RID: 1991
	public Rect dynamicRegion = new Rect(0f, 0f, 0.5f, 1f);

	// Token: 0x040007C8 RID: 1992
	private Rect dynamicRegionPx = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x040007C9 RID: 1993
	public bool dynamicAlwaysReset;

	// Token: 0x040007CA RID: 1994
	private bool dynamicResetPos;

	// Token: 0x040007CB RID: 1995
	public float hatMoveScale = 0.5f;

	// Token: 0x040007CC RID: 1996
	public bool disableX;

	// Token: 0x040007CD RID: 1997
	public bool disableY;

	// Token: 0x040007CE RID: 1998
	private Vector2 touchStart;

	// Token: 0x040007CF RID: 1999
	private int touchId;

	// Token: 0x040007D0 RID: 2000
	private bool touchVerified;

	// Token: 0x040007D1 RID: 2001
	private Vector2 pollPos;

	// Token: 0x040007D2 RID: 2002
	private float angle;

	// Token: 0x040007D3 RID: 2003
	private Vector2 posRaw;

	// Token: 0x040007D4 RID: 2004
	private Vector2 dirVec;

	// Token: 0x040007D5 RID: 2005
	private float tilt;

	// Token: 0x040007D6 RID: 2006
	private Vector2 displayPosStart;

	// Token: 0x040007D7 RID: 2007
	private Vector2 displayPos;

	// Token: 0x040007D8 RID: 2008
	private TouchStick.StickDir dir8way;

	// Token: 0x040007D9 RID: 2009
	private TouchStick.StickDir dir4way;

	// Token: 0x040007DA RID: 2010
	private TouchStick.StickDir dir8wayPrev;

	// Token: 0x040007DB RID: 2011
	private TouchStick.StickDir dir4wayPrev;

	// Token: 0x040007DC RID: 2012
	private TouchStick.StickDir dir8wayLastNonNeutral;

	// Token: 0x040007DD RID: 2013
	private TouchStick.StickDir dir4wayLastNonNeutral;

	// Token: 0x040007DE RID: 2014
	private bool pressedCur;

	// Token: 0x040007DF RID: 2015
	private bool pressedPrev;

	// Token: 0x040007E0 RID: 2016
	public Texture2D releasedHatImg;

	// Token: 0x040007E1 RID: 2017
	public Texture2D releasedBaseImg;

	// Token: 0x040007E2 RID: 2018
	public Texture2D pressedHatImg;

	// Token: 0x040007E3 RID: 2019
	public Texture2D pressedBaseImg;

	// Token: 0x040007E4 RID: 2020
	public bool overrideScale;

	// Token: 0x040007E5 RID: 2021
	public float releasedHatScale = 1f;

	// Token: 0x040007E6 RID: 2022
	public float pressedHatScale = 1f;

	// Token: 0x040007E7 RID: 2023
	public float disabledHatScale = 1f;

	// Token: 0x040007E8 RID: 2024
	public float releasedBaseScale = 1f;

	// Token: 0x040007E9 RID: 2025
	public float pressedBaseScale = 1f;

	// Token: 0x040007EA RID: 2026
	public float disabledBaseScale = 1f;

	// Token: 0x040007EB RID: 2027
	public bool overrideColors;

	// Token: 0x040007EC RID: 2028
	public Color releasedHatColor;

	// Token: 0x040007ED RID: 2029
	public Color releasedBaseColor;

	// Token: 0x040007EE RID: 2030
	public Color pressedHatColor;

	// Token: 0x040007EF RID: 2031
	public Color pressedBaseColor;

	// Token: 0x040007F0 RID: 2032
	public Color disabledHatColor;

	// Token: 0x040007F1 RID: 2033
	public Color disabledBaseColor;

	// Token: 0x040007F2 RID: 2034
	private bool touchCanceled;

	// Token: 0x040007F3 RID: 2035
	public bool enableGetKey;

	// Token: 0x040007F4 RID: 2036
	public KeyCode getKeyCodePress;

	// Token: 0x040007F5 RID: 2037
	public KeyCode getKeyCodePressAlt;

	// Token: 0x040007F6 RID: 2038
	public KeyCode getKeyCodeUp;

	// Token: 0x040007F7 RID: 2039
	public KeyCode getKeyCodeUpAlt;

	// Token: 0x040007F8 RID: 2040
	public KeyCode getKeyCodeDown;

	// Token: 0x040007F9 RID: 2041
	public KeyCode getKeyCodeDownAlt;

	// Token: 0x040007FA RID: 2042
	public KeyCode getKeyCodeLeft;

	// Token: 0x040007FB RID: 2043
	public KeyCode getKeyCodeLeftAlt;

	// Token: 0x040007FC RID: 2044
	public KeyCode getKeyCodeRight;

	// Token: 0x040007FD RID: 2045
	public KeyCode getKeyCodeRightAlt;

	// Token: 0x040007FE RID: 2046
	public bool enableGetButton;

	// Token: 0x040007FF RID: 2047
	public string getButtonName;

	// Token: 0x04000800 RID: 2048
	public bool enableGetAxis;

	// Token: 0x04000801 RID: 2049
	public string axisHorzName;

	// Token: 0x04000802 RID: 2050
	public string axisVertName;

	// Token: 0x04000803 RID: 2051
	public bool axisHorzFlip;

	// Token: 0x04000804 RID: 2052
	public bool axisVertFlip;

	// Token: 0x04000805 RID: 2053
	public bool codeCustomGUI;

	// Token: 0x04000806 RID: 2054
	public bool codeCustomLayout;

	// Token: 0x04000807 RID: 2055
	private const TouchStick.StickDir StickDirFirst = TouchStick.StickDir.U;

	// Token: 0x04000808 RID: 2056
	private const TouchStick.StickDir StickDirLast = TouchStick.StickDir.UL;

	// Token: 0x02000136 RID: 310
	public enum StickPosMode
	{
		// Token: 0x0400080A RID: 2058
		FULL_ANALOG,
		// Token: 0x0400080B RID: 2059
		ANALOG_8WAY,
		// Token: 0x0400080C RID: 2060
		ANALOG_4WAY,
		// Token: 0x0400080D RID: 2061
		DIGITAL_8WAY,
		// Token: 0x0400080E RID: 2062
		DIGITAL_4WAY
	}

	// Token: 0x02000137 RID: 311
	public enum StickDir
	{
		// Token: 0x04000810 RID: 2064
		NEUTRAL,
		// Token: 0x04000811 RID: 2065
		U,
		// Token: 0x04000812 RID: 2066
		UR,
		// Token: 0x04000813 RID: 2067
		R,
		// Token: 0x04000814 RID: 2068
		DR,
		// Token: 0x04000815 RID: 2069
		D,
		// Token: 0x04000816 RID: 2070
		DL,
		// Token: 0x04000817 RID: 2071
		L,
		// Token: 0x04000818 RID: 2072
		UL
	}

	// Token: 0x02000138 RID: 312
	public enum Vec3DMode
	{
		// Token: 0x0400081A RID: 2074
		XZ,
		// Token: 0x0400081B RID: 2075
		XY
	}
}
