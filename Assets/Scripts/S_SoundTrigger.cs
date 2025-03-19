using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class S_SoundTrigger : MonoBehaviour
{
    #region Variables
    private BoxCollider collider;
    [SerializeField] private UnityEvent floorTriggered;
    #endregion

    private void Start()
    {
        collider = GetComponent<BoxCollider>();

        if (floorTriggered == null )
            floorTriggered = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        floorTriggered.Invoke();
    }
}
