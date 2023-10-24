using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using NReco.PdfGenerator;
using System.Net.Mime;
using EmployeeRegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Office.Word;
using CsvHelper.Configuration;
using CsvHelper;
using NuGet.Packaging;
using System.Text;
using System.Net.Mail;
using System.Net;
using Rotativa.AspNetCore;
using System.Drawing;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Abstractions;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.Word;

namespace EmployeeRegistration.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _webhostenvironment;


        public EmployeeController(IWebHostEnvironment webhostenvironment)
        {

            _webhostenvironment = webhostenvironment;
        }





        string str = "Data Source=192.168.25.25;Initial Catalog = ENFINLiveTestDB; Persist Security Info=True;User ID = Dev_Test_CH; Password=RT78^yykh987";

        // GET: EmployeeController

        EmpDAL e = new EmpDAL();
        private ITempDataProvider _tempDataProvider;
        private IServiceProvider _serviceProvider;

        public ActionResult Index()
        {
            EmpDAL e = new EmpDAL();
            List<Emp> lst = e.GetDataList();
            return View(lst);

        }




        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.Hobbies = new List<string>
            {
                "Travelling",
                 "Cooking",
                 "Reading",
                 "Playing",
                 "Netsurfing",
            };


            ViewBag.States = GetCitiesByState();
            List<SelectListItem> states = GetCitiesByState();


            ViewBag.SelectedHobbies = new List<string>
            {
                "Travelling",
                 "Cooking",
                 "Reading",
                 "Playing",
                 "Netsurfing",
            };

            return PartialView();

        }

        [HttpPost]
        //public IActionResult Create(Emp e)
        //{
        //    if (Duplicate(e))
        //    {
        //        if (e.FormImageFile != null && e.FormPdfFile != null)
        //        {
        //            ImageFileToLocalDirectory(e);

        //            PdfFileToLocalDirectory(e);



        //            e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + Path.GetExtension(e.FormImageFile.FileName);
        //            e.UploadPdf = $"{e.Firstname}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

        //        }

        //        else
        //        {


        //            e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + ".jpg";
        //           e.UploadPdf = e.Firstname + "_" +e.Lastname + "_" + e.Dateofbirth + ".pdf";

        //        }




        //        try
        //        {

        //            using SqlConnection con = new SqlConnection(str);
        //            con.Open();



        //            SqlCommand cmd = new SqlCommand("sp_MVC1", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@operation", "Insert");
        //            cmd.Parameters.AddWithValue("@First_name", e.Firstname);
        //            cmd.Parameters.AddWithValue("@Last_name",e.Lastname);
        //            cmd.Parameters.AddWithValue("@Date_of_birth", e.Dateofbirth);
        //            cmd.Parameters.AddWithValue("@Hobbies", string.Join(",", e.Hobbie));
        //            cmd.Parameters.AddWithValue("@Gender", e.Gender);
        //            cmd.Parameters.AddWithValue("@States", e.State);
        //            cmd.Parameters.AddWithValue("@City", e.City);
        //            cmd.Parameters.AddWithValue("@UploadImage",e.UploadImage);
        //            cmd.Parameters.AddWithValue("@UploadPdf", e.UploadPdf);
        //            cmd.Parameters.AddWithValue("@StateId", e.State);
        //            cmd.Parameters.AddWithValue("@CityId", e.City);


        //            int i = cmd.ExecuteNonQuery();

        //            con.Close();





        //            return RedirectToAction("Details");

        //        }
        //        catch
        //        {
        //            ViewBag.Hobbies = new List<string>
        //            {
        //               "Travelling",
        //                "Cooking",
        //                "Reading",
        //               "Playing",
        //               "Netsurfing",
        //            };

        //            return View();

        //        }

        //    }

        //    else
        //    {

        //        TempData["Message"] = "Employee already exist";
        //        return RedirectToAction("Details");
        //    }




        //}



        [HttpPost]
        //public IActionResult Create(Emp e)
        //{
        //    if (Duplicate(e))
        //    {
        //        if (e.FormImageFile != null && e.FormPdfFile != null)
        //        {
        //            ImageFileToLocalDirectory(e);
        //            PdfFileToLocalDirectory(e);
        //            e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + Path.GetExtension(e.FormImageFile.FileName);
        //            e.UploadPdf = $"{e.Firstname}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        //        }
        //        else
        //        {
        //            e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + ".jpg";
        //            e.UploadPdf = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + ".pdf";
        //        }

        //        try
        //        {
        //            using SqlConnection con = new SqlConnection(str);
        //            con.Open();

        //            SqlCommand cmd = new SqlCommand("sp_MVC1", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@operation", "Insert");
        //            cmd.Parameters.AddWithValue("@First_name", e.Firstname);
        //            cmd.Parameters.AddWithValue("@Last_name", e.Lastname);
        //            cmd.Parameters.AddWithValue("@Date_of_birth", e.Dateofbirth);
        //            cmd.Parameters.AddWithValue("@Hobbies", string.Join(",", e.Hobbie));
        //            cmd.Parameters.AddWithValue("@Gender", e.Gender);
        //            cmd.Parameters.AddWithValue("@States", e.State);
        //            cmd.Parameters.AddWithValue("@City", e.City);
        //            cmd.Parameters.AddWithValue("@UploadImage", e.UploadImage);
        //            cmd.Parameters.AddWithValue("@UploadPdf", e.UploadPdf);
        //            cmd.Parameters.AddWithValue("@StateId", e.State);
        //            cmd.Parameters.AddWithValue("@CityId", e.City);

        //            int i = cmd.ExecuteNonQuery();
        //            con.Close();

        //            // Check if the "Send Email" checkbox is checked and email address is provided
        //            if (e.SendEmail)
        //            {
        //                // Ensure you have the 'username' and 'password' values for SMTP credentials
        //                string username = "ashwinbawane1998@gmail.com";
        //                string password = "coyprrqwedeaelaf";

        //                bool emailSent = (e.SendEmail);

        //                if (emailSent)
        //                {
        //                    TempData["SuccessMessage"] = "Email sent successfully!";
        //                }
        //                else
        //                {
        //                    TempData["ErrorMessage"] = "Failed to send email. Please try again.";
        //                }

        //                // Send the email
        //                SendEmail(e.Email, e);
        //            }

        //            return RedirectToAction("Details");
        //        }
        //        catch
        //        {
        //            ViewBag.Hobbies = new List<string>
        //            {
        //           "Travelling",
        //           "Cooking",
        //           "Reading",
        //           "Playing",
        //           "Netsurfing",
        //            };

        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        TempData["Message"] = "Employee already exists";
        //        return RedirectToAction("Details");
        //    }
        //}

        


        public IActionResult Create(Emp e)
        {
            if (Duplicate(e))
            {
                if (e.FormImageFile != null && e.FormPdfFile != null)
                {
                    ImageFileToLocalDirectory(e);
                    PdfFileToLocalDirectory(e);
                    e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + Path.GetExtension(e.FormImageFile.FileName);
                    e.UploadPdf = $"{e.Firstname}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                }
                else
                {
                    e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + ".jpg";
                    e.UploadPdf = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + ".pdf";
                }

                try
                {
                    using SqlConnection con = new SqlConnection(str);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_MVC1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation", "Insert");
                    cmd.Parameters.AddWithValue("@First_name", e.Firstname);
                    cmd.Parameters.AddWithValue("@Last_name", e.Lastname);
                    cmd.Parameters.AddWithValue("@Date_of_birth", e.Dateofbirth);
                    cmd.Parameters.AddWithValue("@Hobbies", string.Join(",", e.Hobbie));
                    cmd.Parameters.AddWithValue("@Gender", e.Gender);
                    cmd.Parameters.AddWithValue("@States", e.State);
                    cmd.Parameters.AddWithValue("@City", e.City);
                    cmd.Parameters.AddWithValue("@UploadImage", e.UploadImage);
                    cmd.Parameters.AddWithValue("@UploadPdf", e.UploadPdf);
                    cmd.Parameters.AddWithValue("@StateId", e.State);
                    cmd.Parameters.AddWithValue("@CityId", e.City);

                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    // Check if the "Send Email" checkbox is checked and email address is provided
                    if (e.SendEmail)
                    {
                        // Ensure you have the 'username' and 'password' values for SMTP credentials



                       
                        string username = "ashwinbawane1998@gmail.com";
                        string password = "coyprrqwedeaelaf";

                        // Generate the PDF of the form
                        byte[] formPdfBytes = GenerateFormPdf(e);

                        

                        // Send the email with the attached PDF
                        bool emailSent = SendEmailWithAttachment(e.Email, e, username, password, formPdfBytes);

                        if (emailSent)
                        {
                            TempData["SuccessMessage"] = "Email sent successfully!";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Failed to send email. Please try again.";
                        }
                    }

                    return RedirectToAction("Details");
                }
                catch
                {
                    ViewBag.Hobbies = new List<string>
                    {
                      "Travelling",
                      "Cooking",
                      "Reading",
                      "Playing",
                     "Netsurfing",
                    };

                    return View();
                }
            }
            else
            {
                TempData["Message"] = "Employee already exists";
                return RedirectToAction("Details");
            }
        }

        private byte[] GenerateFormPdf(Emp emp)
        {
            var htmlContent = $@"
    
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{font - family: Arial, sans-serif;
            margin: 20px;
        }}
        h1 {{background - color: green;
            color: white;
            padding: 10px;
        }}
        h2 {{background - color: green;
            padding: 5px;
        }}
        p {{margin: 5px;
        }}
        input[type='text'] {{width: 100%;
            padding: 5px;
            margin: 5px ;
        }}
        input[type='radio'],
        input[type='checkbox'] {{margin: 0 5px;
        }}
        header {{position: fixed;
            top: 0px;
            left: 0px;
            right: 0px;
            background-color: green;
            color: white;
            text-align: center;
            padding: 10px;
        }}
        footer {{position: fixed;
            bottom: 0px;
            left: 0px;
            right: 0px;
            background-color: green;
            color: white;
            text-align: center;
            padding: 10px;
        }}
    </style>
</head>
<body>
    <header>
        <h1>ELECTRICITY / GAS CONTRACT</h1>
    </header>
    <p>Date:</p>
    <h2>Business Details</h2>
    <p>Business Name:</p>
    <p>Registered Company Name:</p>
    <p>Company Reg. No.:</p>
    <p>Business Type:
        <input type='radio' name='businessType' value='Ltd'> Ltd
        <input type='radio' name='businessType' value='PLC'> PLC
        <input type='radio' name='businessType' value='Charity'> Charity
        <input type='radio' name='businessType' value='PublicSector'> Public Sector
        <input type='radio' name='businessType' value='SoleTrader'> Sole Trader
        <input type='radio' name='businessType' value='Partnership'> Partnership
        <input type='radio' name='businessType' value='LLP'> LLP
        <input type='radio' name='businessType' value='LLC'> LLC
        <input type='radio' name='businessType' value='Other'> Other
    </p>
    <p>Are you a Micro-Business? <input type='checkbox' name='isMicroBusiness'> Yes <input type='checkbox' name='isMicroBusiness'> No</p>
    <h2>Billing Address</h2>
    <p>Address:</p>
    <p>Town/City:</p>
    <p>Postcode:</p>
    <h2>Payment Method:</h2>
    <p>Payment is due within 10 calendar days from the invoice date</p>
    <p>I would like to receive a paper copy of my invoices at the cost of £2.00 per invoice</p>
    
       <div class='container terms page-break' style='page-break-before:always;'>
    <h2>Declaration and Signature/s</h2>
    <p>I/We confirm I/We have read, understood and will adhere to the Pozitive Energy Terms and Conditions as stated on the Pozitive Energy website: <a href='www.pozitive.energy/terms-and-conditions'>www.pozitive.energy/terms-and-conditions</a>.</p>
    <p>I/We certify the meter/s to be supplied are used solely or in part for commercial purposes.</p>
    <p>I/We confirm I/We have authorization to act on behalf of my organization for signing this contract for the supply of energy to the meter/s stated within this contract.</p>
    <p>A second signatory is not mandatory</p>
    <p>Name: <input type='text' name='name1'></p>
    <p>Name: <input type='text' name='name2'></p>
    <p>Job Title: <input type='text' name='jobTitle1'></p>
    <p>Job Title: <input type='text' name='jobTitle2'></p>
    <p>Signature: <input type='text' name='signature1'></p>
    <p>Signature: <input type='text' name='signature2'></p>
    <p>Signed On: <input type='text' name='signedOn1'></p>
    <p>Signed On: <input type='text' name='signedOn2'></p>
    <h3>Unique Contract No. 59149</h3>
    <footer>
        <h3>Unique Contract No. 59149</h3>
        <p>Page 1 of 2</p>
    </footer>
    </div>
</body>
</html>
";


            var pdfBytes = GeneratePdf(htmlContent);

            return pdfBytes;
        }


        //private byte[] GenerateFormPdf(Emp e)
        //{
        //    var htmlContent = RenderViewToString("Views/Employee/FormPdfTemplate.cshtml", e);
        //    var pdfBytes = GeneratePdf(htmlContent);
        //    return pdfBytes;
        //}


        private byte[] GeneratePdf(string htmlContent)
        {
            var htmlToPdf = new HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);

            return pdfBytes;
        }

        



        private bool SendEmailWithAttachment(string toEmail, Emp emp, string username, string password, byte[] attachment)
        {
            // Send an email with an attachment (the PDF)

            // Example using the SmtpClient
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("ashwinbawane1998@gmail.com" ,"coyprrqwedeaelaf"); // Use provided username and password
                client.Port = 587; // Set the appropriate SMTP port
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true; // Enable SSL

                MailMessage message = new MailMessage();
                message.From = new MailAddress("ashwinbawane1998@gmail.com");
                message.To.Add(toEmail);
                message.Subject = "New Employee Information";
                message.Body = $"Hello,\n\nHere is the information of the new employee:\n\n" +
                    $"First Name: {emp.Firstname}\n" +
                    $"Last Name: {emp.Lastname}\n" +
                    $"Date of Birth: {emp.Dateofbirth}\n" +
                    $"Hobbies: {string.Join(", ", emp.Hobbie)}\n" +
                    $"Gender: {emp.Gender}\n" +
                    $"State: {emp.State}\n" +
                    $"City: {emp.City}\n\nRegards, Pozitive Energy, Mohali";

                // Add the PDF attachment
                message.Attachments.Add(new Attachment(new MemoryStream(attachment), "Registration Form.pdf", "application/pdf"));

                try
                {
                    client.Send(message);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }




        public ActionResult Details(int CurrentPage = 1, int RecordsPerPage = 3, string searchData = "")
        {
            int currentPage = CurrentPage;
            PagingData paginationData = new PagingData();
            List<Emp> employee = new List<Emp>();
            using SqlConnection con = new SqlConnection(str);
            {

                SqlCommand cmd = new SqlCommand("GetPagedData", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNumber", currentPage);
                cmd.Parameters.AddWithValue("@PageSize", RecordsPerPage);
                cmd.Parameters.AddWithValue("@searchData", searchData);


                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Emp emp = new Emp()
                    {
                        SerialNo = (long)reader["RowNum"],
                        Id = (Int32)reader["intid"],
                        Firstname = reader.GetString("strfirst_name"),
                        Lastname = reader.GetString("strlast_name"),
                        Dateofbirth = reader.GetString("dtedob"),

                        Hobbies = reader.GetString("strhobbies"),
                        Gender = reader.GetString("strgender"),
                        //State = reader.GetString("strstates"),
                        //City = reader.GetString("strcity"),
                        State = reader.GetString("StateName"),
                        City = reader.GetString("CityName"),
                        UploadImage = reader.GetString("uploadimage"),
                        UploadPdf = reader.GetString("uploadpdf"),


                    };
                    employee.Add(emp);
                }
                con.Close();

                paginationData.Data = employee;




                paginationData.RecordsPerPage = RecordsPerPage;
                paginationData.CurrentPage = CurrentPage;
                paginationData.SearchTerm = searchData;

                paginationData.TotalRecords = GetAllUser(paginationData.SearchTerm);



                if (TempData.ContainsKey("ErrorMessages"))
                {
                    var serializedErrorMessages = TempData["ErrorMessages"].ToString();
                    TempData["ErrorMessages"] = JsonConvert.DeserializeObject<List<string>>(serializedErrorMessages);
                }

                if (TempData.ContainsKey("DuplicateRecords"))
                {
                    var serializedDuplicateRecords = TempData["DuplicateRecords"].ToString();
                    TempData["DuplicateRecords"] = JsonConvert.DeserializeObject<List<string>>(serializedDuplicateRecords);
                }


                return PartialView(paginationData);







            }

        }


        // GET: EmployeeController/Edit/5

        public IActionResult Edit(int id)
        {

            ViewBag.States = GetCitiesByState();
            List<SelectListItem> states = GetCitiesByState();
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_MVC1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation", "GetById");
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Emp e = new Emp()
                    {
                        Id = reader.GetInt32("intid"),
                        Firstname = reader.GetString("strfirst_name"),
                        Lastname = reader.GetString("strlast_name"),
                        Dateofbirth = reader.GetString("dtedob"),
                        Hobbies = reader.GetString("strhobbies"),
                        Gender = reader.GetString("strgender"),
                        State = reader.GetString("strstates"),
                        City = reader.GetString("strcity"),
                        UploadImage = reader.GetString("uploadimage"),
                        UploadPdf = reader.GetString("uploadpdf"),
                    };


                    ViewBag.Hobbies = new List<string>
                    {
                      "Travelling",
                       "Cooking",
                       "Reading",
                       "Playing",
                      "Netsurfing",
                    };


                    ViewBag.SelectedHobbies = e.Hobbies.Split(',').Select(h => h.Trim()).ToList();

                    return View(e);
                }
            }

            return null;
        }


        [HttpPost]

        public IActionResult Edit(Emp e)
        {


            if (e.FormImageFile != null && e.FormPdfFile != null)
            {
                ImageFileToLocalDirectory(e);

                PdfFileToLocalDirectory(e);



                e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + Path.GetExtension(e.FormImageFile.FileName);
                e.UploadPdf = $"{e.Firstname}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";



            }

            else
            {

                e.UploadImage = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + ".jpg";
                e.UploadPdf = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth + ".pdf";
            }




            try
            {

                using SqlConnection con = new SqlConnection(str);
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("sp_MVC1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation", "Update");
                    cmd.Parameters.AddWithValue("@Id", e.Id);
                    cmd.Parameters.AddWithValue("@First_name", e.Firstname);
                    cmd.Parameters.AddWithValue("@Last_name", e.Lastname);
                    cmd.Parameters.AddWithValue("@Date_of_birth", e.Dateofbirth);
                    cmd.Parameters.AddWithValue("@Hobbies", string.Join(",", e.Hobbie));
                    cmd.Parameters.AddWithValue("@Gender", e.Gender);
                    cmd.Parameters.AddWithValue("@States", e.State);
                    cmd.Parameters.AddWithValue("@City", e.City);
                    cmd.Parameters.AddWithValue("@UploadImage", e.UploadImage);
                    cmd.Parameters.AddWithValue("@UploadPdf", e.UploadPdf);
                    cmd.Parameters.AddWithValue("@StateId", e.State);
                    cmd.Parameters.AddWithValue("@CityId", e.City);




                    cmd.ExecuteNonQuery();



                    con.Close();
                }

                return RedirectToAction("Details");


            }
            catch
            {

                ViewBag.Hobbies = new List<string>
                {
                  "Travelling",
                   "Cooking",
                   "Reading",
                  "Playing",
                  "Netsurfing",
                };


                return PartialView();

            }




        }



        public IActionResult Delete(int id)
        {
            using SqlConnection con1 = new SqlConnection(str);

            SqlCommand cmd1 = new SqlCommand("sp_MVC1", con1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@operation", "GetById");
            cmd1.Parameters.AddWithValue("@Id", id);

            con1.Open();


            SqlDataReader reader = cmd1.ExecuteReader();

            while (reader.Read())
            {

                string ImageFile = reader["UploadImage"].ToString();
                string PdfFile = reader["UploadPdf"].ToString();
                DeleteFile(ImageFile);
                DeleteFile(PdfFile);


            }

            try
            {
                using SqlConnection con = new SqlConnection(str);
                {
                    con.Open();




                    SqlCommand cmd = new SqlCommand("sp_MVC1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation", "Delete");
                    cmd.Parameters.AddWithValue("@Id", id);



                    cmd.ExecuteNonQuery();



                    con.Close();

                    return RedirectToAction("Details");

                }
            }

            catch
            {
                return View();
            }

        }



        public bool ImageFileToLocalDirectory(Emp e)
        {
            if (e.FormImageFile != null && e.FormImageFile.Length > 0)
            {
                var fileExtension = Path.GetExtension(e.FormImageFile.FileName);
                var allowedExtensions = new[] { ".JPG", ".PNG" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return false;
                }

                var fileName = e.Firstname + "_" + e.Lastname + "_" + e.Dateofbirth;
                string filePath = Path.Combine(_webhostenvironment.WebRootPath, fileName + fileExtension);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    e.FormImageFile.CopyTo(stream);
                }
            }
            return true;
        }


        public bool PdfFileToLocalDirectory(Emp e)
        {
            if (e.FormPdfFile != null && e.FormPdfFile.Length > 0)
            {
                var fileExtension = ".pdf";
                var fileName = $"{e.Firstname}_{DateTime.Now:yyyyMMdd_HHmmss}{fileExtension}";


                string filePath = Path.Combine(_webhostenvironment.WebRootPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    e.FormPdfFile.CopyTo(stream);
                }

                return true;
            }
            return false;
        }




        public IActionResult DownloadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }
            string filePath = Path.Combine(_webhostenvironment.WebRootPath, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var contentDisposition = new ContentDisposition
            {
                FileName = fileName,
                Inline = false,
            };

            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/octet-stream");

        }



        public IActionResult GetImage(string fileName)
        {
            var imagePath = Path.Combine(_webhostenvironment.WebRootPath, fileName);

            if (System.IO.File.Exists(imagePath))
            {
                var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(imageBytes, "image/jpeg");
            }

            else
            {
                return NotFound();
            }
        }


        public IActionResult GetPdf(string fileName)
        {

            var fileNameParts = Path.GetFileNameWithoutExtension(fileName).Split('_');
            if (fileNameParts.Length == 2)
            {
                var firstName = fileNameParts[0];
                var dateTimeString = fileNameParts[1];


                if (DateTime.TryParseExact(dateTimeString, "yyyyMMdd_HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
                {


                    var imageFileName = $"{firstName}_{dateTime:yyyyMMdd_HHmmss}.png";


                    var imagePath = Path.Combine(_webhostenvironment.WebRootPath, imageFileName);

                    if (System.IO.File.Exists(imagePath))
                    {
                        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                        return File(imageBytes, "image/png");
                    }
                }
            }

            return NotFound();
        }




        public bool Duplicate(Emp e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand("sp_MVC1", con);
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation", "ValidateUser");
                    cmd.Parameters.AddWithValue("@First_name", e.Firstname);
                    cmd.Parameters.AddWithValue("@Last_name", e.Lastname);
                    cmd.Parameters.AddWithValue("@Date_of_birth", e.Dateofbirth);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        return false;

                    }

                    return true;


                }


            }
        }

        public void DeleteFile(string fileName)
        {
            var pdfPath = Path.Combine(_webhostenvironment.WebRootPath, fileName);
            if (System.IO.File.Exists(pdfPath))
            {
                System.IO.File.Delete(pdfPath);
            }
        }



        public int GetAllUser(string searchData = "")
        {
            int count = 0;

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand("sp_MVC1", con);
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation", "GetAllUsers");
                    cmd.Parameters.AddWithValue("@searchData", searchData);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        count++;

                    }

                    return count;


                }


            }

        }


        //public JsonResult GetCities(int stateId)
        //{
        //    var cities = EmpDAL.GetCities();
        //    var selectedCities = cities.Where(city => city.StateID == stateId).Select(city => new { city.CityID, city.CityName });
        //    return new JsonResult(selectedCities);
        //}

        public JsonResult GetCitiesById(int stateId)
        {
            var cities = GetCities();
            var selectedCities = cities.Where(city => city.StateID == stateId).Select(city => new { city.CityID, city.CityName });
            return new JsonResult(selectedCities);
        }




        public List<City> GetCities()
        {
            var cities = new List<City>();
            using SqlConnection con = new SqlConnection(str);
            {
                SqlCommand cmd = new SqlCommand("sp_MVC1", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@operation", "GetCitiesByState");
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var City = new City
                    {
                        CityID = (int)dataReader["CityId"],
                        CityName = dataReader["CityName"].ToString(),
                        StateID = (int)dataReader["StateId"]
                    };
                    cities.Add(City);
                }
                con.Close();
            }

            return cities;
        }



        public List<SelectListItem> GetCitiesByState()
        {
            List<SelectListItem> AvailableStates = new List<SelectListItem>();
            using SqlConnection con = new SqlConnection(str);
            {
                SqlCommand cmd = new SqlCommand("sp_MVC1", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                cmd.Parameters.AddWithValue("@operation", "GetAllStates");
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var state = new SelectListItem()
                    {
                        Value = dataReader["StateId"].ToString(),
                        Text = dataReader["StateName"].ToString()
                    };
                    AvailableStates.Add(state);
                }
                con.Close();
            }
            return AvailableStates;
        }

        [HttpGet]
        public ActionResult Upload()
        {
            ViewBag.Hobbies = new List<string>
            {
              "Travelling",
              "Cooking",
              "Reading",
              "Playing",
              "Netsurfing",
            };


            ViewBag.States = GetCitiesByState();
            List<SelectListItem> states = GetCitiesByState();


            ViewBag.SelectedHobbies = new List<string>
            {
            "Travelling",
            "Cooking",
            "Reading",
            "Playing",
            "Netsurfing",
            };
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IFormFile UploadedFile)
        {
            var errorMessages = new List<string>();
            var duplicateRecords = new List<string>();

            try
            {
                //if (UploadedFile == null || UploadedFile.Length == 0)
                //{
                //    errorMessages.Add("Empty file. Please upload a valid file");
                //    TempData["ErrorMessages"] = JsonConvert.SerializeObject(errorMessages);
                //    TempData["DuplicateRecords"] = JsonConvert.SerializeObject(duplicateRecords);
                //    return RedirectToAction("Details");
                //}

                var usersList = new List<Emp>();

                if (Path.GetExtension(UploadedFile.FileName).ToLower() == ".xlsx")
                {
                    using (var package = new ExcelPackage(UploadedFile.OpenReadStream()))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var currentSheet = package.Workbook.Worksheets.FirstOrDefault();

                        if (currentSheet != null)
                        {
                            var noOfCol = currentSheet.Dimension.End.Column;
                            var noOfRow = currentSheet.Dimension.End.Row;

                            for (int rowIterator = 2; rowIterator < noOfRow; rowIterator++)
                            {
                                var user = new Emp
                                {
                                    Firstname = currentSheet.Cells[rowIterator, 1].Value?.ToString(),
                                    Lastname = currentSheet.Cells[rowIterator, 2].Value?.ToString(),
                                    Gender = currentSheet.Cells[rowIterator, 3].Value?.ToString(),
                                    Dateofbirth = currentSheet.Cells[rowIterator, 4].Value?.ToString(),
                                    Hobbies = currentSheet.Cells[rowIterator, 5].Value?.ToString(),
                                    State = currentSheet.Cells[rowIterator, 6].Value?.ToString(),
                                    City = currentSheet.Cells[rowIterator, 7].Value?.ToString(),
                                    StateID = int.TryParse(currentSheet.Cells[rowIterator, 8].Value?.ToString(), out int stateId) ? stateId : 0,
                                    CityID = int.TryParse(currentSheet.Cells[rowIterator, 9].Value?.ToString(), out int cityId) ? cityId : 0
                                };

                                if (string.IsNullOrEmpty(user.Firstname) || string.IsNullOrEmpty(user.Lastname) || string.IsNullOrEmpty(user.Dateofbirth) || string.IsNullOrEmpty(user.Gender) || string.IsNullOrEmpty(user.Hobbies) || string.IsNullOrEmpty(user.City) || string.IsNullOrEmpty(user.State))
                                {

                                    var individualErrorMessages = new List<string>();

                                    if (string.IsNullOrEmpty(user.Firstname))
                                    {
                                        individualErrorMessages.Add("First Name is empty");
                                    }

                                    if (string.IsNullOrEmpty(user.Lastname))
                                    {
                                        individualErrorMessages.Add("Last Name is empty");
                                    }

                                    if (string.IsNullOrEmpty(user.Dateofbirth))
                                    {
                                        individualErrorMessages.Add("Date of Birth is empty");
                                    }

                                    if (string.IsNullOrEmpty(user.Gender))
                                    {
                                        individualErrorMessages.Add("Gender is empty");
                                    }

                                    if (string.IsNullOrEmpty(user.Hobbies))
                                    {
                                        individualErrorMessages.Add("Hobbies are empty");
                                    }

                                    if (string.IsNullOrEmpty(user.City))
                                    {
                                        individualErrorMessages.Add("City is empty");
                                    }

                                    if (string.IsNullOrEmpty(user.State))
                                    {
                                        individualErrorMessages.Add("State is empty");
                                    }

                                    var errorMessage = string.Join(", ", individualErrorMessages);
                                    errorMessages.Add($"Row {rowIterator}: {errorMessage}");
                                }

                                usersList.Add(user);
                                var allErrorMessages = string.Join("; ", errorMessages);
                            }
                        }
                        else
                        {
                            errorMessages.Add("Excel file is empty.");
                        }
                    }
                }
                else if (Path.GetExtension(UploadedFile.FileName).ToLower() == ".csv")
                {
                    using (var streamReader = new StreamReader(UploadedFile.OpenReadStream()))
                    using (var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        var records = csvReader.GetRecords<Emp1>().ToList();

                        if (records.Any())
                        {
                            foreach (var emp in records)
                            {
                                var employee = new Emp
                                {
                                    Firstname = emp.Firstname,
                                    Lastname = emp.Lastname,
                                    Dateofbirth = emp.Dateofbirth,
                                    Hobbies = emp.Hobbies,
                                    Gender = emp.Gender,
                                    State = emp.State,
                                    City = emp.City,
                                    StateID = emp.StateID,
                                    CityID = emp.CityID
                                };
                                usersList.Add(employee);
                            }
                        }
                        else
                        {
                            errorMessages.Add("CSV file is empty.");
                        }
                    }
                }
                else
                {
                    errorMessages.Add("File format is not supported");
                }

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    int rowIterator = 0;
                    foreach (var user in usersList)
                    {
                        rowIterator++;
                        using (SqlCommand checkCmd = new SqlCommand("sp_MVC1", con))
                        {
                            checkCmd.CommandType = CommandType.StoredProcedure;
                            checkCmd.Parameters.AddWithValue("@operation", "ValidateUser");
                            checkCmd.Parameters.AddWithValue("@First_name", user.Firstname);
                            checkCmd.Parameters.AddWithValue("@Last_name", user.Lastname);
                            checkCmd.Parameters.AddWithValue("@Date_of_birth", user.Dateofbirth);
                            int count = (int)(checkCmd.ExecuteScalar() ?? 0);

                            if (count > 0)
                            {
                                duplicateRecords.Add($"Duplicate record found for First Name: {user.Firstname}, Last Name: {user.Lastname}, and Date of Birth: {user.Dateofbirth}, Row: {rowIterator}");

                            }
                        }

                        if (duplicateRecords.Count == 0 && !errorMessages.Any())
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_MVC1", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@operation", "Insert");
                                cmd.Parameters.AddWithValue("@First_name", user.Firstname);
                                cmd.Parameters.AddWithValue("@Last_name", user.Lastname);
                                cmd.Parameters.AddWithValue("@Date_of_birth", user.Dateofbirth);
                                cmd.Parameters.AddWithValue("@Hobbies", user.Hobbies);
                                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                                cmd.Parameters.AddWithValue("@States", user.State);
                                cmd.Parameters.AddWithValue("@City", user.City);
                                cmd.Parameters.AddWithValue("@UploadImage", user.UploadImage);
                                cmd.Parameters.AddWithValue("@UploadPdf", user.UploadPdf);
                                cmd.Parameters.AddWithValue("@StateId", user.StateID);
                                cmd.Parameters.AddWithValue("@CityId", user.CityID);

                                int i = cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessages.Add($"Excel file is empty");
            }

            TempData["ErrorMessages"] = JsonConvert.SerializeObject(errorMessages);
            TempData["DuplicateRecords"] = JsonConvert.SerializeObject(duplicateRecords);

            if (duplicateRecords.Count > 0 || errorMessages.Any())
            {
                return RedirectToAction("Details");
            }

            return RedirectToAction("Details");
        }










        [HttpGet]

        public IActionResult Export(string format)
        {
            List<Emp> usersList = new List<Emp>();

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_MVC1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation", "Select");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Emp e = new Emp()
                    {

                        Firstname = reader.GetString("strfirst_name"),
                        Lastname = reader.GetString("strlast_name"),
                        Dateofbirth = reader.GetString("dtedob"),
                        Hobbies = reader.GetString("strhobbies"),
                        Gender = reader.GetString("strgender"),
                        State = reader.GetString("strstates"),
                        City = reader.GetString("strcity"),
                        StateID = reader.GetInt32("StateId"),
                        CityID = reader.GetInt32("CityId"),
                    };
                    usersList.Add(e);
                }
            }

            if (format == "csv")
            {

                var csvBuilder = new StringBuilder();
                csvBuilder.AppendLine("First Name,Last Name,Gender,Date of Birth,Hobbies,State,City,StateID,CityID");

                foreach (var user in usersList)
                {
                    csvBuilder.AppendLine($"{user.Firstname},{user.Lastname},{user.Gender},{user.Dateofbirth},{user.Hobbies},{user.State},{user.City},{user.StateID},{user.CityID}");
                }

                byte[] fileBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
                return File(fileBytes, "text/csv", "users.csv");
            }
            else
            {

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Users");

                    worksheet.Cell(1, 1).Value = "First Name";
                    worksheet.Cell(1, 2).Value = "Last Name";
                    worksheet.Cell(1, 3).Value = "Gender";
                    worksheet.Cell(1, 4).Value = "Date of Birth";
                    worksheet.Cell(1, 5).Value = "Hobbies";
                    worksheet.Cell(1, 6).Value = "State";
                    worksheet.Cell(1, 7).Value = "City";
                    worksheet.Cell(1, 8).Value = "StateID";
                    worksheet.Cell(1, 9).Value = "CityID";


                    for (int i = 0; i < usersList.Count; i++)
                    {
                        var user = usersList[i];
                        worksheet.Cell(i + 2, 1).Value = user.Firstname;
                        worksheet.Cell(i + 2, 2).Value = user.Lastname;
                        worksheet.Cell(i + 2, 3).Value = user.Gender;
                        worksheet.Cell(i + 2, 4).Value = user.Dateofbirth;
                        worksheet.Cell(i + 2, 5).Value = user.Hobbies;
                        worksheet.Cell(i + 2, 6).Value = user.State;
                        worksheet.Cell(i + 2, 7).Value = user.City;
                        worksheet.Cell(i + 2, 8).Value = user.StateID;
                        worksheet.Cell(i + 2, 9).Value = user.CityID;
                    }


                    byte[] fileBytes;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        workbook.SaveAs(memoryStream);
                        fileBytes = memoryStream.ToArray();
                    }

                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "users.xlsx");
                }
            }
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult SendEmail(Emp emp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Get the recipient's email address from the form
        //        string toEmail = emp.Email;

        //        // Ensure you have the 'username' and 'password' values for SMTP credentials
        //        string username = "ashwinbawane1998@gmail.com";
        //        string password = "A@shwin123";

        //        // Call your email sending method
        //        SendEmail(toEmail, emp, username, password);

        //        // Optionally, you can add a success message or redirect to another page
        //        TempData["SuccessMessage"] = "Email sent successfully!";
        //        return RedirectToAction("Details"); // Redirect to another action
        //    }

        //    // If the model is not valid, return the view with validation errors
        //    return View(emp);
        //}

        public void SendEmail(string toEmail, Emp emp)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("ashwinbawane1998@gmail.com", "coyprrqwedeaelaf");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("ashwinbawane1998@gmail.com");
                message.To.Add(toEmail);
                message.Subject = "New Employee Information";
                message.Body = $"Hello,\n\nHere is the information of the new employee:\n\nFirst Name: {emp.Firstname}\nLast Name: {emp.Lastname}\nDate of Birth: {emp.Dateofbirth}\nHobbies: {string.Join(", ", emp.Hobbie)}\nGender: {emp.Gender}\nState: {emp.State}\nCity: {emp.City}\n\nRegards, Pozitive Energy, Mohali";

                client.Send(message);
            }
        }








        public IActionResult CommonView()
        {
            return View();
        }




    }


















}

