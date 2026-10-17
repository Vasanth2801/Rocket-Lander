using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    [Header("Lander Settings")]
    [SerializeField] private float force = 700f;
    [SerializeField] private float turnSpeed = 100f;

    private Rigidbody2D landerRigidbody2D;

    private void Awake()
    {
        landerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Keyboard.current.upArrowKey.isPressed)
        {
            landerRigidbody2D.AddForce(force * transform.up * Time.deltaTime);
        }

        if(Keyboard.current.rightArrowKey.isPressed)
        {
            landerRigidbody2D.AddTorque(-turnSpeed * Time.deltaTime);
        }
        
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            landerRigidbody2D.AddTorque(turnSpeed * Time.deltaTime);
        }
    }
}
