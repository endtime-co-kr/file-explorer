using DataStructure.Trees;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerViewModel
{
    public class ExplorerMainViewModel : BaseViewModel
    {
        private ObservableCollection<FileInfoViewModel> _fileInfoCollection;
        public ObservableCollection<FileInfoViewModel> FileInfoCollection
        {
            get => _fileInfoCollection;
            set => OnUpdateProperty(ref _fileInfoCollection, value, nameof(FileInfoCollection));
        }

        private DirectoryTreeViewModel _directoryTreeVM;
        public DirectoryTreeViewModel DirectoryTreeVM
        {
            get => _directoryTreeVM;
            set => OnUpdateProperty(ref _directoryTreeVM, value, nameof(DirectoryTreeVM));
        }



        public ExplorerMainViewModel()
        {
            _fileInfoCollection = new ObservableCollection<FileInfoViewModel>();
            DirectoryTreeVM = new DirectoryTreeViewModel();
            Test();
        }

        public void Test()
        {
            FileInfoCollection.Add(new FileInfoViewModel() { FileName = "a" });
            FileInfoCollection.Add(new FileInfoViewModel() { FileName = "b" });
            FileInfoCollection.Add(new FileInfoViewModel() { FileName = "c" });

            Tree<string> tree = new Tree<string>("root");
            tree.Root.AddChild("1");
            tree.Root.AddChild("2");

            tree.Root.Children.ElementAt(0).AddChild("1.1");
            tree.Root.Children.ElementAt(0).AddChild("1.2");

            tree.Root.Children.ElementAt(1).AddChild("2.1");
            tree.Root.Children.ElementAt(1).AddChild("2.2");

            tree.Root.FindNode("2.2");

            tree.Traverse(tree.Root, n => Debug.WriteLine(n.Data));


            DirectoryTreeVM.DirectoryTreeCollection?.Root.AddChild(new DirectoryInfoViewModel() { Name = "a" });
            DirectoryTreeVM.DirectoryTreeCollection?.Root.AddChild(new DirectoryInfoViewModel() { Name = "b" });

            DirectoryTreeVM.DirectoryTreeCollection?.Root.Children.ElementAt(0).AddChild(new DirectoryInfoViewModel() { Name = "a.1" });
            DirectoryTreeVM.DirectoryTreeCollection?.Root.Children.ElementAt(0).AddChild(new DirectoryInfoViewModel() { Name = "a.2" });

            DirectoryTreeVM.DirectoryTreeCollection?.Root.Children.ElementAt(1).AddChild(new DirectoryInfoViewModel() { Name = "b.1" });
            DirectoryTreeVM.DirectoryTreeCollection?.Root.Children.ElementAt(1).AddChild(new DirectoryInfoViewModel() { Name = "b.2" });
        }
    }
}
