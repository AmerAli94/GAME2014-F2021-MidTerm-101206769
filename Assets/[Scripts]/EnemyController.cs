using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform enemyTransform;
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    private void Start()
    {
        enemyTransform = GetComponent<Transform>();
       // enemyTransform.transform.position = new Vector3(7.6f, 0.0f, 0.0f);
        enemyTransform.transform.position = new Vector3(8.0f, Random.Range(-4.55f, 4.55f), 0.0f);
        enemyTransform.transform.Rotate(0.0f, 0.0f, 270.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
      
    }

    private void _Move()
    {
        //transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, 0.0f, 0.0f);
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f); // moving enemies on y axis for top down movement
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary) //bounds moved to y axis
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary) //bounds moved to y axis
        {
            direction = 1.0f;
        }
    }
}
