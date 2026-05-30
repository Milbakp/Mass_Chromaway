using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1.0f;

    void Update()
    {
        // Linearly increases the rotation angle over time
        float currentRotation = RenderSettings.skybox.GetFloat("_Rotation");
        float newRotation = currentRotation + (rotationSpeed * Time.deltaTime);
        
        // Keeps the value between 0 and 360 degrees
        newRotation %= 360f;

        // Apply the new rotation to the skybox material
        RenderSettings.skybox.SetFloat("_Rotation", newRotation);
    }
}
