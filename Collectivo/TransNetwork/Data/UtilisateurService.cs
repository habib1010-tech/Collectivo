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
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IDapperService _dapperService;

        public UtilisateurService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(UtilisateurModel Utilisateur)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdUtilisateur", Utilisateur.IdUtilisateur, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("NomUtilisateur", Utilisateur.NomUtilisateur, DbType.String, ParameterDirection.Input);
            dbPara.Add("Email", Utilisateur.Email, DbType.String, ParameterDirection.Input);
            dbPara.Add("MotDePasse", Utilisateur.MotDePasse, DbType.String, ParameterDirection.Input);
            dbPara.Add("IdRole", Utilisateur.IdRole, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("Mobile", Utilisateur.Mobile, DbType.String, ParameterDirection.Input);
            dbPara.Add("Nom", Utilisateur.Nom, DbType.String, ParameterDirection.Input);
            dbPara.Add("Prenom", Utilisateur.Prenom, DbType.String, ParameterDirection.Input);
            dbPara.Add("CompteActif", Utilisateur.CompteActif, DbType.Boolean, ParameterDirection.Input);
            dbPara.Add("IdCivilite", Utilisateur.IdCivilite, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("DateNaissance", Utilisateur.DateNaissance, DbType.DateTime, ParameterDirection.Input);
            dbPara.Add("IdGouvernorat", Utilisateur.IdGouvernorat, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("CodePostal", Utilisateur.CodePostal, DbType.String, ParameterDirection.Input);
            dbPara.Add("IdPays", Utilisateur.IdPays, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("IdDelegation", Utilisateur.IdDelegation, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("Ville", Utilisateur.Ville, DbType.String, ParameterDirection.Input);
            dbPara.Add("Adresse", Utilisateur.Adresse, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Utilisateur_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdUtilisateur");
            return Task.FromResult(ReturnValue);
        }

        public Task<UtilisateurModel> GetById(int id)
        {
            var Utilisateur = Task.FromResult(_dapperService.Get<UtilisateurModel>($"SELECT * FROM utilisateur WHERE IdUtilisateur = '{id}'", null, commandType: CommandType.Text));
            return Utilisateur;
        }

        public Task<UtilisateurModel> GetByEmail(string email)
        {
            var Utilisateur = Task.FromResult(_dapperService.Get<UtilisateurModel>($"SELECT * FROM utilisateur WHERE Email = '{email}'", null, commandType: CommandType.Text));
            return Utilisateur;
        }

        public Task<int> Delete(int id)
        {
            var deleteUtilisateur = Task.FromResult(_dapperService.Execute($"DELETE FROM utilisateur WHERE IdUtilisateur = '{id}'", null, commandType: CommandType.Text));
            return deleteUtilisateur;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountUtilisateur = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM utilisateur WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountUtilisateur;
        }

        public Task<List<UtilisateurModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Utilisateur = Task.FromResult(_dapperService.GetAll<UtilisateurModel>($"SELECT IdUtilisateur,NomUtilisateur,Email,MotDePasse,utilisateur.IdRole,LibelleRole, Mobile,Nom,Prenom,CompteActif,utilisateur.IdCivilite,LibelleCivilite, DateNaissance,utilisateur.IdGouvernorat,LibelleGouvernorat,CodePostal,utilisateur.IdPays,LibellePays,utilisateur.IdDelegation,LibelleDelegation,Ville,Adresse FROM utilisateur LEFT JOIN role ON role.IdRole = utilisateur.IdRole LEFT JOIN civilite ON civilite.IdCivilite = utilisateur.IdCivilite LEFT JOIN pays ON pays.IdPays = utilisateur.IdPays LEFT JOIN gouvernorat ON gouvernorat.IdPays = utilisateur.IdPays AND gouvernorat.IdGouvernorat = utilisateur.IdGouvernorat LEFT JOIN delegation ON delegation.IdGouvernorat = utilisateur.IdGouvernorat AND delegation.IdDelegation = utilisateur.IdDelegation WHERE 1 =1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Utilisateur;
        }

        public Task<int> Update(UtilisateurModel Utilisateur)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdUtilisateur", Utilisateur.IdUtilisateur, DbType.Int32);
            dbPara.Add("NomUtilisateur", Utilisateur.NomUtilisateur, DbType.String, ParameterDirection.Input);
            dbPara.Add("Email", Utilisateur.Email, DbType.String, ParameterDirection.Input);
            dbPara.Add("MotDePasse", Utilisateur.MotDePasse, DbType.String, ParameterDirection.Input);
            dbPara.Add("IdRole", Utilisateur.IdRole, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("Mobile", Utilisateur.Mobile, DbType.String, ParameterDirection.Input);
            dbPara.Add("Nom", Utilisateur.Nom, DbType.String, ParameterDirection.Input);
            dbPara.Add("Prenom", Utilisateur.Prenom, DbType.String, ParameterDirection.Input);
            dbPara.Add("CompteActif", Utilisateur.CompteActif, DbType.Boolean, ParameterDirection.Input);
            dbPara.Add("IdCivilite", Utilisateur.IdCivilite, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("DateNaissance", Utilisateur.DateNaissance, DbType.DateTime, ParameterDirection.Input);
            dbPara.Add("IdGouvernorat", Utilisateur.IdGouvernorat, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("CodePostal", Utilisateur.CodePostal, DbType.String, ParameterDirection.Input);
            dbPara.Add("IdPays", Utilisateur.IdPays, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("IdDelegation", Utilisateur.IdDelegation, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("Ville", Utilisateur.Ville, DbType.String, ParameterDirection.Input);
            dbPara.Add("Adresse", Utilisateur.Adresse, DbType.String, ParameterDirection.Input);
            var updateUtilisateur = Task.FromResult(_dapperService.Update<int>("Utilisateur_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateUtilisateur;
        }


    }
}