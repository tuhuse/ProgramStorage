using System;
using UnityEngine;
/// <summary>
/// 敵のステータスクラス
/// </summary>
public class EnemyStatus : MonoBehaviour,IStatusUI
{
   [SerializeField] private Status _baseStatus; // 基礎データ
    private RuntimeStatus _runtimeStatus;

    public event Action<int, int> OnHpChanged;

    public IStatus Status => _runtimeStatus;

    private void Awake()
    {
        _runtimeStatus = new RuntimeStatus(_baseStatus);
        // RuntimeStatus のイベントを横流し
        _runtimeStatus.OnHpChanged += (hp, maxHp) => OnHpChanged?.Invoke(hp, maxHp);
    }
    /// <summary>
    /// ダメージを受けた際の処理
    /// </summary>
    /// <param name="damage">プレイヤーの攻撃力</param>
    public void ReceiveDamage(int damage)
    {
        _runtimeStatus.TakeDamage(damage);
        Debug.Log($"Boss HP: {_runtimeStatus.HP}/{_baseStatus.HP}");

        if (_runtimeStatus.IsDead)
        {
            GameSceneManager.Instance.LoadGameClearScene();
          
        }
    }
}
