using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    private EnemyMovement enemy;


    private void Start()
    {
        enemy = parentObject.GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
            enemy.Die();
    }
}
