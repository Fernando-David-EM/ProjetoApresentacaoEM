using ProjetoApresentacaoEM.EM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoApresentacaoEM
{
    public partial class CadastroDeAlunos : Form
    {
        public CadastroDeAlunos()
        {
            InitializeComponent();
            comboBoxSexo.Items.Add(EnumeradorSexo.Masculino);
            comboBoxSexo.Items.Add(EnumeradorSexo.Feminino);
        }

        internal void InsereNoCampoMatricula(int matriculaAluno)
        {
            textBoxMatricula.Text = matriculaAluno.ToString();
        }

        internal void InsereNoCampoNome(string nomeDoAluno)
        {
            textBoxNome.Text = nomeDoAluno;
        }

        internal void SelecionaSexo(EnumeradorSexo masculino)
        {
            comboBoxSexo.SelectedItem = masculino;
        }

        internal void InsereNoCampoDataDeNascimento(DateTime data)
        {
            
        }
    }
}
