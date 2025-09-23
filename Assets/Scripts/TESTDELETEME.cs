using UnityEngine;

public class TESTDELETEME : MonoBehaviour
{
    public PlayerPawn pawnToTest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            pawnToTest.health.TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            pawnToTest.health.Heal(1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            pawnToTest.health.Die();
        }
    }
}
