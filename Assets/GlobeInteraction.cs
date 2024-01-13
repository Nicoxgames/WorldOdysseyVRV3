using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GlobeInteraction : MonoBehaviour
{
    public ActionBasedController leftHandController;
    public ActionBasedController rightHandController;

    private Vector3 lastHandPosition;
    private bool isHandGrabbing = false;
    private Quaternion lastGlobeRotation;

    void Update()
    {
        
        CheckGrab(leftHandController);
        CheckGrab(rightHandController);

        
        if (isHandGrabbing)
        {
            RotateGlobe();
        }
    }

    private void CheckGrab(ActionBasedController controller)
    {
        if (controller.selectAction.action.ReadValue<float>() > 0.1f)
        {
            if (!isHandGrabbing)
            {
              
                isHandGrabbing = true;
                lastHandPosition = controller.transform.position;
                lastGlobeRotation = transform.rotation;
            }
        }
        else if (isHandGrabbing)
        {
            // Relâcher le globe
            isHandGrabbing = false;
        }
    }

    private void RotateGlobe()
    {
        ActionBasedController activeController = isHandGrabbing && leftHandController.selectAction.action.ReadValue<float>() > 0.1f ? leftHandController : rightHandController;
        Vector3 currentHandPosition = activeController.transform.position;

        // Calculer la différence de position depuis la dernière position de la main
        Vector3 handDelta = currentHandPosition - lastHandPosition;

        // Déterminer l'axe de rotation basé sur le mouvement de la main
        Vector3 rotationAxis = Vector3.Cross(handDelta, transform.up).normalized;
        float angle = handDelta.magnitude * 100f; // La valeur 100f est un multiplicateur pour ajuster la sensibilité

        // Appliquer la rotation autour de l'axe déterminé
        transform.rotation = Quaternion.AngleAxis(angle, rotationAxis) * lastGlobeRotation;

        // Mise à jour de la dernière position de la main
        lastHandPosition = currentHandPosition;
        // Mise à jour de la dernière rotation du globe
        lastGlobeRotation = transform.rotation;
    }
}

