using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trees
{
    public class TreeNode<T> : ITreeNode<T>
    {
        public string? Name { get; set; }
        public T Data { get; set; }
        private List<ITreeNode<T>> _children;
        public IEnumerable<ITreeNode<T>> Children => _children.AsReadOnly();
        
        [AllowNull]
        public ITreeNode<T> Parent { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            _children = new List<ITreeNode<T>>();
        }

        public void AddChild(T data)
        {
            TreeNode<T> child = new TreeNode<T>(data);
            _children.Add(child);
        }

        public void RemoveChild(T data)
        {
            _children.RemoveAll(child => EqualityComparer<T>.Default.Equals(child.Data, data));
        }

        public ITreeNode<T>? FindNode(T data)
        {
            if (EqualityComparer<T>.Default.Equals(Data, data))
            {
                return this;
            }

            foreach (var child in Children)
            {
                var foundNode = child.FindNode(data);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }        
    }
}
