using System;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class InverterNode : BTreeNode
    {
        [Output] public AivoTreeStatus output;

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
                    return this.node as AivoTree.InverterNode<BTreeContext>;
                }
                else
                {
                    var btNode = node.Build();
                    this.node = new AivoTree.InverterNode<BTreeContext>(btNode);
                    return this.node as AivoTree.InverterNode<BTreeContext>;
                }
            }
            return null;
        }
    }
}