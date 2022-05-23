using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
          if(collision.gameObject.tag == "Enemy")
          {
            PauseMenu.instance.invasionSucceed = true;
          }
        }
}
