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

        public int N_NumFilas()
        {
            return objDato.D_NumFilas();
        }
    }

}
