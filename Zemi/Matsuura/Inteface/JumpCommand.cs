using System;
using UnityEngine;

public class JumpCommand : ICommand
{
    private PlayerJump _playerJump=default;
    private Func<float> _getInput=default;
    public JumpCommand(PlayerJump playerJump, Func<float> inputGetter)
    {
        _playerJump = playerJump;
        _getInput = inputGetter;

    }

  
    public void Execute()
    {
        _playerJump.OnjumpInput(_getInput.Invoke());
    }
}
