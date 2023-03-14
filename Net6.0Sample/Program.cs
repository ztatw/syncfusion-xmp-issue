//Create a new PDF document.
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using System.Diagnostics;
using Syncfusion.Pdf.Interactive;
using System.Reflection.Emit;
using System.Threading;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;

Thread thread = new Thread(GenerateBulkFile);
thread.Start();
partial class Program
{
    public static int counter = 1;


    static void GenerateBulkFile()
    {

        PdfDocument pdfDoc = new PdfDocument();
        //Create a page
        PdfPage page = pdfDoc.Pages.Add();

        //Get XMP object
        XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

        var customSchema = new CustomSchema(metaData, "example", "http://ns.adobe.com/xap/1.0/abc");
        customSchema["the_key"] = $"a{((char)11).ToString()}b";
        
        //XMP PDF Schema
        PDFSchema pdfSchema = metaData.PDFSchema;
        //Set the PDF Schema details of the document
        pdfSchema.Producer = "Syncfusion";
        pdfSchema.PDFVersion = "1.5";
        pdfSchema.Keywords = "Essen#%ial PDF";
        pdfSchema.Producer = "^%$PDF";

        //Save and close the document
        MemoryStream stream = new MemoryStream();
        pdfDoc.Save(stream);
        stream.Position = 0;

        File.WriteAllBytes("Output.pdf", stream.ToArray());

        //Close the document
        pdfDoc.Close(true);

    }
}