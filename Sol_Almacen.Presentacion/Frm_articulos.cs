using System;
using System.Windows.Forms;

namespace Sol_Almacen.Presentacion
{
    public partial class Frm_articulos : Form
    {
        public Frm_articulos()
        {
            InitializeComponent();
        }
        #region "Mis variables"
        int nCodigo_ar = 0;
        int nEstadoguarda = 0;
        int nCodigo_um = 0;
        int nCodigo_ca = 0;
        #endregion 
        #region "Mis metodos"

        private void Formato_ar()
        {
            Dgv_articulos.Columns[0].Width = 80;
            Dgv_articulos.Columns[0].HeaderText = "Codigo";
            Dgv_articulos.Columns[1].Width = 250;
            Dgv_articulos.Columns[1].HeaderText = "Articulo";
            Dgv_articulos.Columns[2].Width = 150;
            Dgv_articulos.Columns[2].HeaderText = "Marca";
            Dgv_articulos.Columns[3].Width = 80;
            Dgv_articulos.Columns[3].HeaderText = "Medida";
            Dgv_articulos.Columns[4].Width = 150;
            Dgv_articulos.Columns[4].HeaderText = "Categoria";
            Dgv_articulos.Columns[5].Width = 150;
            Dgv_articulos.Columns[5].HeaderText = "Stock Actual";
            Dgv_articulos.Columns[6].Visible = false;
            Dgv_articulos.Columns[7].Visible = false;
        }
        private void Listado_ar(string ctexto)
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_articulos.DataSource = Datos.Listado_ar(ctexto);
            this.Formato_ar();
        }

        private void Estado_texto(bool LEstado)
        {
            txt_descripcion_ar.ReadOnly = !LEstado;
            txt_marca_ar.ReadOnly = !LEstado;
            txt_stock_actual.ReadOnly = !LEstado;
        }

        private void Estado_botones_procesos(bool lEstado)
        {
            Btn_lupa_ca.Enabled = lEstado;
            Btn_lupa_um.Enabled = lEstado;

            Btn_cancelar.Visible = lEstado;
            Btn_guardar.Visible = lEstado;

            TxtBuscar.ReadOnly = lEstado;
            Btn_buscar.Enabled = lEstado;
            Dgv_articulos.Enabled = lEstado;
        }

