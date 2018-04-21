using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using capaEntidad;
using capaDatos;

namespace capaNegocio
{
    public class N_focusedBible
    {
        D_focusedBible objDato = new D_focusedBible();
        E_focusedBible preg = new E_focusedBible();

        public DataTable N_listado(E_focusedBible preg)
        {
            return objDato.D_listado(preg);
        }

        public void N_Insertar(E_focusedBible preg)
        {
            objDato.D_insertar(preg); //pasamos el objeto de la capa E_focusedBible como parametro al metodo D_insertar.
        }

        public int N_NumFilas()
        {
            return objDato.D_NumFilas();
        }


    }

}
