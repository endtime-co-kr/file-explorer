using DataStructure.Trees;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trees
{
    public class Tree<T> : ITree<T>
    {
        public ITreeNode<T> Root { get; set; }

        public Tree(T data) => Root = new TreeNode<T>(data);

        public void Traverse(ITreeNode<T> node, Action<ITreeNode<T>> action)
        {
            if (node == null)
                return;

            action(node);

            foreach (var child in node.Children)
            {
                Traverse(child, action);
            }
        }
    }

    //public class Tree<T> : ITree<T>
    //{
    //    public ITreeNode<T> Root { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public ITreeNode<T> Add(ITreeNode<T> node, ITreeNode<T> newNode)
    //    {
    //        node.Children.ToList().Add(newNode);
    //        return newNode;
    //    }

    //    public void Remove(ITreeNode<T> node)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ITreeNode<T> Search(ITreeNode<T> startNode, T target)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ITreeNode<T> Search(ITreeNode<T> startNode, ITreeNode<T> target)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ITreeNode<T> Search(ITreeNode<T> startNode, string targetName)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
