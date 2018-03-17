using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour {

    int[] data = {1,11,20,29,32,41,50,65,72,77,83,91,99 };
    //二叉查找树的节点定义
    public class Node {
        //节点本身的数据
        public int data;
        //左孩子
        public Node left;
        //右孩子
        public Node right;
        public void DisplayData() {
            Debug.Log(data + " ");
        }
    }

    //构建二叉树
    //构建二叉树是通过向二叉树插入元素得以实现的，所有小于根节点的节点插入根节点的左子树，大于根节点的，插入右子树。
    //    依此类推进行递归。直到找到位置进行插入。二叉查找树的构建过程其实就是节点的插入过程。
    public void Insert(int data) {
        Node Parent;
        //将所需插入的数据包装进节点
        Node newNode = new Node();
        newNode.data = data;

        //如果为空树，则插入根节点
        if (rootNode == null) {
            rootNode = newNode;
        }
        //否则找到合适叶子节点位置插入
        else {
            Node Current = rootNode;
            while (true) {
                Parent = Current;
                if (newNode.data < Current.data) {
                    Current = Current.left;
                    if (Current == null) {
                        Parent.left = newNode;
                        //插入叶子后跳出循环
                        break;
                    }
                } else {
                    Current = Current.right;
                    if (Current == null) {
                        Parent.right = newNode;
                        //插入叶子后跳出循环
                        break;
                    }
                }
            }
        }
    }

    //二叉树的遍历
    //二叉树的遍历分为先序(PreOrder)，中序(InOrder)和后序(PostOrder) 。
    //先序首先遍历根节点，然后是左子树，然后是右子树。
    //    中序首先遍历左子树，然后是根节点，最后是右子树。
    //    而后续首先遍历左子树，然后是右子树，最后是根节点。因此，我们可以通过.
    //中序
    public void InOrder(Node theRoot) {
        if (theRoot != null) {
            InOrder(theRoot.left);
            theRoot.DisplayData();
            InOrder(theRoot.right);
        }
    }
    //先序
    public void PreOrder(Node theRoot) {
        if (theRoot != null) {
            theRoot.DisplayData();
            PreOrder(theRoot.left);
            PreOrder(theRoot.right);
        }
    }
    //后序
    public void PostOrder(Node theRoot) {
        if (theRoot != null) {
            PostOrder(theRoot.left);
            PostOrder(theRoot.right);
            theRoot.DisplayData();
        }
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < data.Length; i++) {
            Insert(data[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
