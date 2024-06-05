using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        //Aqui hay que agregar los repositorios
        ICategoriaRepository Categoria { get; }

        //Guardar los cambios realizados en una unidad de trabajo
        void Save();
    }
}
