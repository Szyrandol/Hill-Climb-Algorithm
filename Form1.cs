namespace HillClimbAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            aTextBox.Text = "-4";
            bTextBox.Text = "12";
            dComboBox.SelectedIndex = 2;
            tTextBox.Text = "10";
        }

        int a;
        int b;
        double d;
        int l;
        int t;
        private void StartButton_Click(object sender, EventArgs e)
        {
            this.wykres.Plot.Clear();
            this.tabela.Rows.Clear();
            a = int.Parse(aTextBox.Text);
            b = int.Parse(bTextBox.Text);
            d = double.Parse(dComboBox.Text);//Convert.ToDouble(dComboBox.Text);
            l = (int)Math.Ceiling(Math.Log((b - a) / d + 1, 2));
            t = int.Parse(tTextBox.Text);

            Generation[] generation = new Generation[t];
            double best = 0;
            Specimen bestSpecimen = new Specimen(a, b, l, d, 0);
            double[] dataX = new double[t];
            double[] dataBest = new double[t];
            //double[] dataY = new double[t];
            for (int i = 0; i < t; ++i)
            {
                generation[i] = new Generation(a, b, l, d, i);
                dataX[i] = i + 1;
                if (generation[i].best > best)
                {
                    best = generation[i].best;
                    bestSpecimen = generation[i].bestSpecimen;
                }
                dataBest[i] = best;
                this.tabela.Rows.Add(i + 1, generation[i].bestSpecimen.xReal2, generation[i].bestSpecimen.xBin, generation[i].bestSpecimen.y);
            }
            wynikTextBox.Text = "xreal = " + bestSpecimen.xReal2 + ",   xbin = " + bestSpecimen.xBin + ",   f(x) = " + bestSpecimen.y;
            this.wykres.Plot.AddScatter(dataX, dataBest, label: "Best");
            for (int i = 0; i < t; ++i)
            {
                this.wykres.Plot.AddScatter(generation[i].indeces, generation[i].yMax);
            }
            this.wykres.Plot.Legend();
            this.wykres.Plot.AxisAuto();
            this.wykres.Plot.SetAxisLimitsY(-2.1, 2.1, 0);
            this.wykres.Refresh();
        }
    }
}