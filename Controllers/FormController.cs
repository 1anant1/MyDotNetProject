using Microsoft.AspNetCore.Mvc;
using Registration_Form.Data;
using Registration_Form.Models;

namespace Registration_Form.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDbCotext _db;

        public FormController(ApplicationDbCotext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Registration obj)
        {
            var IsUserExist = _db.Registrations.Where(c=>c.Email.Equals(obj.Email)).FirstOrDefault();
           
            var IsUserExistNew =  (from db in _db.Registrations
                                  where db.Email == obj.Email
                                  select db).FirstOrDefault();
            if (IsUserExist == null)
            {
                if (ModelState.IsValid)
                {
                    _db.Registrations.Add(obj);
                    _db.SaveChanges();
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "User already exist please try with other email id:)";
                
            }
            return View();

            

        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(Registration obj)
        {
            var IsUserExistNew = (from db in _db.Registrations
                                  where db.UserName == obj.UserName  && db.ConfirmPassword == obj.ConfirmPassword
                                  select db).FirstOrDefault();

            if (IsUserExistNew != null)
            {
                HttpContext.Session.SetString("UserName", IsUserExistNew.UserName);
               return RedirectToAction("QuestionOpt");

            }
            else
            {
                ViewBag.Message = "Either UserName or Passowrd is invalid";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Form( Registration obj)
        {
            obj.UserName = ViewBag.UserName;
            return View();
        }
        [HttpGet]
        public IActionResult QuestionOpt()
        {
            var UserName = HttpContext.Session.GetString("UserName").ToString();
            Login ologin=new Login();
            ologin.UserName = UserName;
            return View(ologin);
        }
        [HttpGet]
        public IActionResult ExamQuestion()
        {
            ExamQuestions Exam = _db.ExamQuestions.OrderBy(c => c.ExamQuestionId).FirstOrDefault();
            return View(Exam);
        }
        [HttpPost]
        public IActionResult ExamQuestion(ExamQuestions obj)
        {
            IEnumerable<ExamQuestions> Exam = _db.ExamQuestions;
            return View(Exam);

        }

    }
}

