public class RedFood : Food
{
    private int _scoreLevel = 8;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
