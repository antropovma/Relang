using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Relang
{
    public static class DirectoryTreeView
    {
        /// <summary>
        /// Returns nodes collection of directories.
        /// </summary>
        /// <param name="rootDirectory">Directory name where the search begins.</param>
        /// <param name="targetFolder">Folder name for the search.</param>
        /// <returns></returns>
        public static TreeNode Load(string rootDirectory, string targetFolder)
        {
            var targetList = GetTargetDirectories(rootDirectory, targetFolder);
            return DetectNodes(targetList, rootDirectory, targetFolder);
        }

        private static List<string> GetTargetDirectories(string rootDirectory, string targetFolder)
        {
            List<string> folderList = new List<string>();
            if (Directory.Exists(rootDirectory))
                folderList = Directory.GetDirectories(rootDirectory, targetFolder, SearchOption.AllDirectories).ToList();
            return folderList;
        }

        private static TreeNode DetectNodes(List<string> targetFolders, string rootDirectory, string targetFolder)
        {
            var pathSeparator = '\\';
            string rootFolder = rootDirectory.Split('\\').Last();
            string prefixDir = rootDirectory.Replace(rootFolder, "");
            TreeNode lastNode = null;
            TreeNode allNodes = new TreeNode();
            foreach (string path in targetFolders)
            {
                var dir = path.Replace(prefixDir, "").Replace(targetFolder, "").TrimEnd(pathSeparator);
                var subPathAgg = string.Empty;
                foreach (string subPath in dir.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = allNodes.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                    {
                        lastNode = lastNode == null ? allNodes.Nodes.Add(subPathAgg, subPath) : lastNode.Nodes.Add(subPathAgg, subPath);
                        lastNode.ForeColor = Color.LightGray;
                    }
                    else
                        lastNode = nodes[0];
                }
                if (lastNode != null)
                {
                    lastNode.ForeColor = Color.Black;
                    lastNode.Tag = path;
                    lastNode.ToolTipText = path;
                }
            }
            if (allNodes.Nodes.Count > 0)
                return allNodes.Nodes[0];
            else
                return allNodes;
        }
    }
}
