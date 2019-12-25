using System;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class AlwaysNode : BTreeNode
    {
        [Output] public AivoTreeStatus output;
        public AivoTreeStatus targetStatus;

        public override AivoTree.TreeNode<BTreeContext> Build()
        {
            NodePort outputPort = GetOutputPort("output");

            if (!outputPort.IsConnected)
            {
                Debug.LogWarning("Node isn't connected");
                return null;
            }

            var node = outputPort.Connection.node as BTreeNode;
            if (node)
            {
                if (this.node != null)
                {
                    return this.node as AivoTree.AlwaysNode<BTreeContext>;
                }
                else
                {
                    var btNode = node.Build();
                    this.node = new AivoTree.AlwaysNode<BTreeContext>(btNode, targetStatus);
                    return this.node as AivoTree.AlwaysNode<BTreeContext>;
                }
            }
            return null;
        }
    }
}