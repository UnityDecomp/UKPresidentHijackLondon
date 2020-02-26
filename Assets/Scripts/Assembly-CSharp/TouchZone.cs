using System;
using UnityEngine;

// Token: 0x02000139 RID: 313
[Serializable]
public class TouchZone : TouchableControl
{
	// Token: 0x060008D2 RID: 2258 RVA: 0x000391C8 File Offset: 0x000375C8
	private TouchZone.Finger GetFinger(int i)
	{
		return (i != 0) ? ((i != 1) ? null : this.fingerB) : this.fingerA;
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x000391F0 File Offset: 0x000375F0
	public bool Pressed(int fingerId, bool trueOnMidFramePress, bool falseOnMidFrameRelease)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.Pressed(trueOnMidFramePress, falseOnMidFrameRelease);
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x0003921E File Offset: 0x0003761E
	public bool Pressed(int fingerId)
	{
		return this.Pressed(fingerId, false, false);
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x00039229 File Offset: 0x00037629
	public bool UniPressed(bool trueOnMidFramePress, bool falseOnMidFrameRelease)
	{
		return (this.uniCur || (trueOnMidFramePress && this.uniMidFramePressed)) && (!falseOnMidFrameRelease || !this.uniMidFrameReleased);
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x0003925C File Offset: 0x0003765C
	public bool UniPressed()
	{
		return this.UniPressed(false, false);
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x00039266 File Offset: 0x00037666
	public bool MultiPressed(bool trueOnMidFramePress, bool falseOnMidFrameRelease)
	{
		return (this.multiCur || (trueOnMidFramePress && this.multiMidFramePressed)) && (!falseOnMidFrameRelease || !this.multiMidFrameReleased);
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x00039299 File Offset: 0x00037699
	public bool MultiPressed()
	{
		return this.MultiPressed(false, false);
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000392A4 File Offset: 0x000376A4
	public bool JustPressed(int fingerId, bool trueOnMidFramePress, bool trueOnMidFrameRelease)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.JustPressed(trueOnMidFramePress, trueOnMidFrameRelease);
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x000392D2 File Offset: 0x000376D2
	public bool JustPressed(int fingerId)
	{
		return this.JustPressed(fingerId, false, false);
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x000392DD File Offset: 0x000376DD
	public bool JustUniPressed(bool trueOnMidFramePress, bool trueOnMidFrameRelease)
	{
		return (!this.uniPrev && this.uniCur) || (trueOnMidFramePress && this.uniMidFramePressed) || (trueOnMidFrameRelease && this.uniMidFrameReleased);
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x00039318 File Offset: 0x00037718
	public bool JustUniPressed()
	{
		return this.JustUniPressed(false, false);
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x00039322 File Offset: 0x00037722
	public bool JustMultiPressed(bool trueOnMidFramePress, bool trueOnMidFrameRelease)
	{
		return (!this.multiPrev && this.multiCur) || (trueOnMidFramePress && this.multiMidFramePressed) || (trueOnMidFrameRelease && this.multiMidFrameReleased);
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x0003935D File Offset: 0x0003775D
	public bool JustMultiPressed()
	{
		return this.JustMultiPressed(false, false);
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x00039368 File Offset: 0x00037768
	public bool JustReleased(int fingerId, bool trueOnMidFramePress, bool trueOnMidFrameRelease)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.JustPressed(trueOnMidFramePress, trueOnMidFrameRelease);
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x00039396 File Offset: 0x00037796
	public bool JustReleased(int fingerId)
	{
		return this.JustReleased(fingerId, false, false);
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x000393A1 File Offset: 0x000377A1
	public bool JustUniReleased(bool trueOnMidFramePress, bool trueOnMidFrameRelease)
	{
		return (this.uniPrev && !this.uniCur) || (trueOnMidFramePress && this.uniMidFramePressed) || (trueOnMidFrameRelease && this.uniMidFrameReleased);
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x000393DC File Offset: 0x000377DC
	public bool JustUniReleased()
	{
		return this.JustUniReleased(false, false);
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x000393E6 File Offset: 0x000377E6
	public bool JustMultiReleased(bool trueOnMidFramePress, bool trueOnMidFrameRelease)
	{
		return (this.multiPrev && !this.multiCur) || (trueOnMidFramePress && this.multiMidFramePressed) || (trueOnMidFrameRelease && this.multiMidFrameReleased);
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x00039421 File Offset: 0x00037821
	public bool JustMultiReleased()
	{
		return this.JustMultiReleased(false, false);
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x0003942C File Offset: 0x0003782C
	public bool JustMidFramePressed(int fingerId)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.midFramePressed;
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x00039458 File Offset: 0x00037858
	public bool JustMidFrameReleased(int fingerId)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.midFrameReleased;
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x00039484 File Offset: 0x00037884
	public bool JustMidFrameUniPressed()
	{
		return this.uniMidFramePressed;
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x0003948C File Offset: 0x0003788C
	public bool JustMidFrameUniReleased()
	{
		return this.uniMidFrameReleased;
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x00039494 File Offset: 0x00037894
	public bool JustMidFrameMultiPressed()
	{
		return this.multiMidFramePressed;
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x0003949C File Offset: 0x0003789C
	public bool JustMidFrameMultiReleased()
	{
		return this.multiMidFrameReleased;
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x000394A4 File Offset: 0x000378A4
	public float GetTouchDuration(int fingerId)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return (!finger.curState) ? 0f : (this.joy.curTime - finger.startTime);
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x000394F1 File Offset: 0x000378F1
	public float GetUniTouchDuration()
	{
		return (!this.uniCur) ? 0f : (this.joy.curTime - this.uniStartTime);
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x0003951A File Offset: 0x0003791A
	public float GetMultiTouchDuration()
	{
		return (!this.multiCur) ? 0f : (this.joy.curTime - this.multiStartTime);
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x00039544 File Offset: 0x00037944
	public Vector2 GetPos(int fingerId, TouchCoordSys cs)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return this.TransformPos(finger.posCur, cs, false);
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x00039578 File Offset: 0x00037978
	public Vector2 GetPos(int fingerId)
	{
		return this.GetPos(fingerId, TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x00039582 File Offset: 0x00037982
	public Vector2 GetUniPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.uniPosCur, cs, false);
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x00039592 File Offset: 0x00037992
	public Vector2 GetUniPos()
	{
		return this.GetUniPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x0003959B File Offset: 0x0003799B
	public Vector2 GetMultiPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.multiPosCur, cs, false);
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000395AB File Offset: 0x000379AB
	public Vector2 GetMultiPos()
	{
		return this.GetMultiPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x000395B4 File Offset: 0x000379B4
	public Vector2 GetStartPos(int fingerId, TouchCoordSys cs)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return this.TransformPos(finger.startPos, cs, false);
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x000395E8 File Offset: 0x000379E8
	public Vector2 GetStartPos(int fingerId)
	{
		return this.GetStartPos(fingerId, TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x000395F2 File Offset: 0x000379F2
	public Vector2 GetUniStartPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.uniPosStart, cs, false);
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x00039602 File Offset: 0x00037A02
	public Vector2 GetUniStartPos()
	{
		return this.GetUniStartPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x0003960B File Offset: 0x00037A0B
	public Vector2 GetMultiStartPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.multiPosStart, cs, false);
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x0003961B File Offset: 0x00037A1B
	public Vector2 GetMultiStartPos()
	{
		return this.GetMultiStartPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00039624 File Offset: 0x00037A24
	public Vector2 GetDragVec(int fingerId, TouchCoordSys cs, bool raw)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		if (!raw && !finger.moved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(finger.posCur - finger.startPos, cs, true);
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x0003967A File Offset: 0x00037A7A
	public Vector2 GetDragVec(int fingerId)
	{
		return this.GetDragVec(fingerId, TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x00039685 File Offset: 0x00037A85
	public Vector2 GetDragVec(int fingerId, TouchCoordSys cs)
	{
		return this.GetDragVec(fingerId, cs, false);
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x00039690 File Offset: 0x00037A90
	public Vector2 GetDragVec(int fingerId, bool raw)
	{
		return this.GetDragVec(fingerId, TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x0003969B File Offset: 0x00037A9B
	public Vector2 GetDragVecRaw(int fingerId)
	{
		return this.GetDragVec(fingerId, TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000396A6 File Offset: 0x00037AA6
	public Vector2 GetDragVecRaw(int fingerId, TouchCoordSys cs)
	{
		return this.GetDragVec(fingerId, cs, true);
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x000396B1 File Offset: 0x00037AB1
	public Vector2 GetUniDragVec(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.uniMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(this.uniTotalDragCur, cs, true);
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x000396D8 File Offset: 0x00037AD8
	public Vector2 GetUniDragVec()
	{
		return this.GetUniDragVec(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x000396E2 File Offset: 0x00037AE2
	public Vector2 GetUniDragVec(TouchCoordSys cs)
	{
		return this.GetUniDragVec(cs, false);
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x000396EC File Offset: 0x00037AEC
	public Vector2 GetUniDragVec(bool raw)
	{
		return this.GetUniDragVec(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000904 RID: 2308 RVA: 0x000396F6 File Offset: 0x00037AF6
	public Vector2 GetUniDragVecRaw()
	{
		return this.GetUniDragVec(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x00039700 File Offset: 0x00037B00
	public Vector2 GetUniDragVecRaw(TouchCoordSys cs)
	{
		return this.GetUniDragVec(cs, true);
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x0003970A File Offset: 0x00037B0A
	public Vector2 GetMultiDragVec(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.uniMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(this.multiPosCur - this.multiPosStart, cs, true);
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x0003973C File Offset: 0x00037B3C
	public Vector2 GetMultiDragVec()
	{
		return this.GetMultiDragVec(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x00039746 File Offset: 0x00037B46
	public Vector2 GetMultiDragVec(TouchCoordSys cs)
	{
		return this.GetMultiDragVec(cs, false);
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x00039750 File Offset: 0x00037B50
	public Vector2 GetMultiDragVec(bool raw)
	{
		return this.GetMultiDragVec(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x0003975A File Offset: 0x00037B5A
	public Vector2 GetMultiDragVecRaw()
	{
		return this.GetMultiDragVec(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x00039764 File Offset: 0x00037B64
	public Vector2 GetMultiDragVecRaw(TouchCoordSys cs)
	{
		return this.GetMultiDragVec(cs, true);
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x00039770 File Offset: 0x00037B70
	public Vector2 GetDragDelta(int fingerId, TouchCoordSys cs, bool raw)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		if (!raw && !finger.moved)
		{
			return Vector2.zero;
		}
		return this.TransformPos((raw || !finger.justMoved) ? (finger.posCur - finger.posPrev) : (finger.posCur - finger.startPos), cs, true);
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x000397ED File Offset: 0x00037BED
	public Vector2 GetDragDelta(int fingerId)
	{
		return this.GetDragDelta(fingerId, TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x000397F8 File Offset: 0x00037BF8
	public Vector2 GetDragDelta(int fingerId, TouchCoordSys cs)
	{
		return this.GetDragDelta(fingerId, cs, false);
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x00039803 File Offset: 0x00037C03
	public Vector2 GetDragDelta(int fingerId, bool raw)
	{
		return this.GetDragDelta(fingerId, TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x0003980E File Offset: 0x00037C0E
	public Vector2 GetDragDeltaRaw(int fingerId)
	{
		return this.GetDragDelta(fingerId, TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x00039819 File Offset: 0x00037C19
	public Vector2 GetDragDeltaRaw(int fingerId, TouchCoordSys cs)
	{
		return this.GetDragDelta(fingerId, cs, true);
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x00039824 File Offset: 0x00037C24
	public Vector2 GetUniDragDelta(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.uniMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos((raw || !this.uniJustMoved) ? (this.uniTotalDragCur - this.uniTotalDragPrev) : this.uniTotalDragCur, cs, true);
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x0003987D File Offset: 0x00037C7D
	public Vector2 GetUniDragDelta()
	{
		return this.GetUniDragDelta(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x00039887 File Offset: 0x00037C87
	public Vector2 GetUniDragDelta(TouchCoordSys cs)
	{
		return this.GetUniDragDelta(cs, false);
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x00039891 File Offset: 0x00037C91
	public Vector2 GetUniDragDelta(bool raw)
	{
		return this.GetUniDragDelta(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x0003989B File Offset: 0x00037C9B
	public Vector2 GetUniDragDeltaRaw()
	{
		return this.GetUniDragDelta(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x000398A5 File Offset: 0x00037CA5
	public Vector2 GetUniDragDeltaRaw(TouchCoordSys cs)
	{
		return this.GetUniDragDelta(cs, true);
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x000398B0 File Offset: 0x00037CB0
	public Vector2 GetMultiDragDelta(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.multiMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos((raw || !this.multiJustMoved) ? (this.multiPosCur - this.multiPosPrev) : (this.multiPosCur - this.multiPosStart), cs, true);
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x00039914 File Offset: 0x00037D14
	public Vector2 GetMultiDragDelta()
	{
		return this.GetMultiDragDelta(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x0003991E File Offset: 0x00037D1E
	public Vector2 GetMultiDragDelta(TouchCoordSys cs)
	{
		return this.GetMultiDragDelta(cs, false);
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x00039928 File Offset: 0x00037D28
	public Vector2 GetMultiDragDelta(bool raw)
	{
		return this.GetMultiDragDelta(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x00039932 File Offset: 0x00037D32
	public Vector2 GetMultiDragDeltaRaw()
	{
		return this.GetMultiDragDelta(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x0003993C File Offset: 0x00037D3C
	public Vector2 GetMultiDragDeltaRaw(TouchCoordSys cs)
	{
		return this.GetMultiDragDelta(cs, true);
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x00039948 File Offset: 0x00037D48
	public bool Dragged(int fingerId)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.curState && finger.moved;
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x00039982 File Offset: 0x00037D82
	public bool UniDragged()
	{
		return this.uniCur && this.uniMoved;
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x00039998 File Offset: 0x00037D98
	public bool MultiDragged()
	{
		return this.multiCur && this.multiMoved;
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x000399B0 File Offset: 0x00037DB0
	public bool JustDragged(int fingerId)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.curState && finger.justMoved;
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x000399EA File Offset: 0x00037DEA
	public bool JustUniDragged()
	{
		return this.uniCur && this.uniJustMoved;
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x00039A00 File Offset: 0x00037E00
	public bool JustMultiDragged()
	{
		return this.multiCur && this.multiJustMoved;
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x00039A18 File Offset: 0x00037E18
	public Vector2 GetDragVel(int fingerId, TouchCoordSys cs)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return this.TransformPos(finger.dragVel, cs, true);
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x00039A4C File Offset: 0x00037E4C
	public Vector2 GetDragVel(int fingerId)
	{
		return this.GetDragVel(fingerId, TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x00039A56 File Offset: 0x00037E56
	public Vector2 GetUniDragVel(TouchCoordSys cs)
	{
		return this.TransformPos(this.uniDragVel, cs, true);
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x00039A66 File Offset: 0x00037E66
	public Vector2 GetUniDragVel()
	{
		return this.GetUniDragVel(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x00039A6F File Offset: 0x00037E6F
	public Vector2 GetMultiDragVel(TouchCoordSys cs)
	{
		return this.TransformPos(this.multiDragVel, cs, true);
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x00039A7F File Offset: 0x00037E7F
	public Vector2 GetMultiDragVel()
	{
		return this.GetMultiDragVel(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x00039A88 File Offset: 0x00037E88
	public bool Twisted()
	{
		return this.twistMoved;
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x00039A90 File Offset: 0x00037E90
	public bool JustTwisted()
	{
		return this.twistJustMoved;
	}

	// Token: 0x0600092C RID: 2348 RVA: 0x00039A98 File Offset: 0x00037E98
	public float GetTwistVel()
	{
		return this.twistVel;
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x00039AA0 File Offset: 0x00037EA0
	public float GetTotalTwist(bool raw)
	{
		if (!raw && !this.twistMoved)
		{
			return 0f;
		}
		return this.twistCur;
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x00039ABF File Offset: 0x00037EBF
	public float GetTotalTwist()
	{
		return this.GetTotalTwist(false);
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x00039AC8 File Offset: 0x00037EC8
	public float GetTotalTwistRaw()
	{
		return this.GetTotalTwist(true);
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x00039AD1 File Offset: 0x00037ED1
	public float GetTwistDelta(bool raw)
	{
		if (!raw && this.twistJustMoved)
		{
			return this.twistCur;
		}
		return Mathf.DeltaAngle(this.twistPrev, this.twistCur);
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x00039AFC File Offset: 0x00037EFC
	public float GetTwistDelta()
	{
		return this.GetTwistDelta(false);
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x00039B05 File Offset: 0x00037F05
	public float GetTwistDeltaRaw()
	{
		return this.GetTwistDelta(true);
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x00039B0E File Offset: 0x00037F0E
	public bool Pinched()
	{
		return this.pinchMoved;
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x00039B16 File Offset: 0x00037F16
	public bool JustPinched()
	{
		return this.pinchJustMoved;
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x00039B1E File Offset: 0x00037F1E
	public float GetPinchDist(TouchCoordSys cs, bool raw)
	{
		if (!this.multiCur || (!raw && !this.pinchMoved))
		{
			return 0f;
		}
		return this.TransformPos(this.pinchCurDist, cs);
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x00039B4F File Offset: 0x00037F4F
	public float GetPinchDist()
	{
		return this.GetPinchDist(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000937 RID: 2359 RVA: 0x00039B59 File Offset: 0x00037F59
	public float GetPinchDist(TouchCoordSys cs)
	{
		return this.GetPinchDist(cs, false);
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x00039B63 File Offset: 0x00037F63
	public float GetPinchDist(bool raw)
	{
		return this.GetPinchDist(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x00039B6D File Offset: 0x00037F6D
	public float GetPinchDistRaw()
	{
		return this.GetPinchDist(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x00039B77 File Offset: 0x00037F77
	public float GetPinchDistRaw(TouchCoordSys cs)
	{
		return this.GetPinchDist(cs, true);
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x00039B84 File Offset: 0x00037F84
	public float GetPinchDistDelta(TouchCoordSys cs, bool raw)
	{
		if (!this.multiCur || (!raw && !this.pinchMoved))
		{
			return 0f;
		}
		return this.TransformPos(this.pinchCurDist - ((raw || !this.pinchJustMoved) ? this.pinchPrevDist : this.pinchDistStart), cs);
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x00039BE3 File Offset: 0x00037FE3
	public float GetPinchDistDelta()
	{
		return this.GetPinchDistDelta(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x0600093D RID: 2365 RVA: 0x00039BED File Offset: 0x00037FED
	public float GetPinchDistDelta(TouchCoordSys cs)
	{
		return this.GetPinchDistDelta(cs, false);
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x00039BF7 File Offset: 0x00037FF7
	public float GetPinchDistDelta(bool raw)
	{
		return this.GetPinchDistDelta(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x00039C01 File Offset: 0x00038001
	public float GetPinchDistDeltaRaw()
	{
		return this.GetPinchDistDelta(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x00039C0B File Offset: 0x0003800B
	public float GetPinchDistDeltaRaw(TouchCoordSys cs)
	{
		return this.GetPinchDistDelta(cs, true);
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x00039C15 File Offset: 0x00038015
	public float GetPinchScale(bool raw)
	{
		if (!this.multiCur || (!raw && !this.pinchMoved))
		{
			return 1f;
		}
		return this.pinchCurDist / this.pinchDistStart;
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x00039C46 File Offset: 0x00038046
	public float GetPinchScale()
	{
		return this.GetPinchScale(false);
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x00039C4F File Offset: 0x0003804F
	public float GetPinchScaleRaw()
	{
		return this.GetPinchScale(true);
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x00039C58 File Offset: 0x00038058
	public float GetPinchRelativeScale(bool raw)
	{
		if (!this.multiCur || (!raw && !this.pinchMoved))
		{
			return 1f;
		}
		return this.pinchCurDist / ((raw || !this.pinchJustMoved) ? this.pinchPrevDist : this.pinchDistStart);
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x00039CB0 File Offset: 0x000380B0
	public float GetPinchRelativeScale()
	{
		return this.GetPinchRelativeScale(false);
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x00039CB9 File Offset: 0x000380B9
	public float GetPinchRelativeScaleRaw()
	{
		return this.GetPinchRelativeScale(true);
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x00039CC2 File Offset: 0x000380C2
	public float GetPinchDistVel()
	{
		return this.pinchDistVel;
	}

	// Token: 0x06000948 RID: 2376 RVA: 0x00039CCA File Offset: 0x000380CA
	public bool JustTapped()
	{
		return this.fingerA.JustTapped(false);
	}

	// Token: 0x06000949 RID: 2377 RVA: 0x00039CD8 File Offset: 0x000380D8
	public bool JustMultiTapped()
	{
		return this.justMultiTapped;
	}

	// Token: 0x0600094A RID: 2378 RVA: 0x00039CE0 File Offset: 0x000380E0
	public bool JustSingleTapped()
	{
		return this.fingerA.JustTapped(true);
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x00039CEE File Offset: 0x000380EE
	public bool JustMultiSingleTapped()
	{
		return this.justMultiDelayTapped;
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x00039CF6 File Offset: 0x000380F6
	public bool JustDoubleTapped()
	{
		return this.fingerA.JustDoubleTapped();
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x00039D03 File Offset: 0x00038103
	public bool JustMultiDoubleTapped()
	{
		return this.justMultiDoubleTapped;
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x00039D0B File Offset: 0x0003810B
	public Vector2 GetTapPos(TouchCoordSys cs)
	{
		return this.fingerA.GetTapPos(cs);
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x00039D19 File Offset: 0x00038119
	public Vector2 GetTapPos()
	{
		return this.GetTapPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x00039D22 File Offset: 0x00038122
	public Vector2 GetMultiTapPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.lastMultiTapPos, cs, false);
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x00039D32 File Offset: 0x00038132
	public Vector2 GetMultiTapPos()
	{
		return this.GetMultiTapPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x00039D3C File Offset: 0x0003813C
	public Vector2 GetReleasedStartPos(int fingerId, TouchCoordSys cs)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return this.TransformPos(finger.endedPosStart, cs, false);
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x00039D70 File Offset: 0x00038170
	public Vector2 GetReleasedStartPos(int fingerId)
	{
		return this.GetReleasedStartPos(fingerId, TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x00039D7A File Offset: 0x0003817A
	public Vector2 GetReleasedUniStartPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.endedUniPosStart, cs, false);
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x00039D8A File Offset: 0x0003818A
	public Vector2 GetReleasedUniStartPos()
	{
		return this.GetReleasedUniStartPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x00039D93 File Offset: 0x00038193
	public Vector2 GetReleasedMultiStartPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.endedMultiPosStart, cs, false);
	}

	// Token: 0x06000957 RID: 2391 RVA: 0x00039DA3 File Offset: 0x000381A3
	public Vector2 GetReleasedMultiStartPos()
	{
		return this.GetReleasedMultiStartPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x00039DAC File Offset: 0x000381AC
	public Vector2 GetReleasedEndPos(int fingerId, TouchCoordSys cs)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return this.TransformPos(finger.endedPosEnd, cs, false);
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x00039DE0 File Offset: 0x000381E0
	public Vector2 GetReleasedEndPos(int fingerId)
	{
		return this.GetReleasedEndPos(fingerId, TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x00039DEA File Offset: 0x000381EA
	public Vector2 GetReleasedUniEndPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.endedUniPosEnd, cs, false);
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x00039DFA File Offset: 0x000381FA
	public Vector2 GetReleasedUniEndPos()
	{
		return this.GetReleasedUniEndPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x00039E03 File Offset: 0x00038203
	public Vector2 GetReleasedMultiEndPos(TouchCoordSys cs)
	{
		return this.TransformPos(this.endedMultiPosEnd, cs, false);
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x00039E13 File Offset: 0x00038213
	public Vector2 GetReleasedMultiEndPos()
	{
		return this.GetReleasedMultiEndPos(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x00039E1C File Offset: 0x0003821C
	public bool ReleasedDragged(int fingerId)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.endedMoved;
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x00039E48 File Offset: 0x00038248
	public bool ReleasedUniDragged()
	{
		return this.endedUniMoved;
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x00039E50 File Offset: 0x00038250
	public bool ReleasedMultiDragged()
	{
		return this.endedMultiMoved;
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x00039E58 File Offset: 0x00038258
	public bool ReleasedMoved(int fingerId)
	{
		return this.ReleasedDragged(fingerId);
	}

	// Token: 0x06000962 RID: 2402 RVA: 0x00039E61 File Offset: 0x00038261
	public bool ReleasedUniMoved()
	{
		return this.ReleasedUniDragged();
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x00039E69 File Offset: 0x00038269
	public bool ReleasedMultiMoved()
	{
		return this.ReleasedMultiDragged();
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x00039E74 File Offset: 0x00038274
	public Vector2 GetReleasedDragVec(int fingerId, TouchCoordSys cs, bool raw)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		if (!raw && !finger.endedMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(finger.endedPosEnd - finger.endedPosStart, cs, true);
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x00039ECA File Offset: 0x000382CA
	public Vector2 GetReleasedDragVec(int fingerId)
	{
		return this.GetReleasedDragVec(fingerId, TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x00039ED5 File Offset: 0x000382D5
	public Vector2 GetReleasedDragVec(int fingerId, TouchCoordSys cs)
	{
		return this.GetReleasedDragVec(fingerId, cs, false);
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x00039EE0 File Offset: 0x000382E0
	public Vector2 GetReleasedDragVec(int fingerId, bool raw)
	{
		return this.GetReleasedDragVec(fingerId, TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x00039EEB File Offset: 0x000382EB
	public Vector2 GetReleasedDragVecRaw(int fingerId)
	{
		return this.GetReleasedDragVec(fingerId, TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x00039EF6 File Offset: 0x000382F6
	public Vector2 GetReleasedDragVecRaw(int fingerId, TouchCoordSys cs)
	{
		return this.GetReleasedDragVec(fingerId, cs, true);
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x00039F01 File Offset: 0x00038301
	public Vector2 GetReleasedUniDragVec(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.endedUniMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(this.endedUniTotalDrag, cs, true);
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x00039F28 File Offset: 0x00038328
	public Vector2 GetReleasedUniDragVec()
	{
		return this.GetReleasedUniDragVec(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x00039F32 File Offset: 0x00038332
	public Vector2 GetReleasedUniDragVec(TouchCoordSys cs)
	{
		return this.GetReleasedUniDragVec(cs, false);
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x00039F3C File Offset: 0x0003833C
	public Vector2 GetReleasedUniDragVec(bool raw)
	{
		return this.GetReleasedUniDragVec(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x00039F46 File Offset: 0x00038346
	public Vector2 GetReleasedUniDragVecRaw()
	{
		return this.GetReleasedUniDragVec(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x00039F50 File Offset: 0x00038350
	public Vector2 GetReleasedUniDragVecRaw(TouchCoordSys cs)
	{
		return this.GetReleasedUniDragVec(cs, true);
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x00039F5A File Offset: 0x0003835A
	public Vector2 GetReleasedMultiDragVec(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.endedMultiMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(this.endedMultiPosEnd - this.endedMultiPosStart, cs, true);
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x00039F8C File Offset: 0x0003838C
	public Vector2 GetReleasedMultiDragVec()
	{
		return this.GetReleasedMultiDragVec(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x00039F96 File Offset: 0x00038396
	public Vector2 GetReleasedMultiDragVec(TouchCoordSys cs)
	{
		return this.GetReleasedMultiDragVec(cs, false);
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x00039FA0 File Offset: 0x000383A0
	public Vector2 GetReleasedMultiDragVec(bool raw)
	{
		return this.GetReleasedMultiDragVec(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x00039FAA File Offset: 0x000383AA
	public Vector2 GetReleasedMultiDragVecRaw()
	{
		return this.GetReleasedMultiDragVec(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x00039FB4 File Offset: 0x000383B4
	public Vector2 GetReleasedMultiDragVecRaw(TouchCoordSys cs)
	{
		return this.GetReleasedMultiDragVec(cs, true);
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x00039FC0 File Offset: 0x000383C0
	public float GetReleasedDuration(int fingerId)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		return finger.endedEndTime - finger.endedStartTime;
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x00039FF3 File Offset: 0x000383F3
	public float GetReleasedUniDuration()
	{
		return this.endedUniEndTime - this.endedUniStartTime;
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x0003A002 File Offset: 0x00038402
	public float GetReleasedMultiDuration()
	{
		return this.endedMultiEndTime - this.endedMultiStartTime;
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x0003A014 File Offset: 0x00038414
	public Vector2 GetReleasedDragVel(int fingerId, TouchCoordSys cs, bool raw)
	{
		TouchZone.Finger finger = (fingerId != 1) ? this.fingerA : this.fingerB;
		if (!raw && !finger.endedMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(finger.endedDragVel, cs, true);
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x0003A05F File Offset: 0x0003845F
	public Vector2 GetReleasedDragVel(int fingerId)
	{
		return this.GetReleasedDragVel(fingerId, TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x0003A06A File Offset: 0x0003846A
	public Vector2 GetReleasedDragVel(int fingerId, TouchCoordSys cs)
	{
		return this.GetReleasedDragVel(fingerId, cs, false);
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x0003A075 File Offset: 0x00038475
	public Vector2 GetReleasedDragVel(int fingerId, bool raw)
	{
		return this.GetReleasedDragVel(fingerId, TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x0003A080 File Offset: 0x00038480
	public Vector2 GetReleasedDragVelRaw(int fingerId)
	{
		return this.GetReleasedDragVel(fingerId, TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x0003A08B File Offset: 0x0003848B
	public Vector2 GetReleasedDragVelRaw(int fingerId, TouchCoordSys cs)
	{
		return this.GetReleasedDragVel(fingerId, cs, true);
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x0003A096 File Offset: 0x00038496
	public Vector2 GetReleasedUniDragVel(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.endedUniMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(this.endedUniDragVel, cs, true);
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x0003A0BD File Offset: 0x000384BD
	public Vector2 GetReleasedUniDragVel()
	{
		return this.GetReleasedUniDragVel(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x0003A0C7 File Offset: 0x000384C7
	public Vector2 GetReleasedUniDragVel(TouchCoordSys cs)
	{
		return this.GetReleasedUniDragVel(cs, false);
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x0003A0D1 File Offset: 0x000384D1
	public Vector2 GetReleasedUniDragVel(bool raw)
	{
		return this.GetReleasedUniDragVel(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x0003A0DB File Offset: 0x000384DB
	public Vector2 GetReleasedUniDragVelRaw()
	{
		return this.GetReleasedUniDragVel(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x0003A0E5 File Offset: 0x000384E5
	public Vector2 GetReleasedUniDragVelRaw(TouchCoordSys cs)
	{
		return this.GetReleasedUniDragVel(cs, true);
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x0003A0EF File Offset: 0x000384EF
	public Vector2 GetReleasedMultiDragVel(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.endedMultiMoved)
		{
			return Vector2.zero;
		}
		return this.TransformPos(this.endedMultiDragVel, cs, true);
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x0003A116 File Offset: 0x00038516
	public Vector2 GetReleasedMultiDragVel()
	{
		return this.GetReleasedMultiDragVel(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x0003A120 File Offset: 0x00038520
	public Vector2 GetReleasedMultiDragVel(TouchCoordSys cs)
	{
		return this.GetReleasedMultiDragVel(cs, false);
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x0003A12A File Offset: 0x0003852A
	public Vector2 GetReleasedMultiDragVel(bool raw)
	{
		return this.GetReleasedMultiDragVel(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x0003A134 File Offset: 0x00038534
	public Vector2 GetReleasedMultiDragVelRaw()
	{
		return this.GetReleasedMultiDragVel(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x0003A13E File Offset: 0x0003853E
	public Vector2 GetReleasedMultiDragVelRaw(TouchCoordSys cs)
	{
		return this.GetReleasedMultiDragVel(cs, true);
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x0003A148 File Offset: 0x00038548
	public bool ReleasedTwisted()
	{
		return this.endedTwistMoved;
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x0003A150 File Offset: 0x00038550
	public bool ReleasedTwistMoved()
	{
		return this.ReleasedTwisted();
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x0003A158 File Offset: 0x00038558
	public float GetReleasedTwistAngle(bool raw)
	{
		if (!raw && !this.endedTwistMoved)
		{
			return 0f;
		}
		return this.endedTwistAngle;
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x0003A177 File Offset: 0x00038577
	public float GetReleasedTwistAngle()
	{
		return this.GetReleasedTwistAngle(false);
	}

	// Token: 0x0600098F RID: 2447 RVA: 0x0003A180 File Offset: 0x00038580
	public float GetReleasedTwistAngleRaw()
	{
		return this.GetReleasedTwistAngle(true);
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x0003A189 File Offset: 0x00038589
	public float GetReleasedTwistVel(bool raw)
	{
		if (!raw && !this.endedTwistMoved)
		{
			return 0f;
		}
		return this.endedTwistVel;
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x0003A1A8 File Offset: 0x000385A8
	public float GetReleasedTwistVel()
	{
		return this.GetReleasedTwistVel(false);
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x0003A1B1 File Offset: 0x000385B1
	public float GetReleasedTwistVelRaw()
	{
		return this.GetReleasedTwistVel(true);
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x0003A1BA File Offset: 0x000385BA
	public bool ReleasedPinched()
	{
		return this.endedPinchMoved;
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x0003A1C2 File Offset: 0x000385C2
	public bool ReleasedPinchMoved()
	{
		return this.ReleasedPinched();
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x0003A1CA File Offset: 0x000385CA
	public float GetReleasedPinchScale(bool raw)
	{
		if (!raw && !this.endedPinchMoved)
		{
			return 1f;
		}
		return this.endedPinchDistEnd / this.endedPinchDistStart;
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x0003A1F0 File Offset: 0x000385F0
	public float GetReleasedPinchScale()
	{
		return this.GetReleasedPinchScale(false);
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x0003A1F9 File Offset: 0x000385F9
	public float GetReleasedPinchScaleRaw()
	{
		return this.GetReleasedPinchScale(true);
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x0003A202 File Offset: 0x00038602
	public float GetReleasedPinchStartDist(TouchCoordSys cs)
	{
		return this.TransformPos(this.endedPinchDistStart, cs);
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x0003A211 File Offset: 0x00038611
	public float GetReleasedPinchStartDist()
	{
		return this.GetReleasedPinchStartDist(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x0003A21A File Offset: 0x0003861A
	public float GetReleasedPinchEndDist(TouchCoordSys cs)
	{
		return this.TransformPos(this.endedPinchDistEnd, cs);
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x0003A229 File Offset: 0x00038629
	public float GetReleasedPinchEndDist()
	{
		return this.GetReleasedPinchEndDist(TouchCoordSys.SCREEN_PX);
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x0003A232 File Offset: 0x00038632
	public float GetReleasedPinchDistVel(TouchCoordSys cs, bool raw)
	{
		if (!raw && !this.endedPinchMoved)
		{
			return 0f;
		}
		return this.TransformPos(this.endedPinchDistVel, cs);
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x0003A258 File Offset: 0x00038658
	public float GetReleasedPinchDistVel()
	{
		return this.GetReleasedPinchDistVel(TouchCoordSys.SCREEN_PX, false);
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x0003A262 File Offset: 0x00038662
	public float GetReleasedPinchDistVel(TouchCoordSys cs)
	{
		return this.GetReleasedPinchDistVel(cs, false);
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x0003A26C File Offset: 0x0003866C
	public float GetReleasedPinchDistVel(bool raw)
	{
		return this.GetReleasedPinchDistVel(TouchCoordSys.SCREEN_PX, raw);
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x0003A276 File Offset: 0x00038676
	public float GetReleasedPinchDistVelRaw()
	{
		return this.GetReleasedPinchDistVel(TouchCoordSys.SCREEN_PX, true);
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x0003A280 File Offset: 0x00038680
	public float GetReleasedPinchDistVelRaw(TouchCoordSys cs)
	{
		return this.GetReleasedPinchDistVel(cs, true);
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x0003A28A File Offset: 0x0003868A
	public void TotalTakeover()
	{
		this.joy.EndTouch(this.fingerA.touchId, this);
		this.joy.EndTouch(this.fingerB.touchId, this);
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x0003A2BC File Offset: 0x000386BC
	public override void Enable(bool skipAnimation)
	{
		this.enabled = true;
		this.AnimateParams((!this.overrideScale) ? this.joy.releasedZoneScale : this.releasedScale, TouchController.ScaleAlpha((!this.overrideColors) ? this.joy.defaultReleasedZoneColor : this.releasedColor, (float)((!this.visible) ? 0 : 1)), (!skipAnimation) ? ((!this.overrideAnimDuration) ? this.joy.enableAnimDuration : this.enableAnimDuration) : 0f);
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x0003A364 File Offset: 0x00038764
	public override void Disable(bool skipAnim)
	{
		this.enabled = false;
		this.ReleaseTouches();
		this.AnimateParams((!this.overrideScale) ? this.joy.disabledZoneScale : this.disabledScale, TouchController.ScaleAlpha((!this.overrideColors) ? this.joy.defaultDisabledZoneColor : this.disabledColor, (float)((!this.visible) ? 0 : 1)), (!skipAnim) ? ((!this.overrideAnimDuration) ? this.joy.disableAnimDuration : this.disableAnimDuration) : 0f);
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x0003A410 File Offset: 0x00038810
	public override void Show(bool skipAnim)
	{
		this.visible = true;
		this.AnimateParams((!this.overrideScale) ? ((!this.enabled) ? this.joy.disabledZoneScale : this.joy.releasedZoneScale) : ((!this.enabled) ? this.disabledScale : this.releasedScale), (!this.overrideColors) ? ((!this.enabled) ? this.joy.defaultDisabledZoneColor : this.joy.defaultReleasedZoneColor) : ((!this.enabled) ? this.disabledColor : this.releasedColor), (!skipAnim) ? ((!this.overrideAnimDuration) ? this.joy.showAnimDuration : this.showAnimDuration) : 0f);
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x0003A500 File Offset: 0x00038900
	public override void Hide(bool skipAnim)
	{
		this.visible = false;
		this.ReleaseTouches();
		Color end = this.animColor.end;
		end.a = 0f;
		this.AnimateParams(this.animScale.end, end, (!skipAnim) ? ((!this.overrideAnimDuration) ? this.joy.hideAnimDuration : this.hideAnimDuration) : 0f);
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x0003A578 File Offset: 0x00038978
	public void SetRect(Rect r)
	{
		if (this.screenRectPx != r)
		{
			this.screenRectPx = r;
			this.posPx = r.center;
			if (this.shape == TouchController.ControlShape.CIRCLE)
			{
				this.sizePx.x = (this.sizePx.y = Mathf.Min(r.width, r.height));
			}
			else
			{
				this.sizePx.x = r.width;
				this.sizePx.y = r.height;
			}
			this.OnReset();
		}
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x0003A610 File Offset: 0x00038A10
	public override void ResetRect()
	{
		this.SetRect(this.layoutRectPx);
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x0003A620 File Offset: 0x00038A20
	public Rect GetRect(bool getAutoRect)
	{
		return (!getAutoRect) ? this.screenRectPx : this.layoutRectPx;
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x0003A646 File Offset: 0x00038A46
	public Rect GetRect()
	{
		return this.GetRect(false);
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x0003A650 File Offset: 0x00038A50
	public Rect GetDisplayRect(bool applyScale)
	{
		Rect cenRect = this.screenRectPx;
		if (this.shape == TouchController.ControlShape.CIRCLE || this.shape == TouchController.ControlShape.RECT)
		{
			cenRect = TouchController.GetCenRect(this.posPx, this.sizePx * ((!applyScale) ? 1f : this.animScale.cur));
		}
		return cenRect;
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x0003A6AE File Offset: 0x00038AAE
	public Rect GetDisplayRect()
	{
		return this.GetDisplayRect(true);
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x0003A6B7 File Offset: 0x00038AB7
	public Color GetColor()
	{
		return this.animColor.cur;
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x0003A6C4 File Offset: 0x00038AC4
	public int GetGUIDepth()
	{
		return this.joy.guiDepth + this.guiDepth + ((!this.UniPressed()) ? 0 : this.joy.guiPressedOfs);
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x0003A6F5 File Offset: 0x00038AF5
	public Texture2D GetDisplayTex()
	{
		return (!this.enabled || !this.UniPressed()) ? this.releasedImg : this.pressedImg;
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x0003A720 File Offset: 0x00038B20
	public bool GetKey(KeyCode key)
	{
		bool flag = false;
		return this.GetKeyEx(key, out flag);
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x0003A738 File Offset: 0x00038B38
	public bool GetKeyDown(KeyCode key)
	{
		bool flag = false;
		return this.GetKeyDownEx(key, out flag);
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x0003A750 File Offset: 0x00038B50
	public bool GetKeyUp(KeyCode key)
	{
		bool flag = false;
		return this.GetKeyUpEx(key, out flag);
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x0003A768 File Offset: 0x00038B68
	public bool GetKeyEx(KeyCode key, out bool keySupported)
	{
		keySupported = false;
		if (!this.enableGetKey || key == KeyCode.None)
		{
			return false;
		}
		if (key == this.getKeyCode || key == this.getKeyCodeAlt)
		{
			keySupported = true;
			if (this.UniPressed())
			{
				return true;
			}
		}
		if (key == this.getKeyCodeMulti || key == this.getKeyCodeMultiAlt)
		{
			keySupported = true;
			if (this.MultiPressed())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x0003A7DC File Offset: 0x00038BDC
	public bool GetKeyDownEx(KeyCode key, out bool keySupported)
	{
		keySupported = false;
		if (!this.enableGetKey || key == KeyCode.None)
		{
			return false;
		}
		if (key == this.getKeyCode || key == this.getKeyCodeAlt)
		{
			keySupported = true;
			if (this.JustUniPressed())
			{
				return true;
			}
		}
		if (key == this.getKeyCodeMulti || key == this.getKeyCodeMultiAlt)
		{
			keySupported = true;
			if (this.JustMultiPressed())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x0003A850 File Offset: 0x00038C50
	public bool GetKeyUpEx(KeyCode key, out bool keySupported)
	{
		keySupported = false;
		if (!this.enableGetKey || key == KeyCode.None)
		{
			return false;
		}
		if (key == this.getKeyCode || key == this.getKeyCodeAlt)
		{
			keySupported = true;
			if (this.JustUniReleased())
			{
				return true;
			}
		}
		if (key == this.getKeyCodeMulti || key == this.getKeyCodeMultiAlt)
		{
			keySupported = true;
			if (this.JustMultiReleased())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x0003A8C4 File Offset: 0x00038CC4
	public bool GetButton(string buttonName)
	{
		bool flag = false;
		return this.GetButtonEx(buttonName, out flag);
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x0003A8DC File Offset: 0x00038CDC
	public bool GetButtonDown(string buttonName)
	{
		bool flag = false;
		return this.GetButtonDownEx(buttonName, out flag);
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x0003A8F4 File Offset: 0x00038CF4
	public bool GetButtonUp(string buttonName)
	{
		bool flag = false;
		return this.GetButtonUpEx(buttonName, out flag);
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x0003A90C File Offset: 0x00038D0C
	public bool GetButtonEx(string buttonName, out bool buttonSupported)
	{
		buttonSupported = false;
		if (!this.enableGetButton)
		{
			return false;
		}
		if (buttonName == this.getButtonName)
		{
			buttonSupported = true;
			if (this.UniPressed())
			{
				return true;
			}
		}
		if (buttonName == this.getButtonMultiName)
		{
			buttonSupported = true;
			if (this.MultiPressed())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x0003A96C File Offset: 0x00038D6C
	public bool GetButtonDownEx(string buttonName, out bool buttonSupported)
	{
		buttonSupported = false;
		if (!this.enableGetButton)
		{
			return false;
		}
		if (buttonName == this.getButtonName)
		{
			buttonSupported = true;
			if (this.JustUniPressed())
			{
				return true;
			}
		}
		if (buttonName == this.getButtonMultiName)
		{
			buttonSupported = true;
			if (this.JustMultiPressed())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009BB RID: 2491 RVA: 0x0003A9CC File Offset: 0x00038DCC
	public bool GetButtonUpEx(string buttonName, out bool buttonSupported)
	{
		buttonSupported = false;
		if (!this.enableGetButton)
		{
			return false;
		}
		if (buttonName == this.getButtonName)
		{
			buttonSupported = true;
			if (this.JustUniReleased())
			{
				return true;
			}
		}
		if (buttonName == this.getButtonMultiName)
		{
			buttonSupported = true;
			if (this.JustMultiReleased())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x0003AA2C File Offset: 0x00038E2C
	public float GetAxis(string axisName)
	{
		bool flag = false;
		return this.GetAxisEx(axisName, out flag);
	}

	// Token: 0x060009BD RID: 2493 RVA: 0x0003AA44 File Offset: 0x00038E44
	public float GetAxisEx(string axisName, out bool supported)
	{
		if (this.enableGetAxis)
		{
			if (this.axisHorzName == axisName)
			{
				supported = true;
				return this.GetUniDragDelta(true).x * this.axisValScale * ((!this.axisHorzFlip) ? 1f : -1f);
			}
			if (this.axisVertName == axisName)
			{
				supported = true;
				return this.GetUniDragDelta(true).y * -this.axisValScale * ((!this.axisVertFlip) ? 1f : -1f);
			}
		}
		supported = false;
		return 0f;
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x0003AAF4 File Offset: 0x00038EF4
	public static int GetBoxPortion(int horzSections, int vertSections, Vector2 normalizedPos)
	{
		int num = 0;
		int num2 = 0;
		if (horzSections == 2)
		{
			num = ((normalizedPos.x >= 0.5f) ? 4 : 1);
		}
		else if (horzSections >= 3)
		{
			num = ((normalizedPos.x >= 0.333f) ? ((normalizedPos.x <= 0.666f) ? 2 : 4) : 1);
		}
		if (vertSections == 2)
		{
			num2 = ((normalizedPos.y >= 0.5f) ? 32 : 8);
		}
		else if (vertSections >= 3)
		{
			num2 = ((normalizedPos.y >= 0.333f) ? ((normalizedPos.y <= 0.666f) ? 16 : 32) : 8);
		}
		return num | num2;
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x0003ABC4 File Offset: 0x00038FC4
	public override void Init(TouchController joy)
	{
		base.Init(joy);
		this.joy = joy;
		this.fingerA = new TouchZone.Finger(this);
		this.fingerB = new TouchZone.Finger(this);
		this.AnimateParams((!this.overrideScale) ? this.joy.releasedZoneScale : this.releasedScale, (!this.overrideColors) ? this.joy.defaultReleasedZoneColor : this.releasedColor, 0f);
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

	// Token: 0x060009C0 RID: 2496 RVA: 0x0003AC6E File Offset: 0x0003906E
	public int GetFingerNum()
	{
		return ((!this.fingerA.curState) ? 0 : 1) + ((!this.fingerB.curState) ? 0 : 1);
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x0003ACA0 File Offset: 0x000390A0
	private void AnimateParams(float scale, Color color, float duration)
	{
		if (duration <= 0f)
		{
			this.animTimer.Reset(0f);
			this.animTimer.Disable();
			this.animColor.Reset(color);
			this.animScale.Reset(scale);
		}
		else
		{
			this.animTimer.Start(duration);
			this.animScale.MoveTo(scale);
			this.animColor.MoveTo(color);
		}
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x0003AD14 File Offset: 0x00039114
	public override void OnReset()
	{
		this.fingerA.Reset();
		this.fingerB.Reset();
		this.multiCur = (this.multiPrev = (this.justMultiTapped = (this.justMultiDelayTapped = (this.justMultiDoubleTapped = (this.nextTapCanBeMultiDoubleTap = false)))));
		this.twistMoved = (this.twistJustMoved = (this.pinchMoved = (this.pinchJustMoved = (this.uniMoved = (this.uniJustMoved = (this.uniCur = (this.uniPrev = false)))))));
		this.multiStartTime = (this.lastMultiTapTime = (this.uniStartTime = -100f));
		this.multiPosCur = (this.multiPosPrev = (this.multiPosStart = (this.lastMultiTapPos = Vector2.zero)));
		this.multiDragVel = Vector2.zero;
		this.uniDragVel = Vector2.zero;
		this.twistVel = 0f;
		this.pinchDistVel = 0f;
		this.twistStartAbs = (this.twistCurAbs = (this.twistCur = (this.twistCurRaw = (this.twistPrevAbs = (this.twistPrev = 0f)))));
		this.twistVel = 0f;
		this.pinchDistStart = (this.pinchCurDist = (this.pinchPrevDist = (this.pinchDistVel = 0f)));
		this.uniPosCur = (this.uniPosStart = (this.uniTotalDragCur = (this.uniTotalDragPrev = Vector2.zero)));
		this.touchCanceled = false;
		this.AnimateParams((!this.overrideScale) ? this.joy.releasedZoneScale : this.releasedScale, (!this.overrideColors) ? this.joy.defaultReleasedZoneColor : this.releasedColor, 0f);
		if (!this.enabled)
		{
			this.Disable(true);
		}
		if (!this.visible)
		{
			this.Hide(true);
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x0003AF27 File Offset: 0x00039327
	public override void OnPrePoll()
	{
		this.fingerA.OnPrePoll();
		this.fingerB.OnPrePoll();
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x0003AF40 File Offset: 0x00039340
	public override void OnPostPoll()
	{
		if (this.fingerA.touchId >= 0 && !this.fingerA.touchVerified)
		{
			this.OnTouchEnd(this.fingerA.touchId, false);
		}
		if (this.fingerB.touchId >= 0 && !this.fingerB.touchVerified)
		{
			this.OnTouchEnd(this.fingerB.touchId, false);
		}
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x0003AFB8 File Offset: 0x000393B8
	public override void ReleaseTouches()
	{
		if (this.fingerA.touchId >= 0)
		{
			this.OnTouchEnd(this.fingerA.touchId, true);
		}
		if (this.fingerB.touchId >= 0)
		{
			this.OnTouchEnd(this.fingerB.touchId, true);
		}
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x0003B010 File Offset: 0x00039410
	private void OnMultiStart(Vector2 startPos, Vector2 curPos)
	{
		this.multiCur = true;
		this.multiStartTime = this.joy.curTime;
		this.multiPosStart = startPos;
		this.multiPosCur = curPos;
		this.multiPosPrev = curPos;
		this.multiMoved = false;
		this.multiLastMoveTime = 0f;
		this.multiDragVel = Vector2.zero;
		this.multiExtremeCurVec = Vector2.zero;
		this.multiExtremeCurDist = 0f;
		this.pinchCurDist = (this.pinchPrevDist = (this.pinchDistStart = this.GetFingerDist()));
		this.pinchMoved = false;
		this.pinchJustMoved = false;
		this.pinchLastMoveTime = 0f;
		this.pinchDistVel = 0f;
		this.pinchExtremeCurDist = 0f;
		this.twistCurAbs = (this.twistPrevAbs = (this.twistStartAbs = this.GetFingerAbsAngle(0f)));
		this.twistCur = (this.twistPrev = 0f);
		this.twistMoved = false;
		this.twistJustMoved = false;
		this.twistLastMoveTime = 0f;
		this.twistVel = 0f;
		this.twistExtremeCur = 0f;
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x0003B134 File Offset: 0x00039534
	private void OnMultiEnd(Vector2 endPos)
	{
		this.multiPosCur = endPos;
		this.UpdateMultiTouchState(true);
		this.multiCur = false;
		this.endedMultiStartTime = this.multiStartTime;
		this.endedMultiEndTime = this.joy.curTime;
		this.endedMultiPosEnd = endPos;
		this.endedMultiPosStart = this.multiPosStart;
		this.endedMultiDragVel = this.multiDragVel;
		this.endedTwistAngle = this.twistCur;
		this.endedTwistVel = this.twistVel;
		this.endedPinchDistStart = this.pinchDistStart;
		this.endedPinchDistEnd = this.pinchCurDist;
		this.endedPinchDistVel = this.pinchDistVel;
		this.endedMultiMoved = this.multiMoved;
		this.endedTwistMoved = this.twistMoved;
		this.endedPinchMoved = this.pinchMoved;
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x0003B1F4 File Offset: 0x000395F4
	private void OnUniStart(Vector2 startPos, Vector2 curPos)
	{
		this.uniCur = true;
		this.uniStartTime = this.joy.curTime;
		this.uniPosStart = startPos;
		this.uniPosCur = curPos;
		this.uniMoved = false;
		this.uniJustMoved = false;
		this.uniExtremeDragCurVec = Vector2.zero;
		this.uniExtremeDragCurDist = 0f;
		this.uniDragVel = Vector2.zero;
		this.uniTotalDragPrev = Vector2.zero;
		this.uniTotalDragCur = Vector2.zero;
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x0003B26C File Offset: 0x0003966C
	private void OnUniEnd(Vector2 endPos, Vector2 endDeltaAccum)
	{
		this.uniTotalDragCur += endDeltaAccum;
		this.uniPosCur = endPos;
		this.UpdateUniTouchState(true);
		this.uniCur = false;
		this.endedUniPosEnd = endPos;
		this.endedUniStartTime = this.uniStartTime;
		this.endedUniEndTime = this.joy.curTime;
		this.endedUniDragVel = this.uniDragVel;
		this.endedUniPosStart = this.uniPosStart;
		this.endedUniTotalDrag = this.uniTotalDragCur;
		this.endedUniMoved = this.uniMoved;
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x0003B2F4 File Offset: 0x000396F4
	private void OnPinchStart()
	{
		if (!this.pinchMoved)
		{
			this.pinchMoved = true;
			this.pinchJustMoved = true;
			if (this.startDragWhenPinching)
			{
				this.OnMultiDragStart();
			}
			if (this.startTwistWhenPinching)
			{
				this.OnTwistStart();
			}
		}
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x0003B334 File Offset: 0x00039734
	private void OnTwistStart()
	{
		if (!this.twistMoved)
		{
			this.twistMoved = true;
			this.twistJustMoved = true;
			this.twistStartRaw = this.twistCurRaw;
			this.twistCur = 0f;
			if (this.startDragWhenTwisting)
			{
				this.OnMultiDragStart();
			}
			if (this.startPinchWhenTwisting)
			{
				this.OnPinchStart();
			}
		}
	}

	// Token: 0x060009CC RID: 2508 RVA: 0x0003B393 File Offset: 0x00039793
	private void OnMultiDragStart()
	{
		if (!this.multiMoved)
		{
			this.multiMoved = true;
			this.multiJustMoved = true;
			if (this.startTwistWhenDragging)
			{
				this.OnTwistStart();
			}
			if (this.startPinchWhenDragging)
			{
				this.OnPinchStart();
			}
		}
	}

	// Token: 0x060009CD RID: 2509 RVA: 0x0003B3D0 File Offset: 0x000397D0
	private void UpdateUniTouchState(bool lastUpdateMode = false)
	{
		if (lastUpdateMode)
		{
			return;
		}
		this.uniExtremeDragCurVec.x = Mathf.Max(Mathf.Abs(this.uniTotalDragCur.x), this.uniExtremeDragCurVec.x);
		this.uniExtremeDragCurVec.y = Mathf.Max(Mathf.Abs(this.uniTotalDragCur.y), this.uniExtremeDragCurVec.y);
		this.uniExtremeDragCurDist = Mathf.Max(this.uniTotalDragCur.magnitude, this.uniExtremeDragCurDist);
		this.uniJustMoved = false;
		if (!this.uniMoved && this.uniExtremeDragCurDist > this.joy.touchTapMaxDistPx)
		{
			this.uniMoved = true;
			this.uniJustMoved = true;
		}
		if (this.uniCur)
		{
			if (TouchZone.PxPosEquals(this.uniTotalDragCur, this.uniTotalDragPrev))
			{
				if (this.joy.curTime - this.uniLastMoveTime > this.joy.velPreserveTime)
				{
					this.uniDragVel = Vector2.zero;
				}
			}
			else
			{
				this.uniLastMoveTime = this.joy.curTime;
				this.uniDragVel = (this.uniTotalDragCur - this.uniTotalDragPrev) * this.joy.invDeltaTime;
			}
		}
	}

	// Token: 0x060009CE RID: 2510 RVA: 0x0003B518 File Offset: 0x00039918
	private void UpdateMultiTouchState(bool lastUpdateMode = false)
	{
		if (lastUpdateMode)
		{
			return;
		}
		this.multiJustMoved = false;
		this.pinchJustMoved = false;
		this.twistJustMoved = false;
		if (this.multiCur)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			Vector2 vector = this.multiPosCur - this.multiPosStart;
			this.multiExtremeCurVec.x = Mathf.Max(Mathf.Abs(vector.x), this.multiExtremeCurVec.x);
			this.multiExtremeCurVec.y = Mathf.Max(Mathf.Abs(vector.y), this.multiExtremeCurVec.y);
			this.multiExtremeCurDist = Mathf.Max(vector.magnitude, this.multiExtremeCurDist);
			if (!this.multiMoved && this.multiExtremeCurDist > this.joy.touchTapMaxDistPx)
			{
				flag = true;
			}
			this.pinchJustMoved = false;
			this.pinchCurDist = this.GetFingerDist();
			this.pinchExtremeCurDist = Mathf.Max(Mathf.Abs(this.pinchCurDist - this.pinchDistStart), this.pinchExtremeCurDist);
			if (!this.pinchMoved && this.pinchExtremeCurDist > this.joy.pinchMinDistPx)
			{
				flag2 = true;
			}
			this.twistJustMoved = false;
			this.twistCurAbs = this.GetFingerAbsAngle(this.twistPrevAbs);
			this.twistCurRaw = Mathf.DeltaAngle(this.twistCurAbs, this.twistStartAbs);
			bool flag4 = this.pinchCurDist > this.joy.twistSafeFingerDistPx;
			if (!this.twistMoved && flag4 && Mathf.Abs(this.twistCurRaw) * 0.0174532924f * 2f * this.pinchCurDist > this.joy.pinchMinDistPx)
			{
				flag3 = true;
			}
			if (this.twistMoved && (flag4 || !this.freezeTwistWhenTooClose))
			{
				this.twistCur = this.twistCurRaw - this.twistStartRaw;
				this.twistExtremeCur = Mathf.Max(Mathf.Abs(this.twistCur), this.twistExtremeCur);
			}
			int num = 0;
			switch (this.gestureDetectionOrder)
			{
			case TouchZone.GestureDetectionOrder.TWIST_PINCH_DRAG:
				num = 136;
				break;
			case TouchZone.GestureDetectionOrder.TWIST_DRAG_PINCH:
				num = 80;
				break;
			case TouchZone.GestureDetectionOrder.PINCH_TWIST_DRAG:
				num = 129;
				break;
			case TouchZone.GestureDetectionOrder.PINCH_DRAG_TWIST:
				num = 17;
				break;
			case TouchZone.GestureDetectionOrder.DRAG_TWIST_PINCH:
				num = 66;
				break;
			case TouchZone.GestureDetectionOrder.DRAG_PINCH_TWIST:
				num = 10;
				break;
			}
			for (int i = 0; i < 3; i++)
			{
				int num2 = num >> i * 3 & 7;
				if (num2 != 0)
				{
					if (num2 != 1)
					{
						if (num2 == 2)
						{
							if (this.multiMoved || flag)
							{
								if (this.noTwistAfterDrag)
								{
									flag3 = false;
								}
								if (this.noPinchAfterDrag)
								{
									flag2 = false;
								}
							}
						}
					}
					else if (this.pinchMoved || flag2)
					{
						if (this.noDragAfterPinch)
						{
							flag = false;
						}
						if (this.noTwistAfterPinch)
						{
							flag3 = false;
						}
					}
				}
				else if (this.twistMoved || flag3)
				{
					if (this.noDragAfterTwist)
					{
						flag = false;
					}
					if (this.noPinchAfterTwist)
					{
						flag2 = false;
					}
				}
			}
			if (flag)
			{
				this.OnMultiDragStart();
			}
			if (flag2)
			{
				this.OnPinchStart();
			}
			if (flag3)
			{
				this.OnTwistStart();
			}
		}
		if (this.multiCur)
		{
			if (TouchZone.PxPosEquals(this.multiPosCur, this.multiPosPrev))
			{
				if (this.joy.curTime - this.multiLastMoveTime > this.joy.velPreserveTime)
				{
					this.multiDragVel = Vector2.zero;
				}
			}
			else
			{
				this.multiLastMoveTime = this.joy.curTime;
				this.multiDragVel = (this.multiPosCur - this.multiPosPrev) * this.joy.invDeltaTime;
			}
			if (TouchZone.PxDistEquals(this.pinchCurDist, this.pinchPrevDist))
			{
				if (this.joy.curTime - this.pinchLastMoveTime > this.joy.velPreserveTime)
				{
					this.pinchDistVel = 0f;
				}
			}
			else
			{
				this.pinchLastMoveTime = this.joy.curTime;
				this.pinchDistVel = (this.pinchCurDist - this.pinchPrevDist) * this.joy.invDeltaTime;
			}
			if (TouchZone.TwistAngleEquals(this.twistCur, this.twistPrev))
			{
				if (this.joy.curTime - this.twistLastMoveTime > this.joy.velPreserveTime)
				{
					this.twistVel = 0f;
				}
			}
			else
			{
				this.twistLastMoveTime = this.joy.curTime;
				this.twistVel = (this.twistCur - this.twistPrev) * this.joy.invDeltaTime;
			}
		}
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x0003B9F4 File Offset: 0x00039DF4
	public override void OnUpdate(bool firstUpdate)
	{
		this.fingerA.PreUpdate(firstUpdate);
		this.fingerB.PreUpdate(firstUpdate);
		this.uniPrev = this.uniCur;
		this.uniTotalDragPrev = this.uniTotalDragCur;
		this.uniMidFramePressed = false;
		this.uniMidFrameReleased = false;
		if (this.uniCur && this.pollUniReleasedInitial)
		{
			this.OnUniEnd(this.pollUniPosEnd, this.pollUniDeltaAccumAtEnd);
		}
		if (this.pollUniTouched)
		{
			this.OnUniStart(this.pollUniPosStart, this.pollUniPosCur);
		}
		if ((this.fingerA.touchId >= 0 || this.fingerB.touchId >= 0) != this.uniCur)
		{
			if (this.uniCur)
			{
				this.OnUniEnd(this.pollUniPosEnd, this.pollUniDeltaAccumAtEnd);
			}
			else
			{
				this.OnUniStart(this.pollUniPosStart, this.pollUniPosCur);
			}
		}
		this.uniMidFramePressed = (!this.pollUniInitialState && this.pollUniTouched && !this.uniCur);
		this.uniMidFrameReleased = (this.pollUniInitialState && this.pollUniReleasedInitial && this.uniCur);
		if (this.uniCur)
		{
			this.uniPosCur = this.pollUniPosCur;
		}
		this.uniTotalDragCur += this.pollUniDeltaAccum;
		this.UpdateUniTouchState(false);
		this.pollUniReleasedInitial = false;
		this.pollUniReleased = false;
		this.pollUniTouched = false;
		this.pollUniInitialState = this.uniCur;
		this.pollUniPosCur = (this.pollUniPosPrev = (this.pollUniPosStart = (this.pollUniPosEnd = this.uniPosCur)));
		this.pollUniWaitForDblStart = false;
		this.pollUniWaitForDblEnd = false;
		this.pollUniDeltaAccum = (this.pollUniDblEndPos = (this.pollUniDeltaAccumAtEnd = Vector2.zero));
		this.multiPrev = this.multiCur;
		this.multiPosPrev = this.multiPosCur;
		this.pinchPrevDist = this.pinchCurDist;
		this.twistPrevAbs = this.twistCurAbs;
		this.twistPrev = this.twistCur;
		this.multiMidFramePressed = false;
		this.multiMidFrameReleased = false;
		if (this.multiCur && this.pollMultiReleasedInitial)
		{
			this.OnMultiEnd(this.pollMultiPosEnd);
		}
		if (this.pollMultiTouched)
		{
			this.OnMultiStart(this.pollMultiPosStart, this.pollMultiPosCur);
		}
		if ((this.fingerA.touchId >= 0 && this.fingerB.touchId >= 0) != this.multiCur)
		{
			if (this.multiCur)
			{
				this.OnMultiEnd(this.pollMultiPosEnd);
			}
			else
			{
				this.OnMultiStart(this.pollMultiPosStart, this.pollMultiPosCur);
			}
		}
		this.multiMidFramePressed = (!this.pollMultiInitialState && this.pollMultiTouched && !this.multiCur);
		this.multiMidFrameReleased = (this.pollMultiInitialState && this.pollMultiReleasedInitial && this.multiCur);
		if (this.multiCur)
		{
			this.multiPosCur = this.pollMultiPosCur;
		}
		this.UpdateMultiTouchState(false);
		this.pollMultiReleasedInitial = false;
		this.pollMultiReleased = false;
		this.pollMultiTouched = false;
		this.pollMultiInitialState = this.multiCur;
		this.pollMultiPosCur = (this.pollMultiPosStart = (this.pollMultiPosEnd = this.multiPosCur));
		this.justMultiDoubleTapped = false;
		this.justMultiTapped = false;
		this.justMultiDelayTapped = false;
		if (this.JustMultiReleased(true, true))
		{
			if (!this.endedMultiMoved && this.endedMultiEndTime - this.endedMultiStartTime <= this.joy.touchTapMaxTime)
			{
				bool flag = this.nextTapCanBeMultiDoubleTap && this.endedMultiStartTime - this.lastMultiTapTime <= this.joy.doubleTapMaxGapTime;
				this.waitForMultiDelyedTap = !flag;
				this.justMultiDoubleTapped = flag;
				this.justMultiTapped = true;
				this.lastMultiTapPos = this.endedMultiPosStart;
				this.lastMultiTapTime = this.joy.curTime;
				this.nextTapCanBeMultiDoubleTap = !flag;
				this.fingerA.CancelTap();
				this.fingerB.CancelTap();
			}
			else
			{
				this.waitForMultiDelyedTap = false;
				this.nextTapCanBeMultiDoubleTap = false;
			}
		}
		else if (this.JustMultiPressed(true, true))
		{
			this.waitForMultiDelyedTap = false;
		}
		else if (this.waitForMultiDelyedTap && this.joy.curTime - this.lastMultiTapTime > this.joy.doubleTapMaxGapTime)
		{
			this.justMultiDelayTapped = true;
			this.waitForMultiDelyedTap = false;
			this.nextTapCanBeMultiDoubleTap = true;
		}
		if (this.emulateMouse)
		{
			this.joy.SetInternalMousePos((!this.mousePosFromFirstFinger) ? this.GetUniPos(TouchCoordSys.SCREEN_PX) : this.GetPos(0, TouchCoordSys.SCREEN_PX), true);
		}
		if (this.uniCur != this.uniPrev && this.enabled)
		{
			if (this.uniCur)
			{
				this.AnimateParams((!this.overrideScale) ? this.joy.pressedZoneScale : this.pressedScale, (!this.overrideColors) ? this.joy.defaultPressedZoneColor : this.pressedColor, (!this.overrideAnimDuration) ? this.joy.pressAnimDuration : this.pressAnimDuration);
			}
			else
			{
				this.AnimateParams((!this.overrideScale) ? this.joy.releasedZoneScale : this.releasedScale, (!this.overrideColors) ? this.joy.defaultReleasedZoneColor : this.releasedColor, (!this.touchCanceled) ? ((!this.overrideAnimDuration) ? this.joy.releaseAnimDuration : this.releaseAnimDuration) : this.joy.cancelAnimDuration);
			}
		}
		if (this.animTimer.Enabled)
		{
			this.animTimer.Update(this.joy.deltaTime);
			float lerpt = TouchController.SlowDownEase(this.animTimer.Nt);
			this.animColor.Update(lerpt);
			this.animScale.Update(lerpt);
			if (this.animTimer.Completed)
			{
				this.animTimer.Disable();
			}
		}
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x0003C065 File Offset: 0x0003A465
	public override void OnPostUpdate(bool firstUpdate)
	{
		this.fingerA.PostUpdate(firstUpdate);
		this.fingerB.PostUpdate(firstUpdate);
	}

	// Token: 0x060009D1 RID: 2513 RVA: 0x0003C080 File Offset: 0x0003A480
	public override void OnLayoutAddContent()
	{
		if (this.shape == TouchController.ControlShape.SCREEN_REGION)
		{
			return;
		}
		TouchController.LayoutBox layoutBox = this.joy.layoutBoxes[this.layoutBoxId];
		TouchController.ControlShape controlShape = this.shape;
		if (controlShape != TouchController.ControlShape.CIRCLE)
		{
			if (controlShape == TouchController.ControlShape.RECT)
			{
				layoutBox.AddContent(this.posCm, this.sizeCm);
			}
		}
		else
		{
			layoutBox.AddContent(this.posCm, this.sizeCm.x);
		}
	}

	// Token: 0x060009D2 RID: 2514 RVA: 0x0003C0FC File Offset: 0x0003A4FC
	public override void OnLayout()
	{
		TouchController.ControlShape controlShape = this.shape;
		if (controlShape != TouchController.ControlShape.CIRCLE && controlShape != TouchController.ControlShape.RECT)
		{
			if (controlShape == TouchController.ControlShape.SCREEN_REGION)
			{
				this.layoutRectPx = this.joy.NormalizedRectToPx(this.regionRect, true);
				this.layoutPosPx = this.layoutRectPx.center;
				this.layoutSizePx.x = this.layoutRectPx.width;
				this.layoutSizePx.y = this.layoutRectPx.height;
				this.screenRectPx = this.layoutRectPx;
			}
		}
		else
		{
			TouchController.LayoutBox layoutBox = this.joy.layoutBoxes[this.layoutBoxId];
			this.layoutPosPx = layoutBox.GetScreenPos(this.posCm);
			this.layoutSizePx = layoutBox.GetScreenSize(this.sizeCm);
			this.layoutRectPx = new Rect(this.layoutPosPx.x - 0.5f * this.layoutSizePx.x, this.layoutPosPx.y - 0.5f * this.layoutSizePx.y, this.layoutSizePx.x, this.layoutSizePx.y);
		}
		this.posPx = this.layoutPosPx;
		this.sizePx = this.layoutSizePx;
		this.screenRectPx = this.layoutRectPx;
		this.OnReset();
	}

	// Token: 0x060009D3 RID: 2515 RVA: 0x0003C250 File Offset: 0x0003A650
	public override void DrawGUI()
	{
		if (this.disableGui)
		{
			return;
		}
		bool flag = this.UniPressed(true, false);
		Texture2D texture2D = (!flag) ? this.releasedImg : this.pressedImg;
		if (texture2D != null)
		{
			GUI.depth = this.joy.guiDepth + this.guiDepth + ((!flag) ? 0 : this.joy.guiPressedOfs);
			Rect displayRect = this.GetDisplayRect(true);
			GUI.color = TouchController.ScaleAlpha(this.animColor.cur, this.joy.GetAlpha());
			GUI.DrawTexture(displayRect, texture2D);
		}
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x0003C2F4 File Offset: 0x0003A6F4
	public override void TakeoverTouches(TouchableControl controlToUntouch)
	{
		if (controlToUntouch != null)
		{
			if (this.fingerA.touchId >= 0)
			{
				controlToUntouch.OnTouchEnd(this.fingerA.touchId, true);
			}
			if (this.fingerB.touchId >= 0)
			{
				controlToUntouch.OnTouchEnd(this.fingerB.touchId, true);
			}
		}
	}

	// Token: 0x060009D5 RID: 2517 RVA: 0x0003C350 File Offset: 0x0003A750
	public bool MultiTouchPossible()
	{
		return this.enableSecondFinger && this.fingerA.touchId >= 0 && this.fingerB.touchId < 0 && (!this.strictTwoFingerStart || this.joy.curTime - this.fingerA.startTime < this.joy.strictMultiFingerMaxTime);
	}

	// Token: 0x060009D6 RID: 2518 RVA: 0x0003C3C0 File Offset: 0x0003A7C0
	public override TouchController.HitTestResult HitTest(Vector2 touchPos, int touchId)
	{
		if (!this.enabled || !this.visible || (this.fingerA.touchId >= 0 && (!this.enableSecondFinger || this.fingerB.touchId >= 0 || (this.strictTwoFingerStart && !this.fingerA.pollTouched && this.joy.curTime - this.fingerA.startTime > this.joy.strictMultiFingerMaxTime))) || touchId == this.fingerA.touchId || touchId == this.fingerB.touchId)
		{
			return new TouchController.HitTestResult(false);
		}
		TouchController.HitTestResult result;
		switch (this.shape)
		{
		case TouchController.ControlShape.CIRCLE:
			result = this.joy.HitTestCircle(this.posPx, 0.5f * this.sizePx.x, touchPos, true);
			break;
		case TouchController.ControlShape.RECT:
			result = this.joy.HitTestBox(this.posPx, this.sizePx, touchPos, true);
			break;
		case TouchController.ControlShape.SCREEN_REGION:
			result = this.joy.HitTestRect(this.screenRectPx, touchPos, true);
			break;
		default:
			result = new TouchController.HitTestResult(false);
			break;
		}
		result.prio = this.prio;
		result.distScale = this.hitDistScale;
		return result;
	}

	// Token: 0x060009D7 RID: 2519 RVA: 0x0003C524 File Offset: 0x0003A924
	public override TouchController.EventResult OnTouchStart(int touchId, Vector2 pos)
	{
		TouchZone.Finger finger = (this.fingerA.touchId >= 0) ? ((this.fingerB.touchId >= 0) ? null : this.fingerB) : this.fingerA;
		if (finger == null)
		{
			return TouchController.EventResult.NOT_HANDLED;
		}
		this.touchCanceled = false;
		TouchZone.Finger finger2 = (finger != this.fingerA) ? this.fingerA : this.fingerB;
		finger.touchId = touchId;
		finger.touchVerified = true;
		finger.touchPos = pos;
		finger.pollTouched = true;
		finger.pollPosStart = pos;
		finger.pollPosCur = pos;
		if (finger2.touchId < 0)
		{
			this.pollUniTouched = true;
			this.pollUniPosStart = pos;
			this.pollUniPosCur = pos;
			this.pollUniWaitForDblStart = true;
			this.pollUniWaitForDblEnd = false;
			this.pollUniDeltaAccum = Vector2.zero;
		}
		else
		{
			finger2.CancelTap();
			this.pollMultiTouched = true;
			this.pollMultiPosStart = (this.pollMultiPosCur = (this.fingerA.pollPosCur + this.fingerB.pollPosCur) / 2f);
			this.pollUniPosCur = this.pollMultiPosCur;
			if (this.pollUniWaitForDblStart)
			{
				this.pollUniPosStart = this.pollUniPosCur;
				this.pollUniWaitForDblStart = false;
				this.pollUniWaitForDblEnd = true;
			}
		}
		this.pollUniPosPrev = this.pollUniPosCur;
		return (!this.nonExclusiveTouches) ? TouchController.EventResult.HANDLED : TouchController.EventResult.SHARED;
	}

	// Token: 0x060009D8 RID: 2520 RVA: 0x0003C694 File Offset: 0x0003AA94
	public override TouchController.EventResult OnTouchEnd(int touchId, bool canceled = false)
	{
		TouchZone.Finger finger = (this.fingerA.touchId != touchId) ? ((this.fingerB.touchId != touchId) ? null : this.fingerB) : this.fingerA;
		if (finger == null)
		{
			return TouchController.EventResult.NOT_HANDLED;
		}
		TouchZone.Finger finger2 = (finger != this.fingerA) ? this.fingerA : this.fingerB;
		finger.touchId = -1;
		finger.touchVerified = true;
		if (!finger.pollReleased)
		{
			finger.pollReleased = true;
			finger.pollPosEnd = finger.pollPosCur;
			if (finger.pollInitialState)
			{
				finger.pollReleasedInitial = true;
			}
		}
		finger.pollTouched = false;
		if (finger2.touchId >= 0)
		{
			this.pollUniPosCur = finger2.pollPosCur;
			this.pollUniWaitForDblEnd = true;
			this.pollUniDblEndPos = (this.fingerA.pollPosCur + this.fingerB.pollPosCur) / 2f;
		}
		else
		{
			if (!this.pollUniReleased)
			{
				this.pollUniReleased = true;
				if (this.pollUniWaitForDblEnd)
				{
					this.pollUniPosEnd = this.pollUniDblEndPos;
					this.pollUniWaitForDblEnd = false;
				}
				else
				{
					this.pollUniPosEnd = this.pollUniPosCur;
				}
				this.pollUniDeltaAccumAtEnd = this.pollUniDeltaAccum;
				this.pollUniDeltaAccum = Vector2.zero;
				if (this.pollUniInitialState)
				{
					this.pollUniReleasedInitial = true;
				}
			}
			this.pollUniTouched = false;
		}
		this.pollUniPosPrev = this.pollUniPosCur;
		if (finger2.touchId >= 0)
		{
			if (!this.pollMultiReleased)
			{
				this.pollMultiReleased = true;
				this.pollMultiPosEnd = this.pollMultiPosCur;
				if (this.pollMultiInitialState)
				{
					this.pollMultiReleasedInitial = true;
				}
			}
			this.pollMultiTouched = false;
		}
		return (!this.nonExclusiveTouches) ? TouchController.EventResult.HANDLED : TouchController.EventResult.SHARED;
	}

	// Token: 0x060009D9 RID: 2521 RVA: 0x0003C868 File Offset: 0x0003AC68
	public override TouchController.EventResult OnTouchMove(int touchId, Vector2 pos)
	{
		TouchZone.Finger finger = (this.fingerA.touchId != touchId) ? ((this.fingerB.touchId != touchId) ? null : this.fingerB) : this.fingerA;
		if (finger == null)
		{
			return TouchController.EventResult.NOT_HANDLED;
		}
		TouchZone.Finger finger2 = (finger != this.fingerA) ? this.fingerA : this.fingerB;
		finger.touchVerified = true;
		finger.pollPosCur = pos;
		if (finger2.touchId >= 0)
		{
			this.pollMultiPosCur = (this.fingerA.pollPosCur + this.fingerB.pollPosCur) / 2f;
			this.pollUniPosCur = this.pollMultiPosCur;
		}
		else
		{
			this.pollUniPosCur = pos;
		}
		if (this.pollUniPosCur != this.pollUniPosPrev)
		{
			this.pollUniWaitForDblEnd = false;
			this.pollUniWaitForDblStart = false;
			this.pollUniDeltaAccum += this.pollUniPosCur - this.pollUniPosPrev;
			this.pollUniPosPrev = this.pollUniPosCur;
		}
		return (!this.nonExclusiveTouches) ? TouchController.EventResult.HANDLED : TouchController.EventResult.SHARED;
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x0003C996 File Offset: 0x0003AD96
	private Vector2 GetCenterPos()
	{
		return (this.fingerA.posCur + this.fingerB.posCur) * 0.5f;
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x0003C9BD File Offset: 0x0003ADBD
	private float GetFingerDist()
	{
		return Mathf.Max(2f, Vector2.Distance(this.fingerA.posCur, this.fingerB.posCur));
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x0003C9E4 File Offset: 0x0003ADE4
	private float GetFingerAbsAngle(float lastAngle = 0f)
	{
		Vector2 vector = this.fingerB.posCur - this.fingerA.posCur;
		if (vector.sqrMagnitude < 1E-05f)
		{
			return lastAngle;
		}
		vector.Normalize();
		return Mathf.Atan2(vector.y, vector.x) * 57.29578f;
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x0003CA40 File Offset: 0x0003AE40
	private Vector2 TransformPos(Vector2 screenPosPx, TouchCoordSys posType, bool deltaMode)
	{
		Vector2 vector = screenPosPx;
		if (!deltaMode && (posType == TouchCoordSys.LOCAL_CM || posType == TouchCoordSys.LOCAL_INCH || posType == TouchCoordSys.LOCAL_NORMALIZED || posType == TouchCoordSys.LOCAL_PX))
		{
			vector.x -= this.screenRectPx.xMin;
			vector.y -= this.screenRectPx.yMin;
		}
		switch (posType)
		{
		case TouchCoordSys.SCREEN_PX:
		case TouchCoordSys.LOCAL_PX:
			return vector;
		case TouchCoordSys.SCREEN_NORMALIZED:
			vector.x /= this.joy.GetScreenWidth();
			vector.y /= this.joy.GetScreenHeight();
			return vector;
		case TouchCoordSys.SCREEN_CM:
		case TouchCoordSys.LOCAL_CM:
			return vector / this.joy.GetDPCM();
		case TouchCoordSys.SCREEN_INCH:
		case TouchCoordSys.LOCAL_INCH:
			return vector / this.joy.GetDPI();
		case TouchCoordSys.LOCAL_NORMALIZED:
			vector.x /= this.screenRectPx.width;
			vector.y /= this.screenRectPx.height;
			return vector;
		default:
			return vector;
		}
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x0003CB60 File Offset: 0x0003AF60
	private float TransformPos(float screenPosPx, TouchCoordSys posType)
	{
		switch (posType)
		{
		case TouchCoordSys.SCREEN_PX:
		case TouchCoordSys.LOCAL_PX:
			return screenPosPx;
		case TouchCoordSys.SCREEN_NORMALIZED:
			return screenPosPx / Mathf.Max(this.joy.GetScreenWidth(), this.joy.GetScreenHeight());
		case TouchCoordSys.SCREEN_CM:
		case TouchCoordSys.LOCAL_CM:
			return screenPosPx / this.joy.GetDPCM();
		case TouchCoordSys.SCREEN_INCH:
		case TouchCoordSys.LOCAL_INCH:
			return screenPosPx / this.joy.GetDPI();
		case TouchCoordSys.LOCAL_NORMALIZED:
			return screenPosPx / this.screenRectPx.width;
		default:
			return screenPosPx;
		}
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x0003CBEC File Offset: 0x0003AFEC
	private float TransformPosX(float screenPosPx, TouchCoordSys posType)
	{
		switch (posType)
		{
		case TouchCoordSys.SCREEN_PX:
		case TouchCoordSys.LOCAL_PX:
			return screenPosPx;
		case TouchCoordSys.SCREEN_NORMALIZED:
			return screenPosPx / this.joy.GetScreenWidth();
		case TouchCoordSys.SCREEN_CM:
		case TouchCoordSys.LOCAL_CM:
			return screenPosPx / this.joy.GetDPCM();
		case TouchCoordSys.SCREEN_INCH:
		case TouchCoordSys.LOCAL_INCH:
			return screenPosPx / this.joy.GetDPI();
		case TouchCoordSys.LOCAL_NORMALIZED:
			return screenPosPx / this.screenRectPx.width;
		default:
			return screenPosPx;
		}
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x0003CC68 File Offset: 0x0003B068
	private float TransformPosY(float screenPosPx, TouchCoordSys posType)
	{
		switch (posType)
		{
		case TouchCoordSys.SCREEN_PX:
		case TouchCoordSys.LOCAL_PX:
			return screenPosPx;
		case TouchCoordSys.SCREEN_NORMALIZED:
			return screenPosPx / this.joy.GetScreenHeight();
		case TouchCoordSys.SCREEN_CM:
		case TouchCoordSys.LOCAL_CM:
			return screenPosPx / this.joy.GetDPCM();
		case TouchCoordSys.SCREEN_INCH:
		case TouchCoordSys.LOCAL_INCH:
			return screenPosPx / this.joy.GetDPI();
		case TouchCoordSys.LOCAL_NORMALIZED:
			return screenPosPx / this.screenRectPx.height;
		default:
			return screenPosPx;
		}
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x0003CCE4 File Offset: 0x0003B0E4
	public static bool PxPosEquals(Vector2 p0, Vector2 p1)
	{
		return (p0 - p1).sqrMagnitude < 0.1f;
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x0003CD07 File Offset: 0x0003B107
	public static bool PxDistEquals(float d0, float d1)
	{
		return Mathf.Abs(d0 - d1) < 0.1f;
	}

	// Token: 0x060009E3 RID: 2531 RVA: 0x0003CD18 File Offset: 0x0003B118
	public static bool TwistAngleEquals(float a0, float a1)
	{
		return Mathf.Abs(Mathf.DeltaAngle(a0, a1)) < 0.5f;
	}

	// Token: 0x0400081C RID: 2076
	public TouchController.ControlShape shape;

	// Token: 0x0400081D RID: 2077
	public Vector2 posCm;

	// Token: 0x0400081E RID: 2078
	public Vector2 sizeCm;

	// Token: 0x0400081F RID: 2079
	public Rect regionRect;

	// Token: 0x04000820 RID: 2080
	private Vector2 posPx;

	// Token: 0x04000821 RID: 2081
	private Vector2 sizePx;

	// Token: 0x04000822 RID: 2082
	private Vector2 layoutPosPx;

	// Token: 0x04000823 RID: 2083
	private Vector2 layoutSizePx;

	// Token: 0x04000824 RID: 2084
	private Rect screenRectPx;

	// Token: 0x04000825 RID: 2085
	private Rect layoutRectPx;

	// Token: 0x04000826 RID: 2086
	public bool enableSecondFinger;

	// Token: 0x04000827 RID: 2087
	public bool nonExclusiveTouches;

	// Token: 0x04000828 RID: 2088
	public bool strictTwoFingerStart;

	// Token: 0x04000829 RID: 2089
	public bool freezeTwistWhenTooClose;

	// Token: 0x0400082A RID: 2090
	public bool noPinchAfterDrag;

	// Token: 0x0400082B RID: 2091
	public bool noPinchAfterTwist;

	// Token: 0x0400082C RID: 2092
	public bool noTwistAfterDrag;

	// Token: 0x0400082D RID: 2093
	public bool noTwistAfterPinch;

	// Token: 0x0400082E RID: 2094
	public bool noDragAfterPinch;

	// Token: 0x0400082F RID: 2095
	public bool noDragAfterTwist;

	// Token: 0x04000830 RID: 2096
	public bool startPinchWhenTwisting;

	// Token: 0x04000831 RID: 2097
	public bool startPinchWhenDragging;

	// Token: 0x04000832 RID: 2098
	public bool startDragWhenPinching;

	// Token: 0x04000833 RID: 2099
	public bool startDragWhenTwisting;

	// Token: 0x04000834 RID: 2100
	public bool startTwistWhenDragging;

	// Token: 0x04000835 RID: 2101
	public bool startTwistWhenPinching;

	// Token: 0x04000836 RID: 2102
	public TouchZone.GestureDetectionOrder gestureDetectionOrder;

	// Token: 0x04000837 RID: 2103
	public KeyCode debugKey;

	// Token: 0x04000838 RID: 2104
	public Texture2D releasedImg;

	// Token: 0x04000839 RID: 2105
	public Texture2D pressedImg;

	// Token: 0x0400083A RID: 2106
	public bool overrideScale;

	// Token: 0x0400083B RID: 2107
	public float releasedScale;

	// Token: 0x0400083C RID: 2108
	public float pressedScale;

	// Token: 0x0400083D RID: 2109
	public float disabledScale;

	// Token: 0x0400083E RID: 2110
	public bool overrideColors;

	// Token: 0x0400083F RID: 2111
	public Color releasedColor;

	// Token: 0x04000840 RID: 2112
	public Color pressedColor;

	// Token: 0x04000841 RID: 2113
	public Color disabledColor;

	// Token: 0x04000842 RID: 2114
	public bool overrideAnimDuration;

	// Token: 0x04000843 RID: 2115
	public float pressAnimDuration;

	// Token: 0x04000844 RID: 2116
	public float releaseAnimDuration;

	// Token: 0x04000845 RID: 2117
	public float disableAnimDuration;

	// Token: 0x04000846 RID: 2118
	public float enableAnimDuration;

	// Token: 0x04000847 RID: 2119
	public float showAnimDuration;

	// Token: 0x04000848 RID: 2120
	public float hideAnimDuration;

	// Token: 0x04000849 RID: 2121
	private AnimTimer animTimer;

	// Token: 0x0400084A RID: 2122
	private TouchController.AnimFloat animScale;

	// Token: 0x0400084B RID: 2123
	private TouchController.AnimColor animColor;

	// Token: 0x0400084C RID: 2124
	private TouchZone.Finger fingerA;

	// Token: 0x0400084D RID: 2125
	private TouchZone.Finger fingerB;

	// Token: 0x0400084E RID: 2126
	private bool multiCur;

	// Token: 0x0400084F RID: 2127
	private bool multiPrev;

	// Token: 0x04000850 RID: 2128
	private bool multiMoved;

	// Token: 0x04000851 RID: 2129
	private bool multiJustMoved;

	// Token: 0x04000852 RID: 2130
	private bool multiMidFrameReleased;

	// Token: 0x04000853 RID: 2131
	private bool multiMidFramePressed;

	// Token: 0x04000854 RID: 2132
	private float multiStartTime;

	// Token: 0x04000855 RID: 2133
	private Vector2 multiPosCur;

	// Token: 0x04000856 RID: 2134
	private Vector2 multiPosPrev;

	// Token: 0x04000857 RID: 2135
	private Vector2 multiPosStart;

	// Token: 0x04000858 RID: 2136
	private float multiExtremeCurDist;

	// Token: 0x04000859 RID: 2137
	private Vector2 multiExtremeCurVec;

	// Token: 0x0400085A RID: 2138
	private float multiLastMoveTime;

	// Token: 0x0400085B RID: 2139
	private Vector2 multiDragVel;

	// Token: 0x0400085C RID: 2140
	private bool justMultiTapped;

	// Token: 0x0400085D RID: 2141
	private bool justMultiDoubleTapped;

	// Token: 0x0400085E RID: 2142
	private bool justMultiDelayTapped;

	// Token: 0x0400085F RID: 2143
	private bool waitForMultiDelyedTap;

	// Token: 0x04000860 RID: 2144
	private float lastMultiTapTime;

	// Token: 0x04000861 RID: 2145
	private bool nextTapCanBeMultiDoubleTap;

	// Token: 0x04000862 RID: 2146
	private Vector2 lastMultiTapPos;

	// Token: 0x04000863 RID: 2147
	[NonSerialized]
	private float twistStartAbs;

	// Token: 0x04000864 RID: 2148
	[NonSerialized]
	private float twistCurAbs;

	// Token: 0x04000865 RID: 2149
	[NonSerialized]
	private float twistPrevAbs;

	// Token: 0x04000866 RID: 2150
	[NonSerialized]
	private float twistCur;

	// Token: 0x04000867 RID: 2151
	[NonSerialized]
	private float twistPrev;

	// Token: 0x04000868 RID: 2152
	[NonSerialized]
	private float twistCurRaw;

	// Token: 0x04000869 RID: 2153
	[NonSerialized]
	private float twistStartRaw;

	// Token: 0x0400086A RID: 2154
	[NonSerialized]
	private float twistExtremeCur;

	// Token: 0x0400086B RID: 2155
	[NonSerialized]
	private float twistLastMoveTime;

	// Token: 0x0400086C RID: 2156
	[NonSerialized]
	private float twistVel;

	// Token: 0x0400086D RID: 2157
	[NonSerialized]
	private float pinchDistStart;

	// Token: 0x0400086E RID: 2158
	[NonSerialized]
	private float pinchCurDist;

	// Token: 0x0400086F RID: 2159
	[NonSerialized]
	private float pinchPrevDist;

	// Token: 0x04000870 RID: 2160
	[NonSerialized]
	private float pinchExtremeCurDist;

	// Token: 0x04000871 RID: 2161
	[NonSerialized]
	private float pinchLastMoveTime;

	// Token: 0x04000872 RID: 2162
	[NonSerialized]
	private float pinchDistVel;

	// Token: 0x04000873 RID: 2163
	private bool endedMultiMoved;

	// Token: 0x04000874 RID: 2164
	private bool endedTwistMoved;

	// Token: 0x04000875 RID: 2165
	private bool endedPinchMoved;

	// Token: 0x04000876 RID: 2166
	private float endedMultiStartTime;

	// Token: 0x04000877 RID: 2167
	private float endedMultiEndTime;

	// Token: 0x04000878 RID: 2168
	private float endedPinchDistStart;

	// Token: 0x04000879 RID: 2169
	private float endedPinchDistEnd;

	// Token: 0x0400087A RID: 2170
	private float endedPinchDistVel;

	// Token: 0x0400087B RID: 2171
	private float endedTwistAngle;

	// Token: 0x0400087C RID: 2172
	private float endedTwistVel;

	// Token: 0x0400087D RID: 2173
	private Vector2 endedMultiPosStart;

	// Token: 0x0400087E RID: 2174
	private Vector2 endedMultiPosEnd;

	// Token: 0x0400087F RID: 2175
	private Vector2 endedMultiDragVel;

	// Token: 0x04000880 RID: 2176
	private bool pollMultiInitialState;

	// Token: 0x04000881 RID: 2177
	private bool pollMultiReleasedInitial;

	// Token: 0x04000882 RID: 2178
	private bool pollMultiTouched;

	// Token: 0x04000883 RID: 2179
	private bool pollMultiReleased;

	// Token: 0x04000884 RID: 2180
	private Vector2 pollMultiPosEnd;

	// Token: 0x04000885 RID: 2181
	private Vector2 pollMultiPosStart;

	// Token: 0x04000886 RID: 2182
	private Vector2 pollMultiPosCur;

	// Token: 0x04000887 RID: 2183
	private bool twistMoved;

	// Token: 0x04000888 RID: 2184
	private bool twistJustMoved;

	// Token: 0x04000889 RID: 2185
	private bool pinchMoved;

	// Token: 0x0400088A RID: 2186
	private bool pinchJustMoved;

	// Token: 0x0400088B RID: 2187
	private bool uniMoved;

	// Token: 0x0400088C RID: 2188
	private bool uniJustMoved;

	// Token: 0x0400088D RID: 2189
	private bool uniCur;

	// Token: 0x0400088E RID: 2190
	private bool uniPrev;

	// Token: 0x0400088F RID: 2191
	private float uniStartTime;

	// Token: 0x04000890 RID: 2192
	private Vector2 uniPosCur;

	// Token: 0x04000891 RID: 2193
	private Vector2 uniPosStart;

	// Token: 0x04000892 RID: 2194
	private Vector2 uniTotalDragCur;

	// Token: 0x04000893 RID: 2195
	private Vector2 uniTotalDragPrev;

	// Token: 0x04000894 RID: 2196
	private float uniExtremeDragCurDist;

	// Token: 0x04000895 RID: 2197
	private Vector2 uniExtremeDragCurVec;

	// Token: 0x04000896 RID: 2198
	private float uniLastMoveTime;

	// Token: 0x04000897 RID: 2199
	private Vector2 uniDragVel;

	// Token: 0x04000898 RID: 2200
	private float endedUniStartTime;

	// Token: 0x04000899 RID: 2201
	private float endedUniEndTime;

	// Token: 0x0400089A RID: 2202
	private Vector2 endedUniPosStart;

	// Token: 0x0400089B RID: 2203
	private Vector2 endedUniPosEnd;

	// Token: 0x0400089C RID: 2204
	private Vector2 endedUniTotalDrag;

	// Token: 0x0400089D RID: 2205
	private Vector2 endedUniDragVel;

	// Token: 0x0400089E RID: 2206
	private bool endedUniMoved;

	// Token: 0x0400089F RID: 2207
	private bool uniMidFrameReleased;

	// Token: 0x040008A0 RID: 2208
	private bool uniMidFramePressed;

	// Token: 0x040008A1 RID: 2209
	private bool pollUniInitialState;

	// Token: 0x040008A2 RID: 2210
	private bool pollUniReleasedInitial;

	// Token: 0x040008A3 RID: 2211
	private bool pollUniTouched;

	// Token: 0x040008A4 RID: 2212
	private bool pollUniReleased;

	// Token: 0x040008A5 RID: 2213
	private bool pollUniWaitForDblStart;

	// Token: 0x040008A6 RID: 2214
	private bool pollUniWaitForDblEnd;

	// Token: 0x040008A7 RID: 2215
	private Vector2 pollUniPosEnd;

	// Token: 0x040008A8 RID: 2216
	private Vector2 pollUniPosStart;

	// Token: 0x040008A9 RID: 2217
	private Vector2 pollUniPosCur;

	// Token: 0x040008AA RID: 2218
	private Vector2 pollUniPosPrev;

	// Token: 0x040008AB RID: 2219
	private Vector2 pollUniDeltaAccum;

	// Token: 0x040008AC RID: 2220
	private Vector2 pollUniDblEndPos;

	// Token: 0x040008AD RID: 2221
	private Vector2 pollUniDeltaAccumAtEnd;

	// Token: 0x040008AE RID: 2222
	private bool touchCanceled;

	// Token: 0x040008AF RID: 2223
	private const float MIN_PINCH_DIST_PX = 2f;

	// Token: 0x040008B0 RID: 2224
	private const float PIXEL_POS_EPSILON_SQR = 0.1f;

	// Token: 0x040008B1 RID: 2225
	private const float PIXEL_DIST_EPSILON = 0.1f;

	// Token: 0x040008B2 RID: 2226
	private const float TWIST_ANGLE_EPSILON = 0.5f;

	// Token: 0x040008B3 RID: 2227
	public bool enableGetKey;

	// Token: 0x040008B4 RID: 2228
	public KeyCode getKeyCode;

	// Token: 0x040008B5 RID: 2229
	public KeyCode getKeyCodeAlt;

	// Token: 0x040008B6 RID: 2230
	public KeyCode getKeyCodeMulti;

	// Token: 0x040008B7 RID: 2231
	public KeyCode getKeyCodeMultiAlt;

	// Token: 0x040008B8 RID: 2232
	public bool enableGetButton;

	// Token: 0x040008B9 RID: 2233
	public string getButtonName;

	// Token: 0x040008BA RID: 2234
	public string getButtonMultiName;

	// Token: 0x040008BB RID: 2235
	public bool emulateMouse;

	// Token: 0x040008BC RID: 2236
	public bool mousePosFromFirstFinger;

	// Token: 0x040008BD RID: 2237
	public bool enableGetAxis;

	// Token: 0x040008BE RID: 2238
	public string axisHorzName;

	// Token: 0x040008BF RID: 2239
	public string axisVertName;

	// Token: 0x040008C0 RID: 2240
	public bool axisHorzFlip;

	// Token: 0x040008C1 RID: 2241
	public bool axisVertFlip;

	// Token: 0x040008C2 RID: 2242
	public float axisValScale;

	// Token: 0x040008C3 RID: 2243
	public bool codeUniJustPressed;

	// Token: 0x040008C4 RID: 2244
	public bool codeUniPressed;

	// Token: 0x040008C5 RID: 2245
	public bool codeUniJustReleased;

	// Token: 0x040008C6 RID: 2246
	public bool codeUniJustDragged;

	// Token: 0x040008C7 RID: 2247
	public bool codeUniDragged;

	// Token: 0x040008C8 RID: 2248
	public bool codeUniReleasedDrag;

	// Token: 0x040008C9 RID: 2249
	public bool codeMultiJustPressed;

	// Token: 0x040008CA RID: 2250
	public bool codeMultiPressed;

	// Token: 0x040008CB RID: 2251
	public bool codeMultiJustReleased;

	// Token: 0x040008CC RID: 2252
	public bool codeMultiJustDragged;

	// Token: 0x040008CD RID: 2253
	public bool codeMultiDragged;

	// Token: 0x040008CE RID: 2254
	public bool codeMultiReleasedDrag;

	// Token: 0x040008CF RID: 2255
	public bool codeJustTwisted;

	// Token: 0x040008D0 RID: 2256
	public bool codeTwisted;

	// Token: 0x040008D1 RID: 2257
	public bool codeReleasedTwist;

	// Token: 0x040008D2 RID: 2258
	public bool codeJustPinched;

	// Token: 0x040008D3 RID: 2259
	public bool codePinched;

	// Token: 0x040008D4 RID: 2260
	public bool codeReleasedPinch;

	// Token: 0x040008D5 RID: 2261
	public bool codeSimpleTap;

	// Token: 0x040008D6 RID: 2262
	public bool codeSingleTap;

	// Token: 0x040008D7 RID: 2263
	public bool codeDoubleTap;

	// Token: 0x040008D8 RID: 2264
	public bool codeSimpleMultiTap;

	// Token: 0x040008D9 RID: 2265
	public bool codeMultiSingleTap;

	// Token: 0x040008DA RID: 2266
	public bool codeMultiDoubleTap;

	// Token: 0x040008DB RID: 2267
	public bool codeCustomGUI;

	// Token: 0x040008DC RID: 2268
	public bool codeCustomLayout;

	// Token: 0x040008DD RID: 2269
	public const int BOX_LEFT = 1;

	// Token: 0x040008DE RID: 2270
	public const int BOX_CEN = 2;

	// Token: 0x040008DF RID: 2271
	public const int BOX_RIGHT = 4;

	// Token: 0x040008E0 RID: 2272
	public const int BOX_TOP = 8;

	// Token: 0x040008E1 RID: 2273
	public const int BOX_MID = 16;

	// Token: 0x040008E2 RID: 2274
	public const int BOX_BOTTOM = 32;

	// Token: 0x040008E3 RID: 2275
	public const int BOX_TOP_LEFT = 9;

	// Token: 0x040008E4 RID: 2276
	public const int BOX_TOP_CEN = 10;

	// Token: 0x040008E5 RID: 2277
	public const int BOX_TOP_RIGHT = 12;

	// Token: 0x040008E6 RID: 2278
	public const int BOX_MID_LEFT = 17;

	// Token: 0x040008E7 RID: 2279
	public const int BOX_MID_CEN = 18;

	// Token: 0x040008E8 RID: 2280
	public const int BOX_MID_RIGHT = 20;

	// Token: 0x040008E9 RID: 2281
	public const int BOX_BOTTOM_LEFT = 33;

	// Token: 0x040008EA RID: 2282
	public const int BOX_BOTTOM_CEN = 34;

	// Token: 0x040008EB RID: 2283
	public const int BOX_BOTTOM_RIGHT = 36;

	// Token: 0x040008EC RID: 2284
	public const int BOX_H_MASK = 7;

	// Token: 0x040008ED RID: 2285
	public const int BOX_V_MASK = 56;

	// Token: 0x0200013A RID: 314
	public enum GestureDetectionOrder
	{
		// Token: 0x040008EF RID: 2287
		TWIST_PINCH_DRAG,
		// Token: 0x040008F0 RID: 2288
		TWIST_DRAG_PINCH,
		// Token: 0x040008F1 RID: 2289
		PINCH_TWIST_DRAG,
		// Token: 0x040008F2 RID: 2290
		PINCH_DRAG_TWIST,
		// Token: 0x040008F3 RID: 2291
		DRAG_TWIST_PINCH,
		// Token: 0x040008F4 RID: 2292
		DRAG_PINCH_TWIST
	}

	// Token: 0x0200013B RID: 315
	private class Finger
	{
		// Token: 0x060009E4 RID: 2532 RVA: 0x0003CD2D File Offset: 0x0003B12D
		public Finger(TouchZone tzone)
		{
			this.zone = tzone;
			this.Reset();
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0003CD42 File Offset: 0x0003B142
		public bool JustPressed(bool includeMidFramePress, bool includeMidFrameRelease)
		{
			return (this.curState && !this.prevState) || (includeMidFramePress && this.midFramePressed) || (includeMidFrameRelease && this.midFrameReleased);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0003CD7D File Offset: 0x0003B17D
		public bool JustReleased(bool includeMidFramePress, bool includeMidFrameRelease)
		{
			return (!this.curState && this.prevState) || (includeMidFramePress && this.midFramePressed) || (includeMidFrameRelease && this.midFrameReleased);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0003CDB8 File Offset: 0x0003B1B8
		public bool Pressed(bool includeMidFramePress, bool returnFalseOnMidFrameRelease)
		{
			return (this.curState || (includeMidFramePress && this.midFramePressed)) && (!returnFalseOnMidFrameRelease || !this.midFrameReleased);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0003CDEB File Offset: 0x0003B1EB
		public bool JustTapped(bool onlyOnce = false)
		{
			return (!onlyOnce) ? this.justTapped : this.justDelayTapped;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0003CE04 File Offset: 0x0003B204
		public bool JustDoubleTapped()
		{
			return this.justDoubleTapped;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0003CE0C File Offset: 0x0003B20C
		public Vector2 GetTapPos(TouchCoordSys cs)
		{
			return this.zone.TransformPos(this.lastTapPos, cs, false);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0003CE24 File Offset: 0x0003B224
		public void OnTouchStart(Vector2 startPos, Vector2 curPos)
		{
			this.startTime = this.zone.joy.curTime;
			this.startPos = startPos;
			this.posPrev = startPos;
			this.posCur = curPos;
			this.curState = true;
			this.tapCanceled = false;
			this.moved = false;
			this.justMoved = false;
			this.lastMoveTime = 0f;
			this.dragVel = Vector2.zero;
			this.dragVel = Vector2.zero;
			this.extremeDragCurVec = (this.extremeDragPrevVec = Vector2.zero);
			this.extremeDragCurDist = (this.extremeDragPrevDist = 0f);
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0003CEC4 File Offset: 0x0003B2C4
		public void OnTouchEnd(Vector2 endPos)
		{
			this.posCur = endPos;
			this.UpdateState(true);
			this.endedMoved = this.moved;
			this.endedStartTime = this.startTime;
			this.endedEndTime = this.zone.joy.curTime;
			this.endedPosStart = this.startPos;
			this.endedPosEnd = endPos;
			this.endedDragVel = this.dragVel;
			this.endedExtremeDragVec = this.extremeDragCurVec;
			this.endedExtremeDragDist = this.extremeDragCurDist;
			this.endedWasTapCanceled = this.tapCanceled;
			this.curState = false;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0003CF58 File Offset: 0x0003B358
		public void Reset()
		{
			this.touchId = -1;
			this.curState = false;
			this.prevState = false;
			this.moved = false;
			this.justMoved = false;
			this.touchVerified = true;
			this.dragVel = Vector2.zero;
			this.pollInitialState = false;
			this.pollReleasedInitial = false;
			this.pollTouched = false;
			this.pollReleased = false;
			this.tapCanceled = false;
			this.lastTapPos = Vector2.zero;
			this.lastTapTime = -100f;
			this.nextTapCanBeDoubleTap = false;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0003CFDA File Offset: 0x0003B3DA
		public void OnPrePoll()
		{
			this.touchVerified = false;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0003CFE4 File Offset: 0x0003B3E4
		private void UpdateState(bool lastUpdateMode = false)
		{
			this.justMoved = false;
			Vector2 vector = this.posCur - this.startPos;
			this.extremeDragCurVec.x = Mathf.Max(Mathf.Abs(vector.x), this.extremeDragCurVec.x);
			this.extremeDragCurVec.y = Mathf.Max(Mathf.Abs(vector.y), this.extremeDragCurVec.y);
			this.extremeDragCurDist = Mathf.Max(vector.magnitude, this.extremeDragCurDist);
			if (!this.moved && this.extremeDragCurDist > this.zone.joy.touchTapMaxDistPx)
			{
				this.moved = true;
				this.justMoved = true;
			}
			if (lastUpdateMode)
			{
				return;
			}
			if (this.curState)
			{
				if (TouchZone.PxPosEquals(this.posCur, this.posPrev))
				{
					if (this.zone.joy.curTime - this.lastMoveTime > this.zone.joy.velPreserveTime)
					{
						this.dragVel = Vector2.zero;
					}
				}
				else
				{
					this.lastMoveTime = this.zone.joy.curTime;
					this.dragVel = (this.posCur - this.posPrev) * this.zone.joy.invDeltaTime;
				}
			}
			else
			{
				this.dragVel = Vector2.zero;
			}
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0003D15C File Offset: 0x0003B55C
		public void PreUpdate(bool firstUpdate)
		{
			this.prevState = this.curState;
			this.posPrev = this.posCur;
			this.extremeDragPrevDist = this.extremeDragCurDist;
			this.extremeDragPrevVec = this.extremeDragCurVec;
			this.midFramePressed = false;
			this.midFrameReleased = false;
			if (this.curState && this.pollReleasedInitial)
			{
				this.OnTouchEnd(this.pollPosEnd);
			}
			if (this.pollTouched && (!this.pollInitialState || this.touchId >= 0))
			{
				this.OnTouchStart(this.pollPosStart, this.pollPosCur);
			}
			if (this.touchId >= 0 != this.curState)
			{
				if (this.curState)
				{
					this.OnTouchEnd(this.pollPosEnd);
				}
				else
				{
					this.OnTouchStart(this.pollPosStart, this.pollPosCur);
				}
			}
			if (this.touchId >= 0)
			{
				this.posCur = this.pollPosCur;
			}
			this.midFramePressed = (!this.pollInitialState && this.pollTouched && !this.curState);
			this.midFrameReleased = (this.pollInitialState && this.pollReleasedInitial && this.curState);
			this.UpdateState(false);
			this.justDelayTapped = false;
			this.justTapped = false;
			this.justDoubleTapped = false;
			if (this.JustReleased(true, true))
			{
				if (!this.endedMoved && !this.endedWasTapCanceled && this.zone.joy.curTime - this.endedStartTime <= this.zone.joy.touchTapMaxTime)
				{
					bool flag = this.nextTapCanBeDoubleTap && this.endedStartTime - this.lastTapTime <= this.zone.joy.doubleTapMaxGapTime;
					this.waitForDelyedTap = !flag;
					this.justDoubleTapped = flag;
					this.justTapped = true;
					this.lastTapPos = this.endedPosStart;
					this.lastTapTime = this.zone.joy.curTime;
					this.nextTapCanBeDoubleTap = !flag;
				}
				else
				{
					this.waitForDelyedTap = false;
					this.nextTapCanBeDoubleTap = false;
				}
			}
			else if (this.JustPressed(false, false))
			{
				this.waitForDelyedTap = false;
			}
			else if (this.waitForDelyedTap && this.zone.joy.curTime - this.lastTapTime > this.zone.joy.doubleTapMaxGapTime)
			{
				this.justDelayTapped = true;
				this.waitForDelyedTap = false;
				this.nextTapCanBeDoubleTap = false;
			}
			this.pollInitialState = this.curState;
			this.pollReleasedInitial = false;
			this.pollReleased = false;
			this.pollTouched = false;
			this.pollPosCur = this.posCur;
			this.pollPosStart = this.posCur;
			this.pollPosEnd = this.posCur;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0003D44B File Offset: 0x0003B84B
		public void PostUpdate(bool firstUpdate)
		{
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0003D44D File Offset: 0x0003B84D
		public void CancelTap()
		{
			this.waitForDelyedTap = false;
			this.tapCanceled = true;
			this.nextTapCanBeDoubleTap = false;
		}

		// Token: 0x040008F5 RID: 2293
		private TouchZone zone;

		// Token: 0x040008F6 RID: 2294
		public int touchId;

		// Token: 0x040008F7 RID: 2295
		public bool touchVerified;

		// Token: 0x040008F8 RID: 2296
		public Vector2 touchPos;

		// Token: 0x040008F9 RID: 2297
		public Vector2 startPos;

		// Token: 0x040008FA RID: 2298
		public Vector2 posPrev;

		// Token: 0x040008FB RID: 2299
		public Vector2 posCur;

		// Token: 0x040008FC RID: 2300
		public float startTime;

		// Token: 0x040008FD RID: 2301
		public bool moved;

		// Token: 0x040008FE RID: 2302
		public bool justMoved;

		// Token: 0x040008FF RID: 2303
		public bool prevState;

		// Token: 0x04000900 RID: 2304
		public bool curState;

		// Token: 0x04000901 RID: 2305
		public Vector2 extremeDragCurVec;

		// Token: 0x04000902 RID: 2306
		public Vector2 extremeDragPrevVec;

		// Token: 0x04000903 RID: 2307
		public float extremeDragCurDist;

		// Token: 0x04000904 RID: 2308
		public float extremeDragPrevDist;

		// Token: 0x04000905 RID: 2309
		public float lastMoveTime;

		// Token: 0x04000906 RID: 2310
		public Vector2 dragVel;

		// Token: 0x04000907 RID: 2311
		public bool endedMoved;

		// Token: 0x04000908 RID: 2312
		public bool endedWasTapCanceled;

		// Token: 0x04000909 RID: 2313
		public float endedStartTime;

		// Token: 0x0400090A RID: 2314
		public float endedEndTime;

		// Token: 0x0400090B RID: 2315
		public Vector2 endedDragVel;

		// Token: 0x0400090C RID: 2316
		public Vector2 endedPosStart;

		// Token: 0x0400090D RID: 2317
		public Vector2 endedPosEnd;

		// Token: 0x0400090E RID: 2318
		public Vector2 endedExtremeDragVec;

		// Token: 0x0400090F RID: 2319
		public float endedExtremeDragDist;

		// Token: 0x04000910 RID: 2320
		private bool justTapped;

		// Token: 0x04000911 RID: 2321
		private bool justDoubleTapped;

		// Token: 0x04000912 RID: 2322
		private bool justDelayTapped;

		// Token: 0x04000913 RID: 2323
		private bool waitForDelyedTap;

		// Token: 0x04000914 RID: 2324
		private float lastTapTime;

		// Token: 0x04000915 RID: 2325
		private bool nextTapCanBeDoubleTap;

		// Token: 0x04000916 RID: 2326
		private Vector2 lastTapPos;

		// Token: 0x04000917 RID: 2327
		private bool tapCanceled;

		// Token: 0x04000918 RID: 2328
		public bool midFrameReleased;

		// Token: 0x04000919 RID: 2329
		public bool midFramePressed;

		// Token: 0x0400091A RID: 2330
		public bool pollInitialState;

		// Token: 0x0400091B RID: 2331
		public bool pollReleasedInitial;

		// Token: 0x0400091C RID: 2332
		public bool pollTouched;

		// Token: 0x0400091D RID: 2333
		public bool pollReleased;

		// Token: 0x0400091E RID: 2334
		public Vector2 pollPosEnd;

		// Token: 0x0400091F RID: 2335
		public Vector2 pollPosStart;

		// Token: 0x04000920 RID: 2336
		public Vector2 pollPosCur;
	}
}
