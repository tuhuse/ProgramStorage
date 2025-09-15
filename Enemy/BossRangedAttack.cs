using Tuhuse.Shared.Interfaces;
using UnityEngine;

public class BossRangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab=default;
    [SerializeField] private Transform _firePoint=default;
    [SerializeField] private Transform _targetPosi=default;  
    [SerializeField] private SkillManager skillManager;
    [SerializeField] private float _projectileSpeed = 10f;
    private GameObject _projObj = default;

    private void Start()
    {
        BossStateMachine boss = GameObject.FindFirstObjectByType<BossStateMachine>();
        boss.StateEvent.OnRangeAttack += OnRangeAttack;
    }
    /// <summary>
    /// イベント登録していて攻撃を実行する
    /// </summary>
    private void OnRangeAttack()
    {    
          ShootAt(_targetPosi);        
    }
    /// <summary>
    ///放物線UseGravityつける
    /// </summary>
    /// <param name="target">プレイヤー位置</param>
    public void ShootAt(Transform target)
    {
        if (_projObj == null)
        {
            _projObj = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
            BossProjectile projectile = _projObj.GetComponent<BossProjectile>();

            // ターゲットのワールド座標を渡す
            projectile.LaunchParabola(target.position, _projectileSpeed);
            if (projectile.TryGetComponent<ITimeAffectable>(out ITimeAffectable affectable))
            {
                skillManager.TimeTargets.Add(affectable);
            }
        }
         
    }
   

}
