
namespace Расчет_норматив_потерь
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.database1DataSet3 = new Расчет_норматив_потерь.Database1DataSet3();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableTableAdapter = new Расчет_норматив_потерь.Database1DataSet3TableAdapters.TableTableAdapter();
            this.видПотерьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.потериГазаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.потериКонденсатаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаИзмененияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.видПотерьDataGridViewTextBoxColumn,
            this.потериГазаDataGridViewTextBoxColumn,
            this.потериКонденсатаDataGridViewTextBoxColumn,
            this.датаИзмененияDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tableBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1569, 555);
            this.dataGridView1.TabIndex = 0;
            // 
            // database1DataSet3
            // 
            this.database1DataSet3.DataSetName = "Database1DataSet3";
            this.database1DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.database1DataSet3;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // видПотерьDataGridViewTextBoxColumn
            // 
            this.видПотерьDataGridViewTextBoxColumn.DataPropertyName = "Вид потерь";
            this.видПотерьDataGridViewTextBoxColumn.HeaderText = "Вид потерь";
            this.видПотерьDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.видПотерьDataGridViewTextBoxColumn.Name = "видПотерьDataGridViewTextBoxColumn";
            this.видПотерьDataGridViewTextBoxColumn.ReadOnly = true;
            this.видПотерьDataGridViewTextBoxColumn.Width = 125;
            // 
            // потериГазаDataGridViewTextBoxColumn
            // 
            this.потериГазаDataGridViewTextBoxColumn.DataPropertyName = "Потери газа";
            this.потериГазаDataGridViewTextBoxColumn.HeaderText = "Потери газа";
            this.потериГазаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.потериГазаDataGridViewTextBoxColumn.Name = "потериГазаDataGridViewTextBoxColumn";
            this.потериГазаDataGridViewTextBoxColumn.ReadOnly = true;
            this.потериГазаDataGridViewTextBoxColumn.Width = 125;
            // 
            // потериКонденсатаDataGridViewTextBoxColumn
            // 
            this.потериКонденсатаDataGridViewTextBoxColumn.DataPropertyName = "Потери конденсата";
            this.потериКонденсатаDataGridViewTextBoxColumn.HeaderText = "Потери конденсата";
            this.потериКонденсатаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.потериКонденсатаDataGridViewTextBoxColumn.Name = "потериКонденсатаDataGridViewTextBoxColumn";
            this.потериКонденсатаDataGridViewTextBoxColumn.ReadOnly = true;
            this.потериКонденсатаDataGridViewTextBoxColumn.Width = 125;
            // 
            // датаИзмененияDataGridViewTextBoxColumn
            // 
            this.датаИзмененияDataGridViewTextBoxColumn.DataPropertyName = "Дата изменения";
            this.датаИзмененияDataGridViewTextBoxColumn.HeaderText = "Дата изменения";
            this.датаИзмененияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.датаИзмененияDataGridViewTextBoxColumn.Name = "датаИзмененияDataGridViewTextBoxColumn";
            this.датаИзмененияDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаИзмененияDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 555);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Database1DataSet3 database1DataSet3;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private Database1DataSet3TableAdapters.TableTableAdapter tableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn видПотерьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn потериГазаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn потериКонденсатаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаИзмененияDataGridViewTextBoxColumn;
    }
}