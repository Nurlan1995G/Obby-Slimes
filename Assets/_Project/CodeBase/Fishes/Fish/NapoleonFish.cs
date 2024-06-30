public class NapoleonFish : Fish
{
    private int _scoreLevel = 64;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
