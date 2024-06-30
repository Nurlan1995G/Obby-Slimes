public class PicassoFish : Fish
{
    private int _scoreLevel = 128;

    protected override int WriteScoreLevel() =>
        ScoreLevel = _scoreLevel;
}
