using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class SoundSystemSingleton : MonoBehaviour {
    
    [SerializeField] private AudioSource musicSource, sfxSource, otherNoiseSource;

    public static SoundSystemSingleton Instance { get; private set; }
    
    private void Awake() {
        // start of singleton pattern
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySfxSound(AudioClip clip) {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayOtherSound(AudioClip clip) {
        otherNoiseSource.PlayOneShot(clip);
    }

    public void PlayMusicSound(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.mute = false;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void ChangeMusicPitch(float pitch) {
        musicSource.pitch = pitch;
    }

    public void StopTheMusic() {
        musicSource.mute = true;
    }

    public void PlayTheMusicAgain() {
        musicSource.mute = false;
    }

    public void ChangeMusicVolume(float vol) {
        musicSource.volume = vol;
    }

    public void ChangeSoundVolume(float vol) {
        sfxSource.volume = vol;
    }

    public void TurnOnSound() {
        sfxSource.volume = 1f;
    }

    public void TurnOffSound() {
        sfxSource.volume = 0f;
    }
}
