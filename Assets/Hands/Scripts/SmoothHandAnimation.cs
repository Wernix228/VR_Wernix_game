    using UnityEngine.InputSystem;
using UnityEngine;

namespace Hands.Scripts
{

    public class SmoothHandAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _handAnimator;
        [SerializeField] private InputActionReference _triggerActionRef;
        [SerializeField] private InputActionReference _gripActionRef;

        private static readonly int TriggerAnimation = Animator.StringToHash("Trigger");
        private static readonly int GripAnimation = Animator.StringToHash("Grip");

        private void Update()
        {
            float triggerValue = _triggerActionRef.action.ReadValue<float>();
            _handAnimator.SetFloat(TriggerAnimation, triggerValue);

            float gripValue = _triggerActionRef.action.ReadValue<float>();
            _handAnimator.SetFloat(GripAnimation, gripValue);
        }
    }
}