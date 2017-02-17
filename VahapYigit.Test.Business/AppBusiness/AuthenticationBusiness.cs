//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file WILL NOT BE LOST if the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Business
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.Threading.Tasks;

	using VahapYigit.Test.Core;
	using VahapYigit.Test.Crud;
	using VahapYigit.Test.Models;

	/// <summary>
	/// This class contains Authentication business methods.
	/// </summary>
	[BusinessClass]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public class AuthenticationBusiness : BusinessBase
	{
		#region [ Custom public methods ]

		/// <summary>
		/// Indicates whether the Username is already used in the database (User table).
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="username">
		/// Username value.
		/// </param>
		/// 
		/// <returns>
		/// True if the Username is already used in the database; otherwise, false.
		/// </returns>
		[BusinessMethod]
		public bool IsUsernameUsed(IUserContext userContext, string username)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new UserCrud(userContext))
			{
				var options = new SearchOptions();
				options.Filters.Add(User.ColumnNames.Username, FilterOperator.Equals, username);

				return db.HasResult(options);
			}
		}

		/// <summary>
		/// Indicates whether the Email is already used in the database (User table).
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="username">
		/// Email value.
		/// </param>
		/// 
		/// <returns>
		/// True if the Email is already used in the database; otherwise, false.
		/// </returns>
		[BusinessMethod]
		public bool IsEmailUsed(IUserContext userContext, string email)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new UserCrud(userContext))
			{
				var options = new SearchOptions();
				options.Filters.Add(User.ColumnNames.Email, FilterOperator.Equals, email);

				return db.HasResult(options);
			}
		}

		/// <summary>
		/// Indicates whether the user is registered in the database through the UserContext.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context (Identifier and Password properties must be set).
		/// </param>
		/// 
		/// <param name="user">
		/// The returned User entity with Roles.
		/// </param>
		/// 
		/// <returns>
		/// True if the is registered in the database; otherwise, false.
		/// </returns>
		[BusinessMethod]
		public bool IsRegistered(IUserContext userContext, out User user)
		{
			bool bIsRegistered = false;
			user = null;

			using (var et = new ExecutionTracerService())
			using (var userCrud = new UserCrud(userContext))
			using (var userRoleCrud = new UserRoleCrud(userContext))
			using (var roleCrud = new RoleCrud(userContext))
			{
				var options = new SearchOptions { MaxRecords = 1 };

				// Note about the the first parameter (orGroup) -> different values -> OR operator
				// Thus userContext.Identifier can contain either the Username or the email address (Unique constraint on these values)

				options.Filters.Add(0, User.ColumnNames.Username, FilterOperator.Equals, userContext.Identifier);
				options.Filters.Add(1, User.ColumnNames.Email, FilterOperator.Equals, userContext.Identifier);

				var users = userCrud.Search(ref options);
				if (users.Count == 1)
				{
					user = users.First();
					if (user.Password == userContext.Password) // because of French_CI_AI collation at SQL Server side (Case Insensitive, Accent Insensitive)
					{
						bIsRegistered = true;

						userCrud.LoadUserRoleCollection(ref user);
						user.UserRoleCollection.ForEach((userRole) => { userRoleCrud.LoadRole(ref userRole); });

						user.LastConnectionDate = DateTime.Now;
						userCrud.Save(ref user);
					}
				}
			}

			if (!bIsRegistered)
			{
				user = null;
			}

			return bIsRegistered;
		}

		/// <summary>
		/// Creates an User in the database.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="user">
		/// The User to create.
		/// </param>
		/// 
		/// <param name="errors">
		/// The eventual errors.
		/// </param>
		/// 
		/// <returns>
		/// True if the User has been created; otherwise, false.
		/// </returns>
		[BusinessMethod]
		public bool Create(IUserContext userContext, ref User user, out IList<TranslationEnum> errors)
		{
			bool withError = false;
			errors = new List<TranslationEnum>();

			using (var userCrud = new UserCrud(userContext))
			using (var roleCrud = new RoleCrud(userContext))
			{
				// NOTE: if you have a compilation error on 'Role.CodeRefs.Member'
				//       1. Change Role.CodeRefs.Member by ""
				//       2. Add the [CodeRef = Member, Name = Member] entry in the 'Role' table
				//       3. Compile the solution and execute LayerCake Generator
				//       4. Then change back "" to Role.CodeRefs.Member

				var memberRole = roleCrud.GetByCodeRef(Role.CodeRefs.Member);

				if (user.UserRoleCollection.Count(l => l.IdRole == memberRole.Id) == 0)
				{
					user.UserRoleCollection.Add(new UserRole { IdUser = user.Id, IdRole = memberRole.Id });
				}

				user.RegistrationDate = DateTime.Now;

				try
				{
					userCrud.Save(ref user, new SaveOptions { SaveChildren = true });

					Task.WaitAll(SendMailOnUserCreatedAsync(user)); // cannot use await because of ref/out parameters
				}
				catch (EntityValidationException evx)
				{
					withError = true;
					errors = evx.Translations;
				}
				catch (System.Net.Mail.SmtpFailedRecipientException) // Cannot deliver the mail (bad email address?)
				{
					// NOTE: if you have a compilation error on 'TranslationEnum.CustomExceptionSmtpBadRecipient'
					//       1. Comment the line
					//       2. Add the 'CustomExceptionSmtpBadRecipient' entry in the 'Translation' table
					//       3. Compile the solution
					//       4. Execute LayerCake Generator Process (Menu > Extensions > Generate Translations)
					//       5. Close LayerCake Generator
					//       6. Then uncomment the line and recompile

					withError = true;
					errors.Add(TranslationEnum.CustomExceptionSmtpBadRecipient);
				}
				catch
				{
					withError = true;
					throw;
				}
				finally
				{
					if (withError || errors.Count != 0)
					{
						if (user.IsInDb)
						{
							userCrud.Delete(user); // When the mail has not been delivered... (bad email address?)
						}
					}
				}
			}

			return !withError && errors.Count == 0;
		}

		/// <summary>
		/// Resets the password when the User has forgotten it.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="email">
		/// User's email address.
		/// </param>
		/// 
		/// <param name="passwordResponse">
		/// Response to the secret question.
		/// </param>
		/// 
		/// <returns>
		/// The new password if the passwordResponse value is correct; otherwise, 'null' value.
		/// </returns>
		[BusinessMethod]
		public string ResetPassword(IUserContext userContext, string email, string passwordResponse)
		{
			string newPassword = null;

			using (var et = new ExecutionTracerService())
			using (var db = new UserCrud(userContext))
			{
				var options = new SearchOptions();

				options.Filters.Add(User.ColumnNames.Email, FilterOperator.Equals, email);
				options.Filters.Add(User.ColumnNames.PasswordResponse, FilterOperator.Equals, passwordResponse);

				var users = db.Search(ref options);
				if (users.Count == 1)
				{
					var user = users.First();

					newPassword = RandomHelper.GetRandomString(8);
					user.Password = HashHelper.EncodeWithSha1(newPassword);

					db.Save(ref user);

					Task.Run(() => SendMailOnPasswordResetAsync(user, newPassword)); // background
				}
			}

			return newPassword;
		}

		#endregion

		#region [ Custom private methods ]

		/// <summary>
		/// Send a mail when the user's account has been created.
		/// </summary>
		/// 
		/// <param name="user">
		/// User instance.
		/// </param>
		private static async Task SendMailOnUserCreatedAsync(User user)
		{
			var templateService = new MailTemplateService("OnUserCreated"); // Load WebServices\App_Data\MailTemplates\OnUserCreated.xml

			var tokens = new Dictionary<string, object>()
            {
                { "%User.Username%", user.Username },
                { "%User.Email%", user.Email },
                { "%User.Password%", user.Password },
                { "%User.PasswordQuestion%", user.PasswordQuestion },
                { "%User.PasswordResponse%", string.Concat(user.PasswordResponse[0], "*******") },
            };

			templateService.Load(user.Culture, tokens);

			await templateService.SendByMailAsync(user.Email, new SmtpServiceOptions { IsHtmlBody = true });
		}

		/// <summary>
		/// Send a mail when the user's password has been reset.
		/// </summary>
		/// 
		/// <param name="user">
		/// User instance.
		/// </param>
		/// 
		/// <param name="newPassword">
		/// New password.
		/// </param>
		private static async Task SendMailOnPasswordResetAsync(User user, string newPassword)
		{
			var templateService = new MailTemplateService("OnPasswordReset"); 

			var tokens = new Dictionary<string, object>()
            {
                { "%User.Username%", user.Username },
                { "%User.Email%", user.Email },
                { "%User.NewPassword%", newPassword },
                { "%User.PasswordQuestion%", user.PasswordQuestion },
                { "%User.PasswordResponse%", string.Concat(user.PasswordResponse[0], "*******") },
            };

			templateService.Load(user.Culture, tokens);

			await templateService.SendByMailAsync(user.Email, new SmtpServiceOptions { IsHtmlBody = true });
		}

		#endregion
	}
}