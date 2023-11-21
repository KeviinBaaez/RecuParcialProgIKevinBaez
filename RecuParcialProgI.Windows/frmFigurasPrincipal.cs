using RecuParcialProgI.Entidades;
using RecuParcialProgI.Datos;
using System;

namespace RecuParcialProgI.Windows
{
    public partial class frmFigurasPrincipal : Form
    {
        private RepositorioDeFigura repo;
        private List<Hexagono> lista;
        int intValor;
        private Hexagono hexagono;

        public frmFigurasPrincipal()
        {
            InitializeComponent();
            repo = new RepositorioDeFigura();
            ActualizarCantidadRegistros();
        }

        private void ActualizarCantidadRegistros()
        {
            if (intValor > 0)
            {
                txtCantidad.Text = repo.GetCantidad(intValor).ToString();
            }
            else
            {
                txtCantidad.Text = repo.GetCantidad().ToString();
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
        private void SetearFila(DataGridViewRow r, Hexagono hexagono)
        {
            r.Cells[ColLado.Index].Value = hexagono.GetLado();
            r.Cells[ColColor.Index].Value = hexagono.ColorRelleno;
            r.Cells[ColBorde.Index].Value = hexagono.TipoDeBorde;
            r.Cells[ColApotema.Index].Value = hexagono.GetApotema();
            r.Cells[ColArea.Index].Value = hexagono.GetArea();
            r.Cells[ColPerimetro.Index].Value = hexagono.GetVolumen();
            r.Tag = hexagono;
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
            MessageBox.Show("Registro borrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (repo.GetCantidad() > 0)
            {
                lista = repo.GetLista();
                MostrarDatosEnGrilla();
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var hexagono in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, hexagono);
                AgregarFila(r);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFiguraAE frm = new frmFiguraAE() { Text = "Agregar Objeto." };
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            Hexagono hexagono = frm.GetHexagono();
            if (!repo.Existe(hexagono))
            {

                repo.Agregar(hexagono);
                txtCantidad.Text = repo.GetCantidad().ToString();
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, hexagono);
                AgregarFila(r);

                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registro existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("¿Desea borrar el Hexagono?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Hexagono hexagono = filaSeleccionada.Tag as Hexagono;
            repo.Borrar(hexagono);
            txtCantidad.Text = repo.GetCantidad().ToString();
            QuitarFila(filaSeleccionada);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];

            Hexagono hexagono = (Hexagono)filaSeleccionada.Tag;
            int aristaAnterior = hexagono.GetLado();
            frmFiguraAE frm = new frmFiguraAE() { Text = "Editar Hexagono" };
            frm.SetHexagono(hexagono);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            hexagono = frm.GetHexagono();
            repo.Editar(aristaAnterior, hexagono);
            SetearFila(filaSeleccionada, hexagono);
            MessageBox.Show("Registro editado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbFiltro_Click(object sender, EventArgs e)
        {
            var stringValor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el valor a filtrar",
                "Filtrar por mayor o igual",
                "0", 400, 400);
            if (!int.TryParse(stringValor, out intValor))
            {
                return;
            }
            if (intValor <= 0)
            {
                return;
            }
            lista = repo.Filtrar(intValor);
            tsbFiltro.BackColor = Color.BlueViolet;
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
            MessageBox.Show("Filtro aplicado!");
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
            intValor = 0;
            tsbFiltro.BackColor = SystemColors.Control;
        }

        private void tsbOrdenar_Click(object sender, EventArgs e)
        {
            lista = repo.OrdenarAsc();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
