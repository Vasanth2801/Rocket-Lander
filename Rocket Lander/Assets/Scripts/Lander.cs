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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(!collision.gameObject.TryGetComponent(out LandingPad landingPad))
        {
            Debug.Log("Crashed on the Terrain!");
            return;
        }

        float softLandingSpeed = 4f;

        if(collision.relativeVelocity.magnitude > softLandingSpeed)
        {
            Debug.Log("Landed too Hard!");
            return;
        }
           Debug.Log("Landed safely!");

        float landingAngle = Vector2.Dot(Vector2.up, transform.up);

        float landingAngleThreshold = 0.9f;

        if(landingAngle < landingAngleThreshold)
        {
            Debug.Log("Landed at a bad angle!");
            return;
        }

        Debug.Log("Landed successfully!");


    }
}
