namespace Command_Pattern
{
    public class CommandData
    {
        public float XMoveDir { get; }
        public float YMoveDir { get; }
        public CommandData(float x, float y)
        {
            XMoveDir = x;
            YMoveDir = y;
        }
    }
}
