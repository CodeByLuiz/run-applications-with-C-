namespace Executar_Aplicativos
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
            btnExecutar = new Button();
            txtNome = new TextBox();
            lblStatus = new Label();
            lstResultados = new ListBox();
            btnBuscar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnExecutar
            // 
            btnExecutar.Location = new Point(249, 72);
            btnExecutar.Name = "btnExecutar";
            btnExecutar.Size = new Size(75, 23);
            btnExecutar.TabIndex = 0;
            btnExecutar.Text = "Executar";
            btnExecutar.UseVisualStyleBackColor = true;
            btnExecutar.Click += btnExecutar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(36, 23);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(538, 23);
            txtNome.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(36, 374);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(19, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "....";
            // 
            // lstResultados
            // 
            lstResultados.FormattingEnabled = true;
            lstResultados.ItemHeight = 15;
            lstResultados.Location = new Point(739, 45);
            lstResultados.Name = "lstResultados";
            lstResultados.Size = new Size(726, 259);
            lstResultados.TabIndex = 3;
            lstResultados.SelectedIndexChanged += lstResultados_SelectedIndexChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(36, 72);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(489, 72);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 345);
            label1.Name = "label1";
            label1.Size = new Size(152, 15);
            label1.TabIndex = 6;
            label1.Text = "Procurando em tempo real:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 5);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 7;
            label2.Text = "Nome do executavel:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(739, 26);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 8;
            label3.Text = "resultados:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1477, 652);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnBuscar);
            Controls.Add(lstResultados);
            Controls.Add(lblStatus);
            Controls.Add(txtNome);
            Controls.Add(btnExecutar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExecutar;
        private TextBox txtNome;
        private Label lblStatus;
        private ListBox lstResultados;
        private Button btnBuscar;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
