using System.Collections.Generic;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class BTreeNode : Node
    {
        public AivoTree.TreeNode<BTreeContext> node;
        [Input(typeConstraint = TypeConstraint.Strict, connectionType = ConnectionType.Override)] public AivoTreeStatus status;
        private int nodeNumber = 0;

        public virtual AivoTree.TreeNode<BTreeContext> Build()
        {
            return null;
        }

        public override object GetValue(NodePort port)
        {
            return status;
        }

        protected int SortConnections(BTreeNode node1, BTreeNode node2)
        {
            return node1.nodeNumber < node2.nodeNumber ? -1 : 1;
        }

        public void SetNumber(int number)
        {
            nodeNumber = number;
        }

    }
}