using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;

    // Update is called once per frame
    void LateUpdate()
    {
        FollowTarget(player);
    }

    void FollowTarget(Transform target)
    {
        if (transform.position.x < target.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
