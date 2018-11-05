using DAL.Interfaces;

namespace DAL.Impl
{
    using BE;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FamiliaDao : IDao<Familia>, IFamiliaDao
    {
        public IRepositorioBitacora RepositorioBitacora;

        public FamiliaDao(IRepositorioBitacora repositorioBitacora)
        {
            this.RepositorioBitacora = repositorioBitacora;
        }
        public bool Create(BE.Familia ObjAlta)
        {
            try
            {
                var sqlQuery = string.Format("@INSERT INTO dbo.Familia (idFamilia, Descripcion) values ('{0}', {1})", ObjAlta.IdFamilia.ToString(), ObjAlta.Descripcion);
                return SqlUtils.Exec(sqlQuery);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(), 
                    String.Format("Ocurrio un error al tratar de crear la familia: {0}. Error: {1}", ObjAlta.Descripcion, ex.Message));
            }

            return false;
        }

        public Familia GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Familia> Retrive()
        {
            try
            {
                var query = "Select * from Familia";
                return SqlUtils.Exec<Familia>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(), 
                    string.Format("Ocurrio un error al traer todas las familias de la base de datos. Error: {0}", ex.Message));
            }

            return null;
        }

        public bool Delete(Familia entity)
        {
            try
            {
                var query = string.Format("Delete Familia where IdFamilia = {0}", entity.IdFamilia);
                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(), 
                    string.Format("Ocurrio un error al eliminar la familia: {0}. Error: {1}", 
                        entity.Descripcion, ex.Message));
            }

            return false;
        }

        public bool Update(Familia entity)
        {
            try
            {
                var query = string.Format("Update Familia set Descripcion = {0} where IdFamilia = {1}",
                    entity.Descripcion, entity.IdFamilia);
                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(), 
                    string.Format("Ocurrio un error al actualizar la familia: {0}. Error: {1}", entity.Descripcion, ex.Message));
            }

            return false;
        }

        public bool GuardarFamiliaUsuario(List<Guid> familiaIds, Guid usuarioId)
        {
            try
            {
                //TODO: Implementar mas adelante
                foreach (var idFamilia in familiaIds)
                {
                    string processQuery = string.Format("INSERT INTO FamiliaUsuario (IdFamilia, IdUsuario) VALUES ('{0}', '{1}')", idFamilia, usuarioId);
                    SqlUtils.Connection().Execute(processQuery);
                }
                                                
                return true;
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al guardar en FamiliaUsuario idUsuario: {0}. Error: {1}",
                        usuarioId, ex.Message));
            }

            return false;
        }
    }
}
