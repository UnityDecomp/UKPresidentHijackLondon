using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000129 RID: 297
[ExecuteInEditMode]
[AddComponentMenu("ControlFreak/Control Freak Controller")]
public class TouchController : MonoBehaviour
{
	// Token: 0x06000805 RID: 2053 RVA: 0x00034BA0 File Offset: 0x00032FA0
	public void InitController()
	{
		this.contentDirtyFlag = false;
		this.firstPostPollUpdate = true;
		this.curTime = 0f;
		this.deltaTime = 0.0166666675f;
		this.invDeltaTime = 1f / this.deltaTime;
		this.lastRealTime = Time.realtimeSinceStartup;
		this.emuMousePos = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		if (this.sticks == null)
		{
			this.sticks = new TouchStick[0];
		}
		if (this.touchZones == null)
		{
			this.touchZones = new TouchZone[0];
		}
		if (this.touchables == null)
		{
			this.touchables = new List<TouchableControl>(16);
		}
		this.touchables.Clear();
		if (this.sticks != null)
		{
			foreach (TouchStick touchStick in this.sticks)
			{
				if (touchStick != null)
				{
					this.touchables.Add(touchStick);
				}
			}
		}
		if (this.touchZones != null)
		{
			foreach (TouchZone touchZone in this.touchZones)
			{
				if (touchZone != null)
				{
					this.touchables.Add(touchZone);
				}
			}
		}
		foreach (TouchableControl touchableControl in this.touchables)
		{
			touchableControl.Init(this);
		}
		if (!this.initialized)
		{
			this.StartAlphaAnim(1f, 0f);
		}
		this.Layout();
		this.initialized = true;
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x00034D5C File Offset: 0x0003315C
	public void PollController()
	{
		if (this.automaticMode)
		{
			return;
		}
		this.PollControllerInternal();
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x00034D70 File Offset: 0x00033170
	public void UpdateController()
	{
		if (this.automaticMode)
		{
			return;
		}
		this.UpdateControllerInternal();
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x00034D84 File Offset: 0x00033184
	public void DrawControllerGUI()
	{
		if (this.automaticMode && !this.manualGui)
		{
			return;
		}
		this.DrawControllerGUIInternal();
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x00034DA4 File Offset: 0x000331A4
	public void ResetController()
	{
		if (this.touchables != null)
		{
			for (int i = 0; i < this.touchables.Count; i++)
			{
				this.touchables[i].OnReset();
			}
		}
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x00034DEC File Offset: 0x000331EC
	public void ReleaseTouches()
	{
		foreach (TouchableControl touchableControl in this.touchables)
		{
			touchableControl.ReleaseTouches();
		}
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x00034E48 File Offset: 0x00033248
	public void ShowController(float animDuration)
	{
		this.StartAlphaAnim(1f, animDuration);
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x00034E56 File Offset: 0x00033256
	public void HideController(float animDuration)
	{
		this.StartAlphaAnim(0f, animDuration);
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x00034E64 File Offset: 0x00033264
	public float GetAlpha()
	{
		return this.globalAlpha;
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x00034E6C File Offset: 0x0003326C
	public void DisableController()
	{
		this.disableAll = true;
		this.ReleaseTouches();
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x00034E7B File Offset: 0x0003327B
	public void EnableController()
	{
		this.disableAll = false;
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x00034E84 File Offset: 0x00033284
	public bool ControllerEnabled()
	{
		return !this.disableAll;
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00034E8F File Offset: 0x0003328F
	public bool LayoutChanged()
	{
		return this.customLayoutNeedsRebuild;
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x00034E97 File Offset: 0x00033297
	public void LayoutChangeHandled()
	{
		this.customLayoutNeedsRebuild = false;
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x00034EA0 File Offset: 0x000332A0
	public void ResetAllRects()
	{
		foreach (TouchableControl touchableControl in this.touchables)
		{
			touchableControl.ResetRect();
		}
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x00034EFC File Offset: 0x000332FC
	public float GetDPI()
	{
		return this.GetActualDPI();
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x00034F04 File Offset: 0x00033304
	public float GetDPCM()
	{
		return this.GetDPI() / 2.54f;
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x00034F12 File Offset: 0x00033312
	public float GetActualDPI()
	{
		if (Screen.dpi != 0f)
		{
			return Screen.dpi;
		}
		return 96f;
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x00034F2E File Offset: 0x0003332E
	public Rect GetScreenEmuRect(bool viewportRect = false)
	{
		return new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x00034F4B File Offset: 0x0003334B
	public bool GetLeftHandedMode()
	{
		return this.leftHandedMode;
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x00034F53 File Offset: 0x00033353
	public void SetLeftHandedMode(bool enableLeftedHandMode)
	{
		if (this.leftHandedMode != enableLeftedHandMode)
		{
			this.leftHandedMode = enableLeftedHandMode;
			this.SetLayoutDirtyFlag();
		}
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x00034F6E File Offset: 0x0003336E
	public void ResetMaskAreas()
	{
		if (this.maskAreas == null)
		{
			this.maskAreas = new List<Rect>(8);
		}
		else
		{
			this.maskAreas.Clear();
		}
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x00034F97 File Offset: 0x00033397
	public void AddMaskArea(Rect r)
	{
		if (this.maskAreas == null)
		{
			this.maskAreas = new List<Rect>(8);
		}
		this.maskAreas.Add(r);
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x0600081C RID: 2076 RVA: 0x00034FBC File Offset: 0x000333BC
	public int StickCount
	{
		get
		{
			return this.sticks.Length;
		}
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x00034FC6 File Offset: 0x000333C6
	public int GetStickCount()
	{
		return this.sticks.Length;
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x00034FD0 File Offset: 0x000333D0
	public int GetStickId(string name)
	{
		return this.GetTouchableArrayElemId(this.sticks, name);
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x00034FDF File Offset: 0x000333DF
	public TouchStick GetStick(int id)
	{
		if (id < 0 || this.sticks == null || id >= this.sticks.Length)
		{
			return this.GetBlankStick();
		}
		return this.sticks[id];
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x00035010 File Offset: 0x00033410
	public TouchStick GetStick(string name)
	{
		return this.GetStick(this.GetStickId(name));
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x0003501F File Offset: 0x0003341F
	public TouchStick GetStickOrNull(int id)
	{
		if (id < 0 || this.sticks == null || id >= this.sticks.Length)
		{
			return null;
		}
		return this.sticks[id];
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x0003504B File Offset: 0x0003344B
	public TouchStick GetStickOrNull(string name)
	{
		return this.GetStickOrNull(this.GetStickId(name));
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x0003505C File Offset: 0x0003345C
	private TouchStick GetBlankStick()
	{
		if (this.blankStick != null)
		{
			return this.blankStick;
		}
		this.blankStick = new TouchStick();
		this.blankStick.Init(this);
		this.blankStick.OnReset();
		this.blankStick.name = "BLANK-STICK";
		return this.blankStick;
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x06000824 RID: 2084 RVA: 0x000350B3 File Offset: 0x000334B3
	public int ZoneCount
	{
		get
		{
			return this.touchZones.Length;
		}
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x000350BD File Offset: 0x000334BD
	public int GetZoneCount()
	{
		return this.touchZones.Length;
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x000350C7 File Offset: 0x000334C7
	public int GetZoneId(string name)
	{
		return this.GetTouchableArrayElemId(this.touchZones, name);
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x000350D6 File Offset: 0x000334D6
	public TouchZone GetZone(int id)
	{
		if (id < 0 || this.touchZones == null || id >= this.touchZones.Length)
		{
			return this.GetBlankZone();
		}
		return this.touchZones[id];
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x00035107 File Offset: 0x00033507
	public TouchZone GetZone(string name)
	{
		return this.GetZone(this.GetZoneId(name));
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x00035116 File Offset: 0x00033516
	public TouchZone GetZoneOrNull(int id)
	{
		if (id < 0 || this.touchZones == null || id >= this.touchZones.Length)
		{
			return null;
		}
		return this.touchZones[id];
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x00035142 File Offset: 0x00033542
	public TouchZone GetZoneOrNull(string name)
	{
		return this.GetZoneOrNull(this.GetZoneId(name));
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x00035154 File Offset: 0x00033554
	private TouchZone GetBlankZone()
	{
		if (this.blankZone != null)
		{
			return this.blankZone;
		}
		this.blankZone = new TouchZone();
		this.blankZone.Init(this);
		this.blankZone.OnReset();
		this.blankZone.name = "NULL";
		return this.blankZone;
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x0600082C RID: 2092 RVA: 0x000351AB File Offset: 0x000335AB
	public int ControlCount
	{
		get
		{
			return (this.touchables != null) ? this.touchables.Count : 0;
		}
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x000351C9 File Offset: 0x000335C9
	public int GetControlCount()
	{
		return (this.touchables != null) ? this.touchables.Count : 0;
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x000351E7 File Offset: 0x000335E7
	public TouchableControl GetControl(int id)
	{
		if (id < 0 || this.touchables == null || id >= this.touchables.Count)
		{
			return null;
		}
		return this.touchables[id];
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x0003521C File Offset: 0x0003361C
	public float GetAxisEx(string name, out bool axisSupported)
	{
		axisSupported = false;
		float num = 0f;
		for (int i = 0; i < this.sticks.Length; i++)
		{
			bool flag = false;
			float axisEx = this.sticks[i].GetAxisEx(name, out flag);
			if (flag)
			{
				axisSupported = true;
				num += axisEx;
			}
		}
		for (int j = 0; j < this.touchZones.Length; j++)
		{
			bool flag2 = false;
			float axisEx2 = this.touchZones[j].GetAxisEx(name, out flag2);
			if (flag2)
			{
				axisSupported = true;
				num += axisEx2;
			}
		}
		return num;
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x000352B0 File Offset: 0x000336B0
	public float GetAxis(string name)
	{
		bool flag = false;
		return this.GetAxisEx(name, out flag);
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x000352C8 File Offset: 0x000336C8
	public float GetAxisRaw(string name)
	{
		return this.GetAxis(name);
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x000352D4 File Offset: 0x000336D4
	public bool GetButton(string buttonName)
	{
		bool flag = false;
		return this.GetButtonEx(buttonName, out flag);
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x000352EC File Offset: 0x000336EC
	public bool GetButtonDown(string buttonName)
	{
		bool flag = false;
		return this.GetButtonDownEx(buttonName, out flag);
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x00035304 File Offset: 0x00033704
	public bool GetButtonUp(string buttonName)
	{
		bool flag = false;
		return this.GetButtonUpEx(buttonName, out flag);
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0003531C File Offset: 0x0003371C
	public bool GetButtonEx(string buttonName, out bool buttonSupported)
	{
		buttonSupported = false;
		for (int i = 0; i < this.sticks.Length; i++)
		{
			bool flag = false;
			bool buttonEx = this.sticks[i].GetButtonEx(buttonName, out flag);
			if (flag)
			{
				buttonSupported = true;
			}
			if (buttonEx)
			{
				return true;
			}
		}
		for (int j = 0; j < this.touchZones.Length; j++)
		{
			bool flag2 = false;
			bool buttonEx2 = this.touchZones[j].GetButtonEx(buttonName, out flag2);
			if (flag2)
			{
				buttonSupported = true;
			}
			if (buttonEx2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x000353AC File Offset: 0x000337AC
	public bool GetButtonDownEx(string buttonName, out bool buttonSupported)
	{
		buttonSupported = false;
		for (int i = 0; i < this.sticks.Length; i++)
		{
			bool flag = false;
			bool buttonDownEx = this.sticks[i].GetButtonDownEx(buttonName, out flag);
			if (flag)
			{
				buttonSupported = true;
			}
			if (buttonDownEx)
			{
				return true;
			}
		}
		for (int j = 0; j < this.touchZones.Length; j++)
		{
			bool flag2 = false;
			bool buttonDownEx2 = this.touchZones[j].GetButtonDownEx(buttonName, out flag2);
			if (flag2)
			{
				buttonSupported = true;
			}
			if (buttonDownEx2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x0003543C File Offset: 0x0003383C
	public bool GetButtonUpEx(string buttonName, out bool buttonSupported)
	{
		buttonSupported = false;
		for (int i = 0; i < this.sticks.Length; i++)
		{
			bool flag = false;
			bool buttonUpEx = this.sticks[i].GetButtonUpEx(buttonName, out flag);
			if (flag)
			{
				buttonSupported = true;
			}
			if (buttonUpEx)
			{
				return true;
			}
		}
		for (int j = 0; j < this.touchZones.Length; j++)
		{
			bool flag2 = false;
			bool buttonUpEx2 = this.touchZones[j].GetButtonUpEx(buttonName, out flag2);
			if (flag2)
			{
				buttonSupported = true;
			}
			if (buttonUpEx2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x000354CC File Offset: 0x000338CC
	public bool GetKey(KeyCode keyCode)
	{
		bool flag = false;
		return this.GetKeyEx(keyCode, out flag);
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x000354E4 File Offset: 0x000338E4
	public bool GetKeyDown(KeyCode keyCode)
	{
		bool flag = false;
		return this.GetKeyDownEx(keyCode, out flag);
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x000354FC File Offset: 0x000338FC
	public bool GetKeyUp(KeyCode keyCode)
	{
		bool flag = false;
		return this.GetKeyUpEx(keyCode, out flag);
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x00035514 File Offset: 0x00033914
	public bool GetKeyEx(KeyCode keyCode, out bool keySupported)
	{
		keySupported = false;
		for (int i = 0; i < this.sticks.Length; i++)
		{
			bool flag = false;
			bool keyEx = this.sticks[i].GetKeyEx(keyCode, out flag);
			if (flag)
			{
				keySupported = true;
			}
			if (keyEx)
			{
				return true;
			}
		}
		for (int j = 0; j < this.touchZones.Length; j++)
		{
			bool flag2 = false;
			bool keyEx2 = this.touchZones[j].GetKeyEx(keyCode, out flag2);
			if (flag2)
			{
				keySupported = true;
			}
			if (keyEx2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x000355A4 File Offset: 0x000339A4
	public bool GetKeyDownEx(KeyCode keyCode, out bool keySupported)
	{
		keySupported = false;
		for (int i = 0; i < this.sticks.Length; i++)
		{
			bool flag = false;
			bool keyDownEx = this.sticks[i].GetKeyDownEx(keyCode, out flag);
			if (flag)
			{
				keySupported = true;
			}
			if (keyDownEx)
			{
				return true;
			}
		}
		for (int j = 0; j < this.touchZones.Length; j++)
		{
			bool flag2 = false;
			bool keyDownEx2 = this.touchZones[j].GetKeyDownEx(keyCode, out flag2);
			if (flag2)
			{
				keySupported = true;
			}
			if (keyDownEx2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x00035634 File Offset: 0x00033A34
	public bool GetKeyUpEx(KeyCode keyCode, out bool keySupported)
	{
		keySupported = false;
		for (int i = 0; i < this.sticks.Length; i++)
		{
			bool flag = false;
			bool keyUpEx = this.sticks[i].GetKeyUpEx(keyCode, out flag);
			if (flag)
			{
				keySupported = true;
			}
			if (keyUpEx)
			{
				return true;
			}
		}
		for (int j = 0; j < this.touchZones.Length; j++)
		{
			bool flag2 = false;
			bool keyUpEx2 = this.touchZones[j].GetKeyUpEx(keyCode, out flag2);
			if (flag2)
			{
				keySupported = true;
			}
			if (keyUpEx2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x000356C3 File Offset: 0x00033AC3
	public bool GetMouseButton(int i)
	{
		return this.GetKey((i != 0) ? ((i != 1) ? ((i != 2) ? KeyCode.None : KeyCode.Mouse2) : KeyCode.Mouse1) : KeyCode.Mouse0);
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x000356FE File Offset: 0x00033AFE
	public bool GetMouseButtonDown(int i)
	{
		return this.GetKeyDown((i != 0) ? ((i != 1) ? ((i != 2) ? KeyCode.None : KeyCode.Mouse2) : KeyCode.Mouse1) : KeyCode.Mouse0);
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x00035739 File Offset: 0x00033B39
	public bool GetMouseButtonUp(int i)
	{
		return this.GetKeyUp((i != 0) ? ((i != 1) ? ((i != 2) ? KeyCode.None : KeyCode.Mouse2) : KeyCode.Mouse1) : KeyCode.Mouse0);
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x00035774 File Offset: 0x00033B74
	public Vector2 GetMousePos()
	{
		return this.emuMousePos;
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x0003577C File Offset: 0x00033B7C
	public static Collider PickCollider(Vector2 screenPos, Camera cam, LayerMask layerMask)
	{
		Ray ray = cam.ScreenPointToRay(new Vector3(screenPos.x, (float)Screen.height - screenPos.y, 0f));
		float radius = 0.1f;
		RaycastHit raycastHit;
		if (!Physics.SphereCast(ray, radius, out raycastHit, float.PositiveInfinity, layerMask))
		{
			return null;
		}
		return raycastHit.collider;
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x000357D7 File Offset: 0x00033BD7
	private void InitIfNeeded()
	{
		if (!this.initialized || this.contentDirtyFlag)
		{
			this.InitController();
		}
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x000357F5 File Offset: 0x00033BF5
	private void OnEnable()
	{
		this.InitIfNeeded();
		this.ResetLayoutBoxes();
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x00035803 File Offset: 0x00033C03
	public static bool IsSupported()
	{
		return (SystemInfo.deviceType == DeviceType.Handheld && Input.multiTouchEnabled) || Application.platform == RuntimePlatform.IPhonePlayer;
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00035825 File Offset: 0x00033C25
	private void Awake()
	{
		this.InitIfNeeded();
		if (this.disableWhenNoTouchScreen && !TouchController.IsSupported())
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x00035849 File Offset: 0x00033C49
	private void OnDestroy()
	{
		if (CFInput.ctrl == this)
		{
			CFInput.ctrl = null;
		}
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x00035861 File Offset: 0x00033C61
	private void Start()
	{
		if (this.automaticMode && !this.initialized)
		{
			this.InitController();
		}
		if (this.autoActivate)
		{
			CFInput.ctrl = this;
		}
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x00035890 File Offset: 0x00033C90
	private void Update()
	{
		this.InitIfNeeded();
		if (this.automaticMode)
		{
			this.PollControllerInternal();
			this.UpdateControllerInternal();
		}
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x000358AF File Offset: 0x00033CAF
	private void OnGUI()
	{
		if (this.automaticMode && !this.manualGui)
		{
			this.DrawControllerGUIInternal();
		}
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x000358CD File Offset: 0x00033CCD
	private void OnApplicationPause(bool pause)
	{
		this.releaseTouchesFlag = true;
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x000358D6 File Offset: 0x00033CD6
	public void SetLayoutDirtyFlag()
	{
		this.layoutDirtyFlag = true;
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000358DF File Offset: 0x00033CDF
	public void SetContentDirtyFlag()
	{
		this.contentDirtyFlag = true;
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x000358E8 File Offset: 0x00033CE8
	private void LayoutIfDirty()
	{
		if (this.layoutDirtyFlag || Screen.width != this.screenWidth || Screen.height != this.screenHeight)
		{
			this.Layout();
		}
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x0003591C File Offset: 0x00033D1C
	private int GetTouchableArrayElemId(TouchableControl[] carr, string name)
	{
		if (carr == null)
		{
			return -1;
		}
		for (int i = 0; i < carr.Length; i++)
		{
			if (name.Equals(carr[i].name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x0003595C File Offset: 0x00033D5C
	private void Layout()
	{
		this.customLayoutNeedsRebuild = true;
		this.releaseTouchesFlag = true;
		this.layoutDirtyFlag = false;
		this.screenWidth = Screen.width;
		this.screenHeight = Screen.height;
		this.fingerBufferRadPx = Mathf.Max(1f, 0.5f * (this.fingerBufferCm * this.GetDPCM()));
		this.touchTapMaxDistPx = Mathf.Clamp(this.touchTapMaxDistCm * this.GetDPCM(), 1f, Mathf.Min(this.GetScreenWidth(), this.GetScreenHeight()) * 0.3f);
		this.pinchMinDistPx = Mathf.Clamp(this.pinchMinDistCm * this.GetDPCM(), 1f, Mathf.Min(this.GetScreenWidth(), this.GetScreenHeight()) * 0.3f);
		this.twistSafeFingerDistPx = Mathf.Clamp(this.twistSafeFingerDistCm * this.GetDPCM(), 1f, Mathf.Min(this.GetScreenWidth(), this.GetScreenHeight()) * 0.3f);
		this.ResetLayoutBoxes();
		foreach (TouchableControl touchableControl in this.touchables)
		{
			touchableControl.OnLayoutAddContent();
		}
		foreach (TouchController.LayoutBox layoutBox in this.layoutBoxes)
		{
			layoutBox.ContentFinalize();
		}
		if (this.touchables != null)
		{
			foreach (TouchableControl touchableControl2 in this.touchables)
			{
				touchableControl2.OnLayout();
			}
		}
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x00035B2C File Offset: 0x00033F2C
	private void ResetLayoutBoxes()
	{
		if (this.layoutBoxes == null || this.layoutBoxes.Length != 16 || this.layoutBoxes[0] == null)
		{
			this.layoutBoxes = new TouchController.LayoutBox[16];
			for (int i = 0; i < this.layoutBoxes.Length; i++)
			{
				switch (i)
				{
				case 0:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Full-Screen", 0f, 0f, 1f, 1f, TouchController.LayoutAnchor.TOP_LEFT);
					break;
				case 1:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Right-Half", 0.5f, 0f, 0.5f, 1f, TouchController.LayoutAnchor.MID_RIGHT);
					break;
				case 2:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Left-Half", 0f, 0f, 0.5f, 1f, TouchController.LayoutAnchor.MID_LEFT);
					break;
				case 3:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Top-Half", 0f, 0f, 1f, 0.5f, TouchController.LayoutAnchor.TOP_CENTER);
					break;
				case 4:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Bottom-Half", 0f, 0.5f, 1f, 0.5f, TouchController.LayoutAnchor.BOTTOM_CENTER);
					break;
				case 5:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Bottom-Right-Qrtr", 0.5f, 0.5f, 0.5f, 0.5f, TouchController.LayoutAnchor.BOTTOM_RIGHT);
					break;
				case 6:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Bottom-Left-Qrtr", 0f, 0.5f, 0.5f, 0.5f, TouchController.LayoutAnchor.BOTTOM_LEFT);
					break;
				case 7:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Top-Right-Qrtr", 0.5f, 0f, 0.5f, 0.5f, TouchController.LayoutAnchor.TOP_RIGHT);
					break;
				case 8:
					this.layoutBoxes[i] = new TouchController.LayoutBox("Top-Left-Qrtr", 0f, 0f, 0.5f, 0.5f, TouchController.LayoutAnchor.TOP_LEFT);
					break;
				default:
					this.layoutBoxes[i] = new TouchController.LayoutBox("User" + i.ToString("00"), 0f, 0f, 1f, 1f, TouchController.LayoutAnchor.TOP_LEFT);
					break;
				}
			}
		}
		foreach (TouchController.LayoutBox layoutBox in this.layoutBoxes)
		{
			layoutBox.SetController(this);
			layoutBox.ResetContent();
		}
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x00035DAC File Offset: 0x000341AC
	private void PollControllerInternal()
	{
		this.firstPostPollUpdate = true;
		this.LayoutIfDirty();
		foreach (TouchableControl touchableControl in this.touchables)
		{
			touchableControl.OnPrePoll();
		}
		if (this.releaseTouchesFlag)
		{
			foreach (TouchableControl touchableControl2 in this.touchables)
			{
				touchableControl2.ReleaseTouches();
			}
			this.releaseTouchesFlag = false;
		}
		int touchCount = Input.touchCount;
		int i = 0;
		while (i < touchCount)
		{
			Vector2 zero = Vector2.zero;
			Touch touch = Input.GetTouch(i);
			TouchPhase phase = touch.phase;
			int fingerId = touch.fingerId;
			zero = new Vector2(touch.position.x, (float)Screen.height - touch.position.y);
			if (phase != TouchPhase.Began || this.maskAreas == null)
			{
				goto IL_166;
			}
			bool flag = false;
			for (int j = 0; j < this.maskAreas.Count; j++)
			{
				if (this.maskAreas[j].Contains(zero))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				goto IL_166;
			}
			IL_314:
			i++;
			continue;
			IL_166:
			switch (phase)
			{
			case TouchPhase.Began:
				if (this.disableAll)
				{
					goto IL_314;
				}
				for (int k = 0; k < 8; k++)
				{
					TouchableControl touchableControl3 = null;
					TouchController.HitTestResult r = new TouchController.HitTestResult(false);
					for (int l = 0; l < this.touchables.Count; l++)
					{
						if (k <= 0 || this.touchables[l].acceptSharedTouches)
						{
							if (touchableControl3 == null || r.prio <= this.touchables[l].prio)
							{
								TouchController.HitTestResult hitTestResult = this.touchables[l].HitTest(zero, fingerId);
								if (hitTestResult.hit)
								{
									if (touchableControl3 == null || hitTestResult.IsCloserThan(r))
									{
										touchableControl3 = this.touchables[l];
										r = hitTestResult;
									}
								}
							}
						}
					}
					if (touchableControl3 != null)
					{
						if (touchableControl3.OnTouchStart(fingerId, zero) != TouchController.EventResult.SHARED)
						{
							break;
						}
					}
				}
				goto IL_314;
			case TouchPhase.Moved:
			case TouchPhase.Stationary:
				for (int m = 0; m < this.touchables.Count; m++)
				{
					this.touchables[m].OnTouchMove(fingerId, zero);
				}
				goto IL_314;
			case TouchPhase.Ended:
			case TouchPhase.Canceled:
				for (int n = 0; n < this.touchables.Count; n++)
				{
					this.touchables[n].OnTouchEnd(fingerId, false);
				}
				goto IL_314;
			default:
				goto IL_314;
			}
		}
		foreach (TouchableControl touchableControl4 in this.touchables)
		{
			touchableControl4.OnPostPoll();
		}
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x00036148 File Offset: 0x00034548
	private void UpdateControllerInternal()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		this.deltaTime = realtimeSinceStartup - this.lastRealTime;
		if (this.deltaTime <= 0.0001f)
		{
			this.deltaTime = 0.0166666675f;
		}
		this.invDeltaTime = 1f / this.deltaTime;
		this.curTime += this.deltaTime;
		this.lastRealTime = realtimeSinceStartup;
		if (this.globalAlphaTimer.Enabled)
		{
			this.globalAlphaTimer.Update(this.deltaTime);
			this.globalAlpha = Mathf.Lerp(this.globalAlphaStart, this.globalAlphaEnd, this.globalAlphaTimer.Nt);
			if (this.globalAlphaTimer.Completed)
			{
				this.globalAlphaTimer.Disable();
			}
		}
		if (this.touchables != null)
		{
			foreach (TouchableControl touchableControl in this.touchables)
			{
				touchableControl.OnUpdate(this.firstPostPollUpdate);
			}
			foreach (TouchableControl touchableControl2 in this.touchables)
			{
				touchableControl2.OnPostUpdate(this.firstPostPollUpdate);
			}
		}
		this.firstPostPollUpdate = false;
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x000362C8 File Offset: 0x000346C8
	private void DrawControllerGUIInternal()
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}
		bool enabled = GUI.enabled;
		int depth = GUI.depth;
		GUI.depth = this.guiDepth;
		GUI.enabled = true;
		if (this.touchables != null)
		{
			for (int i = 0; i < this.touchables.Count; i++)
			{
				this.touchables[i].DrawGUI();
			}
		}
		GUI.depth = depth;
		if (GUI.enabled != enabled)
		{
			GUI.enabled = enabled;
		}
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x00036352 File Offset: 0x00034752
	public void SetInternalMousePos(Vector2 pos, bool inGuiSpace = true)
	{
		if (inGuiSpace)
		{
			pos.y = (float)Screen.height - pos.y;
		}
		this.emuMousePos = pos;
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x00036378 File Offset: 0x00034778
	private void StartAlphaAnim(float targetAlpha, float time)
	{
		if (time <= 0f)
		{
			this.globalAlphaTimer.Reset(0f);
			this.globalAlpha = targetAlpha;
			this.globalAlphaEnd = targetAlpha;
			this.globalAlphaStart = targetAlpha;
		}
		else
		{
			this.globalAlphaStart = this.globalAlpha;
			this.globalAlphaEnd = targetAlpha;
			this.globalAlphaTimer.Start(time);
		}
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x000363E0 File Offset: 0x000347E0
	public TouchController.HitTestResult HitTestCircle(Vector2 cen, float rad, Vector2 touchPos, bool useFingerBuffer = true)
	{
		TouchController.HitTestResult result = new TouchController.HitTestResult(false);
		result.dist = (touchPos - cen).magnitude;
		if (result.dist > rad + ((!useFingerBuffer) ? 0f : this.fingerBufferRadPx))
		{
			result.hit = false;
			return result;
		}
		result.hit = true;
		result.hitInside = (result.dist <= rad);
		result.distScale = 1f;
		return result;
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x00036464 File Offset: 0x00034864
	public TouchController.HitTestResult HitTestBox(Vector2 cen, Vector2 size, Vector2 touchPos, bool useFingerBuffer = true)
	{
		TouchController.HitTestResult result = new TouchController.HitTestResult(false);
		float num = (!useFingerBuffer) ? 0f : this.fingerBufferRadPx;
		Vector2 vector = new Vector2(Mathf.Abs(touchPos.x - cen.x), Mathf.Abs(touchPos.y - cen.y));
		size *= 0.5f;
		if (vector.x > size.x + num || vector.y > size.y + num)
		{
			result.hit = false;
			return result;
		}
		result.hit = true;
		result.hitInside = (vector.x <= size.x && vector.y <= size.y);
		result.dist = vector.magnitude;
		result.distScale = 1f;
		return result;
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x00036554 File Offset: 0x00034954
	public TouchController.HitTestResult HitTestRect(Rect rect, Vector2 touchPos, bool useFingerBuffer = true)
	{
		TouchController.HitTestResult result = new TouchController.HitTestResult(false);
		float num = (!useFingerBuffer) ? 0f : this.fingerBufferRadPx;
		Vector2 vector = touchPos - rect.center;
		vector.x = Mathf.Abs(vector.x);
		vector.y = Mathf.Abs(vector.y);
		Vector2 vector2 = new Vector2(rect.width * 0.5f, rect.height * 0.5f);
		if (vector.x > vector2.x + num || vector.y > vector2.y + num)
		{
			result.hit = false;
			return result;
		}
		result.hit = true;
		result.hitInside = (vector.x <= vector2.x && vector.y <= vector2.y);
		result.dist = vector.magnitude;
		result.distScale = 1f;
		return result;
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x0003665C File Offset: 0x00034A5C
	public void EndTouch(int touchId, TouchableControl ctrlToIgnore)
	{
		if (touchId < 0)
		{
			return;
		}
		foreach (TouchableControl touchableControl in this.touchables)
		{
			if (touchableControl != ctrlToIgnore)
			{
				touchableControl.OnTouchEnd(touchId, false);
			}
		}
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x000366D0 File Offset: 0x00034AD0
	public float GetScreenWidth()
	{
		return (float)Screen.width;
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x000366D8 File Offset: 0x00034AD8
	public float GetScreenHeight()
	{
		return (float)Screen.height;
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x000366E0 File Offset: 0x00034AE0
	public float GetScreenX(float xFactor)
	{
		return xFactor * (float)Screen.width;
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x000366EA File Offset: 0x00034AEA
	public float GetScreenY(float yFactor)
	{
		return yFactor * (float)Screen.height;
	}

	// Token: 0x0600085F RID: 2143 RVA: 0x000366F4 File Offset: 0x00034AF4
	public float CmToPixels(float cmVal)
	{
		return this.GetDPCM() * cmVal;
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x00036700 File Offset: 0x00034B00
	public float PixelsToWorld(float pxVal)
	{
		float num = (this.rwUnit != TouchController.RealWorldUnit.CM) ? this.GetDPI() : this.GetDPCM();
		if (num <= 1E-05f)
		{
			return 0f;
		}
		return pxVal / num;
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x00036740 File Offset: 0x00034B40
	public Rect NormalizedRectToPx(Rect nrect, bool respectLeftHandMode = true)
	{
		Rect rect = Rect.MinMaxRect(this.GetScreenX(nrect.xMin), this.GetScreenY(nrect.yMin), this.GetScreenX(nrect.xMax), this.GetScreenY(nrect.yMax));
		if (respectLeftHandMode)
		{
			return this.RightHandToScreenRect(rect);
		}
		return rect;
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x00036796 File Offset: 0x00034B96
	public float GetPreviewScale()
	{
		return 1f;
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x0003679D File Offset: 0x00034B9D
	public Vector2 RightHandToScreen(Vector2 pos)
	{
		if (!this.leftHandedMode)
		{
			return pos;
		}
		pos.x = (float)Screen.width - pos.x;
		return pos;
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x000367C4 File Offset: 0x00034BC4
	public Rect RightHandToScreenRect(Rect rect)
	{
		if (!this.leftHandedMode)
		{
			return rect;
		}
		Vector2 vector = this.RightHandToScreen(new Vector2(rect.xMin, rect.yMin));
		Vector2 vector2 = this.RightHandToScreen(new Vector2(rect.xMax, rect.yMax));
		return Rect.MinMaxRect(Mathf.Min(vector.x, vector2.x), Mathf.Min(vector.y, vector2.y), Mathf.Max(vector.x, vector2.x), Mathf.Max(vector.y, vector2.y));
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x00036864 File Offset: 0x00034C64
	private static Vector2 AnchorLeftover(Vector2 topLeftOfs, TouchController.LayoutAnchor anchor, float maxMarginX = 0f, float maxMarginY = 0f, bool uniformMargins = false)
	{
		float num = 0f;
		float num2 = 0f;
		if (topLeftOfs.x > 0f)
		{
			num = Mathf.Min(topLeftOfs.x, maxMarginX);
		}
		if (topLeftOfs.y > 0f)
		{
			num2 = Mathf.Min(topLeftOfs.y, maxMarginY);
		}
		if (uniformMargins && maxMarginX > 0.001f && maxMarginY > 0.001f)
		{
			float num3 = Mathf.Min(num / maxMarginX, num2 / maxMarginY);
			num = num3 * maxMarginX;
			num2 = num3 * maxMarginY;
		}
		switch (anchor)
		{
		case TouchController.LayoutAnchor.BOTTOM_LEFT:
			topLeftOfs.y -= num2;
			topLeftOfs.x = num;
			break;
		case TouchController.LayoutAnchor.BOTTOM_CENTER:
			topLeftOfs.y -= num2;
			topLeftOfs.x *= 0.5f;
			break;
		case TouchController.LayoutAnchor.BOTTOM_RIGHT:
			topLeftOfs.y -= num2;
			topLeftOfs.x -= num;
			break;
		case TouchController.LayoutAnchor.MID_LEFT:
			topLeftOfs.y *= 0.5f;
			topLeftOfs.x = num;
			break;
		case TouchController.LayoutAnchor.MID_CENTER:
			topLeftOfs.y *= 0.5f;
			topLeftOfs.x *= 0.5f;
			break;
		case TouchController.LayoutAnchor.MID_RIGHT:
			topLeftOfs.y *= 0.5f;
			topLeftOfs.x -= num;
			break;
		case TouchController.LayoutAnchor.TOP_LEFT:
			topLeftOfs.y = num2;
			topLeftOfs.x = num;
			break;
		case TouchController.LayoutAnchor.TOP_CENTER:
			topLeftOfs.y = num2;
			topLeftOfs.x *= 0.5f;
			break;
		case TouchController.LayoutAnchor.TOP_RIGHT:
			topLeftOfs.y = num2;
			topLeftOfs.x -= num;
			break;
		}
		return topLeftOfs;
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x00036A51 File Offset: 0x00034E51
	public static float SlowDownEase(float t)
	{
		t = 1f - t;
		return 1f - t * t;
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x00036A65 File Offset: 0x00034E65
	public static float SpeedUpEase(float t)
	{
		return t * t;
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x00036A6A File Offset: 0x00034E6A
	public static Color ScaleAlpha(Color c, float alphaScale)
	{
		c.a *= alphaScale;
		return c;
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x00036A7C File Offset: 0x00034E7C
	public static Rect GetCenImgRectAtPos(Vector2 pos, Texture2D img, float scale = 1f)
	{
		if (img == null)
		{
			return new Rect(pos.x, pos.y, 1f, 1f);
		}
		pos.x -= (float)img.width * 0.5f * scale;
		pos.y -= (float)img.height * 0.5f * scale;
		return new Rect(pos.x, pos.y, (float)img.width * scale, (float)img.height * scale);
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x00036B14 File Offset: 0x00034F14
	public static Rect GetCenRect(Vector2 pos, Vector2 size)
	{
		pos.x -= size.x * 0.5f;
		pos.y -= size.y * 0.5f;
		return new Rect(pos.x, pos.y, size.x, size.y);
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x00036B78 File Offset: 0x00034F78
	public static Rect GetCenRect(Vector2 pos, float size)
	{
		pos.x -= size * 0.5f;
		pos.y -= size * 0.5f;
		return new Rect(pos.x, pos.y, size, size);
	}

	// Token: 0x040006F1 RID: 1777
	public bool automaticMode = true;

	// Token: 0x040006F2 RID: 1778
	public bool manualGui;

	// Token: 0x040006F3 RID: 1779
	public bool autoActivate = true;

	// Token: 0x040006F4 RID: 1780
	public bool disableWhenNoTouchScreen;

	// Token: 0x040006F5 RID: 1781
	public int guiDepth = 10;

	// Token: 0x040006F6 RID: 1782
	public int guiPressedOfs = 10;

	// Token: 0x040006F7 RID: 1783
	public float fingerBufferCm = 0.8f;

	// Token: 0x040006F8 RID: 1784
	private float fingerBufferRadPx = 10f;

	// Token: 0x040006F9 RID: 1785
	public float stickMagnetAngleMargin = 10f;

	// Token: 0x040006FA RID: 1786
	public float stickDigitalEnterThresh = 0.5f;

	// Token: 0x040006FB RID: 1787
	public float stickDigitalLeaveThresh = 0.4f;

	// Token: 0x040006FC RID: 1788
	public float touchTapMaxTime = 0.13333334f;

	// Token: 0x040006FD RID: 1789
	public float doubleTapMaxGapTime = 0.333333343f;

	// Token: 0x040006FE RID: 1790
	public float strictMultiFingerMaxTime = 0.2f;

	// Token: 0x040006FF RID: 1791
	public float velPreserveTime = 0.1f;

	// Token: 0x04000700 RID: 1792
	public float touchTapMaxDistCm = 0.5f;

	// Token: 0x04000701 RID: 1793
	public float twistThresh = 5f;

	// Token: 0x04000702 RID: 1794
	public float pinchMinDistCm = 0.5f;

	// Token: 0x04000703 RID: 1795
	public float twistSafeFingerDistCm = 1f;

	// Token: 0x04000704 RID: 1796
	public float curTime;

	// Token: 0x04000705 RID: 1797
	public float deltaTime = 0.0166666675f;

	// Token: 0x04000706 RID: 1798
	public float invDeltaTime = 60f;

	// Token: 0x04000707 RID: 1799
	private float lastRealTime;

	// Token: 0x04000708 RID: 1800
	private bool initialized;

	// Token: 0x04000709 RID: 1801
	public TouchStick[] sticks;

	// Token: 0x0400070A RID: 1802
	public TouchZone[] touchZones;

	// Token: 0x0400070B RID: 1803
	public TouchController.LayoutBox[] layoutBoxes;

	// Token: 0x0400070C RID: 1804
	[NonSerialized]
	private TouchStick blankStick;

	// Token: 0x0400070D RID: 1805
	[NonSerialized]
	private TouchZone blankZone;

	// Token: 0x0400070E RID: 1806
	[NonSerialized]
	private List<TouchableControl> touchables;

	// Token: 0x0400070F RID: 1807
	[NonSerialized]
	private List<Rect> maskAreas;

	// Token: 0x04000710 RID: 1808
	private bool layoutDirtyFlag;

	// Token: 0x04000711 RID: 1809
	private bool contentDirtyFlag;

	// Token: 0x04000712 RID: 1810
	private bool releaseTouchesFlag;

	// Token: 0x04000713 RID: 1811
	public float pressAnimDuration = 0.1f;

	// Token: 0x04000714 RID: 1812
	public float releaseAnimDuration = 0.3f;

	// Token: 0x04000715 RID: 1813
	public float disableAnimDuration = 0.3f;

	// Token: 0x04000716 RID: 1814
	public float enableAnimDuration = 0.3f;

	// Token: 0x04000717 RID: 1815
	public float cancelAnimDuration = 0.3f;

	// Token: 0x04000718 RID: 1816
	public float showAnimDuration = 0.3f;

	// Token: 0x04000719 RID: 1817
	public float hideAnimDuration = 0.3f;

	// Token: 0x0400071A RID: 1818
	public float releasedZoneScale = 1f;

	// Token: 0x0400071B RID: 1819
	public float pressedZoneScale = 1.1f;

	// Token: 0x0400071C RID: 1820
	public float disabledZoneScale = 1f;

	// Token: 0x0400071D RID: 1821
	public float releasedStickHatScale = 0.75f;

	// Token: 0x0400071E RID: 1822
	public float pressedStickHatScale = 0.9f;

	// Token: 0x0400071F RID: 1823
	public float disabledStickHatScale = 0.75f;

	// Token: 0x04000720 RID: 1824
	public float releasedStickBaseScale = 1f;

	// Token: 0x04000721 RID: 1825
	public float pressedStickBaseScale = 0.9f;

	// Token: 0x04000722 RID: 1826
	public float disabledStickBaseScale = 1f;

	// Token: 0x04000723 RID: 1827
	public Color defaultPressedZoneColor = new Color(1f, 1f, 1f, 1f);

	// Token: 0x04000724 RID: 1828
	public Color defaultReleasedZoneColor = new Color(1f, 1f, 1f, 0.75f);

	// Token: 0x04000725 RID: 1829
	public Color defaultDisabledZoneColor = new Color(0.5f, 0.5f, 0.5f, 0.35f);

	// Token: 0x04000726 RID: 1830
	public Color defaultPressedStickHatColor = new Color(1f, 1f, 1f, 1f);

	// Token: 0x04000727 RID: 1831
	public Color defaultReleasedStickHatColor = new Color(1f, 1f, 1f, 0.75f);

	// Token: 0x04000728 RID: 1832
	public Color defaultDisabledStickHatColor = new Color(0.5f, 0.5f, 0.5f, 0.35f);

	// Token: 0x04000729 RID: 1833
	public Color defaultPressedStickBaseColor = new Color(1f, 1f, 1f, 1f);

	// Token: 0x0400072A RID: 1834
	public Color defaultReleasedStickBaseColor = new Color(1f, 1f, 1f, 0.75f);

	// Token: 0x0400072B RID: 1835
	public Color defaultDisabledStickBaseColor = new Color(0.5f, 0.5f, 0.5f, 0.35f);

	// Token: 0x0400072C RID: 1836
	private float globalAlpha = 1f;

	// Token: 0x0400072D RID: 1837
	private float globalAlphaStart;

	// Token: 0x0400072E RID: 1838
	private float globalAlphaEnd;

	// Token: 0x0400072F RID: 1839
	private AnimTimer globalAlphaTimer;

	// Token: 0x04000730 RID: 1840
	private int screenWidth;

	// Token: 0x04000731 RID: 1841
	private int screenHeight;

	// Token: 0x04000732 RID: 1842
	private bool disableAll;

	// Token: 0x04000733 RID: 1843
	private bool leftHandedMode;

	// Token: 0x04000734 RID: 1844
	public const int DEFAULT_ZONE_PRIO = 0;

	// Token: 0x04000735 RID: 1845
	public const int DEFAULT_STICK_PRIO = 0;

	// Token: 0x04000736 RID: 1846
	private const int MAX_EVENT_SHARE_COUNT = 8;

	// Token: 0x04000737 RID: 1847
	private const float NON_MOBILE_DIAGONAL_INCHES = 7f;

	// Token: 0x04000738 RID: 1848
	private const float DEFAULT_MONITOR_DPI = 96f;

	// Token: 0x04000739 RID: 1849
	public KeyCode debugSecondTouchDragModeKey = KeyCode.LeftShift;

	// Token: 0x0400073A RID: 1850
	public KeyCode debugSecondTouchPinchModeKey = KeyCode.LeftControl;

	// Token: 0x0400073B RID: 1851
	public KeyCode debugSecondTouchTwistModeKey = KeyCode.LeftAlt;

	// Token: 0x0400073C RID: 1852
	public bool debugDrawTouches = true;

	// Token: 0x0400073D RID: 1853
	public bool debugDrawLayoutBoxes = true;

	// Token: 0x0400073E RID: 1854
	public bool debugDrawAreas = true;

	// Token: 0x0400073F RID: 1855
	public Texture2D debugTouchSprite;

	// Token: 0x04000740 RID: 1856
	public Texture2D debugSecondTouchSprite;

	// Token: 0x04000741 RID: 1857
	public Color debugFirstTouchNormalColor = new Color(1f, 1f, 0.6f, 0.3f);

	// Token: 0x04000742 RID: 1858
	public Color debugFirstTouchActiveColor = new Color(1f, 1f, 0f, 0.7f);

	// Token: 0x04000743 RID: 1859
	public Color debugSecondTouchNormalColor = new Color(1f, 1f, 1f, 0.3f);

	// Token: 0x04000744 RID: 1860
	public Color debugSecondTouchActiveColor = new Color(1f, 0f, 0f, 0.6f);

	// Token: 0x04000745 RID: 1861
	public Texture2D defaultZoneImg;

	// Token: 0x04000746 RID: 1862
	public Texture2D defaultStickHatImg;

	// Token: 0x04000747 RID: 1863
	public Texture2D defaultStickBaseImg;

	// Token: 0x04000748 RID: 1864
	public Texture2D debugCircleImg;

	// Token: 0x04000749 RID: 1865
	public Texture2D debugRectImg;

	// Token: 0x0400074A RID: 1866
	public bool screenEmuOn;

	// Token: 0x0400074B RID: 1867
	public bool screenEmuPortrait;

	// Token: 0x0400074C RID: 1868
	public bool screenEmuShrink = true;

	// Token: 0x0400074D RID: 1869
	public Vector2 screenEmuPan = new Vector2(0.5f, 0.5f);

	// Token: 0x0400074E RID: 1870
	public int screenEmuHwDpi = 250;

	// Token: 0x0400074F RID: 1871
	public TouchController.ScreenEmuMode screenEmuMode = TouchController.ScreenEmuMode.EXPAND;

	// Token: 0x04000750 RID: 1872
	public int screenEmuHwHorzRes = 1024;

	// Token: 0x04000751 RID: 1873
	public int screenEmuHwVertRes = 640;

	// Token: 0x04000752 RID: 1874
	public float monitorDiagonal = 15f;

	// Token: 0x04000753 RID: 1875
	public Color screenEmuBorderColor = new Color(0f, 0f, 0f, 0.75f);

	// Token: 0x04000754 RID: 1876
	public Color screenEmuBorderBadColor = new Color(0.5f, 0f, 0f, 0.75f);

	// Token: 0x04000755 RID: 1877
	public TouchController.RealWorldUnit rwUnit;

	// Token: 0x04000756 RID: 1878
	public TouchController.PreviewMode previewMode;

	// Token: 0x04000757 RID: 1879
	private bool firstPostPollUpdate;

	// Token: 0x04000758 RID: 1880
	private bool customLayoutNeedsRebuild;

	// Token: 0x04000759 RID: 1881
	private Vector2 emuMousePos;

	// Token: 0x0400075A RID: 1882
	public int version;

	// Token: 0x0400075B RID: 1883
	public const int LayoutBoxCount = 16;

	// Token: 0x0400075C RID: 1884
	public float twistSafeFingerDistPx = 10f;

	// Token: 0x0400075D RID: 1885
	public float pinchMinDistPx = 10f;

	// Token: 0x0400075E RID: 1886
	public float touchTapMaxDistPx = 10f;

	// Token: 0x0400075F RID: 1887
	[NonSerialized]
	private double editorLastSafetyUpdateTime;

	// Token: 0x04000760 RID: 1888
	[NonSerialized]
	private const double EDITOR_SAFETY_UPDATE_INTERVAL = 2.0;

	// Token: 0x0200012A RID: 298
	public enum RealWorldUnit
	{
		// Token: 0x04000762 RID: 1890
		CM,
		// Token: 0x04000763 RID: 1891
		INCH
	}

	// Token: 0x0200012B RID: 299
	public enum PreviewMode
	{
		// Token: 0x04000765 RID: 1893
		RELEASED,
		// Token: 0x04000766 RID: 1894
		PRESSED,
		// Token: 0x04000767 RID: 1895
		DISABLED
	}

	// Token: 0x0200012C RID: 300
	public enum LayoutAnchor
	{
		// Token: 0x04000769 RID: 1897
		BOTTOM_LEFT,
		// Token: 0x0400076A RID: 1898
		BOTTOM_CENTER,
		// Token: 0x0400076B RID: 1899
		BOTTOM_RIGHT,
		// Token: 0x0400076C RID: 1900
		MID_LEFT,
		// Token: 0x0400076D RID: 1901
		MID_CENTER,
		// Token: 0x0400076E RID: 1902
		MID_RIGHT,
		// Token: 0x0400076F RID: 1903
		TOP_LEFT,
		// Token: 0x04000770 RID: 1904
		TOP_CENTER,
		// Token: 0x04000771 RID: 1905
		TOP_RIGHT
	}

	// Token: 0x0200012D RID: 301
	public enum ControlShape
	{
		// Token: 0x04000773 RID: 1907
		CIRCLE,
		// Token: 0x04000774 RID: 1908
		RECT,
		// Token: 0x04000775 RID: 1909
		SCREEN_REGION
	}

	// Token: 0x0200012E RID: 302
	public enum ScreenEmuMode
	{
		// Token: 0x04000777 RID: 1911
		PIXEL_PERFECT,
		// Token: 0x04000778 RID: 1912
		PHYSICAL,
		// Token: 0x04000779 RID: 1913
		EXPAND
	}

	// Token: 0x0200012F RID: 303
	public enum EventResult
	{
		// Token: 0x0400077B RID: 1915
		NOT_HANDLED,
		// Token: 0x0400077C RID: 1916
		HANDLED,
		// Token: 0x0400077D RID: 1917
		SHARED
	}

	// Token: 0x02000130 RID: 304
	public struct HitTestResult
	{
		// Token: 0x0600086C RID: 2156 RVA: 0x00036BC4 File Offset: 0x00034FC4
		public HitTestResult(bool hit)
		{
			this.hit = hit;
			this.dist = 1f;
			this.distScale = 1f;
			this.hitInside = false;
			this.prio = 0;
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00036BF4 File Offset: 0x00034FF4
		public bool IsCloserThan(TouchController.HitTestResult r)
		{
			return this.hit && (this.prio > r.prio || (this.hitInside && !r.hitInside) || ((this.prio != r.prio) ? (this.dist < r.dist) : (this.dist * this.distScale < r.dist * r.distScale)));
		}

		// Token: 0x0400077E RID: 1918
		public bool hit;

		// Token: 0x0400077F RID: 1919
		public float dist;

		// Token: 0x04000780 RID: 1920
		public int prio;

		// Token: 0x04000781 RID: 1921
		public bool hitInside;

		// Token: 0x04000782 RID: 1922
		public float distScale;
	}

	// Token: 0x02000131 RID: 305
	[Serializable]
	public class LayoutBox
	{
		// Token: 0x0600086E RID: 2158 RVA: 0x00036C80 File Offset: 0x00035080
		public LayoutBox(string name, float left, float top, float width, float height, TouchController.LayoutAnchor anchor)
		{
			this.name = name;
			this.normalizedRect = new Rect(left, top, width, height);
			this.anchor = anchor;
			this.uniformMargins = true;
			this.horzMarginMax = 0.5f;
			this.vertMarginMax = 0.5f;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00036CEF File Offset: 0x000350EF
		public void SetController(TouchController joy)
		{
			this.joy = joy;
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00036CF8 File Offset: 0x000350F8
		public void ResetContent()
		{
			this.contentSize = Vector2.zero;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00036D08 File Offset: 0x00035108
		private void AddContentMinMax(Vector2 bbmin, Vector2 bbmax)
		{
			if (this.contentSize.x < 0.001f)
			{
				this.contentOfs = bbmin;
				this.contentSize = bbmax - bbmin;
			}
			else
			{
				Vector2 a = this.contentOfs + this.contentSize;
				this.contentOfs.x = Mathf.Min(bbmin.x, this.contentOfs.x);
				this.contentOfs.y = Mathf.Min(bbmin.y, this.contentOfs.y);
				a.x = Mathf.Max(bbmax.x, a.x);
				a.y = Mathf.Max(bbmax.y, a.y);
				this.contentSize = a - this.contentOfs;
			}
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00036DE0 File Offset: 0x000351E0
		public void AddContent(Vector2 cen, float size)
		{
			size *= 0.5f;
			Vector2 b = new Vector2(size, size);
			this.AddContentMinMax(cen - b, cen + b);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00036E13 File Offset: 0x00035213
		public void AddContent(Vector2 cen, Vector2 size)
		{
			size *= 0.5f;
			this.AddContentMinMax(cen - size, cen + size);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00036E38 File Offset: 0x00035238
		public void ContentFinalize()
		{
			float screenX = this.joy.GetScreenX(this.normalizedRect.xMin);
			float screenX2 = this.joy.GetScreenX(this.normalizedRect.xMax);
			float screenY = this.joy.GetScreenY(this.normalizedRect.yMin);
			float screenY2 = this.joy.GetScreenY(this.normalizedRect.yMax);
			Vector2 a = new Vector2(screenX2 - screenX, screenY2 - screenY);
			float num = this.joy.CmToPixels(this.contentSize.x);
			float num2 = this.joy.CmToPixels(this.contentSize.y);
			if (num < 0.01f || num2 < 0.01f)
			{
				this.contentPosScale = Vector2.one;
				this.contentSizeScale = 1f;
			}
			else
			{
				float num3 = Mathf.Clamp01(a.x / num);
				float num4 = Mathf.Clamp01(a.y / num2);
				this.contentSizeScale = Mathf.Clamp01(Mathf.Min(num3, num4));
				if (this.allowNonuniformScale)
				{
					this.contentPosScale = new Vector2(Mathf.Clamp01(num3), Mathf.Clamp01(num4));
				}
				else
				{
					this.contentPosScale = new Vector2(this.contentSizeScale, this.contentSizeScale);
				}
			}
			Vector2 b = new Vector2(this.contentPosScale.x * num, this.contentPosScale.y * num2);
			this.contentPosScale *= this.joy.GetDPCM();
			this.contentSizeScale *= this.joy.GetDPCM();
			Vector2 topLeftOfs = a - b;
			float maxMarginX = this.horzMarginMax * this.joy.GetDPCM();
			float maxMarginY = this.vertMarginMax * this.joy.GetDPCM();
			this.screenDstOfs = new Vector2(screenX, screenY) + TouchController.AnchorLeftover(topLeftOfs, this.anchor, maxMarginX, maxMarginY, this.uniformMargins);
			this.contentScreenBox = new Rect(this.screenDstOfs.x, this.screenDstOfs.y, b.x, b.y);
			this.availableScreenBox = new Rect(screenX, screenY, a.x, a.y);
			if (!this.ignoreLeftHandedMode)
			{
				this.contentScreenBox = this.joy.RightHandToScreenRect(this.contentScreenBox);
				this.availableScreenBox = this.joy.RightHandToScreenRect(this.availableScreenBox);
			}
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x000370C0 File Offset: 0x000354C0
		public Vector2 GetScreenPos(Vector2 pos)
		{
			pos -= this.contentOfs;
			pos.x *= this.contentPosScale.x;
			pos.y *= this.contentPosScale.y;
			pos += this.screenDstOfs;
			return (!this.ignoreLeftHandedMode) ? this.joy.RightHandToScreen(pos) : pos;
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00037138 File Offset: 0x00035538
		public float GetScreenSize(float size)
		{
			return size * this.contentSizeScale;
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00037142 File Offset: 0x00035542
		public Vector2 GetScreenSize(Vector2 size)
		{
			return size * this.contentSizeScale;
		}

		// Token: 0x04000783 RID: 1923
		public string name;

		// Token: 0x04000784 RID: 1924
		public TouchController.LayoutAnchor anchor;

		// Token: 0x04000785 RID: 1925
		public bool allowNonuniformScale;

		// Token: 0x04000786 RID: 1926
		public bool ignoreLeftHandedMode;

		// Token: 0x04000787 RID: 1927
		public Rect normalizedRect;

		// Token: 0x04000788 RID: 1928
		public float horzMarginMax;

		// Token: 0x04000789 RID: 1929
		public float vertMarginMax;

		// Token: 0x0400078A RID: 1930
		public bool uniformMargins;

		// Token: 0x0400078B RID: 1931
		private TouchController joy;

		// Token: 0x0400078C RID: 1932
		private Vector2 contentOfs;

		// Token: 0x0400078D RID: 1933
		private Vector2 contentSize;

		// Token: 0x0400078E RID: 1934
		private Vector2 contentPosScale;

		// Token: 0x0400078F RID: 1935
		private float contentSizeScale;

		// Token: 0x04000790 RID: 1936
		private Vector2 screenDstOfs;

		// Token: 0x04000791 RID: 1937
		private Rect contentScreenBox;

		// Token: 0x04000792 RID: 1938
		private Rect availableScreenBox;

		// Token: 0x04000793 RID: 1939
		public Color debugColor = new Color(1f, 1f, 1f, 0.2f);

		// Token: 0x04000794 RID: 1940
		public bool debugDraw;
	}

	// Token: 0x02000132 RID: 306
	public struct AnimFloat
	{
		// Token: 0x06000878 RID: 2168 RVA: 0x00037150 File Offset: 0x00035550
		public void Reset(float val)
		{
			this.cur = val;
			this.end = val;
			this.start = val;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00037176 File Offset: 0x00035576
		public void MoveTo(float val)
		{
			this.start = this.cur;
			this.end = val;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x0003718B File Offset: 0x0003558B
		public void Update(float lerpt)
		{
			this.cur = Mathf.Lerp(this.start, this.end, lerpt);
		}

		// Token: 0x04000795 RID: 1941
		public float start;

		// Token: 0x04000796 RID: 1942
		public float end;

		// Token: 0x04000797 RID: 1943
		public float cur;
	}

	// Token: 0x02000133 RID: 307
	public struct AnimColor
	{
		// Token: 0x0600087B RID: 2171 RVA: 0x000371A8 File Offset: 0x000355A8
		public void Reset(Color val)
		{
			this.cur = val;
			this.end = val;
			this.start = val;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x000371CE File Offset: 0x000355CE
		public void MoveTo(Color val)
		{
			this.start = this.cur;
			this.end = val;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000371E3 File Offset: 0x000355E3
		public void Update(float lerpt)
		{
			this.cur = Color.Lerp(this.start, this.end, lerpt);
		}

		// Token: 0x04000798 RID: 1944
		public Color start;

		// Token: 0x04000799 RID: 1945
		public Color end;

		// Token: 0x0400079A RID: 1946
		public Color cur;
	}
}
