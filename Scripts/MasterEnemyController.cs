using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEnemyController : MonoBehaviour
{
    public GameObject[] Enemies;
    public float respawnTimer = 5f;
    public List<EnemyHealth> EnemyControllers;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject Enemy in Enemies)
        {
            EnemyControllers.Add(Enemy.GetComponent<EnemyHealth>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach(EnemyHealth enemyController in EnemyControllers)
        {
            if(Time.fixedTime -enemyController.deathTime > respawnTimer)
            {
                if (enemyController.health < 0)
                {
                    enemyController.Respawn();
                }
            }
        }
    }
}
