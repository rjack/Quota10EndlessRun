using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
  [SerializeField] private AudioMixer sfxMixer;
  [SerializeField] private AudioMixer musicMixer;

  public void SetSfxVolume(Single volume)
  {
    float vol = math.log10(volume) * 20f;
    sfxMixer.SetFloat("sfxVolume",vol);
    PlayerPrefs.SetFloat("sfxVolume", vol);
    
  }

  public void SetMusicVolume(Single volume)
  {
    float vol = math.log10(volume) * 20f;
    musicMixer.SetFloat("musicVolume",vol);
    PlayerPrefs.SetFloat("musicVolume", vol);
  }


  private void Awake()
  {
    if (PlayerPrefs.HasKey("musicVolume"))
    {
      musicMixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("musicVolume"));
    }
    if (PlayerPrefs.HasKey("sfxVolume"))
    {
      sfxMixer.SetFloat("sfxVolume", PlayerPrefs.GetFloat("sfxVolume"));
    }
  }
}