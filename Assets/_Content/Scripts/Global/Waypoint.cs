using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour
{
    public int id;
    public bool isCompleted;

    public Enemy[] enemies;

    public int killedEnemies;
    public int KilledEnemies { get => killedEnemies; set { killedEnemies = value; CheckFinish(); } }

    private void Awake()
    {
        foreach (Enemy i in enemies)
        {
            i.components.Waypoint = this;
        }
    }

    public void CheckFinish()
    {
        if(killedEnemies >= enemies.Length)
        {
            CharacterGlobal.instance.characterMovement.parameters.IsReadyToFire = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterGlobal CH = CharacterGlobal.instance;
            isCompleted = true;
            CH.characterMovement.parameters.CurrentWaypoint++;
            CH.characterMovement.RotateTo(transform);
            CH.characterMovement.parameters.IsReadyToFire = true;

            foreach (Enemy i in enemies)
            {
                i.parameters.IsImmortal = false;
            }

            if (CH.characterMovement.parameters.CurrentWaypoint >= CH.characterMovement.components.Waypoints.Length)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
