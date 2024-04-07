using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hands.Scripts
{
    public class SnapHandAnimaton : MonoBehaviour
    {
        [SerializeField] private Animator handAnimator;
        [SerializeField] private InputActionReference triggerActionRef;
        [SerializeField] private InputActionReference gripActionRef;

        private static readonly int TriggerAnimation = Animator.StringToHash("Trigger");
        private static readonly int GripAnimation = Animator.StringToHash("Grip");

        private void OnEnable()
        {
            triggerActionRef.action.performed += TriggerAction_perfomed;
            triggerActionRef.action.canceled += TriggerAction_canceled;

            gripActionRef.action.performed += GripAction_perfomed;
            gripActionRef.action.canceled += GripAction_canceled;
        }

        private void GripAction_canceled(InputAction.CallbackContext context) => handAnimator.SetFloat(GripAnimation, 0f);


        private void GripAction_perfomed(InputAction.CallbackContext context) => handAnimator.SetFloat(GripAnimation, 1f);

        private void TriggerAction_canceled(InputAction.CallbackContext context) => handAnimator.SetFloat(TriggerAnimation, 0f);
        
        private void TriggerAction_perfomed(InputAction.CallbackContext context) => handAnimator.SetFloat(TriggerAnimation, 1f);


        private void OnDisable()
        {
            triggerActionRef.action.performed -= TriggerAction_perfomed;
            triggerActionRef.action.canceled -= TriggerAction_canceled;

            gripActionRef.action.performed -= GripAction_perfomed;
            gripActionRef.action.canceled -= GripAction_canceled;
        }
    }
}
