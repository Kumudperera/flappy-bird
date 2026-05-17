using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float flapStrength;

    public LogicScript logic;

    public bool birdIsAlive = true;

    public float deadZone = -30;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            myRigidbody2D.linearVelocity = Vector2.up * flapStrength;
        }

        if (transform.position.y < deadZone)
        {
            birdIsDead();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsDead();
    }

    void birdIsDead()
    {
        birdIsAlive = false;
        logic.gameOver();
    }
}
