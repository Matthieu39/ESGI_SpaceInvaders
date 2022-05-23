using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject RulesUI;
    public GameObject IngameUI;
    public GameObject settingsWindow;

    public bool gameIsPaused = false;
    public bool canPlay = true;
    public bool cantBeTouched = false;
    public bool invasionSucceed = false;

    public int nbOfEnemiesKilled=0;
    public int lives =3;
    public int startCount;


    public Text txtNbLives;
    public Text victoryTxt;
    public Text starText;

    public static PauseMenu instance;


    private void Awake()
    {
      if(instance != null){
        Debug.LogWarning("Il y a plus d'une instance de PauseMenu dans la scene");
        return ;
      }
      instance = this;

      StartCoroutine(Ready());

        txtNbLives.text = "X " + lives;
        Time.timeScale = 1;
        gameIsPaused = false;
    }


    void Update()
    {

        txtNbLives.text = "X" + lives;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
          if(!gameIsPaused)
          {
            pauseMenuUI.SetActive(true);
            IngameUI.SetActive(false);
            Time.timeScale = 0;
            gameIsPaused = true;
          }else{
            pauseMenuUI.SetActive(false);
            IngameUI.SetActive(true);
            RulesUI.SetActive(false);
            settingsWindow.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
            }

        }


        if(nbOfEnemiesKilled == 41){
          pauseMenuUI.SetActive(true);
          IngameUI.SetActive(false);
          Time.timeScale = 0;
          gameIsPaused = true;

          victoryTxt.text = "you win !";
          nbOfEnemiesKilled = 0;
          lives=3;
      }

      if(lives == 0 || invasionSucceed== true){
        pauseMenuUI.SetActive(true);
        IngameUI.SetActive(false);
        Time.timeScale = 0;
        gameIsPaused = true;

        victoryTxt.text = "you lose...";
        nbOfEnemiesKilled = 0;
        lives=3;
    }
    }


    public IEnumerator Ready()
    {
      canPlay = false;

  for(int i =0;i<3;i++){
  startCount = 3 - i;
  starText.text = "     "+ startCount;
  yield return new WaitForSeconds(1f);

}
  starText.text = "PRESS \nSPACE";
  yield return new WaitForSeconds(1f);
  starText.text = "  ";
}



   public void reload(){
Scene scene = SceneManager.GetActiveScene();
SceneManager.LoadScene(scene.name);
Time.timeScale = 1;
  }


public void rules()
{
RulesUI.SetActive(true);
}


public void CloseRules()
{
  RulesUI.SetActive(false);
}

  public void Settings()
  {
    settingsWindow.SetActive(true);
  }

  public void CloseSettings()
  {
    settingsWindow.SetActive(false);
  }

  public void QuitGame()
  {
    Application.Quit();
  }


}
