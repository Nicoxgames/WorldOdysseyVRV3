using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContinentInfoManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    public Image continentImage;
    public Canvas continentInfoCanvas; 
    public Camera playerCamera; 

    private void Update()
    {
        
        continentInfoCanvas.enabled = IsPlayerLookingAtCanvas();
    }

    public void UpdateContinentInfo(ContinentInfo info)
    {
        if (info != null)
        {
            descriptionText.text = info.description;
            continentImage.sprite = info.image;
            
        }
        else
        {
            Debug.LogWarning("Les informations du continent sont nulles.");
            
        }
    }

    public void DisplayDefaultOceanInfo()
    {
        descriptionText.text = "Mer ou Océan";
        continentImage.sprite = null;
       
    }

    private bool IsPlayerLookingAtCanvas()
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("CanvasLayer");

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            return hit.collider.gameObject == continentInfoCanvas.gameObject;
        }
        return false;
    }
}

