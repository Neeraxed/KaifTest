using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);

    //[SerializeField] private FloatingJoystick Joystick;
    [SerializeField] private FloatingJoystick joystick;

    private Finger MovementFinger;
    private Vector2 MovementAmount;

    private Rigidbody rb;
    private Vector3 moveVector;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        rb.MovePosition(rb.position + moveVector);
    }

    //private void OnEnable()
    //{
    //    EnhancedTouchSupport.Enable();
    //    ETouch.Touch.onFingerDown += HandleFingerDown;
    //    ETouch.Touch.onFingerUp += HandleLoseFinger;
    //    ETouch.Touch.onFingerMove += HandleFingerMove;
    //}
    //private void OnDisable()
    //{
    //    ETouch.Touch.onFingerDown -= HandleFingerDown;
    //    ETouch.Touch.onFingerUp -= HandleLoseFinger;
    //    ETouch.Touch.onFingerMove -= HandleFingerMove;
    //    EnhancedTouchSupport.Disable();
    //}

    //private void HandleFingerMove(Finger MovedFinger)
    //{
    //    if(MovedFinger == MovementFinger)
    //    {
    //        Vector2 knobPosition;
    //        float maxMovement = JoystickSize.x / 2f;
    //        ETouch.Touch currentTouch = MovedFinger.currentTouch;

    //        if (Vector2.Distance(currentTouch.screenPosition, Joystick.RectTransform.anchoredPosition) > maxMovement)
    //        {
    //            knobPosition = (currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition).normalized * maxMovement;
    //        }
    //        else
    //        {
    //            knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
    //        }
    //        Joystick.Knob.anchoredPosition = knobPosition;
    //        MovementAmount = knobPosition / maxMovement;
    //    }
    //}

    //private void HandleLoseFinger(Finger LostFinger)
    //{
    //   if(LostFinger == MovementFinger)
    //    {
    //        MovementFinger = null;
    //        Joystick.Knob.anchoredPosition = Vector2.zero;
    //        Joystick.gameObject.SetActive(false);
    //        MovementAmount = Vector2.zero;
    //    }
    //}

    //private void HandleFingerDown(Finger TouchedFinger)
    //{
    //    if(MovementFinger == null)
    //    {
    //        MovementFinger = TouchedFinger;
    //        MovementAmount = Vector2.zero;
    //        Joystick.gameObject.SetActive(true);
    //        Joystick.RectTransform.sizeDelta = JoystickSize;
    //        //Joystick.RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
    //        Joystick.RectTransform.anchoredPosition = TouchedFinger.screenPosition;
    //    }
    //}

    //private Vector2 ClampStartPosition(Vector2 startPosition)
    //{
    //    if(startPosition.x < JoystickSize.x / 2f)
    //    {
    //        startPosition.x = JoystickSize.x / 2f;
    //    }
    //    if (startPosition.y < JoystickSize.y / 2f)
    //    {
    //        startPosition.y = JoystickSize.y / 2f;
    //    }
    //    else if (startPosition.y > Screen.height - JoystickSize.y / 2f)
    //    {
    //        startPosition.y = Screen.height - JoystickSize.y / 2f;
    //    }
    //    return startPosition;
    //}

    //private void Update()
    //{
    //    Vector3 scaledMovement = new Vector3(MovementAmount.x, 0, MovementAmount.y) * Time.deltaTime * 3;
    //    transform.LookAt(scaledMovement);
    //    rb.AddForce(scaledMovement);
    //}
}
