using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHitZone : MonoBehaviour
{
    [SerializeField] GameObject gfx;

    Animator animator;


    private void Start()
    {
        animator = gfx.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.enabled = false;
        }
    }
}
