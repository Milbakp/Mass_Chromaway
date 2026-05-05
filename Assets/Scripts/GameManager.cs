using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject section, section2;
    public List<GameObject> sections = new List<GameObject>();
    //public List<sectionInfo> ActiveSections = new List<sectionInfo>();
    //public List<GameObject> sectionsToRemove = new List<GameObject>();
    public float floorSpeed = 2;
    public Inventory inventory = new Inventory();
    public GameObject gameOverScreen;
    public struct sectionInfo
    {
        public bool isActive;
        public string sectionType;
        public GameObject section;
    }
    void Start()
    {
        GameObject tmp = Instantiate(section, new Vector3(0, 0, 100), Quaternion.identity);
        GameObject tmp2 = Instantiate(section2, new Vector3(0, 0, 400), Quaternion.identity);
        sections.Add(tmp);
        sections.Add(tmp2);

        inventory = FindAnyObjectByType<Inventory>();
        gameOverScreen.SetActive(false);

        // GameObject tmp3 = Instantiate(section2, new Vector3(0, 0, 100), Quaternion.identity);
        // GameObject tmp4 = Instantiate(section2, new Vector3(0, 0, 400), Quaternion.identity);
        // sections.Add(new sectionInfo { section = tmp3, sectionType = "Wall", isActive = false });
        // sections.Add(new sectionInfo { section = tmp4, sectionType = "Wall", isActive = false });
        // foreach(sectionInfo sec in sections)
        // {
        //     sec.section.SetActive(false);
        // }
        // //int index = Random.Range(0, sections.Count);
        // var result = sections[0];
        // result.section.SetActive(true);
        // result.section.transform.localPosition = new Vector3(0, 0, 100);
        // result.section.GetComponent<Zone>().removeCubesInZone();
        // result.section.GetComponent<Zone>().createCubesInZone();
        // result.isActive = true;
        // sections[0] = result;

        // var result2 = sections[1];
        // result2.section.SetActive(true);
        // result2.section.transform.localPosition = new Vector3(0, 0, 400);
        // result2.section.GetComponent<Zone>().removeCubesInZone();
        // result2.section.GetComponent<Zone>().createCubesInZone();
        // result2.isActive = true;
        // sections[1] = result2;

        // foreach(sectionInfo sec in sections)
        // {
        //     Debug.Log($"Section: {sec.sectionType}, Active: {sec.isActive}");
        // }

    }

    // Update is called once per frame
    void Update()
    {
        // GameObject toRemove = new GameObject();
        foreach (GameObject sec in sections)
        {
            // if(sections[i].isActive == false)
            // {
            //     continue;
            // }
            sec.transform.Translate(Vector3.back * Time.deltaTime * floorSpeed, Space.Self);
            if(sec.transform.localPosition.z <= -180)
            {
                // sectionInfo tmpSec = sections[i];
                // tmpSec.section.SetActive(false);
                // tmpSec.isActive = false;
                // sections[i] = tmpSec;
                // randomSectionActivation();
                sec.GetComponent<Zone>().removeCubesInZone();
                sec.GetComponent<Zone>().createCubesInZone();
                sec.transform.localPosition = new Vector3(0, 0, 420);
            }
        }
        if (inventory.isGameOver && !gameOverScreen.activeSelf)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    // public void randomSectionActivation()
    // {
    //     var activeMembers = sections.Where(m => m.isActive == false).ToList();

    //     // Make sure there's actually someone to pick
    //     if (activeMembers.Any())
    //     {
    //         int index = Random.Range(0, activeMembers.Count);
    //         var result = activeMembers[index];
    //         result.section.SetActive(true);
    //         result.section.transform.localPosition = new Vector3(0, 0, 420);
    //         result.section.GetComponent<Zone>().removeCubesInZone();
    //         result.section.GetComponent<Zone>().createCubesInZone();
    //         result.isActive = true;
    //         sections[index] = result;
    //     }
    //     else
    //     {
    //         Debug.Log("No active members found.");
    //     }
    // }

    public void reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
