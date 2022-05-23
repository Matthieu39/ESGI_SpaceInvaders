using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public AudioClip[] playlist;

  public AudioSource audioSource;

    void Start()
    {
      PlayMusic();
    }

    void Update()
    {
      if(!audioSource.isPlaying)
      {
        PlayMusic();
      }

    }


void PlayMusic()
{
  audioSource.clip = playlist[0];
  audioSource.Play();
}


}
