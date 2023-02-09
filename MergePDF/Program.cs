using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text;

Console.WriteLine("Hello, World!");

string path = @"C:\Users\Malik\Dropbox\Documents\Misc\Financial\Claims DHARIHAZ\202212 Dec\";

string[] lstFiles = new string[4];
lstFiles[0] = path + @"claim_dtsb_202212.pdf";
lstFiles[1] = path + @"RFID E-Statement.pdf";
lstFiles[2] = path + @"Touchngo card 1.pdf";
lstFiles[3] = path + @"Touchngo card 2.pdf";

MergePages(path + @"combined.pdf", lstFiles);

static void MergePages(string outputPdfPath, string[] lstFiles)
{
    PdfReader reader = null;
    Document sourceDocument = null;
    PdfCopy pdfCopyProvider = null;
    PdfImportedPage importedPage;
    sourceDocument = new Document();
    pdfCopyProvider = new PdfCopy(sourceDocument,
    new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
    sourceDocument.Open();
    try
    {
        for (int f = 0; f < lstFiles.Length; f++)
        {
            int pages = 1;
            reader = new PdfReader(lstFiles[f]);
            pages = reader.NumberOfPages;
            //Add pages of current file
            for (int i = 1; i <= pages; i++)
            {
                importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                pdfCopyProvider.AddPage(importedPage);
            }
            reader.Close();
        }
        sourceDocument.Close();
    }
    catch (Exception ex)
    {
        throw ex;
    }
}