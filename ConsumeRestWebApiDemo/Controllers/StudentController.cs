using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ConsumeRestWebApiDemo.Models;
using System.Text;

namespace ConsumeRestWebApiDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private string url = "http://localhost:1512/api/StudentApi/";
        private HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Student> student = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var std = JsonSerializer.Deserialize<List<Student>>(result);
                student = std;
            }
            return View(student);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var std = JsonSerializer.Deserialize<Student>(result);
                if (std != null)
                {
                    student = std;
                }                
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            try
            {
                string student = JsonSerializer.Serialize(std);
                StringContent content = new StringContent(student, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url , content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["insert_message"] = "Student Added";
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var std = JsonSerializer.Deserialize<Student>(result);
                if (std != null)
                {
                    student = std;
                }
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student std)
        {
            try
            {
                string student = JsonSerializer.Serialize(std);
                StringContent content = new StringContent(student,Encoding.UTF8,"application/json");
                HttpResponseMessage response = client.PutAsync(url + std.id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["update_message"] = "Student Updated";
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var std = JsonSerializer.Deserialize<Student>(result);
                if (std != null)
                {
                    student = std;
                }
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                HttpResponseMessage response = client.DeleteAsync(url + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["delete_message"] = "Student Deleted";
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}