using System;
using System.Data;

namespace SSTIS
{
    public class BitacoraViewModel
    {
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Criticidad { get; set; }
        public string Funcionalidad { get; set; }
        public string Descripcion { get; set; }
        public static DataSet ListadoBitacora = new DataSet();

        //public List<BitacoraViewModel> GetBitacora()
        //{
        //    var listado = new List<BitacoraViewModel>();

        //    var obj = new BitacoraViewModel();
        //    obj.Usuario = "pepe";
        //    obj.Criticidad = "Alta";
        //    obj.Descripcion = "lala";
        //    obj.Fecha = DateTime.Now;
        //    obj.Funcionalidad = "lala";

        //    listado.Add(obj);
        //    return listado;
        //}
    }
}
