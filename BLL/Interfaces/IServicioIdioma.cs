using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioIdioma
    {
        List<IdiomaUsuario> GetAllLanguages();
        List<TraduccionControles> GetTranslationsByLanguageAndForm(Guid selectedLanguage, string formName);
    }
}
