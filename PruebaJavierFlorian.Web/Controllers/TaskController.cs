using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaJavierFlorian.Web.Controllers
{
    public class TaskController : Controller
    {
        WsTareas.WsTareas oWsTareas;

        // GET: Task
        public ActionResult Index(string userName = "", string finalizada = "")
        {
            oWsTareas = new WsTareas.WsTareas();
            List<Entities.Task> listTareas = new List<Task>();
            WsTareas.Task _tarea = null;

            try
            {
                if (!String.IsNullOrWhiteSpace(userName) && String.IsNullOrWhiteSpace(finalizada))
                {
                    _tarea = new WsTareas.Task();

                    _tarea.user = new WsTareas.User()
                    {
                        userName = userName
                    };
                }
                else if (String.IsNullOrWhiteSpace(userName) && !String.IsNullOrWhiteSpace(finalizada))
                {
                    _tarea = new WsTareas.Task()
                    {
                        finalizada = finalizada,
                        user = null
                    };
                }

                WsTareas.Task[] listTask = oWsTareas.ListTasks(_tarea);

                if (listTask.Count() > 0 || listTask != null)
                {
                    foreach (var item in listTask)
                    {
                        #region TryParse variables

                        int _id = 0;
                        int.TryParse(item.id, out _id);

                        bool _estado = false;
                        bool.TryParse(item.estado, out _estado);

                        DateTime startDate = DateTime.Now;
                        DateTime.TryParse(item.fechaCreacion, out startDate);

                        DateTime endDate = DateTime.Now;
                        DateTime.TryParse(item.fechaVencimiento, out endDate);


                        #endregion

                        listTareas.Add(new Task()
                        {
                            id = _id,
                            nombre = item.nombre,
                            descripcion = item.descripcion,
                            estado = _estado,
                            fechaCreacion = startDate,
                            fechaVencimiento = endDate,
                            user = new Entities.User() { userName = item.user.userName }
                        });
                    }

                    if (listTareas.Count() > 0 || listTareas != null)
                        return View(listTareas);
                }

                return View(listTareas);
            }
            catch (Exception ez)
            {
                return View(listTareas);
            }
        }



        // GET: Task/Create
        public ActionResult Create(string userName = "")
        {
            try
            {
                if (String.IsNullOrWhiteSpace(userName))
                    ViewBag.users = ListUsers();
                else
                {
                    ViewBag.user = userName;
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.user = null;
                throw;
            }
        }

        private List<SelectListItem> ListUsers()
        {
            oWsTareas = new WsTareas.WsTareas();
            List<WsTareas.User> listUsers = new List<WsTareas.User>();
            List<SelectListItem> listUsuarios = new List<SelectListItem>();
            try
            {
                var usuarios = oWsTareas.ListUsers();
                listUsuarios.Add(new SelectListItem() { Value = "0", Text = "Seleccionar... ", Selected = true });
                if (usuarios.Count() > 0 || usuarios != null)
                {
                    foreach (var item in usuarios)
                        listUsuarios.Add(new SelectListItem() { Value = item.id.ToString(), Text = item.nombre, Selected = true });
                }

                return listUsuarios;

            }
            catch (Exception)
            {
                return listUsuarios;
                throw;
            }
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(Task oTask)
        {
            oWsTareas = new WsTareas.WsTareas();
            try
            {
                WsTareas.Task tarea = new WsTareas.Task()
                {
                    nombre = oTask.nombre,
                    descripcion = oTask.descripcion,
                    fechaCreacion = oTask.fechaCreacion.ToString(),
                    fechaVencimiento = oTask.fechaVencimiento.ToString(),
                    user = new WsTareas.User() { userName = oTask.user.userName }
                };
                oWsTareas.CreateTask(tarea, tarea.user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Muestra la vista para editar
        /// </summary>
        /// <param name="id">tiene el id de la tarea</param>
        /// <returns>vista</returns>
        public ActionResult Edit(int id)
        {
            oWsTareas = new WsTareas.WsTareas();
            WsTareas.Task oTask = new WsTareas.Task();
            Entities.Task tarea = new Task();

            try
            {
                oTask.id = id.ToString();
                oTask = oWsTareas.GetTask(oTask);

                if (oTask != null)
                {
                    #region TryParse variables

                    int _id = 0;
                    int.TryParse(oTask.id, out _id);

                    bool _estado = false;
                    bool.TryParse(oTask.estado, out _estado);

                    DateTime startDate = DateTime.Now;
                    DateTime.TryParse(oTask.fechaCreacion.ToString(), out startDate);

                    DateTime endDate = DateTime.Now;
                    DateTime.TryParse(oTask.fechaVencimiento, out endDate);

                    #endregion

                    tarea = new Task()
                    {
                        id = _id,
                        nombre = oTask.nombre,
                        descripcion = oTask.descripcion,
                        estado = _estado,
                        fechaCreacion = startDate,
                        fechaVencimiento = endDate,
                        user = new Entities.User() { userName = oTask.user.userName }
                    };
                }

                return View(tarea);
            }
            catch (Exception ex)
            {
                return View(tarea);
            }
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(Entities.Task oTask)
        {
            oWsTareas = new WsTareas.WsTareas();
            WsTareas.Task tarea = new WsTareas.Task();
            try
            {
                tarea = new WsTareas.Task()
                {
                    id = oTask.id.ToString(),
                    nombre = oTask.nombre,
                    descripcion = oTask.descripcion,
                    fechaCreacion = oTask.fechaCreacion.ToString(),
                    fechaVencimiento = oTask.fechaVencimiento.ToString(),
                    estado = oTask.estado.ToString(),
                    user = new WsTareas.User() { userName = oTask.user.userName }
                };

                oWsTareas.EditTask(tarea);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }



        /// <summary>
        /// Elimna la tarea
        /// </summary>
        /// <param name="id">tiene el id de la tarea</param>
        /// <returns>Json</returns>
        [HttpPost]
        public JsonResult Delete(string id)
        {
            oWsTareas = new WsTareas.WsTareas();
            WsTareas.Task tarea = new WsTareas.Task();
            try
            {
                tarea.id = id;
                oWsTareas.DeleteTask(tarea);

                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
