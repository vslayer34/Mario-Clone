using UnityEngine;

public class BoxHitZone : MonoBehaviour
{
    [SerializeField] GameObject gfx;
    [SerializeField] GameObject parentObject;
    Animator boxAnimator;


    void Start()
    {
        boxAnimator = gfx.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.playerState == PlayerState.NORMAL)
            {
                boxAnimator.SetTrigger(BoxAnimations.boxHit);
            }

            else if (GameManager.instance.playerState == PlayerState.DOUBLED)
            {
                boxAnimator.SetTrigger(BoxAnimations.boxBreak);
                Destroy(parentObject);
            }
        }
    }
}
