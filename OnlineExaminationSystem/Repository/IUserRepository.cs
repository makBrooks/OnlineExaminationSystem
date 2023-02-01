using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Repository
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByID(string userid);
        Task<SetupMaster> BindSetupMaster();
        Task<UserEntity> Login(string uid, string pass);
        Task<int> InsertUser(UserEntity user);
        Task<int> EditChangeProfile(UserEntity user);
        Task<int> insertResultdetails(ResultDetails res);
        Task<UserEntity> ViewResultbyId(string str);
        Task<List<QuestionMaster>> bindquestion();
        Task<ResultDetails> ck_tbl_result(string userid);
    }
}

