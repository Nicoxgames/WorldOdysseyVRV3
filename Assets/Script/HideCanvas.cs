using UnityEngine;

public class GazeHideCanvas : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the Canvas that will be hidden when not being looked at.")]
    Canvas m_CanvasToHide;

    [Header("Gaze Alignment Config")]
    [SerializeField]
    bool m_HideCanvasWhenGazeDiverges = true;

    [SerializeField]
    float m_CanvasVisibleGazeDivergenceThreshold = 35f;

    void OnEnable()
    {
        if (m_CanvasToHide == null)
        {
            Debug.LogError("Canvas to hide is not assigned. Please assign a Canvas in the inspector.", this);
            enabled = false;
            return;
        }

        // Add necessary bindings and initialization logic
    }

    void OnDisable()
    {
        // Clear bindings and cleanup logic
    }

    void LateUpdate()
    {
        bool shouldShowCanvas = CalculateVisibilityBasedOnGaze();
        m_CanvasToHide.gameObject.SetActive(shouldShowCanvas);
    }

    bool CalculateVisibilityBasedOnGaze()
    {
        if (!m_HideCanvasWhenGazeDiverges)
        {
            // Always show the canvas if gaze divergence check is disabled
            return true;
        }

        // Perform a check if the user is looking towards the canvas based on the angle
        // between the forward direction of the camera and the vector to the canvas
        Vector3 vectorToCanvas = m_CanvasToHide.transform.position - Camera.main.transform.position;
        float angleToCanvas = Vector3.Angle(Camera.main.transform.forward, vectorToCanvas);

        return angleToCanvas <= m_CanvasVisibleGazeDivergenceThreshold;
    }

    // ... Additional methods and properties as needed
}
