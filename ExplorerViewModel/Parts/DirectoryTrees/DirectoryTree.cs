using DataStructure.Trees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerViewModel
{
    public class DirectoryTree
    {
        public DirectoryTreeNode Root { get; set; }
        public DirectoryTree(DirectoryInfoViewModel data) => Root = new DirectoryTreeNode(data);
    }
}
