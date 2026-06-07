using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
