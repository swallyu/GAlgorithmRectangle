namespace GAlgorithm.GAlgorithm
{
/**
 * Created by changhu on 2017/8/8.
 */
    public class Point {

        private float x;
        private float y;

        public Point() {
        }

        public Point(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public float getX() {
            return x;
        }

        public void setX(float x) {
            this.x = x;
        }

        public float getY() {
            return y;
        }

        public void setY(float y) {
            this.y = y;
        }

        /**
         * 点平移
         * @param offsetX
         * @param offsetY
         */
        public void move(float offsetX, float offsetY) {
            this.x+=offsetX;
            this.y+=offsetY;
        }
    }
}