using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Order> orders;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = @""; // Подставить свой путь!

            // Определяем столбцы для DataGridView
            dataGridView.Columns.Clear(); // Очистка предыдущих столбцов, если есть
            dataGridView.Columns.Add("OrderNumber", "Номер заказа");
            dataGridView.Columns.Add("Weight", "Вес");
            dataGridView.Columns.Add("District", "Район");
            dataGridView.Columns.Add("DeliveryTime", "Время доставки");

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Файл {filePath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                orders = LoadOrdersFromCsv(filePath);
                MessageBox.Show($"Загружено заказов из файла: {orders.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заказов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            string selectedDistrict = inputDistr.Text; // Получаем район из TextBox
            DateTime firstDeliveryTime = dateTimePicker.Value; // Получаем время из DateTimePicker

            // Определяем время окончания фильтрации (через 30 минут)
            DateTime endDeliveryTime = firstDeliveryTime.AddMinutes(30);

            // Фильтруем заказы по критериям
            var filteredOrders = orders.Where(order =>
                order.District.Equals(selectedDistrict, StringComparison.OrdinalIgnoreCase) &&
                order.DeliveryTime >= firstDeliveryTime &&
                order.DeliveryTime <= endDeliveryTime).ToList();

            // Очищаем DataGridView перед добавлением новых данных
            dataGridView.Rows.Clear();

            // Заполняем DataGridView отфильтрованными данными
            foreach (var order in filteredOrders)
            {
                dataGridView.Rows.Add(order.OrderNumber, order.Weight, order.District, order.DeliveryTime);
            }

            if (filteredOrders.Count > 0)
            {
                MessageBox.Show($"Найдено {filteredOrders.Count} заказов.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Заказы не найдены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<Order> LoadOrdersFromCsv(string filePath)
        {
            var orders = new List<Order>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null // Игнорируем отсутствующие поля
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Order>();
                foreach (var record in records)
                {
                    if (ValidateOrder(record))
                    {
                        orders.Add(record);
                    }
                    else
                    {
                        MessageBox.Show($"Некорректные данные для заказа: {record.OrderNumber}. Пропускаем.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            return orders;
        }

        private bool ValidateOrder(Order order)
        {
            return !string.IsNullOrWhiteSpace(order.OrderNumber) &&
                   order.Weight > 0 &&
                   !string.IsNullOrWhiteSpace(order.District) &&
                   order.DeliveryTime != default(DateTime); // Проверка времени доставки
        }
    }
}
