using UnityEngine;

// Attach this ONLY to objects you want tracked (e.g., Meteors)
public class DeathTarget : DeathDestroy
{
    private void OnEnable()
    {
        // Only count if GameManager exists
        if (GameManager.instance != null)
        {
            GameManager.instance.RegisterDeathTarget();
        }
    }

    private void OnDisable()
    {
        // Only count if GameManager exists
        if (GameManager.instance != null)
        {
            GameManager.instance.UnregisterDeathTarget();
        }
    }
}
