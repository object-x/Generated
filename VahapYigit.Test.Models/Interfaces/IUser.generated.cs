﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Models
{
	using System;

	using VahapYigit.Test.Core;

	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	public partial interface IUser : IEntity
	{
		#region [ Properties ]

		/// <summary>
		/// Gets or sets the Username value (MANDATORY). 
		/// </summary>
		string Username { get; set; }

		/// <summary>
		/// Gets or sets the Password value (MANDATORY). 
		/// </summary>
		string Password { get; set; }

		/// <summary>
		/// Gets or sets the Email value (MANDATORY). 
		/// </summary>
		string Email { get; set; }

		/// <summary>
		/// Gets or sets the PasswordQuestion value (MANDATORY). 
		/// </summary>
		string PasswordQuestion { get; set; }

		/// <summary>
		/// Gets or sets the PasswordResponse value (MANDATORY). 
		/// </summary>
		string PasswordResponse { get; set; }

		/// <summary>
		/// Gets or sets the RegistrationDate value (MANDATORY). 
		/// </summary>
		DateTime RegistrationDate { get; set; }

		/// <summary>
		/// Gets or sets the LastConnectionDate value (OPTIONAL). 
		/// </summary>
		DateTime? LastConnectionDate { get; set; }

		/// <summary>
		/// Gets or sets the Culture value (MANDATORY). The Culture must be 2 characters long
		/// </summary>
		string Culture { get; set; }


		#endregion

		#region [ References ]

		/// <summary>
		/// Referenced UserRole entity collection by this entity.
		/// </summary>
		TCollection<UserRole> UserRoleCollection { get; set; }

		#endregion
	}
	
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	public static partial class IUserExtensions
	{
		public static void MapFrom(this IUser target, IUser source)
		{
			if (source != null)
			{
				if (target != null)
				{
					target.Username = source.Username;
					target.Password = source.Password;
					target.Email = source.Email;
					target.PasswordQuestion = source.PasswordQuestion;
					target.PasswordResponse = source.PasswordResponse;
					target.RegistrationDate = source.RegistrationDate;
					target.LastConnectionDate = source.LastConnectionDate;
					target.Culture = source.Culture;
				}
			}
		}

		public static void MapTo(this IUser source, IUser target)
		{
			target.MapFrom(source);
		}
	}
}