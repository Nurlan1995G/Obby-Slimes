public class BelugaFish : Fish
{
    private int _scoreLevel = 8;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
