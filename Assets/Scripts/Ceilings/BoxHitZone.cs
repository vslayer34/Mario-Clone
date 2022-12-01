using UnityEngine;

public class BoxHitZone : MonoBehaviour
{
    [SerializeField] GameObject gfx;
    Animator boxAnimator;


    void Start()
    {
        boxAnimator = gfx.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxAnimator.SetTrigger("Box Hit");
    }
}
