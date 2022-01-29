using UnityEngine;

namespace EndlessRunner.Utils
{
    public sealed class LineMovement
    {
        private int indexLineCurrent;
        private int lineTotal;
        private readonly int[] linesPosition = new int[3] {-4, 0, 4};
        public float linePositionCurrent = 0;

        public LineMovement(int indexLine)
        {
            lineTotal = linesPosition.Length;
            SetIndexLine(indexLine);
        }

        public LineMovement()
        {
            lineTotal = linesPosition.Length;
            RandomLinePosition();
        }

        public void MoveLeft()
        {
            SetIndexLine(indexLineCurrent - 1);
        }

        public void MoveRight()
        {
            SetIndexLine(indexLineCurrent + 1);
        }

        public void RandomLinePosition()
        {
            int randomLine = Random.Range(0, lineTotal);
            SetIndexLine(randomLine);
        }

        private void SetIndexLine(int index)
        {
            indexLineCurrent = index;
            CheckLineLimit();
            SetLinePosition();
        }

        private void CheckLineLimit()
        {
            if(indexLineCurrent < 0)
            {
                indexLineCurrent = 0;
            }
            else if(indexLineCurrent >= lineTotal)
            {
                indexLineCurrent = lineTotal - 1;
            }
        }

        private void SetLinePosition()
        {
            linePositionCurrent = linesPosition[indexLineCurrent];
        }
    }
}
