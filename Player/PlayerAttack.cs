using Tuhuse.PlayerSystem.StateMachines;
using UnityEngine;
using System.Collections;
/// <summary>
/// ƒvƒŒƒCƒ„[UŒ‚‚Ì‹““®ˆ—
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _attackObj = default;
    private bool _isCoolTime = default;
    private bool _isAttack = default;
    private const float ATTACK_TIME = 1.8f;
    private const float COOL_TIME = 1f;
    public bool IsAttack => _isAttack;
    void Start()
    {
        PlayerStateMachine stateMachine = GameObject.FindFirstObjectByType<PlayerStateMachine>();
        stateMachine.StateEvent.OnAttack += MeleeAttack;
    }
    /// <summary>
    /// UŒ‚Às
    /// </summary>
    private void MeleeAttack()
    {
        if (_isCoolTime)
        {
            return;
        }
        StartCoroutine(AttackTime());
        _isCoolTime = true;
    }
    /// <summary>
    /// UŒ‚ŠÔ
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackTime()
    {
        _attackObj.SetActive(true);
        _isAttack = true;
        yield return new WaitForSeconds(ATTACK_TIME);
        _attackObj.SetActive(false);
        _isAttack = false;
        yield return new WaitForSeconds(COOL_TIME);
        _isCoolTime = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStatus enemyStatus = other.GetComponent<EnemyStatus>();
            PlayerStatus playerStatus = this.GetComponent<PlayerStatus>();
            enemyStatus.ReceiveDamage(playerStatus.Status.Attack);
        }
    }
}
