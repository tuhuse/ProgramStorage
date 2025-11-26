using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterData _characterData = default;
    [SerializeField] private CharacterGameData _gameData = default;
    [SerializeField] private ItemInventory _itemInventory = default;
    [SerializeField] private PlayerMove _playerMove = default;
    [SerializeField] private PlayerJump _playerJump = default;
    [SerializeField] private InputActionAsset _inputActionAsset = default;
    [SerializeField] private GameObject _tongue = default;
    private Player _player = default;
    private InputReceiver _inputReceiver = default;
    private CharacterStatus _status = new CharacterStatus();
    public ItemInventory ItemInventory => _itemInventory;
    public Player Player => _player;
    public CharacterData CharacterData => _characterData;
    public CharacterGameData CharacterGameData => _gameData;
    public CharacterStatus Status => _status;
    private void Awake()
    {
        _inputReceiver = new InputReceiver(_playerMove, _playerJump, _tongue.GetComponent<StickOutTongue>(), _inputActionAsset);
    }
    void Start()
    {
        _inputReceiver.InitInputAction();
        _player = new Player(_characterData, _gameData);
        _status.SetStatus(_characterData);
        _playerJump.SetJumpData(CharacterData.CharacterRayLength, CharacterData.CharacterJumpForce);
        _playerMove.SetMoveData(CharacterData.CharacterMoveSpeed);

    }
    private void Update()
    {
        if (_status.IsCharacterDown())
        {
            // ダウン中は操作禁止
            _inputReceiver.WalkInput = 0f;
            return;
        }

        _inputReceiver.InputUpdata();


        if (Input.GetKeyDown(KeyCode.F))
        {
            _status.TakeDamage();

            if (_status.IsCharacterDown())
            {
                Debug.Log("キャラがダウン中なので操作不可");
                DownPlayer();
            }
        }
    }

    public void DownPlayer()
    {
        StartCoroutine(_status.DownCharacterCoroutine());
    }
}
