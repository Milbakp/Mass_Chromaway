using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 8, playerTransform.position.z - 11);
    }
}
