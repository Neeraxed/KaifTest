using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float rotateSpeed;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            float horizontalInput = joystick.Horizontal;
            float verticalInput = joystick.Vertical;

            Vector3 dir = new Vector3(horizontalInput, 0, verticalInput);
            dir.Normalize();

            if (dir != Vector3.zero)
            {
                //var localUp = transform.position.y < 0 ? Vector3.down : Vector3.up;
                Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.fixedDeltaTime);
            }
        }
    }
}