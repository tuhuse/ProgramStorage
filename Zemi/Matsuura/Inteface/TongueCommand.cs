using System;

public class TongueCommand : ICommand
{
    private StickOutTongue _stickOutTongue;

    public TongueCommand(StickOutTongue stickOutTongue)
    {
        _stickOutTongue = stickOutTongue;
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
        if (_stickOutTongue.TongueState.NowTongueState == TongueStateController.TongueState.Idle)
        {
           _stickOutTongue.ReceiveInputToTongue();
        }
       
    }
}
