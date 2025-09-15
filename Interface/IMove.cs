namespace Tuhuse.Shared.Interfaces
{
    using UnityEngine;
    /// <summary>
    /// �ړ��C���^�[�t�F�[�X
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// �ʒu��Ԃ�
        /// </summary>
        Vector3 Position { get; } 
        /// <summary>
        /// �ړ�����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        void Move(float x, float z);
    }
}