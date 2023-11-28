using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace BSTree
{
    public class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
    {
        TreeNode Root;

        public bool IsExsit(Tdata _data)
        {
            return BSFind(_data) != null;
        }


        //Balance
        public void Balance()
        {
            List<Tdata> nodes = new List<Tdata>();
            InOrderToArray(this.Root, nodes);
            this.Root = RecursiveBalance(0, nodes.Count - 1, nodes);
        }
        void InOrderToArray(TreeNode node, List<Tdata> nodes)
        {
            if (node == null) return;
            InOrderToArray(node.Left, nodes);
            nodes.Add(node.Data);
            InOrderToArray(node.Right, nodes);
        }
        TreeNode RecursiveBalance(int start, int end, List<Tdata> nodes)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            TreeNode newNode = new TreeNode(nodes[mid]);
            newNode.Left = RecursiveBalance(start, mid - 1, nodes);
            newNode.Right = RecursiveBalance(mid + 1, end, nodes);
            return newNode;
        }


        //Find
        NodeAndParent FindNodeAndParent(Tdata _data)
        {
            TreeNode currentNode = this.Root;
            TreeNode Parent = null;
            NodeAndParent nodeAndParentInfo = null;
            bool left = false;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(_data) == 0)
                {
                    nodeAndParentInfo = new NodeAndParent() { Node = currentNode, Parent = Parent, isLeft = left };
                    break;
                }
                else if (currentNode.Data.CompareTo(_data) > 0)
                {
                    Parent = currentNode;
                    left = true;
                    currentNode = currentNode.Left;
                }
                else
                {
                    Parent = currentNode;
                    left = false;
                    currentNode = currentNode.Right;
                }
            }
            return nodeAndParentInfo;
        }

        TreeNode BSFind(Tdata _data)
        {
            TreeNode currentNode = this.Root;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(_data) == 0)
                {
                    return currentNode;
                }
                else if (currentNode.Data.CompareTo(_data) > 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
            return null;
        }


        //Delete
        public void BsDelete(Tdata _data)
        {
            NodeAndParent nodeAndParentInfo = this.FindNodeAndParent(_data);
            if (nodeAndParentInfo.Node == null) return;

            if (nodeAndParentInfo.Node.Left != null && nodeAndParentInfo.Node.Right != null)
            {
                BSDelete_Has_Childs(nodeAndParentInfo.Node);
            }
            else if (nodeAndParentInfo.Node.Left != null ^ nodeAndParentInfo.Node.Right != null)
            {
                BSDelete_Has_One_Child(nodeAndParentInfo.Node);
            }
            else
            {
                BSDelete_leaf(nodeAndParentInfo);
            }

        }

        void BSDelete_leaf(NodeAndParent nodeAndParentInfo)
        {
            if (nodeAndParentInfo.Parent == null)
            {
                this.Root = null;
            }
            else
            {
                if (nodeAndParentInfo.isLeft)
                {
                    nodeAndParentInfo.Parent.Left = null;
                }
                else
                {
                    nodeAndParentInfo.Parent.Right = null;
                }
            }

        }
        void BSDelete_Has_One_Child(TreeNode nodeToDelete)
        {
            TreeNode nodeToReplace = null;
            if (nodeToDelete.Left != null)
            {
                nodeToReplace = nodeToDelete.Left;
            }
            else
            {
                nodeToReplace = nodeToDelete.Right;
            }
            nodeToDelete.Data = nodeToReplace.Data;
            nodeToDelete.Left = nodeToReplace.Left;
            nodeToDelete.Right = nodeToReplace.Right;
        }
        void BSDelete_Has_Childs(TreeNode nodeToDelete)
        {
            TreeNode currentNode = nodeToDelete.Right;
            TreeNode parent = null;
            while (currentNode.Left != null)
            {
                parent = currentNode;
                currentNode = currentNode.Left;
            }
            if (parent != null)
            {
                parent.Left = currentNode.Right;
            }
            else
            {
                nodeToDelete.Right = currentNode.Right;
            }

            nodeToDelete.Data = currentNode.Data;

        }


        //Insert

        public void BSInsert(Tdata _data)
        {
            TreeNode newNode = new TreeNode(_data);
            if (this.Root == null)
            {
                this.Root = newNode;
                return;
            }
            TreeNode currentNode = this.Root;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(_data) > 0) // currentNode.Data > data
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }

        public void Insert(Tdata _data)
        {
            TreeNode newNode = new TreeNode(_data);
            if (this.Root == null)
            {
                this.Root = newNode;
                return;
            }
            Tree.Queue<TreeNode> q = new Tree.Queue<TreeNode>();
            q.enqueue(this.Root);
            while (q.hasData())
            {
                TreeNode currentNode = q.dequeue();
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    break;
                }
                else
                {
                    q.enqueue(currentNode.Left);
                }

                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    break;
                }
                else
                {
                    q.enqueue(currentNode.Right);
                }
            }
        }

        public int Height()
        {
            return internalHeight(this.Root);
        }
        int internalHeight(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(
              internalHeight(node.Left),
              internalHeight(node.Right)
              );
        }

        public void PreOrder()
        {
            internalPreOrder(this.Root);
            Console.WriteLine("");
        }
        void internalPreOrder(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.Data + " -> ");
            internalPreOrder(node.Left);
            internalPreOrder(node.Right);
        }


        public void InOrder()
        {
            internalInOrder(this.Root);
            Console.WriteLine("");
        }
        void internalInOrder(TreeNode node)
        {
            if (node == null) return;
            internalInOrder(node.Left);
            Console.Write(node.Data + " -> ");
            internalInOrder(node.Right);
        }


        public void PostOrder()
        {
            internalPostOrder(this.Root);
            Console.WriteLine("");
        }
        void internalPostOrder(TreeNode node)
        {
            if (node == null) return;
            internalPostOrder(node.Left);
            internalPostOrder(node.Right);
            Console.Write(node.Data + " -> ");
        }




        class TreeNode
        {
            public Tdata Data;
            public TreeNode Left;
            public TreeNode Right;
            public TreeNode(Tdata _data)
            {
                this.Data = _data;
            }
        } // class TreeNode
        class NodeAndParent
        {
            public TreeNode Node;
            public TreeNode Parent;
            public bool isLeft;
        }


        //============================ Printer
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this.Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = LeftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int Left, int Right = -1)
        {
            Console.SetCursorPosition(Left, top);
            if (Right < 0) Right = Left + s.Length;
            while (Console.CursorLeft < Right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    } // class BinaryTree
}
