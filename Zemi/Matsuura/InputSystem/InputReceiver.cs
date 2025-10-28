using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class InputReceiver
{
    private PlayerMove _playerMove = default;
    private PlayerJump _playerJump = default;
    private StickOutTongue _stickOutTongue = default;
    private InputActionAsset _inputActionAsset = default;
    private InputAction _rightMoveInput = default;
    private InputAction _leftMoveInput = default;
    private InputAction _jumpInput = default;
    private InputAction _tongueInput = default;
    public InputReceiver(PlayerMove playerMove,PlayerJump playerJump,StickOutTongue stickOutTongue,InputActionAsset inputActionData)
    {
        _playerMove = playerMove;
        _playerJump = playerJump;
        _stickOutTongue = stickOutTongue;
        _inputActionAsset = inputActionData;
    }
   
    public InputAction RightMoveInput => _rightMoveInput;
    public InputAction LeftMoveInput => _leftMoveInput;
    public InputAction JumpMoveInput => _jumpInput;
    public InputAction TongueInput => _tongueInput;
    public float WalkInput { get; set; } = default;
    public float JumpInput { get; set; } = default;
    public float TonguePressInput { get; set; } = default;
    public float MoveSpeed => _playerMove.MoveSpeed;
    public float JumpForce => _playerJump.JumpForce;
    private ICommand _moveCommand;
    private ICommand _jumpCommand;
    private ICommand _tongueCommand;
    private readonly List<ICommand> _commandQueue = new();
    public void InitInputAction()
    {
        _moveCommand = new MoveCommand(_playerMove, () => WalkInput, _playerMove.MoveStrategyChanger);
        _jumpCommand = new JumpCommand(_playerJump, () => JumpInput);
        _tongueCommand = new TongueCommand(_stickOutTongue);
        _rightMoveInput = _inputActionAsset.FindAction("MoveRight");
        _leftMoveInput = _inputActionAsset.FindAction("MoveLeft");
        _jumpInput = _inputActionAsset.FindAction("Jump");
        _tongueInput = _inputActionAsset.FindAction("Tongue");
        _rightMoveInput.Enable();
        _leftMoveInput.Enable();
        _jumpInput.Enable();
        _tongueInput.Enable();
    }
    public void InputUpdata()
    {
        WalkInput = 0f;
        JumpInput = 0f;
        TonguePressInput = 0f;
        if (RightMoveInput.IsPressed())
        {
            WalkInput = MoveSpeed;

        }
        if (LeftMoveInput.IsPressed())
        {
            WalkInput = -MoveSpeed;
        }
        ////ジャンプの入力判定
        if (JumpMoveInput.IsPressed())
        {
            //ジャンプ処理を呼び出す
            JumpInput=JumpForce;
        }
        if (TongueInput.IsPressed())
        {
            TonguePressInput = 1f;
        }
        InputCommandQueue();
    }
    private void InputCommandQueue()
    {
        // 入力があれば移動コマンドをキューに追加
        if (Mathf.Abs(WalkInput) > 0.001f)
        {
            _commandQueue.Add(_moveCommand);
        }
        // キャンセル
        else
        {
            _commandQueue.Add(_moveCommand);
        }
        if (Mathf.Abs(JumpInput) > 0.001f)
        {
            _commandQueue.Add(_jumpCommand);
        }
        if (Mathf.Abs(TonguePressInput) > 0.001f)
        {
            _commandQueue.Add(_tongueCommand);
        }
        // キューの実行
        foreach (ICommand cmd in _commandQueue)
        {
            cmd.Execute();
        }
        _commandQueue.Clear();
    }
}
