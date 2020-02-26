using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014F RID: 335
public class AppSoundManager : MonoBehaviour
{
	// Token: 0x06000A37 RID: 2615 RVA: 0x0003E190 File Offset: 0x0003C590
	public void PlaySfxCar(Sfx.Type type)
	{
		if (AppSoundManager.MuteSfx)
		{
			return;
		}
		if (this.isPaused)
		{
			Debug.LogWarning("Its paused... get out");
		}
		string text = Sfx.sfxFiles[(int)type];
		AudioClip audioClip = (AudioClip)Resources.Load(text, typeof(AudioClip));
		if (audioClip == null)
		{
			Debug.LogError("Unable to load clip: " + text);
			return;
		}
		AppSoundManager.car = this.getFreeChannel();
		AppSoundManager.car.volume = ((!this._mute) ? AppSoundManager.startVolume : 0f);
		AppSoundManager.car.pitch = AppSoundManager.startPitch;
		AppSoundManager.car.loop = true;
		AppSoundManager.car.clip = audioClip;
		AppSoundManager.car.Play();
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x06000A38 RID: 2616 RVA: 0x0003E256 File Offset: 0x0003C656
	// (set) Token: 0x06000A39 RID: 2617 RVA: 0x0003E25E File Offset: 0x0003C65E
	public bool Mute
	{
		get
		{
			return this._mute;
		}
		set
		{
			this._mute = value;
			if (this.backgroudMusic.isPlaying)
			{
				this.backgroudMusic.volume = ((!this._mute) ? this.MusicVolume : 0f);
			}
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000A3B RID: 2619 RVA: 0x0003E2AB File Offset: 0x0003C6AB
	// (set) Token: 0x06000A3A RID: 2618 RVA: 0x0003E29D File Offset: 0x0003C69D
	public float MusicVolume
	{
		get
		{
			return AppSoundManager._MusicVolume;
		}
		set
		{
			this.backgroudMusic.volume = value;
		}
	}

	// Token: 0x06000A3C RID: 2620 RVA: 0x0003E2B4 File Offset: 0x0003C6B4
	public static AppSoundManager Get()
	{
		if (AppSoundManager._instance == null)
		{
			AppSoundManager._instance = new GameObject("SoundManager")
			{
				transform = 
				{
					position = new Vector3(100f, 100f, 100f)
				}
			}.AddComponent<AppSoundManager>();
		}
		return AppSoundManager._instance;
	}

	// Token: 0x06000A3D RID: 2621 RVA: 0x0003E30C File Offset: 0x0003C70C
	private void Awake()
	{
		if (AppSoundManager._instance != null && AppSoundManager._instance != this)
		{
			Debug.LogWarning("Destroy previous create sound manager");
			UnityEngine.Object.Destroy(AppSoundManager._instance.gameObject);
		}
		AppSoundManager._instance = this;
		this.createChannels();
		this.pausedChannels = new List<AudioSource>();
		this.isPaused = false;
		this.onFadeoutMusic = false;
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x0003E377 File Offset: 0x0003C777
	private void Start()
	{
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x0003E37C File Offset: 0x0003C77C
	private void Update()
	{
		if (this.onFadeoutMusic)
		{
			this.fadeoutMusicTimer -= Time.deltaTime;
			if (this.fadeoutMusicTimer > 0f)
			{
				float volume = this.fadeoutMusicTimer / this.fadeoutMusicRealDelay * this.MusicVolume;
				this.backgroudMusic.volume = volume;
			}
			else
			{
				this.StopMusic();
				this.onFadeoutMusic = false;
			}
		}
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x0003E3EC File Offset: 0x0003C7EC
	public void PauseAll()
	{
		if (this.isPaused)
		{
		}
		this.pausedChannels.Clear();
		if (this.backgroudMusic.isPlaying)
		{
			this.backgroudMusic.Pause();
		}
		this.pausedChannels.Add(this.backgroudMusic);
		this.StopSfx();
		this.isPaused = true;
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x0003E448 File Offset: 0x0003C848
	public IEnumerator PlaySfxAndPauseMusic(Sfx.Type t)
	{
		this.PauseAll();
		yield return base.StartCoroutine(this.PlaySfxCoroutine(t));
		yield break;
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x0003E46C File Offset: 0x0003C86C
	public void ResumeAll()
	{
		this.isPaused = false;
		foreach (AudioSource audioSource in this.pausedChannels)
		{
			if (audioSource == this.backgroudMusic)
			{
				audioSource.volume = this.MusicVolume;
			}
			else
			{
				audioSource.volume = AppSoundManager.SfxVolume;
			}
			audioSource.Play();
		}
		this.pausedChannels.Clear();
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x0003E508 File Offset: 0x0003C908
	public void PlaySfxMenuClick()
	{
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x0003E50C File Offset: 0x0003C90C
	public void StopSfx()
	{
		foreach (AudioSource audioSource in this.sourceChannels)
		{
			if (audioSource.isPlaying)
			{
				audioSource.Stop();
			}
		}
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x0003E574 File Offset: 0x0003C974
	public void PlaySfx(Sfx.Type type)
	{
		if (AppSoundManager.MuteSfx)
		{
			return;
		}
		if (this.isPaused)
		{
			Debug.LogWarning("Its paused... get out");
		}
		string text = Sfx.sfxFiles[(int)type];
		AudioClip audioClip = (AudioClip)Resources.Load(text, typeof(AudioClip));
		if (audioClip == null)
		{
			Debug.LogError("Unable to load clip: " + text);
			return;
		}
		AudioSource freeChannel = this.getFreeChannel();
		freeChannel.volume = ((!this._mute) ? AppSoundManager.SfxVolume : 0f);
		freeChannel.loop = false;
		freeChannel.clip = audioClip;
		freeChannel.Play();
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x0003E618 File Offset: 0x0003CA18
	public IEnumerator PlaySfxCoroutine(Sfx.Type type)
	{
		if (AppSoundManager.MuteSfx)
		{
			yield break;
		}
		string resName = Sfx.sfxFiles[(int)type];
		AudioClip clip = (AudioClip)Resources.Load(resName, typeof(AudioClip));
		if (clip == null)
		{
			Debug.LogError("Unable to load clip: " + resName);
			yield break;
		}
		AudioSource chan = this.getFreeChannel();
		chan.volume = ((!this._mute) ? AppSoundManager.SfxVolume : 0f);
		chan.loop = false;
		chan.clip = clip;
		chan.Play();
		while (chan.isPlaying)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x0003E63C File Offset: 0x0003CA3C
	public void PlaySfxForDynamic(Sfx.Type type)
	{
		if (AppSoundManager.MuteSfx || (this.dynChannel != null && this.dynChannel.isPlaying))
		{
			return;
		}
		if (this.isPaused)
		{
			Debug.LogWarning("Its paused... get out");
		}
		string text = Sfx.sfxFiles[(int)type];
		AudioClip audioClip = (AudioClip)Resources.Load(text, typeof(AudioClip));
		if (audioClip == null)
		{
			Debug.LogError("Unable to load clip: " + text);
			return;
		}
		this.dynChannel = this.getFreeChannel();
		this.dynChannel.volume = ((!this._mute) ? AppSoundManager.SfxVolume : 0f);
		this.dynChannel.loop = false;
		this.dynChannel.clip = audioClip;
		this.dynChannel.Play();
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x0003E719 File Offset: 0x0003CB19
	public void StopSfxForDynamic()
	{
		if (this.dynChannel != null)
		{
			this.dynChannel.Stop();
		}
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x0003E738 File Offset: 0x0003CB38
	public AudioSource PlaySfxClip(AudioClip clip, bool isLoop = false)
	{
		if (AppSoundManager.MuteSfx)
		{
			return null;
		}
		AudioSource freeChannel = this.getFreeChannel();
		freeChannel.volume = ((!this._mute) ? AppSoundManager.SfxVolume : 0f);
		freeChannel.loop = isLoop;
		if (!isLoop)
		{
			freeChannel.PlayOneShot(clip);
		}
		else
		{
			freeChannel.clip = clip;
			freeChannel.Play();
		}
		return freeChannel;
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0003E7A0 File Offset: 0x0003CBA0
	public AudioSource PlaySfxUinque(AudioClip clip)
	{
		if (this.isClipIsPlaying(clip))
		{
			return null;
		}
		AudioSource freeChannel = this.getFreeChannel();
		freeChannel.volume = ((!this._mute) ? AppSoundManager.SfxVolume : 0f);
		freeChannel.clip = clip;
		freeChannel.Play();
		return freeChannel;
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x0003E7F0 File Offset: 0x0003CBF0
	public bool isMusicPlaying()
	{
		return this.backgroudMusic.isPlaying;
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x0003E800 File Offset: 0x0003CC00
	private void createChannels()
	{
		this.sourceChannels = new List<AudioSource>();
		for (int i = 0; i < 8; i++)
		{
			AudioSource item = base.gameObject.AddComponent<AudioSource>();
			this.sourceChannels.Add(item);
		}
		this.backgroudMusic = base.gameObject.AddComponent<AudioSource>();
	}

	// Token: 0x06000A4D RID: 2637 RVA: 0x0003E854 File Offset: 0x0003CC54
	private AudioSource getFreeChannel()
	{
		foreach (AudioSource audioSource in this.sourceChannels)
		{
			if (!audioSource.isPlaying && !this.pausedChannels.Contains(audioSource))
			{
				return audioSource;
			}
		}
		this.sourceChannels.Add(base.gameObject.AddComponent<AudioSource>());
		return this.sourceChannels[this.sourceChannels.Count - 1];
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x0003E8FC File Offset: 0x0003CCFC
	private bool isClipIsPlaying(AudioClip cl)
	{
		foreach (AudioSource audioSource in this.sourceChannels)
		{
			if (audioSource.isPlaying && audioSource.clip == cl)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x0003E978 File Offset: 0x0003CD78
	public void PlayMusic(Music.Type t)
	{
		if (AppSoundManager.MuteMusic)
		{
			return;
		}
		if (this.backgroudMusic != null)
		{
			this.StopMusic();
		}
		string text = Music.musicFiles[(int)t];
		AudioClip audioClip = Resources.Load(text, typeof(AudioClip)) as AudioClip;
		if (audioClip == null)
		{
			Debug.LogError("Unable to load: " + text + " clip as bg music");
			return;
		}
		this.backgroudMusic.volume = ((!this._mute) ? this.MusicVolume : 0f);
		this.backgroudMusic.loop = true;
		this.backgroudMusic.clip = audioClip;
		this.backgroudMusic.Play();
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x0003EA30 File Offset: 0x0003CE30
	public void PlayMusicNotLoop(Music.Type t)
	{
		if (AppSoundManager.MuteMusic)
		{
			return;
		}
		if (this.backgroudMusic != null)
		{
			this.StopMusic();
		}
		string text = Music.musicFiles[(int)t];
		AudioClip audioClip = Resources.Load(text, typeof(AudioClip)) as AudioClip;
		if (audioClip == null)
		{
			Debug.LogError("Unable to load: " + text + " clip as bg music");
			return;
		}
		this.backgroudMusic.volume = ((!this._mute) ? this.MusicVolume : 0f);
		this.backgroudMusic.loop = false;
		this.backgroudMusic.clip = audioClip;
		this.backgroudMusic.Play();
	}

	// Token: 0x06000A51 RID: 2641 RVA: 0x0003EAE8 File Offset: 0x0003CEE8
	public void StopMusic()
	{
		this.backgroudMusic.Stop();
	}

	// Token: 0x06000A52 RID: 2642 RVA: 0x0003EAF5 File Offset: 0x0003CEF5
	public void StartMusic()
	{
		this.backgroudMusic.Play();
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x0003EB02 File Offset: 0x0003CF02
	public void StopMusicWithFade(float delayTime = 1f)
	{
		this.onFadeoutMusic = true;
		if (delayTime <= 0f)
		{
			delayTime = 0.2f;
		}
		this.fadeoutMusicTimer = delayTime;
		this.fadeoutMusicRealDelay = delayTime;
	}

	// Token: 0x04000959 RID: 2393
	public static float SfxVolume = 1f;

	// Token: 0x0400095A RID: 2394
	public static float _MusicVolume = 1f;

	// Token: 0x0400095B RID: 2395
	public static bool MuteSfx;

	// Token: 0x0400095C RID: 2396
	public static bool MuteMusic;

	// Token: 0x0400095D RID: 2397
	public const int ChannelsCount = 8;

	// Token: 0x0400095E RID: 2398
	public const float FadeoutMusicDelay = 1f;

	// Token: 0x0400095F RID: 2399
	private List<AudioSource> sourceChannels;

	// Token: 0x04000960 RID: 2400
	private AudioSource backgroudMusic;

	// Token: 0x04000961 RID: 2401
	private static AppSoundManager _instance;

	// Token: 0x04000962 RID: 2402
	private bool isPaused;

	// Token: 0x04000963 RID: 2403
	private List<AudioSource> pausedChannels;

	// Token: 0x04000964 RID: 2404
	private bool onFadeoutMusic;

	// Token: 0x04000965 RID: 2405
	private float fadeoutMusicTimer;

	// Token: 0x04000966 RID: 2406
	private float fadeoutMusicRealDelay;

	// Token: 0x04000967 RID: 2407
	private bool _mute;

	// Token: 0x04000968 RID: 2408
	public static AudioSource car;

	// Token: 0x04000969 RID: 2409
	public static float startPitch = 0.3f;

	// Token: 0x0400096A RID: 2410
	public static float endPitch = 1f;

	// Token: 0x0400096B RID: 2411
	public static float startVolume = 0.3f;

	// Token: 0x0400096C RID: 2412
	public static float endVolume = 1f;

	// Token: 0x0400096D RID: 2413
	private AudioSource dynChannel;
}
