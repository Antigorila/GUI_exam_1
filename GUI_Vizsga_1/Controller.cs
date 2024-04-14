using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Vizsga_1
{
    internal class Controller
    {
        public static void Ini(string databasename)
        {
            SQL.Command($"CREATE DATABASE IF NOT EXISTS {databasename} DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;");
            SQL.SetConnectionString($"datasource=127.0.0.1;port=3306;username=root;password=;database={databasename}");

            if (! SQL.Tables().Contains("uzlet"))
            {
                ReadAndExecuteSQLFile("uzlet");
            }

            if (! SQL.Tables().Contains("termek"))
            {
                ReadAndExecuteSQLFile("termek");
            }

            if (! SQL.Tables().Contains("mertekegyseg"))
            {
                ReadAndExecuteSQLFile("mertekegyseg");
            }

            SQL.Command("CREATE TABLE IF NOT EXISTS bevasarlolista (id INT AUTO_INCREMENT PRIMARY KEY, termek_id INT, mennyiseg INT, mertekegyseg_id INT, uzlet_id INT, megvan BOOLEAN, megjegyzes TEXT, FOREIGN KEY (termek_id) REFERENCES termek(id) ON DELETE CASCADE, FOREIGN KEY (mertekegyseg_id) REFERENCES mertekegyseg(id) ON DELETE CASCADE, FOREIGN KEY (uzlet_id) REFERENCES uzlet(id) ON DELETE CASCADE);");            
        }

        private static void ReadAndExecuteSQLFile(string fileName)
        {
            string commands = File.ReadAllText(fileName.Contains(".SQL") ? fileName : fileName + ".SQL");
            SQL.Command(commands);
        }
    }
}
