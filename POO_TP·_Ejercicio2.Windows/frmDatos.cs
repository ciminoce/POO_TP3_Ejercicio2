using Entidades;
using System;
using System.Windows.Forms;

namespace POO_TP__Ejercicio2.Windows
{
    public partial class frmDatos : Form
    {
        public frmDatos()
        {
            InitializeComponent();
        }

        public Hexagono GetHexagono()
        {
            return hexagonoFrmDatos;
        }

        private Hexagono hexagonoFrmDatos;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                double valorDelLado = double.Parse(txtbLado.Text);
                
                
                if (hexagonoFrmDatos == null)
                {
                    hexagonoFrmDatos = new Hexagono(valorDelLado)    ;
                }
                else
                {
                    hexagonoFrmDatos.SetLado(valorDelLado);
                    
                }

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (!double.TryParse(txtbLado.Text, out double valorDelLado) || double.Parse(txtbLado.Text) <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtbLado, "Valor de lado inválido");
            }


            return valido;
        }

        public void SetCircunferencia(Hexagono hexagonoDesdeTag)
        {
            hexagonoFrmDatos = hexagonoDesdeTag;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (hexagonoFrmDatos != null)
            {
                txtbLado.Text = hexagonoFrmDatos.GetLado().ToString();
            }
        }
    }
}
