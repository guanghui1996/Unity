// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2020-07-18 13:40:07
// 版 本：1.0
// ========================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStar
{
    public enum GridType
    {
        //正常类型
        Normal,
        //障碍物类型
        Obstacle,
        //起点类型
        Start,
        //终点类型
        End
    }
    public class Grid : MonoBehaviour, IComparable
    {
        //坐标
        public int x, y;
        //FGH
        private int f, g, h;
        //坐标
        public Grid parent;
        //格子类型
        private GridType gridType;
        public GridType MyGridType
        {
            get
            {
                return gridType;
            }
            set
            {
                gridType = value;
                //设置显示颜色
                Color tempColor = Color.white;
                switch (gridType)
                {
                    case GridType.Start:
                        tempColor = Color.red;
                        break;
                    case GridType.End:
                        tempColor = Color.green;
                        break;
                    case GridType.Obstacle:
                        tempColor = Color.blue;
                        break;
                    default:
                        break;
                }
                SetColor(tempColor);
            }

        }

        public int F { get => f; set => f = value; }
        public int G { get => g; set => g = value; }
        public int H { get => h; set => h = value; }

        private MeshRenderer meshRenderer;


        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetColor(Color c)
        {
            meshRenderer.material.color = c;
        }


        public int CompareTo(object obj)
        {
            Grid target = obj as Grid;
            if (F < target.F)
            {
                return -1;
            }
            else if (F > target.F)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
