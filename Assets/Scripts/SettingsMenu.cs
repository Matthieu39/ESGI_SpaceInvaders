using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{
  public AudioMixer audioMixer;


  public void Start()
  {
    Screen.fullScreen = true;
  }

  public void SetMusic(float volume)
  {
    audioMixer.SetFloat("Music", volume);
  }

  public void SetEffectsSound(float volume)
  {
    audioMixer.SetFloat("Effects", volume);
  }


  public void SetFullScreen(bool isFullscreen)
  {
    Screen.fullScreen = isFullscreen;
  }

}
