using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour 
{
	[System.Serializable]
	public class ClipRef
	{
		public ClipID id;
		public AudioClip clip;
	}

	public enum ClipID
	{
		INTRO,
		BG_STAGE1,
		BG_STAGE1_BOSS,
		SFX_ZOMBIE_ATTACK,
		SFX_ZOMBIE_WALK,
	}

	public static SoundManager instance;
	public AudioSource BGsound;
	public AudioSource primarySFXSound;
	public AudioSource secondarySFXSound;
	
	public List<ClipRef> allAudios;


	public void Start()
	{
		if(SoundManager.instance == null)
			instance = this;
		if(SoundManager.instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySound(ClipID id)
	{
		if (!primarySFXSound.isPlaying) 
		{
			primarySFXSound.clip = GetAudio(id);
			primarySFXSound.Play();
		}
		else
		{
			if(!secondarySFXSound.isPlaying)
			{
				secondarySFXSound.clip = GetAudio(id);
				secondarySFXSound.Play();
			}
		}
	}

	public void PlayBGSound(ClipID id)
	{
		BGsound.clip = GetAudio (id);
		BGsound.Play ();
		BGsound.loop = true;
	}


	public AudioClip GetAudio(ClipID id)
	{
		foreach(ClipRef reference in allAudios)
		{
			if(reference.id == id)
			{
				return reference.clip;
			}
		}
		Debug.Log ("SoundManager error: Could not find a ClipRef with that Id.");
		return null;
	}
}
