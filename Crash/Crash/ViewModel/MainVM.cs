using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Essentials;

namespace Crash.ViewModel
{
	public class MainVM : ViewModelBase
	{
		private RelayCommand _sendMailCommand;
		public RelayCommand SendMailCommand => _sendMailCommand ?? (_sendMailCommand = new RelayCommand(SendMailAsync));

		private async void SendMailAsync()
		{
			EmailMessage message = new EmailMessage
			{
				Subject = "Crash",
				Body = "Test",
				BodyFormat = EmailBodyFormat.PlainText,
				To = new List<string> { "test@example.com" },
				Cc = new List<string> { String.Empty },
				Bcc = new List<string> { String.Empty },
			};

			await Email.ComposeAsync(message);
		}
	}
}
