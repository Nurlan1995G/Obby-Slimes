public class ParrotFish : Fish
{
    private int _scoreLevel = 4;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
