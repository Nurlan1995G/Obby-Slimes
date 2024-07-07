public class BlueFood : Food
{
    private int _scoreLevel = 2;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
