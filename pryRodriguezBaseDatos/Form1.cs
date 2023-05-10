using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pryRodriguezBaseDatos
{
    public partial class Form1 : Form
    {
        OleDbCommand miComandoBD;
        OleDbConnection miConexionDB;
        OleDbDataReader miLectorBD;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                miConexionDB = new OleDbConnection();
                miConexionDB.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\VERDULEROS.mdb";
                miConexionDB.Open();

                label1.Text = "Conexion establecida";
                label1.BackColor = Color.Green;

            }
            catch (Exception ex)
            {
                label1.Text = "Hubo un error"+ ex.Message + ex.Source;
                label1.BackColor = Color.Red;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                miComandoBD = new OleDbCommand();

                miComandoBD.Connection=miConexionDB;
                miComandoBD.CommandType = CommandType.TableDirect;
                miComandoBD.CommandText = "Productos";

                label1.Text = "Tabla Obtenida";
                label1.BackColor = Color.Green;

                miLectorBD = miComandoBD.ExecuteReader();

                OleDbDataReader miLectorBDGrupo;
                miComandoBD.CommandType=CommandType.TableDirect;
                miComandoBD.CommandText = "Grupos";
                miLectorBDGrupo = miComandoBD.ExecuteReader();



                string auxNombreGrupo;
                while (miLectorBD.Read())
                {
                    
                    //label1.Text = label1.Text + miLectorBD[1] + "\n";
                    while (miLectorBDGrupo.Read())
                    {
                        if (miLectorBD[2] == miLectorBDGrupo[0])
                        {
                            auxNombreGrupo = miLectorBDGrupo[1].ToString();
                        }
                    }


                    dataGridView1.Rows.Add(miLectorBD[0], miLectorBD[1], auxNombreGrupo, miLectorBD[3]);
                }
            }
            catch (Exception error)
            {
                label1.Text = "Hubo un error" + error.Message;
                label1.BackColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
