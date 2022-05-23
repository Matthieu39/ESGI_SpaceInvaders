using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
  public GameObject enemyMissile;
  Vector3 playerSpawn = new Vector3(0,-3.37f,0);

    void Update()
    {
          transform.Translate(new Vector3(0,-5* Time.deltaTime,0));
          if(transform.position.y<-5)
          {
            Destroy(transform.gameObject);
          }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
          if(collision.gameObject.tag == "Player")
          {
                PauseMenu.instance.canPlay = false;


                    if(PauseMenu.instance.lives >=1)
                    {
                          collision.gameObject.transform.position = playerSpawn;
                          Destroy(enemyMissile);
                          Debug.Log("Bonjour");

                          if(PauseMenu.instance.cantBeTouched == false)
                          {
                          PauseMenu.instance.lives-=1;
                          }
                          PauseMenu.instance.cantBeTouched= true;
                    }
                    else
                    {

                      if(PauseMenu.instance.cantBeTouched == false)
                      {
                      PauseMenu.instance.lives-=1;
                      }
                      PauseMenu.instance.cantBeTouched= true;

                          Destroy(collision.gameObject);
                          Debug.Log("GAME OVER");
                    }
           }
    }
}
