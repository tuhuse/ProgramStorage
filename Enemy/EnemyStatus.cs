using System;
using UnityEngine;
/// <summary>
/// �G�̃X�e�[�^�X�N���X
/// </summary>
public class EnemyStatus : MonoBehaviour,IStatusUI
{
   [SerializeField] private Status _baseStatus; // ��b�f�[�^
    private RuntimeStatus _runtimeStatus;

    public event Action<int, int> OnHpChanged;

    public IStatus Status => _runtimeStatus;

    private void Awake()
    {
        _runtimeStatus = new RuntimeStatus(_baseStatus);
        // RuntimeStatus �̃C�x���g��������
        _runtimeStatus.OnHpChanged += (hp, maxHp) => OnHpChanged?.Invoke(hp, maxHp);
    }
    /// <summary>
    /// �_���[�W���󂯂��ۂ̏���
    /// </summary>
    /// <param name="damage">�v���C���[�̍U����</param>
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
