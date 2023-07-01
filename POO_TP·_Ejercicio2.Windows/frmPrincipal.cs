using Entidades;
using System;
using System.Windows.Forms;

namespace POO_TP__Ejercicio2.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void panelInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, System.EventArgs e)
        {
            frmDatos formularioDatos = new frmDatos() {Text="Ingresá los datos del hexágono."};
            DialogResult dr = formularioDatos.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                return;
            }

            Hexagono hexaFrmPrincipal = formularioDatos.GetHexagono();      // trae el hexágono con el método GetHexagono, del objeto formularioDatos, de la clase frmDatos (el formulario de datos)
            DataGridViewRow r = ConstruirFila();        // Asignación al objeto "r" del tipo DataGridViewRow de la salida del método ConstruirFila
            SetearFila(r, hexaFrmPrincipal);        // Completa las celdas de la fila
            AgregarFila(r);     // Agrega la fila
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvHexagono.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Hexagono hexaFrmPrincipal)
        {
            r.Cells[colLado.Index].Value = hexaFrmPrincipal.GetLado();
            r.Cells[colApotema.Index].Value = hexaFrmPrincipal.GetApotema();
            r.Cells[colPerimetro.Index].Value = hexaFrmPrincipal.GetPerimetro();
            r.Cells[colArea.Index].Value = hexaFrmPrincipal.GetArea();
            r.Tag = hexaFrmPrincipal;       // Agrega el objeto hexaFrmPrincipal en la propiedad Tag
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();      // Creación del objeto r
            r.CreateCells(dgvHexagono);     // Crea celdas en la tabla dgvHexagono
            return r;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if(dgvHexagono.SelectedRows.Count == 0) 
            {
                return;
            }
            DataGridViewRow filaSeleccionada = dgvHexagono.SelectedRows[0];
            DialogResult queresBorrar = MessageBox.Show("¿Querés borrar la fila seleccionada?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if ( queresBorrar == DialogResult.No)
            {
                return;
            }
            dgvHexagono.Rows.Remove(filaSeleccionada);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvHexagono.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow filaSeleccionada = dgvHexagono.SelectedRows[0];
            Hexagono hexagonoDesdeTag = (Hexagono) filaSeleccionada.Tag;       // Convierte el objeto al tipo Hexagono
            frmDatos frmEditar = new frmDatos() {Text = "Editar hexágono." };        // Creo un formulario editar del tipo frmDatos
            frmEditar.SetCircunferencia(hexagonoDesdeTag);
            DialogResult frmDatosEditado = frmEditar.ShowDialog();

            if (frmDatosEditado == DialogResult.Cancel) 
            {
                return;
            }

            else
            {
                hexagonoDesdeTag = frmEditar.GetHexagono();
                SetearFila(filaSeleccionada , hexagonoDesdeTag);
            }
        }        
    }
}
