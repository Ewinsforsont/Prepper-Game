using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;

public class S_GrabDetection : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("This is triggered when the object is picked up")]UnityEvent wasPickedUp;
    [SerializeField, Tooltip("The ISDK_HandGrabInteraction, will find it on it's own if left empty")] private HandGrabInteractable interactable;
    private bool hasBeenGrabbed;
    #endregion
    void Start()
    {
        if (wasPickedUp == null)
            wasPickedUp = new UnityEvent();

        hasBeenGrabbed = false;

        if (interactable == null)
            if (TryGetComponent<HandGrabInteractable>(out interactable))
                Debug.Log("Set interactable");
            else
                Debug.LogWarning("Failed to find interactable");
    }


    void Update()
    {
        if (!hasBeenGrabbed && interactable.State == InteractableState.Select)
        {
            hasBeenGrabbed = true;
            wasPickedUp.Invoke();
        }
        else if (hasBeenGrabbed && interactable.State == InteractableState.Normal || interactable.State == InteractableState.Hover && hasBeenGrabbed)
        {
            hasBeenGrabbed = false;
        }
    }
}
