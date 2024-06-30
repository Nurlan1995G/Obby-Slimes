public class AngelFish : Fish
{
    private int _scoreLevel = 32;

    protected override int WriteScoreLevel() => 
        ScoreLevel = _scoreLevel;
}
