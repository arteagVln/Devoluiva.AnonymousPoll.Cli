using AutoMapper;
using Devoluiva.AnonymousPoll.CliV2.DBContext;
using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;
using Devoluiva.AnonymousPoll.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoluiva.AnonymousPoll.CliV2.Providers
{
    public class StudentProvider : IStudentProvider
    {
        private readonly StudentContext _context;
        public readonly IMapper _mapper;

        public StudentProvider(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Student[] GetStudents() => _mapper.Map<Student[]>(_context.Students.ToArray());
    }
}
