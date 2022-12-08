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
        {
            Rigidbody2D rb = player.gameObject.GetComponent<Rigidbody2D>();

            enemy.Die();

            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            GameManager.instance.playerScore += 200;
        }
    }
}
