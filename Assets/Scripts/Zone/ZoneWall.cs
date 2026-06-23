using System.Collections.Generic;
using UnityEngine;

public class ZoneWall : MonoBehaviour
{
    public GameObject wallPrefab;
    public List<GameObject> wallsInZone = new List<GameObject>();
    public Zone parentZone;
    public int MinNumberOfWalls = 5;
    public int MaxNumberOfWalls = 10;
    void Start()
    {
        parentZone = GetComponent<Zone>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parentZone.zoneSpecial && parentZone.removeSpcieal)
        {
            parentZone.zoneSpecial = false;
            parentZone.removeSpcieal = false;
            removeWallsInZone();
            createWallsInZone();
        }
    }
    public void createWallsInZone()
    {
        Debug.Log("Creating walls in zone");
        // Get the size of the platform's mesh
        MeshRenderer plateRenderer = parentZone.section.GetComponent<MeshRenderer>();
        Bounds bounds = plateRenderer.bounds;

        int randomNumOfWalls = Random.Range(MinNumberOfWalls, MaxNumberOfWalls);

        for (int i = 0; i < randomNumOfWalls; i++)
        {
            // Calculate random X and Z within the platform bounds
            // We subtract a small offset so cubes don't hang off the edge
            float randomX = Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f);
            float randomZ = Random.Range(bounds.min.z + 0.5f, bounds.max.z - 0.5f);
            
            // Set Y to be slightly above the platform surface
            float spawnY = bounds.max.y + 2f;

            Vector3 randomPos = new Vector3(randomX, spawnY, randomZ);

            // Instantiate the wall
            GameObject wall = Instantiate(wallPrefab, randomPos, Quaternion.identity);
            wall.transform.parent = this.transform;
            wallsInZone.Add(wall);
        }
    }

    public void removeWallsInZone()
    {
        Debug.Log("Removing walls in zone");
        foreach (GameObject wall in wallsInZone)
        {
            Destroy(wall);
        }
        wallsInZone.Clear();
    }
}
