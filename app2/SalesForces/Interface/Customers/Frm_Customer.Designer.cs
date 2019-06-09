namespace Interface.Customers
{
    partial class Frm_Customer
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ClienteTitle = new System.Windows.Forms.Label();
            this.lbl_CardName = new System.Windows.Forms.Label();
            this.txt_CardName = new System.Windows.Forms.TextBox();
            this.lbl_CardLastName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_CardType = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saleForceDBDataSet = new Interface.SaleForceDBDataSet();
            this.tCardTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t_CardTypesTableAdapter = new Interface.SaleForceDBDataSetTableAdapters.t_CardTypesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.saleForceDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCardTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // lbl_ClienteTitle
            // 
            this.lbl_ClienteTitle.AutoSize = true;
            this.lbl_ClienteTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ClienteTitle.Location = new System.Drawing.Point(12, 9);
            this.lbl_ClienteTitle.Name = "lbl_ClienteTitle";
            this.lbl_ClienteTitle.Size = new System.Drawing.Size(105, 29);
            this.lbl_ClienteTitle.TabIndex = 1;
            this.lbl_ClienteTitle.Text = "Clientes";
            // 
            // lbl_CardName
            // 
            this.lbl_CardName.AutoSize = true;
            this.lbl_CardName.Location = new System.Drawing.Point(17, 65);
            this.lbl_CardName.Name = "lbl_CardName";
            this.lbl_CardName.Size = new System.Drawing.Size(52, 13);
            this.lbl_CardName.TabIndex = 2;
            this.lbl_CardName.Text = "Nombres:";
            // 
            // txt_CardName
            // 
            this.txt_CardName.Location = new System.Drawing.Point(71, 65);
            this.txt_CardName.Name = "txt_CardName";
            this.txt_CardName.Size = new System.Drawing.Size(177, 20);
            this.txt_CardName.TabIndex = 3;
            // 
            // lbl_CardLastName
            // 
            this.lbl_CardLastName.AutoSize = true;
            this.lbl_CardLastName.Location = new System.Drawing.Point(283, 65);
            this.lbl_CardLastName.Name = "lbl_CardLastName";
            this.lbl_CardLastName.Size = new System.Drawing.Size(52, 13);
            this.lbl_CardLastName.TabIndex = 4;
            this.lbl_CardLastName.Text = "Apellidos:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 5;
            // 
            // lbl_CardType
            // 
            this.lbl_CardType.AutoSize = true;
            this.lbl_CardType.Location = new System.Drawing.Point(542, 65);
            this.lbl_CardType.Name = "lbl_CardType";
            this.lbl_CardType.Size = new System.Drawing.Size(45, 13);
            this.lbl_CardType.TabIndex = 6;
            this.lbl_CardType.Text = "Genero:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.tCardTypesBindingSource;
            this.comboBox1.DisplayMember = "CardTypeName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(594, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.ValueMember = "CardType";
            // 
            // saleForceDBDataSet
            // 
            this.saleForceDBDataSet.DataSetName = "SaleForceDBDataSet";
            this.saleForceDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tCardTypesBindingSource
            // 
            this.tCardTypesBindingSource.DataMember = "t_CardTypes";
            this.tCardTypesBindingSource.DataSource = this.saleForceDBDataSet;
            // 
            // t_CardTypesTableAdapter
            // 
            this.t_CardTypesTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_CardType);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_CardLastName);
            this.Controls.Add(this.txt_CardName);
            this.Controls.Add(this.lbl_CardName);
            this.Controls.Add(this.lbl_ClienteTitle);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Customer";
            this.Text = "Frm_Customer";
            this.Load += new System.EventHandler(this.Frm_Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saleForceDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCardTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ClienteTitle;
        private System.Windows.Forms.Label lbl_CardName;
        private System.Windows.Forms.TextBox txt_CardName;
        private System.Windows.Forms.Label lbl_CardLastName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_CardType;
        private System.Windows.Forms.ComboBox comboBox1;
        private SaleForceDBDataSet saleForceDBDataSet;
        private System.Windows.Forms.BindingSource tCardTypesBindingSource;
        private SaleForceDBDataSetTableAdapters.t_CardTypesTableAdapter t_CardTypesTableAdapter;
    }
}