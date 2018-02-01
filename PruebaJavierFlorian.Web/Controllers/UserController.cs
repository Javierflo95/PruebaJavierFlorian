using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaJavierFlorian.Web.Controllers
{
    public class UserController : Controller
    {
        WsTareas.WsTareas oWsTareas;
        /// <summary>
        /// Muestra el listado de los usuarios
        /// </summary>
        /// <returns>vista</returns>
        public ActionResult Index()
        {
            oWsTareas = new WsTareas.WsTareas();
            List<Entities.User> _listUsers = new List<Entities.User>();
            try
            {
                WsTareas.User[] listUsers = oWsTareas.ListUsers();

                if (listUsers.Count() > 0 || listUsers != null)
                {
                    foreach (var item in listUsers)
                    {
                        int _edad = 0;
                        int.TryParse(item.edad, out _edad);


                        bool _crearTarea = false;
                        bool.TryParse(item.crearTarea, out _crearTarea);

                        bool _estado = false;
                        bool.TryParse(item.estado, out _estado);

                        _listUsers.Add(new Entities.User()
                        {
                            userName = item.userName,
                            nombre = item.nombre,
                            apellido = item.apellido,
                            edad = _edad,
                            password = item.password,
                            crearTarea = _crearTarea,
                            estado = _estado
                        });
                    }
                }
                return View(_listUsers);
            }
            catch (Exception)
            {

                throw;
            }
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User oUser)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User oUser)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: User/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                return Json("Ok", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}
