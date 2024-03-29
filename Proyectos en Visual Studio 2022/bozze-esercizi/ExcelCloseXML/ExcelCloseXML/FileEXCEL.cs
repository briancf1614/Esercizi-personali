using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCloseXML
{
    public class FileEXCEL
    {
        public static void crearExcel(string path)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");
            worksheet.Cell("A1").InsertData(new List<Programador>
            {
                new Programador{Nombre="Carlos", Edad= 23244,Lenguaje="C#"},
                new Programador{Nombre="dftgdg", Edad= 22344,Lenguaje="Casf#"},
                new Programador{Nombre="sfthssgd", Edad= 2234,Lenguaje="C23#"}
            });
            workbook.SaveAs(path);
        }
    }
}
