/// <summary>
/// �X�L���C���^�[�t�F�[�X
/// </summary>
public interface ISkill
{
    /// <summary>
    /// ���s����
    /// </summary>
    void Activate();
    /// <summary>
    /// �������̍X�V����
    /// </summary>
    /// <param name="deltaTime">deltaTime</param>
    void Update(float deltaTime);
    /// <summary>
    /// �X�L�����I��������
    /// </summary>
    bool IsFinished { get; }  
}
