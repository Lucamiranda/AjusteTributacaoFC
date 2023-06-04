namespace AjusteTributario
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btBuscar = new System.Windows.Forms.Button();
            this.btImportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAmbos = new System.Windows.Forms.RadioButton();
            this.rbDrogaria = new System.Windows.Forms.RadioButton();
            this.rbRevenda = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbProdutos = new System.Windows.Forms.RadioButton();
            this.rbNCM = new System.Windows.Forms.RadioButton();
            this.btConsultar = new System.Windows.Forms.Button();
            this.btExportar = new System.Windows.Forms.Button();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.progressoBarra = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.SuspendLayout();
            // 
            // btBuscar
            // 
            this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscar.Location = new System.Drawing.Point(944, 598);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(138, 23);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "...";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btImportar
            // 
            this.btImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btImportar.Location = new System.Drawing.Point(943, 627);
            this.btImportar.Name = "btImportar";
            this.btImportar.Size = new System.Drawing.Size(139, 23);
            this.btImportar.TabIndex = 2;
            this.btImportar.Text = "Importar";
            this.btImportar.UseVisualStyleBackColor = true;
            this.btImportar.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAmbos);
            this.groupBox1.Controls.Add(this.rbDrogaria);
            this.groupBox1.Controls.Add(this.rbRevenda);
            this.groupBox1.Location = new System.Drawing.Point(225, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 59);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupo";
            // 
            // rbAmbos
            // 
            this.rbAmbos.AutoSize = true;
            this.rbAmbos.Location = new System.Drawing.Point(186, 20);
            this.rbAmbos.Name = "rbAmbos";
            this.rbAmbos.Size = new System.Drawing.Size(57, 17);
            this.rbAmbos.TabIndex = 2;
            this.rbAmbos.TabStop = true;
            this.rbAmbos.Text = "Ambos";
            this.rbAmbos.UseVisualStyleBackColor = true;
            this.rbAmbos.CheckedChanged += new System.EventHandler(this.rbAmbos_CheckedChanged);
            // 
            // rbDrogaria
            // 
            this.rbDrogaria.AutoSize = true;
            this.rbDrogaria.Location = new System.Drawing.Point(99, 20);
            this.rbDrogaria.Name = "rbDrogaria";
            this.rbDrogaria.Size = new System.Drawing.Size(65, 17);
            this.rbDrogaria.TabIndex = 1;
            this.rbDrogaria.TabStop = true;
            this.rbDrogaria.Text = "Drogaria";
            this.rbDrogaria.UseVisualStyleBackColor = true;
            this.rbDrogaria.CheckedChanged += new System.EventHandler(this.rbDrogaria_CheckedChanged);
            // 
            // rbRevenda
            // 
            this.rbRevenda.AutoSize = true;
            this.rbRevenda.Location = new System.Drawing.Point(7, 20);
            this.rbRevenda.Name = "rbRevenda";
            this.rbRevenda.Size = new System.Drawing.Size(69, 17);
            this.rbRevenda.TabIndex = 0;
            this.rbRevenda.TabStop = true;
            this.rbRevenda.Text = "Revenda";
            this.rbRevenda.UseVisualStyleBackColor = true;
            this.rbRevenda.CheckedChanged += new System.EventHandler(this.rbRevenda_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbProdutos);
            this.groupBox2.Controls.Add(this.rbNCM);
            this.groupBox2.Location = new System.Drawing.Point(515, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Por";
            // 
            // rbProdutos
            // 
            this.rbProdutos.AutoSize = true;
            this.rbProdutos.Location = new System.Drawing.Point(81, 20);
            this.rbProdutos.Name = "rbProdutos";
            this.rbProdutos.Size = new System.Drawing.Size(67, 17);
            this.rbProdutos.TabIndex = 1;
            this.rbProdutos.TabStop = true;
            this.rbProdutos.Text = "Produtos";
            this.rbProdutos.UseVisualStyleBackColor = true;
            this.rbProdutos.CheckedChanged += new System.EventHandler(this.rbProdutos_CheckedChanged);
            // 
            // rbNCM
            // 
            this.rbNCM.AutoSize = true;
            this.rbNCM.Location = new System.Drawing.Point(15, 20);
            this.rbNCM.Name = "rbNCM";
            this.rbNCM.Size = new System.Drawing.Size(49, 17);
            this.rbNCM.TabIndex = 0;
            this.rbNCM.TabStop = true;
            this.rbNCM.Text = "NCM";
            this.rbNCM.UseVisualStyleBackColor = true;
            this.rbNCM.CheckedChanged += new System.EventHandler(this.rbNCM_CheckedChanged);
            // 
            // btConsultar
            // 
            this.btConsultar.Location = new System.Drawing.Point(24, 23);
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.Size = new System.Drawing.Size(159, 23);
            this.btConsultar.TabIndex = 5;
            this.btConsultar.Text = "Buscar";
            this.btConsultar.UseVisualStyleBackColor = true;
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // btExportar
            // 
            this.btExportar.Location = new System.Drawing.Point(24, 59);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(159, 23);
            this.btExportar.TabIndex = 6;
            this.btExportar.Text = "Exportar";
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            this.dgDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Location = new System.Drawing.Point(24, 98);
            this.dgDados.Name = "dgDados";
            this.dgDados.ReadOnly = true;
            this.dgDados.Size = new System.Drawing.Size(1058, 485);
            this.dgDados.TabIndex = 7;
            // 
            // progressoBarra
            // 
            this.progressoBarra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressoBarra.Location = new System.Drawing.Point(24, 627);
            this.progressoBarra.Name = "progressoBarra";
            this.progressoBarra.Size = new System.Drawing.Size(870, 23);
            this.progressoBarra.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 662);
            this.Controls.Add(this.progressoBarra);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.btExportar);
            this.Controls.Add(this.btConsultar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btImportar);
            this.Controls.Add(this.btBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste Fiscal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button btImportar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAmbos;
        private System.Windows.Forms.RadioButton rbDrogaria;
        private System.Windows.Forms.RadioButton rbRevenda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbProdutos;
        private System.Windows.Forms.RadioButton rbNCM;
        private System.Windows.Forms.Button btConsultar;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.ProgressBar progressoBarra;
    }
}

