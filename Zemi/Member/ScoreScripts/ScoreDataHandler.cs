using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアの加算・保存を行う
/// シングルトン
/// </summary>
public class ScoreDataHandler : MonoBehaviour
{
    // 参加人数は4人で固定
    private const int CHARACTER_NUM = 4;
    private const string CHARACTER_TAG = "Character";

    private int[] _scores;
    private List<ICharacter> _characters = new List<ICharacter>(CHARACTER_NUM);

    public static ScoreDataHandler Instance
    {
        get; private set;
    }

    /// <summary>
    /// シングルトン化　プレイヤーの人数を取得し、スコア配列を準備する
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void InitializeCharacters()
    {
        GameObject[] characterObj = GameObject.FindGameObjectsWithTag(CHARACTER_TAG);

        for (int i = 0; i < characterObj.Length; i++)
        {
            PlayerController playerController;

            if (characterObj[i].TryGetComponent<PlayerController>(out playerController))
            {
                _characters.Add(playerController.Player);
            }
            else
            {
                // エネミー
            }
        }

        // 人数分のスコアを準備する
        _scores = new int[CHARACTER_NUM];
    }

    public int[] GetScore()
    {
        if (_scores.Length == 0)
        {
            InitializeCharacters();
        }
        return _scores;
    }

    public List<ICharacter> Characters()
    {
        if (_characters.Count == 0)
        {
            InitializeCharacters();
        }
        return _characters;
    }

    /// <summary>
    /// 指定プレイヤーのスコアに値をプラスする
    /// </summary>
    /// <param name="scoreAdditionTarget">指定キャラクター</param>
    /// <param name="addValue">加える値</param>
    public void AddScore(ICharacter scoreAdditionTarget, int addValue)
    {
        if (_scores.Length == 0)
        {
            InitializeCharacters();
        }

        for (int i = 0; i < CHARACTER_NUM; i++)
        {
            if (_characters[i].Character.CharacterNumber == scoreAdditionTarget.Character.CharacterNumber)
            {
                _scores[i] += addValue;
                return;
            }
        }

        Debug.Log("該当するCharacterが見つかりませんでした。");
    }

    /// <summary>
    /// 全員のスコアを０にする
    /// </summary>
    public void ResetScore()
    {
        if (_scores.Length == 0)
        {
            InitializeCharacters();
        }

        for (int i = 0; i < CHARACTER_NUM; i++)
        {
            _scores[i] = 0;

        }
    }
}
