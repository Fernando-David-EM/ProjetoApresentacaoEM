namespace ProjetoApresentacaoEM.EM.WindowsForms
{
    partial class CadastroDeAlunos
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
            this.groupBoxAluno = new System.Windows.Forms.GroupBox();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.comboBoxSexo = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxNascimento = new System.Windows.Forms.MaskedTextBox();
            this.textBoxCpf = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.buttonAdicionarModificar = new System.Windows.Forms.Button();
            this.buttonLimparCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPesquisar = new System.Windows.Forms.TextBox();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonEditarAdicionar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.repositorioAlunoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxAluno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorioAlunoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAluno
            // 
            this.groupBoxAluno.Controls.Add(this.textBoxMatricula);
            this.groupBoxAluno.Controls.Add(this.comboBoxSexo);
            this.groupBoxAluno.Controls.Add(this.maskedTextBoxNascimento);
            this.groupBoxAluno.Controls.Add(this.textBoxCpf);
            this.groupBoxAluno.Controls.Add(this.textBoxNome);
            this.groupBoxAluno.Controls.Add(this.buttonAdicionarModificar);
            this.groupBoxAluno.Controls.Add(this.buttonLimparCancelar);
            this.groupBoxAluno.Controls.Add(this.label5);
            this.groupBoxAluno.Controls.Add(this.label4);
            this.groupBoxAluno.Controls.Add(this.label3);
            this.groupBoxAluno.Controls.Add(this.label2);
            this.groupBoxAluno.Controls.Add(this.label1);
            this.groupBoxAluno.Location = new System.Drawing.Point(13, 13);
            this.groupBoxAluno.Name = "groupBoxAluno";
            this.groupBoxAluno.Size = new System.Drawing.Size(595, 123);
            this.groupBoxAluno.TabIndex = 0;
            this.groupBoxAluno.TabStop = false;
            this.groupBoxAluno.Text = "Novo aluno";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Location = new System.Drawing.Point(8, 40);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(99, 20);
            this.textBoxMatricula.TabIndex = 13;
            this.textBoxMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxSexo
            // 
            this.comboBoxSexo.FormattingEnabled = true;
            this.comboBoxSexo.Items.AddRange(new object[] {
            "Masculino",
            "Feminino"});
            this.comboBoxSexo.Location = new System.Drawing.Point(8, 88);
            this.comboBoxSexo.Name = "comboBoxSexo";
            this.comboBoxSexo.Size = new System.Drawing.Size(99, 21);
            this.comboBoxSexo.TabIndex = 12;
            // 
            // maskedTextBoxNascimento
            // 
            this.maskedTextBoxNascimento.Location = new System.Drawing.Point(117, 89);
            this.maskedTextBoxNascimento.Name = "maskedTextBoxNascimento";
            this.maskedTextBoxNascimento.Size = new System.Drawing.Size(116, 20);
            this.maskedTextBoxNascimento.TabIndex = 11;
            // 
            // textBoxCpf
            // 
            this.textBoxCpf.Location = new System.Drawing.Point(239, 89);
            this.textBoxCpf.Name = "textBoxCpf";
            this.textBoxCpf.Size = new System.Drawing.Size(151, 20);
            this.textBoxCpf.TabIndex = 10;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(117, 40);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(461, 20);
            this.textBoxNome.TabIndex = 8;
            // 
            // buttonAdicionarModificar
            // 
            this.buttonAdicionarModificar.Location = new System.Drawing.Point(492, 86);
            this.buttonAdicionarModificar.Name = "buttonAdicionarModificar";
            this.buttonAdicionarModificar.Size = new System.Drawing.Size(86, 23);
            this.buttonAdicionarModificar.TabIndex = 6;
            this.buttonAdicionarModificar.Text = "Adicionar";
            this.buttonAdicionarModificar.UseVisualStyleBackColor = true;
            // 
            // buttonLimparCancelar
            // 
            this.buttonLimparCancelar.Location = new System.Drawing.Point(399, 86);
            this.buttonLimparCancelar.Name = "buttonLimparCancelar";
            this.buttonLimparCancelar.Size = new System.Drawing.Size(87, 23);
            this.buttonLimparCancelar.TabIndex = 5;
            this.buttonLimparCancelar.Text = "Limpar";
            this.buttonLimparCancelar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CPF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nascimento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sexo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrícula";
            // 
            // textBoxPesquisar
            // 
            this.textBoxPesquisar.Location = new System.Drawing.Point(13, 145);
            this.textBoxPesquisar.Name = "textBoxPesquisar";
            this.textBoxPesquisar.Size = new System.Drawing.Size(486, 20);
            this.textBoxPesquisar.TabIndex = 14;
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Location = new System.Drawing.Point(505, 145);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(86, 23);
            this.buttonPesquisar.TabIndex = 14;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(595, 209);
            this.dataGridView1.TabIndex = 15;
            // 
            // buttonEditarAdicionar
            // 
            this.buttonEditarAdicionar.Location = new System.Drawing.Point(429, 386);
            this.buttonEditarAdicionar.Name = "buttonEditarAdicionar";
            this.buttonEditarAdicionar.Size = new System.Drawing.Size(87, 23);
            this.buttonEditarAdicionar.TabIndex = 16;
            this.buttonEditarAdicionar.Text = "Editar";
            this.buttonEditarAdicionar.UseVisualStyleBackColor = true;
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(521, 386);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(87, 23);
            this.buttonExcluir.TabIndex = 17;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // repositorioAlunoBindingSource
            // 
            this.repositorioAlunoBindingSource.DataSource = typeof(ProjetoApresentacaoEM.EM.Repository.RepositorioAluno);
            // 
            // CadastroDeAlunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 418);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonEditarAdicionar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonPesquisar);
            this.Controls.Add(this.textBoxPesquisar);
            this.Controls.Add(this.groupBoxAluno);
            this.Name = "CadastroDeAlunos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Alunos";
            this.groupBoxAluno.ResumeLayout(false);
            this.groupBoxAluno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorioAlunoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAluno;
        private System.Windows.Forms.Button buttonAdicionarModificar;
        private System.Windows.Forms.Button buttonLimparCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCpf;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNascimento;
        private System.Windows.Forms.ComboBox comboBoxSexo;
        private System.Windows.Forms.TextBox textBoxPesquisar;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonEditarAdicionar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.BindingSource repositorioAlunoBindingSource;
    }
}