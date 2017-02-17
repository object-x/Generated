﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Contracts
{
	using System;
	using System.Net.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.Threading.Tasks;
	using System.Xml;

	/// <summary>
	/// AuthenticationService Contract.
	/// </summary>
	[ServiceContract(Namespace = VahapYigit.Test.Core.Globals.Namespace)]
	[ServiceKnownType(typeof(VahapYigit.Test.Core.ClientContext))]
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	public partial interface IAuthenticationService : IService
	{
		#region [ IAuthenticationService Business ]
		#pragma warning disable 1591 // Disable 'missing XML comment for publicly visible type or member' warnings

		[OperationContract(Name = "IsUsernameUsed")]
		bool IsUsernameUsed(VahapYigit.Test.Core.IUserContext userContext, string username);
		
		[OperationContract(Name = "IsEmailUsed")]
		bool IsEmailUsed(VahapYigit.Test.Core.IUserContext userContext, string email);
		
		[OperationContract(Name = "IsRegistered")]
		bool IsRegistered(VahapYigit.Test.Core.IUserContext userContext, out VahapYigit.Test.Models.User user);
		
		[OperationContract(Name = "Create")]
		bool Create(VahapYigit.Test.Core.IUserContext userContext, ref VahapYigit.Test.Models.User user, out System.Collections.Generic.IList<VahapYigit.Test.Core.TranslationEnum> errors);
		
		[OperationContract(Name = "ResetPassword")]
		string ResetPassword(VahapYigit.Test.Core.IUserContext userContext, string email, string passwordResponse);
		
		#pragma warning restore 1591
		#endregion
	}
}