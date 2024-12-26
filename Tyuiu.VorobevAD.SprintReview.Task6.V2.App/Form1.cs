using Tyuiu.VorobevAD.SprintReview.Task6.V2.Lib;

using System.Drawing.Drawing2D;

namespace Tyuiu.VorobevAD.SprintReview.Task6.V2.App
{
    public partial class MainForm : Form
    {
        DataService ds = new DataService();

        private int[,] matrix;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void GenButton_VAD_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TextBoxIntN_VAD.Text, out int N) || N <= 0 ||
                !int.TryParse(TextBoxIntM_VAD.Text, out int M) || M <= 0 ||
                !int.TryParse(TextBoxIntn1_VAD.Text, out int n1) ||
                !int.TryParse(TextBoxIntn2_VAD.Text, out int n2) || n1 >= n2)
            {
                MessageBox.Show("Тяжелый случай... попробуйте еще раз.");
                return;
            }
            matrix = new int[N, M];
            matrix = ds.RandMatrix(matrix, n1, n2);

            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            DataGridArray_VAD.ColumnCount = columns;
            DataGridArray_VAD.RowCount = rows;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    DataGridArray_VAD.Rows[i].Cells[j].Value = matrix[i, j].ToString();
            }

            DataGridArray_VAD.AllowUserToResizeRows = false;
            DataGridArray_VAD.AllowUserToResizeColumns = false;

            foreach (DataGridViewColumn column in DataGridArray_VAD.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridArray_VAD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

       

        private void CalcAMButton_VAD_Click(object sender, EventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Для начала сгенерируйте матрицу...");
                return;
            }

            if (!int.TryParse(TextBoxIntC_VAD.Text, out int c) || c < 0 || c >= matrix.GetLength(0) ||
                !int.TryParse(TextBoxIntK_VAD.Text, out int k) || k < 0 ||
                !int.TryParse(TextBoxIntL_VAD.Text, out int l) || l < k || l >= matrix.GetLength(1))
            {
                MessageBox.Show("Серьезно...? Давай по новой.");
                return;
            }

            double p = ds.GetMatrix(matrix, k, l, c);

            ResultTextBox_VAD.Text = p.ToString();

        }
    }
}
