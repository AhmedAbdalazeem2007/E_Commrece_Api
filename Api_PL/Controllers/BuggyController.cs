


namespace Api_PL.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly FirstDataBase firstDatabase;

        public BuggyController(FirstDataBase firstDatabase)
        {
            this.firstDatabase = firstDatabase;
        }

        [HttpGet("not found")]
        public ActionResult Gatnotfoundrequest()
        {
            var prod = firstDatabase.Products.Find(100);
            if (prod is null)
                return NotFound(new ApiResponse(400));
            return Ok(prod);
        }
        [HttpGet("servererror")]
        public ActionResult Getservererror()
        {
            var prod = firstDatabase.Products.Find(100);
            var p = prod.ToString();
            return Ok(p);
        }
        [HttpGet("badrequest")]
        public ActionResult Getbadrequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest{id}")]
        public ActionResult GetBadrequest(int id)
        {
            if (ModelState.IsValid)
            {

            }
            return Ok();
        }

    }
}
