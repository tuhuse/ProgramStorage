using Tuhuse.Shared.Interfaces;
using UnityEngine;
/// <summary>
/// プレイヤーインプットフラグクラス
/// </summary>
public class PlayerInput : IInput
{
  
    private readonly PlayerDamageReceiver _damageReceiver;
    // 既存フラグ
    public bool IsRightWalk { get; private set; }
    public bool IsLeftWalk { get; private set; }
    public bool IsForward { get; private set; }
    public bool IsBack { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsSkill { get; private set; }
    public bool IsAttack { get; private set; }
    public bool IsHit => _damageReceiver.IsKnockback;
    public PlayerInput(PlayerDamageReceiver damageReceiver)
    {
        _damageReceiver = damageReceiver;
    }
    public int ActiveSkillIndex { get; private set; } = 1;

    public bool IsLeftDiagonalWalk => throw new System.NotImplementedException();

    public bool IsRightDiagonalWalk => throw new System.NotImplementedException();

    public void InputUpdate()
    {
        IsRightWalk = Input.GetKey(KeyCode.D);
        IsLeftWalk = Input.GetKey(KeyCode.A);
        IsForward = Input.GetKey(KeyCode.W);
        IsBack = Input.GetKey(KeyCode.S);

        IsJump = Input.GetKeyDown(KeyCode.Space);
        IsSkill = Input.GetKeyDown(KeyCode.Q)||Input.GetKeyDown(KeyCode.E);
        IsAttack = Input.GetMouseButtonDown(0);

        // 数字キーでスキル切り替え
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActiveSkillIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActiveSkillIndex = 2;
        }
        
    }
    
    
}
