using System.Collections.Generic;
using Tuhuse.Shared.Interfaces;
/// <summary>
/// ���~�߃X�L��
/// </summary>
public class TimeStopSkill : ISkill
{
    private readonly List<ITimeAffectable> _targets;
    private readonly float _duration;
    private float _timer;

    private bool _isActive;
    private bool _isFinished=true;

    public bool IsFinished => _isFinished;

    public TimeStopSkill(List<ITimeAffectable> targets, float duration = 2f)
    {
        _targets = targets;
        _duration = duration;
    }
    /// <summary>
    /// ���~�ߎ��s
    /// </summary>
    public void Activate()
    {
        foreach (ITimeAffectable t in _targets)
        {
            t.OnTimeStop();
        }
        _isActive = true;
        _isFinished = false;
        _timer = 0f;
    }

    public void Update(float deltaTime)
    {
        if (!_isActive)
        {
            return;
        }
        _timer += deltaTime;
        if (_timer >= _duration)
        {
            Deactivate();
        }
    }
    /// <summary>
    /// ���ԍĊJ
    /// </summary>
    private void Deactivate()
    {
        foreach (var t in _targets)
        {
            t.OnTimeResume();
        }
        _isActive = false;
        _isFinished = true;
    }
}
