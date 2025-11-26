using System;

public class MoveCommand : ICommand
{
    private PlayerMove _playerMove;
    private Func<float> _getInput;
    private MoveStrategyChanger _changer;

    public MoveCommand(PlayerMove playerMove, Func<float> inputGetter, MoveStrategyChanger changer)
    {
        _playerMove = playerMove;
        _getInput = inputGetter;
        _changer = changer;
    }

    public void Execute()
    {
        //if (PlayerIsOnGround())
        //{
        //    _changer.SwitchToWalk();
        //}
        //else if (PlayerIsInWater())
        //{
        //    _changer.SwitchToSwim();
        //}
        //else
        //{
        //    _changer.SwitchToHover();
        //}

            _playerMove.OnMoveInput(_getInput.Invoke());
    }
}
