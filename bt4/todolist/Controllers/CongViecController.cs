using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    public class CongViecController : Controller
    {
        private static List<CongViec> congViecs = new()
        {
             new CongViec { Id = 1, TenCongViec = "Đi chợ", TrangThaiHoanThanh = true },
            new CongViec { Id = 2, TenCongViec = "Chơi thể thao", TrangThaiHoanThanh = false },
            new CongViec { Id = 3, TenCongViec = "Làm bài tập", TrangThaiHoanThanh = false },
            new CongViec { Id = 4, TenCongViec = "Học bài", TrangThaiHoanThanh = true }
        };

        public IActionResult Index()
        {
            return View(congViecs);
        }

        public IActionResult Details(int id)
        {
            var cv = congViecs.FirstOrDefault(x => x.Id == id);
            return View(cv);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CongViec congViec)
        {
            if (congViecs.Any(x => x.Id == congViec.Id))
            {
                ModelState.AddModelError("Id", "Mã công việc đã tồn tại");
                return View(congViec);
            }
            if (congViecs.Any(x => x.TenCongViec == congViec.TenCongViec))
            {
                ModelState.AddModelError("TenCongViec", "Tên công việc đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return View(congViec);
            }
            congViecs.Add(congViec);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var cv = congViecs.FirstOrDefault(x => x.Id == id);
            return View(cv);
        }

        [HttpPost]
        public IActionResult Edit(CongViec updated)
        {
            var cv = congViecs.FirstOrDefault(x => x.Id == updated.Id);
            if (cv == null) return NotFound();
            if (congViecs.Any(x =>
        x.TenCongViec == updated.TenCongViec && x.Id != updated.Id))
            {
                ModelState.AddModelError("TenCongViec", "Tên công việc đã tồn tại");
                return View(updated);
            }
            cv.TenCongViec = updated.TenCongViec;
            cv.TrangThaiHoanThanh = updated.TrangThaiHoanThanh;

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var cv = congViecs.FirstOrDefault(x => x.Id == id);
            if (cv != null)
            {
                congViecs.Remove(cv);
            }
            return RedirectToAction("Index");
        }

    }
}
