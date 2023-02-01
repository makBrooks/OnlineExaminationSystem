using OnlineExaminationSystem.Models;
using OnlineExaminationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Services
{
    public class OnlineExamService : IOnlineExamService
    {
        private readonly IAdminRepository _admin = null;
        private readonly IUserRepository _user = null;
        public OnlineExamService(IAdminRepository admin, IUserRepository user)
        {
            _admin = admin;
            _user = user;
        }

        public async Task<SetupMaster> BindSetupMaster()
        {
            try
            {
                return await _user.BindSetupMaster();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DeleteSub(int subid)
        {
            try
            {
                return await _admin.DeleteSub(subid);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> DeleteTech(int techid)
        {
            try
            {
                return await _admin.DeleteTech(techid);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> EditChangeProfile(UserEntity user)
        {
            try
            {
                return await _user.EditChangeProfile(user);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<SubjectMaster>> GetAllSubject(int techid)
        {
            try
            {
                return await _admin.GetAllSubject(techid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<SubjectMaster>> GetAllSubjectTable()
        {
            try
            {
                return await _admin.GetAllSubjectTable();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TechnologyMaster>> GetAllTechnology()
        {
            try
            {
                return await _admin.GetAllTechnology();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<UserEntity>> GetAllUser()
        {
            try
            {
                return await _admin.GetAllUser();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserEntity> GetByID(string userid)
        {
            try
            {
                return await _user.GetByID(userid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InsertUser(UserEntity user)
        {
            try
            {
                return await _user.InsertUser(user);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<UserEntity> Login(string uid, string pass)
        {
            try
            {
                return await _user.Login(uid, pass);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> SaveUpdateSub(SubjectMaster sub)
        {
            try
            {
                return await _admin.SaveUpdateSub(sub);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> SaveUpdateTech(TechnologyMaster tech)
        {
            try
            {
                return await _admin.SaveUpdateTech(tech);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> UpdateStatus(string uid)

        {
            try
            {
                return await _admin.UpdateStatus(uid);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> InsertSetUp(SetupMaster setup)
        {
            try
            {
                return await _admin.InsertSetUp(setup);
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }
        public async Task<List<TechnologyMaster>> GetTechById(int techid)
        {
            try
            {
                return await _admin.GetTechById(techid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> SaveQuestion(QuestionMaster que)
        {
            try
            {
                return await _admin.SaveQuestion(que);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> insertResultdetails(ResultDetails res)
        {
            try
            {
                return await _user.insertResultdetails(res);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<UserEntity> ViewResultbyId(string s)
        {
            try
            {
                return await _user.ViewResultbyId(s);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DeleteQuestion(int Qid)
        {
            try
            {
                return await _admin.DeleteQuestion(Qid);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<List<QuestionMaster>> GetAllQuestion()
        {
            try
            {
                return await _admin.GetAllQuestion();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<QuestionMaster> GetQuestionById(int Qid)
        {
            try
            {
                return await _admin.GetQuestionById(Qid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<SubjectMaster> GetSubjectById(int x)
        {
            try
            {
                return await _admin.GetSubjectById(x);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> UpdateCertificate(string UserId)
        {
            try
            {
                return await _admin.UpdateCertificate(UserId);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<List<UserEntity>> ViewAllResult()
        {
            try
            {
                return await _admin.ViewAllResult();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<QuestionMaster>> bindquestion()
        {
            try
            {
                return await _user.bindquestion();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResultDetails> ck_tbl_result(string userid)
        {
            try
            {
                return await _user.ck_tbl_result(userid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
