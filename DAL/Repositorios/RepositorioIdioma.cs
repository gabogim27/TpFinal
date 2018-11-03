using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class RepositorioIdioma : IRepositorioIdioma
    {
        public IIdiomaDao IdiomaDao { get; set; }

        public RepositorioIdioma(IIdiomaDao idiomaDao)
        {
            this.IdiomaDao = idiomaDao;
        }
        public List<IdiomaUsuario> GetAllLanguages()
        {
            return IdiomaDao.GetAllLanguages();
        }

        public List<TraduccionControles> GetTranslationsByLanguageAndForm(Guid selectedLanguage, string formName)
        {
            return IdiomaDao.GetTranslationsByLanguageAndForm(selectedLanguage, formName);
        }
    }
}
