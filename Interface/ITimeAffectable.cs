namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// �����~�߂�Ώۂɂ���C���^�[�t�F�[�X
    /// </summary>
    public interface ITimeAffectable
    {
        /// <summary>
        /// ���Ԃ��~�߂�
        /// </summary>
        void OnTimeStop();
        /// <summary>
        /// ���Ԃ��ĊJ������
        /// </summary>
        void OnTimeResume();
    }
}