using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;
using System.Linq;
using System.Text;

public class PlayerMovement : MonoBehaviour
{

  public static PlayerMovement instance;
  public float moveSpeed;
  private float horizontalMovement;
  private float verticalMovement;

  public bool canShoot = true;

  public Rigidbody2D rb;
  private Vector3 velocity = Vector3.zero;

  public GameObject playerShip;
  public GameObject missile;
  public GameObject missileClone;


  void Awake()
  {
    if(instance != null){
      Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scene");
      return ;
    }
    instance = this;
  }


  void Update()
  {
      if(PauseMenu.instance.gameIsPaused == false){
        if (canShoot) {
          StartCoroutine(shootMissile());
      }
    }
  }

    void FixedUpdate()
    {
      horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
      verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
      MovePlayer(horizontalMovement,verticalMovement);
    }


  public void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
            // deplacement Horizontal
             Vector3 horiVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
             rb.velocity = Vector3.SmoothDamp(rb.velocity, horiVelocity, ref velocity, .1f);

             //deplacement vertical
             Vector3 vertiVelocity = new Vector2(rb.velocity.x, _verticalMovement);
             rb.velocity = Vector3.SmoothDamp(rb.velocity, vertiVelocity, ref velocity, .1f);
   }

    public IEnumerator shootMissile()
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        canShoot = false;
        missileClone = Instantiate(missile, new Vector3(playerShip.transform.position.x, playerShip.transform.position.y + 1f ,0), playerShip.transform.rotation) as GameObject;
        yield return new WaitForSeconds(0.20f);
        canShoot = true;
        PauseMenu.instance.cantBeTouched = false;
        PauseMenu.instance.canPlay = true;
      }
    }
}
