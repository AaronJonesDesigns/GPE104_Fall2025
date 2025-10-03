using UnityEngine;

public class Health : MonoBehaviour
{
    // Data (variables)
    // Current Health
    private float currentHealth;
    [SerializeField] private float maxHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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
    public void TakeDamage(float damage, Controller damageDealer)
    {
        // TODO: Give points to the damage dealer for dealing damage
        Debug.Log(damageDealer.gameObject.name + " did " + damage + " damage to " + this.gameObject.name);

        // Actually take the damage
        TakeDamage(damage);
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
            // Debug: No death component warning
            Debug.LogWarning("Warning: " + gameObject.name + " has no death component.");
        }
    }
}

