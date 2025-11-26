using UnityEngine;

public class ItemTongueHitJudger
{
    //舌のワールドの大きさ
    private Vector2 _tongueWorldSize;

    //ベロの見た目
    private Sprite _tongueSprite;

    //ベロのトランスフォーム情報
    private Transform _tongueTransform;

    //ベロから出るレイの長さ
    private float _rayLength = 0f;

    //舌があたるオブジェクトのレイヤー（レイヤーの番号はビット変換）
    private LayerMask LAYER_MASK = 64 | 128 | 256 | 512 | 1024;

    //ハエのレイヤー（レイヤー番号そのまま）
    private const int _fryLayer = 10;

    //舌の状態を管理するクラス
    private TongueStateController _tongueStateController = default;

    //舌がオブジェクトにあたった後、何に当たったかを仕分けるクラス
    private ItemTongueHitDetector _hitDetector;

    private GameObject _parentObject = default;

    /// <summary>
    /// ベロの初期位置、最大の長さを取得する
    /// </summary>
    /// <param name="tongueTransform">ベロの初期位置（ベロのトランスフォーム情報）</param>
    /// <param name="max_length">ベロの最大の長さ</param>
    public ItemTongueHitJudger(Transform tongueTransform, Sprite tongueSprite, TongueStateController tongueStaetController)
    {
        _hitDetector = new ItemTongueHitDetector(tongueTransform);
        _tongueTransform = tongueTransform;
        _tongueSprite = tongueSprite;
        _tongueStateController = tongueStaetController;

        //ベロの画像のサイズを読み取る
        _tongueWorldSize = _tongueSprite.rect.size / _tongueSprite.pixelsPerUnit;

        _parentObject = tongueTransform.parent.gameObject;
    }

    /// <summary>
    /// ベロの当たり判定を例でとる処理
    /// </summary>
    public void hitJudge()
    {
        //当たり判定をレイで飛ばす
        RaycastHit2D[] hitObjects = Physics2D.RaycastAll(_tongueTransform.transform.position, Vector2.right, _rayLength, LAYER_MASK);

        if (hitObjects.Length == 0)
        {
            return;
        }

        foreach (RaycastHit2D hitGameObject in hitObjects)
        {
            //あたったのが自分自身だったら
            if (hitGameObject.collider.gameObject == _parentObject)
            {
                continue;
            }

            //自分以外の何かに当たった場合
            if (!_tongueStateController.IsTouch)
            {
                //ハエに当たった時だけ舌のスケールダウンをしない
                if (hitGameObject.collider.gameObject.layer == _fryLayer)
                {
                    //当たったオブジェクトの仕分け
                    _hitDetector.HitDetector(hitGameObject);
                    Debug.Log("ハエに衝突");

                    return;
                }

                //当たったオブジェクトの仕分け
                _hitDetector.HitDetector(hitGameObject);
                //舌のスケールダウンを開始する
                _tongueStateController.ChangeTongueState(TongueStateController.TongueState.ScaleDown);
                _tongueStateController.IsTouch = true;

            }
        }

    }

    public void ChangeCollisionSize()
    {
        _rayLength = _tongueWorldSize.x * _tongueTransform.lossyScale.x;
    }
}
