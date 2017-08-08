namespace GAlgorithm.GAlgorithm
{
    /// <summary>
    /// 线段信息
    /// </summary>
    public class LineInfo {

        private Point start;
        private Point end;

        public Point getStart() {
            return start;
        }

        public void setStart(Point start) {
            this.start = start;
        }

        public Point getEnd() {
            return end;
        }

        public void setEnd(Point end) {
            this.end = end;
        }

        public LineInfo() {
        }

        public LineInfo(Point start, Point end) {
            this.start = start;
            this.end = end;
        }

        /**
         * 线段平移
         * @param offsetX
         * @param offsetY
         */
        public void move(float offsetX, float offsetY) {

            start.move(offsetX,offsetY);
            end.move(offsetX,offsetY);
        }
    }

}