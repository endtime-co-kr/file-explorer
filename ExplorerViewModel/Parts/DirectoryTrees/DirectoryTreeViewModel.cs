using DataStructure.Trees;
using ExplorerViewModel;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerViewModel
{
    public class DirectoryTreeViewModel : BaseViewModel
    {
        private DirectoryTree? _directoryTreeCollection;
        public DirectoryTree? DirectoryTreeCollection
        { 
            get => _directoryTreeCollection; 
            set => OnUpdateProperty(ref _directoryTreeCollection, value, nameof(DirectoryTreeCollection));
        }

        public DirectoryTreeViewModel() 
        {
            DirectoryTreeCollection = new DirectoryTree(new DirectoryInfoViewModel() { Name = "root" });
        }
    }
}
