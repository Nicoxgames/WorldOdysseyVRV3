using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class ContinentDetector : MonoBehaviour
{
    public ActionBasedController controller;
    public LayerMask globeLayer;
    public Texture2D continentTexture;
    public ContinentInfoManager continentInfoManager;
    private Dictionary<Color, ContinentInfo> colorToContinentInfo;

    private void Start()
    {
        colorToContinentInfo = new Dictionary<Color, ContinentInfo>
        { 
            { new Color(1, 0, 0), Resources.Load<ContinentInfo>("Assets/ContinentResources/Amérique du Sud.asset") },
            { new Color(1, 1, 0), Resources.Load<ContinentInfo>("Assets/ContinentResources/Afrique.asset") },
            { new Color(0, 1, 0), Resources.Load<ContinentInfo>("Assets/ContinentResources/Asie.asset") },
            { new Color(0, 0, 0), Resources.Load<ContinentInfo>("Assets/ContinentResources/Europe.asset") },
            { new Color(0, 1, 1), Resources.Load<ContinentInfo>("Assets/ContinentResources/Amérique du Nord.asset") },
            { new Color(1, 0, 1), Resources.Load<ContinentInfo>("Assets/ContinentResources/Océanie.asset") },
            { new Color(1, 1, 1), Resources.Load<ContinentInfo>("Assets/ContinentResources/Antarctique.asset") },
        };

    }

    private void Update()
    {
        if (controller.activateAction.action.triggered)
        {
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        Ray ray = new Ray(controller.transform.position, controller.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, globeLayer))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Vector2 hitUV = hit.textureCoord;
                hitUV.x *= continentTexture.width;
                hitUV.y *= continentTexture.height;
                Color pixelColor = continentTexture.GetPixelBilinear(hitUV.x, hitUV.y);
                IdentifyContinent(pixelColor);
            }
        }
    }

    private void IdentifyContinent(Color pixelColor)
    {
        float tolerance = 0.1f;
        ContinentInfo closestContinentInfo = null;
        float closestColorDistance = float.MaxValue;

        foreach (KeyValuePair<Color, ContinentInfo> pair in colorToContinentInfo)
        {
            float colorDistance = ColorDistance(pixelColor, pair.Key);
            if (colorDistance < closestColorDistance && colorDistance < tolerance)
            {
                closestColorDistance = colorDistance;
                closestContinentInfo = pair.Value;
            }
        }

        if (closestContinentInfo != null)
        {
            continentInfoManager.UpdateContinentInfo(closestContinentInfo);
        }
        else
        {
            continentInfoManager.DisplayDefaultOceanInfo();
        }
    }

    private float ColorDistance(Color c1, Color c2)
    {
        return Mathf.Sqrt((c1.r - c2.r) * (c1.r - c2.r) +
                          (c1.g - c2.g) * (c1.g - c2.g) +
                          (c1.b - c2.b) * (c1.b - c2.b));
    }
}





