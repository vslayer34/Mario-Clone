using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHitZone : MonoBehaviour
{
    [SerializeField] GameObject gfx;
    [SerializeField] GameObject spawner;

    Animator animator;
    ItemSpawner itemSpawner;


    private void Start()
    {
        // Get the animator of the GFX
        animator = gfx.GetComponent<Animator>();

        // Get the script to spawn the items
        itemSpawner = spawner.GetComponent<ItemSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Pause the animation when the player hit the block
            animator.enabled = false;

            // Spawn new item and disabe the script to prevent it from spawning more items after the player hit it again
            itemSpawner.SpawnItem();
        }
    }
}
