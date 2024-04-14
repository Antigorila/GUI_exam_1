using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Vizsga_1
{
    public class BevasarloListaElem
    {
        public int ID { get; set; }
        public Table termek_id { get; set; }
        public int mennyiseg { get; set; }
        public Table mertekegyseg_id { get; set; }
        public Table uzlet_id { get; set; }
        public bool megvan { get; set; }
        public string megjegyzes { get; set; }

        public BevasarloListaElem(int id)
        {
            ID = id;
            List<string[]> datas = SQL.Query($"SELECT * FROM bevasarlolista WHERE id = {id}");
            termek_id = new Table(int.Parse(datas[0][1]), "termek");
            mennyiseg = int.Parse(datas[0][2]);
            mertekegyseg_id = new Table(int.Parse(datas[0][3]), "mertekegyseg");
            uzlet_id = new Table(int.Parse(datas[0][4]), "uzlet");
            megvan = bool.Parse(datas[0][5]);
            megjegyzes = datas[0][6];
        }
    }

    public class Table
    {
        public int ID { get; set; }
        public string nev { get; set; }
        public Table(int id, string tableName)
        {
            List<string[]> datas = SQL.Query($"SELECT * FROM {tableName} WHERE id = {id}");
            ID = int.Parse(datas[0][0]);
            nev = datas[0][1];
        }
    }
}
