namespace FactoryMethodWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DocumentCreator creator;

            if (radioWord.Checked)
                creator = new WordCreator();
            else if (radioPdf.Checked)
                creator = new PdfCreator();
            else
                creator = new ExcelCreator();

            IDocument doc = creator.CreateDocument(txtTitle.Text);

            lblResult.Text = $"Створено документ: {doc.GetInfo()}";
            doc.Export();
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
    public interface IDocument
    {
        string Title { get; set; }
        string GetInfo();
        void Export();
    }
    public class WordDocument : IDocument
    {
        public string Title { get; set; }
        public string GetInfo() => $"Word документ '{Title}'";
        public void Export() =>
            MessageBox.Show($"'{Title}.docx' успішно збережено!", "Word Export");
    }

    public class PdfDocument : IDocument
    {
        public string Title { get; set; }
        public string GetInfo() => $"PDF документ '{Title}'";
        public void Export() =>
            MessageBox.Show($"'{Title}.pdf' збережено як PDF!", "PDF Export");
    }
    public class ExcelDocument : IDocument
    {
        public string Title { get; set; }
        public string GetInfo() => $"Excel таблиця '{Title}'";
        public void Export() =>
            MessageBox.Show($"'{Title}.xlsx' збережено!", "Excel Export");
    }
    public abstract class DocumentCreator
    {
        public abstract IDocument CreateDocument(string title);
    }
    public class WordCreator : DocumentCreator
    {
        public override IDocument CreateDocument(string title) =>
            new WordDocument { Title = title };
    }

    public class PdfCreator : DocumentCreator
    {
        public override IDocument CreateDocument(string title) =>
           new PdfDocument { Title = title };
    }
    public class ExcelCreator : DocumentCreator
    {
        public override IDocument CreateDocument(string title) =>
            new ExcelDocument { Title = title };
    }
}
