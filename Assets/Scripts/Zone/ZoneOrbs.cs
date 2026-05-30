using System.Collections.Generic;
using UnityEngine;

public class ZoneOrbs : MonoBehaviour
{
    public GameObject orbPrefab;
    public List<GameObject> orbsInZone = new List<GameObject>();
    public Zone parentZone;
    public int numberOfOrbs = 5;
    bool orbsLaunched = false;
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
            removeOrbsInZone();
            createOrbsInZone();
        }
        if(transform.localPosition.z <= 180 && !orbsLaunched)
        {
            lauchOrbs();
            orbsLaunched = true;
        }
    }
    public void createOrbsInZone()
    {
        Debug.Log("Creating orbs in zone");
        // Get the size of the platform's mesh
        MeshRenderer plateRenderer = parentZone.section.GetComponent<MeshRenderer>();
        Bounds bounds = plateRenderer.bounds;

        for (int i = 0; i < numberOfOrbs; i++)
        {
            // Calculate random X and Z within the platform bounds
            // We subtract a small offset so cubes don't hang off the edge
            float randomX = Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f);
            float randomZ = Random.Range(bounds.min.z + 0.5f, bounds.max.z - 0.5f);
            
            // Set Y to be slightly above the platform surface
            float spawnY = bounds.max.y + 4f;

            Vector3 randomPos = new Vector3(randomX, spawnY, randomZ);

            // Instantiate the orb
            GameObject orb = Instantiate(orbPrefab, randomPos, Random.rotationUniform);
            orb.transform.parent = this.transform;
            orbsInZone.Add(orb);
        }
        orbsLaunched = false;
    }

    public void removeOrbsInZone()
    {
        Debug.Log("Removing orbs in zone");
        foreach (GameObject orb in orbsInZone)
        {
            Destroy(orb);
        }
        orbsInZone.Clear();
    }

    public void lauchOrbs()
    {
        Debug.Log("Launching orbs in zone");
        foreach (GameObject orb in orbsInZone)
        {
            orb.GetComponent<OrbLauch>().Launch();
        }
    }
}
