using Microsoft.AspNetCore.Mvc;

namespace prboard.api.Controllers
{    
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public TransactionController()
        {
        }
        
        /*[HttpGet]
        [Route("{id}/fast-track-ownership")]
        public async Task<IActionResult> CompleteFromProductAsync([FromRoute] string id)
        {
            var entity = await _transactionRepository
                .Include(p => p.Tournament)
                .FirstOrDefaultAsync(p => p.StripeId == id && p.DeletedAt == null);
            
            if (entity == null)
                throw new HttpResponseException(404);

            if (entity.Status != TransactionStatus.Succeeded)
            {
                await _transactionUpdateService.ChangeTransactionStatusAsync(entity.Uuid, TransactionStatus.Processing);
            }

            await _productUserEditService.CreateAsync(entity.Uuid);

            var productVersion = await _tournamentRepository
                .Where(p => p.Product.Uuid == entity.PurchasedProduct.Uuid)
                .FirstOrDefaultAsync(p => p.Product.LatestApprovedVersionId == p.Id);

            var downloadRequestEntity = await _productVersionDownloadRequestCreateService.CreateAsync(productVersion.Uuid);

            var returnable = new ProductVersionDownloadLink
            {
                Uuid = downloadRequestEntity.Uuid,
                TransactionIdentifier = entity.Identifier
            };
            
            return Ok(returnable);
        }*/
    }
}