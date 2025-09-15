namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// インプットインターフェース
    /// </summary>
    public interface IInput
    {
        bool IsJump { get; }
        bool IsAttack { get; }
        bool IsRightWalk { get; }
        bool IsForward { get; }
        bool IsBack { get; }
        bool IsLeftWalk { get; }
        bool IsLeftDiagonalWalk { get; }
        bool IsRightDiagonalWalk { get; }
        bool IsSkill { get; }
        public bool IsHit { get; }
        public int ActiveSkillIndex { get; }
        void InputUpdate();
    }
}