using System;
using System.Collections.Generic;
using System.ComponentModel;
using JsonExemplo;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonExemplo
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (!JsonController.obterDados(ref richTextBox1))
            {
                MessageBox.Show("Não foi possível trazer os dados para o RichBox!");
            }

            cepWebService cepWebService = null;
            if (JsonController.obterDadosClasse(txtBox.Text, ref cepWebService))
            {
                lblLocalidade.Text = cepWebService.localidade;
                lblCEP.Text = cepWebService.cep;
                lblUF.Text = cepWebService.uf;
                lblBairro.Text = cepWebService.bairro;
            }
        }
    }
}
