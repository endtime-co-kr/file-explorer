using DataStructure.Trees;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerViewModel
{
    public class DirectoryTreeNode : BaseViewModel
    {
        public DirectoryInfoViewModel Data { get; set; }
        private ObservableCollection<DirectoryTreeNode> _children;
        public ObservableCollection<DirectoryTreeNode> Children
        {
            get => _children;
            set => OnUpdateProperty(ref _children, value);
        }

        [AllowNull]
        public DirectoryTreeNode Parent { get; set; }

        public DirectoryTreeNode(DirectoryInfoViewModel data)
        {
            Data = data;
            _children = new ObservableCollection<DirectoryTreeNode>();
        }

        public void AddChild(DirectoryInfoViewModel data)
        {
            DirectoryTreeNode child = new DirectoryTreeNode(data);
            child.Parent = this;
            _children.Add(child);
        }

        public void RemoveChild(DirectoryInfoViewModel data)
        {
            
        }

        public DirectoryTreeNode FindNode(DirectoryInfoViewModel data)
        {
            if (EqualityComparer<DirectoryInfoViewModel>.Default.Equals(Data, data))
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
