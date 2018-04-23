using System;
using System.Text;

namespace Lab8
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree(random.Next(0, 10));
            for(int i = 0; i < 99; i++)
            {
                binaryTree.Add(random.Next(0, 10));
            }
            Console.Write("Введите число, которое надо найти в дереве: ");
            int value = int.Parse(Console.ReadLine());
            BinaryTree.TreeNode treeNode = binaryTree.Find(value);
            if (treeNode != null)
            {
                Console.WriteLine("Число повторений числа " + value + ": " + treeNode.Count);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(binaryTree.Path.ToString());
                Console.ReadLine();
            }
        }
    }

    public class BinaryTree
    {
        public class TreeNode
        {
            public int Value { get; set; }
            public int Count { get; set; }
            public TreeNode LeftTreeNode { get; set; }
            public TreeNode RightTreeNode { get; set; }

            public TreeNode(int value)
            {
                Value = value;
                Count = 1;//метод для проверки кол-ва одинаковых элементов и логику для 
                LeftTreeNode = null;
                RightTreeNode = null;
            }
        }

        public TreeNode Root { get; set; }
        public StringBuilder Path { get; set; }
        //public TreeNode Node { get; set; }

        public BinaryTree()
        {
            Root = null;
            Path = new StringBuilder("");
        }

        public BinaryTree(int value)
        {
            Root = new TreeNode(value);
            Path = new StringBuilder("");
        }

        public void Add(int value)//проверить на работоспособность
        {
            if(Root == null)
            {
                Root = new TreeNode(value);
                return;
            }

            TreeNode temp = Root;
            bool b = false;
            do
            {
                if (value == temp.Value)
                {
                    temp.Count++;
                    return;
                }
                if (value > temp.Value)//если больше то вправо
                {
                    if (temp.RightTreeNode == null)
                    {
                        temp.RightTreeNode = new TreeNode(value);
                        b = true;
                        //return;
                    }
                    else
                    {
                        temp = temp.RightTreeNode;
                        //continue;
                    }
                }
                if (value < temp.Value)//если меньше то влево
                {
                    if (temp.LeftTreeNode == null)
                    {
                        temp.LeftTreeNode = new TreeNode(value);
                        b = true;
                        //return;
                    }
                    else
                    {
                        temp = temp.LeftTreeNode;
                        //continue;
                    }
                }
            }
            while (!b);
        }

        public TreeNode Find(int value)
        {
            TreeNode res = null;
            TreeNode temp = Root;
            bool b = false;
            do
            {
                if (temp == null)
                {
                    return null;
                }
                if (value == temp.Value)
                {
                    return temp;
                }
                if (value > temp.Value)//если больше то вправо
                {
                    if (temp.RightTreeNode == null)
                    {
                        return null;
                    }
                    Path.Append(temp.Value).Append(" ");
                    temp = temp.RightTreeNode;
                    continue;
                }
                if (value < temp.Value)//если меньше то влево
                {
                    if (temp.LeftTreeNode == null)
                    {
                        return null;
                    }
                    Path.Append(temp.Value).Append(" ");
                    temp = temp.LeftTreeNode;
                    continue;
                }
            }
            while (!b);
            return res;
        }
    }
}
