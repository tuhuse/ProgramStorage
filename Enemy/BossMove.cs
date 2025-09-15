using Tuhuse.Shared.Interfaces;
using UnityEngine;
/// <summary>
/// ボスの追尾挙動処理クラス
/// </summary>
public class BossMove : MonoBehaviour, IMove, ITimeAffectable
{
    private Rigidbody _rb;
    private bool _isStopped;
    private Vector3 _storedVelocity;

    public Vector3 Position => transform.position;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// 移動処理
    /// </summary>
    /// <param name="x">X軸</param>
    /// <param name="z">Z軸</param>
    public void Move(float x, float z)
    {
        if (_isStopped) return; //  時止め中は無効化
        _rb.velocity = new Vector3(x, _rb.velocity.y, z);
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
