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
    public class AdminRepository : BaseRepository, IAdminRepository
    {
        string spName = "sp_OnlineExamAdmin";
        public AdminRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<int> DeleteSub(int subid)
        {
            try
            {
                var con = CreateConnection();
                if (con.State == ConnectionState.Closed) con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@subid", subid);
                param.Add("@mode", "deletesub");
                int x = await con.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> DeleteTech(int techid)
        {
            try
            {
                var con = CreateConnection();
                if (con.State == ConnectionState.Closed) con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@techid", techid);
                param.Add("@mode", "deletesub");
                int x = await con.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<List<SubjectMaster>> GetAllSubject(int techid)
        {
            try
            {
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@techid", techid);
                param.Add("@mode", "bindSub");
                var _sub = await con.QueryAsync<SubjectMaster>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _sub.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<SubjectMaster>> GetAllSubjectTable()
        {
            try
            {
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "fillsubtable");
                var _lstsubtbl = await con.QueryAsync<SubjectMaster>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _lstsubtbl.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<TechnologyMaster>> GetAllTechnology()
        {
            try
            {
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "bindtech");
                var _tech = await con.QueryAsync<TechnologyMaster>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _tech.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<UserEntity>> GetAllUser()
        {
            try
            {
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "bindallusers");
                var _user = await con.QueryAsync<UserEntity>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _user.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

       

        public async Task<int> SaveUpdateSub(SubjectMaster sub)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@subid", sub.subid);
                param.Add("@techid", sub.techid);
                param.Add("@subname", sub.subname);
                param.Add("@mode", "insupsub");
                int x = await cn.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> SaveUpdateTech(TechnologyMaster tech)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@techid", tech.techid);
                param.Add("@techname", tech.techname);
                param.Add("@mode", "insuptech");
                int x = await cn.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
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
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "upduserstatus");
                param.Add("@userid", uid);

                int x = await con.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return x;
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
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@noofque", setup.noofque);
                param.Add("@timeinminute", setup.timeinminute);
                param.Add("@Rules", setup.rules);
                param.Add("@mode", "insertsetup");
                int x = cn.Execute(spName, param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
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
                var con = CreateConnection();
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@techid", techid);
                param.Add("@mode", "getbyid");
                var _sub = await con.QueryAsync<TechnologyMaster>(spName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return _sub.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int> SaveQuestion(QuestionMaster que)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@slno", que.slno);
                param.Add("@techid", que.techid);
                param.Add("@subid", que.subid);
                param.Add("@question", que.question);
                param.Add("@opt1", que.opt1);
                param.Add("@opt2", que.opt2);
                param.Add("@opt3", que.opt3);
                param.Add("@opt4", que.opt4);
                param.Add("@ans", que.ans);
                param.Add("@mode", "insquemaster");
                int x = await cn.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
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
                var cn = CreateConnection();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "getallquestion");
                var lstprod = cn.Query<QuestionMaster>(spName, param, commandType: CommandType.StoredProcedure).ToList();
                cn.Close();
                return lstprod;
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
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@slno", Qid);
                param.Add("@mode", "deletequestion");
                int x = cn.Execute(spName, param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<QuestionMaster> GetQuestionById(int Qid)
        {
            try
            {
                var cn = CreateConnection();
                DynamicParameters param = new DynamicParameters();
                param.Add("@slno", Qid);
                param.Add("@mode", "getQuestionbyid");
                var lstprod = cn.Query<QuestionMaster>(spName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                cn.Close();
                return lstprod;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<SubjectMaster> GetSubjectById(int x)
        {
            var cn = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@subid", x);
            param.Add("@mode", "GetSubjectById");
            var lstprod = cn.Query<SubjectMaster>(spName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            cn.Close();
            return lstprod;
        }
        public async Task<int> UpdateCertificate(string UserId)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@userid", UserId);
                param.Add("@mode", "approvecertificate");
                int x = cn.Execute(spName, param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
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
                var cn = CreateConnection();
                DynamicParameters param = new DynamicParameters();
                param.Add("@mode", "ViewAllResult");
                var lstprod = cn.Query<UserEntity>(spName, param, commandType: CommandType.StoredProcedure).ToList();
                cn.Close();
                return lstprod;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
