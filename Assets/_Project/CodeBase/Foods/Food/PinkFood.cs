public class PinkFood : Food
{
    private int _scoreLevel = 256;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
