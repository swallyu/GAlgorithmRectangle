namespace GAlgorithm.GAlgorithm
{
    /// <summary>
    /// 轮廓线信息
    /// </summary>
    public class OutLine {

        private float startX;
        private float endX;
        private float y;

        public OutLine(float startX, float endX, float y) {
            this.startX = startX;
            this.endX = endX;
            this.y = y;
        }

        public float Length
        {
            get { return endX - startX; }
        }

        public float StartX {
            get
            {
                return startX;
            }
        }

        public float EndX {
            get
            {
                return endX;
            }
        }

        public float Y {
            get
            {
                return y;
            }
        }
    }

}