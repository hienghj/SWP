using Microsoft.AspNetCore.Mvc;
//using ClosedXML.Excel;
using System.IO;
using System.Collections.Generic;

public class ReportController : Controller
{
    public IActionResult Index()
    {
        // Tải danh sách báo cáo từ cơ sở dữ liệu hoặc dữ liệu mẫu
        var reports = new List<Report>
        {
            new Report { Id = 1, EventName = "Event A", Date = DateTime.Now.AddMonths(-1), Revenue = 5000 },
            new Report { Id = 2, EventName = "Event B", Date = DateTime.Now.AddMonths(-2), Revenue = 7000 }
        };
        return View(reports);
    }
}

    //public IActionResult ExportToExcel()
    //{
    //   // using var workbook = new XLWorkbook();
    //   // var worksheet = workbook.Worksheets.Add("Revenue Report");
     //   worksheet.Cell(1, 1).Value = "Event";
     //   worksheet.Cell(1, 2).Value = "Revenue";

        // Dữ liệu mẫu cho Excel
        //var data = new List<Report>
        //    {
        //        new Report { EventName = "Event A", Revenue = 5000 },
        //        new Report { EventName = "Event B", Revenue = 7000 }
        //    };

        //  for (int i = 0; i < data.Count; i++)
        //  {
        //     worksheet.Cell(i + 2, 1).Value = data[i].EventName;
        //     worksheet.Cell(i + 2, 2).Value = data[i].Revenue;
        // }

//        using (var stream = new MemoryStream())
//        {
//            workbook.SaveAs(stream);
//            var content = stream.ToArray();
//            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RevenueReport.xlsx");
//        }
//    }
//}
