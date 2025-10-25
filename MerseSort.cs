using System.Diagnostics;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        int[] array;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int K = 23;
            int N = (int)(20 + 0.6 * K);
            array = new int[N];
            for (int i = 0; i < N; i++)
                array[i] = rnd.Next(10, 101);

            listBox1.Items.Clear();
            foreach (var num in array)
                listBox1.Items.Add(num);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            array = MergeSort(array);

            listBox1.Items.Clear();
            foreach (var num in array)
                listBox1.Items.Add(num);
        }
        private int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;

            int mid = arr.Length / 2;
            int[] left = MergeSort(arr.Take(mid).ToArray());
            int[] right = MergeSort(arr.Skip(mid).ToArray());

            return Merge(left, right);
        }
        private int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
                result[k++] = (left[i] < right[j]) ? left[i++] : right[j++];

            while (i < left.Length) result[k++] = left[i++];
            while (j < right.Length) result[k++] = right[j++];
            return result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (array == null) return;

            if (!int.TryParse(txtKey.Text, out int key))
            {
                MessageBox.Show("Введіть коректне число!");
                return;
            }

            int count = CountValues(array, key);
            lblResult.Text = $"Значення {key} зустрічається {count} рази";
        }
        private int CountValues(int[] arr, int key)
        {
            int index = BinarySearch(arr, key);
            if (index == -1) return 0;

            int count = 1;
            int left = index - 1;
            while (left >= 0 && arr[left--] == key) count++;

            int right = index + 1;
            while (right < arr.Length && arr[right++] == key) count++;

            return count;
        }
        private int BinarySearch(int[] arr, int key)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == key) return mid;
                else if (arr[mid] < key) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }

        private void btnLinearSearch_Click(object sender, EventArgs e)
        {
            if (array == null) return;

            if (!int.TryParse(txtKey.Text, out int key))
            {
                MessageBox.Show("Введіть коректне число!");
                return;
            }

        
            int count = LinearSearch(array, key); 
            lblResult.Text = $"Значення {key} зустрічається {count} рази";
          
        }
        private int LinearSearch(int[] arr, int key)
        {
            int count = 0; 
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                    count++;
            }
            return count;
        }

    }
}
