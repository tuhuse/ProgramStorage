using UnityEngine;
using System.Collections;
/// <summary>
/// �v���C���[���U�����󂯂��Ƃ��̏����������N���X
/// </summary>
public class PlayerDamageReceiver : MonoBehaviour
{
    [SerializeField] private PlayerStatus _playerStatus;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _knockbackForce = 10f;
    [SerializeField] private float _knockbackUpForce = 3f;

    private bool _isKnockback = false;

    public bool IsKnockback => _isKnockback;
    /// <summary>
    /// �U�����󂯂��Ƃ��̏���
    /// </summary>
    /// <param name="damage">�G�̍U����</param>
    /// <param name="attacker">�G�̈ʒu</param>
    public void ReceiveDamage(int damage, Transform attacker)
    {
        _playerStatus.ReceiveDamage(damage);
        StartCoroutine(KnockbackTime());
        // �m�b�N�o�b�N
        Vector3 dir = (transform.position - attacker.position).normalized;
        dir.y = 0;
        Vector3 knockback = dir * _knockbackForce + Vector3.up * _knockbackUpForce;

        _rb.velocity = Vector3.zero;
        _rb.AddForce(knockback, ForceMode.VelocityChange);

      
    }
    /// <summary>
    /// �m�b�N�o�b�N���󂯂Ă��鎞��
    /// </summary>
    /// <returns></returns>
    private IEnumerator KnockbackTime()
    {
        _isKnockback = true;
        yield return new WaitForSeconds(1f);
        _isKnockback = false;
    }
}
