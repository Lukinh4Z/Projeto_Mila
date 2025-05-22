using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementModifiers
    {
        SPEED
    }

    [System.Serializable]
    public class PlayerMovementModifiers
    {
        public MovementModifiers modifier;
        public float value;
    }

    public float health;
    public float speed;
    //public GameObject gameOver;
    //public float shouldStopX = 24f;
    //public float shouldStopNegX = -24f;
    //public float shouldStopY = 13f;
    //public float shouldStopNegY = -13f;

    //[SerializeField] TextMeshProUGUI lifeValueText;

    private Rigidbody rb;

    private Vector3 movement;
    private Vector3 aim;
    private Vector3 velocity;
    Vector3 mousePos;
    public Camera cam;
    
    private bool isGamepad = true;

    public float controllerDeadZone = 0f;
    public float rotateSmoothing = 1f;

    public PlayerMovementModifiers[] modifiers;


    public SoundEffectSO engineStart;
    //public SoundEffectSO hitSound;
    //public SoundEffectSO deathSound;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        engineStart.Play();
    }

    void FixedUpdate()
    {
        //lifeValueText.text = health.ToString();

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

        PlayerMovementModifiers speedModifier = modifiers.FirstOrDefault(m => m.modifier == MovementModifiers.SPEED);

        Vector3 move = new Vector3(moveX, 0, moveY);
        rb.linearVelocity = move * (speed * (1 + speedModifier.value/100f));
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

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        //hitSound.Play();

        if (health <= 0)
        {
            //deathSound.Play();
            Destroy(gameObject);
            //gameOver.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
