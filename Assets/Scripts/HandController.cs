using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    [SerializeField] private XRRayInteractor xrRayInteractor;
    [SerializeField] private ActionBasedController actionBasedController;
    [SerializeField] private XRDirectInteractor xrDirectInteractior;
    [SerializeField] private InputActionReference teleportActionRef;

    private void OnEnable()
    {
        teleportActionRef.action.performed += TeleportModeActivate;
        teleportActionRef.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeActivate(InputAction.CallbackContext context)
    {
        xrDirectInteractior.enabled = false;

        xrRayInteractor.enabled = true;
        actionBasedController.enableInputActions = true;
    }

    private void TeleportModeCancel(InputAction.CallbackContext context) => Invoke("DisableTeleport", 0.05f);

    private void DisableTeleport()
    {
        xrDirectInteractior.enabled = true;

        xrRayInteractor.enabled = false;
        actionBasedController.enableInputActions = false;
    }

    private void OnDisable()
    {
        teleportActionRef.action.performed -= TeleportModeActivate;
        teleportActionRef.action.canceled -= TeleportModeCancel;
    }
}
