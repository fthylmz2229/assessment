using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.report.api.Helpers
{
  public static class ExcelOperations
  {
    public static string WriteFile(List<RaporModel> model)
    {
      using (var workbook =new XLWorkbook())
      {
        var worksheet = workbook.Worksheets.Add("Rapor");

        worksheet.Cell("A1").Value = "Konum Bilgisi";
        worksheet.Cell("B1").Value = "Kişi Sayısı";
        worksheet.Cell("C1").Value = "Telefon Numarası Sayısı";

        worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(1, 3)).Style.Font.SetBold();

        int count = 2;
        if (model.Any())
        {
          foreach (var item in model)
          {
            worksheet.Cell(count, 1).SetValue(item.KonumBilgisi);
            worksheet.Cell(count, 2).SetValue(item.KisiSayisi);
            worksheet.Cell(count, 3).SetValue(item.TelefonNumarasiSayisi);

            count++;
          }
        }

        worksheet.Columns().AdjustToContents();
        if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Raporlar")))
          Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Raporlar"));
        string path = "Raporlar/" + Guid.NewGuid().ToString() + ".xlsx";
        workbook.SaveAs(Path.Combine(Environment.CurrentDirectory, path));
        return path;
      }
    }
  }
}
