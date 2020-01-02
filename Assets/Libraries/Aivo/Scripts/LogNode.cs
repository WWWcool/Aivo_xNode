using UnityEngine;

namespace AivoTree
{
    public class LogNode<T> : TreeNode<T>
    {
        private readonly bool needLog;
        private readonly string logMsg = "";
        private readonly AivoTreeStatus targetStatus;

        public LogNode(bool needLog, string logMsg = "node tick", AivoTreeStatus targetStatus = AivoTreeStatus.Success)
        {
            this.needLog = needLog;
            this.logMsg = logMsg;
            this.targetStatus = targetStatus;
        }

        public AivoTreeStatus Tick(long timeTick, T context)
        {
            Debug.Log("[LogNode][Tick] " + logMsg);
            return targetStatus;
        }
    }
}