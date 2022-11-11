using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour
{
    public   Transform PosList;
        public GameObject Item;
        public int distance=1;
void Start()
        {
         StartCoroutine( CreateTest());
        }
 
 
 List<float> vectorY = new List<float>();
        List<float> vectorX = new List<float>();
        List<Vector2> vector2s = new List<Vector2>();
        Vector2 pos = new Vector2();
        float _mapWidth;
        float _mapHight;
        public  IEnumerator CreateTest()
        {
            _mapWidth = PosList.GetComponent<RectTransform>().rect.width;//获取ui的实际宽度
            _mapHight = PosList.GetComponent<RectTransform>().rect.height;//长度
            Vector2 pos2D = PosList.position;
            Debug.Log("_mapWidth=" + _mapWidth + "_mapHight=" + _mapHight + "  pos2Dx=" + pos2D.x + "  pos2Dy=" + pos2D.y);
            Debug.Log("Item.transform.GetComponent<RectTransform>().rect.width=" + Item.transform.GetComponent<RectTransform>().rect.width );
            float ItmeWidth = Item.transform.GetComponent<RectTransform>().rect.width/2;
            float ItmeHeigh = Item.transform.GetComponent<RectTransform>().rect.height/2;
            for (int i = 0; i <100; i++)
            {
                do
                {
                    Debug.Log("执行do-----"+ "------i="+i);
                    Debug.Log("pos2D.x+ ItmeWidth=" + (pos2D.x + ItmeWidth)+ " _mapWidth + pos2D.x - ItmeWidth="+ (_mapWidth + pos2D.x - ItmeWidth));
                    Debug.Log("pos2D.y+ ItmeHeigh=" + (pos2D.y + ItmeHeigh) + " _mapHight + pos2D.y - ItmeHeigh=" + (_mapHight + pos2D.y - ItmeHeigh));
                    //随机 最小位置 左下角 （2d区域 x或者y + Itme的宽或者高） ：保证 最小位置不出2d区域 左下角
                    //随机 最打位置 右上角 （2d区域 x或者y + 2d区域的宽或者高+Itme的宽或者高） ：保证 最大位置不出2d区域 右上角
//DataTime.Now.Ticks 的值表示自 0001 年 1 月 1 日午夜 12:00:00 以来所经历的以 100 纳秒为间隔//的间隔数，可用于较精确的计时
                     Random.InitState((int)System.DateTime.Now.Ticks);
                    pos.x = Random.Range(pos2D.x+ ItmeWidth, _mapWidth + pos2D.x - ItmeWidth);
                    pos.y = Random.Range(pos2D.y+ ItmeHeigh, _mapHight + pos2D.y - ItmeHeigh);
                    Debug.Log("pos  y=" + pos.y + "  pos  x=" + pos.x);
                    //Debug.Log("Random.seed=" + Random.seed);
                    yield return null;
                } while (test02(pos));//(!vectorY.Contains(pos.y) && !vectorX.Contains(pos.x));   || BubbleSortY(vectorX, pos.x)
 
                Debug.Log("pos  y="+ pos.y+ "  pos  x="+ pos.x);
                if (pos.y<0){ Debug.LogError("pos.y<0  "+ pos.y);}
                if (pos.x < 0) { Debug.LogError("pos.x<0  " + pos.x); }
 
                vectorY.Add(pos.y);
                vectorX.Add(pos.x);
                vector2s.Add(pos);//不重复不重叠的 添加进List
                CreateItemPrefab(Item, pos);
            }
            
        }
       
        private bool test02(Vector2 p1)
        {
            for (int i = 0; i < vector2s.Count; i++)
            {
                if (TwoPointDistance2D(p1, vector2s[i])<distance)//两个 中心点  必须大于这个数  //才不重叠 Itme 正方形 宽100，（圆形最适合这个计算）
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 2维中如何计算两点之间的距离
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private float TwoPointDistance2D(Vector2 p1, Vector2 p2)
        {
 
            float i = Mathf.Sqrt((p1.x - p2.x) * (p1.x - p2.x)
                                + (p1.y - p2.y) * (p1.y - p2.y));
 
            return i;
        }

        private void CreateItemPrefab(GameObject item,Vector2 posi)
        {
            Instantiate(item,posi,Quaternion.identity);
        }
}
