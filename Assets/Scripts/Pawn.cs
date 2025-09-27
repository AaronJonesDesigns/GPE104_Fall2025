using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Health health;
    public Shooter shooter;
    protected virtual void Awake()
    {
        // Load health component
        health = GetComponent<Health>();
        // Verify that the health component was "got"
        if (health == null)
        {
            Debug.LogWarning(gameObject.name + " does not have a health component");
        }
        // Load the shooter component
        shooter = GetComponent<Shooter>();
    }
}
