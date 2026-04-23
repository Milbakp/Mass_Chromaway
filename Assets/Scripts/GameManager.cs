using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello world! First time using Unity on this computer. I am bacn in C# and... this feels like home!");
        basicCoding("Doing the basics");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void basicCoding(string words){
        for(int i = 0; i < 3; i++){
            Debug.Log($"Repating {words}");
        }
    }
}
