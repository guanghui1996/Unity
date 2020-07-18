// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2020-07-18 15:28:33
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStarNode
{
    public class FindPath : MonoBehaviour
    {
        public MapGrid mapGrid;
        void Start()
        {
            mapGrid = GetComponent<MapGrid>();
        }

        // Update is called once per frame
        void Update()
        {
            FindingPath(mapGrid.m_Start.transform.position, mapGrid.m_End.transform.position);
        }

        public int getDistanceNodes(AsNode a, AsNode b)
        {
            //采用对角算法 X(Y)差值较小的，采取对角
            //对角代价14
            //水平 垂直 代价10
            int cntX = Mathf.Abs(a.x - b.x);
            int cntZ = Mathf.Abs(a.z - b.z);
            if (cntX > cntZ)
                return 14 * cntZ + 10 * (cntX - cntZ);
            else
                return 14 * cntX + 10 * (cntZ - cntX);
        }

        void FindingPath(Vector3 startPos, Vector3 endPos)
        {
            //通过坐标获取地图上的起点和终点
            AsNode startNode = mapGrid.getItem(startPos);
            AsNode endNode = mapGrid.getItem(endPos);
            //打开列表 存放邻近点
            List<AsNode> openList = new List<AsNode>();
            //关闭列表 存放选定的路径点
            List<AsNode> closedList = new List<AsNode>();
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                AsNode curNode = openList[0];
                //（第一次运算）是用来将起点加入到关闭列表中
                //(后面的运算)通过判断还没到达终点,继续下面的执行过程获得新的打开列表（当前点的邻居点）
                for (int i = 0, max = openList.Count; i < max; i++)
                {
                    //比较开启列表里的点 估价总值F 和点到终点的估价H
                    //若列表中的点估价更低，替换为当前点
                    if (openList[i].F <= curNode.F && openList[i].H < curNode.H)
                    {
                        curNode = openList[i];
                    }
                }
                //选择到点，然后加入到关闭列表中
                openList.Remove(curNode);
                closedList.Add(curNode);

                //直到找到终点为止
                if (curNode == endNode)
                {
                    generatePath(startNode, endNode);
                    return;
                }

                foreach (var item in mapGrid.getNeibourhood(curNode))
                {
                    //如果该点是障碍点，或者关闭列表已经有该点，跳过
                    if (item.IsWall || closedList.Contains(item))
                        continue;
                    //可移动点，进行估价
                    int newCost = curNode.G + getDistanceNodes(curNode, item);
                    //如果距离更小，或者原来不在开始列表中
                    if (newCost < item.G || !openList.Contains(item))
                    {
                        //更新与开始节点的距离
                        item.G = newCost;
                        //更新与终点的距离
                        item.H = getDistanceNodes(item, endNode);
                        //更新父节点为当前选定的节点
                        item.Parent = curNode;
                        //如果节点是新加入的，将它加入打开列表中
                        if (!openList.Contains(item))
                            openList.Add(item);
                    }
                }
            }
            generatePath(startNode, null);
        }

        void generatePath(AsNode startNode, AsNode endNote)
        {
            List<AsNode> path = new List<AsNode>();
            if (endNote != null)
            {
                AsNode temp = endNote;
                while (temp != startNode)
                {
                    path.Add(temp);
                    temp = temp.Parent;
                }
                //反转队列内容
                path.Reverse();
            }
            //更新路径
            mapGrid.updatePath(path);
        }
    }

}
