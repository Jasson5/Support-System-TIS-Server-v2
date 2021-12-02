﻿using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Support_System_Server_v2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            this._semesterService = semesterService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Semester> Post(Semester semester)
        {
            return _semesterService.AddSemester(semester);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Semester>> Get()
        {
            return Ok(_semesterService.ListSemesters());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Semester> GetById(int id)
        {
            var semester = _semesterService.GeyById(id);

            return Ok(semester);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _semesterService.DeleteSemester(id);

            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Semester> Update(Semester semester)
        {
            _semesterService.UpdateSemester(semester);

            return Ok(semester);
        }
    }

}