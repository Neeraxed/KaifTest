//using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
//public class PlayerForceMovement : MonoBehaviour
//{
//    [SerializeField] float moveSpeed;
//    private Rigidbody rb;
//    private Vector3 direction;

//    private void Awake()
//    {        
//        rb = GetComponent<Rigidbody>();
//    }

//    private void Update()
//    {
//        direction = transform.forward * moveSpeed * Time.deltaTime;
//        rb.MovePosition(transform.position + direction);
//    }
//}


using UnityEngine;

public class PlayerForceMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private Vector3 steerDirection;

    private void FixedUpdate()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
