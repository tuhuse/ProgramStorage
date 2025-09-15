using UnityEngine;
using Tuhuse.Shared.Interfaces;
/// <summary>
/// �{�X�̃C���v�b�g�N���X��Ƀv���C���[�Ƃ̋��������m���A�t���O�𗧂Ă�
/// </summary>
public class BossAIInput : IInput
{
    private readonly Transform _player;
    private readonly Transform _self;

    public bool CandidateAttack { get; private set; }
    public bool CandidateSkill { get; private set; }
    public bool CandidateJump { get; private set; }

    // ��Ƀv���C���[��ǂ�
    public bool IsForward { get; private set; } = true;

    // IInput �̕K�{�v���p�e�B�i���g�p���������͕K�v�j
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
    /// �v���C���[�Ƃ̋����ɉ����ăt���O��؂�ւ��Ă���
    /// </summary>
    public void InputUpdate()
    {
        float dist = Vector3.Distance(_self.position, _player.position);
        ResetFlags();

        // �t���O�Ō����o���i�ӎv����� Resolver �ɂ����Ă���j
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
    /// �t���O�����Z�b�g���Ă���
    /// </summary>
    private void ResetFlags()
    {
        CandidateAttack = CandidateSkill = CandidateJump = false;
    }
}
