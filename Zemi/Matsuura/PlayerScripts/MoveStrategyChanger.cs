public class MoveStrategyChanger
{
    private PlayerMove _playerMove=default;

    public MoveStrategyChanger(PlayerMove playerMove)
    {
        _playerMove = playerMove;
    }

    public void SwitchToHover() => _playerMove.SetStrategy(new HoverMove());
    public void SwitchToWalk() => _playerMove.SetStrategy(new WalkMove());
    public void SwitchToSwim() => _playerMove.SetStrategy(new SwimmerMove());
}
