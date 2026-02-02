using Microsoft.AspNetCore.Mvc;
using ĐKCN.Models;

namespace ĐKCN.Controllers
{
    public class StudentController : Controller
    {
        private static List<Models.Student> students = new List<Models.Student>();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ShowKQ(Student student)
        {

            students.Add(student);

            int count = students.Count(s => s.ChuyenNganh == student.ChuyenNganh);

            ViewBag.MSSV = student.MSSV;
            ViewBag.HoTen = student.HoTen;
            ViewBag.ChuyenNganh = student.ChuyenNganh;
            ViewBag.SoLuong = count;

            return View();

        }
    }
}
