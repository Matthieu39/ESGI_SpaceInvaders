using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

public float enemyLife;
public float timer = 0;
public float timeToMove = 0.5f;
public float speed = 0.4f;

public bool istouching = false;
public bool canShoot = true;

public int mvtNb = 0;

public GameObject explodingMissile;
public GameObject enemyShip;
public GameObject enemyMissile;
public GameObject enemyMissileClone;

public SpriteRenderer graphics;




  void Update(){

    if (enemyLife == 0)
    {
     Destroy(transform.gameObject);
     PauseMenu.instance.nbOfEnemiesKilled++;
    }

    if(PauseMenu.instance.canPlay == true){

      timer += Time.deltaTime;

      if(timer > timeToMove){
        transform.Translate(new Vector3(speed,0,0));
        timer =0;
        mvtNb++;
      }

      if(mvtNb == 8){
        transform.Translate(new Vector3(0,-0.6f,0));
        mvtNb=0;
        speed = -speed;
      }

      if(PauseMenu.instance.gameIsPaused == false){
        if (canShoot) {
        StartCoroutine(fireEnemyMissile());
        }
      }
    }
 }


private void OnTriggerEnter2D(Collider2D collision){

  if(collision.gameObject.tag != "EnemyMissile" && collision.gameObject.tag != "Player"){
  enemyLife -= 10;
  istouching = true;
  Destroy(collision.gameObject);
}


  StartCoroutine(showDamage());
  StartCoroutine(StopDamage());
}


public IEnumerator showDamage(){

  while (istouching) {
    graphics.color = new Color(1f, 0f, 0f, 1f);
    yield return new WaitForSeconds(0.15f);
    graphics.color = new Color(1f, 1f, 1f, 1f);
    yield return new WaitForSeconds(0.15f);

  }
}

public IEnumerator StopDamage(){
  yield return new WaitForSeconds(2f);
  istouching = false;
}

public IEnumerator  fireEnemyMissile()
  {
    if (Random.Range(0, 1500) <1)
      {
        canShoot = false;
        enemyMissileClone = Instantiate(enemyMissile, new Vector3(enemyShip.transform.position.x, enemyShip.transform.position.y -0.6f ,0), enemyShip.transform.rotation) as GameObject;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;

      }
  }

}
