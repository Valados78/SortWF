namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputDistr = new TextBox();
            button = new Button();
            dataGridView = new DataGridView();
            dateTimePicker = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // inputDistr
            // 
            inputDistr.Location = new Point(228, 235);
            inputDistr.Name = "inputDistr";
            inputDistr.PlaceholderText = "Введите район";
            inputDistr.Size = new Size(157, 23);
            inputDistr.TabIndex = 0;
            // 
            // button
            // 
            button.Location = new Point(490, 232);
            button.Name = "button";
            button.Size = new Size(95, 27);
            button.TabIndex = 2;
            button.Text = "Начать";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(573, 213);
            dataGridView.TabIndex = 3;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarTrailingForeColor = SystemColors.HighlightText;
            dateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(12, 235);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(189, 23);
            dateTimePicker.TabIndex = 4;
            dateTimePicker.Value = new DateTime(2024, 10, 23, 0, 0, 0, 0);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 280);
            Controls.Add(dateTimePicker);
            Controls.Add(dataGridView);
            Controls.Add(button);
            Controls.Add(inputDistr);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputDistr;
        private Button button;
        private DataGridView dataGridView;
        private DateTimePicker dateTimePicker;
    }
}
