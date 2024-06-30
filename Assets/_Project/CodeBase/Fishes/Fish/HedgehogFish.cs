public class HedgehogFish : Fish
{
    private int _scoreLevel = 16;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
