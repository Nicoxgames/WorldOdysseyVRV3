using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour {

    public InputActionReference grip;
    public InputActionReference trigger;

    private Animator anim;
    private float gripValue;
    private float triggerValue;

    void Start() {
        anim = GetComponent<Animator>();
    }

    
    void Update() {
        animGrip();
        animTrigger();
    }

    private void animGrip() {
        gripValue = grip.action.ReadValue<float>();
        anim.SetFloat("Grip", gripValue);
    }

    private void animTrigger() {
        triggerValue = trigger.action.ReadValue<float>();
        anim.SetFloat("Trigger", triggerValue);
    }
}
