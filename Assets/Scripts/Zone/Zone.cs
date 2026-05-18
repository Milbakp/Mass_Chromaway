using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public GameObject section;
    public GameObject cubePrefab;
    public List<GameObject> cubesInZone = new List<GameObject>();
    public int numberOfCubes = 5;
    public bool zoneSpecial = false, removeSpcieal = false;
    public GameManager gameManager;
    private GameObject powerUpInZone;
    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void Start()
    {
        removeCubesInZone();
        createCubesInZone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createCubesInZone()
    {
        // Get the size of the platform's mesh
        MeshRenderer plateRenderer = section.GetComponent<MeshRenderer>();
        Bounds bounds = plateRenderer.bounds;

        for (int i = 0; i < numberOfCubes; i++)
        {
            // Calculate random X and Z within the platform bounds
            // We subtract a small offset so cubes don't hang off the edge
            float randomX = Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f);
            float randomZ = Random.Range(bounds.min.z + 0.5f, bounds.max.z - 0.5f);
            
            // Set Y to be slightly above the platform surface
            float spawnY = bounds.max.y + 2f;

            Vector3 randomPos = new Vector3(randomX, spawnY, randomZ);

            // Instantiate the cube
            GameObject cube = Instantiate(cubePrefab, randomPos, Quaternion.identity);
            cube.transform.parent = this.transform;
            cubesInZone.Add(cube);
        }
        // Spawn a random power up in the zone
        int randomPowerUpIndex = Random.Range(0, gameManager.powerUpPrefabs.Count);
        float ranX = Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f);
        float ranZ = Random.Range(bounds.min.z + 0.5f, bounds.max.z - 0.5f);
        float sY = bounds.max.y + 2f;
        Vector3 ranPos = new Vector3(ranX, sY, ranZ);
        powerUpInZone = Instantiate(gameManager.powerUpPrefabs[randomPowerUpIndex], ranPos, Quaternion.identity);
        powerUpInZone.transform.parent = this.transform;

        zoneSpecial = true;
    }

    public void removeCubesInZone()
    {
        foreach (GameObject cube in cubesInZone)
        {
            Destroy(cube);
        }
        cubesInZone.Clear();
        removeSpcieal = true;
        if(powerUpInZone != null)
        {
            Destroy(powerUpInZone);
        }
    }
}
