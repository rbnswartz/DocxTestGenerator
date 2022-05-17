using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;

namespace DocxTestGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files (*.docx)|*.docx";
            openFileDialog.ShowDialog();
            using (var doc = WordprocessingDocument.Open(openFileDialog.FileName, true))
            {
                documentTree.Nodes.Clear();
                documentTree.Nodes.AddRange(CreateTreeNodes(doc).ToArray());

            }
        }
        private List<TreeNode> CreateTreeNodes(WordprocessingDocument doc)
        {
            var output = new List<TreeNode>();
            if (doc.MainDocumentPart != null)
            {
                var documentNode = new TreeNode("document");
                foreach (var node in doc.MainDocumentPart.Document.ChildElements)
                {
                    documentNode.Nodes.Add(ConvertToTreeNode(node, 0));
                }
                output.Add(documentNode);
            }
            return output;
        }

        private TreeNode ConvertToTreeNode(OpenXmlElement input, int occurenceNumber)
        {
            var nodeCount = new Dictionary<string, int>();
            var output = new TreeNode
            {
                Tag = input,
                Text = occurenceNumber == 0 ? input.LocalName : $"{input.LocalName}[{occurenceNumber}]"
            };
            foreach (var element in input.ChildElements)
            {
                if (nodeCount.ContainsKey(element.LocalName))
                {
                    nodeCount[element.LocalName]++;
                }
                else
                {
                    nodeCount.Add(element.LocalName, 0);
                }
                output.Nodes.Add(ConvertToTreeNode(element, nodeCount[element.LocalName]));
            }
            return output;
        }

        private void documentTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node == null)
            {
                return;
            }
            var element = node.Tag as OpenXmlElement;
            if (element != null)
            {
                lblPath.Text = node.FullPath.Replace("\\", "/");
                lblXml.Text = element.OuterXml;
            }
        }
    }
}