using School.Data.Entities;
using System;
using System.Collections.Generic;

namespace School.Services.Services.Contracts
{
    public interface IExportGradeServices
    {
        byte[] ExportProfessorGradesToExcel(IEnumerable<Guid> professors);

        byte[] ExportStudentGradesToExcel(IEnumerable<Guid> professors);
    }
}