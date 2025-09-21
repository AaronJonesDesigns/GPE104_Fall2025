using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable to hold our sprite Transform information
    private Transform tf;
    // Variable to hold editable Local Movement (WASD) Units per second
    public float moveSpeed = 5f;
    // Variable to hold editable World Movement (Arrow Keys) Units per second
    public float worldMoveSpeed = 5f;
    // Variable to hold degree rotation per frame
    public float turnSpeed;
    // Sets the min and max X and Y values to public, so they can be edited in the Player Movement component
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4.5f;
    public float maxY = -4.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the Transform from the object this script is on
        tf = GetComponent<Transform>();

        // start at the world origin point (0,0,0)
        tf.position = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        // Rotate "turnSpeed" degrees on the Y axis
        tf.Rotate (0, turnSpeed, 0);
        // Move up every frame draw by adding 1 to the y of our position
        tf.position = tf.position + (Vector3.up * 0.5f); // Vector3.up is a preset Vector of (0,1,0) 
        // There is also a Vector3.right (1,0,0) and Vector3.forward (0,0,1)
        // If the "W" is pushed down this function will run once per frame
        if (Input.GetKeyDown(KeyCode.T))
        {
            // pick a random x and y value within the specified range (in the inspector)
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            // set our new position to that random point along X and Y, while keeping Z locked at 0.
            tf.position = new Vector3(randomX, randomY, 0f);
            // Console confirmation that the sprites teleportation systems are functioning properly
            Debug.Log("Teleportation Systems engaged, Cap'n!");
        }
    }
}