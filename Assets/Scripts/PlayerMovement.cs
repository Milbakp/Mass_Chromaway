
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.Self);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.Self);
        }
    }
}
