using System.Collections.Generic;
using System.Linq;

namespace GAlgorithm.GAlgorithm
{
    /// <summary>
    /// 排样轮廓信息
    /// </summary>
    public class OutLineInfo {


        private IList<OutLine> outLineList;


        /**
         * 更新轮廓信息
         * @param outLine
         */
        public void update(OutLine outLine){
            this.outLineList.Add(outLine);
        }

        public int size() {
            return outLineList==null?0: outLineList.Count;
        }

        /// <summary>
        /// 获取最低水平线
        /// </summary>
        /// <returns></returns>
        public IList<OutLine> getLowestOutline()
        {
            //最低水平线
            float minY = outLineList.Min(m => m.getY());

            return new List<OutLine>(outLineList.Where(m => m.getY() == minY));
        }


        public void SearchGoodLine(Panel panel, out OutLine line)
        {
            //throw new System.NotImplementedException();
        }
    }

}