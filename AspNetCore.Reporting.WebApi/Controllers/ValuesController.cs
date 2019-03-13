using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting.ReportExecutionService;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Reporting.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            string mimtype = "";
            int extension = 1;
            var _reportPath = @"Reports\testeReport.rdlc";

            LocalReport localReport = new LocalReport(_reportPath);


            //Dados
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Clear();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "Paulo");
            dt.Rows.Add(2, "Jose");
            localReport.AddDataSource("DataSet1", dt);


            //Parametros do relatório
            var reportParams = new Dictionary<string, string>();
            //reportParams.Add("Key1", "value1");
            //reportParams.Add("Key2", "value2");
            if (reportParams != null && reportParams.Count > 0)// if you use parameter in report
            {
                List<ReportParameter> reportparameter = new List<ReportParameter>();
                foreach (var record in reportParams)
                {
                    reportparameter.Add(new ReportParameter());
                }

            }

            //Geração do arquivo
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters: reportParams);
            byte[] file = result.MainStream;

            Stream stream = new MemoryStream(file);
            return File(stream, "application/pdf", "testeReport.pdf");
        }     
    }
}
