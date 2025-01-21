using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MatStatProg2
{
    public partial class Form1 : Form
    {
        private List<CheckBox> vectorCheckBoxes;
        private List<CheckBox> savedVectorCheckBoxes; // Чекбокси для збережених векторів
        private List<List<double>> loadedVectors; // Завантажені вектори з файлу
        private List<List<double>> savedVectors;  // Збережені вектори

        public Form1()
        {
            InitializeComponent();

            loadedVectors = new List<List<double>>();
            savedVectors = new List<List<double>>();
            vectorCheckBoxes = new List<CheckBox>();
            savedVectorCheckBoxes = new List<CheckBox>();
        }

        private async void відкритиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                if (File.Exists(fileName))
                {
                    ProcessFileV(fileName);
                }
                else
                {
                    MessageBox.Show("Вибраний файл не існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProcessFileV(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);

                panelSave.Controls.Clear();
                vectorCheckBoxes.Clear();
                loadedVectors.Clear();

                if (lines.Length == 0) return;

                textBoxData.Text = string.Join(Environment.NewLine, lines);

                int columnCount = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

                // Ініціалізуємо списки для кожного вектора
                for (int i = 0; i < columnCount; i++)
                {
                    loadedVectors.Add(new List<double>());
                }

                foreach (string line in lines)
                {
                    string[] vectorData = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (vectorData.Length == columnCount)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            loadedVectors[i].Add(double.Parse(vectorData[i], CultureInfo.InvariantCulture));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Рядок містить некоректну кількість значень.", "Помилка у файлі", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Додаємо чекбокси для кожного вектора
                for (int i = 0; i < loadedVectors.Count; i++)
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Text = $"V{i + 1}",
                        Location = new Point(10, i * 30),
                        AutoSize = true
                    };
                    panelSave.Controls.Add(checkBox);
                    vectorCheckBoxes.Add(checkBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка обробки файлу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            List<int> selectedIndices = new List<int>();
            for (int i = 0; i < vectorCheckBoxes.Count; i++)
            {
                if (vectorCheckBoxes[i].Checked)
                {
                    selectedIndices.Add(i);
                }
            }

            if (selectedIndices.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть хоча б один вектор.", "Не вибрано вектор", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            panelDelete.Controls.Clear();
            savedVectorCheckBoxes.Clear();

            foreach (int index in selectedIndices)
            {
                List<double> vector = loadedVectors[index];
                savedVectors.Add(vector);

                string vectorName = $"Vector_{savedVectors.Count}";

                CheckBox savedCheckBox = new CheckBox
                {
                    Text = vectorName,
                    Location = new Point(10, 30 * (savedVectors.Count - 1)),
                    AutoSize = true,
                    Tag = savedVectors.Count - 1
                };

                panel2.Controls.Add(savedCheckBox);
                savedVectorCheckBoxes.Add(savedCheckBox);

                CheckBox deleteCheckBox = new CheckBox
                {
                    Text = vectorName,
                    Location = new Point(10, 30 * (savedVectorCheckBoxes.Count - 1)),
                    AutoSize = true,
                    Tag = savedVectors.Count - 1
                };

                panelDelete.Controls.Add(deleteCheckBox);
            }

            MessageBox.Show("Вибрані вектори успішно збережено та додано до панелі.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Отримуємо список чекбоксів, які вибрані в panelDelete
            List<CheckBox> selectedCheckBoxes = panelDelete.Controls
                .OfType<CheckBox>()
                .Where(cb => cb.Checked)
                .ToList();

            if (selectedCheckBoxes.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть хоча б один вектор для видалення.", "Не вибрано вектор", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Видаляємо вибрані вектори
            foreach (CheckBox checkBox in selectedCheckBoxes)
            {
                int vectorIndex = (int)checkBox.Tag; // Отримуємо індекс вектора із Tag чекбокса

                // Видаляємо вектор із savedVectors
                if (vectorIndex >= 0 && vectorIndex < savedVectors.Count)
                {
                    savedVectors.RemoveAt(vectorIndex);
                }

                // Видаляємо чекбокс з panelDelete
                panelDelete.Controls.Remove(checkBox);
            }

            // Оновлюємо чекбокси у panelDelete після видалення
            RebuildDeletePanel();

            MessageBox.Show("Вибрані вектори успішно видалені.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Метод для оновлення panelDelete після видалення
        private void RebuildDeletePanel()
        {
            panelDelete.Controls.Clear();

            for (int i = 0; i < savedVectors.Count; i++)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = $"Vector_{i + 1}",
                    Location = new Point(10, i * 30),
                    AutoSize = true,
                    Tag = i // Прив'язуємо новий індекс вектора
                };

                panelDelete.Controls.Add(checkBox);
            }
        }

        private void buttonWork_Click(object sender, EventArgs e)
        {
            textBoxXdata.Clear();
            textBoxYdata.Clear();
            dataGridView1.Rows.Clear();
           
            if (savedVectors.Count < 2)
            {
                MessageBox.Show("Потрібно хоча б два збережені вектори для роботи.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перетворення збережених векторів на X та Y
            List<double> vectorX = savedVectors[0];
            List<double> vectorY = savedVectors[1];

            if (vectorX.Count != vectorY.Count)
            {
                MessageBox.Show("Вектори X та Y повинні бути однакового розміру.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Відтворення двовимірного варіаційного ряду в dataGridView1
            Create2DVariationTable(vectorX, vectorY);

            // Відображення оцінок для векторів X та Y
            DisplayResultsXdata(vectorX);
            DisplayResultsYdata(vectorY);

            // Побудова гістограм для X та Y
            DrawHistogramX(vectorX);
            DrawHistogramY(vectorY);
        }

        private void Create2DVariationTable(List<double> vectorX, List<double> vectorY)
        {
            // Визначення кількості класів (кількість розбиттів)
            int classCountX = (int)Math.Sqrt(vectorX.Count);
            int classCountY = (int)Math.Sqrt(vectorY.Count);

            // Мінімальні та максимальні значення для X та Y
            double minX = vectorX.Min();
            double maxX = vectorX.Max();
            double minY = vectorY.Min();
            double maxY = vectorY.Max();

            // Ширина інтервалів для X та Y
            double intervalX = (maxX - minX) / classCountX;
            double intervalY = (maxY - minY) / classCountY;

            // Ініціалізація таблиці для підрахунку n_ij
            int[,] frequencyTable = new int[classCountX, classCountY];

            // Підрахунок кількості точок у кожному інтервалі
            for (int i = 0; i < vectorX.Count; i++)
            {
                int indexX = (int)((vectorX[i] - minX) / intervalX);
                int indexY = (int)((vectorY[i] - minY) / intervalY);

                if (indexX == classCountX) indexX--; // Врахування граничних значень
                if (indexY == classCountY) indexY--;

                frequencyTable[indexX, indexY]++;
            }

            // Відображення результатів у dataGridView1
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            for (int j = 0; j < classCountY; j++)
            {
                dataGridView1.Columns.Add($"ClassY{j + 1}", $"Y{j + 1}");
            }

            for (int i = 0; i < classCountX; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = $"X{i + 1}";
                for (int j = 0; j < classCountY; j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = frequencyTable[i, j] });
                }
                dataGridView1.Rows.Add(row);
            }

            dataGridView1.RowHeadersWidth = 60;

            // Відображення відносних частот p_ij
            double totalPoints = vectorX.Count;
            for (int i = 0; i < classCountX; i++)
            {
                for (int j = 0; j < classCountY; j++)
                {
                    double relativeFrequency = frequencyTable[i, j] / totalPoints;
                    dataGridView1[j, i].Value += $"\n({relativeFrequency:F4})";
                }
            }

            MessageBox.Show("Двовимірний варіаційний ряд успішно створено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //побудова гістограми для X координат
        private void DrawHistogramX(List<double> numbers)
        {
            int N = numbers.Count;
            double min = numbers.Min();
            double max = numbers.Max();
            int numberOfBins = (int)Math.Sqrt(N);
            double binWidth = (max - min) / numberOfBins;

            Series series = new Series("Histogram");
            series.ChartType = SeriesChartType.Column;
            series["PointWidth"] = "1.0"; // Встановлюємо ширину стовпців на 100%

            for (int i = 0; i < numberOfBins; i++)
            {
                double binStart = min + i * binWidth;
                double binEnd = binStart + binWidth;
                int Nl;
                if (i == numberOfBins - 1)
                {
                    Nl = numbers.Count(x => x >= binStart && x <= binEnd);
                }
                else
                {
                    Nl = numbers.Count((x => x >= binStart && x < binEnd));
                }
                double Pi = (double)Nl / N;
                series.Points.AddXY($"{binStart:F4}-{binEnd:F4}", Pi); // Форматування до 4 знаків після коми
            }

            chartXhisto.Series.Clear();
            chartXhisto.Series.Add(series);

            // Налаштування формату міток осі X
            chartXhisto.ChartAreas[0].AxisX.LabelStyle.Format = "F4";



            chartXhisto.ChartAreas[0].AxisX.MajorGrid.Enabled = true; // 
            chartXhisto.ChartAreas[0].AxisY.MajorGrid.Enabled = true; //
        }
        //побудова гістограми для Y
        private void DrawHistogramY(List<double> numbers)
        {
            int N = numbers.Count;
            double min = numbers.Min();
            double max = numbers.Max();
            int numberOfBins = (int)Math.Sqrt(N);
            double binWidth = (max - min) / numberOfBins;

            Series series = new Series("Histogram");
            series.ChartType = SeriesChartType.Column;
            series["PointWidth"] = "1.0"; // Встановлюємо ширину стовпців на 100%

            for (int i = 0; i < numberOfBins; i++)
            {
                double binStart = min + i * binWidth;
                double binEnd = binStart + binWidth;
                int Nl;
                if (i == numberOfBins - 1)
                {
                    Nl = numbers.Count(x => x >= binStart && x <= binEnd);
                }
                else
                {
                    Nl = numbers.Count((x => x >= binStart && x < binEnd));
                }
                double Pi = (double)Nl / N;
                series.Points.AddXY($"{binStart:F4}-{binEnd:F4}", Pi); // Форматування до 4 знаків після коми
            }

            chartYhisto.Series.Clear();
            chartYhisto.Series.Add(series);

            // Налаштування формату міток осі X
            chartYhisto.ChartAreas[0].AxisX.LabelStyle.Format = "F4";



            chartYhisto.ChartAreas[0].AxisX.MajorGrid.Enabled = true; // 
            chartYhisto.ChartAreas[0].AxisY.MajorGrid.Enabled = true; //
        }
        private void DisplayResultsYdata(List<double> numbers)
        {
            if (numbers.Any())
            {
                int n = numbers.Count();

                double mean = numbers.Average(); // Середнє арифметичне
                double standardDeviation = CalculateUnbiasedStandardDeviation(numbers); // Стандартне відхилення
                double median = CalculateMedian(numbers); // Медіана
                double skewness = CalculateUnbiasedSkewness(numbers); // Коефіцієнт асиметрії
                double kurtosis = CalculateUnbiasedKurtosis(numbers); // Ексцес
                double counterKurtosis = CalculateCounterKurtosis(numbers); // Контрексцес
                double pearsonVariation = CalculatePearsonVariation(numbers); // Варіація Пірсона

                // Стандартна похибка середнього
                double seMean = CalculateStandardErrorOfMean(numbers, standardDeviation);
                // Формула: SE_mean = σ / √n

                // Стандартна похибка стандартного відхилення
                double seStandardDeviation = CalculateStandardErrorOfStandardDeviation(numbers, standardDeviation);
                // Формула: SE_σ = σ / √(2(n-1))

                // Стандартна похибка асиметрії
                double seSkewness = CalculateStandardErrorOfSkewness(numbers, skewness);
                // Формула: SE_skewness = √(6(n-2) / ((n+1)(n+3)))

                // Стандартна похибка ексцесу
                double seKurtosis = CalculateStandardErrorOfKurtosis(numbers, kurtosis);
                // Формула: SE_kurtosis = √(24n(n-2)(n-3) / ((n+1)²(n+3)(n+5)))

                // Стандартна похибка контрексцесу
                double seCounterKurtosis = CalculateStandardErrorOfCounterKurtosis(numbers, counterKurtosis);
                // Використовується та ж формула, що і для ексцесу: SE_counterKurtosis = √(24n(n-2)(n-3) / ((n+1)²(n+3)(n+5)))

                // Стандартна похибка варіації Пірсона
                double sePearsonVariation = CalculateStandardErrorOfPearsonVariation(numbers, pearsonVariation);
                // Формула: SE_pearsonVariation = var / √(2n)

                double confidenceLevel = 1.96; // 95% рівень довіри
                double ciMeanLower = mean - confidenceLevel * seMean;
                double ciMeanUpper = mean + confidenceLevel * seMean;
                double ciStandardDeviationLower = standardDeviation - confidenceLevel * seStandardDeviation;
                double ciStandardDeviationUpper = standardDeviation + confidenceLevel * seStandardDeviation;
                double ciSkewnessLower = skewness - confidenceLevel * seSkewness;
                double ciSkewnessUpper = skewness + confidenceLevel * seSkewness;
                double ciKurtosisLower = kurtosis - confidenceLevel * seKurtosis;
                double ciKurtosisUpper = kurtosis + confidenceLevel * seKurtosis;
                double ciCounterKurtosisLower = counterKurtosis - confidenceLevel * seCounterKurtosis;
                double ciCounterKurtosisUpper = counterKurtosis + confidenceLevel * seCounterKurtosis;
                double ciPearsonVariationLower = pearsonVariation - confidenceLevel * sePearsonVariation;
                double ciPearsonVariationUpper = pearsonVariation + confidenceLevel * sePearsonVariation;
                double trimmedMean = CalculateTrimmedMean(numbers); // Усічене середнє (5%)
                double rawMoment7thOrder = CalculateRawMoment7thOrder(numbers); // Початковий момент 7-го порядку
                double centralMoment7thOrder = CalculateCentralMoment7thOrder(numbers); // Центральний момент 7-го порядку


                textBoxYdata.AppendText($" (Y) Кількість спостережень:  {n}.\r\n");
                textBoxYdata.AppendText($"Середнє: {mean:F2}, 95% Дов.Iнт.: [{ciMeanLower:F2}, {ciMeanUpper:F2}]\r\n");
                textBoxYdata.AppendText($"Середньоквадратичне: {standardDeviation:F2}, 95% Дов.Iнт.: [{ciStandardDeviationLower:F2}, {ciStandardDeviationUpper:F2}]\r\n");
                textBoxYdata.AppendText($"Медіана: {median:F2}\r\n");
                textBoxYdata.AppendText($"Асиметрія: {skewness:F2}, 95% Дов.Iнт.: [{ciSkewnessLower:F2}, {ciSkewnessUpper:F2}]\r\n");
                textBoxYdata.AppendText($"Ексцес: {kurtosis:F2}, 95% Дов.Iнт.: [{ciKurtosisLower:F2}, {ciKurtosisUpper:F2}]\r\n");
                textBoxYdata.AppendText($"Контрексцес: {counterKurtosis:F2}, 95% Дов.Iнт.: [{ciCounterKurtosisLower:F2}, {ciCounterKurtosisUpper:F2}]\r\n");
                textBoxYdata.AppendText($"Варіація Пірсона: {pearsonVariation:F2}, 95% Дов.Iнт.: [{ciPearsonVariationLower:F2}, {ciPearsonVariationUpper:F2}]\r\n");
                textBoxYdata.AppendText($"Усічене середнє (5%): {trimmedMean:F2}\r\n");
                textBoxYdata.AppendText($"Початковий момент 7-го порядку: {rawMoment7thOrder:F2}\r\n");
                textBoxYdata.AppendText($"Центральний момент 7-го порядку: {centralMoment7thOrder:F2}\r\n");

                List<double> anomalies = FindAnomalies(numbers, mean, standardDeviation);
                textBoxYdata.AppendText("Аномалії:\r\n");
                foreach (double anomaly in anomalies)
                {
                    textBoxYdata.AppendText($"{anomaly:F2}\r\n");
                }
            }
        }
        //відтворення результатів
        private void DisplayResultsXdata(List<double> numbers)
        {
            if (numbers.Any())
            {
                int n = numbers.Count();

                double mean = numbers.Average(); // Середнє арифметичне
                double standardDeviation = CalculateUnbiasedStandardDeviation(numbers); // Стандартне відхилення
                double median = CalculateMedian(numbers); // Медіана
                double skewness = CalculateUnbiasedSkewness(numbers); // Коефіцієнт асиметрії
                double kurtosis = CalculateUnbiasedKurtosis(numbers); // Ексцес
                double counterKurtosis = CalculateCounterKurtosis(numbers); // Контрексцес
                double pearsonVariation = CalculatePearsonVariation(numbers); // Варіація Пірсона

                // Стандартна похибка середнього
                double seMean = CalculateStandardErrorOfMean(numbers, standardDeviation);
                // Формула: SE_mean = σ / √n

                // Стандартна похибка стандартного відхилення
                double seStandardDeviation = CalculateStandardErrorOfStandardDeviation(numbers, standardDeviation);
                // Формула: SE_σ = σ / √(2(n-1))

                // Стандартна похибка асиметрії
                double seSkewness = CalculateStandardErrorOfSkewness(numbers, skewness);
                // Формула: SE_skewness = √(6(n-2) / ((n+1)(n+3)))

                // Стандартна похибка ексцесу
                double seKurtosis = CalculateStandardErrorOfKurtosis(numbers, kurtosis);
                // Формула: SE_kurtosis = √(24n(n-2)(n-3) / ((n+1)²(n+3)(n+5)))

                // Стандартна похибка контрексцесу
                double seCounterKurtosis = CalculateStandardErrorOfCounterKurtosis(numbers, counterKurtosis);
                // Використовується та ж формула, що і для ексцесу: SE_counterKurtosis = √(24n(n-2)(n-3) / ((n+1)²(n+3)(n+5)))

                // Стандартна похибка варіації Пірсона
                double sePearsonVariation = CalculateStandardErrorOfPearsonVariation(numbers, pearsonVariation);
                // Формула: SE_pearsonVariation = var / √(2n)

                double confidenceLevel = 1.96; // 95% рівень довіри
                double ciMeanLower = mean - confidenceLevel * seMean;
                double ciMeanUpper = mean + confidenceLevel * seMean;
                double ciStandardDeviationLower = standardDeviation - confidenceLevel * seStandardDeviation;
                double ciStandardDeviationUpper = standardDeviation + confidenceLevel * seStandardDeviation;
                double ciSkewnessLower = skewness - confidenceLevel * seSkewness;
                double ciSkewnessUpper = skewness + confidenceLevel * seSkewness;
                double ciKurtosisLower = kurtosis - confidenceLevel * seKurtosis;
                double ciKurtosisUpper = kurtosis + confidenceLevel * seKurtosis;
                double ciCounterKurtosisLower = counterKurtosis - confidenceLevel * seCounterKurtosis;
                double ciCounterKurtosisUpper = counterKurtosis + confidenceLevel * seCounterKurtosis;
                double ciPearsonVariationLower = pearsonVariation - confidenceLevel * sePearsonVariation;
                double ciPearsonVariationUpper = pearsonVariation + confidenceLevel * sePearsonVariation;
                double trimmedMean = CalculateTrimmedMean(numbers); // Усічене середнє (5%)
                double rawMoment7thOrder = CalculateRawMoment7thOrder(numbers); // Початковий момент 7-го порядку
                double centralMoment7thOrder = CalculateCentralMoment7thOrder(numbers); // Центральний момент 7-го порядку


                textBoxXdata.AppendText($"  (X) Кількість спостережень:   {n}.\r\n");
                textBoxXdata.AppendText($"Середнє: {mean:F2}, 95% Дов.Iнт.: [{ciMeanLower:F2}, {ciMeanUpper:F2}]\r\n");
                textBoxXdata.AppendText($"Середньоквадратичне: {standardDeviation:F2}, 95% Дов.Iнт.: [{ciStandardDeviationLower:F2}, {ciStandardDeviationUpper:F2}]\r\n");
                textBoxXdata.AppendText($"Медіана: {median:F2}\r\n");
                textBoxXdata.AppendText($"Асиметрія: {skewness:F2}, 95% Дов.Iнт.: [{ciSkewnessLower:F2}, {ciSkewnessUpper:F2}]\r\n");
                textBoxXdata.AppendText($"Ексцес: {kurtosis:F2}, 95% Дов.Iнт.: [{ciKurtosisLower:F2}, {ciKurtosisUpper:F2}]\r\n");
                textBoxXdata.AppendText($"Контрексцес: {counterKurtosis:F2}, 95% Дов.Iнт.: [{ciCounterKurtosisLower:F2}, {ciCounterKurtosisUpper:F2}]\r\n");
                textBoxXdata.AppendText($"Варіація Пірсона: {pearsonVariation:F2}, 95% Дов.Iнт.: [{ciPearsonVariationLower:F2}, {ciPearsonVariationUpper:F2}]\r\n");
                textBoxXdata.AppendText($"Усічене середнє (5%): {trimmedMean:F2}\r\n");
                textBoxXdata.AppendText($"Початковий момент 7-го порядку: {rawMoment7thOrder:F2}\r\n");
                textBoxXdata.AppendText($"Центральний момент 7-го порядку: {centralMoment7thOrder:F2}\r\n");

                List<double> anomalies = FindAnomalies(numbers, mean, standardDeviation);
                textBoxXdata.AppendText("Аномалії:\r\n");
                foreach (double anomaly in anomalies)
                {
                    textBoxXdata.AppendText($"{anomaly:F2}\r\n");
                }
            }
        }

        //знаходження аномальних значень
        public List<double> FindAnomalies(List<double> numbers, double mean, double standardDeviation, double threshold = 3.0)
        {
            List<double> anomalies = new List<double>();
            foreach (double number in numbers)
            {
                if (Math.Abs(number - mean) > threshold * standardDeviation)
                {
                    anomalies.Add(number);
                }
            }
            return anomalies;
        }

        //підрахунок несміщеного стандартного відхилення 
        private double CalculateUnbiasedStandardDeviation(List<double> numbers)
        {
            double mean = numbers.Average();
            double sumOfSquares = numbers.Sum(num => Math.Pow(num - mean, 2));
            return Math.Sqrt(sumOfSquares / (numbers.Count - 1));
        }

        //медіана
        private double CalculateMedian(List<double> numbers)
        {
            List<double> sortedNumbers = new List<double>(numbers); // Копія списку
            sortedNumbers.Sort();
            int count = sortedNumbers.Count;
            if (count % 2 == 0)
            {
                return (sortedNumbers[count / 2 - 1] + sortedNumbers[count / 2]) / 2;
            }
            else
            {
                return sortedNumbers[count / 2];
            }
        }


        //несміщений коефіціент асиметрії
        private double CalculateUnbiasedSkewness(List<double> numbers)
        {
            double mean = numbers.Average();
            double standardDeviation = CalculateUnbiasedStandardDeviation(numbers);
            double n = numbers.Count;
            double skewness = numbers.Sum(num => Math.Pow(num - mean, 3)) / ((n - 1) * Math.Pow(standardDeviation, 3));
            return skewness * Math.Sqrt(n * (n - 1)) / (n - 2);
        }

        //контер ексцес 
        private double CalculateUnbiasedKurtosis(List<double> numbers)
        {
            double mean = numbers.Average();
            double standardDeviation = CalculateUnbiasedStandardDeviation(numbers);
            double n = numbers.Count;
            double kurtosis = numbers.Sum(num => Math.Pow(num - mean, 4)) / ((n - 1) * Math.Pow(standardDeviation, 4)) - 3;
            return ((n * (n + 1)) / ((n - 1) * (n - 2) * (n - 3))) * kurtosis + (3 * Math.Pow(n - 1, 2)) / ((n - 2) * (n - 3));
        }

        private double CalculateCounterKurtosis(List<double> numbers)
        {
            return 1 / CalculateUnbiasedKurtosis(numbers);
        }

        //коефіціент Пірсона 
        private double CalculatePearsonVariation(List<double> numbers)
        {
            // Коефіцієнт варіації Пірсона = Стандартне відхилення / Середнє значення
            double mean = numbers.Average();
            double standardDeviation = CalculateUnbiasedStandardDeviation(numbers);
            return standardDeviation / mean;
        }

        private double CalculateStandardErrorOfMean(List<double> numbers, double standardDeviation)
        {
            // Стандартна похибка середнього (SEM) = Стандартне відхилення / sqrt(n)
            return standardDeviation / Math.Sqrt(numbers.Count);
        }

        private double CalculateStandardErrorOfStandardDeviation(List<double> numbers, double standardDeviation)
        {
            // Стандартна похибка стандартного відхилення (SES) = Стандартне відхилення / sqrt(2 * (n - 1))
            return standardDeviation / Math.Sqrt(2 * (numbers.Count - 1));
        }

        private double CalculateStandardErrorOfSkewness(List<double> numbers, double skewness)
        {
            // Стандартна похибка асиметрії (SES) = sqrt((6 * (n - 2)) / ((n + 1) * (n + 3)))
            double n = numbers.Count;
            return Math.Sqrt((6 * (n - 2)) / ((n + 1) * (n + 3)));
        }

        private double CalculateStandardErrorOfKurtosis(List<double> numbers, double kurtosis)
        {
            // Стандартна похибка ексцесу (SEK) = sqrt((24 * n * (n - 2) * (n - 3)) / ((n + 1) * (n + 1) * (n + 3) * (n + 5)))
            double n = numbers.Count;
            return Math.Sqrt((24 * n * (n - 2) * (n - 3)) / ((n + 1) * (n + 1) * (n + 3) * (n + 5)));
        }

        private double CalculateStandardErrorOfCounterKurtosis(List<double> numbers, double counterKurtosis)
        {
            // Стандартна похибка контрексцесу (SEC) = sqrt((24 * n * (n - 2) * (n - 3)) / ((n + 1) * (n + 1) * (н + 3) * (н + 5)))
            double n = numbers.Count;
            return Math.Sqrt((24 * n * (n - 2) * (n - 3)) / ((n + 1) * (n + 1) * (n + 3) * (n + 5)));
        }

        private double CalculateStandardErrorOfPearsonVariation(List<double> numbers, double pearsonVariation)
        {
            // Стандартна похибка коефіцієнта варіації Пірсона (SEPV) = Коефіцієнт варіації Пірсона / sqrt(2 * n)
            double n = numbers.Count;
            return pearsonVariation / Math.Sqrt(2 * n);
        }
        private double CalculateTrimmedMean(List<double> numbers, double trimPercentage = 0.05)
        {
            int n = numbers.Count;
            int trimCount = (int)(n * trimPercentage);

            List<double> sortedNumbers = new List<double>(numbers);
            sortedNumbers.Sort(); // Сортуємо копію
            List<double> trimmedNumbers = sortedNumbers.Skip(trimCount).Take(n - 2 * trimCount).ToList();

            return trimmedNumbers.Average();
        }

        private double CalculateRawMoment7thOrder(List<double> numbers)
        {
            double n = numbers.Count;
            double rawMoment7thOrder = numbers.Sum(num => Math.Pow(num, 7)) / n;
            return rawMoment7thOrder;
        }
        private double CalculateCentralMoment7thOrder(List<double> numbers)
        {
            double mean = numbers.Average();
            double n = numbers.Count;
            double centralMoment7thOrder = numbers.Sum(num => Math.Pow(num - mean, 7)) / n;
            return centralMoment7thOrder;
        }
        private void buttonHisto2_Click(object sender, EventArgs e)
        {
            // Перевірка наявності збережених векторів
            if (savedVectors.Count < 2)
            {
                MessageBox.Show("Потрібно хоча б два збережені вектори для побудови гістограми.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Отримання векторів X та Y
            List<double> vectorX = savedVectors[0];
            List<double> vectorY = savedVectors[1];

            // Перевірка, чи вони однакової довжини
            if (vectorX.Count != vectorY.Count)
            {
                MessageBox.Show("Вектори X та Y повинні бути однакового розміру.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Визначення кількості бінів
            int binCountX = 10; // Кількість бінів по X
            int binCountY = 10; // Кількість бінів по Y

            // Мінімальні та максимальні значення
            double minX = vectorX.Min();
            double maxX = vectorX.Max();
            double minY = vectorY.Min();
            double maxY = vectorY.Max();

            // Ширина бінів
            double binWidthX = (maxX - minX) / binCountX;
            double binWidthY = (maxY - minY) / binCountY;

            // Ініціалізація таблиці частот
            double[,] frequencyTable = new double[binCountX, binCountY];

            // Підрахунок частот
            for (int i = 0; i < vectorX.Count; i++)
            {
                int binX = Math.Min((int)((vectorX[i] - minX) / binWidthX), binCountX - 1);
                int binY = Math.Min((int)((vectorY[i] - minY) / binWidthY), binCountY - 1);
                frequencyTable[binX, binY]++;
            }

            // Очищення графіка перед побудовою нового
            chartHisto2.Series.Clear();
            chartHisto2.ChartAreas.Clear();
            ChartArea area = new ChartArea
            {
                AxisX = { Title = "X" },
                AxisY = { Title = "Y" }
            };
            chartHisto2.ChartAreas.Add(area);

            // Знаходимо максимальну частоту
            double maxFrequency = frequencyTable.Cast<double>().Max();

            // Створення зон у вигляді зафарбованих квадратів
            for (int i = 0; i < binCountX; i++)
            {
                for (int j = 0; j < binCountY; j++)
                {
                    double frequency = frequencyTable[i, j];

                    // Пропуск порожніх зон
                    if (frequency > 0)
                    {
                        // Координати прямокутника
                        double xStart = minX + i * binWidthX;
                        double yStart = minY + j * binWidthY;

                        // Створення прямокутника
                        RectangleAnnotation rect = new RectangleAnnotation
                        {
                            AxisX = chartHisto2.ChartAreas[0].AxisX,
                            AxisY = chartHisto2.ChartAreas[0].AxisY,
                            X = xStart,
                            Y = yStart + binWidthY, // Верхня межа прямокутника
                            Width = binWidthX,
                            Height = binWidthY,
                            BackColor = GetColorForFrequency(frequency, maxFrequency),
                            LineColor = Color.Transparent // Забираємо рамки
                        };

                        // Додавання прямокутника на графік
                        chartHisto2.Annotations.Add(rect);
                    }
                }
            }

            MessageBox.Show("Двовимірна гістограма відображена успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Функція для визначення кольору на основі частоти
        private Color GetColorForFrequency(double frequency, double maxFrequency)
        {
            double normalized = frequency / maxFrequency; // Нормалізація частоти

            int r = (int)(255 * normalized);       // Червоний компонент залежить від частоти
            int g = (int)(255 * (1 - normalized)); // Зелений компонент інверсний до частоти
            return Color.FromArgb(r, g, 0);        // Кольори від зеленого до червоного
        }


        private void buttonCorr_Click(object sender, EventArgs e)
        {
            // Перевірка наявності збережених векторів
            if (savedVectors.Count < 2)
            {
                MessageBox.Show("Потрібно хоча б два збережені вектори для побудови кореляційного поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Отримання векторів X та Y
            List<double> vectorX = savedVectors[0];
            List<double> vectorY = savedVectors[1];

            // Перевірка, чи вони однакової довжини
            if (vectorX.Count != vectorY.Count)
            {
                MessageBox.Show("Вектори X та Y повинні бути однакового розміру.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка на наявність сортування
            bool isSortedX = vectorX.SequenceEqual(vectorX.OrderBy(x => x));
            bool isSortedY = vectorY.SequenceEqual(vectorY.OrderBy(y => y));

            if (isSortedX || isSortedY)
            {
                MessageBox.Show("Вхідні вектори X та Y не повинні бути відсортовані для коректного відображення кореляційного поля.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Очищення графіка перед побудовою нового
            chartCorr.Series.Clear();

            // Створення нового серії для кореляційного поля
            Series series = new Series("Кореляційне поле")
            {
                ChartType = SeriesChartType.Point, // Тип графіка - точки
                MarkerStyle = MarkerStyle.Circle, // Відображення точок як кола
                MarkerSize = 6 // Розмір точок
            };

            // Додавання точок у серію
            for (int i = 0; i < vectorX.Count; i++)
            {
                series.Points.AddXY(vectorX[i], vectorY[i]);
            }

            // Додавання серії до графіка
            chartCorr.Series.Add(series);

            // Налаштування осей графіка
            chartCorr.ChartAreas[0].AxisX.Title = "X";
            chartCorr.ChartAreas[0].AxisY.Title = "Y";

            chartCorr.ChartAreas[0].AxisX.MajorGrid.Enabled = true; // Увімкнення сітки для осі X
            chartCorr.ChartAreas[0].AxisY.MajorGrid.Enabled = true; // Увімкнення сітки для осі Y

            MessageBox.Show("Кореляційне поле успішно відображено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}


