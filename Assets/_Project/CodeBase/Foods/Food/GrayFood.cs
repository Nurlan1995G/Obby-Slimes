public class GrayFood : Food
{
    public override int WriteScoreLevel(int score) =>
        ScoreLevel = score;
}
