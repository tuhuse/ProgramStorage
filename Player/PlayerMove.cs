using Tuhuse.Shared.Interfaces;
using UnityEngine;
namespace Tuhuse.PlayerSystem.Movement
{
    /// <summary>
    /// プレイヤーの移動挙動処理を書いてるクラス
    /// </summary>
    public class PlayerMove : MonoBehaviour, IMove
    {
        private Rigidbody _rb = default;
        private PlayerRewind _playerRewind = default;

        [SerializeField] private CameraController _cameraController; // ← カメラ参照
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

            // 入力をベクトルに
            Vector3 inputDir = new Vector3(x, 0, z).normalized;

            if (inputDir.magnitude > 0.1f)
            {
                // カメラの向きを基準に回す
                Vector3 moveDir = _cameraController.GetCameraYaw() * inputDir;

                // 移動
                Vector3 velocity = moveDir * moveSpeed;
                velocity.y = _rb.velocity.y; // 重力は保持
                _rb.velocity = velocity;

                // プレイヤーの向きを移動方向に合わせる
                transform.rotation = Quaternion.LookRotation(moveDir);
            }
            else
            {
                // 入力なしなら横の速度止める
                _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            }
        }
    }
}
