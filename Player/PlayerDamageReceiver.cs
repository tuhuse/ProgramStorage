using UnityEngine;
using System.Collections;
/// <summary>
/// プレイヤーが攻撃を受けたときの処理を書くクラス
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
    /// 攻撃を受けたときの処理
    /// </summary>
    /// <param name="damage">敵の攻撃力</param>
    /// <param name="attacker">敵の位置</param>
    public void ReceiveDamage(int damage, Transform attacker)
    {
        _playerStatus.ReceiveDamage(damage);
        StartCoroutine(KnockbackTime());
        // ノックバック
        Vector3 dir = (transform.position - attacker.position).normalized;
        dir.y = 0;
        Vector3 knockback = dir * _knockbackForce + Vector3.up * _knockbackUpForce;

        _rb.velocity = Vector3.zero;
        _rb.AddForce(knockback, ForceMode.VelocityChange);

      
    }
    /// <summary>
    /// ノックバックを受けている時間
    /// </summary>
    /// <returns></returns>
    private IEnumerator KnockbackTime()
    {
        _isKnockback = true;
        yield return new WaitForSeconds(1f);
        _isKnockback = false;
    }
}
