using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject section, section2, section3, section4;
    public List<sectionInfo> sections = new List<sectionInfo>();
    public float floorSpeed = 2;
    public Inventory inventory;
    public GameObject gameOverScreen;
    private PlayButtonSound playButtonSound;
    public class sectionInfo
    {
        public bool isActive;
        // public string sectionType;
        public GameObject section;
    }
    public List<GameObject> powerUpPrefabs = new List<GameObject>();
    void Start()
    {
        GameObject tmp = Instantiate(section, new Vector3(0, 0, 100), Quaternion.identity);
        GameObject tmp2 = Instantiate(section2, new Vector3(0, 0, 400), Quaternion.identity);
        GameObject tmp3 = Instantiate(section3, new Vector3(2000, 0, 1000), Quaternion.identity);
        GameObject tmp4 = Instantiate(section4, new Vector3(2000, 0, 1000), Quaternion.identity);
        sections.Add(new sectionInfo { section = tmp, isActive = true });
        sections.Add(new sectionInfo { section = tmp2, isActive = true });
        sections.Add(new sectionInfo { section = tmp3, isActive = false });
        sections.Add(new sectionInfo { section = tmp4, isActive = false });

        inventory = FindAnyObjectByType<Inventory>();
        gameOverScreen.SetActive(false);

        playButtonSound = FindAnyObjectByType<PlayButtonSound>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (sectionInfo sec in sections)
        {
            if(sec.isActive == false)
            {
                continue;
            }
            sec.section.transform.Translate(Vector3.back * Time.deltaTime * floorSpeed, Space.Self);
            if(sec.section.transform.localPosition.z <= -180)
            {
                sec.section.transform.localPosition = new Vector3(2000, 0, 1000);
                sec.isActive = false;
                randomSectionActivation();
            }
        }
        if (inventory.isGameOver && !gameOverScreen.activeSelf)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    public void randomSectionActivation()
    {
        List<int> iactiveIndices = new List<int>();
        for (int i = 0; i < sections.Count; i++)
        {
            if (sections[i].isActive == false)
            {
                iactiveIndices.Add(i);
            }
        }
        // Make sure there's actually someone to pick
        if (iactiveIndices.Count > 0)
        {
            int randomIndex = iactiveIndices[UnityEngine.Random.Range(0, iactiveIndices.Count)];
            Debug.Log($"Selected active struct at index: {randomIndex}");

            sections[randomIndex].section.transform.localPosition = new Vector3(0, 0, 420);
            sections[randomIndex].section.GetComponent<Zone>().removeCubesInZone();
            sections[randomIndex].section.GetComponent<Zone>().createCubesInZone();
            sections[randomIndex].isActive = true;
        }
        else
        {
            Debug.Log("No active members found.");
        }
    }

    public void reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playButtonSound.PlaySound();
    }
    public void returnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
        playButtonSound.PlaySound();
    }

}
