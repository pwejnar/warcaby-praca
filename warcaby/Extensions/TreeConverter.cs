using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace Checkers
{
    public class TreeConverter<T> where T : IGotChildrens
    {
        private readonly List<T> _tree;
        public List<List<T>> ResultList { get; set; }

        public TreeConverter(List<T> tree)
        {
            this._tree = tree;
            GeneratePathsFromTree();
        }

        public TreeConverter(T treeNode)
        {
            _tree = new List<T>();
            _tree.Add(treeNode);
            GeneratePathsFromTree();
        }

        private void GeneratePathsFromTree()
        {
            ResultList = new List<List<T>>();

            foreach (var children in _tree)
            {
                GeneratePathsRecursion(children);
            }
        }


        private void GeneratePathsRecursion(T children, List<T> currentPath = null)
        {
            if (currentPath == null)
                currentPath = new List<T>();

            currentPath.Add(children);

            if (children.GetChildrens() == null || children.GetChildrens().Count == 0)
            {
                ResultList.Add(currentPath);
            }

            else
            {
                foreach (var fmove in children.GetChildrens())
                {
                    List<T> l2 = new List<T>(currentPath);
                    GeneratePathsRecursion((T)fmove, l2);
                }
            }
        }



    }
}
