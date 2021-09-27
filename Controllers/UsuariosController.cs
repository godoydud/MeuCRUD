using MeuCRUD.Models.Contexto;
using MeuCRUD.Models.Entidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCRUD.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto _contexto; // Instancia o contexto
        private readonly IWebHostEnvironment _hostEnvironment;
        public UsuariosController(Contexto contexto, IWebHostEnvironment hostEnvironment) // Construtor da classe
        {
            _contexto = contexto;
            _hostEnvironment = hostEnvironment;
        }



        public IActionResult Index(string search) // Utiliza o Index como método LISTAR
        {
            List<Usuario> lista;
            if (!string.IsNullOrEmpty(search))
            {
                lista = _contexto.Usuario.Include(x => x.Imagem).Where(x => x.NomeUsuario.Contains(search)).ToList();

            }
            else
            {
                lista = _contexto.Usuario.Include(x => x.Imagem).ToList();
            }


            ViewBag.search = search;
            CarregaTipoUsuario();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var usuario = new Usuario();
            CarregaTipoUsuario();

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid) // Validação
            {
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(usuario.ImageFile.FileName);
                //string extension = Path.GetExtension(usuario.ImageFile.FileName);
                //usuario.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                //using (var fileStream = new FileStream(path,FileMode.Create))
                //{
                //    await usuario.ImageFile.CopyToAsync(fileStream);
                //}
                using (var memoryStream = new MemoryStream())
                {
                    await usuario.ImageFile.CopyToAsync(memoryStream);
                    usuario.Imagem = new UsuarioImagem() { Imagem = memoryStream.ToArray() };
                }

                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index"); // Se tudo OK, retorna ao index
            }
            CarregaTipoUsuario();
            return View(usuario); // Se houver informações faltando, retorna para o formulario com as infos anteriormente  inseridas no input
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var usuario = _contexto.Usuario.Include(x => x.Imagem).Where(x => x.Id == Id).FirstOrDefault();

            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuario2 = _contexto.Usuario.Include(x => x.Imagem).Where(x => x.Id == usuario.Id).FirstOrDefault();
                _contexto.UsuarioImagem.Remove(usuario2.Imagem);

                using (var memoryStream = new MemoryStream())
                {
                    await usuario.ImageFile.CopyToAsync(memoryStream);
                    usuario2.Imagem = new UsuarioImagem() { Imagem = memoryStream.ToArray() };
                }

                _contexto.Usuario.Update(usuario2);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                CarregaTipoUsuario();
                return View(usuario);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var usuario = _contexto.Usuario.Include(x => x.Imagem).Where(x => x.Id == Id).FirstOrDefault();
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(Usuario user)
        {
            var usuario = _contexto.Usuario.Find(user.Id);
            if (usuario != null)
            {
                _contexto.Usuario.Remove(usuario);
                _contexto.SaveChanges(); // Salva e faz a alteração do DB

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var usuario = _contexto.Usuario.Include(x => x.Imagem).Where(x => x.Id == Id).FirstOrDefault();
            CarregaTipoUsuario();
            return View(usuario);
        }


        [HttpGet]
        public IActionResult Listar(int Idade)
        {
            var usuario = _contexto.Usuario.Include(x => x.Imagem).Where(x => x.Idade == Idade).FirstOrDefault();
            CarregaTipoUsuario();
            return View(usuario);
        }

        public void CarregaTipoUsuario()
        {
            var ItensTipoUsuario = new List<SelectListItem>
            {
                new SelectListItem{ Value = "1", Text = "Administrador"},
                    new SelectListItem{ Value = "2", Text = "Técnico"},
                        new SelectListItem{ Value = "3", Text = "Usuário Comum"}

            };

            ViewBag.TiposUsuario = ItensTipoUsuario;
        }




    }
}
