using UnityEngine;

public class PlayerForceMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] private Transform movingPart;

    private void FixedUpdate()
    {
        movingPart.position += movingPart.forward * moveSpeed * Time.deltaTime;
    }
}
