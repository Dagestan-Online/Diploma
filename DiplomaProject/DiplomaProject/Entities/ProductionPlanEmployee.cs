//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomaProject.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductionPlanEmployee
    {
        public int id { get; set; }
        public Nullable<int> id_plan { get; set; }
        public Nullable<int> id_employee { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ProductionPlan ProductionPlan { get; set; }
    }
}