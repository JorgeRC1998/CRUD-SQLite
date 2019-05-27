using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;

namespace FinalSeguimiento.Models
{
    public class Conexion
    {
        private SQLiteConnection con;

        private static Conexion instancia;

        public static Conexion Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador");
                return instancia;
            }
        }

        public static void Inicializador(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException();
            if(instancia != null)
                instancia.con.Close();
            
            instancia = new Conexion(filename);
        }

        private Conexion(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Registro>();
        }

        public string EstadoDeMensaje;

        public int addNew(string mov, string cto, double val, string obs, DateTime fec, string rec)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Registro() {
                    MOVIMIENTO = mov,
                    CONCEPTO = cto,
                    VALOR = Convert.ToDouble(val),
                    OBSERVACION = obs,
                    FECHA = Convert.ToDateTime(fec),
                    RECURRENCIA = rec
                });
                EstadoDeMensaje = string.Format("Cantidad de filas afectadas: {0}" , result);
            }catch(Exception e)
            {
                EstadoDeMensaje = e.Message;
            }
            return result;
        }

        public IEnumerable<Registro> GetAllReg()
        {
            try
            {
                return con.Table<Registro>();
            }catch(Exception e)
            {
                EstadoDeMensaje = e.Message;
            }
            return Enumerable.Empty<Registro>();
        }

        public IEnumerable<Registro>Delete()
        {
            return Conexion.instancia.con.Query<Registro>("DELETE FROM Registro");
        }
    }
}
