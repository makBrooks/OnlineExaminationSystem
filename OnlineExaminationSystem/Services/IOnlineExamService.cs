using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Services
{
    public interface IOnlineExamService
    {
        Task<UserEntity> GetByID(string userid);
        Task<SetupMaster> BindSetupMaster();
        Task<UserEntity> Login(string uid, string pass);
        Task<int> InsertUser(UserEntity user);
        Task<int> EditChangeProfile(UserEntity user);
        Task<int> UpdateStatus(string uid);
        Task<List<UserEntity>> GetAllUser();
        Task<int> SaveUpdateTech(TechnologyMaster tech);
        Task<int> SaveUpdateSub(SubjectMaster sub);
        Task<int> DeleteSub(int subid);
        Task<int> DeleteTech(int techid);
        Task<List<TechnologyMaster>> GetAllTechnology();
        Task<List<SubjectMaster>> GetAllSubject(int techid);
        Task<List<SubjectMaster>> GetAllSubjectTable();
        Task<int> InsertSetUp(SetupMaster setup);
        Task<List<TechnologyMaster>> GetTechById(int techid);
        Task<int> SaveQuestion(QuestionMaster que);
        Task<int> insertResultdetails(ResultDetails res);
        Task<UserEntity> ViewResultbyId(string str);
        Task<List<QuestionMaster>> GetAllQuestion();
        Task<int> DeleteQuestion(int Qid);
        Task<QuestionMaster> GetQuestionById(int Qid);
        Task<SubjectMaster> GetSubjectById(int x);
        Task<int> UpdateCertificate(string UserId);
        Task<List<UserEntity>> ViewAllResult();
        Task<List<QuestionMaster>> bindquestion();
        Task<ResultDetails> ck_tbl_result(string userid);
    }
}
