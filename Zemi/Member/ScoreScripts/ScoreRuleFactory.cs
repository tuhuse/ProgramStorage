/// <summary>
/// ルールの一覧enumから、勝利条件ごとのスコア計算クラスを返す
/// </summary>
public class ScoreRuleFactory
{
    public IRankingRule Create(StageFlowController.StageVictoryCriteria victoryCriteria)
    {
        return victoryCriteria switch
        {
            StageFlowController.StageVictoryCriteria.HAS_CROWN => new HasCrownScoreRule(),
            StageFlowController.StageVictoryCriteria.ON_THE_LEFT => new OnTheLeftScoreRule(),
            StageFlowController.StageVictoryCriteria.ON_THE_RIGHT => new OnTheRightScoreRule(),
            StageFlowController.StageVictoryCriteria.ON_THE_TOP => new OnTheTopScoreRule(),
            StageFlowController.StageVictoryCriteria.ON_THE_BOTTOM => new OnTheBottomScoreRule(),
            StageFlowController.StageVictoryCriteria.MAX_TAKE_DOWN_TIMES => new TakeDownTimesScoreRule(),
            StageFlowController.StageVictoryCriteria.MAX_ATE_FLY_NUMBER => new AteFlyNumberScoreRule(),
            StageFlowController.StageVictoryCriteria.MAX_MOVING_DISTANCE => new MovingDistanceScoreRule(),
            _ => throw new System.ArgumentOutOfRangeException(nameof(victoryCriteria))
        };
    }

}
