using System.Data;
using System.Linq;
using DAL;
using TimeSpan = System.TimeSpan;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;   
    using DAL.Impl;

    public class UsuarioBLL
    {
        //private BE.IService<Usuario> _objService;

        //public UsuarioBLL(IService<Usuario> objService)
        //{
        //    _objService = objService;
        //}

        //private UsuarioBLL()
        //{
        //}
        
        //private static UsuarioBLL instancia;

        //public static UsuarioBLL Getinstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new UsuarioBLL();
        //    }
        //    return instancia;
        //}

        //public bool logIn(string email,string contraseña)
        //{
        //    return _objService.LogIn(email,contraseña);
        //}


        //public bool Create(Usuario ObjAlta)
        //{
        //    return _objService.Create(ObjAlta);
        //}

        //public List<BE.Usuario> Retrive()
        //{
        //    return (List<Usuario>)(Object)_objService.Retrive();
        //}

        //public bool Delete(BE.Usuario ObjDel)
        //{
        //    return _objService.Delete(ObjDel);
        //}

        //public bool Update(BE.Usuario ObjUpd)
        //{
        //    return _objService.Update(ObjUpd);
        //}

        //public BE.Usuario GetById(Guid id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
