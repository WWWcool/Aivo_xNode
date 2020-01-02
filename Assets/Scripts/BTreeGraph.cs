using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    [CreateAssetMenu(fileName = "New BTree Graph", menuName = "BTree/BTree Graph")]
    public class BTreeGraph : NodeGraph
    {
        public AivoTree.TreeNode<BTreeContext> Build()
        {
            var root = nodes.Find(node => node.GetType() == typeof(RootNode));
            if (root)
            {
                return (root as RootNode).Build();
            }
            else
            {
                Debug.LogWarning("[BTreeGraph][Build] can`t find root node in graph");
                return null;
            }
        }
    }
}