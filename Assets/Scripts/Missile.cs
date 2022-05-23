using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0,-6* Time.deltaTime,0));

        if(transform.position.y>8){
          Destroy(transform.gameObject);
        }
    }
}
