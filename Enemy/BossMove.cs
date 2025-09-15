using Tuhuse.Shared.Interfaces;
using UnityEngine;
/// <summary>
/// �{�X�̒ǔ����������N���X
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
    /// �ړ�����
    /// </summary>
    /// <param name="x">X��</param>
    /// <param name="z">Z��</param>
    public void Move(float x, float z)
    {
        if (_isStopped) return; //  ���~�ߒ��͖�����
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
        _rb.velocity = _storedVelocity; // �� �ĊJ���ɓ����𕜌�
        _isStopped = false;
    }
}
