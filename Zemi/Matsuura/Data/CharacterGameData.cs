using UnityEngine;

public class CharacterGameData : MonoBehaviour
{

    private Transform _characterTransform = default;
    private bool _hasCrown = false;
    private int _takeDown = 0;
    private int _flyEatNumber = 0;
    private float _moveDistance = 0;
    public Transform CharacterTransform => _characterTransform;
    public bool HasCrown => _hasCrown;
    public int TakeDown => _takeDown;
    public int FlyEatNumber => _flyEatNumber;
    public float MoveDistance => _moveDistance;

    public void TakeDownAddScore()
    {
        _takeDown++;
    }
    public void FlyEatAddScore()
    {
        _flyEatNumber++;
    }
   
}
