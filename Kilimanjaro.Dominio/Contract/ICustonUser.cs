
using System;
using System.Collections;
using System.Collections.Generic;
namespace Kilimanjaro.Dominio.Contract
{
    public interface ICustonUser<T> where T : class
    {
        T GetByLogin(string login);

        List<T> TypeListAll();
    }
}
