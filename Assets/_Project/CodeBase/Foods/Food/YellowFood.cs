public class YellowFood : Food
{
    private int _scoreLevel = 32;

    protected override int WriteScoreLevel() => 
        ScoreLevel = _scoreLevel;
}
