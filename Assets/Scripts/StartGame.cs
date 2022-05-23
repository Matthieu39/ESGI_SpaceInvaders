using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Update()
    {
      if(Input.anyKey)
      {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
      }
    }
}
