using System.Collections.Generic;

namespace GAlgorithm.GAlgorithm
{
    /// <summary>
    /// 板材信息
    /// </summary>
    public class BoardInfo
    {
        private float width;
        private float length;

        public float Width {
            get
            {
                return width;
            }
        }

        public void setWidth(float width) {
            this.width = width;
        }

        public float Length {
            get
            {
                return length;
            }
        }

        public void setLength(float length) {
            this.length = length;
        }

        private IList<Panel> panels;

        public void addPanel(Panel panel){
            if(this.panels==null){
                this.panels = new List<Panel>();
            }
            this.panels.Add(panel);
        }
        
        public BoardInfo(){}

        public BoardInfo(BoardInfo info)
        {
            this.width = info.width;
            this.length = info.length;
            
        }
    }
    
    
}