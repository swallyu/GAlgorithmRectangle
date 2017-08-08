using System;

namespace GAlgorithm.GAlgorithm
{
    /// <summary>
    /// 几何算法
    /// </summary>
    public class GeometryUtils
    {
        /// <summary>
        /// 两点距离
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double pointLength(Point start,Point end){

            return Math.Sqrt(Math.Pow(start.getX()-end.getX(),2)+
                             Math.Pow(start.getY()-end.getY(),2));

        }
    }
}