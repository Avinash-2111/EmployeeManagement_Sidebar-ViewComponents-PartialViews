using PdfSharp.Pdf;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace EmployeeManagement.Common.pdf
    {
        public class EmployeeDocument 
        {
            //private readonly EmployeeSource _source;
        private readonly PdfDocument _source = new PdfDocument();
        public EmployeeDocument(EmployeeSource employeeSource)
          {
           
          }

       

            public virtual async void Compose(IDocumentContainer container)
            {
                container
                    .Page(page =>
                    {
                        page.Margin(35);

                        page.Header().Element(ComposeHeader);
                    //    page.Content().Element(ComposeContent);
                        page.Footer().Element(ComposeFooter);
                    });
            }

            private void ComposeHeader(IContainer container)
            {
                container.AlignCenter().Text("Employee Details")
                    .FontSize(20)
                    .Bold();
            }

        /*    private void ComposeContent(IContainer container)
            {
                container.Column(column =>
                {
                    column.Item().Text($"Name: {employeeSource.Fir}").FontSize(14);
                    column.Item().Text($"Position: {Source.Position}").FontSize(14);
                    column.Item().Text($"Department: {Source.Department}").FontSize(14);
                    column.Item().Text($"Salary: {Source.Salary:C}").FontSize(14);
                });
            }
        */
            private void ComposeFooter(IContainer container)
            {
                container.AlignCenter().Text("Thank you for using our Employee Management System")
                    .FontSize(10);
            }

        public void Genaratepdf(MemoryStream pdfStream)
        {
            throw new NotImplementedException();
        }
    }
    }