        private void Estado_botones_principales(bool lEstado)
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_Actualizar.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }
        private void Limpia_texto()
        {
            txt_descripcion_ar.Text = "";
            txt_marca_ar.Text = "";
            txt_descripcion_um.Text = "";
            txt_descripcion_ca.Text = "";
            txt_stock_actual.Text = "0";
        }

        private void selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_articulos.CurrentRow.Cells["codigo_ar"].Value)))
            {
                MessageBox.Show("selecciona un registro", "aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo_ar = Convert.ToInt32(Dgv_articulos.CurrentRow.Cells["codigo_ar"].Value);
                txt_descripcion_ar.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["descripcion_ar"].Value);
                txt_marca_ar.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["marca_ar"].Value);
                txt_descripcion_um.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["descripcion_um"].Value);
                txt_descripcion_ca.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["descripcion_ca"].Value);
                txt_stock_actual.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["stock_actual"].Value);
                this.nCodigo_um = Convert.ToInt32(Dgv_articulos.CurrentRow.Cells["codigo_um"].Value);
                this.nCodigo_ca = Convert.ToInt32(Dgv_articulos.CurrentRow.Cells["codigo_ca"].Value);

            }
        }
        #endregion

        #region "metodos para medidas y categorias"
        private void Formato_um()
        {
            Dgv_um.Columns[0].Width = 200;
            Dgv_um.Columns[0].HeaderText = "Medidas";
            Dgv_um.Columns[1].Visible = false;

        }
        private void Listado_um()
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_um.DataSource = Datos.Listado_um();
            this.Formato_um();
        }

        private void Formato_ca()
        {
            Dgv_ca.Columns[0].Width = 200;
            Dgv_ca.Columns[0].HeaderText = "Categorias";
            Dgv_ca.Columns[1].Visible = false;

        }
        private void Listado_ca()
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_ca.DataSource = Datos.Listado_ca();
            this.Formato_ca();
        }
        private void selecciona_item_um()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_um.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("selecciona un elemento de la lista", "aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo_um = Convert.ToInt32(Dgv_um.CurrentRow.Cells["codigo_um"].Value);
                txt_descripcion_um.Text = Convert.ToString(Dgv_um.CurrentRow.Cells["descripcion_um"].Value);

            }
        }

        private void selecciona_item_ca()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_ca.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("selecciona un elemento de la lista", "aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo_ca = Convert.ToInt32(Dgv_ca.CurrentRow.Cells["codigo_ca"].Value);
                txt_descripcion_ca.Text = Convert.ToString(Dgv_ca.CurrentRow.Cells["descripcion_ca"].Value);

            }
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_articulos_Load(object sender, EventArgs e)
        {
            this.Listado_ar("%");
            this.Listado_ca();
            this.Listado_um();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ar("%" + TxtBuscar.Text.Trim() + "%");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 1;
            this.Limpia_texto();
            this.Estado_texto(true);
            this.Estado_botones_procesos(true);
            this.Estado_botones_principales(false);
            txt_descripcion_ar.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            nCodigo_ar = 0;
            nEstadoguarda = 0;
            this.Limpia_texto();
            this.Estado_texto(false);
            this.Estado_botones_procesos(false);
            this.Estado_botones_principales(true);
            TxtBuscar.Focus();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string Rpta = "";
            P_Articulos oAr = new P_Articulos();
            oAr.Codigo_ar = nCodigo_ar;
            oAr.Descripcion_ar = txt_descripcion_ar.Text.Trim();
            oAr.Marca_ar = txt_marca_ar.Text.Trim();
            oAr.Codigo_um = this.nCodigo_um;
            oAr.Codigo_ca = this.nCodigo_ca;
            oAr.Stock_actual = Convert.ToDecimal(txt_stock_actual.Text);
            oAr.Fecha_crea = DateTime.Now.ToString("yyyy-MM-dd");
            oAr.Fecha_modifica = DateTime.Now.ToString("yyyy-MM-dd");

            D_Articulos Datos = new D_Articulos();
            Rpta = Datos.Guardar_ar(nEstadoguarda, oAr);

            if (Rpta.Equals("OK"))
            {
                this.Estado_texto(false);
                this.Estado_botones_procesos(false);
                this.Estado_botones_principales(true);
                this.Listado_ar("%");
                nCodigo_ar = 0;
                nEstadoguarda = 0;
                MessageBox.Show("Los datos han sido guardados correctamente", "aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(Rpta, "aviso del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 2;
            this.Estado_texto(true);
            this.Estado_botones_procesos(true);
            this.Estado_botones_principales(false);
            txt_descripcion_ar.Focus();
        }

        private void Dgv_articulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_item();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (nCodigo_ar > 0)
            {
                string Rpta = "";
                D_Articulos Datos = new D_Articulos();
                Rpta = Datos.Eliminar_ar(nCodigo_ar);
                if (Rpta.Equals("OK"))
                {
                    this.Limpia_texto();
                    this.Listado_ar("%");
                    nCodigo_ar = 0;
                    MessageBox.Show("Registro eliminado correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("No se tiene seleccionado ningun registro", "aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Articulos oRpt = new Frm_Rpt_Articulos();
            oRpt.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_lupa_um_Click(object sender, EventArgs e)
        {
            Pnl_um.Location = Btn_lupa_um.Location;
            Pnl_um.Visible = true;
        }

        private void Btn_lupa_ca_Click(object sender, EventArgs e)
        {
            Pnl_ca.Location = Btn_lupa_ca.Location;
            Pnl_ca.Visible = true;
        }

        private void Btn_retornar_um_Click(object sender, EventArgs e)
        {
            Pnl_um.Visible = false;
        }

        private void Btn_retornar_ca_Click(object sender, EventArgs e)
        {
            Pnl_ca.Visible = false;
        }

        private void Dgv_um_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_item_um();
            Pnl_um.Visible = false;
        }

        private void Dgv_ca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_item_ca();
            Pnl_ca.Visible = false;
        }

        private void Dgv_articulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
