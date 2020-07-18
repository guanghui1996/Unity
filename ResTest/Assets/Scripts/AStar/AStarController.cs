// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2020-07-18 13:39:47
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AStar 
{
	public class AStarController : MonoBehaviour
	{

		//起点坐标
		public int startPosX, startPosY;
		//终点坐标
		public int endPosX, endPosY;
		//障碍物比率
		public int obstacleRate;

		private GameObject gridPrefab;

		private List<Grid> openList;
		private List<Grid> closeList;
		//结果栈
		private Stack<Grid> result;

		//所有格子数组
		private Grid[,] allGrids = null;

		void Awake()
		{
			result = new Stack<Grid>();
			openList = new List<Grid>();
			closeList = new List<Grid>();
			//设置数组长度
			allGrids = new Grid[(int)(transform.localScale.x
				* 20), (int)(transform.localScale.z * 20)];
		}

		void Start()
		{
			gridPrefab = Resources.Load<GameObject>("Grid");
			//遍历生成格子
			for (int i = 0; i < transform.localScale.x * 20; i++)
			{
				for (int j = 0; j < transform.localScale.z * 20; j++)
				{
					//生成
					Grid currentGrid = Instantiate(gridPrefab).
						GetComponent<Grid>();
					//计算偏移量
					Vector2 offset = new Vector2(-4.7f * transform.
						localScale.x, -4.7f * transform.localScale.z);
					//设置方块的世界坐标
					currentGrid.transform.position = new Vector3(
						offset.x + i * 0.5f, 0, offset.y + j * 0.5f);
					//设置格子坐标
					currentGrid.x = i;
					currentGrid.y = j;
					//存储起来
					allGrids[i, j] = currentGrid;
					//随机障碍物
					int r = Random.Range(1, 101);
					if (r <= obstacleRate)
					{
						currentGrid.MyGridType = GridType.Obstacle;
					}
				}
			}
			//设置起点和终点
			allGrids[startPosX, startPosY].MyGridType = GridType.Start;
			allGrids[endPosX, endPosY].MyGridType = GridType.End;

			//调用AStar计算
			AStarCount();
		}
		/// <summary>
		/// A*计算
		/// </summary>
		void AStarCount()
		{
			//将起点放置到OpenList
			openList.Add(allGrids[startPosX, startPosY]);
			//获取当前要发现的中心格子
			Grid currentGrid = openList[0];
			//循环递归
			//开启列表中有对象&&当前的中心不是终点
			while (openList.Count > 0 &&
				currentGrid.MyGridType != GridType.End)
			{
				//重新排序
				openList.Sort();
				//获取新的中心格子
				currentGrid = openList[0];
				//判断最新的格子是否是终点
				if (currentGrid.MyGridType == GridType.End)
				{
					///TODO:生成结果
					GetParent(currentGrid);
					return;
				}
				//上下左右，左上右上左下右下
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if (i != 0 || j != 0)
						{
							//获取新格子的格子坐标
							int x = currentGrid.x + i;
							int y = currentGrid.y + j;
							//判断格子坐标合法
							//前四个条件判断坐标的合法性
							//新格子不能是障碍物
							//新格子没有被遍历过
							if (x > 0 && y > 0 && x < allGrids.GetLength(0)
							   && y < allGrids.GetLength(1) &&
							   allGrids[x, y].MyGridType != GridType.Obstacle &&
							   !closeList.Contains(allGrids[x, y]))
							{
								//计算G值
								int g = (int)(currentGrid.G +
									Mathf.Sqrt(Mathf.Abs(i) + Mathf.Abs(j)) * 10);
								//判断新格子是否被遍历过
								//如果被遍历过，判断当前G值是否比之前的更小
								if (allGrids[x, y].G == 0 || g < allGrids[x, y].G)
								{
									//更新G值
									allGrids[x, y].G = g;
									//更新父格子
									allGrids[x, y].parent = currentGrid;
								}
								//计算H
								allGrids[x, y].H = (Mathf.Abs(x - endPosX) + Mathf.Abs(y - endPosY)) * 10;
								//计算F
								allGrids[x, y].F = allGrids[x, y].G + allGrids[x, y].H;
								//加入到开启列表
								if (!openList.Contains(allGrids[x, y]))
								{
									Debug.Log(1);
									openList.Add(allGrids[x, y]);
								}
							}
						}
					}
				}
				//将当前格子移除OpenList
				openList.Remove(currentGrid);
				//放到CloseList里
				closeList.Add(currentGrid);
				//OpenList空了
				if (openList.Count == 0)
				{
					Debug.Log("Can Not Arrave！！！");
				}
			}
		}

		private void GetParent(Grid current)
		{
			//进栈
			result.Push(current);
			//判断是否继续递归
			if (current.parent != null)
			{
				GetParent(current.parent);
			}
			else
			{
				//展示结果
				StartCoroutine(ShowResult());
			}
		}

		IEnumerator ShowResult()
		{
			//获取总长度
			int resultCount = result.Count;
			while (result.Count > 0)
			{
				yield return new WaitForSeconds(0.1f);
				//出栈
				Grid currentResultGrid = result.Pop();
				//计算比例
				float scale = (resultCount - result.Count) / (float)resultCount;
				//上色
				Color currentC = Color.Lerp(Color.red, Color.green, scale);
				currentResultGrid.SetColor(currentC);
			}
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
	}
}

