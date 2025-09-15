/// <summary>
/// 巻き戻しスキルクラス
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
    /// 巻き戻し実行
    /// </summary>
    public void Activate()
    {
        _rewind.StartRewind();
        _isFinished = false;
    }

    public void Update(float deltaTime)
    {
        // PlayerRewind が終わったら終了扱い
        if (!_rewind.IsRewinding)
        {
            _isFinished = true;
        }
    }
}
