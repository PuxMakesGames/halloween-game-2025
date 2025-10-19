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


        private void Awake()
        {
            // Cache components
            motor = GetComponent<CharacterMotor>();

            // Cache input actions
            moveAction = InputSystem.actions.FindAction("Move");
        }

        private void Update()
        {
            // Handle character movement
            var moveDirection = moveAction.ReadValue<Vector2>();
            motor.Move(moveDirection);
        }
    }
}
