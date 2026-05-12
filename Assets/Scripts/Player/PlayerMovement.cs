
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    public float leftMax, rightMax;
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.Self);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(!(transform.localPosition.x <= leftMax))
            {
               transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.Self); 
            }
            
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if(!(transform.localPosition.x >= rightMax))
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.Self);
            }
            
        }
    }
}
