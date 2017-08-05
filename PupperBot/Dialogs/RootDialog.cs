using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace PupperBot.Dialogs {
    [Serializable]
    public class RootDialog : IDialog<object> {
        public Task StartAsync(IDialogContext context) {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result) {
            var activity = await result as Activity;

            string text = activity.Text.ToLower();
            if (text.Contains("pupper")) {
                string link = await Puppers.PupperPicker.GetPupper();
                await context.PostAsync($"![pupper](" + link + ")");
            } else if (text.Contains("good boy")) {
                await context.PostAsync($"Woof Woof!");
            }

            context.Wait(MessageReceivedAsync);
        }

    }
}