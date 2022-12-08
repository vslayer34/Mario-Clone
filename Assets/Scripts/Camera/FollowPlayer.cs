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
        if (transform.position.x < target.position.x && target.position.y < 4.0f)
        {
                transform.position = new Vector3(target.position.x, 0.0f, transform.position.z);
        }
        if (target.position.y > 4.0f)
        {
            transform.position = new Vector3(target.position.x, target.position.y - 4.0f, transform.position.z);
        }
    }
}
