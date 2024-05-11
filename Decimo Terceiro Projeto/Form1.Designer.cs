namespace Decimo_Terceiro_Projeto;

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
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        btnCadastrar = new Button();
        txtRua = new TextBox();
        txtDataNascimento = new TextBox();
        txtNumeroDocumentoInserido = new TextBox();
        txtNumeroCasa = new TextBox();
        txtNomeInserido = new TextBox();
        label5 = new Label();
        label4 = new Label();
        label3 = new Label();
        label2 = new Label();
        label1 = new Label();
        tabPage2 = new TabPage();
        btnExcluir = new Button();
        btnBsucar = new Button();
        label14 = new Label();
        txtBuscaNumeroDocumento = new TextBox();
        lblRua = new Label();
        lblNumeroCasa = new Label();
        lblDataNascimento = new Label();
        lblNome = new Label();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        label9 = new Label();
        label10 = new Label();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Location = new Point(10, 7);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(617, 443);
        tabControl1.TabIndex = 0;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(btnCadastrar);
        tabPage1.Controls.Add(txtRua);
        tabPage1.Controls.Add(txtDataNascimento);
        tabPage1.Controls.Add(txtNumeroDocumentoInserido);
        tabPage1.Controls.Add(txtNumeroCasa);
        tabPage1.Controls.Add(txtNomeInserido);
        tabPage1.Controls.Add(label5);
        tabPage1.Controls.Add(label4);
        tabPage1.Controls.Add(label3);
        tabPage1.Controls.Add(label2);
        tabPage1.Controls.Add(label1);
        tabPage1.Location = new Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(609, 415);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Cadastro";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // btnCadastrar
        // 
        btnCadastrar.Dock = DockStyle.Bottom;
        btnCadastrar.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnCadastrar.Location = new Point(3, 187);
        btnCadastrar.Name = "btnCadastrar";
        btnCadastrar.Size = new Size(603, 225);
        btnCadastrar.TabIndex = 6;
        btnCadastrar.Text = "Cadastrar";
        btnCadastrar.UseVisualStyleBackColor = true;
        btnCadastrar.Click += btnCadastrar_Click;
        // 
        // txtRua
        // 
        txtRua.BorderStyle = BorderStyle.FixedSingle;
        txtRua.Location = new Point(235, 97);
        txtRua.Name = "txtRua";
        txtRua.Size = new Size(368, 23);
        txtRua.TabIndex = 4;
        // 
        // txtDataNascimento
        // 
        txtDataNascimento.BorderStyle = BorderStyle.FixedSingle;
        txtDataNascimento.Location = new Point(235, 68);
        txtDataNascimento.Name = "txtDataNascimento";
        txtDataNascimento.Size = new Size(368, 23);
        txtDataNascimento.TabIndex = 3;
        // 
        // txtNumeroDocumentoInserido
        // 
        txtNumeroDocumentoInserido.BorderStyle = BorderStyle.FixedSingle;
        txtNumeroDocumentoInserido.Location = new Point(235, 39);
        txtNumeroDocumentoInserido.Name = "txtNumeroDocumentoInserido";
        txtNumeroDocumentoInserido.Size = new Size(368, 23);
        txtNumeroDocumentoInserido.TabIndex = 2;
        // 
        // txtNumeroCasa
        // 
        txtNumeroCasa.BorderStyle = BorderStyle.FixedSingle;
        txtNumeroCasa.Location = new Point(235, 126);
        txtNumeroCasa.Name = "txtNumeroCasa";
        txtNumeroCasa.Size = new Size(368, 23);
        txtNumeroCasa.TabIndex = 5;
        // 
        // txtNomeInserido
        // 
        txtNomeInserido.BorderStyle = BorderStyle.FixedSingle;
        txtNomeInserido.Location = new Point(235, 10);
        txtNomeInserido.Name = "txtNomeInserido";
        txtNomeInserido.Size = new Size(368, 23);
        txtNomeInserido.TabIndex = 1;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(31, 99);
        label5.Name = "label5";
        label5.Size = new Size(79, 15);
        label5.TabIndex = 4;
        label5.Text = "Nome da rua:";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(31, 128);
        label4.Name = "label4";
        label4.Size = new Size(96, 15);
        label4.TabIndex = 3;
        label4.Text = "Número da casa:";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(31, 70);
        label3.Name = "label3";
        label3.Size = new Size(115, 15);
        label3.TabIndex = 2;
        label3.Text = "Data de nascimento:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(31, 41);
        label2.Name = "label2";
        label2.Size = new Size(136, 15);
        label2.TabIndex = 1;
        label2.Text = "Número do documento:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(31, 12);
        label1.Name = "label1";
        label1.Size = new Size(97, 15);
        label1.TabIndex = 0;
        label1.Text = "Nome completo:";
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(btnExcluir);
        tabPage2.Controls.Add(btnBsucar);
        tabPage2.Controls.Add(label14);
        tabPage2.Controls.Add(txtBuscaNumeroDocumento);
        tabPage2.Controls.Add(lblRua);
        tabPage2.Controls.Add(lblNumeroCasa);
        tabPage2.Controls.Add(lblDataNascimento);
        tabPage2.Controls.Add(lblNome);
        tabPage2.Controls.Add(label6);
        tabPage2.Controls.Add(label7);
        tabPage2.Controls.Add(label8);
        tabPage2.Controls.Add(label9);
        tabPage2.Controls.Add(label10);
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(609, 415);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Modificações";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // btnExcluir
        // 
        btnExcluir.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold);
        btnExcluir.Location = new Point(302, 205);
        btnExcluir.Name = "btnExcluir";
        btnExcluir.Size = new Size(301, 202);
        btnExcluir.TabIndex = 3;
        btnExcluir.Text = "EXCLUIR";
        btnExcluir.UseVisualStyleBackColor = true;
        btnExcluir.Click += btnExcluir_Click;
        // 
        // btnBsucar
        // 
        btnBsucar.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold);
        btnBsucar.Location = new Point(8, 205);
        btnBsucar.Name = "btnBsucar";
        btnBsucar.Size = new Size(291, 202);
        btnBsucar.TabIndex = 2;
        btnBsucar.Text = "BUSCA";
        btnBsucar.UseVisualStyleBackColor = true;
        btnBsucar.Click += btnBsucar_Click;
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(20, 50);
        label14.Name = "label14";
        label14.Size = new Size(97, 15);
        label14.TabIndex = 16;
        label14.Text = "Nome completo:";
        // 
        // txtBuscaNumeroDocumento
        // 
        txtBuscaNumeroDocumento.BorderStyle = BorderStyle.FixedSingle;
        txtBuscaNumeroDocumento.Location = new Point(206, 20);
        txtBuscaNumeroDocumento.Name = "txtBuscaNumeroDocumento";
        txtBuscaNumeroDocumento.Size = new Size(395, 23);
        txtBuscaNumeroDocumento.TabIndex = 1;
        // 
        // lblRua
        // 
        lblRua.AutoSize = true;
        lblRua.Location = new Point(206, 109);
        lblRua.Name = "lblRua";
        lblRua.Size = new Size(12, 15);
        lblRua.TabIndex = 14;
        lblRua.Text = "-";
        // 
        // lblNumeroCasa
        // 
        lblNumeroCasa.AutoSize = true;
        lblNumeroCasa.Location = new Point(206, 138);
        lblNumeroCasa.Name = "lblNumeroCasa";
        lblNumeroCasa.Size = new Size(12, 15);
        lblNumeroCasa.TabIndex = 13;
        lblNumeroCasa.Text = "-";
        // 
        // lblDataNascimento
        // 
        lblDataNascimento.AutoSize = true;
        lblDataNascimento.Location = new Point(206, 80);
        lblDataNascimento.Name = "lblDataNascimento";
        lblDataNascimento.Size = new Size(12, 15);
        lblDataNascimento.TabIndex = 12;
        lblDataNascimento.Text = "-";
        // 
        // lblNome
        // 
        lblNome.AutoSize = true;
        lblNome.Location = new Point(206, 50);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(12, 15);
        lblNome.TabIndex = 10;
        lblNome.Text = "-";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(20, 109);
        label6.Name = "label6";
        label6.Size = new Size(79, 15);
        label6.TabIndex = 9;
        label6.Text = "Nome da rua:";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(20, 138);
        label7.Name = "label7";
        label7.Size = new Size(96, 15);
        label7.TabIndex = 8;
        label7.Text = "Número da casa:";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(20, 80);
        label8.Name = "label8";
        label8.Size = new Size(115, 15);
        label8.TabIndex = 7;
        label8.Text = "Data de nascimento:";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(20, 22);
        label9.Name = "label9";
        label9.Size = new Size(136, 15);
        label9.TabIndex = 6;
        label9.Text = "Número do documento:";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(19, 80);
        label10.Name = "label10";
        label10.Size = new Size(97, 15);
        label10.TabIndex = 5;
        label10.Text = "Nome completo:";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(639, 450);
        Controls.Add(tabControl1);
        MaximumSize = new Size(655, 489);
        MinimumSize = new Size(655, 489);
        Name = "Form1";
        Text = "Form1";
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private Button btnCadastrar;
    private TextBox txtRua;
    private TextBox txtDataNascimento;
    private TextBox txtNumeroDocumentoInserido;
    private TextBox txtNumeroCasa;
    private TextBox txtNomeInserido;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox txtBuscaNumeroDocumento;
    private Label lblRua;
    private Label lblNumeroCasa;
    private Label lblDataNascimento;
    private Label lblNome;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label14;
    private Button btnExcluir;
    private Button btnBsucar;
}
