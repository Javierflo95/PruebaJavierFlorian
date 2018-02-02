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
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Crea un usuario 
        /// </summary>
        /// <param name="oUser">objecto deonde esta los datos del usuario</param>
        /// <returns>vista</returns>
        [HttpPost]
        public ActionResult Create(User oUser)
        {
            oWsTareas = new WsTareas.WsTareas();

            try
            {
                WsTareas.User usuario = new WsTareas.User()
                {
                    userName = oUser.userName,
                    nombre = oUser.nombre,
                    apellido = oUser.apellido,
                    edad = oUser.edad.ToString(),
                    password = oUser.password,
                    crearTarea = oUser.crearTarea.ToString(),
                    estado = oUser.estado.ToString(),
                };
                oWsTareas.CreateUser(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(string userName)
        {
            oWsTareas = new WsTareas.WsTareas();
            WsTareas.User oUser = new WsTareas.User();
            Entities.User usuario = new Entities.User();

            try
            {
                if (!String.IsNullOrWhiteSpace(userName))
                {
                    oUser.userName = userName;

                    var user = oWsTareas.GetUse(oUser);
                    if (user != null)
                    {
                        #region TryParse variables

                        int _id = 0;
                        int.TryParse(user.id, out _id);

                        int _edad = 0;
                        int.TryParse(user.edad, out _edad);

                        bool _estado = false;
                        bool.TryParse(user.estado, out _estado);

                        bool _crearTarea = false;
                        bool.TryParse(user.crearTarea, out _crearTarea);
                        #endregion

                        usuario = new Entities.User()
                        {
                            id = _id,
                            userName = user.userName,
                            nombre = user.nombre,
                            apellido = user.apellido,
                            edad = _edad,
                            estado = _estado,
                            crearTarea = _crearTarea,
                            password = user.password
                        };
                    }
                    return View(usuario);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

       /// <summary>
       /// Actualiza el usuario
       /// </summary>
       /// <param name="oUser">Objeto usuario</param>
       /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(User oUser)
        {
            oWsTareas = new WsTareas.WsTareas();
            WsTareas.User usuario = new WsTareas.User();
            try
            {
                usuario = new WsTareas.User()
                {
                    id = oUser.id.ToString(),
                    userName = oUser.userName,
                    nombre = oUser.nombre,
                    apellido = oUser.apellido,
                    edad = oUser.edad.ToString(),
                    estado = oUser.estado.ToString(),
                    password = oUser.password,
                    crearTarea = oUser.crearTarea.ToString()
                };

                oWsTareas.EditUser(usuario);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        /// <summary>
        /// Elimina el usuario
        /// </summary>
        /// <param name="userName">Contiene el nombre del usuario</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string userName)
        {
            oWsTareas = new WsTareas.WsTareas();
            WsTareas.User oUser = new WsTareas.User();
            try
            {
                oUser.userName = userName;
                oWsTareas.DeleteUser(oUser);
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
