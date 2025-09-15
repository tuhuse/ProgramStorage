/// <summary>
/// �����߂��X�L���N���X
/// </summary>
public class RewindSkill : ISkill
{
    private readonly PlayerRewind _rewind;
    private bool _isFinished=true;

    public bool IsFinished => _isFinished;

    public RewindSkill(PlayerRewind rewind)
    {
        _rewind = rewind;
    }
    /// <summary>
    /// �����߂����s
    /// </summary>
    public void Activate()
    {
        _rewind.StartRewind();
        _isFinished = false;
    }

    public void Update(float deltaTime)
    {
        // PlayerRewind ���I�������I������
        if (!_rewind.IsRewinding)
        {
            _isFinished = true;
        }
    }
}
