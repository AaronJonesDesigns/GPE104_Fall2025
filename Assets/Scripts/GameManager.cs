using System.Collections.Generic;
using UnityEngine;

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
    public float meteorSpawnInterval = 3f; // seconds
    private float meteorTimer = 0f;
    public List<Transform> meteorSpawnPoints;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        // Make players list
        players = new List<PlayerController>();

        // Spawn the Player Controller
        SpawnPlayerController();

        // Spawn the Player Pawn
        SpawnPlayer();
        SpawnPlanet();
        SpawnMeteor();
        SpawnMeteor();
        SpawnMeteor();
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
    }
    public Vector3 GetRandomSpawnPoint()
    {
        if (meteorSpawnPoints == null || meteorSpawnPoints.Count == 0)
        {
            Debug.LogError("No meteor spawn points assigned!");
            return Vector3.zero;
        }
        
    return meteorSpawnPoints[Random.Range(0, meteorSpawnPoints.Count)].position;
    }
    public void SpawnPlanet()
    {
        Debug.Log("SpawnPlanet() called");

        GameObject homePlanet = Instantiate(planetPrefab, Vector3.zero, Quaternion.identity);
    }

    public void SpawnMeteor()
    {
        Debug.Log("SpawnMeteor() called");

        GameObject newMeteor = Instantiate(meteorPrefab, GetRandomSpawnPoint(), Quaternion.identity);
        newMeteor.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    public void SpawnPlayerController()
    {
        Debug.Log("Spawning player controller...");

        GameObject newControllersObject = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);
        PlayerController newPlayerControllerComponent = newControllersObject.GetComponent<PlayerController>();

        if (newPlayerControllerComponent != null)
        {
            players.Add(newPlayerControllerComponent);
            Debug.Log("Added PlayerController. Count = " + players.Count);
        }
        else
        {
            Debug.LogError("PlayerControllerPrefab is missing PlayerController script!");
        }
    }

    public void SpawnPlayer()
    {
        Debug.Log("SpawnPlayer() called");

        if (players.Count == 0)
        {
            Debug.LogError("No players in list! Did SpawnPlayerController() fail?");
            return;
        }

        PlayerController playerController = players[0];

        if (playerController.pawn != null)
        {
            Destroy(playerController.pawn.gameObject);
            playerController.pawn = null;
        }

        GameObject newPawnObject = Instantiate(playerPawnPrefab, new Vector3(0, 0,-0.1f), Quaternion.identity);

        if (newPawnObject != null)
        {
            PlayerPawn newPawn = newPawnObject.GetComponent<PlayerPawn>();
            if (newPawn != null)
            {
                // Link pawn to controller
                playerController.pawn = newPawn;
                Debug.Log("Spawned PlayerPawn and assigned it to PlayerController");

                // Auto-assign camera 
                if (Camera.main != null)
                {
                    CameraFollow cf = Camera.main.GetComponent<CameraFollow>();
                    if (cf != null)
                    {
                        cf.target = newPawn.transform; // <-- inside same scope as newPawn
                        Debug.Log("[GameManager] CameraFollow target set to new pawn.");
                    }
                }
            }
            else
            {
                Debug.LogError("Spawned pawn prefab does NOT have a PlayerPawn component!");
            }
        }
        else
        {
            Debug.LogError("Failed to instantiate PlayerPawn prefab!");
        }
    }
}
