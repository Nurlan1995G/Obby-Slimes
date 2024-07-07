public class OrangeFood : Food
{
    private int _scoreLevel = 64;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
