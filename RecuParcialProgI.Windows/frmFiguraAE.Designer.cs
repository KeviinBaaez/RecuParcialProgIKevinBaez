namespace RecuParcialProgI.Windows
{
    partial class frmFiguraAE
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txt1 = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            btnOK = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            cboBordes = new ComboBox();
            label3 = new Label();
            cboColores = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 54);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Lado:";
            // 
            // txt1
            // 
            txt1.Location = new Point(128, 51);
            txt1.Name = "txt1";
            txt1.Size = new Size(100, 23);
            txt1.TabIndex = 1;
            txt1.TextChanged += txt1_TextChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(43, 230);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(92, 67);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(355, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 67);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 100);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 3;
            label2.Text = "Diseño de Borde:";
            // 
            // cboBordes
            // 
            cboBordes.FormattingEnabled = true;
            cboBordes.Location = new Point(122, 99);
            cboBordes.Name = "cboBordes";
            cboBordes.Size = new Size(121, 23);
            cboBordes.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 147);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 3;
            label3.Text = "Color Relleno";
            // 
            // cboColores
            // 
            cboColores.FormattingEnabled = true;
            cboColores.Location = new Point(122, 144);
            cboColores.Name = "cboColores";
            cboColores.Size = new Size(121, 23);
            cboColores.TabIndex = 4;
            // 
            // frmFiguraAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 358);
            Controls.Add(cboColores);
            Controls.Add(cboBordes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txt1);
            Controls.Add(label1);
            Name = "frmFiguraAE";
            Text = "frmFiguraAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt1;
        private ErrorProvider errorProvider1;
        private Button btnCancelar;
        private Button btnOK;
        private ComboBox cboColores;
        private ComboBox cboBordes;
        private Label label3;
        private Label label2;
    }
}