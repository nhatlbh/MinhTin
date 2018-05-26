using System.Collections.Generic;

namespace TnHSell.DTContract
{
    public class KendoTreeNode
    {
        public KendoTreeNode()
        {
            items = new List<KendoTreeNode>();
        }
        public int id { get; set; }
        public string text { get; set; }
        public string expanded { get; set; }
        public string spriteCssClass { get; set; }
        public List<KendoTreeNode> items { get; set; }
    }
}
