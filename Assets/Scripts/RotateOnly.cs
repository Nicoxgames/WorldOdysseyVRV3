using UnityEngine;

public class RestrictMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public bool allowRotation = true;

    private void Start()
    {
        // Store the initial position and rotation of the object
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Lock the position to the initial position
        transform.position = initialPosition;

        if (!allowRotation)
        {
            // If rotation is not allowed, reset the rotation to the initial state
            transform.rotation = initialRotation;
        }
        else
        {
            // Allow rotation only along X and Y axes
            float xRotation = transform.rotation.eulerAngles.x;
            float yRotation = transform.rotation.eulerAngles.y;

            // Apply only X and Y rotation, keeping the initial Z rotation constant
            transform.rotation = Quaternion.Euler(xRotation, yRotation, initialRotation.eulerAngles.z);
        }
    }
}
