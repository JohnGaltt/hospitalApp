using Hospital.Core.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(IEnumerable<PatientSummary> patientSummaries)
        {
            var patientSummary = patientSummaries;

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>");

            sb.AppendFormat(@"<h1  class='clearfix'>
                            <small><span>DATE</span><br />{0}</small> 
                        </h1>", DateTime.UtcNow);

            sb.Append(@"<table align='center'>
                                    <tr>
                                        <th class='service'>Doctor Name</th>
                                        <th class='desc'>Patient Name</th>
                                        <th>Recomendation:</th>
                                    </tr>");

            foreach (var item in patientSummary)
            {
                sb.AppendFormat(@"<tr>
                                    <td class='service'>{0}</td>
                                    <td class='desc'>{1}</td>
                                    <td class='unit'>{2}</td>
                                  </tr>", item.Doctor.Name, item.Patient.Name, item.Conclusion);
            }

            sb.Append(@"
                                </table>
                            <footer>
                                Invoice was created on a computer and is valid without the signature and seal.
                            </footer>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
