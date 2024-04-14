using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_Vizsga_1
{
    internal class B
    {
        public static List<BevasarloListaElem> Lista()
        {
            List<BevasarloListaElem> bLista = new List<BevasarloListaElem>();
            List<string[]> datas = SQL.Query("SELECT * FROM bevasarlolista");
            for (int i = 0; i < datas.Count; i++)
            {
                bLista.Add(new BevasarloListaElem(int.Parse(datas[i][0])));
            }

            return bLista;
        }
    }
}
