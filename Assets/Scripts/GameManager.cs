using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject section;
    public List<GameObject> sections = new List<GameObject>();
    //public List<GameObject> sectionsToRemove = new List<GameObject>();
    public float floorSpeed = 2;
    void Start()
    {
        Debug.Log("Hello world! First time using Unity on this computer. I am bacn in C# and... this feels like home!");
        basicCoding("Doing the basics");
        GameObject tmp = Instantiate(section, new Vector3(0, 0, 100), Quaternion.identity);
        GameObject tmp2 = Instantiate(section, new Vector3(0, 0, 400), Quaternion.identity);
        sections.Add(tmp);
        sections.Add(tmp2);
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject toRemove = new GameObject();
        foreach (GameObject singularSec in sections)
        {
            singularSec.transform.Translate(Vector3.back * Time.deltaTime * floorSpeed, Space.Self);
            if(singularSec.transform.localPosition.z <= -180)
            {
                singularSec.GetComponent<Zone>().removeCubesInZone();
                singularSec.GetComponent<Zone>().createCubesInZone();
                singularSec.transform.localPosition = new Vector3(0, 0, 420);
            }
        }
    }
    public void basicCoding(string words){
        for(int i = 0; i < 3; i++){
            Debug.Log($"Repating {words}");
        }
    }
}
