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
    public class RoleUtilisateurService : IRoleUtilisateurService
    {
        private readonly IDapperService _dapperService;

        public RoleUtilisateurService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(RoleUtilisateurModel Role)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdRole", Role.IdRole, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("IdUtilisateur", Role.IdUtilisateur, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("RoleUtilisateur_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdRole");
            return Task.FromResult(ReturnValue);
        }

        public Task<RoleUtilisateurModel> GetById(int idRole, int idUtilisateur)
        {
            var Role = Task.FromResult(_dapperService.Get<RoleUtilisateurModel>($"SELECT * FROM role_utilisateur WHERE IdRole = '{idRole}' AND IdUtilisateur = '{idUtilisateur}'", null, commandType: CommandType.Text));
            return Role;
        }

        public Task<int> Delete(int idRole, int idUtilisateur)
        {
            var deleteRole = Task.FromResult(_dapperService.Execute($"DELETE FROM role_utilisateur WHERE IdRole = '{idRole}' AND IdUtilisateur = '{idUtilisateur}'", null, commandType: CommandType.Text));
            return deleteRole;
        }

        public Task<int> Delete(int idUtilisateur)
        {
            var deleteRole = Task.FromResult(_dapperService.Execute($"DELETE FROM role_utilisateur WHERE IdUtilisateur = '{idUtilisateur}'", null, commandType: CommandType.Text));
            return deleteRole;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountRole = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM role_utilisateur WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountRole;
        }

        public Task<List<RoleUtilisateurModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Role = Task.FromResult(_dapperService.GetAll<RoleUtilisateurModel>($"SELECT role_utilisateur.IdRole,role_utilisateur.IdUtilisateur,NomUtilisateur,LibelleRole FROM role_utilisateur LEFT JOIN utilisateur ON utilisateur.IdUtilisateur =role_utilisateur.IdUtilisateur LEFT JOIN role ON role.IdRole = role_utilisateur.IdRole WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Role;
        }

       
    }
}