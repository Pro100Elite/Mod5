using AutoMapper;
using BL.Interfaces;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheTask.Models;

namespace TheTask.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmpService _service;
        private readonly ISalGradeService _salGradeService;
        private readonly IDeptService _deptService;
        private readonly IMapper _mapper;

        public EmpController(IEmpService service, ISalGradeService salGradeService, IDeptService deptService,  IMapper mapper)
        {
            _service = service;
            _salGradeService = salGradeService;
            _deptService = deptService;
            _mapper = mapper;
        }

        // GET: Emp
        public ActionResult Index()
        {
            var salGrade = _salGradeService.Get();
            var data = _service.Get(salGrade);
            var emps = _mapper.Map<IEnumerable<EmpPL>>(data);

            return View(emps);
        }

        public ActionResult GetHierarchy()
        {
            var salGrade = _salGradeService.Get();
            var data = _service.GetEmpHierarchy(salGrade);
            var emps = _mapper.Map<IEnumerable<EmpHierarchyPL>>(data);    

            return View(emps);
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            var depts = _deptService.Get();
            var mgr = _service.Get();

            var Depts = new SelectList(depts, "DEPTNO", "DNAME");
            var Mgr = new SelectList(mgr, "EMPNO", "ENAME");
            var Job = new SelectList(mgr.GroupBy(x =>x.JOB).Select(g => g.First()), "JOB", "JOB");
            var model = new EmpCreatePL { ListDept = Depts, ListMgr = Mgr, ListJob = Job};

            return View(model);
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(EmpCreatePL empPL)
        {
            var model = _mapper.Map<EmpBL>(empPL);
            _service.Create(model);

            return RedirectToAction("Index");
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(decimal id)
        {
            var depts = _deptService.Get();
            var mgr = _service.Get();

            var Depts = new SelectList(depts, "DEPTNO", "DNAME");
            var Mgr = new SelectList(mgr, "EMPNO", "ENAME");
            var Job = new SelectList(mgr, "JOB", "JOB");
            var data = _service.FindById(id);
            var model = _mapper.Map<EmpCreatePL>(data);

            model.ListDept = Depts;
            model.ListJob = Job;
            model.ListMgr = Mgr;

            return View(model);
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(EmpPL empPL)
        {
            var model = _mapper.Map<EmpBL>(empPL);

            _service.Update(model);

            return RedirectToAction("Index");
        }

        // POST: Emp/Delete/5
        [HttpDelete]
        public ActionResult Delete(decimal id)
        {
            _service.Remove(id);

            return new EmptyResult();
        }
    }
}
