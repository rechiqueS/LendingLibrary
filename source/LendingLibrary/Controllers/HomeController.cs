using LendingLibrary.Domain;
using LendingLibrary.Models;
using System.Web.Mvc;

namespace LendingLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoanRepository _loanRepository;

        public HomeController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public HomeController() : this(new LoanRepository(new LendingLibraryDbContext("LendingLibrary.Domain.LendingLibraryDbContext")))
        {
        }

        public ActionResult Index()
        {
            var model = new LendingModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LendingModel lendingModel)
        {
            _loanRepository.AddLoan(lendingModel.ItemDescription, lendingModel.BorrowerName);
            ViewBag.Message = "Successfully Lended";
            return View(lendingModel);
        }
    }
}