using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaAutoController : ControllerBase
    {
        private ICategoriaAutoDAL categoriaAutoDAL;

        public CategoriaAutoController()
        {
            categoriaAutoDAL = new CategoriaAutoDALImpl(new rabdContext());
        }
        private CategoriaModel ConvertirCategoria(CategoriaAuto categoriaAuto)
        {
            try
            {

                if (categoriaAuto != null)
                {

                    return new CategoriaModel
                    {
                        IdCategoria = categoriaAuto.IdCategoria,
                        NombreCategoria = categoriaAuto.NombreCategoria
                    };

                }
                else
                    return new CategoriaModel();

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private CategoriaAuto ConvertirCategoriaModel(CategoriaModel categoriaModel)
        {
            try
            {
                if (categoriaModel != null)
                {

                    return new CategoriaAuto
                    {
                        IdCategoria = categoriaModel.IdCategoria,
                        NombreCategoria = categoriaModel.NombreCategoria
                    };

                }
                else
                    return new CategoriaAuto();
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpGet]
        [Route("MostrarCategorias")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<CategoriaAuto> listaCategoriaAuto;
                listaCategoriaAuto = categoriaAutoDAL.GetAll();

                List<CategoriaModel> listacategoriaAutoModel = new();
                foreach (var item in listaCategoriaAuto)
                {
                    listacategoriaAutoModel.Add(ConvertirCategoria(item));
                }

                return new JsonResult(listaCategoriaAuto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarCategoria")]
        public JsonResult Get(int id)
        {
            try
            {

                CategoriaAuto categoriaAuto;
                categoriaAuto = categoriaAutoDAL.Get(id);

                return new JsonResult(ConvertirCategoria(categoriaAuto));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        [Route("ActualizarCategoria")]
        public bool Put([FromBody] CategoriaAuto categoriaAuto)
        {
            try
            {
                return categoriaAutoDAL.Update(categoriaAuto);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete]
        [Route("EliminarCategoria")]
        public bool Delete(int id)
        {
            try
            {
                CategoriaAuto categoriaAuto = new CategoriaAuto { IdCategoria = id };
                return categoriaAutoDAL.Remove(categoriaAuto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarCategoria")]

        public bool Post([FromBody] CategoriaModel categoriaAuto) 
        {

            try
            {
                return categoriaAutoDAL.Add(ConvertirCategoriaModel(categoriaAuto));
            }
            catch (Exception)
            {

                throw;
            }


        }

       
       

    }
}
