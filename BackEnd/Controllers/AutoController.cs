using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private IAutoDAL autoDAL;

        public AutoController()
        {
            autoDAL = new AutosDALImpl(new rabdContext());
        }

        [HttpPost]
        [Route("imagen")]
        public string UploadFile(string archivoNombre, byte[] imagenBytes, string nombreCarpeta)
        {
            try
            {
                var streamImagenBytes = new MemoryStream(imagenBytes);
                IFormFile fileAuto = new FormFile(streamImagenBytes, 0, streamImagenBytes.Length, archivoNombre, archivoNombre);
                //Variable que retorna el valor del resultado del metodo
                //El valor predeterminado es Falso (false)
                bool resultado = false;

                //La variable "file" recibe el archivo en el objeto Request.Form
                //Del POST que realiza la aplicacion a este servicio.
                //Se envia un formulario completo donde uno de los valores es el archivo
                //var file = Request.Form.Files[0];
                var file = fileAuto;

                //Variable donde se coloca la ruta relativa de la carpeta de destino
                //del archivo cargado
                string NombreCarpeta = "/Files/" + nombreCarpeta + "/";

                //Variable donde se coloca la ruta raíz de la aplicacion
                //para esto se emplea la variable "_env" antes de declarada
                string RutaRaiz = "E:\\";

                //Se concatena las variables "RutaRaiz" y "NombreCarpeta"
                //en una otra variable "RutaCompleta"
                string RutaCompleta = RutaRaiz + NombreCarpeta;


                //Se valida con la variable "RutaCompleta" si existe dicha carpeta            
                if (!Directory.Exists(RutaCompleta))
                {
                    //En caso de no existir se crea esa carpeta
                    Directory.CreateDirectory(RutaCompleta);
                }

                //Se valida si la variable "file" tiene algun archivo
                if (file.Length > 0)
                {
                    //Se declara en esta variable el nombre del archivo cargado
                    string NombreArchivo = file.FileName;

                    //Se declara en esta variable la ruta completa con el nombre del archivo
                    string RutaFullCompleta = Path.Combine(RutaCompleta, NombreArchivo);

                    //Se crea una variable FileStream para carlo en la ruta definida
                    using var stream = new FileStream(RutaFullCompleta, FileMode.Create);
                    file.CopyTo(stream);

                    //Como se cargo correctamente el archivo
                    //la variable "resultado" llena el valor "true"
                    resultado = true;

                }

                string rutaImagenBD = RutaCompleta.Replace(@"\/", @"\").Replace("/", @"\");
                rutaImagenBD += file.FileName;

                //Se retorna la variable "RutaCompleta" como resultado de una tarea
                return rutaImagenBD;
            }
            catch (Exception)
            {

                throw;
            }

        }


        private byte[]? ReadFile(string rutaImagenBD)
        {
            try
            {
                var findedFile = new FileStream(rutaImagenBD, FileMode.Open);
                byte[] formFile;
                if (findedFile != null)
                {
                    using var ms = new MemoryStream();
                    findedFile.CopyTo(ms);
                    formFile = ms.ToArray();
                    findedFile.Close();
                    return formFile;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static AutoModel ConvertirAutoImage(Auto auto, byte[] bytes)
        {
            try
            {
                if (auto != null)
                {

                    return new AutoModel
                    {
                        IdAuto = auto.IdAuto,
                        Marca = auto.Marca,
                        Modelo = auto.Modelo,
                        Anno = auto.Anno,
                        Capacidad = auto.Capacidad,
                        Color = auto.Color,
                        Disponibilidad = auto.Disponibilidad,
                        IdCategoria = auto.IdCategoria,
                        InsertadoPor = auto.InsertadoPor,
                        ModificadorPor = auto.ModificadorPor,
                        Placa = auto.Placa,
                        PrecioDia = auto.PrecioDia,
                        Transmision = auto.Transmision,
                        ImgURL = auto.ImgURL,
                        File = bytes
                    };

                }
                else
                    return new AutoModel();
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static AutoModel ConvertirAuto(Auto auto)
        {
            try
            {
                if (auto != null)
                {
                    return new AutoModel
                    {
                        IdAuto = auto.IdAuto,
                        Marca = auto.Marca,
                        Modelo = auto.Modelo,
                        Anno = auto.Anno,
                        Capacidad = auto.Capacidad,
                        Color = auto.Color,
                        Disponibilidad = auto.Disponibilidad,
                        IdCategoria = auto.IdCategoria,
                        InsertadoPor = auto.InsertadoPor,
                        ModificadorPor = auto.ModificadorPor,
                        Placa = auto.Placa,
                        PrecioDia = auto.PrecioDia,
                        Transmision = auto.Transmision,
                        ImgURL = auto.ImgURL
                    };
                }
                else
                    return new AutoModel();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Auto ConvertirAutoModel(AutoModel auto)
        {
            try
            {
                if (auto != null)
                {
                    return new Auto
                    {
                        IdAuto = auto.IdAuto,
                        Marca = auto.Marca,
                        Modelo = auto.Modelo,
                        Anno = auto.Anno,
                        Capacidad = auto.Capacidad,
                        Color = auto.Color,
                        Disponibilidad = auto.Disponibilidad,
                        IdCategoria = auto.IdCategoria,
                        InsertadoPor = auto.InsertadoPor,
                        ModificadorPor = auto.ModificadorPor,
                        Placa = auto.Placa,
                        PrecioDia = auto.PrecioDia,
                        Transmision = auto.Transmision,
                        ImgURL = auto.ImgURL
                    };
                }
                else
                    return new Auto();
                    
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("MostrarAutos")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Auto> listaAutos;
                listaAutos = autoDAL.GetAll();

                List<AutoModel> listaAutosModel = new();
                foreach (var item in listaAutos)
                {
                    if (item.ImgURL != null)
                    {
                        byte[] bytes = ReadFile(item.ImgURL);
                        listaAutosModel.Add(ConvertirAutoImage(item, bytes));
                    }
                    else
                    {
                        listaAutosModel.Add(ConvertirAuto(item));
                    }
                }

                return new JsonResult(listaAutosModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarAuto")]
        public JsonResult Get(int id)
        {
            try
            {
                Auto autos;
                autos = autoDAL.Get(id);

                if (autos.ImgURL != null)
                {
                    byte[] bytes = ReadFile(autos.ImgURL);
                    return new JsonResult(ConvertirAutoImage(autos, bytes));
                }

                return new JsonResult(ConvertirAuto(autos));
            }
            catch (Exception)
            {

                throw;
            }
        }
   
        [HttpPost]
        [Route("InsertarAuto")]
        public bool Post([FromBody] AutoModel auto)
        {
            try
            {
                if (auto.File != null)
                {
                    string archivoNombre = auto.Placa + auto.Anno + auto.ImgURL;
                    string nombreCarpeta = auto.Placa + auto.Anno;
                    auto.ImgURL = UploadFile(archivoNombre, auto.File, nombreCarpeta);
                }
                return autoDAL.Add(ConvertirAutoModel(auto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<AutoController>/5
        [HttpPut]
        [Route("ActualizarAuto")]
        public bool Put([FromBody] AutoModel auto)
        {
            try
            {
                return autoDAL.Update(ConvertirAutoModel(auto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("EliminarAuto")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                Auto auto = new() { IdAuto = id };
                return autoDAL.Remove(auto);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("MostrarAutoNombre")]
        public JsonResult Get(string marca)
        {
            try
            {
                IEnumerable<Auto> listaAutos;
                listaAutos = autoDAL.GetByName(marca);

                List<AutoModel> listaAutosModel = new();
                foreach (var item in listaAutos)
                {

                    if (item.ImgURL != null)
                    {
                        byte[] bytes = ReadFile(item.ImgURL);
                        listaAutosModel.Add(ConvertirAutoImage(item, bytes));
                    }
                    else
                    {
                        listaAutosModel.Add(ConvertirAuto(item));
                    }
                    //listaAutosModel.Add(ConvertirAuto(item));
                }

                return new JsonResult(listaAutosModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
