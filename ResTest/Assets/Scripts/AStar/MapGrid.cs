// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2020-07-18 15:28:05
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace AStarNode
{
    public class MapGrid : MonoBehaviour
    {
        public GameObject Node;

        public const int mGridWidth = 10;
        public const int mGridHeight = 10;

        public GameObject m_Start;
        public GameObject m_End;


        public AsNode[,] mPointGrid = new AsNode[mGridWidth, mGridHeight];
        private List<GameObject> pathObj = new List<GameObject>();

        private void Start()
        {
            InitMapInfo();
        }

        public void InitMapInfo()
        {
            for (int i = 0; i < mGridHeight; i++)
            {
                for (int j = 0; j < mGridWidth; j++)
                {
                    mPointGrid[i, j] = new AsNode(i, j);
                }
            }
        }

        public List<AsNode> getNeibourhood(AsNode node)
        {
            List<AsNode> list = new List<AsNode>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 || j == 0)
                        continue;
                    int x = node.x + i;
                    int z = node.z + j;
                    if (x < mGridWidth && x >= 0 && z < mGridHeight && z >= 0)
                        list.Add(mPointGrid[x, z]);
                }
            }
            return list;
        }

        public void updatePath(List<AsNode> lines)
        {
            int curListSzie = pathObj.Count;
            for (int i = 0,max = lines.Count; i < max; i++)
            {
                if (i < curListSzie)
                {
                    pathObj[i].transform.position = lines[i].Position;
                    pathObj[i].SetActive(true);
                }
                else
                {
                    GameObject obj = GameObject.Instantiate(Node, lines[i].Position, Quaternion.identity);
                    pathObj.Add(obj);
                }
            }
        }

        public AsNode getItem(Vector3 pos)
        {
            int x = Mathf.RoundToInt(pos.x);
            int z = Mathf.RoundToInt(pos.z);
            return mPointGrid[x, z];
        }



        private void OnDrawGizmos()
        {
            for (int i = 0; i < mGridHeight; i++)
            {
                for (int j = 0; j < mGridWidth; j++)
                {
                    if(mPointGrid[i,j] != null)
                        Gizmos.DrawWireCube(mPointGrid[i, j].Position, Vector3.one);
                }
            }
        }
    }
}
