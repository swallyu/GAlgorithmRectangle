using System.Collections.Generic;
using System.Linq;

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

            IList<BoardInfo> usedBoardList = new List<BoardInfo>();
            BoardInfo currentBoardInfo = null;
            for(int i=0;i<this.panels.Count;i++){
                if(outLineInfo==null){
                    outLineInfo = new OutLineInfo();
                }
                if(i==0){
                    currentBoardInfo = new BoardInfo(this.boardInfo);
                    usedBoardList.Add(currentBoardInfo);
                    
                    Panel panel = Panel.copy(this.panels[i]);

                    panel.setLeftBottomPoint(new Point(0,0));
                    currentBoardInfo.addPanel(panel);

                    OutLine outLine = new OutLine(0,panel.Length,panel.Width);
                    OutLine outLine2 = new OutLine(panel.Length,boardInfo.Length,0);

                    outLineInfo.update(outLine);
                    outLineInfo.update(outLine2);

                    continue;
                }

                IList<OutLine> lowestLines = outLineInfo.getLowestOutline();
                
                //只有一条最低水平轮廓线
                if(lowestLines.Count==1)
                {
                    float lineY = lowestLines[0].Y;
                    float lineLen = lowestLines[0].Length;

                    int matchIndex = -1;
                    searchMatchPanel(ref matchIndex, lineY, lineLen,panels,i);

                    if (matchIndex == -1) //不存在找到合适的零件在当前板材上排放，即需要换新板
                    {
                        currentBoardInfo = new BoardInfo(this.boardInfo);
                        usedBoardList.Add(currentBoardInfo);
                    }
                    else
                    {
                        SwapPanel(i, matchIndex,panels);
                        
                        Panel panel = Panel.copy(this.panels[i]);
                        addPanelAndUpdateOutLine(currentBoardInfo, panel, lowestLines[0]);
                        
                    }

                }else
                {
                    OutLine line = null;
                    SearchGoodLine(lowestLines, panels[i].Length, panels[i].Width, out line);

                    //长度能放下
                    if (line != null)
                    {
                        //最低水平线+当前零件高度没有超出边界
                        if ((lowestLines[0].Y + panels[i].Width) <= boardInfo.Width)
                        {
                            addPanelAndUpdateOutLine(currentBoardInfo, Panel.copy(this.panels[i]), line);
                        }
                        else //搜索当前零件后的零件，看高度是否合适
                        {
                            float lineY = line.Y;
                            float lineLen = line.Length;
                            
                            int matchIndex = -1;
                            searchMatchPanel(ref matchIndex, lineY, lineLen,panels,i);

                            if (matchIndex == -1) //不存在找到合适的零件的高度在当前板材上排放，即需要换新板
                            {
                                currentBoardInfo = new BoardInfo(this.boardInfo);
                                usedBoardList.Add(currentBoardInfo);
                            }
                            else
                            {
                                SwapPanel(i, matchIndex,panels);
                        
                                Panel panel = Panel.copy(this.panels[i]);
                                addPanelAndUpdateOutLine(currentBoardInfo, panel, line);
                            }
                        }
                    }
                    else //长度不合适，查找后面的零件
                    {
                        float minLengh = this.panels.Skip(i + 1).Min(m => m.Length);
                        
                    }
                }
            }

        }

        /// <summary>
        /// 增加零件且更新轮廓线
        /// </summary>
        /// <param name="currentBoardInfo"></param>
        /// <param name="panel"></param>
        /// <param name="outLine"></param>
        private void addPanelAndUpdateOutLine(BoardInfo currentBoardInfo,Panel panel,OutLine outLine)
        {
            panel.setLeftBottomPoint(new Point(outLine.StartX,outLine.Y));
            currentBoardInfo.addPanel(panel);

            outLineInfo.update(outLine,panel.Length,panel.Width);
        }

        /// <summary>
        /// 交换位置
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="matchIndex"></param>
        /// <param name="panels"></param>
        private void SwapPanel(int currentIndex, int matchIndex,IList<Panel> panels)
        {
            if (currentIndex == matchIndex) return;
            var panel = panels[currentIndex];
            panels[currentIndex] = panels[matchIndex];
            panels[matchIndex] = panel;
        }

        /// <summary>
        /// 查找最适合长度的panel
        /// </summary>
        /// <param name="matchIndex"></param>
        /// <param name="lineY"></param>
        /// <param name="lineLen"></param>
        private void searchMatchPanel(ref int matchIndex, float lineY, float lineLen,
            IList<Panel> panels,int currentIndex)
        {
            float matchRate = 0;
            for (var i = currentIndex; i < panels.Count; i++)
            {
                Panel panel = panels[i];
                //待排零件长度小于最低水平轮廓线，且长度和最低水平轮廓线的比例最大，且排样后高度不超出板材，
                if (panel.Length < lineLen &&
                    panel.Length / lineLen > matchRate
                    && (panel.Width + lineY) < boardInfo.Width)
                {
                    matchRate = panel.Length / lineLen;
                    matchIndex = i;
                }
            }
        }
         
        public void SearchGoodLine(IList<OutLine> outLineList, float length,float width, out OutLine line)
        {
            line = null;
            float matchRate = 0;
            foreach (var outLine in outLineList)
            {
                if (length <= outLine.Length && length / outLine.Length > matchRate)
                {
                    matchRate = length / outLine.Length;
                    line = outLine;
                }
            }
        }
        
    }
}