using UnityEngine;
using ScriptableVariables;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _walkAnimationName;
        [SerializeField] private string _idleAnimationName;
        [SerializeField] private BoolVariable _popupOpen;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_popupOpen.Value) return;

            float inputHorizontal = Input.GetAxisRaw("Horizontal");
            float inputVertical = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(inputHorizontal, inputVertical).normalized;
            Vector2 position = _rigidbody2D.position + movement * _speed * Time.fixedDeltaTime;

            _rigidbody2D.MovePosition(position);
            UpdateAnimationMovement(movement);
        }

        private void UpdateAnimationMovement(Vector2 movement)
        {
            if (movement.sqrMagnitude > 0)
            {
                _animator.Play(_walkAnimationName);
            }
            else if (movement.sqrMagnitude == 0)
            {
                _animator.Play(_idleAnimationName);
            }

            if (movement.x < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if (movement.x > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);

            }
        }
    }
}
