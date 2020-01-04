using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class SequenceNode : BTreeNode
    {
        [Output] public AivoTreeStatus output;

        public override AivoTree.TreeNode<BTreeContext> Build()
        {
            if (this.node != null)
            {
                return this.node as AivoTree.SequenceNode<BTreeContext>;
            }
            else
            {
                NodePort outputPort = GetOutputPort("output");

                if (!outputPort.IsConnected)
                {
                    Debug.LogWarning("Node isn't connected");
                    return null;
                }

                List<BTreeNode> nodes = new List<BTreeNode>();

                int connectionCount = outputPort.ConnectionCount;
                for (int i = 0; i < connectionCount; i++)
                {
                    NodePort connectedPort = outputPort.GetConnection(i);
                    BTreeNode connectedNode = connectedPort.node as BTreeNode;

                    if (connectedNode)
                    {
                        nodes.Add(connectedNode);
                    }
                }
                if (nodes.Count > 0)
                {
                    nodes.Sort(SortConnections);
                    this.node = new AivoTree.SequenceNode<BTreeContext>(nodes.ConvertAll(node => node.Build()).ToArray());
                    return this.node as AivoTree.SequenceNode<BTreeContext>;
                }
            }
            return null;
        }
    }
}