using System.Collections.Generic;

namespace GAlgorithm.GAlgorithm
{
    /// <summary>
    /// 二维装箱算法
    /// </summary>
    public class Box2dAlgorithm
    {
        
        private BoardInfo boardInfo;
        private IList<Panel> panels;

        private OutLineInfo outLineInfo;

        /// <summary>
        /// 剩余待排零件长度最小值
        /// </summary>
        private float lmin = 0;
        
        /// <summary>
        /// 当前矩形排放后顶端高度值
        /// </summary>
        private float hnew = 0;

        public Box2dAlgorithm(BoardInfo boardInfo, IList<Panel> panels) {
            this.boardInfo = boardInfo;
            this.panels = panels;
        }

        public void process() {

            IList<BoardInfo> usedBoard = new List<BoardInfo>();

            for(int i=0;i<this.panels.Count;i++){
                if(outLineInfo==null){
                    outLineInfo = new OutLineInfo();
                }
                if(i==0){
                    Panel panel = Panel.copy(this.panels[i]);

                    panel.setLeftBottomPoint(new Point(0,0));
                    this.boardInfo.addPanel(panel);

                    OutLine outLine = new OutLine(0,panel.getLength(),panel.getWidth());
                    OutLine outLine2 = new OutLine(panel.getLength(),boardInfo.getLength(),0);

                    outLineInfo.update(outLine);
                    outLineInfo.update(outLine2);

                    continue;
                }

                IList<OutLine> lowestLines = outLineInfo.getLowestOutline();
                
                if(lowestLines.size()==1){

                }else
                {
                    OutLine line = null;
                    outLineInfo.SearchGoodLine(panels[i], out line);
                }
            }

        }
    }
}