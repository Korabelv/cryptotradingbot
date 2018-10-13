using CryptoTradingBotApp.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;

namespace CryptoTradingBotApp.Controllers
{
    public class MessageController : ApiController
    {
       [Route(@"api/message/update")] //webhook uri part
       public async Task<OkResult> Update([FromBody]Update update)
        {
            var commads = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            foreach(var command in commads)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}