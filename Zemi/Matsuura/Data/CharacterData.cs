using UnityEngine;
using UnityEngine.TextCore.Text;
/// <summary>
/// キャラクターデータ
/// </summary>
[CreateAssetMenu(fileName = "CharacterName", menuName = "ScriptableObject/CharacterData")]
public class CharacterData : ScriptableObject
{ 
    [SerializeField] private int _characterNumber = default;
    [SerializeField] private int _characterHealth = default;
    [SerializeField] private float _characterDownTime = default;
    [SerializeField] private float _characterRayLength = default;
    [SerializeField] private float _characterMoveSpeed = default;
    [SerializeField] private float _characterJumpForce = default;
    [SerializeField] private string _characterName = default;
    [SerializeField] private Sprite _characterSprite = default;
    [SerializeField] private Animator _animator = default;

    public int CharacterNumber => _characterNumber;
    public int CharacterHealth => _characterHealth;
    public float CharacterDownTime => _characterDownTime;
    public float CharacterRayLength => _characterRayLength;
    public float CharacterMoveSpeed => _characterMoveSpeed;
    public float CharacterJumpForce => _characterJumpForce;
    public string CharacterName => _characterName;
    public Sprite CharacterSprite => _characterSprite;
    public Animator CharacterAnimator => _animator;

}
