using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Health health;
    protected virtual void Start()
    {
        // Load health component
        health = GetComponent<Health>();
        // Verify that the health component was "got"
        if (health == null)
        {
            Debug.LogWarning(gameObject.name + " does not have a health component");
        }
    }
}
