using UnityEngine;

namespace PuxMakesGames.Halloween2025
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMotor : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 10f;

        // Component references
        private Rigidbody rb;

        // Movement data
        private Vector3 inputMoveDirection;

        // Rotation data
        private Vector3 inputLookDirection;

        private void Awake()
        {
            // Cache components
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // Handle character rotation
            if (inputLookDirection.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(inputLookDirection);
            }
            else if (inputMoveDirection.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(inputMoveDirection);
            }
        }

        private void FixedUpdate()
        {
            // Handle movement
            var targetVelocity = inputMoveDirection * moveSpeed;
            rb.linearVelocity = targetVelocity;
        }

        public void Move(Vector2 direction)
        {
            inputMoveDirection = new Vector3(direction.x, 0f, direction.y);
        }

        public void Look(Vector2 direction)
        {
            inputLookDirection = new Vector3(direction.x, 0f, direction.y);
        }
    }
}
