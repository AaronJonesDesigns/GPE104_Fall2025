using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Players")]
    public List<PlayerController> players;

    [Header("Prefabs")]
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;
    public GameObject meteorPrefab;
    public GameObject planetPrefab;

    [Header("Game Data")]
    public float score;
    public float topScore;
    public int maxLives;
    public int currentLives;

    [Header("Meteor Spawning")]
    public float meteorSpawnInterval = 3f;
    private float meteorTimer = 0f;
    public List<Transform> meteorSpawnPoints;

    [Header("Death Target Tracking")]
    private int deathTargetCount = 0;

    [Header("Countdown Timer")]
    private float currentTime;

    private bool gameEnded = false;
    public TextMeshProUGUI timerText;
    public float countdownTime = 60f;

    private void Awake()
    {
        // Singleton setup (ONE Game Manager to control them all!)
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Get Public variable so it can be used by other scripts
    public int DeathTargetCount => deathTargetCount;

    // Called when a DeathTarget is spawned
    public void RegisterDeathTarget()
    {
        // DeathTarget counter +1
        deathTargetCount++;
        Debug.Log("DeathTarget Added. Count = " + deathTargetCount);
    }
public void Start()
    {
        // Make players list
        players = new List<PlayerController>();

        // Spawn the Player Controller
        SpawnPlayerController();

        // Spawn the Player Pawn
        SpawnPlayer();
        // Spawn the HomePlanet
        SpawnPlanet();
        // Spawn the Meteor x 3
        SpawnMeteor();
        SpawnMeteor();
        SpawnMeteor();

        // Initialize the timer
        currentTime = countdownTime;
        // Show starting time immediately
        UpdateTimerUI();
    }
    void Update()
    {
        // Add the time (in seconds) since the last frame to our timer
        meteorTimer += Time.deltaTime;

        // Check if enough time has passed to spawn a new meteor
        if (meteorTimer >= meteorSpawnInterval)
        {
            // Call the function to create a meteor at a random spawn point
            SpawnMeteor();

            // Reset the timer back to 0 so we can count up again
            meteorTimer = 0f;
        }
        // Meteor spawning
        meteorTimer += Time.deltaTime;
        if (meteorTimer >= meteorSpawnInterval)
        {
            SpawnMeteor();
            meteorTimer = 0f;
        }
        // Tick the countdown timer
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
                currentTime = 0;

            UpdateTimerUI();
        }
        // Update UI text
        if (timerText != null)
            timerText.text = Mathf.Ceil(currentTime).ToString();

        // Check for victory
        if (currentTime <= 0 && !gameEnded)
        {
            gameEnded = true;
            Debug.Log("Victory! The player survived until the timer ran out.");
        }

        // Meteor spawn logic
        meteorTimer += Time.deltaTime;
        if (meteorTimer >= meteorSpawnInterval)
        {
            SpawnMeteor();
            meteorTimer = 0f;
        }
    }
    private void UpdateTimerUI()
    {
        // Show whole seconds on UI
        if (timerText != null)
            timerText.text = Mathf.CeilToInt(currentTime).ToString();
    }
    // Called when a DeathTarget is destroyed
    public void UnregisterDeathTarget()
    {
        // DeathTarget counter -1
        deathTargetCount--;
        Debug.Log("DeathTarget Removed. Count = " + deathTargetCount);
    }
    // Public active DeathTarget check
    public int GetDeathTargetCount()
    {
        return deathTargetCount;
    }

    //Get random spawn point from the list of spawn points
    public Vector3 GetRandomSpawnPoint()
    {
        if (meteorSpawnPoints == null || meteorSpawnPoints.Count == 0)
        {
            Debug.LogError("No meteor spawn points assigned!");
            return Vector3.zero;
        }

        return meteorSpawnPoints[Random.Range(0, meteorSpawnPoints.Count)].position;
    }
    // HomePlanet spawner
    public void SpawnPlanet()
    {
        GameObject homePlanet = Instantiate(planetPrefab, Vector3.zero, Quaternion.identity);
    }
    // Random location Meteor spawner
    public void SpawnMeteor()
    {
        GameObject newMeteor = Instantiate(meteorPrefab, GetRandomSpawnPoint(), Quaternion.identity);
        newMeteor.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }
    //Controller spawner
    public void SpawnPlayerController()
    {

        GameObject newControllersObject = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);
        PlayerController newPlayerControllerComponent = newControllersObject.GetComponent<PlayerController>();

        if (newPlayerControllerComponent != null)
        {
            players.Add(newPlayerControllerComponent);
        }
    }
    //Player spawner
    public void SpawnPlayer()
    {
        // Make sure at least one controller exists
        if (players.Count == 0)
        {
            return;
        }
        // Always work with the first player
        PlayerController playerController = players[0];

        // Check for existing pawn and kill it if it does
        if (playerController.pawn != null)
            Destroy(playerController.pawn.gameObject);

        // Spawn new pawn in front of the planet
        GameObject newPawnObject = Instantiate(playerPawnPrefab, new Vector3(0, 0, -0.1f), Quaternion.identity);

        // Assign pawn to controller
        playerController.pawn = newPawnObject.GetComponent<PlayerPawn>();

        // Assign camera follow
        if (Camera.main != null)
        {
            CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
            if (cameraFollow != null && playerController.pawn != null)
                cameraFollow.target = playerController.pawn.transform;
        }
    }
}
