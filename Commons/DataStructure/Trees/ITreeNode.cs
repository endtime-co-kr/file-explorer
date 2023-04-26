using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trees
{
    public interface ITreeNode<T>
    {
        T Data { get; set; }
        ITreeNode<T> Parent { get; set; }
        IEnumerable<ITreeNode<T>> Children { get; }
        void AddChild(T data);
        void RemoveChild(T data);
        ITreeNode<T> FindNode(T data);
    }
}
