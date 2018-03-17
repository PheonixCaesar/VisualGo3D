using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour {
    public static int[] data = { 19, 10, 14, 37, 14 };
    public GameObject CubeBar;
    public static GameObject[] CubeArray = new GameObject[data.Length];
    public float posMid, xi, xj;
    public float RotateAroundSpeed;
    public static int mode = 0;
    float margin = 15, wide = 8;

    static float PosMid(int i, int j) {
        return (CubeArray[i].transform.position.x + CubeArray[j].transform.position.x) / 2;
    }

    private static void Swap(IList<int> data, int min, int i) {
        int temp = data[min];
        data[min] = data[i];
        data[i] = temp;
        //3D交换
        float m = (CubeArray[min].transform.position.x + CubeArray[i].transform.position.x) / 2;

        SwitchCube(min, i);
    }

    //static void SwapRound(int i, int j) {
    //    //float m = (CubeArray[i].transform.position.x + CubeArray[j].transform.position.x) / 2;
    //    CubeArray[i].GetComponent<Move>().SetPos(PosMid(i, j), i, j);
    //    CubeArray[i].GetComponent<Move>().StartMove();
    //    CubeArray[j].GetComponent<Move>().SetPos(PosMid(i, j), j, i);
    //    CubeArray[i].GetComponent<Move>().StartMove();
    //}

    static void SwitchCube(int i, int j) {
        float xi = CubeArray[i].transform.position.x,
            xj = CubeArray[j].transform.position.x;
        Debug.Log(i+" "+xi+" "+j+" "+xj);
        //CubeArray[i].transform.RotateAround(new Vector3(posm, 0, 0), Vector3.up, RotateAroundSpeed);
        //CubeArray[j].transform.RotateAround(new Vector3(posm, 0, 0), Vector3.up, RotateAroundSpeed);
        CubeArray[i].GetComponent<Move>().SetPos(PosMid(i,j), xi, xj);
        CubeArray[i].GetComponent<Move>().StartMove();
        CubeArray[j].GetComponent<Move>().SetPos(PosMid(j,i), xj, xi);
        CubeArray[j].GetComponent<Move>().StartMove();
    }

    public static IEnumerator Awake() {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }

    // <summary>
    /// 冒泡排序
    /// </summary>
    /// <param name="data"></param>
    // 做
    //  交换旗帜变量 = 假 （False）
    //  for i = 1 to indexOfLastUnsortedElement-1
    //    如果 左边元素 > 右边元素
    //      交换（左边元素，右边元素）
    //      交换旗帜变量 = 真（True）
    //while 交换旗帜变量
    public static void BubbleSort(IList<int> data) {
        for (int i = data.Count - 1; i > 0; i--) {
            for (int j = 0; j < i; j++) {
                if (data[j] > data[j + 1]) {
                    Swap(data, j, j + 1);
                    Awake();
                }
            }.
        }
    }

    /// <summary>
    /// 选择排序
    /// </summary>
    /// <param name="data"></param>
    //重复（元素个数-1）次
    //把第一个没有排序过的元素设置为最小值
    //遍历每个没有排序过的元素
    //  如果元素<现在的最小值
    //    将此元素设置成为新的最小值
    //将最小值和第一个没有排序过的位置交换
    public static void SelectSort(IList<int> data) {
        for (int i = 0; i < data.Count - 1; i++) {
            int min = i;
            int temp = data[i];
            for (int j = i + 1; j < data.Count; j++) {
                if (data[j] < temp) {
                    min = j;
                    temp = data[j];
                }
            }
            if (min != i) {
                Swap(data, min, i);
                Awake();
            }

        }
    }

    /// <summary>
    /// 插入排序
    /// </summary>
    /// <param name="data"></param>
    //将第一个元素标记为已排序
    //for each unsorted element X
    //  'extract' the element X
    //  for j = lastSortedIndex down to 0
    //    if current element j > X
    //      将排序过的元素向右移一格
    //    break loop and insert X here
    public static void InsertSort(IList<int> data) {
        int temp;
        for (int i = 1; i < data.Count; i++) {
            temp = data[i];
            for (int j = i - 1; j >= 0; j--) {
                if (data[j] > temp) {
                    data[j + 1] = data[j];
                    if (j == 0) {
                        data[0] = temp;
                        break;
                    }
                } else {
                    data[j + 1] = temp;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 归并排序
    /// </summary>
    /// <param name="data"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    //将每个元素拆分成大小为1的部分
    //递归的合并相邻的拆分项
    //  i = 左侧开始项指数 到 右侧最后项指数 的遍历（两端包括）
    //    如果左侧首值 <= 右侧首值
    //     拷贝左侧首项的值
    //    否则： 拷贝右侧部分首值
    //将元素拷贝进原来的数组中
    //public static IList<int> MergeSortOnlyList(IList<int> data, int low, int high) {
    //    if (low == high)
    //        return new List<int> { data[low] };
    //    IList<int> mergeData = new List<int>();
    //    int mid = (low + high) / 2;
    //    IList<int> leftData = MergeSortOnlyList(data, low, mid);
    //    IList<int> rightData = MergeSortOnlyList(data, mid + 1, high);
    //    int i = 0, j = 0;
    //    while (true) {
    //        if (leftData[i] < rightData[j]) {
    //            mergeData.Add(leftData[i]);
    //            if (++i == leftData.Count) {
    //                mergeData.AddRange(rightData.GetRange(j, rightData.Count - j));
    //                break;
    //            }
    //        } else {
    //            mergeData.Add(rightData[j]);
    //            if (++j == rightData.Count) {
    //                mergeData.AddRange(leftData.GetRange(i, leftData.Count - i));
    //                break;
    //            }
    //        }
    //    }
    //    return mergeData;
    //}

    //public static IList<int> MergeSortOnlyList(IList<int> data) {
    //    data = MergeSortOnlyList(data, 0, data.Count - 1);  //不会改变外部引用 参照C#参数传递
    //    return data;
    //}

    /// <summary>
    /// 快速排序
    /// </summary>
    /// <param name="data"></param>
    /// 每个（未排序）的拆分的遍历
    //将第一个元素设为轴心点
    //  存储指数 = 轴心点指数 +1
    //  从 i=轴心点指数 +1 到 最右指数 的遍历
    //    如果 元素[i] < 元素[轴心点]
    //      交换(i, 存储指数); 存储指数++
    //  交换(轴心点, 存储指数 - 1)
    public static void QuickSortStrict(IList<int> data) {
        QuickSortStrict(data, 0, data.Count - 1);
    }

    public static void QuickSortStrict(IList<int> data, int low, int high) {
        if (low >= high) return;
        int temp = data[low];
        int i = low + 1, j = high;
        while (true) {
            while (data[j] > temp) j--;
            while (data[i] < temp && i < j) i++;
            if (i >= j) break;
            Swap(data, i, j);
            i++; j--;
        }
        if (j != low) {
            Swap(data, low, j);
            Awake();
        }
        QuickSortStrict(data, j + 1, high);
        QuickSortStrict(data, low, j - 1);
    }

    int posCalculate(int i) {
        int pos = i * 5;
        return pos;
    }



    // Use this for initialization
    void Start() {

        CubeArray = new GameObject[data.Length];
        //GameObject obj5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //设置物体的位置Vector3三个参数分别代表x,y,z的坐标数  
        Vector3 pos = new Vector3(-(((data.Length - 1) / 2 + 1) * margin), 0, 0);
        for (int k = 0; k < data.Length; k++) {
            pos = new Vector3(pos.x, data[k] / 2, pos.z);
            pos += new Vector3(margin, 0, 0);
            CubeArray[k] = Instantiate(CubeBar, pos, Quaternion.identity);
            CubeArray[k].transform.localScale = new Vector3(wide, data[k], 1);
        }
        //给这个创建出来的对象起个名字  
        //obj1.name = "dujia";
        //设置物体的tag值，在赋值之前要在Inspector面板中注册一个tag值  
        //注册tag值得方法，用鼠标选中摄像机对象在Inspector面板中找到tag，选addtag  
        //obj1.tag = "Cube";
        //设置物体贴图要图片文件放在(Resources）文件夹下，没有自己创建  
        //obj1.GetComponent<Renderer>().material.mainTexture = (Texture)Resources.Load("psb20");
        // RotateAroundSpeed = 20 * Time.deltaTime;//


        //测试
        mode = 1;
        switch (mode) {
            case 1:
                BubbleSort(data);
                break;
            case 2:
                SelectSort(data);
                break;
            case 3:
                InsertSort(data);
                break;
            //case 4:
            //    MergeSortOnlyList(data,0,data.Length);
            //    break;
            case 4:
                QuickSortStrict(data);
                break;
            default:
                break;
        }

        //测试
        //int i = 1, j = 3;
        //SwitchCube(i, j);
    }

    // Update is called once per frame
    void Update() {
        //int i=1, j=3;
        //xi = CubeArray[i].transform.position.x;
        //xj = CubeArray[j].transform.position.x;
        //posMid = (xi + xj) / 2;

        //SwitchCube(1, 3,posMid);
    }
}
