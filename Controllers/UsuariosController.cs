using MeuCRUD.Models.Contexto;
using MeuCRUD.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCRUD.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto _contexto; // Instancia o contexto
        public UsuariosController(Contexto contexto) // Construtor da classe
        {
            _contexto = contexto;
        }



        public IActionResult Index() // Utiliza o Index como método LISTAR
        {
            var lista = _contexto.Usuario.ToList();
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
        public IActionResult Create(Usuario usuario)
        {
            if(ModelState.IsValid) // Validação
            {
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
            var usuario = _contexto.Usuario.Find(Id);
           
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
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
            var usuario = _contexto.Usuario.Find(Id);
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
            var usuario = _contexto.Usuario.Find(Id);
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
