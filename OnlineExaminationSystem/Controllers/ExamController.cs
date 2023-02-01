using DinkToPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OnlineExaminationSystem.Models;
using OnlineExaminationSystem.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Controllers
{
    public class ExamController : Controller
    {
        private readonly IOnlineExamService _service;

        public ExamController(IOnlineExamService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> LogIn()
        {
            return View();
        }
        public async Task<JsonResult> UserLogin(string UserId, string Passwd)
        {
            try
            {
                var x = await _service.Login(UserId, Passwd);

                if (x != null)
                {
                    if (x.userid == "Admin")
                    {
                        HttpContext.Session.SetString("userid", x.userid);
                        HttpContext.Session.SetString("username", x.username);
                        HttpContext.Session.SetString("userpassword", x.userpassword);
                        return Json(2);
                    }
                    else
                    {
                        HttpContext.Session.SetString("userid", x.userid);
                        HttpContext.Session.SetString("username", x.username);
                        HttpContext.Session.SetString("userphone", x.userphone);
                        HttpContext.Session.SetString("useremail", x.useremail);
                        HttpContext.Session.SetString("userpassword", x.userpassword);
                        return Json(3);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(0);
            }
            return Json(0);
        }
        public async Task<IActionResult> Registration()
        {
            try
            {
                List<TechnologyMaster> pc = new List<TechnologyMaster>();
                pc = await _service.GetAllTechnology();
                pc.Insert(0, new TechnologyMaster { techid = 0, techname = "Select One" });
                ViewBag.techid = pc;
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public async Task<JsonResult> SubCat_Bind(int catid)
        {
            try
            {
                var subcatList = await _service.GetAllSubject(catid);
                List<SelectListItem> scalist = new List<SelectListItem>();
                foreach (SubjectMaster dr in subcatList)
                {
                    scalist.Add(new SelectListItem { Text = dr.subname, Value = dr.subid.ToString() });
                }
                var jsonres = JsonConvert.SerializeObject(scalist);
                return Json(jsonres);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        public async Task<JsonResult> Subject_Bind(int TechId)
        {
            try
            {
                var subcatList = await _service.GetAllSubject(TechId);
                List<SelectListItem> scalist = new List<SelectListItem>();
                foreach (SubjectMaster dr in subcatList)
                {
                    scalist.Add(new SelectListItem { Text = dr.subname, Value = dr.subid.ToString() });
                }
                var jsonres = JsonConvert.SerializeObject(scalist);
                return Json(jsonres);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        public async Task<JsonResult> UserCreat(UserEntity obj)
        {
            try
            {
                if (await _service.GetByID(obj.userid) == null)
                {
                    var x = await _service.InsertUser(obj);
                    return Json(x);
                }
                else
                {
                    return Json(0);
                }
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }
        public async Task<IActionResult> AdminDashboard()
        {
            try
            {
                if (HttpContext.Session.GetString("username") != null)
                {
                    ViewBag.userName = HttpContext.Session.GetString("username");
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> UserDashboard()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.userName = HttpContext.Session.GetString("username");
                SetupMaster exinfo = await _service.BindSetupMaster();
                if (exinfo != null)
                {
                    ViewBag.Time = exinfo.timeinminute;
                    ViewBag.NoOFQuestion = exinfo.noofque;
                    ViewBag.Rules = exinfo.rules;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Exam");
            }
        }
        public async Task<IActionResult> ViewUser()
        {
            try
            {
                List<UserEntity> usr = await _service.GetAllUser();
                return View(usr);
            }
            catch (Exception ex)
            {
                return View(null);
            }
        }
        public async Task<JsonResult> GetAllUserDetails()
        {
            try
            {
                List<UserEntity> lstprod = await _service.GetAllUser();
                var jsonres = JsonConvert.SerializeObject(lstprod);
                return Json(jsonres);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        public IActionResult AddUpdateSubject()
        {
            return View();
        }
        public IActionResult AddUpdateTechnology()
        {
            return View();
        }
        public async Task<JsonResult> InsertTechnology(TechnologyMaster obj)
        {
            try
            {
                var x = await _service.SaveUpdateTech(obj);
                return Json(x);
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }
        public async Task<JsonResult> GetTechnologyById(int id)
        {
            try
            {
                List<TechnologyMaster> lsttech = await _service.GetTechById(id);
                var jsonres = JsonConvert.SerializeObject(lsttech);
                return Json(jsonres);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        public async Task<JsonResult> GetTechnology()
        {
            try
            {
                List<TechnologyMaster> lsttech = await _service.GetAllTechnology();
                var jsonres = JsonConvert.SerializeObject(lsttech);
                return Json(jsonres);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        public IActionResult QuestionCreate()
        {
            return View();
        }
        public async Task<IActionResult> SetUpInsert()
        {
            return View();
        }
        public async Task<JsonResult> SetupCreate(SetupMaster obj)
        {
            try
            {
                var x = await _service.InsertSetUp(obj);
                return Json(x);
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }
        
        public async Task<IActionResult> SaveQuestion()
        {
            try
            {
                List<TechnologyMaster> lstcat = new List<TechnologyMaster>();
                lstcat = await _service.GetAllTechnology();
                lstcat.Insert(0, new TechnologyMaster { techid = 0, techname = "--- Select ---" });
                ViewBag.Technology = lstcat;
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public async Task<JsonResult> CreateQuestion(QuestionMaster que)
        {
            try
            {
                var x = await _service.SaveQuestion(que);
                return Json(x);
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }
        public async Task<JsonResult> DeleteTech(int id)
        {
            try
            {
                var x = await _service.DeleteTech(id);
                return Json(x);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        public async Task<IActionResult> entersubject()
        {
            try
            {
                List<TechnologyMaster> pc = new List<TechnologyMaster>();
                pc = await _service.GetAllTechnology();
                pc.Insert(0, new TechnologyMaster { techid = 0, techname = "--- Select ---" });
                ViewBag.techid = pc;
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public async Task<JsonResult> entersubjectt(SubjectMaster sub)
        {
            try
            {
                var x = await _service.SaveUpdateSub(sub);
                return Json(x);
            }
            catch
            {
                return Json(0);
            }

        }
        public async Task<JsonResult> GetAllsub()
        {
            try
            {
                List<SubjectMaster> pd = await _service.GetAllSubjectTable();
                var jsonres = JsonConvert.SerializeObject(pd);
                return Json(jsonres);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public async Task<int> Deletesubject(int vid)
        {
            try
            {
                return await _service.DeleteSub(vid);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<IActionResult> ChangePassword()
        {
            try
            {
                if (HttpContext.Session.GetString("username") != null)
                {
                    var x = HttpContext.Session.GetString("userid");
                    UserEntity user = await _service.GetByID(x);
                    ViewBag.pwd = user.userpassword;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Exam");
                }
            }
            catch ( Exception ex)
            {
                return RedirectToAction("Index", "Exam");
            }
        }
        public async Task<JsonResult> ChangePwd(UserEntity obj)
        {
            try
            {
                obj.userid = HttpContext.Session.GetString("userid");
                var x = await _service.EditChangeProfile(obj);
                return Json(x);
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }
        public async Task<IActionResult> EditProfile()
        {
            try
            {
                if (HttpContext.Session.GetString("username") != null)
                {
                    UserEntity usr = await _service.GetByID(HttpContext.Session.GetString("userid"));
                    ViewBag.userName = usr.username;
                    ViewBag.Phone = usr.userphone;
                    ViewBag.email = usr.useremail;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Exam");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Exam");
            }
        }
        public async Task<JsonResult> UserUpdate(UserEntity obj)
        {
            try
            {
                obj.userid = HttpContext.Session.GetString("userid");
                if (obj.userpassword=="")
                {
                    var x = await _service.EditChangeProfile(obj);
                    return Json(x);
                }
                else
                {
                    var x = await _service.EditChangeProfile(obj);
                    return Json(x);
                }
                
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }
        public async Task<IActionResult> GetApprove(string id)
        {
            try
            {
                await _service.UpdateStatus(id);
                return RedirectToAction("ViewUser");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewUser");
            }
        }
        //public async Task<JsonResult> GetApprove(string id)
        //{            
        //    var x = await _service.UpdateStatus(id);            
        //    return Json(x);
        //}
        
       
       
        public async Task<JsonResult> GetQuestion()
        {
            List<QuestionMaster> lstprod = await _service.GetAllQuestion();
            var jsonres = JsonConvert.SerializeObject(lstprod);
            return Json(jsonres);
        }
        public async Task<IActionResult> giveExam()
        {
            UserEntity x = await _service.GetByID(HttpContext.Session.GetString("userid"));
            ViewBag.techname = x.techname;
            ViewBag.subname = x.subname;
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }
        public async Task<int> DeleteQue(int vid)
        {
            return await _service.DeleteQuestion(vid);
        }

        public async Task<JsonResult> GetQuestionById(int Qid)
        {
            QuestionMaster lstprod = await _service.GetQuestionById(Qid);
            var jsonres = JsonConvert.SerializeObject(lstprod);
            return Json(jsonres);
        }
        public async Task<JsonResult> GetSubjectById(int id)
        {
            SubjectMaster lstprod = await _service.GetSubjectById(id);
            var jsonres = JsonConvert.SerializeObject(lstprod);
            return Json(jsonres);
        }
        static int z;
        static int ck = 0;
        static int que_limit;

        static int x = 0;

        static ResultDetails tr = new ResultDetails();
        public async Task<JsonResult> BindQuestion()
        {
            if (ck == 0)
            {
                tr = await _service.ck_tbl_result(HttpContext.Session.GetString("userid"));
                ck++;
            }

            if (tr == null)
            {
                if (x == 0)
                {
                    SetupMaster no = await _service.BindSetupMaster();
                    que_limit = no.noofque;
                    x++;
                }
                QuestionMaster que = new QuestionMaster();
                for (int i = 0; i < que_limit; i++)
                {
                    List<QuestionMaster> lstprod = await _service.bindquestion();
                    que = lstprod[i];
                }
                que_limit--;
                if (que_limit < 0)
                {
                    return Json(3);
                }
                else
                {
                    var jsonres = JsonConvert.SerializeObject(que);
                    return Json(jsonres);
                }
            }
            else
            {
                return Json(4);
            }
        }
        //    public async Task<JsonResult> BindQuestion(int id)
        //{
        //    z = id;
        //    List<QuestionMaster> lstprod = await _service.bindquestion();
            
        //    int i;
        //    QuestionMaster que = new QuestionMaster();
        //    for (i = 0; i <= id; i++)
        //    {
        //        que = lstprod[i];
        //    }
        //    que.id = i;
        //    var jsonres = JsonConvert.SerializeObject(que);
        //    return Json(jsonres);
        //}
        public async Task<JsonResult> InsertResult(ResultDetails rslt)
        {
            SetupMaster no = await _service.BindSetupMaster();
            int y = no.noofque;
            if (y > z)
            {
                rslt.userid = HttpContext.Session.GetString("userid");
                rslt.slno = rslt.qid;
                var x = await _service.insertResultdetails(rslt);
                return Json(x);
            }
            else
            {
                return Json(3);
            }
        }
        public async Task<IActionResult> ViewResult()
        {
            return View(await _service.ViewResultbyId(HttpContext.Session.GetString("userid")));
        }


         public async Task<IActionResult> Approvecertificate(string id)
         {
             await _service.UpdateCertificate(id);
             return View("ViewAllResult", await _service.ViewAllResult());
         }

        public async Task<IActionResult> ViewAllResult()
        {

            return View(await _service.ViewAllResult());
        }
        public IActionResult logout()
        {
            //Delete the Session object.
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();

            HttpContext.Session.Remove("userid");
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();

            HttpContext.Session.Remove("userphone");
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("useremail");
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("userpassword");
            HttpContext.Session.Clear();
            ck = 0;
            x = 0;
            return RedirectToAction("Login");
        }
        public async Task<JsonResult> getTime()
        {
            SetupMaster t = new SetupMaster();
            t = await _service.BindSetupMaster();
            return Json(t.timeinminute);
        }
        [HttpGet]
        public ActionResult GetPdf()
        {
            //string filePath = "~/Download/"+ HttpContext.Session.GetString("username") + "result.pdf";
            //Response.Headers.Add("Content-Disposition", "inline; filename=" + HttpContext.Session.GetString("username") + "result.pdf");
            //return File(filePath, "application/pdf");
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"..\Download\" + HttpContext.Session.GetString("username") + "result.pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                //HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            //Convert(pdf);
            return RedirectToAction("ViewResult");
        }
    }
}
