using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerForceMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    private void Awake()
    {
        direction = Vector3.forward * 2f * Time.deltaTime;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //rb.MovePosition(transform.position + direction);
    }
}
