﻿using DataAccess.Interfaces;
using DataAccess.Model;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            this._attendanceRepository = attendanceRepository;
        }
        public Attendance AddAttendance(Attendance attendance)
        {
            var result = _attendanceRepository.FindByDate(attendance.AttendanceDate, attendance.User.Id);
            var newAttendance = new Attendance();
            if (result == null)
            {
                newAttendance = _attendanceRepository.Add(attendance);
            }
            else
            {
                throw new ApplicationException("La asistencia en la fecha dada ya existe");
            }

            return newAttendance;
        }

        public void DeleteAttendance(int id)
        {
            var attendance = _attendanceRepository.FindById(id);

            if (attendance != null)
            {
                _attendanceRepository.Delete(attendance);
            }
        }


        public Attendance GeyById(int id)
        {
            return _attendanceRepository.FindById(id);
        }

        public ICollection<Attendance> ListAttendances()
        {
            var attendance = _attendanceRepository.ListAttendances();

            return attendance.ToList();
        }

        public ICollection<Attendance> ListAttendancesByCompany(string shortName)
        {
            var attendance = _attendanceRepository.ListAttendancesByCompany(shortName);

            return attendance.ToList();
        }

        public ICollection<GradeAverageVM> ListGradesByCompany(string companyName)
        {
            var attendance = _attendanceRepository.ListGradesByCompany(companyName);

            return attendance.ToList();
        }

        public void UpdateAttendance(Attendance attendance)
        {
            _attendanceRepository.Update(attendance);
        }
    }
}
