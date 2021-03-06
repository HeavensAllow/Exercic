﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmacyEx
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExFarmaciasEntities : DbContext
    {
        public ExFarmaciasEntities()
            : base("name=ExFarmaciasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
    
        public virtual int CreatePharmacy(Nullable<int> code, string name, string city, Nullable<System.DateTime> createdOn, string createdBy)
        {
            var codeParameter = code.HasValue ?
                new ObjectParameter("Code", code) :
                new ObjectParameter("Code", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var createdOnParameter = createdOn.HasValue ?
                new ObjectParameter("CreatedOn", createdOn) :
                new ObjectParameter("CreatedOn", typeof(System.DateTime));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePharmacy", codeParameter, nameParameter, cityParameter, createdOnParameter, createdByParameter);
        }
    
        public virtual int DeletePharmacy(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePharmacy", iDParameter);
        }
    
        public virtual ObjectResult<ListPharmacy_Result> ListPharmacy()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListPharmacy_Result>("ListPharmacy");
        }
    
        public virtual ObjectResult<Nullable<int>> ReadPharmacy(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ReadPharmacy", iDParameter);
        }
    
        public virtual int UpdatePharmacy(Nullable<int> iD, string name, string city, Nullable<System.DateTime> updatedOn, string updatedBy)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var updatedOnParameter = updatedOn.HasValue ?
                new ObjectParameter("UpdatedOn", updatedOn) :
                new ObjectParameter("UpdatedOn", typeof(System.DateTime));
    
            var updatedByParameter = updatedBy != null ?
                new ObjectParameter("UpdatedBy", updatedBy) :
                new ObjectParameter("UpdatedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePharmacy", iDParameter, nameParameter, cityParameter, updatedOnParameter, updatedByParameter);
        }
    }
}
