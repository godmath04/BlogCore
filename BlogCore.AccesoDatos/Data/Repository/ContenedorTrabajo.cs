using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//La unidad de trabajo es donde se condensan todos los repositorios 
namespace BlogCore.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            //Instanciamos para que funcione correctamente 
            Categoria = new CategoriaRepository(_db);
            Articulo = new ArticuloRepository(_db);
        }

        public ICategoriaRepository Categoria {  get; private set; }
        public IArticuloRepository Articulo { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        //Guarda en la unidad de trabajo
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
