using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Numerics;
using taller.Supermarket.Data;
using taller.Supermarket.Data.Entities;

namespace taller.Supermarket.Controllers
{
    public class AdministradoresController : Controller
    {
        private readonly DataContext _context;

        public AdministradoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //Para acciones que simplemente muestran datos.
        public async Task<IActionResult> Index()
        {
            List<Administrador> administrador = await _context.Administrador.ToListAsync();
            return View(administrador);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //Crea el administrador y lo mete en una base de datos.
        [HttpPost] //El post es cuando se crea o se actualiza registros.
        public async Task<IActionResult> Create(Administrador administrador)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(administrador);
                }

                await _context.Administrador.AddAsync(administrador); //Crea el queary (Instrucciones sql).
                await _context.SaveChangesAsync(); //Ejecuta el queary.

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                return RedirectToAction(nameof(Index));
            }
        }

        //EDIT
        [HttpGet]
        public async Task <IActionResult> Edit([FromRoute] int id) 
        {
            try 
            {
                Administrador? administrador = await _context.Administrador.FirstOrDefaultAsync(a => a.Cedula == id);
                Console.WriteLine(id);
                return View(administrador);
   
            
            } catch (Exception ex) 
            { 
                return RedirectToAction(nameof(Index));
            }
        }

        //EDIT
        [HttpPost]
        public async Task<IActionResult> Edit(Administrador administrador)
        {
            try
            {
                if (!ModelState.IsValid) //El model state nos valida si los campos estan cumpliendo con las validaciones
                {
                    return View(administrador);
                }

                //Crear el autor    
                _context.Administrador.Update(administrador); //Crea el queary

                await _context.SaveChangesAsync(); //Ejecuta el queary

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Administrador? administrador = await _context.Administrador.FirstOrDefaultAsync(a => a.Cedula == id);
            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





    }//Cierre de Controller.

 






    //Async: Significa que esta es una operación asíncrona, lo que permite que otras tareas se ejecuten mientras se espera la respuesta de la base de datos.

    //ModelState.IsValid: Verifica si los datos enviados por el formulario son válidos según las reglas de validación definidas en el modelo Administrador,
    //      Si hay errores, se vuelve a mostrar la vista con los errores para que el usuario los corrija.

    //FirstOrDefaultAsync = Va hasta la base de datos y va a buscar el primer registro que sea igual al id 

    //(a => a.Cedula == Cedula): Esta es una expresión lambda que define la condición de búsqueda.
    //      a representa cada administrador de la lista y a.Cedula == Cedula verifica si la cédula del administrador actual (a) es igual a la cédula que estamos buscando (Cedula).
   //        await: Indica que el código esperará hasta que se complete la búsqueda en la base de datos antes de continuar con la siguiente línea.
}
