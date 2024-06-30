public class BlueSergeonFish : Fish
{
    private int _scoreLevel = 1;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
