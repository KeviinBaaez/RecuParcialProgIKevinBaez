using RecuParcialProgI.Entidades;
using RecuuParcialProgI.Entidades;
using System.Data;

namespace RecuParcialProgI.Windows
{
    public partial class frmFiguraAE : Form
    {
        public frmFiguraAE()
        {
            InitializeComponent();
        }

        public Hexagono hexagono;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboColorRelleno();
            CargarDatosComboTipodeBorde();
            if (hexagono != null)
            {
                txt1.Text = hexagono.GetLado().ToString();
                cboColores.SelectedItem = hexagono.ColorRelleno;
                cboBordes.SelectedItem = hexagono.TipoDeBorde;
            }
        }
        private void CargarDatosComboTipodeBorde()
        {
            var listaBordes = Enum.GetValues(typeof(TipodeBorde)).Cast<TipodeBorde>().ToList();
            cboBordes.DataSource = listaBordes;
            cboBordes.SelectedIndex = 0;
        }

        private void CargarDatosComboColorRelleno()
        {
            var listaColores = Enum.GetValues(typeof(ColorRelleno)).Cast<ColorRelleno>().ToList();
            cboColores.DataSource = listaColores;
            cboColores.SelectedIndex = 0;
        }

        internal Hexagono GetHexagono()
        {
            return hexagono;
        }



        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txt1.Text, out int arista))
            {
                valido = false;
                errorProvider1.SetError(txt1, "Nro. mal ingresado.");
            }
            else if (arista <= 0)
            {
                valido = false;
                errorProvider1.SetError(txt1, "Valor de la Arista menor o igual a cero.");
            }

            return valido;
        }
        public void SetHexagono(Hexagono? hexagono)
        {
            this.hexagono = hexagono;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (hexagono == null)
                {
                    hexagono = new Hexagono();
                }

                hexagono.SetLado(int.Parse(txt1.Text));
                hexagono.ColorRelleno = (ColorRelleno)cboColores.SelectedItem;
                hexagono.TipoDeBorde = (TipodeBorde)cboBordes.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
