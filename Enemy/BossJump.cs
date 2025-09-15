using UnityEngine;
using Tuhuse.Shared.Interfaces;
/// <summary>
/// ボスジャンプ挙動処理クラス
/// </summary>
public class BossJump : MonoBehaviour, IJump, ITimeAffectable
{
    [SerializeField] private float _groundCheckDistance = 2f;
    private Rigidbody _rb;   
    private bool _isStopped = false;
    private Vector3 _storedVelocity;
    public bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance);

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Jump(float force)
    {
        if (_isStopped) return; // 時止め中は無効化
        if (IsGrounded)
            _rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }


    public void OnTimeStop()
    {
        if (_isStopped) return;
        _storedVelocity = _rb.velocity;
        _rb.isKinematic = true;
        _isStopped = true;
    }

    public void OnTimeResume()
    {
        if (!_isStopped) return;
        _rb.isKinematic = false;
        _rb.velocity = _storedVelocity; // ← 再開時に動きを復元
        _isStopped = false;
    }

}
