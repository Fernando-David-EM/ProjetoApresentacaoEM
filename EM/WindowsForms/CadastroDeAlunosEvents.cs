using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoApresentacaoEM.EM.WindowsForms
{
    partial class CadastroDeAlunos
    {
        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var aluno = _bindingSource.Current as Aluno;
            textBoxMatricula.Text = aluno.Matricula.ToString();
            textBoxNome.Text = aluno.Nome;
            comboBoxSexo.SelectedIndex = (int)aluno.Sexo;
            textBoxCpf.Text = Formata.RemovePontuacaoCpf(aluno.CPF);
            maskedTextBoxNascimento.Text = aluno.Nascimento.ToString("dd/MM/yyyy");
        }

        private void EstaApagando_KeyDown(object sender, KeyEventArgs e)
        {
            _teclaEhDeApagar = false;

            VerificaSeEstaApagando(e);
        }
        private void VerificaSeEstaApagando(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                _teclaEhDeApagar = true;
            }
        }

        private void TextBoxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !_teclaEhDeApagar)
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
            if (!char.IsDigit(e.KeyChar) && !_teclaEhDeApagar)
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

        private void buttonEstadoEditar_Click(object sender, EventArgs e)
        {
            AlternaEstadoDaTela();
        }
        private void buttonEstadoAdicionar_Click(object sender, EventArgs e)
        {
            AlternaEstadoDaTela();
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
            AlternaEstadoDaTela();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionaAluno();
            }
            catch (FbException ex)
            {
                TrateFbException(ex);
            }
            catch (FormatException)
            {
                MessageBox.Show("Data inválida!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AdicionaAluno()
        {
            var aluno = CriaAlunoBaseadoNosCampos();

            _repositorio.Add(aluno);

            MessageBox.Show("Aluno adicionado com sucesso!");

            if ((_bindingSource.DataSource as BindingList<Aluno>) == null)
            {
                InicializaDataGridView();
            }
            else
            {
                _bindingSource.Add(aluno);
            }
        }

        private void TrateFbException(FbException ex)
        {
            if (ex.Message.Contains("MATRICULA"))
                MessageBox.Show("Matricula já cadastrada!");
            else
            {
                if (ex.Message.Contains("CPF"))
                    MessageBox.Show("CPF já cadastrado!");
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                EditeAluno();
            }
            catch (FbException ex)
            {
                TrateFbException(ex);
            }
            catch (FormatException)
            {
                MessageBox.Show("Data inválida!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditeAluno()
        {
            var aluno = CriaAlunoBaseadoNosCampos();

            _repositorio.Update(aluno);

            MessageBox.Show("Aluno alterado com sucesso!");

            InicializaDataGridView();
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            AtribuiListaAoBindingSource(
                _repositorio
                .GetByConteudoNoNome(
                    textBoxPesquisar.Text));
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
