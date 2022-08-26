using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
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
                var footNoteNode = new TreeNode("footnotes");
                foreach (var node in doc.MainDocumentPart.FootnotesPart.Footnotes.ChildElements)
                {
                    footNoteNode.Nodes.Add(ConvertToTreeNode(node, 0));
                }
                output.Add(footNoteNode);
                var settingsNode = new TreeNode("settings");
                foreach (var node in doc.MainDocumentPart.DocumentSettingsPart.Settings.ChildElements)
                {
                    settingsNode.Nodes.Add(ConvertToTreeNode(node, 0));
                }
                output.Add(settingsNode);
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
                lstAttributes.Items.Clear();
                lstAttributes.SelectedIndex = -1;
                SetPathAndValue();
                foreach(var attribute in element.GetAttributes())
                {
                    lstAttributes.Items.Add(attribute.LocalName);
                }
                if (!string.IsNullOrEmpty(element.InnerText))
                {
                    lstAttributes.Items.Add("InnerText");
                }                    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var (path, value) = GetPathAndValue();
            Clipboard.SetDataObject($"{path}\t{value}");
        }

        private (string path, string? value) GetPathAndValue()
        {
            var selectedNOde = documentTree.SelectedNode;
            var path = documentTree.SelectedNode.FullPath.Replace("\\", "/");
            var value = "";
            if (selectedNOde.Tag is DocumentFormat.OpenXml.Wordprocessing.Text)
            {
                value = (selectedNOde.Tag as DocumentFormat.OpenXml.Wordprocessing.Text).InnerText;
            }
            if (lstAttributes.SelectedIndex >= 0)
            {
                if (lstAttributes.SelectedItem.ToString() == "InnerText")
                {
                    value = (selectedNOde.Tag as OpenXmlElement)?.InnerText;
                }
                else
                {
                    path += $".{lstAttributes.SelectedItem}";
                    value = ((OpenXmlElement)selectedNOde.Tag).GetAttributes().FirstOrDefault(x => x.LocalName == lstAttributes.SelectedItem.ToString()).Value;
                }
            }
            return (path, value);
        }

        private void b_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lstAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPathAndValue();
        }
        private void SetPathAndValue()
        {
            if (lstAttributes.SelectedIndex == -1)
            {
                lblPath.Text = "";
                lblValue.Text = "";
                return;
            }
            var (path, value) = GetPathAndValue();
            lblPath.Text = path;
            lblValue.Text = value ?? "";
        }
    }
}