using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using BTree;
using XNodeEditor;
using XNode;

namespace BTreeEditor
{
    [CustomNodeGraphEditor(typeof(BTreeGraph))]
    public class BTreeGraphEditor : NodeGraphEditor
    {
        /// <summary> 
        /// Overriding GetNodeMenuName lets you control if and how nodes are categorized.
        /// </summary>
        public override string GetNodeMenuName(System.Type type)
        {
            if (type.Namespace == "BTree")
            {
                return base.GetNodeMenuName(type).Replace("BTree/BTree Graph/", "");
            }
            else return null;
        }

        public override void OnGUI()
        {
            // Repaint each frame
            window.Repaint();
            DrawConnectionNumber();
        }

        private struct SortData
        {
            public Vector2 connectionCoords;
            public BTreeNode node;

            public SortData(Vector2 coords, BTreeNode node)
            {
                connectionCoords = coords;
                this.node = node;
            }
        }

        public void DrawConnectionNumber()
        {
            Color col = GUI.color;

            var tmpStyle = new GUIStyle();
            tmpStyle.alignment = TextAnchor.MiddleRight;
            tmpStyle.fontStyle = FontStyle.Bold;
            tmpStyle.normal.textColor = Color.white;

            foreach (Node node in target.nodes)
            {
                if (node == null) continue;

                foreach (NodePort output in node.Outputs)
                {
                    List<SortData> connections = new List<SortData>();
                    for (int k = 0; k < output.ConnectionCount; k++)
                    {
                        NodePort input = output.GetConnection(k);
                        BTreeNode connectedNode = input.node as BTreeNode;
                        Rect toRect;
                        if (!window.portConnectionPoints.TryGetValue(input, out toRect)) continue;

                        Vector2 point = window.GridToWindowPosition(toRect.min);
                        point.x -= 10;
                        connections.Add(new SortData(point, connectedNode));
                    }
                    connections.Sort((d1, d2) => d1.connectionCoords.y < d2.connectionCoords.y ? -1 : 1);
                    for (int k = 0; k < connections.Count; k++)
                    {
                        Handles.Label(connections[k].connectionCoords, (k + 1).ToString(), tmpStyle);
                        connections[k].node.SetNumber(k);
                    }
                }
            }
            GUI.color = col;
        }
    }
}
