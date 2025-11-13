using Gobi.Consulting.Models;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Gobi.Consulting.Controllers
{
	public class ContactController(IConfiguration configuration) : Controller
    {
        [HttpPost]
        public async Task<JsonResult> Send(FormContactRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Para prosseguir, é necessário preencher todos os campos obrigatórios e estar ciente da nossa Política de Privacidade."
                });
            }

            var settingsApiKey = configuration.GetValue<string>("SEND_GRID_API_KEY");
            var settingsFrom = configuration.GetValue<string>("SEND_GRID_FROM");

            try
            {
                const string subject = "Gobi Consulting - Site";

                var content = $"""
                               <p><strong>Nome completo:</strong> {request.Name}</p>
                               <p><strong>Email corporativo:</strong> {request.Email}</p>
                               <p><strong>Celular:</strong> {request.Phone}</p>
                               <p><strong>Empresa:</strong> {request.CompanyName}</p>
                               <p><strong>Tamanho da Empresa:</strong> {request.CompanySize}</p>
                               <p><strong>Assunto:</strong></p>
                               <p>{request.Subject}</p>
                               """;

                var client = new SendGridClient(settingsApiKey);

                var from = new EmailAddress(settingsFrom, "Gobi Consulting");
                var to = new EmailAddress(settingsFrom, "Gobi Consulting");

                var msg = MailHelper.CreateSingleEmail(from, to, subject, string.Empty, content);
                
                var response = await client.SendEmailAsync(msg);

                var success = response.IsSuccessStatusCode;

                return Json(new
                {
                    success,
                    message = success
                        ? "Mensagem enviada com sucesso!"
                        : "Erro ao enviar mensagem"
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = false,
                    message = e.Message
                });
            }
        }
    }
}
