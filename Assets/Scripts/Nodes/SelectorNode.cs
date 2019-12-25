using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class SelectorNode : BTreeNode
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

            List<AivoTree.TreeNode<BTreeContext>> nodes = new List<AivoTree.TreeNode<BTreeContext>>();

            int connectionCount = outputPort.ConnectionCount;
            for (int i = 0; i < connectionCount; i++)
            {
                NodePort connectedPort = outputPort.GetConnection(i);
                BTreeNode connectedNode = connectedPort.node as BTreeNode;

                if (connectedNode)
                {
                    var btNode = connectedNode.Build();
                    nodes.Add(btNode);
                }
            }

            if (nodes.Count > 0)
            {
                if (this.node != null)
                {
                    return this.node as AivoTree.SequenceNode<BTreeContext>;
                }
                else
                {
                    this.node = new AivoTree.SequenceNode<BTreeContext>(nodes.ToArray());
                    return this.node as AivoTree.SequenceNode<BTreeContext>;
                }
            }
            return null;
        }
    }
}