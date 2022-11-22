using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class GameObjectData : MonoBehaviour
{
    public Item item;
    public SpriteRenderer spriteRenderer;

    public Animator animator;
    private CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = item.sprite;
        animator.runtimeAnimatorController = item.animator;
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
    }
}
