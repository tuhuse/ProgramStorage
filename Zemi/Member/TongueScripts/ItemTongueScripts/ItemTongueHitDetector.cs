using UnityEngine;
using static StageFlowController;

public class ItemTongueHitDetector
{
    private int _hitObjectLayer = 0;
    private int _hitLayerNum = 1;

    private Layers _layer = default;

    ItemInventory _itemInventory = default;

    private enum Layers
    {
        Ground = 64,
        Player = 128,
        Tongue = 512,
    }

    public ItemTongueHitDetector(Transform tongueTransform)
    {
        if (!tongueTransform.parent.TryGetComponent<ItemInventory>(out _itemInventory))
        {
            Debug.LogError("ベロの親オブジェクトにItemInventoryがありません");
            return;
        }
    }

    public void HitDetector(RaycastHit2D hit)
    {

        //レイヤーの番号
        _hitObjectLayer = hit.collider.gameObject.layer;

        //レイヤーの番号をビット変換する
        while (_hitObjectLayer > 0)
        {
            _hitObjectLayer--;
            _hitLayerNum *= 2;
        }
        //ビット変換した数をenumに合わせる
        _layer = (Layers)_hitLayerNum;

        switch (_layer)
        {
            case Layers.Ground:

                Debug.Log("地面に衝突");
                break;

            case Layers.Player:

                PlayerController playerController = hit.collider.gameObject.GetComponent<PlayerController>();

                if (StageFlowController.Instance.NowVictoryCriteria == StageVictoryCriteria.MAX_TAKE_DOWN_TIMES)
                {
                    _itemInventory.ActivationItem(hit.collider.gameObject);

                    //敵がダウン中だったら
                    if (playerController.Status.IsCharacterDown())
                    {
                        playerController.DownPlayer();

                        //ダウンさせた回数を増やす
                        playerController.CharacterGameData.TakeDownAddScore();
                    }
                }
                Debug.Log("プレイヤーに衝突");
                break;

            case Layers.Tongue:

                Debug.Log("ベロに衝突");
                break;

            default:

                Debug.Log("それ以外");
                break;
        }

        //レイヤーの番号を初期化
        _hitLayerNum = 1;
    }
}
