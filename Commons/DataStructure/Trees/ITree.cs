using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataStructure.Trees
{
    public interface ITree<T>
    {
        ITreeNode<T> Root { get; set; }
    }
}
