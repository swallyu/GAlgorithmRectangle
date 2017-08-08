namespace GAlgorithm.GAlgorithm
{
    /// <summary>
    /// 板件信息
    /// </summary>
    public class Panel {

        private int panelId;
        private float width;
        private float length;

        private int rotateAngle = 0;

        public float getWidth() {
            return width;
        }

        public float getLength() {
            return length;
        }

        public int getPanelId() {
            return panelId;
        }

        public void setPanelId(int panelId) {
            this.panelId = panelId;
        }

        private LineInfo[] lineInfos;

        public static Panel copy(Panel panel){
            Panel p=new Panel(panel.length,panel.width);
            p.panelId = panel.panelId;
            return p;
        }

        /**
         * 默认以左下为原点，生成四边信息。
         * @param length
         * @param width
         */
        public Panel(float length, float width) {
            if(length<width){
                this.width = length;
                this.length = width;
            }else {
                //较长的边作为长，
                this.width = width;
                this.length = length;
                rotateAngle = 90;
            }


            setLineInfos();
        }

        /**
         * 根据长宽，设置四边信息
         * 用左下作为原点起点，逆时针生成各线段
         */
        private void setLineInfos() {
            this.lineInfos = new LineInfo[4];

            lineInfos[0] = new LineInfo(new Point(0,0),new Point(length,0));
            lineInfos[1] = new LineInfo(new Point(length,0),new Point(length, width));
            lineInfos[2] = new LineInfo(new Point(length, width),new Point(0, width));
            lineInfos[3] = new LineInfo(new Point(0, width),new Point(0,0));
        }

        /**
         * 旋转90度，矩形交换长宽
         */
        public void rotate90(){
            float tmp = this.length;
            this.length = this.width;
            this.width = tmp;

            setLineInfos();
        }

        private Point leftBottomPoint;

        public void setLeftBottomPoint(Point point){
            this.leftBottomPoint = point;

            float offsetX = point.getX();
            float offsetY = point.getY();

            foreach (LineInfo lineInfo in lineInfos) {
                lineInfo.move(offsetX,offsetY);
            }
        }
    }
}