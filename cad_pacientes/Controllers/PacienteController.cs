using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using cad_pacientes.DAO;
using cad_pacientes.Models;
using System;

namespace cad_pacientes.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            PacienteDAO dao = new PacienteDAO();
            List<PacienteViewModel> lista = dao.Listagem();
            return View(lista);
        }
        public IActionResult Create()
        {
            PacienteViewModel paciente = new PacienteViewModel();
            paciente.Data_nascimento = DateTime.Now;

            PacienteDAO dao = new PacienteDAO();
            paciente.Id = dao.ProximoId();


            return View("Form", paciente);
        }
        public IActionResult Salvar(PacienteViewModel paciente)
        {
            try
            {
                PacienteDAO dao = new PacienteDAO();
                if (dao.Consulta(paciente.Id) == null)
                    dao.Inserir(paciente);
                else
                    dao.Alterar(paciente);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                PacienteDAO dao = new PacienteDAO();
                PacienteViewModel paciente = dao.Consulta(id);
                if (paciente == null)
                    return RedirectToAction("index");
                else
                    return View("Form", paciente);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                PacienteDAO dao = new PacienteDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

    }
}
