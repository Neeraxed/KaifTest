using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform followingObject;
    [SerializeField] private Transform GravityAttractor;

    [SerializeField] private float smoothTime = 0.3F;
    [SerializeField] private float distance;

    private Vector3 velocity = Vector3.zero;
    //private Vector3 direction;

    private void Awake()
    {
        distance = Vector3.Distance(transform.position, followingObject.position);
        //direction = transform.position - followingObject.transform.position;
    }

    private void FixedUpdate()
    {

        Vector3 targetPosition = followingObject.TransformPoint(new Vector3(0, 2, 0));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition + (followingObject.up * distance), ref velocity, smoothTime);
        //transform.position = followingObject.transform.position;

        transform.LookAt(followingObject);
    }
}
