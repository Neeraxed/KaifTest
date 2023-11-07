using UnityEngine;

public class PlayerForceMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] private Transform movingPart;
    
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    } 

    private void FixedUpdate()
    {
        //rb.AddForce(transform.forward * moveSpeed);

        movingPart.position += movingPart.forward * moveSpeed * Time.deltaTime;
    }
}
