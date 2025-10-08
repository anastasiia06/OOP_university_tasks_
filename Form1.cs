namespace ChainOfResponsibilityWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string request = txtRequest.Text;

            if (string.IsNullOrWhiteSpace(request))
            {
                lblResponse.Text = "Введіть повідомлення!";
                return;
            }
            SupportHandler tech = new TechSupport();
            SupportHandler finance = new FinanceSupport();
            SupportHandler manager = new ManagerSupport();

            tech.SetNext(finance);
            finance.SetNext(manager);
            lblResponse.Text = tech.Handle(request);
        }
    }
    public abstract class SupportHandler
    {
        protected SupportHandler next;

        public void SetNext(SupportHandler nextHandler)
        {
            next = nextHandler;
        }
        public abstract string Handle(string request);
    }
    public class TechSupport : SupportHandler
    {
        public override string Handle(string request)
        {
            if (request.ToLower().Contains("техніка"))
                return "Технічна підтримка відповіла на ваше питання.";
            else if (next != null)
                return next.Handle(request);
            else
                return "Поки що, в нас немає відповіді, але ми розглянемо ваше питання.";
        }
    }

    public class FinanceSupport : SupportHandler
    {
        public override string Handle(string request)
        {
            if (request.ToLower().Contains("оплата") || request.ToLower().Contains("рахунок"))
                return "Фінансова підтримка відповіла на ваше питання.";
            else if (next != null)
                return next.Handle(request);
            else
                return "Поки що, в нас немає відповіді, але ми розглянемо ваше питання.";
        }
    }
    public class ManagerSupport : SupportHandler
    {
        public override string Handle(string request)
        {
            return "Поки що, в нас немає відповіді, але ми розглянемо ваше питання.";
        }
    }
}
