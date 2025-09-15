using UnityEngine;
using Tuhuse.Shared.Interfaces;
using System.Collections;
/// <summary>
/// ボスのジャンプ攻撃の挙動処理クラス
/// </summary>
public class BossJumpAttack : MonoBehaviour, ITimeAffectable, IJump
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _attackRadius = 3f;
    [SerializeField] private LayerMask _playerLayer;

    private bool _isStopped=default;
    private bool _isJumping=default;
    private bool _isCoolTime = default;
    private const float COOL_TIME = 10f;
    private Vector3 _storedVelocity=default;
    
    private Transform _target; 

    public bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, 3f);

    public void SetTarget(Transform target) => _target = target;
    /// <summary>
    /// インターフェース実装
    /// </summary>
    /// <param name="force"></param>
    public void Jump(float force)
    {
        if (_target == null||_isStopped||_isCoolTime) return;
        StartCoroutine(AttackTime());
    }
    /// <summary>
    ///ジャンプ攻撃
    /// </summary>
    /// <param name="target">プレイヤー</param>
    public void JumpAttack(Transform target)
    {
        if (_isJumping) return;
        _isJumping = true;

        _rb.isKinematic = false;
        _rb.velocity = Vector3.zero;

        Vector3 toTarget = target.position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);

        float distanceXZ = toTargetXZ.magnitude;
        float y = toTarget.y;
        float g = Mathf.Abs(Physics.gravity.y);

        float time = 5.0f; //滞空時間を固定

        // 水平方向の速度
        Vector3 velocityXZ = toTargetXZ / time;

        // 垂直方向の速度
        float velocityY = (y / time) + (0.5f * g * time);

        // 合体
        Vector3 velocity = velocityXZ;
        velocity.y = velocityY;

        _rb.velocity = velocity;
    }
    /// <summary>
    /// ジャンプ攻撃＆クールタイム
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackTime()
    {  
        JumpAttack(_target);
        _isCoolTime = true;
        yield return new WaitForSeconds(COOL_TIME);
        _isCoolTime = false;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (!_isJumping) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _attackRadius, _playerLayer);
            foreach (Collider hit in hits)
            {
                PlayerDamageReceiver playerStatus = hit.GetComponent<PlayerDamageReceiver>(); // ← ここをhitに
                if (playerStatus != null)
                {
                    EnemyStatus enemyStatus = this.GetComponent<EnemyStatus>();
                    playerStatus.ReceiveDamage(enemyStatus.Status.Attack, this.transform);
                }
            }
            _isJumping = false;
        }
    }


    // 時間停止対応
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
        _rb.velocity = _storedVelocity;
        _isStopped = false;
    }
}
