﻿using Microsoft.AspNetCore.Mvc;
using Swagger_Demo.Models;
using Swagger_Demo.Repository.Contracts;
using Swagger_Demo.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
       

          
            public readonly IEmployee employeeServices;
            public EmployeeController(IEmployee employeeServices)
            {
                this.employeeServices = employeeServices;
            }

            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    var emps = employeeServices.GetEmployees();
                    var response = new ApiResponse();
                    if (emps.Count == 0)
                    {
                        response.data = emps;
                        response.error = "employees not found !";
                        response.status = 404;
                        response.message = "Employee record not avialable !";

                        return NotFound(response);
                    }
                    else
                    {
                        response.data = emps;
                        response.status = 200;
                        response.message = "Employee record found !";
                        return Ok(response);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //var emps = employeeServices.GetEmployees();
                ////var response = new ApiResponse();
                //if (emps.Count == 0)
                //{
                //    return NotFound(emps);
                //}
                //return Ok(emps);

            }

            [HttpGet]
            [Route("getemployeebyid/{id}")]

            public IActionResult Get(int id)
            {
                try
                {

                    var emps = employeeServices.GetEmployeeById(id);
                    var response = new ApiResponse();
                    if (emps == null)
                    {
                        response.data = emps;
                        response.status = 404;
                        response.message = $"Employee record with {id} not found !";
                        response.error = "Invalid employee id !";
                        return NotFound(response);
                    }
                    else
                    {
                        response.data = emps;
                        response.status = 200;
                        response.message = $"Employee record with {id}  found !";
                        return Ok(response);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            else
            {
                var result = employeeServices.CreateEmployee(employee);
                return Created("Get", result);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    var result = employeeServices.DeleteEmployee(id);
                    if (result)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Update(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            else
            {
                var result = employeeServices.UpdateEmployee(emp);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
