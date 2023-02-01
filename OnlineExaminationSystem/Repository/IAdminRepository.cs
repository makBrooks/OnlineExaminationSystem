using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Repository
{
    public interface IAdminRepository
    {
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
        Task<List<QuestionMaster>> GetAllQuestion();
        Task<int> DeleteQuestion(int Qid);
        Task<QuestionMaster> GetQuestionById(int Qid);
        Task<SubjectMaster> GetSubjectById(int x);
        Task<int> UpdateCertificate(string UserId);
        Task<List<UserEntity>> ViewAllResult();
    }
}
