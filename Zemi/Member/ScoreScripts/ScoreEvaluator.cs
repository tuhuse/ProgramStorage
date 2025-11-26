using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// 勝利条件などを加味して、実際にスコアを振り分けるクラス
/// </summary>
public class ScoreEvaluator
{
    private ScoreDataHandler _scoreDatabase;
    private ScoreRuleFactory _scoreRuleFactory;

    /// <summary>
    /// スコアに関するインスタンスを生成・取得
    /// </summary>
    public ScoreEvaluator()
    {
        _scoreDatabase = ScoreDataHandler.Instance;
        _scoreRuleFactory = new ScoreRuleFactory();
    }

    /// <summary>
    /// 勝利条件をもとに対応したクラスを生成し、データベースにスコアを加算する命令を出す
    /// </summary>
    /// <param name="victoryCriteria">勝利条件</param>
    /// <param name="characters">全プレイヤー</param>
    public void AddScore(StageFlowController.StageVictoryCriteria victoryCriteria, List<ICharacter> characters)
    {
        IRankingRule rule = _scoreRuleFactory.Create(victoryCriteria);
        int[] scores = rule.MakeRanking(characters);
        for(int i = 0; i < scores.Length; i++)
        {
            _scoreDatabase.AddScore(characters[i], scores[i]);
        }
    }
}