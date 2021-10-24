// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : OCT 23, 2021
// PURPOSE     : GAME2014_F2021_MIDTERM_101206769
// File : PlayerController.cs
// SPECIAL NOTES:
// ===============================
// Change History: OCT 22, 2021
// Changed the background scroll to landscape right to left scroll.
//==================================
// Change History: OCT 23, 2021
// Added required rotation  & position to the player facing right towards enemies and positioned towards left of the screen
// Changed to up & down movement instead of Left & Right
//==================================


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    public Transform playerTransform;

    [Header("Boundary Check")]
    public float verticalBoundary;

    [Header("Player Speed")]
    public float verticalSpeed; // modified to change the up & down movement
    public float maxSpeed;
    public float verticalTValue; // modified to change the up & down movement


    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();


        playerTransform = GetComponent<Transform>();
        playerTransform.transform.Rotate(0.0f,0.0f,270.0f); // makes sure the player is rotated in the right direction when hit start.
        playerTransform.transform.position = new Vector3(-8.0f,0.0f,0.0f); // makes sure the position of the player is on the Left side of the screen.

    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();

    }

    private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;
        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y) // modified to change the up & down movement
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y) // modified to change the up & down movement
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
            transform.position = new Vector2(transform.position.x , Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalTValue)); // modified to change the up & down movement
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * verticalSpeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f); // modified to change the up & down movement
        }

        // check left bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f); // modified to change the up & down movement

        }

    }
}
