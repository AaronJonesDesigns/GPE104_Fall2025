using UnityEngine;

public class Health : MonoBehaviour
{
    // Data (variables)
    // Current Health
    private float currentHealth;
    [SerializeField] private float maxHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start with max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(float healAmount)
    {
        currentHealth = currentHealth + healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void Die()
    {
        Death deathComponent = GetComponent<Death>();

        if (deathComponent != null)
        {
            deathComponent.Die();
        }
        else
        {
            Debug.LogWarning("Warning: " + gameObject.name + " has no death component.");
        }
    }
}

