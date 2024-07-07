public class GreenFood : Food
{
    private int _scoreLevel = 1;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
