using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private VirtualJoystickFloating stick;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private GravityBody g;
    
    private Rigidbody rb;

    protected PlayerActionsExample playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerActionsExample();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {

        Vector2 movement = playerInput.Player.Move.ReadValue<Vector2>();

        if (movement != default)
        {
            float horizontalInput = movement.x;
            float verticalInput = movement.y;

            transform.Rotate(transform.up, horizontalInput);
            transform.Rotate(transform.up, verticalInput);

            //float angleA = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg;
            //var a = new Vector3(transform.rotation.x, angleA, transform.rotation.z);
            //Debug.Log(angleA);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angleA, transform.up), 0.5f);

            //Vector3 dir = joystick.Direction;

            //float Angle = 90 - Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;


           // Quaternion toRotation = Quaternion.LookRotation(transform.rotation.eulerAngles, a);

           // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.fixedDeltaTime);

           // transform.rotation = Quaternion.AngleAxis(angleA, transform.up);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, a, rotateSpeed * Time.deltaTime);

            //Vector3 dir = transform.up * horizontalInput - transform.right * verticalInput;
            //dir.Normalize();

            
            



                //Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
                //transform.rotation = toRotation;

                //rb.AddTorque(0, -horizontalInput * 5, 0);

                //transform.localRotation = Quaternion.LookRotation(dir) ;

                //var target = new Vector3(0,  Mathf.Atan2(horizontalInput, verticalInput) * 180 / Mathf.PI, 0);
                //transform.localEulerAngles = target;


                //Vector3 diff = -dir;
                //diff.Normalize();
                //float rotation = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
                //transform.localRotation = Quaternion.Euler(0f, rotation, 0f);


                //var localUp = transform.position.y < 0 ? Vector3.down : Vector3.up;



        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}