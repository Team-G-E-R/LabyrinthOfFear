using System;
using UnityEngine;

namespace Common.Scripts
{
    public class movement : MonoBehaviour
    {
        #region Constants

        private static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");

        #endregion

        #region Inspector

        [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;
        [SerializeField] private float speed = 100f;
        [SerializeField] private float sprintSpeedBonus = 50f;

        [Header("Relations")]
        [SerializeField]
        private Animator animator = null;

        [SerializeField]
        private Rigidbody physicsBody = null;

        [SerializeField]
        private SpriteRenderer spriteRenderer = null;

        #endregion


        #region Fields

        private Vector3 _movement;
        private bool _movementLocked;
        private bool _sprintLocked;

        #endregion


        #region MonoBehaviour

        private void Update()
        {
            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            if (horizontal > 0)
                spriteRenderer.flipX = false;
            else if (horizontal < 0)
                spriteRenderer.flipX = true;

            _movement = new Vector3(horizontal, 0, vertical).normalized;
        }

        private void FixedUpdate()
        {
            if (_movementLocked)
                return;

            float sprint = _sprintLocked == false && Input.GetKey(_sprintKey) ? sprintSpeedBonus : 0;
            physicsBody.velocity = _movement * (speed + sprint) * Time.fixedDeltaTime;
        }

        public void SetSprint(bool sprint) => _sprintLocked = !sprint;
        public void SetWalk(bool walk) => _movementLocked = !walk;

        #endregion
    }
}
