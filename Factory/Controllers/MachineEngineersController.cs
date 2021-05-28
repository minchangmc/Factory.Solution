using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachineEngineersController : Controller
  {
    private readonly FactoryContext _db;

    public MachineEngineersController(FactoryContext db)
    {
      _db = db;
    }
    public MachineEngineer FindMachineEngineer(int id) => _db.MachineEngineers
      .FirstOrDefault(cs => cs.MachineEngineerId == id);

    public MachineEngineer CheckEnrollment(int MachineId, int engineerId) => _db.MachineEngineers
      .FirstOrDefault(cs => (cs.EngineerId == engineerId && cs.EngineerId == MachineId));

    public void CreateNewEngineerMachine(int MachineId, int engineerId) => _db.MachineEngineers.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = engineerId });


    [HttpPost]
    public ActionResult Delete(int id, string redirectTo)
    {
      var thisMachineEngineer = FindMachineEngineer(id);
      _db.MachineEngineers.Remove(thisMachineEngineer);
      _db.SaveChanges();
      int entityId = 0;
      if (redirectTo == "Machines") entityId = thisMachineEngineer.MachineId;
      if (redirectTo == "Engineers") entityId = thisMachineEngineer.EngineerId;

      return RedirectToAction("Edit", redirectTo, new { id = entityId });
    }

    [HttpPost]
    public ActionResult Create(int id, int MachineId, string redirectTo)
    {
      bool engineerCertifiedMachine = CheckEnrollment(id, MachineId) != null;
      if (MachineId != 0 && !engineerCertifiedMachine)
      {
        CreateNewEngineerMachine(MachineId, id);
      }
      return RedirectToAction("Edit", redirectTo, new { id = id });
    }
  }
}