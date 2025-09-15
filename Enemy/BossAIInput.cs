using UnityEngine;
using Tuhuse.Shared.Interfaces;
/// <summary>
/// ボスのインプットクラス主にプレイヤーとの距離を感知し、フラグを立てる
/// </summary>
public class BossAIInput : IInput
{
    private readonly Transform _player;
    private readonly Transform _self;

    public bool CandidateAttack { get; private set; }
    public bool CandidateSkill { get; private set; }
    public bool CandidateJump { get; private set; }

    // 常にプレイヤーを追う
    public bool IsForward { get; private set; } = true;

    // IInput の必須プロパティ（未使用だが実装は必要）
    public bool IsJump => false;
    public bool IsAttack => false;
    public bool IsSkill => false;
    public bool IsRightWalk => false;
    public bool IsBack => false;
    public bool IsLeftWalk => false;
    public bool IsLeftDiagonalWalk => false;
    public bool IsRightDiagonalWalk => false;

    public int ActiveSkillIndex => throw new System.NotImplementedException();

    public bool IsHit => throw new System.NotImplementedException();

    public BossAIInput(Transform player, Transform self)
    {
        _player = player;
        _self = self;
    }
    /// <summary>
    /// プレイヤーとの距離に応じてフラグを切り替えている
    /// </summary>
    public void InputUpdate()
    {
        float dist = Vector3.Distance(_self.position, _player.position);
        ResetFlags();

        // フラグで候補を出す（意思決定は Resolver にさせている）
        if (dist <= 3f)
        {
            CandidateAttack = true;
        }
        else if (dist <= 8f)
        {
            CandidateAttack = true;
            CandidateSkill = true;
        }
        else if (dist<=15f)
        {
            CandidateSkill = true;
            CandidateJump = true;
        }
        else
        {
            CandidateJump = true;
        }
    }
    /// <summary>
    /// フラグをリセットしている
    /// </summary>
    private void ResetFlags()
    {
        CandidateAttack = CandidateSkill = CandidateJump = false;
    }
}
