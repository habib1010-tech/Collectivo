using TransNetwork.Interfaces;
using TransNetwork.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static TransNetwork.Interfaces.Interfaces;

namespace TransNetwork.Data
{
    public class RoleService : IRoleService
    {
        private readonly IDapperService _dapperService;

        public RoleService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(RoleModel Role)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdRole", Role.IdRole, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("LibelleRole", Role.LibelleRole, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Role_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdRole");
            return Task.FromResult(ReturnValue);
        }

        public Task<RoleModel> GetById(int id)
        {
            var Role = Task.FromResult(_dapperService.Get<RoleModel>($"SELECT * FROM [role] WHERE IdRole = '{id}'", null, commandType: CommandType.Text));
            return Role;
        }

        public Task<int> Delete(int id)
        {
            var deleteRole = Task.FromResult(_dapperService.Execute($"DELETE FROM role WHERE IdRole = '{id}'", null, commandType: CommandType.Text));
            return deleteRole;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountRole = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM role WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountRole;
        }

        public Task<List<RoleModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Role = Task.FromResult(_dapperService.GetAll<RoleModel>($"SELECT IdRole,LibelleRole FROM role WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Role;
        }

        public Task<int> Update(RoleModel Role)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdRole", Role.IdRole);
            dbPara.Add("LibelleRole", Role.LibelleRole, DbType.String);
            var updateRole = Task.FromResult(_dapperService.Update<int>("Role_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateRole;
        }


    }
}