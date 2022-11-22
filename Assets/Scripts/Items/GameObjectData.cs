using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class GameObjectData : MonoBehaviour
{
    public Item item;
    public SpriteRenderer spriteRenderer;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = item.sprite;
        animator.runtimeAnimatorController = item.animator;
    }
}
