using DAL.Interfaces;
using DAL.Utils;
using log4net;

namespace DAL.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class IdiomaDao : IIdiomaDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IdiomaDao));

        public List<IdiomaUsuario> GetAllLanguages()
        {
            try
            {
                string query = "Select * from Idioma";
                return SqlUtils.Exec<IdiomaUsuario>(query);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Ocurrió un error al leer los idiomas de la BD. Error: {0}", e.Message);
            }

            return null;
        }

        public List<TraduccionControles> GetTranslationsByLanguageAndForm(Guid selectedLanguage, string formName)
        {
            try
            {
                var query = string.Format(
                    "Select trad.* from traduccion trad inner join formulario form on form.IdFormulario = trad.IdFormulario" +
                    " inner join idioma id on id.IdIdioma = trad.IdIdioma" +
                    " where id.IdIdioma = '{0}' and form.NombreFormulario = '{1}'", selectedLanguage, formName);

                return SqlUtils.Exec<TraduccionControles>(query);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Ocurrio un error al traer las traducciones para el formulario: {0}. Error: {1}", formName, e.Message);
            }

            return null;
        }
    }
}
