using UnityEngine;

public class RGBCube : MonoBehaviour
{
    private Renderer RGBrenderer;
    void Awake()
    {
        RGBrenderer = gameObject.GetComponent<Renderer>();
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                RGBrenderer.material.color = Color.red;
                break;
            case 1:
                RGBrenderer.material.color = Color.green;
                break;
            case 2:
                RGBrenderer.material.color = Color.blue;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
