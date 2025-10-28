using UnityEngine;
[CreateAssetMenu(fileName = "RocketTongueEffect", menuName = "ScriptableObject/RocketTongueEffect")]
/// <summary>
/// ロケットを打つスキルの実装
/// </summary>
public class RocketTongue : ItemEffectBase
{
    [SerializeField]
    private GameObject _rocketPrefab = default;

    private GameObject _instantiateRocket = default;

    /// <summary>
    /// ロケットがすでにインスタンス化されていた場合はそれを有効化、
    /// されていない場合はインスタンス化する
    /// </summary>
    /// <param name="target">攻撃相手</param>
    public override void ApplyEffect(GameObject target,GameObject mySelf)
    {
        if(_instantiateRocket == null)
        {
            _instantiateRocket = Instantiate(_rocketPrefab);
        }
        else
        {
            _instantiateRocket.SetActive(true);
        }
    }
}
