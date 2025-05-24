using ScriptableObjects;
using Systems.Player;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] Ship ship;

    private Vector3 movement;
    private Vector3 aim;
    private Vector3 velocity;
    Vector3 mousePos;
    public Camera cam;
    [SerializeField] Animator animator;

    private bool isGamepad = true;

    public float controllerDeadZone = 0f;
    public float rotateSmoothing = 1f;

    public SoundEffectSO engineStart;

    private void Start()
    {
        engineStart.Play();

        if(ship == null) ship = GetComponent<Ship>();

        if ( ship == null )
        {
            throw new System.Exception("Sem nave!");
        } else
        {
            rb = ship.gameObject.GetComponent<Rigidbody>();
        }

        if(animator == null) animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
    }

    void HandleInput()
    {
        movement = UserInput.instance.moveInput;
        aim = UserInput.instance.aimInput;
    }

    void HandleMovement()
    {
        float moveX = movement.x;
        float moveY = movement.y;

        //float speedModifier = ship.GetStat(ShipStatistic.Speed).statValue;
        float speed = ship.GetStat(ShipStatistic.Speed).statValue;

        Vector3 move = new Vector3(moveX, 0, moveY);
        //rb.linearVelocity = move * (speed * (1 + speedModifier/100f));

        Debug.Log("X: " + moveX + ", Y: " + moveY);
        HandleAnimation(moveX);

        rb.linearVelocity = move * speed;
    }

    private void HandleAnimation(float moveX)
    {
        if (moveX > 0)
        {
            Debug.Log("Virando pra Direita");
            animator.SetBool("moveRight", true);
            animator.SetBool("moveLeft", false);
        }
        else if (moveX < 0)
        {
            Debug.Log("Virando pra Esquerda");
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", true);
        }
        else
        {
            Debug.Log("Parado");
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", false);
        }
    }

    void HandleRotation()
    {
        if(isGamepad)
        {
            if(Mathf.Abs(aim.x) > controllerDeadZone || Mathf.Abs(aim.y) > controllerDeadZone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if(playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateSmoothing * Time.deltaTime);
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(aim);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if(groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectPoint);
    }

    public void OnDeviceChange(PlayerInput playerInput)
    {
        isGamepad = playerInput.currentControlScheme.Equals("Gamepad") ? true : false;
    }
}
