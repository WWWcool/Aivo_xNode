using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AivoTree;

namespace BTree
{
    public class SimpleAIAgent : MonoBehaviour
    {
        [SerializeField] private BTreeGraph m_graph = null;
        [SerializeField] private float m_stepTime = 1;
        private TreeNode<BTreeContext> m_root = null;
        private BTreeContext m_context;
        private float m_timePassed = 0;

        void Start()
        {
            if (m_graph != null)
            {
                m_root = m_graph.Build();
                m_context = new BTreeContext();
            }
        }

        void Update()
        {
            if (m_root != null)
            {
                m_timePassed -= Time.deltaTime;
                if (m_timePassed <= 0)
                {
                    m_timePassed = m_stepTime;
                    m_root.Tick((long)m_timePassed * 1000, m_context);
                }
            }
        }
    }
}
