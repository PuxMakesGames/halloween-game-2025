using UnityEngine;
using UnityEngine.InputSystem;

namespace PuxMakesGames.Halloween2025
{
    [SelectionBase]
    [RequireComponent(typeof(CharacterMotor))]
    public class PlayerController : MonoBehaviour
    {
        // Component references
        private CharacterMotor motor;

        // Input
        private InputAction moveAction;
        private InputAction lookAction;


        private void Awake()
        {
            // Cache components
            motor = GetComponent<CharacterMotor>();

            // Cache input actions
            moveAction = InputSystem.actions.FindAction("Move");
            lookAction = InputSystem.actions.FindAction("Look");
        }

        private void Update()
        {
            // Handle character movement
            var moveDirection = moveAction.ReadValue<Vector2>();
            motor.Move(moveDirection);

            // Handle character look rotation
            var lookDirection = lookAction.ReadValue<Vector2>();
            motor.Look(lookDirection);
        }
    }
}
