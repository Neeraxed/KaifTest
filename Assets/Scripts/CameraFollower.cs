using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject followingObject;

    public float smoothTime = 0.3F;

    private Vector3 direction;
    private Vector3 offset;

    private void Awake()
    {
        direction = transform.position - followingObject.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = followingObject.transform.position;
        transform.LookAt(direction);
    }
}
