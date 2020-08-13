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
using Utf8Json;

namespace ProjetoApresentacaoEM.EM.WindowsForms
{
    public partial class CadastroDeAlunos : Form
    {
        private bool _teclaNaoNumerica = false;
        private bool _teclaEhDeApagar = false;
        private EnumeradorEstadosTela _estadoTela = EnumeradorEstadosTela.Adicionar;
        private readonly RepositorioAluno _repositorio = new RepositorioAluno();
        private readonly BindingSource _bindingSource = new BindingSource();

        public CadastroDeAlunos()
        {
            InicializaComponentes();
        }

        private void InicializaComponentes()
        {
            InitializeComponent();
            InicializaDataGridView();
            InicializaMascaras();
            InicializaComboBoxSexo();
            InicializaEvents();

            AlternaEstadoDaTela();
        }

        private void InicializaDataGridView()
        {
            AtribuiListaAoBindingSource(_repositorio.GetAll());

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = _bindingSource;
        }

        private void AtribuiListaAoBindingSource(IEnumerable<Aluno> alunos)
        {
            var alunosBinding = new BindingList<Aluno>();

            foreach (var aluno in alunos)
            {
                alunosBinding.Add(aluno);
            }

            _bindingSource.DataSource = alunosBinding;
        }

        private void InicializaMascaras()
        {
            maskedTextBoxNascimento.Mask = "00/00/0000";
        }

        private void InicializaEvents()
        {
            textBoxMatricula.KeyDown += EhNumero_KeyDown;
            textBoxMatricula.KeyPress += TextBoxMatricula_KeyPress;

            textBoxCpf.KeyDown += EhNumero_KeyDown;
            textBoxCpf.KeyPress += TextBoxCpf_KeyPress;

            textBoxNome.KeyPress += TextBoxNome_KeyPress;

            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
        }

        private void InicializaComboBoxSexo()
        {
            comboBoxSexo.SelectedIndex = 0;
            comboBoxSexo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AlternaEstadoDaTela()
        {
            if (_estadoTela == EnumeradorEstadosTela.Adicionar)
            {
                _estadoTela = EnumeradorEstadosTela.Editar;

                DefineBotoesAdicionar();

                DefineEventoDeCliqueAdicionar();
            }
            else
            {
                _estadoTela = EnumeradorEstadosTela.Adicionar;

                DefineBotoesAlterar();

                DefineEventoDeCliqueAlterar();
            }
        }

        private void DefineBotoesAdicionar()
        {
            buttonAdicionarModificar.Text = "Adicionar";
            buttonLimparCancelar.Text = "Limpar";
            buttonEditarAdicionar.Text = "Editar";
            groupBoxAluno.Text = "Novo aluno";
            textBoxMatricula.Enabled = true;
        }

        private void DefineBotoesAlterar()
        {
            buttonAdicionarModificar.Text = "Modificar";
            buttonLimparCancelar.Text = "Cancelar";
            buttonEditarAdicionar.Text = "Adicionar";
            groupBoxAluno.Text = "Editando aluno";
            textBoxMatricula.Enabled = false;
        }

        private void DefineEventoDeCliqueAdicionar()
        {
            buttonEditarAdicionar.Click += buttonEstadoEditar_Click;
            buttonEditarAdicionar.Click -= buttonEstadoAdicionar_Click;
            buttonLimparCancelar.Click += buttonLimpar_Click;
            buttonLimparCancelar.Click -= buttonCancelar_Click;
            buttonAdicionarModificar.Click += buttonAdicionar_Click;
            buttonAdicionarModificar.Click -= buttonEditar_Click;
        }

        private void DefineEventoDeCliqueAlterar()
        {
            buttonEditarAdicionar.Click += buttonEstadoAdicionar_Click;
            buttonEditarAdicionar.Click -= buttonEstadoEditar_Click;
            buttonLimparCancelar.Click += buttonCancelar_Click;
            buttonLimparCancelar.Click -= buttonLimpar_Click;
            buttonAdicionarModificar.Click += buttonEditar_Click;
            buttonAdicionarModificar.Click -= buttonAdicionar_Click;
        }
        private Aluno CriaAlunoBaseadoNosCampos()
        {
            VerificaCampos();

            var matricula = Convert.ToInt32(textBoxMatricula.Text);
            var nome = textBoxNome.Text;
            var sexo = (EnumeradorSexo)comboBoxSexo.SelectedIndex;
            var nascimento = DateTime.Parse(maskedTextBoxNascimento.Text);
            var cpf = textBoxCpf.Text;

            return new Aluno(matricula, nome, cpf, nascimento, sexo);
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
    }
}
