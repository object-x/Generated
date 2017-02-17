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
	/// RoleService Contract.
	/// </summary>
	[ServiceContract(Namespace = VahapYigit.Test.Core.Globals.Namespace)]
	[ServiceKnownType(typeof(VahapYigit.Test.Core.ClientContext))]
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	public partial interface IRoleService : IService
	{
		#region [ IRoleService ]
		
		/// <summary>
		/// Refreshs the entity instance from the database.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="appSettings">
		/// Entity to refresh (must be in database).
		/// </param>
		[OperationContract(Name = "GeneratedRefresh")]
		void Refresh(VahapYigit.Test.Core.IUserContext userContext, ref VahapYigit.Test.Models.Role entity);
		
		/// <summary>
		/// Gets an entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The entity.
		/// </returns>
		[OperationContract(Name = "GeneratedGetById")]
		VahapYigit.Test.Models.Role GetById(VahapYigit.Test.Core.IUserContext userContext, long id);
		
		/// <summary>
		/// Gets an entity given its unique CodeRef value.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="codeRef">
		/// Unique CodeRef value.
		/// </param>
		/// 
		/// <returns>
		/// The entity.
		/// </returns>
		[OperationContract(Name = "GeneratedGetByCodeRef")]
		VahapYigit.Test.Models.Role GetByCodeRef(VahapYigit.Test.Core.IUserContext userContext, string codeRef);

		/// <summary>
		/// Gets entities with search options.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional options, filters, orderby, paging, etc..
		/// </param>
		/// 
		/// <returns>
		/// A collection of entities.
		/// </returns>
		[OperationContract(Name = "GeneratedSearch")]
		TCollection<VahapYigit.Test.Models.Role> Search(VahapYigit.Test.Core.IUserContext userContext, ref VahapYigit.Test.Core.SearchOptions options);
		
		/// <summary>
		/// Gets the number of records that verify the search options.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional search options. If not defined all records are counted.
		/// </param>
		/// 
		/// <returns>
		/// The number of records.
		/// </returns>
		[OperationContract(Name = "GeneratedCount")]
		int Count(VahapYigit.Test.Core.IUserContext userContext, VahapYigit.Test.Core.SearchOptions options = null);
		
		/// <summary>
		/// Indicates whether the search returns at least 1 entity.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional options, filters, orderby, paging, etc.
		/// </param>
		/// 
		/// <returns>
		/// True if the search returns at least 1 entity; otherwise, false.
		/// </returns>
		[OperationContract(Name = "GeneratedHasResult")]
		bool HasResult(VahapYigit.Test.Core.IUserContext userContext, VahapYigit.Test.Core.SearchOptions options = null);
		
		/// <summary>
		/// Saves (or updates) the entity in the database.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		///
		/// <param name="entity">
		/// Entity to save or update.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional options.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		[OperationContract(Name = "GeneratedSave")]
		int Save(VahapYigit.Test.Core.IUserContext userContext, ref VahapYigit.Test.Models.Role entity, VahapYigit.Test.Core.SaveOptions options = null);
		
		/// <summary>
		/// Deletes the entity from the database.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="entity">
		/// Entity to delete.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		[OperationContract(Name = "GeneratedDelete")]
		int Delete(VahapYigit.Test.Core.IUserContext userContext,VahapYigit.Test.Models.Role entity);
		
		/// <summary>
		/// Deletes the entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		[OperationContract(Name = "GeneratedDeleteById")]
		int Delete(VahapYigit.Test.Core.IUserContext userContext, long id);

		/// <summary>
		/// Loads the UserRole entities associated to the current instance (entity.UserRoleCollection property).
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="entity">
		/// The target entity.
		/// </param>
		[OperationContract(Name = "GeneratedLoadUserRoleCollection")]
		void LoadUserRoleCollection(VahapYigit.Test.Core.IUserContext userContext, ref VahapYigit.Test.Models.Role entity);

		/// <summary>
		/// Loads the UserRole entities associated to the instances (entity.UserRole collection property).
		/// </summary>
		/// 
		/// <param name="collection">
		/// The target entity collection.
		/// </param>
		[OperationContract(Name = "GeneratedLoadUserRoleCollectionEx")]
		void LoadUserRoleCollection(VahapYigit.Test.Core.IUserContext userContext, TCollection<VahapYigit.Test.Models.Role> collection);

		#endregion

	}
}