using UnityEngine;


public class ColorChanger : MonoBehaviour
{
    // TODO: Create a variable to hold our sprite renderer component
    private SpriteRenderer spriteRenderer;
    public Color spriteColor = Color.green;


    //Awake runs when an object is created
    private void Awake()
    {
        // TODO: Load our sprite renderer into that variable
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("Error! Sprite Renderer is null");
        }
        else
        {
            // TODO: Change the color of our sprite to green
            spriteRenderer.color = spriteColor;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Do this if P key is pressed down
            // Change to a random color
            spriteRenderer.color = GetRandomColor();
        }
    }
    private Color GetRandomColor()
    {
        Color color;
        color.r = Random.Range(0.0f, 1.0f);
        color.g = Random.Range(0.0f, 1.0f);
        color.b = Random.Range(0.0f, 1.0f);
        color.a = 1.0f;

        return color;
    }
}