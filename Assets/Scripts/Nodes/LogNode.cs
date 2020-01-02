using System;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class LogNode : BTreeNode
    {
        public bool needLog;
        public AivoTreeStatus targetStatus;

        public override AivoTree.TreeNode<BTreeContext> Build()
        {
            this.node = new AivoTree.LogNode<BTreeContext>(needLog, "log from " + name, targetStatus);
            return this.node as AivoTree.LogNode<BTreeContext>;
        }
    }
}