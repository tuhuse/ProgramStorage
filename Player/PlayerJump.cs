using Tuhuse.Shared.Interfaces;
using UnityEngine;

namespace Tuhuse.PlayerSystem.Movement
{
    /// <summary>
    /// プレイヤージャンプの挙動処理クラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerJump : MonoBehaviour, IJump
    {
        [SerializeField] private Transform _groundCheck; // 足元の位置
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
