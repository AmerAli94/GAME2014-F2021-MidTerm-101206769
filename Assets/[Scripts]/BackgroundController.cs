// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : OCT 22, 2021
// PURPOSE     : GAME2014_F2021_MIDTERM_101206769
// SPECIAL NOTES:
// ===============================
// Change History:
// Changed the background scroll to landscape right to left scroll.
//==================================
//
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //changed vertical to horizontal speed.
    public float horizontalSpeed;
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3( 21.0f, 0.0f);
        
    }

    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= horizontalBoundary)
        {
            _Reset();
        }
    }
}
