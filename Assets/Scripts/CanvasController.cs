using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;
    public GameObject canvas6;
    public GameObject canvas7;

    void Start()
    {
        // Deactivate all canvases on start
        DeactivateAllCanvases();
    }

    void DeactivateAllCanvases()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        canvas7.SetActive(false);
    }

    public void EnableCanvas1()
    {
        DeactivateAllCanvases();
        canvas1.SetActive(true);
    }

    public void EnableCanvas2()
    {
        DeactivateAllCanvases();
        canvas2.SetActive(true);
    }

    public void EnableCanvas3()
    {
        DeactivateAllCanvases();
        canvas3.SetActive(true);
    }

    public void EnableCanvas4()
    {
        DeactivateAllCanvases();
        canvas4.SetActive(true);
    }

    public void EnableCanvas5()
    {
        DeactivateAllCanvases();
        canvas5.SetActive(true);
    }

    public void EnableCanvas6()
    {
        DeactivateAllCanvases();
        canvas6.SetActive(true);
    }

    public void EnableCanvas7()
    {
        DeactivateAllCanvases();
        canvas7.SetActive(true);
    }

    // Function to ensure only one canvas is active at a time
    public void ActivateOnlyCanvas(GameObject canvasToActivate)
    {
        DeactivateAllCanvases();
        canvasToActivate.SetActive(true);
    }
    public void DoNothing()
    {
        // This function does nothing
    }
}
