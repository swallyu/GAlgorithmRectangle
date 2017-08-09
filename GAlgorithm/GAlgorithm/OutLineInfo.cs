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
            float minY = outLineList.Min(m => m.Y);

            return new List<OutLine>(outLineList.Where(m => m.Y == minY));
        }


        
        /// <summary>
        /// 更新水平线轮廓，
        /// 去除原有的轮廓线，新增排样后的轮廓线
        /// </summary>
        /// <param name="lowestLine">最低水平线</param>
        /// <param name="getLength">长度</param>
        /// <param name="getWidth">宽度</param>
        public void update(OutLine lowestLine, float length, float width)
        {
            OutLine line1 = new OutLine(lowestLine.StartX,lowestLine.StartX+length,width+lowestLine.Y);
            
            this.update(line1);

            if (lowestLine.Length == length)
            {
                return;
            }
            OutLine line2 = new OutLine(lowestLine.StartX+length,lowestLine.EndX,lowestLine.Y);
            this.update(line2);
            //去除原有的水平轮廓线，
            this.outLineList.Remove(lowestLine);
        }
    }

}