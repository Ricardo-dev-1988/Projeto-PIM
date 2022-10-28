using MySql.Data.MySqlClient;
using System.Runtime.ConstrainedExecution;

namespace PimV8
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dr;
        string strSql;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = crud_pim_8; Uid = root; Pwd = #Tecnologia1988;");

                strSql = "INSERT INTO usuario (nome, cpf, ddd, telefone, tipo, logradouro, numero, cep, bairro, cidade, estado) " +
                    "VALUES (@nome, @cpf, @ddd, @telefone, @tipo, @logradouro, @numero, @cep, @bairro, @cidade, @estado)";

                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
                comando.Parameters.AddWithValue("@ddd", txtDDD.Text);
                comando.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                comando.Parameters.AddWithValue("@tipo", txtTipo.Text);                
                comando.Parameters.AddWithValue("@logradouro", txtLogradouro.Text);
                comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                comando.Parameters.AddWithValue("@cep", txtCep.Text);
                comando.Parameters.AddWithValue("@bairro", txtBairro.Text);
                comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                comando.Parameters.AddWithValue("@estado", txtEstado.Text);               

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Dados cadastrado com sucesso!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = crud_pim_8; Uid = root; Pwd = #Tecnologia1988;");

                strSql = "UPDATE usuario SET nome = @nome, " +
                    "cpf = @cpf, ddd = @ddd, telefone = @telefone, " +
                    "tipo = @tipo, logradouro = @logradouro, numero = @numero, cep =" +
                    " @cep, bairro = @bairro, cidade = @cidade, estado = @estado WHERE id = @id";
                
                    
                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@id", txtID.Text);
                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
                comando.Parameters.AddWithValue("@ddd", txtDDD.Text);
                comando.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                comando.Parameters.AddWithValue("@tipo", txtTipo.Text);
                comando.Parameters.AddWithValue("@logradouro", txtLogradouro.Text);
                comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                comando.Parameters.AddWithValue("@cep", txtCep.Text);
                comando.Parameters.AddWithValue("@bairro", txtBairro.Text);
                comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                comando.Parameters.AddWithValue("@estado", txtEstado.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Dados atualizado com sucesso!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = crud_pim_8; Uid = root; Pwd = #Tecnologia1988;");

                strSql = "SELECT * FROM usuario WHERE id = @id";


                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@id", txtID.Text);

                conexao.Open();

                dr = comando.ExecuteReader();                

                while (dr.Read())
                {
                    txtNome.Text = Convert.ToString(dr["nome"]);
                    txtCpf.Text = Convert.ToString(dr["cpf"]);
                    txtDDD.Text = Convert.ToString(dr["ddd"]);
                    txtTelefone.Text = Convert.ToString(dr["telefone"]);
                    txtTipo.Text = Convert.ToString(dr["tipo"]);
                    txtLogradouro.Text = Convert.ToString(dr["logradouro"]);
                    txtNumero.Text = Convert.ToString(dr["numero"]);
                    txtCep.Text = Convert.ToString(dr["cep"]);
                    txtBairro.Text = Convert.ToString(dr["bairro"]);
                    txtCidade.Text = Convert.ToString(dr["cidade"]);
                    txtEstado.Text = Convert.ToString(dr["estado"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = crud_pim_8; Uid = root; Pwd = #Tecnologia1988;");

                strSql = "DELETE FROM usuario WHERE id = @id";


                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@id", txtID.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Dados excluidos com sucesso!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
    }

}