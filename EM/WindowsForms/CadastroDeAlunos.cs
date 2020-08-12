using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoApresentacaoEM.EM.WindowsForms
{
    public partial class CadastroDeAlunos : Form
    {
        private bool _teclaNaoNumerica = false;
        private bool _teclaEhDeApagar = false;
        private EnumeradorEstadosTela _estadoTela;
        private RepositorioAluno _repositorio;
        private BindingSource _bindingSource;

        public CadastroDeAlunos()
        {
            _repositorio = new RepositorioAluno();

            InitializeComponent();
            PopuleDataGrid();
            InicializeMascaras();
            CrieEvents();
            InicializeComboBoxSexo();
            DefineEstadoDaTela(EnumeradorEstadosTela.Adicionar);
        }

        private void PopuleDataGrid()
        {
            _bindingSource = new BindingSource();
            var alunos = new BindingList<Aluno>();
            var alunosRepo = _repositorio.GetAll();
            foreach (var aluno in alunosRepo)
            {
                alunos.Add(aluno);
            }

            _bindingSource.DataSource = alunos;
            dataGridView1.DataSource = _bindingSource;
        }

        private void InicializeMascaras()
        {
            maskedTextBoxNascimento.Mask = "00/00/0000";
        }

        private void CrieEvents()
        {
            textBoxMatricula.KeyDown += EhNumero_KeyDown;
            textBoxMatricula.KeyPress += TextBoxMatricula_KeyPress;

            textBoxCpf.KeyDown += EhNumero_KeyDown;
            textBoxCpf.KeyPress += TextBoxCpf_KeyPress;

            textBoxNome.KeyPress += TextBoxNome_KeyPress;

            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var aluno = _bindingSource.Current as Aluno;
            textBoxMatricula.Text = aluno.Matricula.ToString();
            textBoxNome.Text = aluno.Nome;
            comboBoxSexo.SelectedIndex = (int)aluno.Sexo;
            textBoxCpf.Text = aluno.CPF;
            maskedTextBoxNascimento.Text = aluno.Nascimento.ToString("dd/MM/yyyy");
        }

        private void EhNumero_KeyDown(object sender, KeyEventArgs e)
        {
            _teclaNaoNumerica = false;
            _teclaEhDeApagar = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        _teclaNaoNumerica = true;
                    }
                }
            }
            if (ModifierKeys == Keys.Shift)
            {
                _teclaNaoNumerica = true;
            }
            if (e.KeyCode == Keys.Back)
            {
                _teclaEhDeApagar = true;
            }
        }

        private void TextBoxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_teclaNaoNumerica == true)
            {
                e.Handled = true;
            }

            if (textBoxMatricula.TextLength == 9 && !_teclaEhDeApagar)
            {
                e.Handled = true;
            }
        }
        private void TextBoxCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_teclaNaoNumerica == true)
            {
                e.Handled = true;
            }

            if (textBoxCpf.TextLength == 11 && !_teclaEhDeApagar)
            {
                e.Handled = true;
            }
        }

        private void TextBoxNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxNome.TextLength == 100)
            {
                e.Handled = true;
            }
        }

        private void InicializeComboBoxSexo()
        {
            comboBoxSexo.SelectedIndex = 0;
            comboBoxSexo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DefineEstadoDaTela(EnumeradorEstadosTela enumeradorEstadosTela)
        {
            _estadoTela = enumeradorEstadosTela;

            if (_estadoTela == EnumeradorEstadosTela.Adicionar)
            {
                buttonAdicionarModificar.Text = "Adicionar";
                buttonLimparCancelar.Text = "Limpar";
                buttonEditarAdicionar.Text = "Editar";
                groupBoxAluno.Text = "Novo aluno";
                textBoxMatricula.Enabled = true;
                buttonEditarAdicionar.Click += buttonMudarEstadoEditar_Click;
                buttonEditarAdicionar.Click -= buttonMudarEstadoAdicionar_Click;
                buttonLimparCancelar.Click += buttonLimpar_Click;
                buttonLimparCancelar.Click -= buttonCancelar_Click;
                buttonAdicionarModificar.Click += buttonAdicionar_Click;
                buttonAdicionarModificar.Click -= buttonEditar_Click;
            }
            else
            {
                buttonAdicionarModificar.Text = "Modificar";
                buttonLimparCancelar.Text = "Cancelar";
                buttonEditarAdicionar.Text = "Adicionar";
                groupBoxAluno.Text = "Editando aluno";
                textBoxMatricula.Enabled = false;
                buttonEditarAdicionar.Click += buttonMudarEstadoAdicionar_Click;
                buttonEditarAdicionar.Click -= buttonMudarEstadoEditar_Click;
                buttonLimparCancelar.Click += buttonCancelar_Click;
                buttonLimparCancelar.Click -= buttonLimpar_Click;
                buttonAdicionarModificar.Click += buttonEditar_Click;
                buttonAdicionarModificar.Click -= buttonAdicionar_Click;
            }
        }

        private void buttonMudarEstadoEditar_Click(object sender, EventArgs e)
        {
            DefineEstadoDaTela(EnumeradorEstadosTela.Editar);
        }
        private void buttonMudarEstadoAdicionar_Click(object sender, EventArgs e)
        {
            DefineEstadoDaTela(EnumeradorEstadosTela.Adicionar);
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxMatricula.Text = "";
            textBoxNome.Text = "";
            comboBoxSexo.SelectedIndex = 0;
            maskedTextBoxNascimento.Text = "";
            textBoxCpf.Text = "";
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DefineEstadoDaTela(EnumeradorEstadosTela.Adicionar);
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var aluno = CrieAlunoBaseadoNosCampos();

                _repositorio.Add(aluno);

                MessageBox.Show("Aluno adicionado com sucesso!");
                _bindingSource.Add(aluno);
            }
            catch (FbException ex)
            {
                if (ex.Message.Contains("ALU_MATRICULA"))
                    MessageBox.Show("Matricula já cadastrada!");
                else
                {
                    if (ex.Message.Contains("ALU_CPF"))
                        MessageBox.Show("CPF já cadastrado!");
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                var aluno = CrieAlunoBaseadoNosCampos();

                _repositorio.Update(aluno);

                MessageBox.Show("Aluno alterado com sucesso!");

                var pos = _bindingSource.Position;

                _bindingSource.RemoveCurrent();
                _bindingSource.Insert(pos, aluno);
            }
            catch (FbException ex)
            {
                if (ex.Message.Contains("ALU_MATRICULA"))
                    MessageBox.Show("Matricula já cadastrada!");
                if (ex.Message.Contains("ALU_CPF"))
                    MessageBox.Show("CPF já cadastrado!");
            }
        }

        private Aluno CrieAlunoBaseadoNosCampos()
        {
            try
            {
                VerificaCampos();

                var matricula = Convert.ToInt32(textBoxMatricula.Text);
                var nome = textBoxNome.Text;
                var sexo = (EnumeradorSexo)comboBoxSexo.SelectedIndex;
                var nascimento = DateTime.Parse(maskedTextBoxNascimento.Text);
                var cpf = textBoxCpf.Text;

                return new Aluno(matricula, nome, cpf, nascimento, sexo);
            }
            catch (FormatException)
            {
                MessageBox.Show("Data inválida!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private void VerificaCampos()
        {
            if (string.IsNullOrEmpty(textBoxMatricula.Text))
                throw new Exception("Campo Matricula deve ser preenchido!");
            if (string.IsNullOrEmpty(maskedTextBoxNascimento.Text))
                throw new Exception("Campo Nascimento deve ser preenchido!");
            if (maskedTextBoxNascimento.Text.Length < 10)
                throw new Exception("Campo Nascimento deve ser preenchido por completo!");
            if (string.IsNullOrEmpty(textBoxNome.Text))
                throw new Exception("Campo Nome deve ser preenchido!");
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            var alunos = new BindingList<Aluno>();
            var alunosRepo = _repositorio.GetByConteudoNoNome(textBoxPesquisar.Text);

            foreach (var aluno in alunosRepo)
            {
                alunos.Add(aluno);
            }

            _bindingSource.DataSource = alunos;
            dataGridView1.DataSource = _bindingSource;
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                _repositorio.Remove((Aluno)_bindingSource.Current);

                MessageBox.Show("Aluno excluído com sucesso!");
                _bindingSource.RemoveCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
