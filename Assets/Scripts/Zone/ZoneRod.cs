using System.Collections.Generic;
using UnityEngine;

public class ZoneRod : MonoBehaviour
{
    public GameObject rodPrefab;
    public List<GameObject> rodsInZone = new List<GameObject>();
    public Zone parentZone;
    public int MinNumberOfRods = 5;
    public int MaxNumberOfRods = 10;
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
            removeRodsInZone();
            createRodsInZone();
        }
    }
    public void createRodsInZone()
    {
        Debug.Log("Creating rods in zone");
        // Get the size of the platform's mesh
        MeshRenderer plateRenderer = parentZone.section.GetComponent<MeshRenderer>();
        Bounds bounds = plateRenderer.bounds;

        int randomNumOfRods = Random.Range(MinNumberOfRods, MaxNumberOfRods);

        for (int i = 0; i < randomNumOfRods; i++)
        {
            // Calculate random X and Z within the platform bounds
            // We subtract a small offset so cubes don't hang off the edge
            float randomX = Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f);
            float randomZ = Random.Range(bounds.min.z + 0.5f, bounds.max.z - 0.5f);
            
            // Set Y to be slightly above the platform surface
            float spawnY = bounds.max.y + 2f;

            Vector3 randomPos = new Vector3(randomX, spawnY, randomZ);

            // Random y Rotation
            float randomY = Random.Range(0f, 360f);

            // Instantiate the rod
            GameObject rod = Instantiate(rodPrefab, randomPos, Quaternion.Euler(0f, randomY, 0f));
            rod.transform.parent = this.transform;
            rodsInZone.Add(rod);
        }
    }

    public void removeRodsInZone()
    {
        Debug.Log("Removing rods in zone");
        foreach (GameObject rod in rodsInZone)
        {
            Destroy(rod);
        }
        rodsInZone.Clear();
    }
}
