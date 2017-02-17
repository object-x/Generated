﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Crud
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.Common;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Transactions;

	using VahapYigit.Test.Core;

	/// <summary>
	/// UserRoleCrud class used to access to the database using stored procedures.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
	public partial class UserRoleCrud : CrudBase<VahapYigit.Test.Models.UserRole>
	{
		#region [ Constructor ]

		/// <summary>
		/// Constructor.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		public UserRoleCrud(IUserContext userContext)
			: base(userContext)
		{
			base.Initialize();
		}

		#endregion

		#region [ Public methods ]
		
		/// <summary>
		/// Refreshs the entity instance from the database.
		/// </summary>
		/// 
		/// <param name="appSettings">
		/// Entity to refresh (must be in database).
		/// </param>
		public override void Refresh(ref VahapYigit.Test.Models.UserRole entity)
		{
			ConditionChecker.Required(
				entity != null,
				new ArgumentNullException("entity"));

			long id = entity.Id;

			entity = this.GetById(id);
			if (entity == null)
			{
				throw new EntityNotFoundException(VahapYigit.Test.Models.UserRole.EntityName, id);
			}
		}
		
		/// <summary>
		/// Gets an entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The entity.
		/// </returns>
		public override VahapYigit.Test.Models.UserRole GetById(long id)
		{
			using (var et = new ExecutionTracerService())
			{
				VahapYigit.Test.Models.UserRole entity = null;

				var parameters = new Dictionary<string, object>();

				parameters.Add("@UserRole_Id", id);

				var collection = base.ToEntityCollection("UserRole_Get", parameters, withDeepMapping: false);
				if (!collection.IsNullOrEmpty())
				{
					entity = collection[0];
				}

				return entity;
			}
		}

		/// <summary>
		/// Gets all the UserRole entities associated to a given User.
		/// </summary>
		/// 
		/// <param name="idUser">
		/// Unique ID of the User.
		/// </param>
		/// 
		/// <returns>
		/// A collection of UserRole entities.
		/// </returns>
		public TCollection<VahapYigit.Test.Models.UserRole> GetByIdUser(long idUser)
		{
			var options = new SearchOptions();
			options.Filters.Add(VahapYigit.Test.Models.UserRole.ColumnNames.IdUser, FilterOperator.Equals, idUser);

			return this.Search(ref options);
		}

		/// <summary>
		/// Searchs entities with search options.
		/// </summary>
		/// 
		/// <param name="options">
		/// Optional options, filters, orderby, paging, etc.
		/// </param>
		/// 
		/// <returns>
		/// A collection of entities.
		/// </returns>
		public override TCollection<VahapYigit.Test.Models.UserRole> Search(ref SearchOptions options)
		{
			TCollection<VahapYigit.Test.Models.UserRole> collection = null;
			
			using (var et = new ExecutionTracerService())
			{
				if (options == null)
				{
					options = new SearchOptions();
				}

				var parameters = new Dictionary<string, object>();

				if (!options.Filters.IsNullOrEmpty())
				{
					parameters.Add("Filter", options.Filters.ToSql());
				}

				if (!options.Orders.IsNullOrEmpty())
				{
					parameters.Add("OrderBy", options.Orders.ToSql());
				}

				int maxRecords = int.MaxValue;
				if (options.MaxRecords != 0)
				{
					maxRecords = (options.MaxRecords < 0) ? 0 : options.MaxRecords;
				}

				parameters.Add("MaxRecords", maxRecords);

				parameters.Add("CtxWithPaging", options.WithPaging);
				parameters.Add("CtxPagingCurrentPage", options.PagingOptions.CurrentPage);
				parameters.Add("CtxPagingRecordsPerPage", options.PagingOptions.RecordsPerPage);

				DbConnection dbConnection;

				using (var dbReader = this.ToDataReader("UserRole_Search", parameters, out dbConnection))
				{
					collection = this.Map(dbReader);

					dbReader.NextResult();
					dbReader.Read();

					options.PagingOptions.TotalRecords = TypeHelper.To<int>(dbReader[0]);
				}

				if (dbConnection != null)
					dbConnection.Close();
			}

			return collection;
		}

		/// <summary>
		/// Gets the number of records that verify the search options.
		/// </summary>
		/// 
		/// <param name="options">
		/// Optional search options. If not defined all records are counted.
		/// </param>
		/// 
		/// <returns>
		/// The number of records.
		/// </returns>
		public override int Count(SearchOptions options = null)
		{
			using (var et = new ExecutionTracerService())
			{
				if (options == null)
				{
					options = new SearchOptions();
				}

				var parameters = new Dictionary<string, object>();

				if (!options.Filters.IsNullOrEmpty())
				{
					parameters.Add("Filter", options.Filters.ToSql());
				}

				return base.ExecuteScalar<int>("UserRole_Count", parameters);
			}
		}
		
		/// <summary>
		/// Saves (or updates) the entity in the database.
		/// </summary>
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
		public override int Save(ref VahapYigit.Test.Models.UserRole entity, SaveOptions options = null)
		{
			ConditionChecker.Required(
				entity != null,
				new ArgumentNullException("entity"));

			if (options == null)
			{
				options = SaveOptions.Default;
			}

			int rowCount = 0;

			using (var scope = TransactionScopeHelper.CreateDefaultTransactionScope())
			{
				this.OnSaving(ref entity, options);

				if (options.SaveChildren)
				{
					rowCount = this.PersistWithChildren(ref entity, new ObjectIDGenerator(), options);
				}
				else
				{
					rowCount = this.Persist(ref entity, options);
				}
				
				this.OnSaved(ref entity, options);

				scope.Complete();
			}

			return rowCount;
		}
		
		/// <summary>
		/// Saves or updates the entity without its children.
		/// </summary>
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
		private int Persist(ref VahapYigit.Test.Models.UserRole entity, SaveOptions options = null)
		{
			if (entity.State !=VahapYigit.Test.Models.EntityState.ToInsert && 
				entity.State !=VahapYigit.Test.Models.EntityState.ToUpdate)
			{
				return 0;
			}

			IList<TranslationEnum> errors;
			if (!entity.IsValid(out errors))
			{
				throw new EntityValidationException(errors);
			}

			int rowCount = 0;

			using (var et = new ExecutionTracerService(tag: entity.State.ToString()))
			{
				if (options.CheckUniqueConstraints)
				{
					IList<TranslationEnum> ucErrors = new List<TranslationEnum>();
					SearchOptions searchOpts = new SearchOptions();

					searchOpts.Clear();

					if (entity.State ==VahapYigit.Test.Models.EntityState.ToUpdate)
					{
						searchOpts.Filters.Add(VahapYigit.Test.Models.UserRole.ColumnNames.Id, FilterOperator.Different, entity.Id);
					}

					searchOpts.Filters.Add(VahapYigit.Test.Models.UserRole.ColumnNames.IdUser, FilterOperator.Equals, entity.IdUser);
					searchOpts.Filters.Add(VahapYigit.Test.Models.UserRole.ColumnNames.IdRole, FilterOperator.Equals, entity.IdRole);

					if (this.HasResult(searchOpts))
					{
						ucErrors.Add(TranslationEnum.CrudUserRoleIdUser_IdRoleUniqueConstraint);
					}

					if (ucErrors.Count != 0)
					{
						throw new EntityValidationException(ucErrors);
					}
				}

				var parameters = new Dictionary<string, object>();

				parameters.Add("@UserRole_Id", entity.Id);
				parameters.Add("@UserRole_IdUser", entity.IdUser);
				parameters.Add("@UserRole_IdRole", entity.IdRole);

				var collection = base.ToEntityCollection("UserRole_Save", parameters, withDeepMapping: false);
				if (!collection.IsNullOrEmpty())
				{
					entity.Map(collection[0]);
					rowCount = 1;
				}

				return rowCount;
			}
		}
		
		/// <summary>
		/// Saves or updates the entity without its children.
		/// </summary>
		/// 
		/// <param name="entity">
		/// Entity to save or update.
		/// </param>
		/// 
		/// <param name="idGenerator">
		/// ObjectIDGenerator instance to generate IDs for objects.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional options.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		internal int PersistWithChildren(ref VahapYigit.Test.Models.UserRole entity, ObjectIDGenerator idGenerator, SaveOptions options = null)
		{
			int rowCount = 0;

			if (entity.User != null && idGenerator.HasId(entity.User, withForceId: true) == 0)
			{
				using (var  db = new UserCrud(base.UserContext))
				{
					var child = entity.User;

					rowCount += db.PersistWithChildren(ref child, idGenerator, options);

					entity.IdUser = child.Id;
				}
			}

			if (entity.Role != null && idGenerator.HasId(entity.Role, withForceId: true) == 0)
			{
				using (var  db = new RoleCrud(base.UserContext))
				{
					var child = entity.Role;

					rowCount += db.PersistWithChildren(ref child, idGenerator, options);

					entity.IdRole = child.Id;
				}
			}

			rowCount += this.Persist(ref entity, options);

			return rowCount;
		}
		
		/// <summary>
		/// Deletes the entity from the database.
		/// </summary>
		/// 
		/// <param name="entity">
		/// Entity to delete.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		public override int Delete(VahapYigit.Test.Models.UserRole entity)
		{
			int rowCount = 0;

			if (entity != null)
			{
				rowCount = this.Delete(entity.Id);
				if (rowCount > 0)
				{				
					entity.Id = 0;
					entity.State =VahapYigit.Test.Models.EntityState.Deleted;
				}
			}

			return rowCount;
		}

		/// <summary>
		/// Deletes the entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		public override int Delete(long id)
		{
			int rowCount = 0;

			using (var et = new ExecutionTracerService())
			using (var scope = TransactionScopeHelper.CreateDefaultTransactionScope())
			{
				this.OnDeleting(id);

				var parameters = new Dictionary<string, object>();

				parameters.Add("@UserRole_Id", id);

				rowCount = base.ExecuteScalar<int>("UserRole_Delete", parameters);

				this.OnDeleted(id);

				scope.Complete();
			}

			return rowCount;
		}

		/// <summary>
		/// Loads the User entity associated to the current instance (entity.User property).
		/// </summary>
		/// 
		/// <param name="entity">
		/// The target entity.
		/// </param>
		public void LoadUser(ref VahapYigit.Test.Models.UserRole entity)
		{
			if (entity != null)
			{
				var options = new SearchOptions();
				options.Filters.Add(VahapYigit.Test.Models.User.ColumnNames.Id, FilterOperator.Equals, entity.IdUser);

				using (var  db = new UserCrud(base.UserContext))
				{
					var collection = db.Search(ref options);
					if (collection.Count == 1)
					{
						entity.User = collection[0];
						entity.User.UserRoleCollection.Add(entity);
					}
				}
			}
		}

		/// <summary>
		/// Loads the Role entity associated to the current instance (entity.Role property).
		/// </summary>
		/// 
		/// <param name="entity">
		/// The target entity.
		/// </param>
		public void LoadRole(ref VahapYigit.Test.Models.UserRole entity)
		{
			if (entity != null)
			{
				var options = new SearchOptions();
				options.Filters.Add(VahapYigit.Test.Models.Role.ColumnNames.Id, FilterOperator.Equals, entity.IdRole);

				using (var  db = new RoleCrud(base.UserContext))
				{
					var collection = db.Search(ref options);
					if (collection.Count == 1)
					{
						entity.Role = collection[0];
						entity.Role.UserRoleCollection.Add(entity);
					}
				}
			}
		}

		/// <summary>
		/// Converts an IDataReader to a TCollection WITHOUT associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// IDataReader source.
		/// </param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.UserRole> Map(IDataReader dbReader)
		{
			var collection = new TCollection<VahapYigit.Test.Models.UserRole>();

			while (dbReader.Read())
			{
				var entity = new VahapYigit.Test.Models.UserRole();
				entity.Map(dbReader, base.UserContext);

				var currentUserRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentUserRole == null)
				{
					collection.Add(entity);
					currentUserRole = entity;
				}
			}

			return collection;
		}
		
		/// <summary>
		/// Converts an DataTable to a TCollection WITHOUT associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// DataTable source.
		/// </param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.UserRole> Map(DataTable source)
		{
			var collection = new TCollection<VahapYigit.Test.Models.UserRole>();

			foreach (DataRow row in source.Rows)
			{
				var entity = new VahapYigit.Test.Models.UserRole();
				entity.Map(row, base.UserContext);

				var currentUserRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentUserRole == null)
				{
					collection.Add(entity);
					currentUserRole = entity;
				}
			}

			return collection;
		}
		
		/// <summary>
		/// Converts an IDataReader to a TCollection WITH possible associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// IDataReader source.
		///</param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.UserRole> DeepMap(IDataReader dbReader)
		{
			var collection = new TCollection<VahapYigit.Test.Models.UserRole>();

			while (dbReader.Read())
			{
				var entity = new VahapYigit.Test.Models.UserRole();
				entity.DeepMap(dbReader, base.UserContext);

				var currentUserRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentUserRole == null)
				{
					collection.Add(entity);
					currentUserRole = entity;
				}
			}

			return collection;
		}
		
		/// <summary>
		/// Converts an DataTable to a TCollection WITH possible associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// DataTable source.
		/// </param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.UserRole> DeepMap(DataTable source)
		{
			var collection = new TCollection<VahapYigit.Test.Models.UserRole>();

			foreach (DataRow row in source.Rows)
			{
				var entity = new VahapYigit.Test.Models.UserRole();
				entity.DeepMap(row, base.UserContext);

				var currentUserRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentUserRole == null)
				{
					collection.Add(entity);
					currentUserRole = entity;
				}
			}

			return collection;
		}

		#endregion

		#region [ Partial methods ]

		partial void OnSaving(ref VahapYigit.Test.Models.UserRole entity, SaveOptions options);
		partial void OnSaved(ref VahapYigit.Test.Models.UserRole entity, SaveOptions option);

		partial void OnDeleting(long id);
		partial void OnDeleted(long id);

		#endregion
	}
}
