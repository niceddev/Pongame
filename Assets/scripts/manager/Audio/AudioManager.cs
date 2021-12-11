using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public static AudioManager instance;

	void Awake() {

		if(instance == null){
			instance = this;
		}else{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (var s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.loop = s.loop;
		}
	}
	
	void Start(){
		if(!PlayerPrefs.HasKey("Sound") || PlayerPrefs.GetString("Sound") == "yes"){
			Play("theme");
			PlayerPrefs.SetString("Sound","yes");
		}
	}

	public void Play(string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.Log("Not found " + name);
			return;
		}
		s.source.Play();
	}

	public void Mute(bool mute) {
		Sound theme = Array.Find(sounds, sounds => sounds.name == "theme");
		if(mute){
			foreach (Sound sound in sounds)
			{
				sound.source.mute = true;
				theme.source.Stop();
			}
		}else{
			foreach (Sound sound in sounds)
			{
				sound.source.mute = false;
				theme.source.Play();
			}
		}
		
	}

}
