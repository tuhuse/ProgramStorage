using Tuhuse.Shared.Interfaces;
using UnityEngine;

namespace Tuhuse.PlayerSystem.Movement
{
    /// <summary>
    /// �v���C���[�W�����v�̋��������N���X
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerJump : MonoBehaviour, IJump
    {
        [SerializeField] private Transform _groundCheck; // �����̈ʒu
        [SerializeField] private float _groundRadius = 0.2f;
        [SerializeField] private LayerMask _groundLayer;

        private Rigidbody _rb;

       public bool IsGrounded => Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundLayer);

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Jump(float force)
        {
            if (IsGrounded)
            {
                _rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }

      
    }
}
