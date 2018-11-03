using BE;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicioIdioma : IServicioIdioma
    {
        public IRepositorioIdioma RepositorioIdioma;

        public ServicioIdioma(IRepositorioIdioma repositorioIdioma)
        {
            this.RepositorioIdioma = repositorioIdioma;
        }
        public List<IdiomaUsuario> GetAllLanguages()
        {
            return RepositorioIdioma.GetAllLanguages();
        }

        public List<TraduccionControles> GetTranslationsByLanguageAndForm(Guid selectedLanguage, string formName)
        {
            return RepositorioIdioma.GetTranslationsByLanguageAndForm(selectedLanguage, formName);
        }
    }
}
