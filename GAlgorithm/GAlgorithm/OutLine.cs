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

        public float getStartX() {
            return startX;
        }

        public float getEndX() {
            return endX;
        }

        public float getY() {
            return y;
        }
    }

}