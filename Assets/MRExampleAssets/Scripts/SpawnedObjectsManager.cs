using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

[RequireComponent(typeof(ObjectSpawner))]
public class SpawnedObjectMannager : MonoBehaviour
{
    public GameObject targetObject;

    [SerializeField]
    TMP_Dropdown m_ObjectSelectorDropdown;

    [SerializeField]
    Button m_DestroyObjectsButton;

    [SerializeField]
    Slider positionSlider;

    [SerializeField]
    Slider rotationSlider;

    [SerializeField]
    Slider scaleSlider;

    ObjectSpawner m_Spawner;
    TransformController m_TransformController;

    void OnEnable()
    {
        m_Spawner = GetComponent<ObjectSpawner>();
        m_Spawner.spawnAsChildren = true;
        OnObjectSelectorDropdownValueChanged(m_ObjectSelectorDropdown.value);
        m_ObjectSelectorDropdown.onValueChanged.AddListener(OnObjectSelectorDropdownValueChanged);
        m_DestroyObjectsButton.onClick.AddListener(OnDestroyObjectsButtonClicked);

        // Find the TransformController script in the scene
        m_TransformController = FindObjectOfType<TransformController>();

        // Subscribe to the slider value change events in both scripts
        positionSlider.onValueChanged.AddListener(MoveObject);
        rotationSlider.onValueChanged.AddListener(RotateObject);
        scaleSlider.onValueChanged.AddListener(ScaleObject);

        m_TransformController.positionSlider.onValueChanged.AddListener(MoveSpawnedObjects);
        m_TransformController.rotationSlider.onValueChanged.AddListener(RotateSpawnedObjects);
        m_TransformController.scaleSlider.onValueChanged.AddListener(ScaleSpawnedObjects);
    }

    void OnDisable()
    {
        m_ObjectSelectorDropdown.onValueChanged.RemoveListener(OnObjectSelectorDropdownValueChanged);
        m_DestroyObjectsButton.onClick.RemoveListener(OnDestroyObjectsButtonClicked);

        // Unsubscribe from the slider value change events in both scripts
        positionSlider.onValueChanged.RemoveListener(MoveObject);
        rotationSlider.onValueChanged.RemoveListener(RotateObject);
        scaleSlider.onValueChanged.RemoveListener(ScaleObject);

        m_TransformController.positionSlider.onValueChanged.RemoveListener(MoveSpawnedObjects);
        m_TransformController.rotationSlider.onValueChanged.RemoveListener(RotateSpawnedObjects);
        m_TransformController.scaleSlider.onValueChanged.RemoveListener(ScaleSpawnedObjects);
    }

    void OnObjectSelectorDropdownValueChanged(int value)
    {
        if (value == 0)
        {
            m_Spawner.RandomizeSpawnOption();
            return;
        }

        m_Spawner.spawnOptionIndex = value - 1;
    }

    void OnDestroyObjectsButtonClicked()
    {
        foreach (Transform child in m_Spawner.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Apply transformations to targetObject
    void MoveObject(float sliderValue)
    {
        m_TransformController.MoveObject(sliderValue);
    }

    void RotateObject(float sliderValue)
    {
        m_TransformController.RotateObject(sliderValue);
    }

    void ScaleObject(float sliderValue)
    {
        m_TransformController.ScaleObject(sliderValue);
    }

    // Apply transformations from TransformController to spawned objects
    void MoveSpawnedObjects(float sliderValue)
    {
        foreach (Transform child in m_Spawner.transform)
        {
            if (child != null)
            {
                // Apply the transformations using methods from TransformController
                m_TransformController.MoveObject(sliderValue);
            }
        }
    }

    void RotateSpawnedObjects(float sliderValue)
    {
        foreach (Transform child in m_Spawner.transform)
        {
            if (child != null)
            {
                // Apply the transformations using methods from TransformController
                m_TransformController.RotateObject(sliderValue);
            }
        }
    }

    void ScaleSpawnedObjects(float sliderValue)
    {
        foreach (Transform child in m_Spawner.transform)
        {
            if (child != null)
            {
                // Apply the transformations using methods from TransformController
                m_TransformController.ScaleObject(sliderValue);
            }
        }
    }
}
