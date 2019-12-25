using System;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class BTreeNode : Node
    {
        public AivoTree.TreeNode<BTreeContext> node;
        [Input(typeConstraint = TypeConstraint.Strict)] public AivoTreeStatus status;

        public virtual AivoTree.TreeNode<BTreeContext> Build()
        {
            return null;
        }

        public override object GetValue(NodePort port)
        {
            return status;
        }

    }
}