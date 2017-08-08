using System.Collections.Generic;

namespace GAlgorithm.GAlgorithm
{
/**
 * 遗传算法实现
 */
    public class GAlgorithm {

        /**
         * 子代停止
         */
        private int generation = 100;

        /**
         * 变异率
         */
        private float mutation = 0.0001f;

        /**
         * 交叉率
         */
        private float crossover = 0.0001f;

        /**
         *
         * @param boardInfo 板材描述
         * @param panels 待排板件信息
         */
        public void process(BoardInfo boardInfo, IList<Panel> panels){

            Box2dAlgorithm algorithm = new Box2dAlgorithm(boardInfo,panels);

            algorithm.process();
        }
    }
}