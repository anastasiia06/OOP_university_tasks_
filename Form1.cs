using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
namespace Final_test
{
    
    public partial class Form1 : Form
    {
        Pharmacy pharmacy;
        public Form1()
        {
            InitializeComponent();
            pharmacy = JsonHelper.LoadFromFile<Pharmacy>("pharmacy.json") ?? new Pharmacy();
            RefreshLists();
            this.FormClosing += Form1_FormClosing;
        }
        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMedicinePrice.Text, out decimal price))
            {
                Medicine med = new Medicine(txtMedicineName.Text, price);
                pharmacy.AddMedicine(med);
                RefreshLists();
            }
            else
            {
                MessageBox.Show("Введіть правильну ціну!");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(txtCustomerLastName.Text);
            pharmacy.AddCustomer(customer);
            RefreshLists();
            lstCustomers.SelectedItem = customer;
        }

        private void btnAddPurchase_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem is Customer customer && lstMedicines.SelectedItem is Medicine med)
            {
                customer.AddPurchase(med);
                RefreshLists();
                lstCustomers.SelectedItem = customer;
            }
            else
            {
                MessageBox.Show("Оберіть клієнта та ліки!");
            }
        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem is Customer selectedCustomer)
                lblCustomerTotal.Text = $"Customer Total: {selectedCustomer.TotalSpent():C}";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "pharmacy.json");
            JsonHelper.SaveToFile(pharmacy, path);
            MessageBox.Show($"JSON збережено тут: {path}");

        }

        private void RefreshLists()
        {
            var selectedCustomer = lstCustomers.SelectedItem as Customer;

            lstMedicines.DataSource = null;
            lstMedicines.DataSource = pharmacy.Medicines;

            lstCustomers.DataSource = null;
            lstCustomers.DataSource = pharmacy.Customers;

            // Відновлюємо виділення, якщо клієнт все ще є у списку
            if (selectedCustomer != null && pharmacy.Customers.Contains(selectedCustomer))
                lstCustomers.SelectedItem = selectedCustomer;
            else if (pharmacy.Customers.Count > 0)
                lstCustomers.SelectedIndex = 0; // виділяємо першого, якщо список не пустий

            // Оновлюємо підсумки
            lblTotalRevenue.Text = $"Total Revenue: {pharmacy.GetTotalRevenue():C}";
            if (lstCustomers.SelectedItem is Customer c)
                lblCustomerTotal.Text = $"Customer Total: {c.TotalSpent():C}";
            else
                lblCustomerTotal.Text = $"Customer Total: 0";
        }
    }
    public class Medicine
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Medicine() { }

        public Medicine(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString() => $"{Name} - {Price:C}";
    }

    public class Customer
    {
        public string LastName { get; set; }
        public List<Medicine> Purchases { get; set; } = new List<Medicine>();

        public Customer() { }

        public Customer(string lastName)
        {
            LastName = lastName;
        }

        public void AddPurchase(Medicine medicine)
        {
            Purchases.Add(medicine);
        }

        public decimal TotalSpent()
        {
            return Purchases.Sum(m => m.Price);
        }

        public override string ToString() => $"{LastName} - Total Spent: {TotalSpent():C}";
    }

    public interface IStore
    {
        void AddMedicine(Medicine medicine);
        void AddCustomer(Customer customer);
        decimal GetTotalRevenue();
        Customer GetCustomerByLastName(string lastName);
    }

    public class Pharmacy : IStore, IEnumerable<Customer>
    {
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public void AddMedicine(Medicine medicine) => Medicines.Add(medicine);

        public void AddCustomer(Customer customer) => Customers.Add(customer);

        public decimal GetTotalRevenue() => Customers.Sum(c => c.TotalSpent());

        public Customer GetCustomerByLastName(string lastName) =>
            Customers.FirstOrDefault(c => c.LastName == lastName);
        public IEnumerator<Customer> GetEnumerator() => Customers.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class JsonHelper
    {
        public static void SaveToFile<T>(T obj, string filename)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        public static T LoadFromFile<T>(string filename)
        {
            if (!File.Exists(filename)) return default(T);
            var json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

