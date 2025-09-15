using Tuhuse.Shared.Interfaces;
using UnityEngine;
namespace Tuhuse.PlayerSystem.Movement
{
    /// <summary>
    /// �v���C���[�̈ړ����������������Ă�N���X
    /// </summary>
    public class PlayerMove : MonoBehaviour, IMove
    {
        private Rigidbody _rb = default;
        private PlayerRewind _playerRewind = default;

        [SerializeField] private CameraController _cameraController; // �� �J�����Q��
        [SerializeField] private float moveSpeed = 5f;

        public Vector3 Position => this.transform.position;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _playerRewind = GetComponent<PlayerRewind>();
        }

        public void Move(float x, float z)
        {
            if (_playerRewind.IsRewinding)
                return;

            // ���͂��x�N�g����
            Vector3 inputDir = new Vector3(x, 0, z).normalized;

            if (inputDir.magnitude > 0.1f)
            {
                // �J�����̌�������ɉ�
                Vector3 moveDir = _cameraController.GetCameraYaw() * inputDir;

                // �ړ�
                Vector3 velocity = moveDir * moveSpeed;
                velocity.y = _rb.velocity.y; // �d�͕͂ێ�
                _rb.velocity = velocity;

                // �v���C���[�̌������ړ������ɍ��킹��
                transform.rotation = Quaternion.LookRotation(moveDir);
            }
            else
            {
                // ���͂Ȃ��Ȃ牡�̑��x�~�߂�
                _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            }
        }
    }
}
