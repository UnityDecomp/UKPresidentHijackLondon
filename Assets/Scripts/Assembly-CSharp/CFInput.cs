using System;
using UnityEngine;

// Token: 0x02000127 RID: 295
public class CFInput
{
	// Token: 0x060007D8 RID: 2008 RVA: 0x00034369 File Offset: 0x00032769
	public static bool ControllerActive()
	{
		return CFInput.ctrl != null && CFInput.ctrl.enabled;
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x060007D9 RID: 2009 RVA: 0x00034388 File Offset: 0x00032788
	public static Vector3 mousePosition
	{
		get
		{
			if (CFInput.ControllerActive())
			{
				return CFInput.ctrl.GetMousePos();
			}
			return Input.mousePosition;
		}
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x000343AC File Offset: 0x000327AC
	public static bool GetKey(KeyCode key)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			bool keyEx = CFInput.ctrl.GetKeyEx(key, out flag);
			if (flag)
			{
				return keyEx;
			}
		}
		return Input.GetKey(key);
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000343E4 File Offset: 0x000327E4
	public static bool GetKeyDown(KeyCode key)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			bool keyDownEx = CFInput.ctrl.GetKeyDownEx(key, out flag);
			if (flag)
			{
				return keyDownEx;
			}
		}
		return Input.GetKeyDown(key);
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x0003441C File Offset: 0x0003281C
	public static bool GetKeyUp(KeyCode key)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			bool keyUpEx = CFInput.ctrl.GetKeyUpEx(key, out flag);
			if (flag)
			{
				return keyUpEx;
			}
		}
		return Input.GetKeyUp(key);
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x00034454 File Offset: 0x00032854
	public static bool GetButton(string axisName)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			bool buttonEx = CFInput.ctrl.GetButtonEx(axisName, out flag);
			if (flag)
			{
				return buttonEx;
			}
		}
		try
		{
			return Input.GetButton(axisName);
		}
		catch (UnityException)
		{
		}
		return false;
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x000344A8 File Offset: 0x000328A8
	public static bool GetButtonDown(string axisName)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			bool buttonDownEx = CFInput.ctrl.GetButtonDownEx(axisName, out flag);
			if (flag)
			{
				return buttonDownEx;
			}
		}
		try
		{
			return Input.GetButtonDown(axisName);
		}
		catch (UnityException)
		{
		}
		return false;
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x000344FC File Offset: 0x000328FC
	public static bool GetButtonUp(string axisName)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			bool buttonUpEx = CFInput.ctrl.GetButtonUpEx(axisName, out flag);
			if (flag)
			{
				return buttonUpEx;
			}
		}
		try
		{
			return Input.GetButtonUp(axisName);
		}
		catch (UnityException)
		{
		}
		return false;
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x00034550 File Offset: 0x00032950
	public static float GetAxis(string axisName)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			float axisEx = CFInput.ctrl.GetAxisEx(axisName, out flag);
			if (flag)
			{
				return axisEx;
			}
		}
		try
		{
			return Input.GetAxis(axisName);
		}
		catch (UnityException)
		{
		}
		return 0f;
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x000345A8 File Offset: 0x000329A8
	public static float GetAxisRaw(string axisName)
	{
		if (CFInput.ControllerActive())
		{
			bool flag = false;
			float axisEx = CFInput.ctrl.GetAxisEx(axisName, out flag);
			if (flag)
			{
				return axisEx;
			}
		}
		try
		{
			return Input.GetAxisRaw(axisName);
		}
		catch (UnityException)
		{
		}
		return 0f;
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x00034600 File Offset: 0x00032A00
	public static float GetAxisPx(string axisName, float refResolution = 1280f, float maxDragInches = 1f)
	{
		if (CFInput.ControllerActive() && TouchController.IsSupported())
		{
			float actualDPI = CFInput.ctrl.GetActualDPI();
			float axis = CFInput.GetAxis(axisName);
			return axis / (actualDPI * maxDragInches) * refResolution;
		}
		int width = Screen.currentResolution.width;
		return CFInput.GetAxis(axisName) * ((width != 0) ? (refResolution / (float)width) : 1f);
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x00034664 File Offset: 0x00032A64
	public static bool GetMouseButton(int i)
	{
		if (CFInput.ControllerActive())
		{
			return CFInput.ctrl.GetMouseButton(i);
		}
		return Input.GetMouseButton(i);
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x00034682 File Offset: 0x00032A82
	public static bool GetMouseButtonDown(int i)
	{
		if (CFInput.ControllerActive())
		{
			return CFInput.ctrl.GetMouseButtonDown(i);
		}
		return Input.GetMouseButtonDown(i);
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x000346A0 File Offset: 0x00032AA0
	public static bool GetMouseButtonUp(int i)
	{
		if (CFInput.ControllerActive())
		{
			return CFInput.ctrl.GetMouseButtonUp(i);
		}
		return Input.GetMouseButtonUp(i);
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x000346BE File Offset: 0x00032ABE
	public static void ResetInputAxes()
	{
		Input.ResetInputAxes();
		if (CFInput.ControllerActive())
		{
			CFInput.ctrl.ReleaseTouches();
		}
	}

	// Token: 0x040006E4 RID: 1764
	public static TouchController ctrl;
}
