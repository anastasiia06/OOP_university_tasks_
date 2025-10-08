namespace BridgePatternExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboShape.Items.AddRange(new string[] { "Круг", "Квадрат" });
            comboColor.Items.AddRange(new string[] { "Червоний", "Синій", "Зелений" });

            comboShape.SelectedIndex = 0;
            comboColor.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            IColor color;
            switch (comboColor.SelectedItem.ToString())
            {
                case "Червоний":
                    color = new RedColor();
                    break;
                case "Синій":
                    color = new BlueColor();
                    break;
                default:
                    color = new GreenColor();
                    break;
            }
            Shape shape;
            if (comboShape.SelectedItem.ToString() == "Круг")
                shape = new Circle(color);
            else
                shape = new Square(color);

            lblResult.Text = shape.Draw();
        }
    }
    public interface IColor
    {
        string ApplyColor();
    }
    public class RedColor : IColor
    {
        public string ApplyColor() => "червоний";
    }

    public class BlueColor : IColor
    {
        public string ApplyColor() => "синій";
    }
    public class GreenColor : IColor
    {
        public string ApplyColor() => "зелений";
    }
    public abstract class Shape
    {
        protected IColor color;
        public Shape(IColor color) => this.color = color;
        public abstract string Draw();
    }
    public class Circle : Shape
    {
        public Circle(IColor color) : base(color) { }
        public override string Draw() => $"Результат: {color.ApplyColor()} круг";
    }
    public class Square : Shape
    {
        public Square(IColor color) : base(color) { }
        public override string Draw() => $"Результат: {color.ApplyColor()} квадрат";
    }
    

}
