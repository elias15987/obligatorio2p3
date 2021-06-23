﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public interface IReposiory<T>
    {
        bool Alta(T obj);
        bool Baja(int id);
        bool Modificacion(T obj);
        List<T> TraerTodo();
        T BuscarPorId(int id);
    }
}
