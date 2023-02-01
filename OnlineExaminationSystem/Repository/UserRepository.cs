using Dapper;
using Microsoft.Extensions.Configuration;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        string spName = "sp_OnlineExamUser";
        public UserRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<SetupMaster> BindSetupMaster()
        {
            try
            {
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "bindsetup");
                var _user = await con.QueryAsync<SetupMaster>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _user.ToList()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> EditChangeProfile(UserEntity user)
        {
            try
            {
                var con = CreateConnection();
                if (con.State == ConnectionState.Closed) con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@userid", user.userid);
                param.Add("@username", user.username);
                param.Add("@userpassword", user.userpassword);
                param.Add("@userphone", user.userphone);
                param.Add("@useremail", user.useremail);
                param.Add("@mode", "updatechange");
                int x = await con.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return x;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<UserEntity> GetByID(string userid)
        {
            try
            {
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@userid", userid);
                param.Add("@mode", "getbyid");
                var _user = await con.QueryAsync<UserEntity>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _user.ToList()[0];
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
                var con = CreateConnection();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "InsertUser");
                param.Add("@userid", user.userid);
                param.Add("@userpassword", user.userpassword);
                param.Add("@username", user.username);
                param.Add("@userphone", user.userphone);
                param.Add("@useremail", user.useremail);
                param.Add("@usertechnology", user.usertechnology);
                param.Add("@usersubject", user.usersubject);
                var x = await con.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<UserEntity> Login(string uid, string pass)
        {
            try
            {
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "login");
                param.Add("@userid", uid);
                param.Add("@userpassword", pass);
                var _user = await con.QueryAsync<UserEntity>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _user.ToList()[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> insertResultdetails(ResultDetails res)
        {
            try
            {
                var cn = CreateConnection();
                cn.Open();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@optchoose", res.optchoose);
                param.Add("@userid", res.userid);
                param.Add("@slno", res.slno);
                param.Add("@mode", "insertResultdetails");
                int x = cn.Execute(spName, param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<UserEntity> ViewResultbyId(string str)
        {
            try
            {
                var cn = CreateConnection();
                cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@userid", str);
                param.Add("@mode", "ViewResultbyId");
                var lstprod = cn.Query<UserEntity>(spName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                cn.Close();
                return lstprod;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<QuestionMaster>> bindquestion()
        {
            var cn = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@mode", "bindquestion");
            var lstprod = await cn.QueryAsync<QuestionMaster>(spName, param, commandType: CommandType.StoredProcedure);
            cn.Close();
            return lstprod.ToList();
        }
        public async Task<ResultDetails> ck_tbl_result(string userid)
        {
            var cn = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@userid", userid);
            param.Add("@mode", "ckresult");
            var lstprod = cn.Query<ResultDetails>(spName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            cn.Close();
            return lstprod;
        }
    }
}