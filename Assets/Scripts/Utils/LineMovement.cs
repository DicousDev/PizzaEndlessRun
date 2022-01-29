namespace EndlessRunner.Utils
{
    public sealed class LineMovement
    {
        private int lineCurrent;
        private const int lineTotal = 3;
        private const int lineMinimun = 1;
        private const float distanceBetweenLines = 4;
        public float linePosition = 0;

        public LineMovement(int lineCurrent)
        {
            SetLineCurrent(lineCurrent);
        }

        public void MoveLeft()
        {
            SetLineCurrent(lineCurrent - 1);
        }

        public void MoveRight()
        {
            SetLineCurrent(lineCurrent + 1);
        }

        private void SetLineCurrent(int line)
        {
            lineCurrent = line;
            CheckLineLimit();
            SetLinePosition();
        }

        private void CheckLineLimit()
        {
            if(lineCurrent <= lineMinimun)
            {
                lineCurrent = lineMinimun;
            }
            else if(lineCurrent > lineTotal)
            {
                lineCurrent = lineTotal;
            }
        }

        private void SetLinePosition()
        {
            if(lineCurrent == 1)
            {
                linePosition = -distanceBetweenLines;
            }
            else if(lineCurrent == 2)
            {
                linePosition = 0;
            }
            else if(lineCurrent == 3)
            {
                linePosition = distanceBetweenLines;
            }
        }
    }
}
