using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using css.Shared.ViewModels;
using System.Net.Http;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using IronPdf;
using System.Drawing.Imaging;

namespace customerServiceSoftware.TabClasses
{
   public class SolutionOperations
    {
        public static SolutionVM LoadSolutionData(int RequestID)
          {
            SolutionVM fillfields = new SolutionVM();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Solution/GetOneSolutionData?RequestId=" + RequestID.ToString();
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<SolutionVM>().Result;
                        return fillfields;
                    }

                    return fillfields;


                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return fillfields;
            }


        }

        public static string SaveSolutionData(SolutionVM OrderData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var OrderRequest = Newtonsoft.Json.JsonConvert.SerializeObject(OrderData);
                HttpResponseMessage response;
                if (OrderData.solution.solution_id == 0)
                {
                    response = client.PostAsJsonAsync("api/_Solution/CreateSolutionData", OrderRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<tbl_Solution>().Result;
                        return result.solution_id.ToString();


                    }
                }
                else
                {
                    response = client.PutAsJsonAsync("api/_Solution/UpdateSolutionData", OrderRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<string>().Result;
                        if (result == "Successful")
                        {
                            return "Successful";
                        }

                    }
                }

            }




            return "Successful";
        }

        public static string UpdateSolutionEmailSent(tbl_Solution OrderData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var OrderRequest = Newtonsoft.Json.JsonConvert.SerializeObject(OrderData);
                HttpResponseMessage response = client.PutAsJsonAsync(" api/_Solution/UpdateSolutionEmail", OrderRequest).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<string>().Result;
                    if (result == "Successful")
                    {
                        return "Successful";
                    }
                }
            }




            return "Successful";
        }

        public static void PrintInfoPdf()
        {
            //int index_current = 0;
            //string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            //int count_page =2;
            //int img_count = 0;
            //Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            //PdfWriter.GetInstance(doc, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "" + "_Report.pdf", FileMode.Create));
            //doc.Open();
            //doc.AddCreationDate();
            //doc.AddAuthor("");
            //doc.AddTitle( "Info's_Report");
            //doc.AddCreator("");
            //doc.AddHeader("first", "Header");
            //iTextSharp.text.Font black = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            //iTextSharp.text.Font blue = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.BLUE);
          
            //    doc.NewPage();
            //    Paragraph p_of_img2 = new Paragraph("Please Perform Slicing (IPR) in the Indicated Spots", FontFactory.GetFont("Arial", 12, iTextSharp.text.BaseColor.RED));
            //    p_of_img2.Alignment = Element.ALIGN_CENTER;
                
            //        Chunk c1 = new Chunk("Doctor : ", black);
            //        Chunk c2 = new Chunk("test", blue);
            //        //Chunk c3 = new Chunk("Patient : ", black);
            //        //Chunk c4 = new Chunk(label1.Text, blue);
            //        //Chunk c5 = new Chunk("Date : ", black);
            //        //Chunk c6 = new Chunk(label7.Text, blue);
            //        //Chunk c7 = new Chunk("Upper Aligner : ", black);
            //        //Chunk c8 = new Chunk(label3.Text, blue);
            //        //Chunk c9 = new Chunk("Lower Aligner : ", black);
            //        //Chunk c10 = new Chunk(label4.Text, blue);
            //        //Chunk c11 = new Chunk("Duration of Each Aligner : ", black);
            //        //Chunk c12 = new Chunk(label10.Text, blue);
            //        Phrase docName = new Phrase();
            //        docName.Add(c1);
            //        docName.Add(c2);
            //        //Phrase patName = new Phrase();
            //        //patName.Add(c3);
            //        //patName.Add(c4);
            //        //Phrase date = new Phrase();
            //        //date.Add(c5);
            //        //date.Add(c6);
            //        //Phrase Upper = new Phrase();
            //        //Upper.Add(c7);
            //        //Upper.Add(c8);
            //        //Phrase lower = new Phrase();
            //        //lower.Add(c9);
            //        //lower.Add(c10);
            //        //Phrase duration = new Phrase();
            //        //duration.Add(c11);
            //        //duration.Add(c12);
            //        Paragraph p1 = new Paragraph(docName);
            //        //Paragraph p2 = new Paragraph(patName);
            //        //Paragraph p3 = new Paragraph(date);
            //        //Paragraph p4 = new Paragraph(Upper);
            //        //Paragraph p6 = new Paragraph(duration);
            //        //Paragraph p5 = new Paragraph(lower);
            //        PdfPTable tbl = new PdfPTable(2);
            //        tbl.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //        tbl.AddCell(p1);
            //        tbl.DefaultCell.HorizontalAlignment = 2;
                    //tbl.AddCell(p6);
                    //tbl.DefaultCell.HorizontalAlignment = 0;
                    //tbl.AddCell(p2);
                    //tbl.DefaultCell.HorizontalAlignment = 2;
                    //tbl.AddCell(p4);
                    //tbl.DefaultCell.HorizontalAlignment = 0;
                    //tbl.AddCell(p3);
                    //tbl.DefaultCell.HorizontalAlignment = 2;
                    //tbl.AddCell(p5);
                 //   System.Drawing.Image logo_img = System.Drawing.Image.FromHbitmap(Properties.Resources.Add_icon.GetHbitmap());
                   // iTextSharp.text.Image logo_head = iTextSharp.text.Image.GetInstance(logo_img, System.Drawing.Imaging.ImageFormat.Png);
                  //  logo_head.ScaleToFit(100f, 350f);
                    //logo_head.Alignment = Element.ALIGN_MIDDLE;
                    //logo_head.BackgroundColor = null;
                 //   iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(UriPath + "\\images" + "\\1.jpeg");
                  //  img1.ScaleToFit(320f, 380f);
                  //  img1.Alignment = Element.ALIGN_MIDDLE;
                  ////  iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(UriPath + "\\images" + "\\2.jpeg");
                  //  img2.ScaleToFit(320f, 380f);
                  //  img2.Alignment = Element.ALIGN_MIDDLE;
                   // doc.Add(logo_head);
                    //doc.Add(tbl);
                  //  doc.Add(img1);
                    //if (arraySlicingNotExist[index_current] == 2)
                    //{
                    //    doc.Add(p_of_img2);
                    //    doc.Add(img2);
                    //    index_current++;
                    //}
                    //img_count = 3;
                //}
                //else
                //{
                    //for (int ins_img = 0; ins_img < 2; ins_img++)
                    //{
                    //    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(UriPath + "\\images\\" + img_count + ".jpeg");
                    //    img.ScaleToFit(350f, 380f);
                    //    img.Alignment = Element.ALIGN_MIDDLE;
                    //    if (ins_img == 1)
                    //    {
                    //        if (img_count == arraySlicingNotExist[index_current])
                    //        {
                    //            doc.Add(p_of_img2);
                    //            doc.Add(img);
                    //            index_current++;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        doc.Add(img);
                    //    }

                    //    img_count++;
                    //}
            //    }
            //}
            //doc.Close();
           // this.Close();
        }

        public static void testPrintFile()
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Chunk chunk = new Chunk("This is from chunk. ");
                document.Add(chunk);

                Phrase phrase = new Phrase("This is from Phrase.");
                document.Add(phrase);

                Paragraph para = new Paragraph("This is from paragraph.");
                document.Add(para);

                string text ="you are successfully created PDF file.";
                Paragraph paragraph = new Paragraph();
                paragraph.SpacingBefore = 10;
                paragraph.SpacingAfter = 10;
                paragraph.Alignment = Element.ALIGN_LEFT;
                paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
                paragraph.Add(text);
                document.Add(paragraph);

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                //Response.Clear();
                //Response.ContentType = "application/pdf";

                //string pdfName = "User";
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                //Response.ContentType = "application/pdf";
                //Response.Buffer = true;
                //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                //Response.BinaryWrite(bytes);
                //Response.End();
                //Response.Close();
            }
        }

        public static void IronPdf()
        {
            //var Renderer = new IronPdf.HtmlToPdf();
            //var PDF = Renderer.RenderHtmlAsPdf("<h1>Hello IronPdf</h1>");
            //var OutputPath = "HtmlToPDF.pdf";
            //PDF.SaveAs(OutputPath);
            //// This neat trick opens our PDF file so we can see the result in our default PDF viewer
            //System.Diagnostics.Process.Start(OutputPath);


            // Create a PDF from an existing HTML
            var Renderer = new IronPdf.HtmlToPdf();
            Renderer.PrintOptions.MarginTop = 50;  //millimeters
            Renderer.PrintOptions.MarginBottom = 50;
            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;
            Renderer.PrintOptions.Header = new SimpleHeaderFooter()
            {
                CenterText = "{pdf-title}",
                DrawDividerLine = true,
                FontSize = 16
            };
            Renderer.PrintOptions.Footer = new SimpleHeaderFooter()
            {
                LeftText = "{date} {time}",
                RightText = "Page {page} of {total-pages}",
                DrawDividerLine = true,
                FontSize = 14
            };
            var PDF = Renderer.RenderHtmlAsPdf("<h2>Service Request Information:	</h2>");
            var OutputPath = "Invoice.pdf";
            PDF.SaveAs(OutputPath);
            // This neat trick opens our PDF file so we can see the result
            System.Diagnostics.Process.Start(OutputPath);
        }



    }
}
