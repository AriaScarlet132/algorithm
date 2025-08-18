using System;
using System.Text;
using System.Collections.Generic;

namespace Rcbi.Framework.Helper
{
    public class LayuiTreeNode
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string Name { get; set; }

        public List<LayuiTreeNode> Children { get; set; }

        public LayuiTreeNode(string id, string name, string parentId)
        {
            this.Id = id;
            this.Name = name;
            this.ParentId = parentId;
        }
        public LayuiTreeNode(string id, string name, LayuiTreeNode parent)
        {
            this.Id = id;
            this.ParentId = parent.Id;
            this.Name = name;
        }

        public override string ToString()
        {
            var json = "{\"id\":\"" + this.Id + "\",\"name\":\"" + this.Name + "\",\"open\":true";
            if (this.Children != null && this.Children.Count > 0)
            {
                json += ",\"children\":[";
                for (var i = 0; i < this.Children.Count; i++) {
                    json += this.Children[i];
                    if (i < this.Children.Count - 1)
                        json += ",";
                }
                json += "]";
            }
            json += "}";

            return json;
        }
    }

    public class LayuiTreeBuilder
    {
        public static string BuildJson(List<LayuiTreeNode> treeNodes)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for (var i = 0; i < treeNodes.Count; i++) {
                sb.Append(treeNodes[i].ToString());
                if (i < treeNodes.Count - 1)
                    sb.Append(",");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static List<LayuiTreeNode> BuildByRecursive(List<LayuiTreeNode> treeNodes)
        {
            List<LayuiTreeNode> trees = new List<LayuiTreeNode>();
            foreach (var treeNode in treeNodes)
            {
                if (string.IsNullOrEmpty(treeNode.ParentId))
                {
                    trees.Add(FindChildren(treeNode, treeNodes));
                }
            }
            return trees;
        }

        public static LayuiTreeNode FindChildren(LayuiTreeNode treeNode, List<LayuiTreeNode> treeNodes)
        {
            foreach (var it in treeNodes)
            {
                if (treeNode.Id == it.ParentId)
                {
                    if (treeNode.Children == null)
                    {
                        treeNode.Children = new List<LayuiTreeNode>();
                    }
                    treeNode.Children.Add(FindChildren(it, treeNodes));
                }
            }
            return treeNode;
        }
    }
}
