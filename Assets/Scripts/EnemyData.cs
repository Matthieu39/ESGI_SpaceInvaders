using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "MyGame/EnemyData")]
public class EnemyData : ScriptableObject
{
  public string enemyName;
  public int health;
  public int points;
}
