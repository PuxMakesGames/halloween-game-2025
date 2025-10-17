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
        private Vector3 inputDirection;

        private void Awake()
        {
            // Cache components
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // Handle character rotation
            if (inputDirection.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(inputDirection);
            }
        }

        private void FixedUpdate()
        {
            // Handle movement
            var targetVelocity = inputDirection * moveSpeed;
            rb.linearVelocity = targetVelocity;
        }

        public void Move(Vector2 direction)
        {
            inputDirection = new Vector3(direction.x, 0f, direction.y);
        }
    }
}
