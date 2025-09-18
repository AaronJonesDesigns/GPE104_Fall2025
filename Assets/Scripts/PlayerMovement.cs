using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable to hold our sprite Transform information
    private Transform tf;
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
        // If the "W" is pushed down this function will run once per frame
        if (Input.GetKeyDown(KeyCode.W))
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