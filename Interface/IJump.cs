namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// �W�����v�C���^�[�t�F�[�X
    /// </summary>
    public interface IJump
    {
        /// <summary>
        /// �W�����v����
        /// </summary>
        /// <param name="force">��ԗ�</param>
        void Jump(float force);
        /// <summary>
        /// �n�ʂɂ��Ă��邩
        /// </summary>
        bool IsGrounded { get; }
    }
}
