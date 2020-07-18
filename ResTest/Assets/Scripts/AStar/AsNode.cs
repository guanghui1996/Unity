// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2020-07-18 14:14:19
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AStarNode
{
    public class AsNode
    {
        public int x;
        public int z;
        private int f;
        private int g;
        private int h;
        private int w;
        private bool isWall;
        private AsNode parent;
        private Vector3 pos;

        public AsNode(int x, int z)
        {
            this.x = x;
            this.z = z;
            this.Position = new Vector3(x, 0, z);
        }

        public AsNode(int x, int z, bool isWall) : this(x, z)
        {
            this.isWall = isWall;
        }

        /// <summary>
        /// f = h + g
        /// </summary>
        public int F { get => f; set => f = value; }
        /// <summary>
        /// 起点到当前节点 初始节点到当前节点的实际代价
        /// </summary>
        public int G { get => g; set => g = value; }
        /// <summary>
        /// 当前节点到终点预估值
        /// </summary>
        public int H { get => h; set => h = value; }
        /// <summary>
        /// 节点的权重
        /// </summary>
        public int W { get => w; set => w = value; }
        public Vector3 Position { get => pos; set => pos = value; }
        public AsNode Parent { get => parent; set => parent = value; }
        public bool IsWall { get => isWall; set => isWall = value; }
    }
}

