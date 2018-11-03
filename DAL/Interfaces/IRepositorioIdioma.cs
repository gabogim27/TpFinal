using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Interfaces
{
    public interface IRepositorioIdioma
    {
        List<IdiomaUsuario> GetAllLanguages();
        List<TraduccionControles> GetTranslationsByLanguageAndForm(Guid selectedLanguage, string formName);
    }
}
