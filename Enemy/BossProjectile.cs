using Tuhuse.Shared.Interfaces;
using UnityEngine;
/// <summary>
/// 遠距離攻撃の弾の挙動処理クラス
/// </summary>
public class BossProjectile : MonoBehaviour, ITimeAffectable
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _lifeTime = 5f;
    private bool _isStopped = false;
    private Vector3 _storedVelocity;
    private EnemyStatus _enemyStatus = default;




    private void Start()
    {
        _enemyStatus = GameObject.FindFirstObjectByType<EnemyStatus>();
        Destroy(gameObject, _lifeTime); // 一定時間で消滅
    }

    public void Launch(Vector3 direction, float speed)
    {
        _rb.velocity = direction.normalized * speed;
    }
    /// <summary>
    /// 投石処理
    /// </summary>
    /// <param name="target">プレイヤー位置</param>
    /// <param name="speed">投石の早さ</param>
    public void LaunchParabola(Vector3 target, float speed)
    {
        _rb.isKinematic = false;
        _rb.useGravity = true;

        Vector3 toTarget = target - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);

        float xz = toTargetXZ.magnitude;
        float y = toTarget.y;
        float g = Physics.gravity.y;


        float angle = 45f * Mathf.Deg2Rad;
        float v = speed;

        float vy = v * Mathf.Sin(angle);
        float vxz = v * Mathf.Cos(angle);

        Vector3 dirXZ = toTargetXZ.normalized;
        Vector3 velocity = dirXZ * vxz;
        velocity.y = vy;

        _rb.velocity = velocity;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDamageReceiver playerStatus = other.GetComponent<PlayerDamageReceiver>();
            playerStatus.ReceiveDamage(_enemyStatus.Status.Attack, this.transform);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
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
        _rb.velocity = _storedVelocity;
        _isStopped = false;
    }
    private void OnDestroy()
    {
        SkillManager skillManager = FindObjectOfType<SkillManager>();
        if (skillManager != null)
        {
            skillManager.TimeTargets.Remove(this);
        }
    }

}
