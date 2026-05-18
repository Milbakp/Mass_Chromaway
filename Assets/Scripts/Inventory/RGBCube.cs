using UnityEngine;

public class RGBCube : MonoBehaviour
{
    private Renderer RGBrenderer;
    public string colorType;
    public virtual void Awake()
    {
        RGBrenderer = gameObject.GetComponent<Renderer>();
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                RGBrenderer.material.color = Color.red;
                colorType = "Red";
                break;
            case 1:
                RGBrenderer.material.color = Color.green;
                colorType = "Green";
                break;
            case 2:
                RGBrenderer.material.color = Color.blue;
                colorType = "Blue";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
