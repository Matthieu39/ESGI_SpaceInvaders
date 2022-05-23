using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public AudioClip[] playlisteffects;
    public AudioSource audioSourceEffects;

    void Start()
    {

    }

    void Update()
    {
      if(PauseMenu.instance.gameIsPaused == false)
      {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        PlayBlaster();
      }
    }
    }


    void PlayBlaster(){
      audioSourceEffects.clip = playlisteffects[0];
      audioSourceEffects.Play();
    }
}
