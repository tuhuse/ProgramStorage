using System;
using UnityEngine;
/// <summary>
/// �v���C���[�̃X�e�[�^�X
/// </summary>
public class PlayerStatus : MonoBehaviour,IStatusUI
{
    [SerializeField] private Status _baseStatus; // ��b�f�[�^
    private RuntimeStatus _runtimeStatus;
    public event Action<int, int> OnHpChanged;
    public IStatus Status => _runtimeStatus;

    private void Awake()
    {
        _runtimeStatus = new RuntimeStatus(_baseStatus);
        _runtimeStatus.OnHpChanged += (hp, maxHp) => OnHpChanged?.Invoke(hp, maxHp);
    }

    public void ReceiveDamage(int damage)
    {
        _runtimeStatus.TakeDamage(damage);

        if (_runtimeStatus.IsDead)
        {   
            GameSceneManager.Instance.LoadGameOverScene();
            
        }
    }
}
