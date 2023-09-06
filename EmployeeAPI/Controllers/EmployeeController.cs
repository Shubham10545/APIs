using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employee;
        private readonly IWebHostEnvironment _webHostEnvironment;
        

        public EmployeeController(IEmployeeService employee,IWebHostEnvironment webHostEnvironment)
        {
            _employee = employee;
            _webHostEnvironment = webHostEnvironment;
            
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public IActionResult GetAllRecords()
        {
            var response=this._employee.GetEmployees();
            return Ok(response);
        }


        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddRecords([FromForm] Employee request)
        {
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
            }
            using (FileStream filestream = System.IO.File.Create((_webHostEnvironment.WebRootPath + "\\Images\\" + request.files.FileName)))
            {
                request.files.CopyTo(filestream);
                filestream.Flush();
                //obj.ImageName = obj.files.FileName;
                //this._employee.FileUploads( obj);
                // return "\\Images\\" + request.files.FileName;
                return Ok(_employee.AddEmployee(request));
            }
        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee request)
        {
            return Ok(this._employee.UpdateEmployee(request));
        }


        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            return Ok(this._employee.DeleteEmployee(id));  
        }

       
        //[HttpPost]
        //[Route("AddFile")]


        //public string Upload([FromForm] Employee obj)
        //{
        //    if (obj.files.Length > 0)
        //    {
        //        try
        //        {
        //            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
        //            {
        //                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
        //            }
        //            using (FileStream filestream = System.IO.File.Create((_webHostEnvironment.WebRootPath + "\\Images\\" + obj.files.FileName)))
        //            {
        //                obj.files.CopyTo(filestream);
        //                filestream.Flush();
        //                //obj.ImageName = obj.files.FileName;
        //                //this._employee.FileUploads( obj);
                        

        //                return "\\Images\\" + obj.files.FileName;
        //            }
        //        }
        //        catch (Exception ex)

        //        {
        //            return ex.ToString();
        //        }

        //    }
        //    else
        //    {

        //        return "Upload Failed";

        //    }
        //}

    }
}
