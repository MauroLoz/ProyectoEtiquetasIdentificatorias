namespace Proyecto
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtColada = new System.Windows.Forms.TextBox();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.txtPieza = new System.Windows.Forms.TextBox();
            this.btnGenerarInforme = new System.Windows.Forms.Button();
            this.lblModulo = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblColada = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtLoteDia = new System.Windows.Forms.TextBox();
            this.cmbLoteMes = new System.Windows.Forms.ComboBox();
            this.txtLoteAño = new System.Windows.Forms.TextBox();
            this.ListBoxPro = new System.Windows.Forms.ListBox();
            this.txtCopias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(118, 306);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(309, 26);
            this.txtDescripcion.TabIndex = 32;
            // 
            // txtColada
            // 
            this.txtColada.Enabled = false;
            this.txtColada.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColada.Location = new System.Drawing.Point(118, 401);
            this.txtColada.Name = "txtColada";
            this.txtColada.Size = new System.Drawing.Size(109, 26);
            this.txtColada.TabIndex = 30;
            // 
            // txtModulo
            // 
            this.txtModulo.Enabled = false;
            this.txtModulo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModulo.Location = new System.Drawing.Point(118, 495);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(109, 26);
            this.txtModulo.TabIndex = 29;
            // 
            // txtPieza
            // 
            this.txtPieza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPieza.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPieza.Location = new System.Drawing.Point(118, 103);
            this.txtPieza.Name = "txtPieza";
            this.txtPieza.Size = new System.Drawing.Size(309, 26);
            this.txtPieza.TabIndex = 28;
            this.txtPieza.TextChanged += new System.EventHandler(this.BusquedaTextBox_TextChanged);
            // 
            // btnGenerarInforme
            // 
            this.btnGenerarInforme.Enabled = false;
            this.btnGenerarInforme.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarInforme.Location = new System.Drawing.Point(307, 587);
            this.btnGenerarInforme.Name = "btnGenerarInforme";
            this.btnGenerarInforme.Size = new System.Drawing.Size(120, 37);
            this.btnGenerarInforme.TabIndex = 27;
            this.btnGenerarInforme.Text = "Imprimir";
            this.btnGenerarInforme.UseVisualStyleBackColor = true;
            this.btnGenerarInforme.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulo.Location = new System.Drawing.Point(28, 498);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(60, 18);
            this.lblModulo.TabIndex = 26;
            this.lblModulo.Text = "Modulo:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(67, 106);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(45, 18);
            this.lbl1.TabIndex = 25;
            this.lbl1.Text = "Pieza:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(28, 358);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(57, 18);
            this.lbl3.TabIndex = 24;
            this.lbl3.Text = "Cliente:";
            // 
            // lblColada
            // 
            this.lblColada.AutoSize = true;
            this.lblColada.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColada.Location = new System.Drawing.Point(28, 404);
            this.lblColada.Name = "lblColada";
            this.lblColada.Size = new System.Drawing.Size(54, 18);
            this.lblColada.TabIndex = 23;
            this.lblColada.Text = "Colada:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(28, 314);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(84, 18);
            this.lbl2.TabIndex = 22;
            this.lbl2.Text = "Descripcion:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 75);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Of:";
            // 
            // txtOF
            // 
            this.txtOF.Enabled = false;
            this.txtOF.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOF.Location = new System.Drawing.Point(267, 401);
            this.txtOF.MaxLength = 6;
            this.txtOF.Name = "txtOF";
            this.txtOF.Size = new System.Drawing.Size(109, 26);
            this.txtOF.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 42;
            this.label2.Text = "Lote:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(118, 355);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(309, 26);
            this.txtCliente.TabIndex = 43;
            // 
            // txtLoteDia
            // 
            this.txtLoteDia.Enabled = false;
            this.txtLoteDia.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteDia.Location = new System.Drawing.Point(118, 449);
            this.txtLoteDia.MaxLength = 2;
            this.txtLoteDia.Name = "txtLoteDia";
            this.txtLoteDia.Size = new System.Drawing.Size(56, 26);
            this.txtLoteDia.TabIndex = 44;
            this.txtLoteDia.TextChanged += new System.EventHandler(this.txtLoteDia_TextChanged);
            // 
            // cmbLoteMes
            // 
            this.cmbLoteMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoteMes.Enabled = false;
            this.cmbLoteMes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoteMes.FormattingEnabled = true;
            this.cmbLoteMes.Location = new System.Drawing.Point(190, 449);
            this.cmbLoteMes.Name = "cmbLoteMes";
            this.cmbLoteMes.Size = new System.Drawing.Size(57, 26);
            this.cmbLoteMes.TabIndex = 45;
            // 
            // txtLoteAño
            // 
            this.txtLoteAño.Enabled = false;
            this.txtLoteAño.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteAño.Location = new System.Drawing.Point(267, 449);
            this.txtLoteAño.Name = "txtLoteAño";
            this.txtLoteAño.Size = new System.Drawing.Size(56, 26);
            this.txtLoteAño.TabIndex = 46;
            // 
            // ListBoxPro
            // 
            this.ListBoxPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxPro.FormattingEnabled = true;
            this.ListBoxPro.ItemHeight = 15;
            this.ListBoxPro.Location = new System.Drawing.Point(118, 144);
            this.ListBoxPro.Name = "ListBoxPro";
            this.ListBoxPro.Size = new System.Drawing.Size(309, 139);
            this.ListBoxPro.TabIndex = 47;
            this.ListBoxPro.SelectedIndexChanged += new System.EventHandler(this.ListBoxPro_SelectedIndexChanged);
            // 
            // txtCopias
            // 
            this.txtCopias.Enabled = false;
            this.txtCopias.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopias.Location = new System.Drawing.Point(138, 540);
            this.txtCopias.Name = "txtCopias";
            this.txtCopias.Size = new System.Drawing.Size(86, 26);
            this.txtCopias.TabIndex = 49;
            this.txtCopias.Text = "1";
            this.txtCopias.TextChanged += new System.EventHandler(this.txtLoteDia_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 48;
            this.label3.Text = "Nro de Copias:";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(31, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 37);
            this.button1.TabIndex = 50;
            this.button1.Text = "Vista Previa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnConfig
            // 
            this.btnConfig.Enabled = false;
            this.btnConfig.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.Location = new System.Drawing.Point(170, 587);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(120, 37);
            this.btnConfig.TabIndex = 51;
            this.btnConfig.Text = "Config. Impre";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(456, 638);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCopias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ListBoxPro);
            this.Controls.Add(this.txtLoteAño);
            this.Controls.Add(this.cmbLoteMes);
            this.Controls.Add(this.txtLoteDia);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtColada);
            this.Controls.Add(this.txtModulo);
            this.Controls.Add(this.txtPieza);
            this.Controls.Add(this.btnGenerarInforme);
            this.Controls.Add(this.lblModulo);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lblColada);
            this.Controls.Add(this.lbl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etiquetas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtColada;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.TextBox txtPieza;
        private System.Windows.Forms.Button btnGenerarInforme;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblColada;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtLoteDia;
        private System.Windows.Forms.ComboBox cmbLoteMes;
        private System.Windows.Forms.TextBox txtLoteAño;
        private System.Windows.Forms.ListBox ListBoxPro;
        private System.Windows.Forms.TextBox txtCopias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConfig;
    }
}

